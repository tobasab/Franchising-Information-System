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
	public partial class frmAddPerson : Form
	{
		SqlConnection cn;
		SqlCommand cm;
		SqlDataReader dr;
		frmRegistration f;
		public frmAddPerson(frmRegistration f)
		{
			InitializeComponent();
			cn = new SqlConnection(dbconstring._connection);
			this.f = f;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
		public void Clear()
		{
			txtFirstName.Clear();
			txtMiddleName.Clear();
			txtLastName.Clear();
			txtExtName.Clear();
			txtAddress.Clear();
			txtContact.Clear();
			btnUpdate.Enabled = false;

		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Do you want to save this record? ", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					cn.Open();
					cm = new SqlCommand("insert into tblPersonalDetails (fname, mname, lname, ename, address,contact) VALUES (@fname, @mname, @lname, @ename, @address,@contact)", cn);
					cm.Parameters.AddWithValue("@fname", txtFirstName.Text);
					cm.Parameters.AddWithValue("@mname", txtMiddleName.Text);
					cm.Parameters.AddWithValue("@lname", txtLastName.Text);
					cm.Parameters.AddWithValue("@ename", txtExtName.Text);
					cm.Parameters.AddWithValue("@address", txtAddress.Text);
					cm.Parameters.AddWithValue("@contact", txtContact.Text);
					//	cm.Parameters.AddWithValue("@address", "BRGY. " + cbBrgy.Text + ", " + cbCity.Text);
				//	cm.Parameters.AddWithValue("@barangay", cbBrgy.Text);
				//	cm.Parameters.AddWithValue("@city", cbCity.Text);
				//	cm.Parameters.AddWithValue("@contact", contact.Text);
					cm.ExecuteNonQuery();
					cn.Close();
					MessageBox.Show("Record has been successfully saved!", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
					Clear();
					f.LoadRecords();
				//	ClearPersonalDetailsForm();
				//	f.registrationLoadRecord();


				}
			}
			catch (Exception ex)
			{
				cn.Close();
				MessageBox.Show(ex.Message, dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
