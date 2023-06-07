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
    public partial class frmOrdinanceList : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public frmOrdinanceList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring._connection);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmOrdinance f = new frmOrdinance(this);
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }
        public void LoadRecords()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();

                cm = new SqlCommand("select * from tblOrdinance", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1],dr[2]);
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

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				string _column = dataGridView1.Columns[e.ColumnIndex].Name;
				if (_column == "colActive")
				{
					if (MessageBox.Show("Do you want to Activate this ordinance " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " ? ", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						cn.Open();
						cm = new SqlCommand("UPDATE tblOrdinance set status = 'Inactive'", cn);
						cm.ExecuteNonQuery();
						cn.Close();

						cn.Open();
						cm = new SqlCommand("update tblOrdinance set status = 'Active' where id = @id", cn);
						cm.Parameters.AddWithValue("@id", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
						cm.ExecuteNonQuery();
						cn.Close();

						MessageBox.Show(" Ordinance " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " has been successfuly Activated!", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadRecords();
					}
				}
				else if (_column == "colInactive")
				{
					if (MessageBox.Show("Do you want to deactivate this ordinance " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " ? ", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						cn.Open();
						cm = new SqlCommand("UPDATE tblOrdinance set status = 'Inactive'", cn);
						cm.ExecuteNonQuery();
						cn.Close();

						MessageBox.Show(" ordinance " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " has been successfuly deactivated!", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadRecords();
					}
				}
			}
			catch (Exception ex)
			{
				cn.Close();
				MessageBox.Show(ex.Message, dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadRecords();
			}
		}
	}
}
