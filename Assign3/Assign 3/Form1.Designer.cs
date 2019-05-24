namespace Assign3
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
            this.ResultButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ResultButton2 = new System.Windows.Forms.Button();
            this.ResultButton3 = new System.Windows.Forms.Button();
            this.ResultButton4 = new System.Windows.Forms.Button();
            this.ResultButton6 = new System.Windows.Forms.Button();
            this.ResultButton5 = new System.Windows.Forms.Button();
            this.zidBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.greaterThanRadioThreshold = new System.Windows.Forms.RadioButton();
            this.lessThanRadioThreshold = new System.Windows.Forms.RadioButton();
            this.gradeComboBoxThreshold = new System.Windows.Forms.ComboBox();
            this.courseBoxThreshold = new System.Windows.Forms.TextBox();
            this.majorComboBoxStudentFail = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.courseBoxStudentFail = new System.Windows.Forms.TextBox();
            this.courseBoxGradeReport = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.greaterThanRadioFailReport = new System.Windows.Forms.RadioButton();
            this.lessThanRadioFailReport = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.percentSpinnerFailReport = new System.Windows.Forms.NumericUpDown();
            this.greaterThanRadioPassReport = new System.Windows.Forms.RadioButton();
            this.lessThanRadioPassReport = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gradeComboPassReport = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.queryOut = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentSpinnerFailReport)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultButton1
            // 
            this.ResultButton1.Location = new System.Drawing.Point(337, 33);
            this.ResultButton1.Name = "ResultButton1";
            this.ResultButton1.Size = new System.Drawing.Size(86, 23);
            this.ResultButton1.TabIndex = 1;
            this.ResultButton1.Text = "Show Results";
            this.ResultButton1.UseVisualStyleBackColor = true;
            this.ResultButton1.Click += new System.EventHandler(this.ResultButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Grade Report for One Student";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Grade Threshold for One Course";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Z-ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fail Report for All Courses";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 474);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Pass Report for All Courses";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(280, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Major students who Failed a Course";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Grade Report for One Course";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Grade";
            // 
            // ResultButton2
            // 
            this.ResultButton2.Location = new System.Drawing.Point(337, 130);
            this.ResultButton2.Name = "ResultButton2";
            this.ResultButton2.Size = new System.Drawing.Size(86, 23);
            this.ResultButton2.TabIndex = 15;
            this.ResultButton2.Text = "Show Results";
            this.ResultButton2.UseVisualStyleBackColor = true;
            this.ResultButton2.Click += new System.EventHandler(this.ResultButton2_Click);
            // 
            // ResultButton3
            // 
            this.ResultButton3.Location = new System.Drawing.Point(340, 227);
            this.ResultButton3.Name = "ResultButton3";
            this.ResultButton3.Size = new System.Drawing.Size(86, 23);
            this.ResultButton3.TabIndex = 16;
            this.ResultButton3.Text = "Show Results";
            this.ResultButton3.UseVisualStyleBackColor = true;
            this.ResultButton3.Click += new System.EventHandler(this.ResultButton3_Click);
            // 
            // ResultButton4
            // 
            this.ResultButton4.Location = new System.Drawing.Point(337, 337);
            this.ResultButton4.Name = "ResultButton4";
            this.ResultButton4.Size = new System.Drawing.Size(86, 23);
            this.ResultButton4.TabIndex = 17;
            this.ResultButton4.Text = "Show Results";
            this.ResultButton4.UseVisualStyleBackColor = true;
            this.ResultButton4.Click += new System.EventHandler(this.ResultButton4_Click);
            // 
            // ResultButton6
            // 
            this.ResultButton6.Location = new System.Drawing.Point(337, 546);
            this.ResultButton6.Name = "ResultButton6";
            this.ResultButton6.Size = new System.Drawing.Size(86, 23);
            this.ResultButton6.TabIndex = 18;
            this.ResultButton6.Text = "Show Results";
            this.ResultButton6.UseVisualStyleBackColor = true;
            this.ResultButton6.Click += new System.EventHandler(this.ResultButton6_Click);
            // 
            // ResultButton5
            // 
            this.ResultButton5.Location = new System.Drawing.Point(337, 438);
            this.ResultButton5.Name = "ResultButton5";
            this.ResultButton5.Size = new System.Drawing.Size(86, 23);
            this.ResultButton5.TabIndex = 19;
            this.ResultButton5.Text = "Show Results";
            this.ResultButton5.UseVisualStyleBackColor = true;
            this.ResultButton5.Click += new System.EventHandler(this.ResultButton5_Click);
            // 
            // zidBox
            // 
            this.zidBox.Location = new System.Drawing.Point(51, 30);
            this.zidBox.Name = "zidBox";
            this.zidBox.Size = new System.Drawing.Size(100, 20);
            this.zidBox.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.greaterThanRadioThreshold);
            this.groupBox1.Controls.Add(this.lessThanRadioThreshold);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 69);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // greaterThanRadioThreshold
            // 
            this.greaterThanRadioThreshold.AutoSize = true;
            this.greaterThanRadioThreshold.Checked = true;
            this.greaterThanRadioThreshold.Location = new System.Drawing.Point(8, 42);
            this.greaterThanRadioThreshold.Name = "greaterThanRadioThreshold";
            this.greaterThanRadioThreshold.Size = new System.Drawing.Size(146, 17);
            this.greaterThanRadioThreshold.TabIndex = 1;
            this.greaterThanRadioThreshold.TabStop = true;
            this.greaterThanRadioThreshold.Text = "Greater Than or Equal To";
            this.greaterThanRadioThreshold.UseVisualStyleBackColor = true;
            // 
            // lessThanRadioThreshold
            // 
            this.lessThanRadioThreshold.AutoSize = true;
            this.lessThanRadioThreshold.Location = new System.Drawing.Point(8, 19);
            this.lessThanRadioThreshold.Name = "lessThanRadioThreshold";
            this.lessThanRadioThreshold.Size = new System.Drawing.Size(133, 17);
            this.lessThanRadioThreshold.TabIndex = 0;
            this.lessThanRadioThreshold.Text = "Less Than or Equal To";
            this.lessThanRadioThreshold.UseVisualStyleBackColor = true;
            // 
            // gradeComboBoxThreshold
            // 
            this.gradeComboBoxThreshold.FormattingEnabled = true;
            this.gradeComboBoxThreshold.Location = new System.Drawing.Point(188, 133);
            this.gradeComboBoxThreshold.Name = "gradeComboBoxThreshold";
            this.gradeComboBoxThreshold.Size = new System.Drawing.Size(37, 21);
            this.gradeComboBoxThreshold.TabIndex = 22;
            // 
            // courseBoxThreshold
            // 
            this.courseBoxThreshold.Location = new System.Drawing.Point(231, 133);
            this.courseBoxThreshold.Name = "courseBoxThreshold";
            this.courseBoxThreshold.Size = new System.Drawing.Size(100, 20);
            this.courseBoxThreshold.TabIndex = 23;
            // 
            // majorComboBoxStudentFail
            // 
            this.majorComboBoxStudentFail.FormattingEnabled = true;
            this.majorComboBoxStudentFail.Location = new System.Drawing.Point(15, 227);
            this.majorComboBoxStudentFail.Name = "majorComboBoxStudentFail";
            this.majorComboBoxStudentFail.Size = new System.Drawing.Size(121, 21);
            this.majorComboBoxStudentFail.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Course";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Major";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(234, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Course";
            // 
            // courseBoxStudentFail
            // 
            this.courseBoxStudentFail.Location = new System.Drawing.Point(237, 227);
            this.courseBoxStudentFail.Name = "courseBoxStudentFail";
            this.courseBoxStudentFail.Size = new System.Drawing.Size(100, 20);
            this.courseBoxStudentFail.TabIndex = 28;
            // 
            // courseBoxGradeReport
            // 
            this.courseBoxGradeReport.Location = new System.Drawing.Point(58, 334);
            this.courseBoxGradeReport.Name = "courseBoxGradeReport";
            this.courseBoxGradeReport.Size = new System.Drawing.Size(100, 20);
            this.courseBoxGradeReport.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 337);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Course";
            // 
            // greaterThanRadioFailReport
            // 
            this.greaterThanRadioFailReport.AutoSize = true;
            this.greaterThanRadioFailReport.Checked = true;
            this.greaterThanRadioFailReport.Location = new System.Drawing.Point(8, 42);
            this.greaterThanRadioFailReport.Name = "greaterThanRadioFailReport";
            this.greaterThanRadioFailReport.Size = new System.Drawing.Size(146, 17);
            this.greaterThanRadioFailReport.TabIndex = 1;
            this.greaterThanRadioFailReport.TabStop = true;
            this.greaterThanRadioFailReport.Text = "Greater Than or Equal To";
            this.greaterThanRadioFailReport.UseVisualStyleBackColor = true;
            // 
            // lessThanRadioFailReport
            // 
            this.lessThanRadioFailReport.AutoSize = true;
            this.lessThanRadioFailReport.Location = new System.Drawing.Point(8, 19);
            this.lessThanRadioFailReport.Name = "lessThanRadioFailReport";
            this.lessThanRadioFailReport.Size = new System.Drawing.Size(133, 17);
            this.lessThanRadioFailReport.TabIndex = 0;
            this.lessThanRadioFailReport.Text = "Less Than or Equal To";
            this.lessThanRadioFailReport.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.greaterThanRadioFailReport);
            this.groupBox2.Controls.Add(this.lessThanRadioFailReport);
            this.groupBox2.Location = new System.Drawing.Point(12, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 62);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // percentSpinnerFailReport
            // 
            this.percentSpinnerFailReport.Location = new System.Drawing.Point(188, 441);
            this.percentSpinnerFailReport.Name = "percentSpinnerFailReport";
            this.percentSpinnerFailReport.Size = new System.Drawing.Size(58, 20);
            this.percentSpinnerFailReport.TabIndex = 32;
            // 
            // greaterThanRadioPassReport
            // 
            this.greaterThanRadioPassReport.AutoSize = true;
            this.greaterThanRadioPassReport.Checked = true;
            this.greaterThanRadioPassReport.Location = new System.Drawing.Point(8, 42);
            this.greaterThanRadioPassReport.Name = "greaterThanRadioPassReport";
            this.greaterThanRadioPassReport.Size = new System.Drawing.Size(146, 17);
            this.greaterThanRadioPassReport.TabIndex = 1;
            this.greaterThanRadioPassReport.TabStop = true;
            this.greaterThanRadioPassReport.Text = "Greater Than or Equal To";
            this.greaterThanRadioPassReport.UseVisualStyleBackColor = true;
            // 
            // lessThanRadioPassReport
            // 
            this.lessThanRadioPassReport.AutoSize = true;
            this.lessThanRadioPassReport.Location = new System.Drawing.Point(8, 19);
            this.lessThanRadioPassReport.Name = "lessThanRadioPassReport";
            this.lessThanRadioPassReport.Size = new System.Drawing.Size(133, 17);
            this.lessThanRadioPassReport.TabIndex = 0;
            this.lessThanRadioPassReport.Text = "Less Than or Equal To";
            this.lessThanRadioPassReport.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.greaterThanRadioPassReport);
            this.groupBox3.Controls.Add(this.lessThanRadioPassReport);
            this.groupBox3.Location = new System.Drawing.Point(12, 504);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 62);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // gradeComboPassReport
            // 
            this.gradeComboPassReport.FormattingEnabled = true;
            this.gradeComboPassReport.Location = new System.Drawing.Point(188, 545);
            this.gradeComboPassReport.Name = "gradeComboPassReport";
            this.gradeComboPassReport.Size = new System.Drawing.Size(37, 21);
            this.gradeComboPassReport.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(189, 527);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Grade";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(187, 425);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Percent";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(452, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 25);
            this.label15.TabIndex = 37;
            this.label15.Text = "Query Results";
            // 
            // queryOut
            // 
            this.queryOut.Location = new System.Drawing.Point(457, 37);
            this.queryOut.Name = "queryOut";
            this.queryOut.Size = new System.Drawing.Size(665, 573);
            this.queryOut.TabIndex = 38;
            this.queryOut.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 622);
            this.Controls.Add(this.queryOut);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gradeComboPassReport);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.percentSpinnerFailReport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.courseBoxGradeReport);
            this.Controls.Add(this.courseBoxStudentFail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.majorComboBoxStudentFail);
            this.Controls.Add(this.courseBoxThreshold);
            this.Controls.Add(this.gradeComboBoxThreshold);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zidBox);
            this.Controls.Add(this.ResultButton5);
            this.Controls.Add(this.ResultButton6);
            this.Controls.Add(this.ResultButton4);
            this.Controls.Add(this.ResultButton3);
            this.Controls.Add(this.ResultButton2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultButton1);
            this.Name = "MainForm";
            this.Text = "NIU Academic Performance Query System";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentSpinnerFailReport)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResultButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ResultButton2;
        private System.Windows.Forms.Button ResultButton3;
        private System.Windows.Forms.Button ResultButton4;
        private System.Windows.Forms.Button ResultButton6;
        private System.Windows.Forms.Button ResultButton5;
        private System.Windows.Forms.TextBox zidBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton greaterThanRadioThreshold;
        private System.Windows.Forms.RadioButton lessThanRadioThreshold;
        private System.Windows.Forms.ComboBox gradeComboBoxThreshold;
        private System.Windows.Forms.TextBox courseBoxThreshold;
        private System.Windows.Forms.ComboBox majorComboBoxStudentFail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox courseBoxStudentFail;
        private System.Windows.Forms.TextBox courseBoxGradeReport;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton greaterThanRadioFailReport;
        private System.Windows.Forms.RadioButton lessThanRadioFailReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown percentSpinnerFailReport;
        private System.Windows.Forms.RadioButton greaterThanRadioPassReport;
        private System.Windows.Forms.RadioButton lessThanRadioPassReport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox gradeComboPassReport;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox queryOut;
    }
}

