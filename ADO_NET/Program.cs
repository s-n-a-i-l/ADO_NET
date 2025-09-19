using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADO_NET
{
	internal class Program
	{
		static string connectionString = "";
		static void Main(string[] args)
		{
			//0)Достаем строку подключения из App.config
			connectionString = ConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
			//1) Создаем подключение к Базе данных на Сервере
			Console.WriteLine(connectionString);
			//connection = new SqlConnection();
			//connection.ConnectionString = connectionString
			Connector db = new Connector(connectionString);

			db.TestConnection();

			//Select("SELECT * FROM Directors");
			//Console.WriteLine();
			//Select("SELECT * FROM Movies");

			Connector.Select("*", "Directors");
			//Select("*", "*");

			//Connector.Select("movie_name,release_date,first_name+last_name AS Режисер", "Movies,Directors","director = director_id");

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
			Connector.InsertMovie();

		}
	}
}
