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
    public partial class View : Form
    {

        public View()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\DESKTOP-ELOH3JS.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        
        private void Btnback_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from EmployeeTable where EmpId='" + EmpId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmpId.Text = dr["EmpId"].ToString();
                lblName.Text = dr["EmpName"].ToString();
                lblDOB.Text = dr["EmpDOB"].ToString();
                lblGender.Text = dr["EmpGender"].ToString();
                
                lblPosition.Text = dr["EmpPosition"].ToString();
                EmpId.Visible= true;
                lblName.Visible = true;
                lblDOB.Visible = true;
                lblGender.Visible = true;
                
                lblPosition.Visible = true;
            }
            Con.Close();
        }
        private void View_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}