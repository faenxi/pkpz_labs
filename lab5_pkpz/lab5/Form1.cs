using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public class Computer
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Cpu { get; set; }
            public int RamSizeGB { get; set; }
            public int StorageSizeGB { get; set; }
            public string OperatingSystem { get; set; }
            public bool IsPoweredOn { get; set; }

            public Computer() { }

            public void SaveToFile(string filePath)
            {
                var lines = new string[]
                {
                    Brand,
                    Model,
                    Cpu,
                    RamSizeGB.ToString(),
                    StorageSizeGB.ToString(),
                    OperatingSystem,
                    IsPoweredOn.ToString()
                };
                File.WriteAllLines(filePath, lines, Encoding.UTF8);
            }

            public static Computer LoadFromFile(string filePath)
            {
                var lines = File.ReadAllLines(filePath, Encoding.UTF8);
                return new Computer
                {
                    Brand = lines[0],
                    Model = lines[1],
                    Cpu = lines[2],
                    RamSizeGB = int.Parse(lines[3]),
                    StorageSizeGB = int.Parse(lines[4]),
                    OperatingSystem = lines[5],
                    IsPoweredOn = bool.Parse(lines[6])
                };
            }

            public string GetInfo()
            {
                var info = new StringBuilder();
                info.AppendLine("========== Характеристики комп'ютера ==========");
                info.AppendLine($"Бренд: {Brand}");
                info.AppendLine($"Модель: {Model}");
                info.AppendLine($"Процесор: {Cpu}");
                info.AppendLine($"ОЗП (GB): {RamSizeGB}");
                info.AppendLine($"Накопичувач (GB): {StorageSizeGB}");
                info.AppendLine($"Операційна система: {OperatingSystem}");
                info.AppendLine($"Стан: {(IsPoweredOn ? "Увімкнений" : "Вимкнений")}");
                info.AppendLine("==============================================");
                return info.ToString();
            }
        }

        Computer myComputer = new Computer();
        string filePath = "computer.txt";

        public Form1()
        {
            InitializeComponent();
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            myComputer.Brand = textBoxBrand.Text;
            myComputer.Model = textBoxModel.Text;
            myComputer.Cpu = textBoxCpu.Text;
            myComputer.RamSizeGB = int.TryParse(textBoxRam.Text, out int ram) ? ram : 0;
            myComputer.StorageSizeGB = int.TryParse(textBoxStorage.Text, out int storage) ? storage : 0;
            myComputer.OperatingSystem = textBoxOS.Text;
            myComputer.IsPoweredOn = checkBoxPower.Checked;

            myComputer.SaveToFile(filePath);
            MessageBox.Show("Дані збережено у файл!");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                myComputer = Computer.LoadFromFile(filePath);
                textBoxBrand.Text = myComputer.Brand;
                textBoxModel.Text = myComputer.Model;
                textBoxCpu.Text = myComputer.Cpu;
                textBoxRam.Text = myComputer.RamSizeGB.ToString();
                textBoxStorage.Text = myComputer.StorageSizeGB.ToString();
                textBoxOS.Text = myComputer.OperatingSystem;
                checkBoxPower.Checked = myComputer.IsPoweredOn;

                textBoxResult.Text = myComputer.GetInfo();
            }
            else
            {
                MessageBox.Show("Файл не знайдено!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBrand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
