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
			f.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
