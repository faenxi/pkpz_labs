namespace lab9_1
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
            btnGenerate = new Button();
            btnLoad = new Button();
            btnProcess = new Button();
            btnSave = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(38, 44);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(264, 29);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "1. Згенерувати Списки";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(38, 115);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(264, 29);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "2. Завантажити L1 з файлу";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(38, 184);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(264, 29);
            btnProcess.TabIndex = 2;
            btnProcess.Text = "3. Обробка (Вставка L2 в L1)";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(38, 248);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(264, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "4. Зберегти Результат";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(365, 36);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(329, 253);
            rtbOutput.TabIndex = 4;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnSave);
            Controls.Add(btnProcess);
            Controls.Add(btnLoad);
            Controls.Add(btnGenerate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerate;
        private Button btnLoad;
        private Button btnProcess;
        private Button btnSave;
        private RichTextBox rtbOutput;
    }
}
