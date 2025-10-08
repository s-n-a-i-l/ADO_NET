namespace Academy
{
	partial class MainForm
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
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageStudents = new System.Windows.Forms.TabPage();
			this.buttonAddEditStudent = new System.Windows.Forms.Button();
			this.comboBoxStudentsDirection = new System.Windows.Forms.ComboBox();
			this.labelStudentsDirection = new System.Windows.Forms.Label();
			this.comboBoxStudentsGroup = new System.Windows.Forms.ComboBox();
			this.labelStudentsGroup = new System.Windows.Forms.Label();
			this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.buttonAddEditGroup = new System.Windows.Forms.Button();
			this.comboBoxGroupsDirection = new System.Windows.Forms.ComboBox();
			this.labelGroupsDirection = new System.Windows.Forms.Label();
			this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
			this.tabPageDirections = new System.Windows.Forms.TabPage();
			this.checkBoxEmptyDirection = new System.Windows.Forms.CheckBox();
			this.dataGridViewDirections = new System.Windows.Forms.DataGridView();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.dataGridViewDisciplines = new System.Windows.Forms.DataGridView();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.buttonAddEditTeacher = new System.Windows.Forms.Button();
			this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
			this.tabPageGroups.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
			this.tabPageDirections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).BeginInit();
			this.tabPageDisciplines.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).BeginInit();
			this.tabPageTeachers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 428);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(800, 22);
			this.statusStrip.TabIndex = 0;
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageStudents);
			this.tabControl.Controls.Add(this.tabPageGroups);
			this.tabControl.Controls.Add(this.tabPageDirections);
			this.tabControl.Controls.Add(this.tabPageDisciplines);
			this.tabControl.Controls.Add(this.tabPageTeachers);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(800, 428);
			this.tabControl.TabIndex = 1;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged_1);
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.buttonAddEditStudent);
			this.tabPageStudents.Controls.Add(this.comboBoxStudentsDirection);
			this.tabPageStudents.Controls.Add(this.labelStudentsDirection);
			this.tabPageStudents.Controls.Add(this.comboBoxStudentsGroup);
			this.tabPageStudents.Controls.Add(this.labelStudentsGroup);
			this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 22);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(792, 402);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			// 
			// buttonAddEditStudent
			// 
			this.buttonAddEditStudent.Location = new System.Drawing.Point(662, 4);
			this.buttonAddEditStudent.Name = "buttonAddEditStudent";
			this.buttonAddEditStudent.Size = new System.Drawing.Size(122, 23);
			this.buttonAddEditStudent.TabIndex = 5;
			this.buttonAddEditStudent.Text = "Добавить/Изменить";
			this.buttonAddEditStudent.UseVisualStyleBackColor = true;
			this.buttonAddEditStudent.Click += new System.EventHandler(this.buttonAddEditStudent_Click);
			// 
			// comboBoxStudentsDirection
			// 
			this.comboBoxStudentsDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStudentsDirection.FormattingEnabled = true;
			this.comboBoxStudentsDirection.Location = new System.Drawing.Point(363, 4);
			this.comboBoxStudentsDirection.Name = "comboBoxStudentsDirection";
			this.comboBoxStudentsDirection.Size = new System.Drawing.Size(246, 21);
			this.comboBoxStudentsDirection.TabIndex = 4;
			this.comboBoxStudentsDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudentsDirection_SelectedIndexChanged);
			// 
			// labelStudentsDirection
			// 
			this.labelStudentsDirection.AutoSize = true;
			this.labelStudentsDirection.Location = new System.Drawing.Point(233, 7);
			this.labelStudentsDirection.Name = "labelStudentsDirection";
			this.labelStudentsDirection.Size = new System.Drawing.Size(124, 13);
			this.labelStudentsDirection.TabIndex = 3;
			this.labelStudentsDirection.Text = "Направление обучения";
			// 
			// comboBoxStudentsGroup
			// 
			this.comboBoxStudentsGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStudentsGroup.FormattingEnabled = true;
			this.comboBoxStudentsGroup.Location = new System.Drawing.Point(58, 4);
			this.comboBoxStudentsGroup.Name = "comboBoxStudentsGroup";
			this.comboBoxStudentsGroup.Size = new System.Drawing.Size(125, 21);
			this.comboBoxStudentsGroup.TabIndex = 2;
			this.comboBoxStudentsGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudentsGroup_SelectedIndexChanged);
			// 
			// labelStudentsGroup
			// 
			this.labelStudentsGroup.AutoSize = true;
			this.labelStudentsGroup.Location = new System.Drawing.Point(9, 7);
			this.labelStudentsGroup.Name = "labelStudentsGroup";
			this.labelStudentsGroup.Size = new System.Drawing.Size(42, 13);
			this.labelStudentsGroup.TabIndex = 1;
			this.labelStudentsGroup.Text = "Группа";
			// 
			// dataGridViewStudents
			// 
			this.dataGridViewStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudents.Location = new System.Drawing.Point(3, 30);
			this.dataGridViewStudents.MultiSelect = false;
			this.dataGridViewStudents.Name = "dataGridViewStudents";
			this.dataGridViewStudents.ReadOnly = true;
			this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewStudents.Size = new System.Drawing.Size(786, 369);
			this.dataGridViewStudents.TabIndex = 0;
			this.dataGridViewStudents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewStudents_MouseDoubleClick);
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Controls.Add(this.buttonAddEditGroup);
			this.tabPageGroups.Controls.Add(this.comboBoxGroupsDirection);
			this.tabPageGroups.Controls.Add(this.labelGroupsDirection);
			this.tabPageGroups.Controls.Add(this.dataGridViewGroups);
			this.tabPageGroups.Location = new System.Drawing.Point(4, 22);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(792, 402);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// buttonAddEditGroup
			// 
			this.buttonAddEditGroup.Location = new System.Drawing.Point(660, 5);
			this.buttonAddEditGroup.Name = "buttonAddEditGroup";
			this.buttonAddEditGroup.Size = new System.Drawing.Size(124, 23);
			this.buttonAddEditGroup.TabIndex = 3;
			this.buttonAddEditGroup.Text = "Добавить/Изменить";
			this.buttonAddEditGroup.UseVisualStyleBackColor = true;
			// 
			// comboBoxGroupsDirection
			// 
			this.comboBoxGroupsDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroupsDirection.FormattingEnabled = true;
			this.comboBoxGroupsDirection.Location = new System.Drawing.Point(143, 7);
			this.comboBoxGroupsDirection.Name = "comboBoxGroupsDirection";
			this.comboBoxGroupsDirection.Size = new System.Drawing.Size(321, 21);
			this.comboBoxGroupsDirection.TabIndex = 2;
			this.comboBoxGroupsDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupsDirection_SelectedIndexChanged);
			// 
			// labelGroupsDirection
			// 
			this.labelGroupsDirection.AutoSize = true;
			this.labelGroupsDirection.Location = new System.Drawing.Point(9, 11);
			this.labelGroupsDirection.Name = "labelGroupsDirection";
			this.labelGroupsDirection.Size = new System.Drawing.Size(127, 13);
			this.labelGroupsDirection.TabIndex = 1;
			this.labelGroupsDirection.Text = "Направление обучения:";
			// 
			// dataGridViewGroups
			// 
			this.dataGridViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGroups.Location = new System.Drawing.Point(3, 30);
			this.dataGridViewGroups.Name = "dataGridViewGroups";
			this.dataGridViewGroups.ReadOnly = true;
			this.dataGridViewGroups.Size = new System.Drawing.Size(786, 369);
			this.dataGridViewGroups.TabIndex = 0;
			// 
			// tabPageDirections
			// 
			this.tabPageDirections.Controls.Add(this.checkBoxEmptyDirection);
			this.tabPageDirections.Controls.Add(this.dataGridViewDirections);
			this.tabPageDirections.Location = new System.Drawing.Point(4, 22);
			this.tabPageDirections.Name = "tabPageDirections";
			this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDirections.Size = new System.Drawing.Size(792, 402);
			this.tabPageDirections.TabIndex = 2;
			this.tabPageDirections.Text = "Directions";
			this.tabPageDirections.UseVisualStyleBackColor = true;
			// 
			// checkBoxEmptyDirection
			// 
			this.checkBoxEmptyDirection.AutoSize = true;
			this.checkBoxEmptyDirection.Location = new System.Drawing.Point(606, 6);
			this.checkBoxEmptyDirection.Name = "checkBoxEmptyDirection";
			this.checkBoxEmptyDirection.Size = new System.Drawing.Size(183, 17);
			this.checkBoxEmptyDirection.TabIndex = 1;
			this.checkBoxEmptyDirection.Text = "Показать пустые направления";
			this.checkBoxEmptyDirection.UseVisualStyleBackColor = true;
			this.checkBoxEmptyDirection.CheckedChanged += new System.EventHandler(this.checkBoxEmptyDirection_CheckedChanged);
			// 
			// dataGridViewDirections
			// 
			this.dataGridViewDirections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewDirections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDirections.Location = new System.Drawing.Point(3, 29);
			this.dataGridViewDirections.Name = "dataGridViewDirections";
			this.dataGridViewDirections.Size = new System.Drawing.Size(786, 370);
			this.dataGridViewDirections.TabIndex = 0;
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Controls.Add(this.dataGridViewDisciplines);
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 22);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisciplines.Size = new System.Drawing.Size(792, 402);
			this.tabPageDisciplines.TabIndex = 3;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// dataGridViewDisciplines
			// 
			this.dataGridViewDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewDisciplines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridViewDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDisciplines.Location = new System.Drawing.Point(3, 27);
			this.dataGridViewDisciplines.Name = "dataGridViewDisciplines";
			this.dataGridViewDisciplines.Size = new System.Drawing.Size(786, 372);
			this.dataGridViewDisciplines.TabIndex = 0;
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Controls.Add(this.buttonAddEditTeacher);
			this.tabPageTeachers.Controls.Add(this.dataGridViewTeachers);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 22);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Size = new System.Drawing.Size(792, 402);
			this.tabPageTeachers.TabIndex = 4;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
			// buttonAddEditTeacher
			// 
			this.buttonAddEditTeacher.Location = new System.Drawing.Point(659, 3);
			this.buttonAddEditTeacher.Name = "buttonAddEditTeacher";
			this.buttonAddEditTeacher.Size = new System.Drawing.Size(125, 23);
			this.buttonAddEditTeacher.TabIndex = 1;
			this.buttonAddEditTeacher.Text = "Добавить/Изменить";
			this.buttonAddEditTeacher.UseVisualStyleBackColor = true;
			// 
			// dataGridViewTeachers
			// 
			this.dataGridViewTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTeachers.Location = new System.Drawing.Point(3, 29);
			this.dataGridViewTeachers.Name = "dataGridViewTeachers";
			this.dataGridViewTeachers.Size = new System.Drawing.Size(789, 373);
			this.dataGridViewTeachers.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.statusStrip);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Academy PD_411";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageStudents.ResumeLayout(false);
			this.tabPageStudents.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
			this.tabPageGroups.ResumeLayout(false);
			this.tabPageGroups.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
			this.tabPageDirections.ResumeLayout(false);
			this.tabPageDirections.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirections)).EndInit();
			this.tabPageDisciplines.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).EndInit();
			this.tabPageTeachers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDirections;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeachers;
		private System.Windows.Forms.DataGridView dataGridViewDirections;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.DataGridView dataGridViewDisciplines;
		private System.Windows.Forms.DataGridView dataGridViewStudents;
		private System.Windows.Forms.DataGridView dataGridViewGroups;
		private System.Windows.Forms.DataGridView dataGridViewTeachers;
		private System.Windows.Forms.Button buttonAddEditStudent;
		private System.Windows.Forms.ComboBox comboBoxStudentsDirection;
		private System.Windows.Forms.Label labelStudentsDirection;
		private System.Windows.Forms.ComboBox comboBoxStudentsGroup;
		private System.Windows.Forms.Label labelStudentsGroup;
		private System.Windows.Forms.ComboBox comboBoxGroupsDirection;
		private System.Windows.Forms.Label labelGroupsDirection;
		private System.Windows.Forms.CheckBox checkBoxEmptyDirection;
		private System.Windows.Forms.Button buttonAddEditGroup;
		private System.Windows.Forms.Button buttonAddEditTeacher;
	}
}

