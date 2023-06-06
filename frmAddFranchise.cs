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
	public partial class frmAddFranchise : Form
	{
		SqlConnection cn;
		SqlCommand cm;
		SqlDataReader dr;
		public frmAddFranchise()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Do you want to save this record? ", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					cn.Open();
					cm = new SqlCommand("insert into tblFranchiseDetails (caseno, daterecieved, zone, plate, crno,engineno,chassisno,make,remarks) VALUES (@caseno, @daterecieved, @zone,@plate, @crno, @engineno,@chassisno,@make,@remarks)", cn);
					cm.Parameters.AddWithValue("@caseno", txtCaseNo.Text);
					cm.Parameters.AddWithValue("@daterecieved", dateTimePicker1.Text);
					cm.Parameters.AddWithValue("@zone", cbZone.Text);
					cm.Parameters.AddWithValue("@plate", txtPlate.Text);
					cm.Parameters.AddWithValue("@crno", txtCR.Text);
					cm.Parameters.AddWithValue("@engineno", txtEngine.Text);
					cm.Parameters.AddWithValue("@chassisno", txtChassis.Text);
					cm.Parameters.AddWithValue("@make", txtMake.Text);
					cm.Parameters.AddWithValue("@remarks", txtRemarks.Text);
					//	cm.Parameters.AddWithValue("@address", "BRGY. " + cbBrgy.Text + ", " + cbCity.Text);
					//	cm.Parameters.AddWithValue("@barangay", cbBrgy.Text);
					//	cm.Parameters.AddWithValue("@city", cbCity.Text);
					//	cm.Parameters.AddWithValue("@contact", contact.Text);
					cm.ExecuteNonQuery();
					cn.Close();
					MessageBox.Show("Record has been successfully saved!", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
					//btnClear_Click(sender, e);
					//f.LoadRecords();
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
