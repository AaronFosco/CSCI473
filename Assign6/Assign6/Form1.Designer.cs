namespace Assign6
{
    partial class Form1
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
            this.ScatterButton = new System.Windows.Forms.Button();
            this.BarButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.BubbleButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScatterButton
            // 
            this.ScatterButton.Location = new System.Drawing.Point(12, 12);
            this.ScatterButton.Name = "ScatterButton";
            this.ScatterButton.Size = new System.Drawing.Size(106, 50);
            this.ScatterButton.TabIndex = 0;
            this.ScatterButton.Text = "Scatter Plot";
            this.ScatterButton.UseVisualStyleBackColor = true;
            this.ScatterButton.Click += new System.EventHandler(this.ScatterButton_Click);
            // 
            // BarButton
            // 
            this.BarButton.Location = new System.Drawing.Point(243, 12);
            this.BarButton.Name = "BarButton";
            this.BarButton.Size = new System.Drawing.Size(106, 50);
            this.BarButton.TabIndex = 1;
            this.BarButton.Text = "Bar Chart";
            this.BarButton.UseVisualStyleBackColor = true;
            this.BarButton.Click += new System.EventHandler(this.BarButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(12, 68);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(106, 50);
            this.LineButton.TabIndex = 2;
            this.LineButton.Text = "Line Graph";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // BubbleButton
            // 
            this.BubbleButton.Location = new System.Drawing.Point(243, 68);
            this.BubbleButton.Name = "BubbleButton";
            this.BubbleButton.Size = new System.Drawing.Size(106, 50);
            this.BubbleButton.TabIndex = 3;
            this.BubbleButton.Text = "Bubble Chart";
            this.BubbleButton.UseVisualStyleBackColor = true;
            this.BubbleButton.Click += new System.EventHandler(this.BubbleButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(138, 136);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 171);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BubbleButton);
            this.Controls.Add(this.LineButton);
            this.Controls.Add(this.BarButton);
            this.Controls.Add(this.ScatterButton);
            this.Name = "Form1";
            this.Text = "Aaron\'s Uncharted charts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ScatterButton;
        private System.Windows.Forms.Button BarButton;
        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button BubbleButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

