using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;


namespace Academy
{
	public partial class MainForm : Form
	{
			SqlConnection connection;
			string connectionString = "Data Source=DESKTOP-NFMFIIS\\SQLEXPRESS;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			Dictionary<string, int> d_groupDirection;
		public MainForm()
		{
			
			InitializeComponent();
			connection = new SqlConnection(connectionString);

			//LoadDirections();
			//LoadDisciplines();
			//LoadStudents();
			//LoadGroups();
			//LoadTeachers();

			dataGridViewDirections.DataSource = Select("*", "Directions");
			dataGridViewGroups.DataSource = Select
				(
				"group_id,group_name,direction", "Groups,Directions", "direction=direction_id"
				);
			d_groupDirection = LoadDataToComboBox("*", "Directions");
			comboBoxGroupsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxGroupsDirection.SelectedIndex = 0;

		}
		DataTable Select(string fields, string tables, string condition = "")
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


		void LoadDirections() 
		{
			string cmd = @"SELECT direction_id AS N'ID',direction_name AS N'Направление', COUNT(group_id) AS N'Количество групп' 
FROM Groups
RIGHT JOIN Directions	ON (direction=direction_id)
GROUP BY direction_id,direction_name
;";
			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();

			for (int i = 0; i < reader.FieldCount; i++) 
			  table.Columns.Add(reader.GetName(i));

			while (reader.Read()) 
			{
			  DataRow row = table.NewRow();
				for (int i= 0; i < reader.FieldCount; i++) 
				   row[i] = reader[i];
				
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridViewDirections.DataSource = table;
			UpdateStatusBar();
		}

		void LoadDisciplines() 
		{
			string cmd = " SELECT * FROM Disciplines";
			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();

			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));

			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
					row[i] = reader[i];

				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridViewDisciplines.DataSource = table;
			//toolStripStatusLabel.Text = $"Количество строк: {table.Rows.Count}";
			UpdateStatusBar();
		}

		void LoadStudents()
		{
			string cmd = " SELECT * FROM Students";
			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();

			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));

			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
					row[i] = reader[i];

				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridViewStudents.DataSource = table;
			//toolStripStatusLabel.Text = $"Количество строк: {table.Rows.Count}";
			UpdateStatusBar();
		}

		void LoadGroups()
		{
			string cmd =
				@"SELECT 
group_id AS N'ID',group_name AS N'Группа',COUNT(stud_id) AS N'Количество студентов',direction_name AS N'Направление обучения'
FROM Students
RIGHT	JOIN	Groups		ON ([group]=group_id)
		JOIN	Directions	ON (direction=direction_id)
GROUP BY group_id, group_name, direction, direction_name;";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();
			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
					row[i] = reader[i];
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridViewGroups.DataSource = table;
		}

		void LoadTeachers()
		{
			string cmd = " SELECT * FROM Teachers";
			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			DataTable table = new DataTable();

			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));

			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
					row[i] = reader[i];

				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridViewTeachers.DataSource = table;
			//toolStripStatusLabel.Text = $"Количество строк: {table.Rows.Count}";
			UpdateStatusBar();
		}

		void UpdateStatusBar()
		{
			if (tabControl.SelectedTab == tabPageDirections)
			{
				toolStripStatusLabel.Text = $"Количество строк: {dataGridViewDirections.Rows.Count - 1}";
			}
			else if (tabControl.SelectedTab == tabPageStudents)
			{
				toolStripStatusLabel.Text = $"Количество строк: {dataGridViewStudents.Rows.Count - 1}";
			}
			else if (tabControl.SelectedTab == tabPageTeachers)
			{
				toolStripStatusLabel.Text = $"Количество строк: {dataGridViewTeachers.Rows.Count - 1}";
			}
			else if (tabControl.SelectedTab == tabPageGroups)
			{
				toolStripStatusLabel.Text = $"Количество строк: {dataGridViewGroups.Rows.Count - 1}";
			}
			else if (tabControl.SelectedTab == tabPageDisciplines)
			{
				toolStripStatusLabel.Text = $"Количество строк: {dataGridViewDisciplines.Rows.Count}";
			}
		}
		
		private void tabControl_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			UpdateStatusBar();
		}

		Dictionary<string, int> LoadDataToComboBox(string fields, string tables)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add("Все", 0);
			string cmd = $"SELECT {fields} FROM {tables}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				//comboBoxGroupsDirection.Items.Add(reader[1]);
				dictionary.Add(reader[1].ToString(), Convert.ToInt32(reader[0]));
			}
			reader.Close();
			connection.Close();
			return dictionary;
		}

		private void comboBoxGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = "direction=direction_id";
			if (comboBoxGroupsDirection.SelectedItem.ToString() != "Все")
				condition += $" AND direction={d_groupDirection[comboBoxGroupsDirection.SelectedItem.ToString()]}";
			dataGridViewGroups.DataSource = Select
			(
				"group_id,group_name,direction",
				"Groups,Directions",
				condition
			);
		}
	}
}
