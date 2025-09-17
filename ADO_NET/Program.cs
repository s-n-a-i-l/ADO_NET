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

			//InsertDiretor();
			InsertMovie();

		}

		static void InsertMovie() 
		{
			Console.Write("Название фильма: ");
			string movie_name = Console.ReadLine();
			Console.Write("Дата выхода: ");
			string release_date = Console.ReadLine();
			Console.Write("Режиссер: ");
			string director = Console.ReadLine();

			string table = "Movies";
			string fields = "movies_id,movie_name,release_date,director";
			string values = $"{Convert.ToInt32(Scalar("SELECT MAX(movies_id) FROM Movies")) + 1},N'{movie_name}',N'{release_date}',{GetDirectorID(director)}";

			Insert(
				table,
				fields,
				values
				);

			Select(
				   "movie_name,release_date,first_name,last_name",
				   "Movies,Directors",
				   "director=director_id"
				   );
		}
		static int GetDirectorID(string full_name) 
		{
			return Convert.ToInt32(
				Scalar
					(
						$"SELECT director_id FROM Directors WHERE first_name =N'{full_name.Split(' ').First()}' AND last_name=N'{full_name.Split(' ').Last()}'"
					)
				);
		}
		static void InsertDiretor() 
		{
			Console.Write("Vvedite imya: ");
			string first_name = Console.ReadLine();

			Console.Write("Vvedite familiy: ");
			string last_name = Console.ReadLine();

			Insert(
				"Directors",
				"director_id,first_name,last_name",
				$"{Convert.ToInt32(Scalar("SELECT MAX(director_id) FROM Directors")) + 1},N'{first_name}',N'{last_name}'"
				 );

			Select("*", "Directors");
		}
		static void Insert(string table, string fields, string values)
		{
			string primary_key = Scalar($@"SELECT COLUMN_NAME
				FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
				WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+QUOTENAME(CONSTRAINT_NAME)),'IsPrimaryKey')=1
				AND TABLE_NAME='{table}'") as string;

			Console.WriteLine("\n==================================");
			Console.WriteLine(primary_key);
			Console.WriteLine("\n==================================");

			string[] fields_for_check = fields.Split(','); 
			string[] values_for_check = values.Split(',');
			string condition = "";
			for(int i = 1; i < fields_for_check.Length; i++) 
			{
			  condition+= $" {fields_for_check[i]} = { values_for_check[i]} AND";
			}
			int index_of_last_space = condition.LastIndexOf(' ');
			condition = condition.Remove(index_of_last_space, 4);
			string cmd = $"IF NOT EXISTS(SELECT {primary_key} FROM {table} WHERE {condition})BEGIN INSERT {table}({fields}) VALUES ({values}); END";

			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
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
