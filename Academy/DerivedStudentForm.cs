﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class DerivedStudentForm : BaseHumanForm
	{
		public DerivedStudentForm()
		{
			InitializeComponent();
			connector = new Connector();
			DataTable groups = connector.Select("*", "Groups");
			comboBoxGroup.DataSource = groups;
			comboBoxGroup.DisplayMember = groups.Columns[1].ToString();
			comboBoxGroup.ValueMember = groups.Columns[0].ToString();
		}
		public DerivedStudentForm (int id) :this()
		{
		    Human = new Student(id);
			Extract();
		}
		protected override void buttonOK_Click(object sender, EventArgs e)
		{
			Human = new Student
				(
					textBoxLastName.Text,
					textBoxFirstName.Text,
					textBoxMiddleName.Text,
					dateTimePickerBirthDate.Text,
					textBoxEmail.Text,
					textBoxPhone.Text,
					Convert.ToInt32(comboBoxGroup.SelectedValue),
					pictureBoxPhoto.Image
				);
		}
		protected override void Extract()
		{
			base.Extract();
			comboBoxGroup.SelectedIndex = (Human as Student).Group;
			labelID.Text = (Human as Student).ID.ToString();
		}

	}
}
