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

namespace Employee_Management_System
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\DESKTOP-ELOH3JS.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void Btnback_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void fetchempdata()
        {
            if (EmpId.Text == "")
            {
                MessageBox.Show("Enter Employee Id");
            }else

                con.Open();
            string query = "select * from EmployeeTable where EmpId='" + EmpId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                EmpName.Text = dr["EmpName"].ToString();

                EmpPosition.Text = dr["EmpPosition"].ToString();


            }
            con.Close();
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }
        int Dailybase,Total;

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            if (EmpPosition.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if (number.Text == "" || Convert.ToInt32(number.Text) > 26)
            {
                MessageBox.Show("Enter vaild number of days");
            } else
            {
                if (EmpPosition.Text == "Cutting Operator")
                {
                    Dailybase = 1500;
                }
                else if (EmpPosition.Text == "Line Supervisor")
                {
                    Dailybase = 2000;
                }
                else if (EmpPosition.Text == "Tailor / Sewer")
                {
                    Dailybase = 1500;
                }
                else if (EmpPosition.Text == "Trimmer")
                {
                    Dailybase = 1500;
                }
                else 
                {
                    Dailybase = 2000;
                }
                Total = Dailybase * Convert.ToInt32(number.Text);
                work.Text = EmpId.Text + "\n" + EmpName.Text + "\n" + EmpPosition.Text + "\n" + work.Text + "\n" + Dailybase + "\n" + Total;

            }

        }
    }
}
        