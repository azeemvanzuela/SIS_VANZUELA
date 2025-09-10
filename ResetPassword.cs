using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1.Admin
{
    public partial class ResetPassword : Form
    {

        private string userEmail;      // email entered by user
        private string resetToken;     // reset code
        private DateTime expiryTime;
        public ResetPassword(string email, string token, DateTime expiry)
        {
            InitializeComponent();

            panelNewPass.Visible = false;
            panelCode.Visible = false;
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            userEmail = txtForgotPass.Text.Trim();
            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Please enter your registered email address.");
                return;
            }

            // Validate email format
            try
            {
                var addr = new System.Net.Mail.MailAddress(userEmail);
                if (addr.Address != userEmail)
                {
                    MessageBox.Show("Invalid email format.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Check if email exists
            bool emailExists = false;
            using (SqlConnection conn = new SqlConnection("Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Trusted_Connection=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM user_login WHERE email = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    int count = (int)cmd.ExecuteScalar();
                    emailExists = count > 0;
                }
            }

            if (!emailExists)
            {
                MessageBox.Show("This email is not registered in our system.");
                return;
            }

            // Generate reset code
            resetToken = new Random().Next(100000, 999999).ToString();
            expiryTime = DateTime.Now.AddMinutes(2);

            try
            {
                GmailHelper.SendEmail(
                    userEmail,
                    "Password Reset Code",
                    $"Hello,\n\nYour password reset code is: {resetToken}\nThis code will expire in 2 minutes.\n\nIf you did not request this, ignore this email."
                );

                MessageBox.Show("Password reset code has been sent to your email.");

                // Switch to code panel
                forgotpassPanel.Visible = false;
                panelDisplay.Controls.Add(panelCode);
                panelCode.Dock = DockStyle.Fill;
                panelCode.Visible = true;
                panelCode.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string enteredCode = txtCode.Text.Trim();

            if (enteredCode != resetToken)
            {
                MessageBox.Show("Invalid reset code.");
                return;
            }

            if (DateTime.Now > expiryTime)
            {
                MessageBox.Show("Reset code has expired.");
                return;
            }

            MessageBox.Show("Code verified! Please enter your new password.");

            // Switch to new password panel
            panelCode.Visible = false;
            panelDisplay.Controls.Add(panelNewPass);
            panelNewPass.Dock = DockStyle.Fill;
            panelNewPass.Visible = true;
            panelNewPass.BringToFront();


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPass.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Please fill in both password fields.");
                return;
            }

            if (newPassword != confirmPass)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string hashedPassword = securityHelper.HashPassword(newPassword);

            using (SqlConnection conn = new SqlConnection("Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Trusted_Connection=True;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE user_login SET password_hash = @Password WHERE email = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@Email", userEmail);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Password updated successfully. You can now log in.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: Email not found in the system.");
                    }
                }
            }
            
        }
    }
}
