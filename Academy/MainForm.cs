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

namespace Academy
{
	public partial class MainForm : Form
	{
			SqlConnection connection;
			string connectionString = "Data Source=DESKTOP-NFMFIIS\\SQLEXPRESS;Initial Catalog=PD_321;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public MainForm()
		{
			
			InitializeComponent();
			connection = new SqlConnection(connectionString);

			LoadDirections();
			LoadDisciplines();
			LoadStudents();
			LoadGroups();
			LoadTeachers();

		}

		void LoadDirections() 
		{
			string cmd = " SELECT * FROM Directions";
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
			string cmd = " SELECT * FROM Groups";
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
			UpdateStatusBar();
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
	}
}
