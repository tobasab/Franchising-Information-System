using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franchising_Information_System
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnRegistration_Click(object sender, EventArgs e)
		{
			frmRegistration f = new frmRegistration();
			f.TopLevel = false;
			panel4.Controls.Add(f);
			f.BringToFront();
			f.LoadRecords();
			f.FLoadRecords();
			f.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void btnMaintenance_Click(object sender, EventArgs e)
		{
			frmMaintenance f = new frmMaintenance();
			f.TopLevel = false;
			panel4.Controls.Add(f);
			f.BringToFront();
		//	f.LoadRecords();
			f.Show();
		}

        private void btnOrdinance_Click(object sender, EventArgs e)
        {
            frmOrdinanceList f = new frmOrdinanceList();
            f.TopLevel = false;
            panel4.Controls.Add(f);
            f.BringToFront();
			f.LoadRecords();
            f.Show();
        }

        private void btnValidity_Click(object sender, EventArgs e)
        {
            frmValidityList f = new frmValidityList();
            f.TopLevel = false;
            panel4.Controls.Add(f);
            f.BringToFront();
           f.LoadRecords();
            f.Show();
        }
    }
}
