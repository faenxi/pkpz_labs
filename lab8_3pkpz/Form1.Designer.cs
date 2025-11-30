namespace lab8_3pkpz
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
            lblDayInput = new Label();
            txtDayNumber = new TextBox();
            btnProcessDay = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // lblDayInput
            // 
            lblDayInput.AutoSize = true;
            lblDayInput.Location = new Point(59, 23);
            lblDayInput.Name = "lblDayInput";
            lblDayInput.Size = new Size(178, 20);
            lblDayInput.TabIndex = 0;
            lblDayInput.Text = "Введіть номер дня (1-7):";
            // 
            // txtDayNumber
            // 
            txtDayNumber.Location = new Point(59, 78);
            txtDayNumber.Name = "txtDayNumber";
            txtDayNumber.Size = new Size(223, 27);
            txtDayNumber.TabIndex = 1;
            // 
            // btnProcessDay
            // 
            btnProcessDay.Location = new Point(59, 132);
            btnProcessDay.Name = "btnProcessDay";
            btnProcessDay.Size = new Size(661, 42);
            btnProcessDay.TabIndex = 2;
            btnProcessDay.Text = "Показати Розклад";
            btnProcessDay.UseVisualStyleBackColor = true;
            btnProcessDay.Click += btnProcessDay_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(59, 199);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(661, 165);
            rtbOutput.TabIndex = 3;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnProcessDay);
            Controls.Add(txtDayNumber);
            Controls.Add(lblDayInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDayInput;
        private TextBox txtDayNumber;
        private Button btnProcessDay;
        private RichTextBox rtbOutput;
    }
}
