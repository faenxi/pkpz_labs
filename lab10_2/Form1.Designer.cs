namespace lab10_2
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
            btnGenerateMatrices = new Button();
            rtbIncidence = new RichTextBox();
            rtbAdjacency = new RichTextBox();
            SuspendLayout();
            // 
            // btnGenerateMatrices
            // 
            btnGenerateMatrices.Location = new Point(103, 45);
            btnGenerateMatrices.Name = "btnGenerateMatrices";
            btnGenerateMatrices.Size = new Size(600, 56);
            btnGenerateMatrices.TabIndex = 0;
            btnGenerateMatrices.Text = "Створити та Вивести Матриці";
            btnGenerateMatrices.UseVisualStyleBackColor = true;
            btnGenerateMatrices.Click += btnGenerateMatrices_Click;
            // 
            // rtbIncidence
            // 
            rtbIncidence.Location = new Point(391, 130);
            rtbIncidence.Name = "rtbIncidence";
            rtbIncidence.Size = new Size(366, 293);
            rtbIncidence.TabIndex = 1;
            rtbIncidence.Text = "";
            // 
            // rtbAdjacency
            // 
            rtbAdjacency.Location = new Point(57, 130);
            rtbAdjacency.Name = "rtbAdjacency";
            rtbAdjacency.Size = new Size(315, 293);
            rtbAdjacency.TabIndex = 2;
            rtbAdjacency.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbAdjacency);
            Controls.Add(rtbIncidence);
            Controls.Add(btnGenerateMatrices);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerateMatrices;
        private RichTextBox rtbIncidence;
        private RichTextBox rtbAdjacency;
    }
}
