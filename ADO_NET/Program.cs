using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//1) Создаем подключение к Базе данных на Сервере
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			Console.WriteLine(connectionString);
			SqlConnection connection = new SqlConnection();
			connection.ConnectionString = connectionString;
			//2)Открываем соединение. //после того как подключение создано, оно не явяется открытым, т.е поключение всегда открывается вручную при необходимости
			connection.Open();

			//________________________________________________________________________

			//3) Для  испольования подключения создаем "SqlDataReader"
			string cmd = "SELECT * FROM Directors;";
			SqlCommand command = new SqlCommand(cmd,connection); //что и по какому соединению

			//4) Создаем "Reader"
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++) 
			{
			Console.Write(reader.GetName(i)+"\t");
			}
			Console.WriteLine();

			while (reader.Read()) 
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");//cтолбики - поля
				for (int i = 0; i < reader.FieldCount; i++)   
				{
			     Console.Write(reader[i]+"\t\t");
				}
				 Console.WriteLine();
			}
			reader.Close();



			//------------------------------------------------------------------------
			//?) Подключение обязательно нужно закрывать
			connection.Close();


		}
	}
}
