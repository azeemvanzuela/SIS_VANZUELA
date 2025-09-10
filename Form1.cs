using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.Admin;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string userEmail;
        private string resetToken;
        private DateTime expiryTime;

        AdminDashboard admin;
        Student student;
        Teachers teacher;

        int count = 0;
        DateTime datetoday = DateTime.Today;

        public Form1()
        {
            InitializeComponent();

            loginPanel.BackColor = Color.FromArgb(80, 186, 85, 211);
            bgPanel.BackColor = Color.FromArgb(100, 0, 0, 0);

            txtUsername.AutoSize = false;
            txtUsername.Size = new Size(300, 30);
            txtPassword.AutoSize = false;
            txtPassword.Size = new Size(300, 30);

            
  




        }



        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            //Reset count every new day
            if (datetoday.Date != DateTime.Today)
            {
                count = 0;
                datetoday = DateTime.Today;
            }
            if (count >= 3)
            {
                MessageBox.Show("You have exceeded the maximum number of login attempts for today. Please try again tomorrow.", "Login Attempts Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            //connection string to connect database to c#
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connection))
            {

                conn.Open(); //open connection
                try
                {
                    //restriction
                    if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Input fields cannot be empty. Please enter username or password.", "Empty fields", MessageBoxButtons.OK);
                        return;
                    }

                    //password hashing matching with database
                    string hashedPassword = securityHelper.HashPassword(password);

                    //sql query to check if username and password are correct
                    string sql = "SELECT * FROM user_login WHERE username = @username AND password_hash = @password";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //prevent sql injection use parameterized query
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        SqlDataReader rdr = cmd.ExecuteReader();

                        //if username and password are correct
                        if (rdr.Read())
                        {


                            var id = rdr.GetInt32(0);
                            var user = rdr.GetString(1);
                            var pass = rdr.GetString(2);
                            var role_id = rdr.GetInt32(4);

                            if (role_id == 1)
                            {
                                AdminDashboard admin = new AdminDashboard();
                                admin.Show();
                                admin.lblWelcome.Text = "Welcome. " + user + "!";
                                this.Hide();
                            }
                            else if (role_id == 2)
                            {
                                Student student = new Student();
                                student.Show();
                                student.lblWelcome.Text = "Welcome. " + user + "!";
                                this.Hide();
                            }
                            else if (role_id == 3)
                            {
                                Teachers teacher = new Teachers();
                                teacher.Show();
                                teacher.lblWelcome.Text = "Welcome. " + user + "!"; // Display username on dashboard
                                this.Hide();
                            }
                            count = 0; //reset count if login is successful
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        else
                        {
                            count++; //increment count if login fails
                            MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unexpected error: " + ex.Message);

                }

            }

        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            ResetPassword forgotPass = new ResetPassword(userEmail, resetToken, expiryTime);
            forgotPass.Show();
        }

       

       
    }

        
   }

    





