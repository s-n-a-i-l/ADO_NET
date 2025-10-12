using System;
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
	public partial class TeacherForm :BaseHumanForm
	{
		public TeacherForm()
		{
			InitializeComponent();
			//connector = new Connector();
			buttonOK.Click += new EventHandler(buttonOK_Click);
		}

		public TeacherForm(short id) :this()
		{
			Human = new Teacher(id);
			Extract();
		}
		protected override void buttonOK_Click(object sender, EventArgs e)
		{
			Human = new Teacher
				(
					textBoxLastName.Text,
					textBoxFirstName.Text,
					textBoxMiddleName.Text,
					dateTimePickerBirthDate.Text,
					textBoxEmail.Text,
					textBoxPhone.Text,
					pictureBoxPhoto.Image,
					dateTimePickerWorkSince.Text,
					Convert.ToDecimal(textBoxRate.Text)
				);
		}

		protected override void Extract()
		{
			base.Extract();
			dateTimePickerWorkSince.Text = (Human as Teacher).WorkSince.ToString();
			textBoxRate.Text = (Human as Teacher).Rate.ToString();
			labelID.Text = (Human as Teacher).ID.ToString();
		}
	}
}
