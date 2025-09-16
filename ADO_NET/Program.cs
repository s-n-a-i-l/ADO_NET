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
		static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		static SqlConnection connection;
		static void Main(string[] args)
		{
			//1) Создаем подключение к Базе данных на Сервере
			Console.WriteLine(connectionString);
			connection = new SqlConnection();
			connection.ConnectionString = connectionString;

			//Select("SELECT * FROM Directors");
			//Console.WriteLine();
			//Select("SELECT * FROM Movies");

			//Select("*", "Directors");
			//Select("*", "*");
			Console.WriteLine();
			//Select("movie_name,release_date,first_name+last_name AS Режисер", "Movies,Directors","director = director_id");

#if SCALAR_CHEC
			connection.Open();

			string cmd = "SELECT COUNT(*) FROM Directors";
			SqlCommand command = new SqlCommand(cmd, connection);
			Console.WriteLine($"Количество режиссеров:\t{command.ExecuteScalar()}");

			command.CommandText = "SELECT COUNT(*) FROM Movies";
			Console.WriteLine($"Количество кино:\t{command.ExecuteScalar()}");

			command.CommandText = "SELECT last_name FROM Directors WHERE first_name = N'James'";
			Console.WriteLine(command.ExecuteScalar());

			connection.Close();

			Console.WriteLine(Scalar("SELECT COUNT(*) FROM Movies")); 
#endif
			//Console.Write("Vvedite imya: ");
			//string first_name = Console.ReadLine();

			//Console.Write("Vvedite familiy: ");
			//string last_name = Console.ReadLine();

			Insert("prov", "erka");

			Select("*", "Directors");
		}
		static void Insert(string first_name, string last_name) 
		{
			int newId = Convert.ToInt32(Scalar("SELECT MAX(director_id) FROM Directors")) + 1;
			string cmd =
			"INSERT INTO Directors (director_id, first_name, last_name) VALUES (@id, @first_name, @last_name)";
			SqlCommand command = new SqlCommand(cmd, connection);
			//параметр(@id, @first_name, @last_name), он безопасней чем конкатенация строк 
			command.Parameters.AddWithValue("@id", newId);
			command.Parameters.AddWithValue("@first_name", first_name);
			command.Parameters.AddWithValue("@last_name", last_name);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		static object Scalar(string cmd) 
		{
			connection.Open();

			SqlCommand command = new SqlCommand(cmd,connection);
			object obj = command.ExecuteScalar();

			connection.Close();
			return obj;
		}
		static void Select(string fields, string tables, string condition = "") 
		{
			//2)Открываем соединение. //после того как подключение создано, оно не явяется открытым, т.е поключение всегда открывается вручную при необходимости
		  connection.Open();

			//________________________________________________________________________
			//3) Для  испольования подключения создаем "SqlDataReader"
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";
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
