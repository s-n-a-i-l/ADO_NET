namespace Academy
{
	partial class TeacherForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelWorkSince = new System.Windows.Forms.Label();
			this.dateTimePickerWorkSince = new System.Windows.Forms.DateTimePicker();
			this.labelRate = new System.Windows.Forms.Label();
			this.textBoxRate = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(414, 334);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(339, 334);
			// 
			// buttonBrowsPhoto
			// 
			this.buttonBrowsPhoto.Location = new System.Drawing.Point(264, 334);
			// 
			// labelWorkSince
			// 
			this.labelWorkSince.AutoSize = true;
			this.labelWorkSince.Location = new System.Drawing.Point(7, 251);
			this.labelWorkSince.Name = "labelWorkSince";
			this.labelWorkSince.Size = new System.Drawing.Size(73, 13);
			this.labelWorkSince.TabIndex = 12;
			this.labelWorkSince.Text = "Рабочие дни:";
			// 
			// dateTimePickerWorkSince
			// 
			this.dateTimePickerWorkSince.CustomFormat = "yyyy-MM-dd";
			this.dateTimePickerWorkSince.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerWorkSince.Location = new System.Drawing.Point(86, 245);
			this.dateTimePickerWorkSince.Name = "dateTimePickerWorkSince";
			this.dateTimePickerWorkSince.Size = new System.Drawing.Size(122, 20);
			this.dateTimePickerWorkSince.TabIndex = 13;
			// 
			// labelRate
			// 
			this.labelRate.AutoSize = true;
			this.labelRate.Location = new System.Drawing.Point(7, 283);
			this.labelRate.Name = "labelRate";
			this.labelRate.Size = new System.Drawing.Size(46, 13);
			this.labelRate.TabIndex = 20;
			this.labelRate.Text = "Ставка:";
			// 
			// textBoxRate
			// 
			this.textBoxRate.Location = new System.Drawing.Point(63, 280);
			this.textBoxRate.Name = "textBoxRate";
			this.textBoxRate.Size = new System.Drawing.Size(100, 20);
			this.textBoxRate.TabIndex = 21;
			// 
			// TeacherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 368);
			this.Controls.Add(this.textBoxRate);
			this.Controls.Add(this.labelRate);
			this.Controls.Add(this.dateTimePickerWorkSince);
			this.Controls.Add(this.labelWorkSince);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "TeacherForm";
			this.Text = "TeacherForm";
			this.Controls.SetChildIndex(this.labelWorkSince, 0);
			this.Controls.SetChildIndex(this.dateTimePickerWorkSince, 0);
			this.Controls.SetChildIndex(this.labelRate, 0);
			this.Controls.SetChildIndex(this.textBoxRate, 0);
			this.Controls.SetChildIndex(this.labelLastName, 0);
			this.Controls.SetChildIndex(this.labelFirstName, 0);
			this.Controls.SetChildIndex(this.labelMiddleName, 0);
			this.Controls.SetChildIndex(this.labelEmail, 0);
			this.Controls.SetChildIndex(this.labelBirthDate, 0);
			this.Controls.SetChildIndex(this.labelPhone, 0);
			this.Controls.SetChildIndex(this.textBoxLastName, 0);
			this.Controls.SetChildIndex(this.textBoxFirstName, 0);
			this.Controls.SetChildIndex(this.textBoxMiddleName, 0);
			this.Controls.SetChildIndex(this.dateTimePickerBirthDate, 0);
			this.Controls.SetChildIndex(this.textBoxEmail, 0);
			this.Controls.SetChildIndex(this.textBoxPhone, 0);
			this.Controls.SetChildIndex(this.pictureBoxPhoto, 0);
			this.Controls.SetChildIndex(this.buttonBrowsPhoto, 0);
			this.Controls.SetChildIndex(this.buttonOK, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.labelID, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelWorkSince;
		private System.Windows.Forms.DateTimePicker dateTimePickerWorkSince;
		private System.Windows.Forms.Label labelRate;
		private System.Windows.Forms.TextBox textBoxRate;
	}
}