namespace lab9_3
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
            lblExpression = new Label();
            txtExpression = new TextBox();
            btnCheck = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // lblExpression
            // 
            lblExpression.AutoSize = true;
            lblExpression.Location = new Point(34, 45);
            lblExpression.Name = "lblExpression";
            lblExpression.Size = new Size(111, 20);
            lblExpression.TabIndex = 0;
            lblExpression.Text = "Вираз з файлу:";
            // 
            // txtExpression
            // 
            txtExpression.Location = new Point(207, 42);
            txtExpression.Name = "txtExpression";
            txtExpression.Size = new Size(305, 27);
            txtExpression.TabIndex = 1;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(34, 100);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(478, 48);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Запустити Перевірку (Зчитати файл)";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(34, 190);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(478, 135);
            rtbOutput.TabIndex = 3;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnCheck);
            Controls.Add(txtExpression);
            Controls.Add(lblExpression);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblExpression;
        private TextBox txtExpression;
        private Button btnCheck;
        private RichTextBox rtbOutput;
    }
}
