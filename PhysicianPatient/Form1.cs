/* 
 * Course:       DBAS 5206 02
 * Group Number: 6
 * Group member: Bei Jia, Yuqi Zhou, Vishwa Patel, Chiao-Yun Chung
 * Description:  Dashboard made for Project
 */

using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicianPatient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-ECN134CA;Initial Catalog=DB_LRCH;User ID=sa;Password=123");
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();

            //SqlCommand com = new SqlCommand("exec sp_GetBedOccupancy", con);
            //SqlCommand com2 = new SqlCommand("exec CountAppointment'"+ int.Parse(txtId.Text) + "','"+ lblNumber.Text+"'",con);
            //com.ExecuteNonQuery();
            //com2.ExecuteNonQuery();
            // lblNumber.Text = com2.Parameters["@OutputVariableName"].Value.ToString();

            con.Close();
            LoadAllRecords();
        }
        // load the list
        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.PatientAdmissionInfo '" + int.Parse(txtId.Text) + "'", con);
            SqlDataAdapter da=new SqlDataAdapter(com);
            DataTable dt=new DataTable();
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;
        }
        // update the admission table
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.AddNoteToAdmission'" + int.Parse(txtAdmission.Text) + "','" + txtNote.Text + "'", con);
            com.ExecuteNonQuery();
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadAllRecords();
        }


    }
}
