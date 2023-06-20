using Franchising_Information_System.Properties;
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
	public partial class fmServerConfig : Form
	{
		private SqlConnection connection;
		private TextBox textBoxConnectionString;
		private Button buttonSave;
		public fmServerConfig()
		{
			InitializeComponent();

			// Create a text box for the connection string.
			textBoxConnectionString = new TextBox();
			textBoxConnectionString.Location = new Point(12, 96);
			textBoxConnectionString.Size = new Size(376, 20);
			textBoxConnectionString.ReadOnly = false;
			Controls.Add(textBoxConnectionString);

			// Add a button to save the connection string.
			buttonSave = new Button();
			buttonSave.Location = new Point(12, 128);
			buttonSave.Size = new Size(376, 23);
			buttonSave.Text = "Save Connection String";
			buttonSave.Click += (object sender, EventArgs e) =>
			{
				// Get the connection string from the text box.
				string connectionString = textBoxConnectionString.Text;

				// Save the connection string in the application settings.
				//dbconstring db = new dbconstring();
				dbconstring._connection = connectionString;

				// Display a message box to notify the user.
				MessageBox.Show("Connection string saved successfully.");
			};
			Controls.Add(buttonSave);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// Get the connection string from the text box.
			string connectionString = textBoxConnectionString.Text;

			// Create a connection object.
			connection = new SqlConnection(connectionString);

			// Try to connect to the database server.
			try
			{
				connection.Open();
				MessageBox.Show("Successfully connected to the database server.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error connecting to the database server: " + ex.Message);
			}
		}
	}
}
