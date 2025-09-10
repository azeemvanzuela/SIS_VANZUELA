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

namespace WindowsFormsApp1.Admin
{
    public partial class AddTeacher : Form
    {
        
        public AddTeacher()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
            lblStatus.Visible = false;
            cboStatus.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";   

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string hashedPassword = securityHelper.HashPassword(txtPass.Text);
                    string sqlTeacher = "UPDATE Teacher SET first_name = @firstname, last_name = @lastname, email = @email, phone = @phone, hire_date = @hiredate, department = @department, specialization = @specialization, status = @status WHERE account_id = @Id";
                    SqlCommand cmdTeacher = new SqlCommand(sqlTeacher, conn, transaction);

                    cmdTeacher.Parameters.AddWithValue("@firstname", txtFname.Text);
                    cmdTeacher.Parameters.AddWithValue("@lastname", txtLname.Text);
                    cmdTeacher.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdTeacher.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmdTeacher.Parameters.AddWithValue("@hiredate", dtpHireDate.Value.ToString("yyyy/dd/MM"));
                    cmdTeacher.Parameters.AddWithValue("@department", txtDepartment.Text);
                    cmdTeacher.Parameters.AddWithValue("@specialization", txtSpecialization.Text);
                    cmdTeacher.Parameters.AddWithValue("@status", cboStatus.SelectedIndex);
                    cmdTeacher.Parameters.AddWithValue("@Id", lblId.Text);

                    cmdTeacher.ExecuteNonQuery();

                    string sqlUser = "UPDATE user_login SET username = @username, password_hash = @password, email = @email WHERE user_id = @Id";
                    SqlCommand cmdUser = new SqlCommand(sqlUser, conn, transaction);

                    cmdUser.Parameters.AddWithValue("@username", txtUser.Text);
                    cmdUser.Parameters.AddWithValue("@password", hashedPassword);
                    cmdUser.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdUser.Parameters.AddWithValue("@Id", lblId.Text);

                    cmdUser.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erorr updating teacher:" + ex.Message);
                    return;
                }
                finally
                {
                    transaction.Commit();

                    MessageBox.Show("Teacher updated successfully!");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string hashedPassword = securityHelper.HashPassword(txtPass.Text);
                    string sqlUser = "INSERT INTO user_login (username, password_hash, role_id) VALUES (@username, @password, @role);" + "SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdUser = new SqlCommand(sqlUser, conn, transaction);
                    int newUserId = Convert.ToInt32(cmdUser.ExecuteScalar());


                    string sqlTeacher = "INSERT INTO Teacher (first_name, last_name, email, phone, hire_date, department, specialization, status, role_id, account_id) VALUES ('"+txtFname.Text + "','" + txtLname.Text + "','" + txtEmail.Text + "','" + txtPhone.Text + "','" + dtpHireDate.Value.ToString("yyyy/MM/dd") + "','" + txtDepartment.Text + "','" + txtSpecialization.Text + "','"+"Active"+"'," + 3 + ", '"+newUserId+"')";
                    SqlCommand cmdTeacher = new SqlCommand(sqlTeacher, conn, transaction);
                    cmdTeacher.ExecuteNonQuery();

                  

                    transaction.Commit();

                    MessageBox.Show("Teacher added successfully!");
                  
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error adding teacher: " + ex.Message);
                   
                }
                
            }

        }
    }
}
