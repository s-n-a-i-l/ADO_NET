﻿using System;
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
	internal class Student:Human
	{
		//public int ID {  get; set; }
		public int Group  { get; set; }
		public Student(int stud_id) 
		{
			Connector connector = new Connector();
			DataTable student = connector.Select("*", "Students", $"stud_id={stud_id}");

			InitFromDataRow(student.Rows[0], stud_id, 1, 2, 3, 4, 5, 6); 
			Group = Convert.ToInt32(student.Rows[0][8]);
			try
			{
				Photo = connector.DownloadPhoto(stud_id, "Students", "photo");
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		
		}
		public Student() { }
		public Student(string last_name,
			string first_name,string middle_name, 
			string birth_date,string email,
			string phone, int group,
			Image photo)
		{
			LastName = last_name;
			FirstName = first_name;
			MiddleName = middle_name;
			BirthDate = birth_date;
			Email = email;
			Phone = phone;
			Group = group;
			Photo = photo;
		}
		public byte[] SerializePhoto() 
		{
		  MemoryStream ms = new MemoryStream();
			Photo.Save(ms, Photo.RawFormat);
			return ms.ToArray();
		}
		public override string ToString()
		{
			return $"{base.ToString()},{Group}";
		}
		public override string ToStringUpdate()
		{
			return $@"
			{base.ToStringUpdate()},
			[group]={Group}
			";
		}
	}
}
