namespace lab13_pkpz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblInputFile = new Label();
            lblOutputFile = new Label();
            txtInputFile = new TextBox();
            txtOutputFile = new TextBox();
            txtInputContent = new TextBox();
            btnTask1_1 = new Button();
            btnTask1_2 = new Button();
            btnTask1_3 = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // lblInputFile
            // 
            lblInputFile.AutoSize = true;
            lblInputFile.Location = new Point(31, 35);
            lblInputFile.Name = "lblInputFile";
            lblInputFile.Size = new Size(106, 20);
            lblInputFile.TabIndex = 0;
            lblInputFile.Text = "Вхідний файл:";
            // 
            // lblOutputFile
            // 
            lblOutputFile.AutoSize = true;
            lblOutputFile.Location = new Point(31, 101);
            lblOutputFile.Name = "lblOutputFile";
            lblOutputFile.Size = new Size(115, 20);
            lblOutputFile.TabIndex = 1;
            lblOutputFile.Text = "Вихідний файл:";
            // 
            // txtInputFile
            // 
            txtInputFile.Location = new Point(31, 58);
            txtInputFile.Name = "txtInputFile";
            txtInputFile.Size = new Size(331, 27);
            txtInputFile.TabIndex = 2;
            // 
            // txtOutputFile
            // 
            txtOutputFile.Location = new Point(31, 124);
            txtOutputFile.Name = "txtOutputFile";
            txtOutputFile.Size = new Size(331, 27);
            txtOutputFile.TabIndex = 3;
            // 
            // txtInputContent
            // 
            txtInputContent.Location = new Point(31, 157);
            txtInputContent.Multiline = true;
            txtInputContent.Name = "txtInputContent";
            txtInputContent.Size = new Size(640, 81);
            txtInputContent.TabIndex = 4;
            // 
            // btnTask1_1
            // 
            btnTask1_1.Location = new Point(31, 258);
            btnTask1_1.Name = "btnTask1_1";
            btnTask1_1.Size = new Size(205, 38);
            btnTask1_1.TabIndex = 5;
            btnTask1_1.Text = "завд1";
            btnTask1_1.UseVisualStyleBackColor = true;
            btnTask1_1.Click += btnTask1_1_Click;
            // 
            // btnTask1_2
            // 
            btnTask1_2.Location = new Point(252, 258);
            btnTask1_2.Name = "btnTask1_2";
            btnTask1_2.Size = new Size(197, 38);
            btnTask1_2.TabIndex = 6;
            btnTask1_2.Text = "завд2";
            btnTask1_2.UseVisualStyleBackColor = true;
            btnTask1_2.Click += btnTask1_2_Click;
            // 
            // btnTask1_3
            // 
            btnTask1_3.Location = new Point(475, 258);
            btnTask1_3.Name = "btnTask1_3";
            btnTask1_3.Size = new Size(196, 38);
            btnTask1_3.TabIndex = 7;
            btnTask1_3.Text = "завд3";
            btnTask1_3.UseVisualStyleBackColor = true;
            btnTask1_3.Click += btnTask1_3_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(31, 302);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(640, 136);
            rtbOutput.TabIndex = 8;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnTask1_3);
            Controls.Add(btnTask1_2);
            Controls.Add(btnTask1_1);
            Controls.Add(txtInputContent);
            Controls.Add(txtOutputFile);
            Controls.Add(txtInputFile);
            Controls.Add(lblOutputFile);
            Controls.Add(lblInputFile);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInputFile;
        private Label lblOutputFile;
        private TextBox txtInputFile;
        private TextBox txtOutputFile;
        private TextBox txtInputContent;
        private Button btnTask1_1;
        private Button btnTask1_2;
        private Button btnTask1_3;
        private RichTextBox rtbOutput;
    }
}
