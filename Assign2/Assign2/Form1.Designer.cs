namespace Assign2
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
            this.printRosterButton = new System.Windows.Forms.Button();
            this.enrollStudentButton = new System.Windows.Forms.Button();
            this.dropStudentButton = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.searchStudentInputBox = new System.Windows.Forms.TextBox();
            this.courseNoInputBox = new System.Windows.Forms.TextBox();
            this.zidBox = new System.Windows.Forms.TextBox();
            this.sectionNoInputBox = new System.Windows.Forms.TextBox();
            this.filterCoursesInputBox = new System.Windows.Forms.TextBox();
            this.nameInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.majorCbx = new System.Windows.Forms.ComboBox();
            this.departCbx = new System.Windows.Forms.ComboBox();
            this.yearCbx = new System.Windows.Forms.ComboBox();
            this.CapacitySpinnerBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.courseOut = new System.Windows.Forms.RichTextBox();
            this.StudentListBox = new System.Windows.Forms.ListBox();
            this.courseListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.CapacitySpinnerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // printRosterButton
            // 
            this.printRosterButton.Location = new System.Drawing.Point(27, 60);
            this.printRosterButton.Name = "printRosterButton";
            this.printRosterButton.Size = new System.Drawing.Size(114, 23);
            this.printRosterButton.TabIndex = 0;
            this.printRosterButton.Text = "Print Course Roster";
            this.printRosterButton.UseVisualStyleBackColor = true;
            this.printRosterButton.Click += new System.EventHandler(this.Print_Roster);
            // 
            // enrollStudentButton
            // 
            this.enrollStudentButton.Location = new System.Drawing.Point(27, 84);
            this.enrollStudentButton.Name = "enrollStudentButton";
            this.enrollStudentButton.Size = new System.Drawing.Size(114, 23);
            this.enrollStudentButton.TabIndex = 0;
            this.enrollStudentButton.Text = "Enroll Student";
            this.enrollStudentButton.UseVisualStyleBackColor = true;
            this.enrollStudentButton.Click += new System.EventHandler(this.Enroll_Student);
            // 
            // dropStudentButton
            // 
            this.dropStudentButton.Location = new System.Drawing.Point(27, 113);
            this.dropStudentButton.Name = "dropStudentButton";
            this.dropStudentButton.Size = new System.Drawing.Size(114, 23);
            this.dropStudentButton.TabIndex = 0;
            this.dropStudentButton.Text = "Drop Student";
            this.dropStudentButton.UseVisualStyleBackColor = true;
            this.dropStudentButton.Click += new System.EventHandler(this.Drop_Student);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(27, 142);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(114, 23);
            this.Search.TabIndex = 0;
            this.Search.Text = "Apply Search Criteria";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Apply_Search);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(27, 281);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Add Student";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Add_Student);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(27, 412);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Add Course";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Add_Course);
            // 
            // searchStudentInputBox
            // 
            this.searchStudentInputBox.Location = new System.Drawing.Point(156, 84);
            this.searchStudentInputBox.Name = "searchStudentInputBox";
            this.searchStudentInputBox.Size = new System.Drawing.Size(147, 20);
            this.searchStudentInputBox.TabIndex = 1;
            // 
            // courseNoInputBox
            // 
            this.courseNoInputBox.Location = new System.Drawing.Point(180, 347);
            this.courseNoInputBox.Name = "courseNoInputBox";
            this.courseNoInputBox.Size = new System.Drawing.Size(147, 20);
            this.courseNoInputBox.TabIndex = 2;
            // 
            // zidBox
            // 
            this.zidBox.Location = new System.Drawing.Point(180, 215);
            this.zidBox.Name = "zidBox";
            this.zidBox.Size = new System.Drawing.Size(147, 20);
            this.zidBox.TabIndex = 3;
            // 
            // sectionNoInputBox
            // 
            this.sectionNoInputBox.Location = new System.Drawing.Point(27, 386);
            this.sectionNoInputBox.Name = "sectionNoInputBox";
            this.sectionNoInputBox.Size = new System.Drawing.Size(147, 20);
            this.sectionNoInputBox.TabIndex = 6;
            // 
            // filterCoursesInputBox
            // 
            this.filterCoursesInputBox.Location = new System.Drawing.Point(156, 125);
            this.filterCoursesInputBox.Name = "filterCoursesInputBox";
            this.filterCoursesInputBox.Size = new System.Drawing.Size(147, 20);
            this.filterCoursesInputBox.TabIndex = 7;
            // 
            // nameInputBox
            // 
            this.nameInputBox.Location = new System.Drawing.Point(27, 215);
            this.nameInputBox.Name = "nameInputBox";
            this.nameInputBox.Size = new System.Drawing.Size(147, 20);
            this.nameInputBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search Student (by Z-ID)";
            // 
            // majorCbx
            // 
            this.majorCbx.FormattingEnabled = true;
            this.majorCbx.Location = new System.Drawing.Point(27, 254);
            this.majorCbx.Name = "majorCbx";
            this.majorCbx.Size = new System.Drawing.Size(147, 21);
            this.majorCbx.TabIndex = 10;
            // 
            // departCbx
            // 
            this.departCbx.FormattingEnabled = true;
            this.departCbx.Location = new System.Drawing.Point(27, 346);
            this.departCbx.Name = "departCbx";
            this.departCbx.Size = new System.Drawing.Size(147, 21);
            this.departCbx.TabIndex = 10;
            // 
            // yearCbx
            // 
            this.yearCbx.FormattingEnabled = true;
            this.yearCbx.Location = new System.Drawing.Point(180, 254);
            this.yearCbx.Name = "yearCbx";
            this.yearCbx.Size = new System.Drawing.Size(147, 21);
            this.yearCbx.TabIndex = 10;
            // 
            // CapacitySpinnerBox
            // 
            this.CapacitySpinnerBox.Location = new System.Drawing.Point(180, 387);
            this.CapacitySpinnerBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.CapacitySpinnerBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CapacitySpinnerBox.Name = "CapacitySpinnerBox";
            this.CapacitySpinnerBox.Size = new System.Drawing.Size(144, 20);
            this.CapacitySpinnerBox.TabIndex = 11;
            this.CapacitySpinnerBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter Courses (by Dept)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last Name, First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Z-ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Major";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Academic Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Course Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Section Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Capacity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Department Code";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(248, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(351, 24);
            this.label11.TabIndex = 9;
            this.label11.Text = "NIU Enrollment Management System";
            // 
            // courseOut
            // 
            this.courseOut.Location = new System.Drawing.Point(27, 457);
            this.courseOut.Name = "courseOut";
            this.courseOut.Size = new System.Drawing.Size(761, 80);
            this.courseOut.TabIndex = 12;
            this.courseOut.Text = "";
            // 
            // StudentListBox
            // 
            this.StudentListBox.FormattingEnabled = true;
            this.StudentListBox.Location = new System.Drawing.Point(412, 60);
            this.StudentListBox.Name = "StudentListBox";
            this.StudentListBox.Size = new System.Drawing.Size(170, 381);
            this.StudentListBox.TabIndex = 13;
            this.StudentListBox.SelectedIndexChanged += new System.EventHandler(this.StudentListBox_SelectedIndexChanged);
            // 
            // courseListBox
            // 
            this.courseListBox.FormattingEnabled = true;
            this.courseListBox.Location = new System.Drawing.Point(618, 60);
            this.courseListBox.Name = "courseListBox";
            this.courseListBox.Size = new System.Drawing.Size(170, 381);
            this.courseListBox.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.courseListBox);
            this.Controls.Add(this.StudentListBox);
            this.Controls.Add(this.courseOut);
            this.Controls.Add(this.CapacitySpinnerBox);
            this.Controls.Add(this.departCbx);
            this.Controls.Add(this.yearCbx);
            this.Controls.Add(this.majorCbx);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameInputBox);
            this.Controls.Add(this.filterCoursesInputBox);
            this.Controls.Add(this.sectionNoInputBox);
            this.Controls.Add(this.zidBox);
            this.Controls.Add(this.courseNoInputBox);
            this.Controls.Add(this.searchStudentInputBox);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dropStudentButton);
            this.Controls.Add(this.enrollStudentButton);
            this.Controls.Add(this.printRosterButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CapacitySpinnerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printRosterButton;
        private System.Windows.Forms.Button enrollStudentButton;
        private System.Windows.Forms.Button dropStudentButton;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox searchStudentInputBox;
        private System.Windows.Forms.TextBox courseNoInputBox;
        private System.Windows.Forms.TextBox zidBox;
        private System.Windows.Forms.TextBox sectionNoInputBox;
        private System.Windows.Forms.TextBox filterCoursesInputBox;
        private System.Windows.Forms.TextBox nameInputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox majorCbx;
        private System.Windows.Forms.ComboBox departCbx;
        private System.Windows.Forms.ComboBox yearCbx;
        private System.Windows.Forms.NumericUpDown CapacitySpinnerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox courseOut;
        private System.Windows.Forms.ListBox StudentListBox;
        private System.Windows.Forms.ListBox courseListBox;
    }
}

