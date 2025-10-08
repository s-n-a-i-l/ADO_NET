﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Academy
{
	 class Connector{
		string connectionString = "";
		SqlConnection connection = null;

		public Connector() 
		{
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			connection = new SqlConnection(connectionString);
		}
		public DataTable Select(string fields, string tables, string condition = "")
		{
			DataTable table = new DataTable();
			string cmd = $"SELECT {fields} FROM	{tables}";
			if (!string.IsNullOrWhiteSpace(condition))
				cmd += $" WHERE {condition}";
			cmd += ";";

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();

			return table;
		}
		public void Insert(string table, string fields, string values)
		{
			string cmd = $"INSERT {table}({fields}) VALUES ({values})";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public void UploadImage(byte[] image,int id, string field, string table) 
		{
			string cmd = $"UPDATE {table} SET {field}=@image WHERE {GetPrimaryKey(table)}={id}";
			SqlCommand command = new SqlCommand(cmd, connection);
			command.Parameters.Add(@"image", SqlDbType.VarBinary).Value = image;
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public void Update(string table, string field, string condition)
		{
			string cmd = $"UPDATE {table} SET {field} WHERE {condition}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		public string GetPrimaryKey(string table) 
		{
		 return Scalar($@"SELECT COLUMN_NAME
				FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
				WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+QUOTENAME(CONSTRAINT_NAME)),'IsPrimaryKey')=1
				AND TABLE_NAME='{table}'") as string;
		}
		public object Scalar(string cmd)
		{
			connection.Open();

			SqlCommand command = new SqlCommand(cmd, connection);
			object obj = command.ExecuteScalar();

			connection.Close();
			return obj;
		}
		public Image DownloadPhoto(int id, string table, string field)
		{
			Image photo = null;
			string cmd = $"SELECT {field} FROM {table} WHERE {GetPrimaryKey(table)}={id}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			if (reader.Read()) 
			{
			    MemoryStream ms = new MemoryStream(reader[0] as byte[]);
				photo = Image.FromStream(ms);
			}
			connection.Close();
			return photo;
		}
	}
}
