namespace lab8_1pkpz
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
            label1 = new Label();
            label2 = new Label();
            txtScore = new TextBox();
            label3 = new Label();
            txtTechScore = new TextBox();
            label4 = new Label();
            txtCountry = new TextBox();
            btnAddSkater = new Button();
            btnQualify = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(225, 55);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 62);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 1;
            label1.Text = "Прізвище:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 115);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 3;
            label2.Text = "Загальний Бал:";
            // 
            // txtScore
            // 
            txtScore.Location = new Point(225, 108);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(125, 27);
            txtScore.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 167);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 5;
            label3.Text = "Технічна оцінка:";
            // 
            // txtTechScore
            // 
            txtTechScore.Location = new Point(225, 160);
            txtTechScore.Name = "txtTechScore";
            txtTechScore.Size = new Size(125, 27);
            txtTechScore.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 224);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 7;
            label4.Text = "Країна:";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(225, 217);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(125, 27);
            txtCountry.TabIndex = 6;
            // 
            // btnAddSkater
            // 
            btnAddSkater.Location = new Point(50, 267);
            btnAddSkater.Name = "btnAddSkater";
            btnAddSkater.Size = new Size(300, 29);
            btnAddSkater.TabIndex = 8;
            btnAddSkater.Text = "Додати Фігуриста";
            btnAddSkater.UseVisualStyleBackColor = true;
            btnAddSkater.Click += btnAddSkater_Click;
            // 
            // btnQualify
            // 
            btnQualify.Location = new Point(50, 321);
            btnQualify.Name = "btnQualify";
            btnQualify.Size = new Size(300, 29);
            btnQualify.TabIndex = 9;
            btnQualify.Text = "Провести Кваліфікацію";
            btnQualify.UseVisualStyleBackColor = true;
            btnQualify.Click += btnQualify_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(401, 33);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(320, 333);
            rtbOutput.TabIndex = 10;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnQualify);
            Controls.Add(btnAddSkater);
            Controls.Add(label4);
            Controls.Add(txtCountry);
            Controls.Add(label3);
            Controls.Add(txtTechScore);
            Controls.Add(label2);
            Controls.Add(txtScore);
            Controls.Add(label1);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private Label label2;
        private TextBox txtScore;
        private Label label3;
        private TextBox txtTechScore;
        private Label label4;
        private TextBox txtCountry;
        private Button btnAddSkater;
        private Button btnQualify;
        private RichTextBox rtbOutput;
    }
}
