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
using System.Diagnostics.Eventing.Reader;

namespace Employee_Management_System
{
    public partial class Employee_Management : Form
    {
        public Employee_Management()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\DESKTOP-ELOH3JS.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void Btndelete_Click(object sender, EventArgs e)
        {
            if(EmpId.Text == "")
            {
                MessageBox.Show("Enter The Employee Id");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM EmployeeTable WHERE EmpId='" + EmpId.Text +"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)

                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {

            if (EmpId.Text == "" || EmpNameTb.Text == "" || EmpConNo.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into EmployeeTable values('"+EmpId.Text+"','"+EmpNameTb.Text+"','"+EmpDOB.Value.Date+"','"+EmpGender.SelectedItem.ToString()+"','"+EmpConNo.Text+"','"+EmpPosition.SelectedItem.ToString()+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    Con.Close();
                    populate();
                    

                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void populate()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\DESKTOP-ELOH3JS.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            string query = "select * from [EmployeeTable]";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Employee_Management_Load(object sender, EventArgs e)
        {
            populate(); 
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = EmpDGV.Rows[e.RowIndex];
            EmpId.Text = row.Cells[0].Value?.ToString();
            EmpNameTb.Text = row.Cells[1].Value?.ToString();
            EmpDOB.Text = row.Cells[2].Value?.ToString();
            EmpGender.Text = row.Cells[3].Value?.ToString();
            EmpConNo.Text = row.Cells[4].Value?.ToString();
            EmpPosition.Text = row.Cells[5].Value?.ToString();
        }
    

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (EmpId.Text == "" || EmpNameTb.Text == "" || EmpDOB.Text == "" || EmpGender.Text == "" || EmpConNo.Text == "" || EmpPosition.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "UPDATE EmployeeTable SET EmpName=@EmpName, EmpDob=@EmpDob, EmpGender=@EmpGender, EmpCoNumber=@EmpCoNumber, EmpPosition=@EmpPosition WHERE EmpId=@EmpId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@EmpName", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EmpDob", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EmpGender", EmpGender.Text);
                    cmd.Parameters.AddWithValue("@EmpCoNumber", EmpConNo.Text);
                    cmd.Parameters.AddWithValue("@EmpPosition", EmpPosition.Text);
                    cmd.Parameters.AddWithValue("@EmpId", EmpId.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
                    Con.Close();
                    populate();
                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void EmpConNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
