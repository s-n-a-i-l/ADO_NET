using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Academy
{ 

	internal class Teacher : Human
	{
		//public short ID { get; set; }
		public string WorkSince { get; set; }
		public SqlMoney Rate { get; set; }

		public Teacher() { }

		public Teacher(short teach_id) 
		{
			Connector connector = new Connector();
			DataTable teacher = connector.Select("*", "Teachers", $"teach_id={teach_id}");

			InitFromDataRow(teacher.Rows[0], teach_id, 0, 1, 2, 3, 4, 5); 
			WorkSince = teacher.Rows[0][7].ToString();
			Rate = Convert.ToDecimal(teacher.Rows[0][8]);
			try
			{
				Photo = connector.DownloadPhoto(teach_id, "Teachers", "photo");
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		}
		public Teacher(string last_name,
			string first_name, string middle_name,
			string birth_date, string email,
			string phone,
			Image photo,string work_since, SqlMoney rate)
		{
			LastName = last_name;
			FirstName = first_name;
			MiddleName = middle_name;
			BirthDate = birth_date;
			Email = email;
			Phone = phone;
			Photo = photo;
			WorkSince = work_since;
			Rate = rate;
		}
		public byte[] SerializePhoto()
		{
			MemoryStream ms = new MemoryStream();
			Photo.Save(ms, Photo.RawFormat);
			return ms.ToArray();
		}
		public override string ToString() 
		{
			return $"{base.ToString()},N'{WorkSince}',N'{Rate}'";
		}

		public override string ToStringUpdate()
		{
			return $@"
			{base.ToStringUpdate()},
			work_since=N'{WorkSince}',
			rate=N'{Rate}'
			";
		}
	}
}
