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
    public partial class frmValidity : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        frmValidityList f;
        public frmValidity(frmValidityList f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconstring._connection);
            this.f = f;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this record? ", dbconstring._title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblValidity (issuedate, validuntil ) VALUES (@issuedate, @validuntil)", cn);
                    cm.Parameters.AddWithValue("@issuedate", DateTime.Parse(dtIssueDate.Text).ToShortDateString());
                    cm.Parameters.AddWithValue("@validuntil", DateTime.Parse(dtValidUntil.Text).ToShortDateString());
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", dbconstring._title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecords();
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
