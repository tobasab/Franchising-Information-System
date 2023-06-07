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

namespace Franchising_Information_System
{
	public partial class frmSearchPerson : Form
	{
		SqlConnection cn;
		SqlCommand cm;
		SqlDataReader dr;
		frmAddFranchise f;

		public frmSearchPerson(frmAddFranchise f)
		{
			InitializeComponent();
			cn = new SqlConnection(dbconstring._connection);
			this.f = f;
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
				//cm = new SqlCommand("select * from tblPersonalDetails ", cn);
				cm = new SqlCommand("select * from tblPersonalDetails where lname like '" + txtSearch.Text + "%' order by lname", cn);
				dr = cm.ExecuteReader();
				while (dr.Read())
				{
					dataGridView1.Rows.Add(dr["id"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["lname"].ToString(), dr["ename"].ToString());
				}
				dr.Close();
				cn.Close();
				dataGridView1.ClearSelection();
				//lblRowCount.Text = "Record Count ( " + dataGridView1.RowCount + ")";
			}
			catch (Exception ex)
			{
				cn.Close();
				MessageBox.Show(ex.Message, dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			LoadRecords();	
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			string _column = dataGridView1.Columns[e.ColumnIndex].Name;
			if (_column == "colSelect")
			{
				string fname = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
				string mname = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string lname = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string ename = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
				string wholename = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f._personid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				f.txtOwner.Text = wholename;
				this.Dispose();
			}
		}
	}
}
