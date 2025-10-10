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
using System.Configuration;


namespace Academy
{
	public partial class MainForm : Form
	{
			SqlConnection connection;
			string connectionString = "Data Source=DESKTOP-NFMFIIS\\SQLEXPRESS;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			Dictionary<string, int> d_groupDirection;
			Dictionary<string, int> d_studentsGroup;
			Connector connector;

		Query[] queries = new Query[]
			{
				new Query
				(
"stud_id,FORMATMESSAGE(N'%s %s %s',last_name,first_name,middle_name) AS N'Студент',group_name AS N'Группа',direction_name AS N'Направление'",
"Students,Groups,Directions",
"[group]=group_id AND direction=direction_id"
				),
				new Query
				(
					"group_id,group_name,learning_days, start_time,direction_name",
					"Groups,Directions",
					"direction=direction_id"
				),
				new Query("*", "Directions"),
				new Query("*", "Disciplines"),
				new Query("*", "Teachers")
			};

		readonly string[] statusBarMessages = new string[]
			{
				"Количество студентов ",
				"Количество групп ",
				"Количество направлений ",
				"Количество дисциплин ",
				"Количество преподавателей "
			};
		public MainForm()
		{
			InitializeComponent();
			AllocConsole();
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			Console.WriteLine(connectionString);
			connection = new SqlConnection(connectionString);
			connector = new Connector();

			Console.WriteLine(this.Name);
			Console.WriteLine(tabControl.TabCount);

			//LoadDirections();
			//LoadDisciplines();
			//LoadStudents();
			//LoadGroups();
			//LoadTeachers();

			//dataGridViewDirections.DataSource = Select("*", "Directions");
			//dataGridViewGroups.DataSource = Select
			//	(
			//	"group_id,group_name,direction", "Groups,Directions", "direction=direction_id"
			//	);

			d_groupDirection = LoadDataToDictionary("*", "Directions");
			d_studentsGroup = LoadDataToDictionary("*", "Groups");
			comboBoxGroupsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxStudentsDirection.Items.AddRange(d_groupDirection.Keys.ToArray());
			comboBoxStudentsGroup.Items.AddRange(d_studentsGroup.Keys.ToArray());
			comboBoxStudentsDirection.SelectedIndex = comboBoxGroupsDirection.SelectedIndex = 0;
			comboBoxStudentsGroup.SelectedIndex = 0;

			tabControl.SelectedIndex = 0;

			for (int i = 0; i < tabControl.TabCount; i++)
			{
				(this.Controls.Find($"dataGridView{tabControl.TabPages[i].Name.Remove(0, "tabPage".Length)}", true)[0] as DataGridView)
					.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGridViewChanged);
			}
		}
		void LoadTab(int i)
		{
			string tableName = tabControl.TabPages[i].Name.Remove(0, "tabPage".Length);
			DataGridView dataGridView = this.Controls.Find($"dataGridView{tableName}", true)[0] as DataGridView;
			dataGridView.DataSource = connector.Select(queries[i].Fields, queries[i].Tables, queries[i].Condition);
			//toolStripStatusLabel.Text = $"{statusBarMessages[i]}: {dataGridView.RowCount - 1}";
			if (i == 1) ConvertLearningDays();
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.ReadOnly = true;
		}
		void FillStatusBar(int i)
		{

		}
		//DataTable Select(string fields, string tables, string condition = "")
		//{
		//	DataTable table = new DataTable();
		//	string cmd = $"SELECT {fields} FROM	{tables}";
		//	if (!string.IsNullOrWhiteSpace(condition))
		//		cmd += $" WHERE {condition}";
		//	cmd += ";";

		//	SqlCommand command = new SqlCommand(cmd, connection);
		//	connection.Open();
		//	SqlDataReader reader = command.ExecuteReader();
		//	for (int i = 0; i < reader.FieldCount; i++)
		//		table.Columns.Add(reader.GetName(i));
		//	while (reader.Read())
		//	{
		//		DataRow row = table.NewRow();
		//		for (int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];
		//		table.Rows.Add(row);
		//	}
		//	reader.Close();
		//	connection.Close();

		//	return table;
		//}

