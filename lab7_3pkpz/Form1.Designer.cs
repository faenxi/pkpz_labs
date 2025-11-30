namespace lab7_3pkpz
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
            label1 = new Label();
            txtCallSign = new TextBox();
            txtFrequency = new TextBox();
            label2 = new Label();
            txtDate = new TextBox();
            label3 = new Label();
            txtStartTime = new TextBox();
            label4 = new Label();
            txtEndTime = new TextBox();
            label5 = new Label();
            txtGroupCount = new TextBox();
            label6 = new Label();
            txtMonth = new TextBox();
            label7 = new Label();
            txtQueryDate = new TextBox();
            label8 = new Label();
            txtQueryStartTime = new TextBox();
            label9 = new Label();
            txtQueryEndTime = new TextBox();
            label10 = new Label();
            btnAddSession = new Button();
            btnTask1 = new Button();
            btnTask2 = new Button();
            btnTask3 = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 0;
            label1.Text = "Позивний:";
            // 
            // txtCallSign
            // 
            txtCallSign.Location = new Point(275, 20);
            txtCallSign.Name = "txtCallSign";
            txtCallSign.Size = new Size(125, 27);
            txtCallSign.TabIndex = 1;
            // 
            // txtFrequency
            // 
            txtFrequency.Location = new Point(275, 53);
            txtFrequency.Name = "txtFrequency";
            txtFrequency.Size = new Size(125, 27);
            txtFrequency.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 56);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 2;
            label2.Text = "Частота:";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(275, 86);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(125, 27);
            txtDate.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 89);
            label3.Name = "label3";
            label3.Size = new Size(186, 20);
            label3.TabIndex = 4;
            label3.Text = "Дата сеансу (ДДММРРРР):";
            // 
            // txtStartTime
            // 
            txtStartTime.Location = new Point(275, 119);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.Size = new Size(125, 27);
            txtStartTime.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 122);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 6;
            label4.Text = "Початок (ГГ:ХХ:СС):";
            // 
            // txtEndTime
            // 
            txtEndTime.Location = new Point(275, 152);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.Size = new Size(125, 27);
            txtEndTime.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 155);
            label5.Name = "label5";
            label5.Size = new Size(160, 20);
            label5.TabIndex = 8;
            label5.Text = "Закінчення (ГГ:ХХ:СС):";
            // 
            // txtGroupCount
            // 
            txtGroupCount.Location = new Point(275, 185);
            txtGroupCount.Name = "txtGroupCount";
            txtGroupCount.Size = new Size(125, 27);
            txtGroupCount.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 188);
            label6.Name = "label6";
            label6.Size = new Size(147, 20);
            label6.TabIndex = 10;
            label6.Text = "К-сть груп (5 симв.):";
            // 
            // txtMonth
            // 
            txtMonth.Location = new Point(275, 269);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(125, 27);
            txtMonth.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 272);
            label7.Name = "label7";
            label7.Size = new Size(110, 20);
            label7.TabIndex = 12;
            label7.Text = "Номер Місяця";
            // 
            // txtQueryDate
            // 
            txtQueryDate.Location = new Point(275, 302);
            txtQueryDate.Name = "txtQueryDate";
            txtQueryDate.Size = new Size(125, 27);
            txtQueryDate.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 305);
            label8.Name = "label8";
            label8.Size = new Size(186, 20);
            label8.TabIndex = 14;
            label8.Text = "Дата запиту (ДДММРРРР):";
            // 
            // txtQueryStartTime
            // 
            txtQueryStartTime.Location = new Point(275, 335);
            txtQueryStartTime.Name = "txtQueryStartTime";
            txtQueryStartTime.Size = new Size(125, 27);
            txtQueryStartTime.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 338);
            label9.Name = "label9";
            label9.Size = new Size(165, 20);
            label9.TabIndex = 16;
            label9.Text = "Час початку (ГГ:ХХ:СС):";
            // 
            // txtQueryEndTime
            // 
            txtQueryEndTime.Location = new Point(275, 368);
            txtQueryEndTime.Name = "txtQueryEndTime";
            txtQueryEndTime.Size = new Size(125, 27);
            txtQueryEndTime.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 371);
            label10.Name = "label10";
            label10.Size = new Size(148, 20);
            label10.TabIndex = 18;
            label10.Text = "Час кінця (ГГ:ХХ:СС):";
            // 
            // btnAddSession
            // 
            btnAddSession.Location = new Point(23, 227);
            btnAddSession.Name = "btnAddSession";
            btnAddSession.Size = new Size(169, 29);
            btnAddSession.TabIndex = 20;
            btnAddSession.Text = "Додати Сеанс";
            btnAddSession.UseVisualStyleBackColor = true;
            btnAddSession.Click += btnAddSession_Click;
            // 
            // btnTask1
            // 
            btnTask1.Location = new Point(23, 409);
            btnTask1.Name = "btnTask1";
            btnTask1.Size = new Size(94, 29);
            btnTask1.TabIndex = 21;
            btnTask1.Text = "Швидкість";
            btnTask1.UseVisualStyleBackColor = true;
            btnTask1.Click += btnTask1_Click;
            // 
            // btnTask2
            // 
            btnTask2.Location = new Point(143, 409);
            btnTask2.Name = "btnTask2";
            btnTask2.Size = new Size(131, 29);
            btnTask2.TabIndex = 22;
            btnTask2.Text = "За Інтервалом";
            btnTask2.UseVisualStyleBackColor = true;
            btnTask2.Click += btnTask2_Click;
            // 
            // btnTask3
            // 
            btnTask3.Location = new Point(300, 409);
            btnTask3.Name = "btnTask3";
            btnTask3.Size = new Size(131, 29);
            btnTask3.TabIndex = 23;
            btnTask3.Text = "Місячний Звіт";
            btnTask3.UseVisualStyleBackColor = true;
            btnTask3.Click += btnTask3_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(455, 114);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(290, 324);
            rtbOutput.TabIndex = 24;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnTask3);
            Controls.Add(btnTask2);
            Controls.Add(btnTask1);
            Controls.Add(btnAddSession);
            Controls.Add(txtQueryEndTime);
            Controls.Add(label10);
            Controls.Add(txtQueryStartTime);
            Controls.Add(label9);
            Controls.Add(txtQueryDate);
            Controls.Add(label8);
            Controls.Add(txtMonth);
            Controls.Add(label7);
            Controls.Add(txtGroupCount);
            Controls.Add(label6);
            Controls.Add(txtEndTime);
            Controls.Add(label5);
            Controls.Add(txtStartTime);
            Controls.Add(label4);
            Controls.Add(txtDate);
            Controls.Add(label3);
            Controls.Add(txtFrequency);
            Controls.Add(label2);
            Controls.Add(txtCallSign);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCallSign;
        private TextBox txtFrequency;
        private Label label2;
        private TextBox txtDate;
        private Label label3;
        private TextBox txtStartTime;
        private Label label4;
        private TextBox txtEndTime;
        private Label label5;
        private TextBox txtGroupCount;
        private Label label6;
        private TextBox txtMonth;
        private Label label7;
        private TextBox txtQueryDate;
        private Label label8;
        private TextBox txtQueryStartTime;
        private Label label9;
        private TextBox txtQueryEndTime;
        private Label label10;
        private Button btnAddSession;
        private Button btnTask1;
        private Button btnTask2;
        private Button btnTask3;
        private RichTextBox rtbOutput;
    }
}
