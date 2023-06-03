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

namespace Franchising_Information_System
{
	public partial class frmRegistration : Form
	{
		SqlConnection cn;
		SqlCommand cm;
		SqlDataReader dr;
		public frmRegistration()
		{
			InitializeComponent();
			cn = new SqlConnection(dbconstring._connection);
		}
		public void LoadRecords()
		{
			try
			{
				dataGridView1.Rows.Clear();
				cn.Open();

				cm = new SqlCommand("select * from tblPersonalDetails", cn);
				dr = cm.ExecuteReader();
				while (dr.Read())
				{
					dataGridView1.Rows.Add(dr["id"].ToString(), dr["name"].ToString(), dr["address"].ToString(), dr["contact"].ToString());
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

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnAddPerson_Click(object sender, EventArgs e)
		{
			frmAddPerson f = new frmAddPerson();
			f.ShowDialog();
		}
	}
}
