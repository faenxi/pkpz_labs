using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab4
{
    public partial class Form1 : Form
    {

        double num1, num2;
        string operation;
        public Form1()
        {
            InitializeComponent();
            Log("=== Початок сесії ===");

        }


        private void Form1_Load(object sender, EventArgs e)
        {
                string text = "Harley-Davidson; Black; 12345; CE1234AA; 2018; 2023; 18000\r\nYamaha; Blue; 54321; CE4321BB; 2020; 2024; 9500\r\nHarley-Davidson; Red; 67890; CE5678CC; 2019; 2023; 20000\r\nSuzuki; White; 11223; CE1111DD; 2021; 2025; 11000\r\n";
                File.WriteAllText("inputData.txt", text);
                File.Create("outputData.txt");


                string numbers = "4 6";
                File.WriteAllText("inputDataOperands.txt", numbers);
                File.WriteAllText("SessionLog.txt", "");
                File.WriteAllText("outputCalculationData.txt", "");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("=== Завершення сесії ===\n");
        }
        private void Log(string message)
        {
            File.AppendAllText("SessionLog.txt", $"{DateTime.Now}: {message}\n");
        }

        private void output_Click(object sender, EventArgs e)
        {
            int rowCount = File.ReadAllLines("inputData.txt").Length;
            int colCount = 7;

            string[,] motorcycles = new string[rowCount, colCount];

            using (StreamReader reader = new StreamReader("inputData.txt"))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');

                    for (int j = 0; j < colCount && j < parts.Length; j++)
                    {
                        motorcycles[i, j] = parts[j].Trim();
                    }
                    i++;
                }
            }

            using (StreamWriter writer = new StreamWriter("outputFile.txt"))
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (motorcycles[i, 0] == "Harley-Davidson")
                    {
                        for (int j = 0; j < colCount; j++)
                        {
                            writer.Write(motorcycles[i, j]);
                            if (j < colCount - 1) writer.Write("; ");
                        }
                        writer.WriteLine();
                    }
                }
            }

            textBox1.Text = File.ReadAllText("outputFile.txt");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = File.ReadAllText("SessionLog.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] data = File.ReadAllText("inputDataOperands.txt").Split(' ');
            num1 = double.Parse(data[0]);
            num2 = double.Parse(data[1]);
            double result = 0;

            switch (true)
            {
                case true when radioButton1.Checked:
                    result = num1 + num2;
                    operation = "+";
                    break;

                case true when radioButton2.Checked:
                    result = num1 - num2;
                    operation = "-";
                    break;

                case true when radioButton4.Checked:
                    result = num1 * num2;
                    operation = "*";
                    break;

                case true when radioButton3.Checked:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        operation = "/";
                    }
                    else
                    {
                        MessageBox.Show("Ділення на нуль неможливе!");
                        return;
                    }
                    break;

                case true when radioButton5.Checked:
                    result = Math.Pow(num1, num2);
                    operation = "^";
                    break;

                default:
                    MessageBox.Show("Виберіть арифметичну операцію!");
                    return;
            }

            textBox2.Text = result.ToString();

            Log($"Обчислено: {num1} {operation} {num2} = {result}");

            string resultLine = $"{num1} {operation} {num2}, Результат: {textBox2.Text}";
            File.AppendAllText("outputCalculationData.txt", resultLine + Environment.NewLine);
            Log("Результат експортовано у OutputData.txt");
        }

    }

}
    


