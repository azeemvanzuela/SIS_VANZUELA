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
using WindowsFormsApp1.Admin;


namespace WindowsFormsApp1
{
    public partial class DGVStudent : Form
    {
        public DGVStudent()
        {
            InitializeComponent();
            //Display data
            LoadStudent();
            CountDisplay();

        }

        public void LoadStudent()
        {

            //Connect database and table Student to DataGrid
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connection))
            {

                conn.Open();
                string sql = "SELECT s.student_id, s.first_name, s.last_name, s.date_of_birth, s.gender, s.email, s.phone, s.address, s.enrollment_date, s.status, s.IsDeleted, ul.username, ul.password_hash, ul.user_id FROM Student s INNER JOIN user_login ul ON s.account_id = ul.user_id WHERE ul.role_id = 2 AND s.IsDeleted = 1 ORDER BY s.student_id DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var dataReader = cmd.ExecuteReader(); //execute the query and get the results (ExecuteReader for SELECT queries)
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);
                    DGVStudents.DataSource = dt;




                }

            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent addStudentForm = new AddStudent();
            addStudentForm.Show();
        }


        private void DGVStudents_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Open AddStudent form to update student info
            AddStudent updateStudentForm = new AddStudent();
            updateStudentForm.Show();
            updateStudentForm.btnUpdate.Visible = true; //button visible (update button on the AddStudent form)
            updateStudentForm.lblId.Text = DGVStudents.Rows[e.RowIndex].Cells[13].Value.ToString(); //get the account_id or user_id from the selected student row and display on label

            updateStudentForm.lblUser.Visible = false;
            updateStudentForm.txtUser.Visible = false;
            updateStudentForm.lblPass.Visible = false;
            updateStudentForm.txtPass.Visible = false;

            //populate the fields in the AddStudent form with the selected student's data
            updateStudentForm.txtFname.Text = DGVStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
            updateStudentForm.txtLname.Text = DGVStudents.Rows[e.RowIndex].Cells[2].Value.ToString();
            updateStudentForm.dtpBday.Value = Convert.ToDateTime(DGVStudents.Rows[e.RowIndex].Cells[3].Value);
            string gender = DGVStudents.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (gender == "Male")
            {
                updateStudentForm.rdoMale.Checked = true;
            }
            else
            {
                updateStudentForm.rdoFemale.Checked = true;
            }
            updateStudentForm.txtEmail.Text = DGVStudents.Rows[e.RowIndex].Cells[5].Value.ToString();
            updateStudentForm.txtPhone.Text = DGVStudents.Rows[e.RowIndex].Cells[6].Value.ToString();
            updateStudentForm.txtAddress.Text = DGVStudents.Rows[e.RowIndex].Cells[7].Value.ToString();
            updateStudentForm.dtpEnrollment.Value = Convert.ToDateTime(DGVStudents.Rows[e.RowIndex].Cells[8].Value);
            updateStudentForm.txtUser.Text = DGVStudents.Rows[e.RowIndex].Cells[11].Value.ToString();
            updateStudentForm.txtPass.Text = DGVStudents.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connection = "SERVER=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            int accountId = Convert.ToInt32(DGVStudents.CurrentRow.Cells["user_id"].Value);

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                try
                {
                    //soft delete (data still exists in the database but marked as deleted)
                    string SqlDeleteStudents = "UPDATE s SET s.IsDeleted=0 FROM Student s INNER JOIN user_login ul ON s.account_id = ul.user_id WHERE s.account_id = '" + accountId + "'";
                    SqlCommand cmd = new SqlCommand(SqlDeleteStudents, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Are you sure you want to remove this student?", "Remove Student", MessageBoxButtons.YesNo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to remove this student: " + ex.Message);
                }
                finally
                {
                    MessageBox.Show("Successfully removed student!");

                }


            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connection = "SERVER=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            string keyword = txtSearch.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();


                //LIKE operator with wildcards (%) to search for partial matches in multiple columns
                string sqlSearchStudent = "SELECT s.student_id, s.first_name, s.last_name, ul.username, ul.email, s.email FROM Student s INNER JOIN user_login ul ON s.account_id = ul.user_id WHERE student_id LIKE '%" + keyword + "%'" +
                    "OR s.first_name LIKE '%" + keyword + "%' OR s.last_name LIKE '%" + keyword + "%' OR ul.username LIKE '%" + keyword + "%' or ul.email LIKE '%" + keyword + "%' OR s.email LIKE '%" + keyword + "%'";
                using (SqlCommand cmd = new SqlCommand(sqlSearchStudent, conn))
                {
                    var dataReader = cmd.ExecuteReader(); //execute the query and get the results
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);
                    DGVStudents.DataSource = dt;
                }

            }
        }

        private void CountDisplay()
        {
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string CountStudent = "SELECT COUNT(*) FROM Student WHERE IsDeleted = 1";

                using (SqlCommand cmd = new SqlCommand(CountStudent, conn))
                {

                    var result = cmd.ExecuteScalar();
                    lblSCount.Text = "Count: " + result.ToString();
                }
            }
        }
    }
}
