using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franchising_Information_System
{
	internal class dbconstring
	{
		public static string _connection = System.IO.File.ReadAllText(System.Environment.CurrentDirectory + @"\config.txt");
		public static string _title = "Franchise Information System";
	}
}