		//void Insert(string table,string fields, string values) 
		//{
		//	string cmd = $"INSERT {table}({fields}) VALUES ({values})";
		//	SqlCommand command = new SqlCommand(cmd, connection);
		//	connection.Open();
		//	command.ExecuteNonQuery();
		//	connection.Close();
		//}
		Dictionary<string, int> LoadDataToDictionary(string fields, string tables, string condition = "")
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			dictionary.Add("Все", 0);
			string cmd = $"SELECT {fields} FROM {tables}";
			if (!string.IsNullOrWhiteSpace(condition))
				cmd += $" WHERE {condition}";

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
		private void tabControl_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			LoadTab((sender as TabControl).SelectedIndex);
			//UpdateStatusBar();
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
			dataGridViewGroups.DataSource = connector.Select
			(
				"group_id,group_name,direction",
				"Groups,Directions",
				condition
			);
		}
		[DllImport("kernel32.dll")]
		static extern void AllocConsole();
		
		private void dataGridViewChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel.Text = $"{statusBarMessages[tabControl.SelectedIndex]}: {(sender as DataGridView).RowCount - 1}";
		}
		void ConvertLearningDays()
		{
			for (int i = 0; i < dataGridViewGroups.RowCount; i++)
			{

				dataGridViewGroups.Rows[i].Cells["learning_days"].Value =
					new Week(Convert.ToByte(dataGridViewGroups.Rows[i].Cells["learning_days"].Value));
			}
		}

		private void comboBoxStudentsGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition_group =
				comboBoxStudentsGroup.SelectedItem.ToString() == "Все" ? "" :
				$"[group]={d_studentsGroup[comboBoxStudentsGroup.SelectedItem.ToString()]}";
			string condition_direction = comboBoxStudentsDirection.SelectedItem.ToString() == "Все" ? "" :
				$" direction={d_groupDirection[comboBoxStudentsDirection.SelectedItem.ToString()]}";
			dataGridViewStudents.DataSource = connector.Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition
					+ (string.IsNullOrWhiteSpace(condition_group) ? "" : $" AND {condition_group}")
					+ (string.IsNullOrWhiteSpace(condition_direction) ? "" : $" AND {condition_direction}")
				);
		}

		private void comboBoxStudentsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			string condition = comboBoxStudentsDirection.SelectedItem.ToString() == "Все" ? "" :
				$" direction={d_groupDirection[(sender as ComboBox).SelectedItem.ToString()]}";
			comboBoxStudentsGroup.Items.Clear();
			comboBoxStudentsGroup.Items.AddRange(LoadDataToDictionary("*", "Groups", condition).Keys.ToArray());
			dataGridViewStudents.DataSource = connector.Select
				(
					queries[0].Fields,
					queries[0].Tables,
					queries[0].Condition + (string.IsNullOrEmpty(condition) ? "" : $" AND {condition}")
				);
		}

		private void checkBoxEmptyDirection_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void buttonAddEditStudent_Click(object sender, EventArgs e)
		{
			StudentForm student = new StudentForm();
			DialogResult result = student.ShowDialog();

			if (result == DialogResult.OK) 
			{

				connector.Insert(
					"Students",
					"last_name, first_name,middle_name,birth_date,email,phone,[group]",
					student.Student.ToString()
					);
			int id = Convert.ToInt32(connector.Scalar("SELECT MAX(stud_id) FROM Students"));
			connector.UploadImage(student.Student.SerializePhoto(), id, "photo", "Students");
			}
		}

		private void dataGridViewStudents_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int i = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells[0].Value);
			StudentForm student = new StudentForm(i);
			DialogResult result = student.ShowDialog();
			if (result == DialogResult.OK)
			{
				connector.Update
				(
					"Students",
					student.Student.ToStringUpdate(),
					$"stud_id={i}"
				);
				connector.UploadImage(student.Student.SerializePhoto(), i, "photo", "students");
				comboBoxStudentsGroup_SelectedIndexChanged(null, null);
			}
		}
	}
}
//		void LoadDirections() 
//		{
//			string cmd = @"SELECT direction_id AS N'ID',direction_name AS N'Направление', COUNT(group_id) AS N'Количество групп' 
//FROM Groups
//RIGHT JOIN Directions	ON (direction=direction_id)
//GROUP BY direction_id,direction_name
//;";
//			SqlCommand command = new SqlCommand(cmd, connection);

//			connection.Open();
//			SqlDataReader reader = command.ExecuteReader();
//			DataTable table = new DataTable();

//			for (int i = 0; i < reader.FieldCount; i++) 
//			  table.Columns.Add(reader.GetName(i));

//			while (reader.Read()) 
//			{
//			  DataRow row = table.NewRow();
//				for (int i= 0; i < reader.FieldCount; i++) 
//				   row[i] = reader[i];

//				table.Rows.Add(row);
//			}
//			reader.Close();
//			connection.Close();
//			dataGridViewDirections.DataSource = table;
//			//UpdateStatusBar();
//		}

