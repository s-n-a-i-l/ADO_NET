﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace LINQ
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			AllocConsole();

			// создаем источник данных
			int[] arr = { 3, 5, 8, 13, 21, 34, 55 };

			//определяем query expression
			IEnumerable<int> FibonacciQuery =
				from i in arr
				where i > 20
				orderby i descending
				select i;

			//выполнение запроса
			foreach(int i in FibonacciQuery) 
			{
			  Console.Write($"{i}\t");
			}
			 Console.WriteLine();
		}
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();

		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();
	}
	
}
