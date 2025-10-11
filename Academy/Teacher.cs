using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{ 

	internal class Teacher : Human
	{
		public short ID { get; set; }
		public string WorkSince { get; set; }
		public decimal Rate { get; set; }

		public Teacher() { }
		public Teacher(short teach_id) 
		{
			Connector connector = new Connector();
			DataTable teacher = connector.Select("*", "Teachers", $"teacher_id={teach_id}");

			ID = teach_id;
			LastName = teacher.Rows[0][1].ToString();
			FirstName = teacher.Rows[0][2].ToString();
			MiddleName = teacher.Rows[0][3].ToString();

			BirthDate = teacher.Rows[0][4].ToString();
			Email = teacher.Rows[0][5].ToString();
			Phone = teacher.Rows[0][6].ToString();

			WorkSince = teacher.Rows[0][8].ToString();
			Rate = Convert.ToDecimal(teacher.Rows[0][9]);
			
			try
			{
				Photo = connector.DownloadPhoto(teach_id, "Teachers", "photo");
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		}
		public Teacher(string work_since,decimal rate):this()
		{
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
