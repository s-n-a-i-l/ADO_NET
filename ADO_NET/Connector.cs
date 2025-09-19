using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET
{
	internal class Connector
	{
		
		static SqlConnection connection;
		private readonly string connectionString_;

		
		private SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString_);
		}
		public Connector(string connectionString)
		{
			connectionString_ = connectionString;
		}
		public void TestConnection()
		{
			connection = GetConnection();
			//connection.Open();
			Console.WriteLine("Подключение к БД успешно!");
			
		}
		public static void InsertMovie()
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
		public static int GetDirectorID(string full_name)
		{
			return Convert.ToInt32(
				Scalar
					(
						$"SELECT director_id FROM Directors WHERE first_name =N'{full_name.Split(' ').First()}' AND last_name=N'{full_name.Split(' ').Last()}'"
					)
				);
		}
		public static void InsertDiretor()
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
		public static void Insert(string table, string fields, string values)
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
			for (int i = 1; i < fields_for_check.Length; i++)
			{
				condition += $" {fields_for_check[i]} = {values_for_check[i]} AND";
			}
			int index_of_last_space = condition.LastIndexOf(' ');
			condition = condition.Remove(index_of_last_space, 4);
			string cmd = $"IF NOT EXISTS(SELECT {primary_key} FROM {table} WHERE {condition})BEGIN INSERT {table}({fields}) VALUES ({values}); END";

			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public static void Insert(string first_name, string last_name)
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
		public static object Scalar(string cmd)
		{
			connection.Open();

			SqlCommand command = new SqlCommand(cmd, connection);
			object obj = command.ExecuteScalar();

			connection.Close();
			return obj;
		}
		public static void Select(string fields, string tables, string condition = "")
		{
			//2)Открываем соединение. //после того как подключение создано, оно не явяется открытым, т.е поключение всегда открывается вручную при необходимости
			connection.Open();

			//________________________________________________________________________
			//3) Для  испольования подключения создаем "SqlDataReader"
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";
			SqlCommand command = new SqlCommand(cmd, connection); //что и по какому соединению

			//4) Создаем "Reader"
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
			}
			Console.WriteLine();

			while (reader.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");//cтолбики - поля
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.Write(reader[i] + "\t\t");
				}
				Console.WriteLine();
			}
			reader.Close();
			//------------------------------------------------------------------------
			//?) Подключение обязательно нужно закрывать
			connection.Close();
		}

		public static void SelectWithParemeters(string first_name, string last_name)
		{
			string cmd = "SELECT movie_name,release_date,last_name,first_name FROM Movies,Directors WHERE director=director_id AND last_name=@last_name AND first_name=@first_name;";
			//SqlParameter parameter = new SqlParameter();
			SqlCommand command = new SqlCommand(cmd, connection);
			command.Parameters.Add(new SqlParameter("@last_name", System.Data.SqlDbType.NVarChar)).Value = last_name;
			command.Parameters.Add(new SqlParameter("@first_name", System.Data.SqlDbType.NVarChar)).Value = first_name;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
				Console.WriteLine();
			}
			while (reader.Read())
			{
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Console.WriteLine(reader[i] + "\t");
					Console.WriteLine();
				}
			}
			connection.Close();
		}







	}
}
