﻿namespace Academy
{
	partial class StudentForm
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
			this.labelLastName = new System.Windows.Forms.Label();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.labelMiddleName = new System.Windows.Forms.Label();
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.labelGroup = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxMiddleName = new System.Windows.Forms.TextBox();
			this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.comboBoxGroup = new System.Windows.Forms.ComboBox();
			this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
			this.buttonBrowsPhoto = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelID = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// labelLastName
			// 
			this.labelLastName.AllowDrop = true;
			this.labelLastName.AutoSize = true;
			this.labelLastName.Location = new System.Drawing.Point(33, 12);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(59, 13);
			this.labelLastName.TabIndex = 0;
			this.labelLastName.Text = "Фамилия:";
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Location = new System.Drawing.Point(58, 51);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(32, 13);
			this.labelFirstName.TabIndex = 1;
			this.labelFirstName.Text = "Имя:";
			// 
			// labelMiddleName
			// 
			this.labelMiddleName.AutoSize = true;
			this.labelMiddleName.Location = new System.Drawing.Point(33, 90);
			this.labelMiddleName.Name = "labelMiddleName";
			this.labelMiddleName.Size = new System.Drawing.Size(57, 13);
			this.labelMiddleName.TabIndex = 2;
			this.labelMiddleName.Text = "Отчество:";
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Location = new System.Drawing.Point(1, 129);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(89, 13);
			this.labelBirthDate.TabIndex = 3;
			this.labelBirthDate.Text = "Дата рождения:";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(52, 161);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(38, 13);
			this.labelEmail.TabIndex = 4;
			this.labelEmail.Text = "E-mail:";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Location = new System.Drawing.Point(37, 202);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(55, 13);
			this.labelPhone.TabIndex = 5;
			this.labelPhone.Text = "Телефон:";
			// 
			// labelGroup
			// 
			this.labelGroup.AutoSize = true;
			this.labelGroup.Location = new System.Drawing.Point(45, 250);
			this.labelGroup.Name = "labelGroup";
			this.labelGroup.Size = new System.Drawing.Size(45, 13);
			this.labelGroup.TabIndex = 6;
			this.labelGroup.Text = "Группа:";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(98, 9);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(197, 20);
			this.textBoxLastName.TabIndex = 7;
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Location = new System.Drawing.Point(98, 47);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(135, 20);
			this.textBoxFirstName.TabIndex = 8;
			// 
			// textBoxMiddleName
			// 
			this.textBoxMiddleName.Location = new System.Drawing.Point(98, 86);
			this.textBoxMiddleName.Name = "textBoxMiddleName";
			this.textBoxMiddleName.Size = new System.Drawing.Size(135, 20);
			this.textBoxMiddleName.TabIndex = 9;
			// 
			// dateTimePickerBirthDate
			// 
			this.dateTimePickerBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerBirthDate.Location = new System.Drawing.Point(98, 125);
			this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
			this.dateTimePickerBirthDate.Size = new System.Drawing.Size(99, 20);
			this.dateTimePickerBirthDate.TabIndex = 10;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(98, 158);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(197, 20);
			this.textBoxEmail.TabIndex = 11;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(98, 199);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(197, 20);
			this.textBoxPhone.TabIndex = 12;
			// 
			// comboBoxGroup
			// 
			this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroup.FormattingEnabled = true;
			this.comboBoxGroup.Location = new System.Drawing.Point(98, 246);
			this.comboBoxGroup.Name = "comboBoxGroup";
			this.comboBoxGroup.Size = new System.Drawing.Size(135, 21);
			this.comboBoxGroup.TabIndex = 13;
			// 
			// pictureBoxPhoto
			// 
			this.pictureBoxPhoto.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPhoto.Location = new System.Drawing.Point(301, 9);
			this.pictureBoxPhoto.Name = "pictureBoxPhoto";
			this.pictureBoxPhoto.Size = new System.Drawing.Size(200, 234);
			this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPhoto.TabIndex = 14;
			this.pictureBoxPhoto.TabStop = false;
			// 
			// buttonBrowsPhoto
			// 
			this.buttonBrowsPhoto.Location = new System.Drawing.Point(368, 250);
			this.buttonBrowsPhoto.Name = "buttonBrowsPhoto";
			this.buttonBrowsPhoto.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowsPhoto.TabIndex = 15;
			this.buttonBrowsPhoto.Text = "Обзор";
			this.buttonBrowsPhoto.UseVisualStyleBackColor = true;
			this.buttonBrowsPhoto.Click += new System.EventHandler(this.buttonBrowsPhoto_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(362, 304);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 16;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(443, 304);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelID.Location = new System.Drawing.Point(13, 307);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(27, 24);
			this.labelID.TabIndex = 18;
			this.labelID.Text = "ID";
			this.labelID.Visible = false;
			// 
			// StudentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 332);
			this.Controls.Add(this.labelID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonBrowsPhoto);
			this.Controls.Add(this.pictureBoxPhoto);
			this.Controls.Add(this.comboBoxGroup);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.dateTimePickerBirthDate);
			this.Controls.Add(this.textBoxMiddleName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelGroup);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelBirthDate);
			this.Controls.Add(this.labelMiddleName);
			this.Controls.Add(this.labelFirstName);
			this.Controls.Add(this.labelLastName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "StudentForm";
			this.Text = "StudentForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.Label labelMiddleName;
		private System.Windows.Forms.Label labelBirthDate;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.Label labelGroup;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.TextBox textBoxMiddleName;
		private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.ComboBox comboBoxGroup;
		private System.Windows.Forms.PictureBox pictureBoxPhoto;
		private System.Windows.Forms.Button buttonBrowsPhoto;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelID;
	}
}