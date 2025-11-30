namespace lab6_3pkpz
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
            lblSpecies = new Label();
            lblHeight = new Label();
            lblPrice = new Label();
            txtName = new TextBox();
            txtHeight = new TextBox();
            txtPrice = new TextBox();
            btnAdd = new Button();
            btnSortPrice = new Button();
            btnSortHeightPrice = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(27, 33);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(35, 20);
            lblSpecies.TabIndex = 0;
            lblSpecies.Text = "Вид";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new Point(27, 86);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(57, 20);
            lblHeight.TabIndex = 1;
            lblHeight.Text = "Висота";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(27, 140);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Ціна";
            // 
            // txtName
            // 
            txtName.Location = new Point(179, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(437, 27);
            txtName.TabIndex = 3;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(178, 83);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(438, 27);
            txtHeight.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(178, 140);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(438, 27);
            txtPrice.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 228);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(155, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Додати дерево";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSortPrice
            // 
            btnSortPrice.Location = new Point(188, 228);
            btnSortPrice.Name = "btnSortPrice";
            btnSortPrice.Size = new Size(226, 29);
            btnSortPrice.TabIndex = 7;
            btnSortPrice.Text = "Сортувати за ціною";
            btnSortPrice.UseVisualStyleBackColor = true;
            btnSortPrice.Click += btnSortPrice_Click;
            // 
            // btnSortHeightPrice
            // 
            btnSortHeightPrice.Location = new Point(420, 228);
            btnSortHeightPrice.Name = "btnSortHeightPrice";
            btnSortHeightPrice.Size = new Size(224, 29);
            btnSortHeightPrice.TabIndex = 8;
            btnSortHeightPrice.Text = "Сортувати за висотою/ціною";
            btnSortHeightPrice.UseVisualStyleBackColor = true;
            btnSortHeightPrice.Click += btnSortHeightPrice_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(27, 273);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(617, 120);
            rtbOutput.TabIndex = 9;
            rtbOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbOutput);
            Controls.Add(btnSortHeightPrice);
            Controls.Add(btnSortPrice);
            Controls.Add(btnAdd);
            Controls.Add(txtPrice);
            Controls.Add(txtHeight);
            Controls.Add(txtName);
            Controls.Add(lblPrice);
            Controls.Add(lblHeight);
            Controls.Add(lblSpecies);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSpecies;
        private Label lblHeight;
        private Label lblPrice;
        private TextBox txtName;
        private TextBox txtHeight;
        private TextBox txtPrice;
        private Button btnAdd;
        private Button btnSortPrice;
        private Button btnSortHeightPrice;
        private RichTextBox rtbOutput;
    }
}
