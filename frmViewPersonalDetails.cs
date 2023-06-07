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
using System.Xml.Linq;

namespace Franchising_Information_System
{
	public partial class frmViewPersonalDetails : Form
	{
		SqlConnection cn;
		SqlCommand cm;
		SqlDataReader dr;
		public frmViewPersonalDetails()
		{
			InitializeComponent();
			cn = new SqlConnection(dbconstring._connection);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
        public void LoadRecords()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from vwfranchisedetails where(owner) like '%" + name.Text + "%'", cn);
                //cm = new SqlCommand("select * from tblFranchiseDetails where(owner) like '%" + name.Text + "%'" ", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["caseno"], DateTime.Parse(dr["daterecieved"].ToString()).ToShortDateString(), dr["zone"], dr["plate"], dr["crno"], dr["engineno"], dr["chassisno"], dr["make"], dr["remarks"], dr["owner"]);
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
                //PDRowCount.Text = "Record Count ( " + dataGridView2.RowCount + ")";
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
