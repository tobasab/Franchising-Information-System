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
					dataGridView1.Rows.Add(dr["id"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["lname"].ToString(), dr["ename"].ToString(), dr["address"].ToString(), dr["contact"].ToString());
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
		public void FLoadRecords()
		{
			try
			{
				dataGridView2.Rows.Clear();
				cn.Open();

				cm = new SqlCommand("select * from vwfranchisedetails", cn);
				dr = cm.ExecuteReader();
				while (dr.Read())
				{
					dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8],dr[9]);
				}
				dr.Close();
				cn.Close();
				dataGridView2.ClearSelection();
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
			string _column = dataGridView1.Columns[e.ColumnIndex].Name;
			if (_column == "colEdit")
			{
				frmAddPerson f = new frmAddPerson(this);
				f._personid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				f.txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
				f.txtMiddleName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
				f.txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
				f.txtExtName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
				f.txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
				f.txtContact.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
				f.btnSave.Enabled = false;
				f.btnUpdate.Enabled = true;
				f.ShowDialog();

			}
			else if (_column == "colDelete")
			{
				if (MessageBox.Show("Do you want to delete this record", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					cn.Open();
					cm = new SqlCommand("delete from tblPersonalDetails where id = @id", cn);
					cm.Parameters.AddWithValue("@id", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
					cm.ExecuteNonQuery();
					cn.Close();
					MessageBox.Show("Record has been deleted successfully", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadRecords();
				}
			}
			else if (_column == "colView")
			{
				frmViewPersonalDetails f = new frmViewPersonalDetails();
				f.ShowDialog();
			}

		}

		private void btnAddPerson_Click(object sender, EventArgs e)
		{
			frmAddPerson f = new frmAddPerson(this);
			f.btnUpdate.Enabled = false;
			f.ShowDialog();
		}

		private void btnAddFranchise_Click(object sender, EventArgs e)
		{
			frmAddFranchise f = new frmAddFranchise(this);
			f.btnUpdate.Enabled = false;
			f.ShowDialog();
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
