using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Admin
{
    public partial class AddStudent : Form
    {
       
        public AddStudent()
        {
            InitializeComponent();
            btnUpdate.Visible = false; // Hide the Update button initially to display add button

        }

        
         

        private void btnAdd_Click(object sender, EventArgs e)
        {

           
           
            string connection= "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); //use transaction to ensure both inserts succeed or fail together (used if there are multiple related operations

                try
                {
                    string hashedPassword = securityHelper.HashPassword(txtPass.Text); //hash the password before storing it in the database
                    string sqlUser = "INSERT INTO user_login (username, password_hash, email, role_id) VALUES (@username, @password, @email, @role_id);" + "SELECT SCOPE_IDENTITY();";
                      
                    SqlCommand cmdUser = new SqlCommand(sqlUser, conn, transaction);

                    //use parameterized query to prevent sql injection
                    cmdUser.Parameters.AddWithValue("@username", txtUser.Text);
                    cmdUser.Parameters.AddWithValue("@password", hashedPassword);
                    cmdUser.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdUser.Parameters.AddWithValue("@role_id", 2);
                    int newUserId = Convert.ToInt32(cmdUser.ExecuteScalar());



                    //Insert into Student table
                    string sqlStudent = "INSERT INTO Student (first_name, last_name, date_of_birth, gender, email, phone, address, enrollment_date, status, role_id, account_id, IsDeleted) VALUES (@firstname, @lastname, @birthday, @gender, @email, @phone, @address, @enrollmentdate, @status, @role_id, @account_id, @isdeleted)";
                    SqlCommand cmdStudent = new SqlCommand(sqlStudent, conn, transaction);

                    cmdStudent.Parameters.AddWithValue("@firstname", txtFname.Text);
                    cmdStudent.Parameters.AddWithValue("@lastname", txtLname.Text);
                    cmdStudent.Parameters.AddWithValue("@birthday", dtpBday.Value.ToString("yyyy/MM/dd"));
                    cmdStudent.Parameters.AddWithValue("@gender", rdoMale.Checked ? "Male" : "Female");
                    cmdStudent.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdStudent.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmdStudent.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmdStudent.Parameters.AddWithValue("@enrollmentdate", dtpEnrollment.Value.ToString("yyyy/MM/dd"));
                    cmdStudent.Parameters.AddWithValue("@status", "Active");
                    cmdStudent.Parameters.AddWithValue("@role_id", 2);
                    cmdStudent.Parameters.AddWithValue("@account_id", newUserId);
                    cmdStudent.Parameters.AddWithValue("@isdeleted", 1);


                    cmdStudent.ExecuteNonQuery(); //execute the insert command (non-query since it does not return any data)

                    transaction.Commit(); //commit the transaction if both inserts succeed 

                    MessageBox.Show("Student added successfully!");
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); //rollback the transaction if any insert fails
                    MessageBox.Show("Error adding student: " + ex.Message);
                }
            }
 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFname.Clear();
            txtLname.Clear();
            dtpBday.Value = DateTime.Now;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpEnrollment.Value = DateTime.Now;
            txtUser.Clear();
            txtPass.Clear();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string hashedPassword = securityHelper.HashPassword(txtPass.Text);
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    //this is concatenation, be cautious of sql injection (parameterized query recommended)
                    string sqlStudent = "UPDATE Student SET first_name = @firstname, last_name = @lastname, date_of_birth = @birthday, gender = @gender, email = @email, phone = @phone, address = @address, enrollment_date = @enrollment WHERE account_id = @Id";
                    SqlCommand cmdStudent = new SqlCommand(sqlStudent, conn, transaction);
                    

                    cmdStudent.Parameters.AddWithValue("@firstname", txtFname.Text);
                    cmdStudent.Parameters.AddWithValue("@lastname", txtLname.Text);
                    cmdStudent.Parameters.AddWithValue("@birthday", dtpBday.Value.ToString("yyyy/dd/MM"));
                    cmdStudent.Parameters.AddWithValue("@gender", rdoFemale.Checked ? "Male" : "Female");
                    cmdStudent.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdStudent.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmdStudent.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmdStudent.Parameters.AddWithValue("@enrollment", dtpEnrollment.Value.ToString("yyyy/dd/MM"));
                    cmdStudent.Parameters.AddWithValue("@Id", lblId.Text);

                    cmdStudent.ExecuteNonQuery();

                    string sqlUser = "UPDATE user_login SET username = @username, password_hash = @password, email = @email WHERE user_id = @Id";
                    SqlCommand cmdUser = new SqlCommand(sqlUser, conn, transaction);

                    cmdUser.Parameters.AddWithValue("@username", txtUser.Text);
                    cmdUser.Parameters.AddWithValue("@password", hashedPassword);
                    cmdUser.Parameters.AddWithValue("@Id", lblId.Text);
                    cmdUser.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmdUser.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error updating student: " + ex.Message);
                }
                finally
                {
                    transaction.Commit();
                    MessageBox.Show("Student updated successfully!");
                    
                }

            }
        }
    }
}
