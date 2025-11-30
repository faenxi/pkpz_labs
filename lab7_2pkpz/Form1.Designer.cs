namespace lab7_2pkpz
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
            btnProcess = new Button();
            btnCreateArray = new Button();
            lblN = new Label();
            txtN = new TextBox();
            rtbOutput = new RichTextBox();
            pnlInput = new Panel();
            SuspendLayout();
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(361, 207);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(216, 58);
            btnProcess.TabIndex = 0;
            btnProcess.Text = "Запустити Обробку";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnCreateArray
            // 
            btnCreateArray.Location = new Point(59, 207);
            btnCreateArray.Name = "btnCreateArray";
            btnCreateArray.Size = new Size(249, 58);
            btnCreateArray.TabIndex = 1;
            btnCreateArray.Text = "Створити Масив (Ввід N)";
            btnCreateArray.UseVisualStyleBackColor = true;
            btnCreateArray.Click += btnCreateArray_Click;
            // 
            // lblN
            // 
            lblN.AutoSize = true;
            lblN.Location = new Point(59, 91);
            lblN.Name = "lblN";
            lblN.Size = new Size(165, 20);
            lblN.TabIndex = 2;
            lblN.Text = "Кількість студентів (N):";
            // 
            // txtN
            // 
            txtN.Location = new Point(59, 162);
            txtN.Name = "txtN";
            txtN.Size = new Size(518, 27);
            txtN.TabIndex = 3;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(59, 286);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(404, 140);
            rtbOutput.TabIndex = 4;
            rtbOutput.Text = "";
            // 
            // pnlInput
            // 
            pnlInput.Location = new Point(506, 286);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(240, 136);
            pnlInput.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlInput);
            Controls.Add(rtbOutput);
            Controls.Add(txtN);
            Controls.Add(lblN);
            Controls.Add(btnCreateArray);
            Controls.Add(btnProcess);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProcess;
        private Button btnCreateArray;
        private Label lblN;
        private TextBox txtN;
        private RichTextBox rtbOutput;
        private Panel pnlInput;
    }
}
