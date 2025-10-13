using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Human
	{
		public int ID { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string BirthDate { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public Image Photo { get; set; }

		public Human() { }
		public Human(string last_name, string first_name, string middle_name, string birth_date, string email, string phone, Image photo)
		{
			LastName = last_name;
			FirstName = first_name;
			MiddleName = middle_name;
			BirthDate = birth_date;
			Email = email;
			Phone = phone;
			Photo = photo;
		}
		protected void InitFromDataRow(DataRow row, int id, int lnIdx, int fnIdx, int mnIdx, int bdIdx, int emailIdx, int phoneIdx)
		{
			ID = id;
			LastName = row[lnIdx].ToString();
			FirstName = row[fnIdx].ToString();
			MiddleName = row[mnIdx].ToString();
			BirthDate = row[bdIdx].ToString();
			Email = row[emailIdx].ToString();
			Phone = row[phoneIdx].ToString();
		}
		public byte[] SerializePhoto()
		{
			MemoryStream ms = new MemoryStream();
			Photo.Save(ms, Photo.RawFormat);
			return ms.ToArray();
		}
		public override string ToString()
		{
			return $"N'{LastName}',N'{FirstName}',N'{MiddleName}','{BirthDate}',N'{Email}',N'{Phone}'";
		}
		public virtual string ToStringUpdate()
		{
			return $@"
			last_name=N'{LastName}',
			first_name=N'{FirstName}',
			middle_name=N'{MiddleName}',
			birth_date='{BirthDate}',
			email=N'{Email}',
			phone=N'{Phone}'
			";
		}
	}
}
