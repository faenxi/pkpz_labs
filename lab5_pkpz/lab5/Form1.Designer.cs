namespace lab5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.textBoxOS = new System.Windows.Forms.TextBox();
            this.textBoxStorage = new System.Windows.Forms.TextBox();
            this.textBoxRam = new System.Windows.Forms.TextBox();
            this.textBoxCpu = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.checkBoxPower = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(40, 44);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(100, 22);
            this.textBoxBrand.TabIndex = 0;
            this.textBoxBrand.Text = "brand";
            this.textBoxBrand.TextChanged += new System.EventHandler(this.textBoxBrand_TextChanged);
            // 
            // textBoxOS
            // 
            this.textBoxOS.CausesValidation = false;
            this.textBoxOS.Location = new System.Drawing.Point(635, 44);
            this.textBoxOS.Name = "textBoxOS";
            this.textBoxOS.Size = new System.Drawing.Size(100, 22);
            this.textBoxOS.TabIndex = 1;
            this.textBoxOS.Text = "os";
            // 
            // textBoxStorage
            // 
            this.textBoxStorage.Location = new System.Drawing.Point(529, 44);
            this.textBoxStorage.Name = "textBoxStorage";
            this.textBoxStorage.Size = new System.Drawing.Size(100, 22);
            this.textBoxStorage.TabIndex = 2;
            this.textBoxStorage.Text = "storage";
            // 
            // textBoxRam
            // 
            this.textBoxRam.Location = new System.Drawing.Point(413, 44);
            this.textBoxRam.Name = "textBoxRam";
            this.textBoxRam.Size = new System.Drawing.Size(100, 22);
            this.textBoxRam.TabIndex = 3;
            this.textBoxRam.Text = "ram";
            // 
            // textBoxCpu
            // 
            this.textBoxCpu.Location = new System.Drawing.Point(291, 44);
            this.textBoxCpu.Name = "textBoxCpu";
            this.textBoxCpu.Size = new System.Drawing.Size(100, 22);
            this.textBoxCpu.TabIndex = 4;
            this.textBoxCpu.Text = "cpu";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(167, 44);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(100, 22);
            this.textBoxModel.TabIndex = 5;
            this.textBoxModel.Text = "model";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(389, 197);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(298, 98);
            this.textBoxResult.TabIndex = 6;
            // 
            // checkBoxPower
            // 
            this.checkBoxPower.AutoSize = true;
            this.checkBoxPower.Location = new System.Drawing.Point(45, 117);
            this.checkBoxPower.Name = "checkBoxPower";
            this.checkBoxPower.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxPower.Size = new System.Drawing.Size(67, 20);
            this.checkBoxPower.TabIndex = 7;
            this.checkBoxPower.Text = "Power";
            this.checkBoxPower.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(192, 197);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(192, 259);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 9;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(783, 347);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkBoxPower);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.textBoxCpu);
            this.Controls.Add(this.textBoxRam);
            this.Controls.Add(this.textBoxStorage);
            this.Controls.Add(this.textBoxOS);
            this.Controls.Add(this.textBoxBrand);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxOS;
        private System.Windows.Forms.TextBox textBoxStorage;
        private System.Windows.Forms.TextBox textBoxRam;
        private System.Windows.Forms.TextBox textBoxCpu;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.CheckBox checkBoxPower;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
    }
}

