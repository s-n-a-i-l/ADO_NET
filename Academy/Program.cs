using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			UserVerification();
		}
		static void UserVerification() 
		{
			LoginForm login = new LoginForm();
			DialogResult result = login.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (login.Resut) Application.Run(new MainForm());
				else MessageBox.Show("Произошла ошибка при попытке входа.\nНеверный логин или пароль.", "Ошибка");
			}
			else return;
		}
	}
}
