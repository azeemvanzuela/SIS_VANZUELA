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
    public partial class DGVTeachers : Form
    {
        public DGVTeachers()
        {
            InitializeComponent();
            LoadTeachers();
            CountDisplay();
        }


        public void LoadTeachers()
        {
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string sql = "SELECT t.teacher_id, t.first_name, t.last_name, t.email, t.phone, t.hire_date, t.department, t.specialization, t.status, t.IsDeleted, ul.username, ul.password_hash, ul.user_id FROM Teacher t INNER JOIN user_login ul ON t.account_id = ul.user_id WHERE t.role_id = 3 AND t.IsDeleted=1 ORDER BY t.teacher_id DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var dataReader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);
                    DGVTeacher.DataSource = dt;
                }
            }
        }

        private void DGVTeacher_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AddTeacher updateTeacherForm = new AddTeacher();
            updateTeacherForm.Show();
            updateTeacherForm.btnUpdate.Visible = true;
            updateTeacherForm.lblStatus.Visible = true;
            updateTeacherForm.cboStatus.Visible = true;


            updateTeacherForm.lblId.Text = DGVTeacher.Rows[e.RowIndex].Cells[12].Value.ToString();

            updateTeacherForm.txtFname.Text = DGVTeacher.Rows[e.RowIndex].Cells[1].Value.ToString();
            updateTeacherForm.txtLname.Text = DGVTeacher.Rows[e.RowIndex].Cells[2].Value.ToString();
            updateTeacherForm.txtEmail.Text = DGVTeacher.Rows[e.RowIndex].Cells[3].Value.ToString();
            updateTeacherForm.txtPhone.Text = DGVTeacher.Rows[e.RowIndex].Cells[4].Value.ToString();
            updateTeacherForm.dtpHireDate.Value = Convert.ToDateTime(DGVTeacher.Rows[e.RowIndex].Cells[5].Value);
            updateTeacherForm.txtDepartment.Text = DGVTeacher.Rows[e.RowIndex].Cells[6].Value.ToString();
            updateTeacherForm.txtSpecialization.Text = DGVTeacher.Rows[e.RowIndex].Cells[7].Value.ToString();
            updateTeacherForm.txtUser.Text = DGVTeacher.Rows[e.RowIndex].Cells[10].Value.ToString();
            updateTeacherForm.txtPass.Text = DGVTeacher.Rows[e.RowIndex].Cells[11].Value.ToString();
            updateTeacherForm.cboStatus.SelectedItem = DGVTeacher.Rows[e.RowIndex].Cells[8].Value.ToString();





        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTeacher addTeacherForm = new AddTeacher();
            addTeacherForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            int accountId = Convert.ToInt32(DGVTeacher.CurrentRow.Cells["user_id"].Value);

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                try
                {
                    string sqlDeleteTeacher = "UPDATE t SET t.IsDeleted = 0 FROM Teacher t INNER JOIN user_login ul ON t.account_id = ul.user_id WHERE t.account_id = '"+accountId+"'";
                    SqlCommand cmd = new SqlCommand(sqlDeleteTeacher, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Are you sure you want to remove this teacher?", "Remove Teacher", MessageBoxButtons.YesNo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to remove this teacher: " + ex.Message);
                }
                finally
                {
                    MessageBox.Show("Successfully removed teacher!");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";
            string keyword = txtSearch.Text;
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string sqlSearchTeacher = "SELECT t.teacher_id, t.first_name, t.last_name, t.email, t.department, t.specialization, ul.username, FROM Teacher t INNER JOIN user_login ul ON t.account_id = ul.user_id " +
                    "WHERE teacher_id LIKE '%" + keyword + "%' OR first_name LIKE '%" + keyword + "%' OR last_name LIKE '%" + keyword + "%' OR email LIKE '%" + keyword + "%' OR department LIKE '%" + keyword + "%' OR specialization LIKE '%" + keyword + "%' OR username LIKE '%" + keyword + "%'";
            }
        }

        private void CountDisplay()
        {
            string connection = "Server=LAB2-PC43\\LAB3PC44;Database=Vanzuela;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string CountStudent = "SELECT COUNT(*) FROM Teacher WHERE IsDeleted = 1";

                using (SqlCommand cmd = new SqlCommand(CountStudent, conn))
                {

                    var result = cmd.ExecuteScalar();
                    lblTCount.Text = "Count: " + result.ToString();
                }
            }
        }
    }
}
