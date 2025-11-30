namespace lab5_2pkpz
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
            txtName = new TextBox();
            txtAge = new TextBox();
            txtDepartment = new TextBox();
            txtSpecificField = new TextBox();
            lblName = new Label();
            lblAge = new Label();
            lblDepartment = new Label();
            lblSpecificField = new Label();
            rbProfessor = new RadioButton();
            rbDotsent = new RadioButton();
            btnRun = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(235, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(235, 91);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(125, 27);
            txtAge.TabIndex = 1;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(235, 144);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(125, 27);
            txtDepartment.TabIndex = 2;
            // 
            // txtSpecificField
            // 
            txtSpecificField.Location = new Point(235, 196);
            txtSpecificField.Name = "txtSpecificField";
            txtSpecificField.Size = new Size(125, 27);
            txtSpecificField.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(47, 50);
            lblName.Name = "lblName";
            lblName.Size = new Size(32, 20);
            lblName.TabIndex = 4;
            lblName.Text = "Імя";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(47, 98);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(29, 20);
            lblAge.TabIndex = 5;
            lblAge.Text = "Вік";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(47, 144);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(50, 20);
            lblDepartment.TabIndex = 6;
            lblDepartment.Text = "Відділ";
            // 
            // lblSpecificField
            // 
            lblSpecificField.AutoSize = true;
            lblSpecificField.Location = new Point(47, 199);
            lblSpecificField.Name = "lblSpecificField";
            lblSpecificField.Size = new Size(89, 20);
            lblSpecificField.TabIndex = 7;
            lblSpecificField.Text = "Спеціальне";
            // 
            // rbProfessor
            // 
            rbProfessor.AutoSize = true;
            rbProfessor.Location = new Point(99, 267);
            rbProfessor.Name = "rbProfessor";
            rbProfessor.Size = new Size(100, 24);
            rbProfessor.TabIndex = 8;
            rbProfessor.TabStop = true;
            rbProfessor.Text = "професор";
            rbProfessor.UseVisualStyleBackColor = true;
            // 
            // rbDotsent
            // 
            rbDotsent.AutoSize = true;
            rbDotsent.Location = new Point(311, 267);
            rbDotsent.Name = "rbDotsent";
            rbDotsent.Size = new Size(79, 24);
            rbDotsent.TabIndex = 9;
            rbDotsent.TabStop = true;
            rbDotsent.Text = "доцент";
            rbDotsent.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(47, 314);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(195, 40);
            btnRun.TabIndex = 10;
            btnRun.Text = "do";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(325, 314);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(292, 129);
            rtbOutput.TabIndex = 11;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnRun);
            Controls.Add(rbDotsent);
            Controls.Add(rbProfessor);
            Controls.Add(lblSpecificField);
            Controls.Add(lblDepartment);
            Controls.Add(lblAge);
            Controls.Add(lblName);
            Controls.Add(txtSpecificField);
            Controls.Add(txtDepartment);
            Controls.Add(txtAge);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtAge;
        private TextBox txtDepartment;
        private TextBox txtSpecificField;
        private Label lblName;
        private Label lblAge;
        private Label lblDepartment;
        private Label lblSpecificField;
        private RadioButton rbProfessor;
        private RadioButton rbDotsent;
        private Button btnRun;
        private RichTextBox rtbOutput;
    }
}
