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
		frmRegistration f;
		public string _personid = "";
		public string _caseno = "";
		public frmAddFranchise(frmRegistration f)
		{
			InitializeComponent();
			cn = new SqlConnection(dbconstring._connection);
			this.f = f;
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void txtOwner_DoubleClick_1(object sender, EventArgs e)
		{
			frmSearchPerson f = new frmSearchPerson(this);
			f.LoadRecords();
			f.ShowDialog();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Do you want to save this record? ", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					
					cm = new SqlCommand("insert into tblFranchiseDetails (caseno, daterecieved, zone, plate, crno,engineno,chassisno,make,remarks,personid) VALUES (@caseno, @daterecieved, @zone,@plate, @crno, @engineno,@chassisno,@make,@remarks,@personid)", cn);
					cn.Open();
					cm.Parameters.AddWithValue("@caseno", txtCaseNo.Text);
					cm.Parameters.AddWithValue("@daterecieved", DateTime.Parse(dateTimePicker1.Text));
					cm.Parameters.AddWithValue("@zone", cbZone.Text);
					cm.Parameters.AddWithValue("@plate", txtPlate.Text);
					cm.Parameters.AddWithValue("@crno", txtCR.Text);
					cm.Parameters.AddWithValue("@engineno", txtEngine.Text);
					cm.Parameters.AddWithValue("@chassisno", txtChassis.Text);
					cm.Parameters.AddWithValue("@make", txtMake.Text);
					cm.Parameters.AddWithValue("@remarks", txtRemarks.Text);
					cm.Parameters.AddWithValue("@personid", _personid);
					cm.ExecuteNonQuery();
					cn.Close();
					MessageBox.Show("Record has been successfully saved!", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
					f.FLoadRecords();
			
				}
			}
			catch (Exception ex)
			{
				cn.Close();
				MessageBox.Show(ex.Message, dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cboOwners_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this record? ", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("update tblFranchiseDetails set daterecieved=@daterecieved,zone=@zone,plate=@plate,crno=@crno,engineno=@engineno,chassisno=@chassisno,make=@make,remarks=@remarks,personid=@personid where caseno = @caseno", cn);
                    cn.Open();
                    
                    cm.Parameters.AddWithValue("@daterecieved", DateTime.Parse(dateTimePicker1.Text));
                    cm.Parameters.AddWithValue("@zone", cbZone.Text);
                    cm.Parameters.AddWithValue("@plate", txtPlate.Text);
                    cm.Parameters.AddWithValue("@crno", txtCR.Text);
                    cm.Parameters.AddWithValue("@engineno", txtEngine.Text);
                    cm.Parameters.AddWithValue("@chassisno", txtChassis.Text);
                    cm.Parameters.AddWithValue("@make", txtMake.Text);
                    cm.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                    cm.Parameters.AddWithValue("@personid", _personid);
                    cm.Parameters.AddWithValue("@caseno", txtCaseNo.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.FLoadRecords();
					this.Dispose();

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