//		void LoadDisciplines() 
//		{
//			string cmd = " SELECT * FROM Disciplines";
//			SqlCommand command = new SqlCommand(cmd, connection);

//			connection.Open();
//			SqlDataReader reader = command.ExecuteReader();
//			DataTable table = new DataTable();

//			for (int i = 0; i < reader.FieldCount; i++)
//				table.Columns.Add(reader.GetName(i));

//			while (reader.Read())
//			{
//				DataRow row = table.NewRow();
//				for (int i = 0; i < reader.FieldCount; i++)
//					row[i] = reader[i];

//				table.Rows.Add(row);
//			}
//			reader.Close();
//			connection.Close();
//			dataGridViewDisciplines.DataSource = table;
//			//toolStripStatusLabel.Text = $"Количество строк: {table.Rows.Count}";
//			//UpdateStatusBar();
//		}

//		void LoadStudents()
//		{
//			string cmd = " SELECT * FROM Students";
//			SqlCommand command = new SqlCommand(cmd, connection);

//			connection.Open();
//			SqlDataReader reader = command.ExecuteReader();
//			DataTable table = new DataTable();

//			for (int i = 0; i < reader.FieldCount; i++)
//				table.Columns.Add(reader.GetName(i));

//			while (reader.Read())
//			{
//				DataRow row = table.NewRow();
//				for (int i = 0; i < reader.FieldCount; i++)
//					row[i] = reader[i];

//				table.Rows.Add(row);
//			}
//			reader.Close();
//			connection.Close();
//			dataGridViewStudents.DataSource = table;
//			//toolStripStatusLabel.Text = $"Количество строк: {table.Rows.Count}";
//			//UpdateStatusBar();
//		}

//		void LoadGroups()
//		{
//			string cmd =
//				@"SELECT 
//group_id AS N'ID',group_name AS N'Группа',COUNT(stud_id) AS N'Количество студентов',direction_name AS N'Направление обучения'
//FROM Students
//RIGHT	JOIN	Groups		ON ([group]=group_id)
//		JOIN	Directions	ON (direction=direction_id)
//GROUP BY group_id, group_name, direction, direction_name;";
//			SqlCommand command = new SqlCommand(cmd, connection);
//			connection.Open();
//			SqlDataReader reader = command.ExecuteReader();
//			DataTable table = new DataTable();
//			for (int i = 0; i < reader.FieldCount; i++)
//				table.Columns.Add(reader.GetName(i));
//			while (reader.Read())
//			{
//				DataRow row = table.NewRow();
//				for (int i = 0; i < reader.FieldCount; i++)
//					row[i] = reader[i];
//				table.Rows.Add(row);
//			}
//			reader.Close();
//			connection.Close();
//			dataGridViewGroups.DataSource = table;
//		}

//		void LoadTeachers()
//		{
//			string cmd = " SELECT * FROM Teachers";
//			SqlCommand command = new SqlCommand(cmd, connection);

//			connection.Open();
//			SqlDataReader reader = command.ExecuteReader();
//			DataTable table = new DataTable();

//			for (int i = 0; i < reader.FieldCount; i++)
//				table.Columns.Add(reader.GetName(i));

//			while (reader.Read())
//			{
//				DataRow row = table.NewRow();
//				for (int i = 0; i < reader.FieldCount; i++)
//					row[i] = reader[i];

//				table.Rows.Add(row);
//			}
//			reader.Close();
//			connection.Close();
//			dataGridViewTeachers.DataSource = table;
//			//toolStripStatusLabel.Text = $"Количество строк: {table.Rows.Count}";
//			//UpdateStatusBar();
//		}

//void UpdateStatusBar()
//{
//	if (tabControl.SelectedTab == tabPageDirections)
//	{
//		toolStripStatusLabel.Text = $"Количество строк: {dataGridViewDirections.Rows.Count - 1}";
//	}
//	else if (tabControl.SelectedTab == tabPageStudents)
//	{
//		toolStripStatusLabel.Text = $"Количество строк: {dataGridViewStudents.Rows.Count - 1}";
//	}
//	else if (tabControl.SelectedTab == tabPageTeachers)
//	{
//		toolStripStatusLabel.Text = $"Количество строк: {dataGridViewTeachers.Rows.Count - 1}";
//	}
//	else if (tabControl.SelectedTab == tabPageGroups)
//	{
//		toolStripStatusLabel.Text = $"Количество строк: {dataGridViewGroups.Rows.Count - 1}";
//	}
//	else if (tabControl.SelectedTab == tabPageDisciplines)
//	{
//		toolStripStatusLabel.Text = $"Количество строк: {dataGridViewDisciplines.Rows.Count}";
//	}
//}