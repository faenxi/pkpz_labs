using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace lab9_1
{
    public partial class Form1 : Form
    {
        private List<int> L1 = new List<int>();
        private List<int> L2 = new List<int>();
        private const string FILENAME = "L1_modified.txt";

        public Form1()
        {
            InitializeComponent();
            rtbOutput.AppendText("Натисніть '1. Згенерувати Списки' для початку.\n");
        }

        private void DisplayList(string title, List<int> list)
        {
            rtbOutput.AppendText($"\n--- {title} (К-сть: {list.Count}) ---\n");
            rtbOutput.AppendText(string.Join(", ", list) + "\n");
        }

        private void InsertIntoSortedList(List<int> list, int item)
        {
            int index = list.BinarySearch(item, Comparer<int>.Create((x, y) => y.CompareTo(x)));

            if (index < 0)
            {
                index = ~index;
            }

            list.Insert(index, item);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            Random rand = new Random();

            L1 = Enumerable.Range(1, 15)
                           .Select(_ => rand.Next(1, 100))
                           .OrderByDescending(x => x)
                           .ToList();

            L2 = Enumerable.Range(1, 8)
                           .Select(_ => rand.Next(1, 100))
                           .ToList();

            DisplayList("Початковий список L1 (впорядкований за спаданням)", L1);
            DisplayList("Початковий список L2 (довільний)", L2);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            if (File.Exists(FILENAME))
            {
                try
                {
                    string content = File.ReadAllText(FILENAME);

                    L1 = content.Split(new[] { ',', ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(s => int.Parse(s))
                                 .ToList();

                    DisplayList($"Список L1 завантажено з файлу {FILENAME}", L1);

                    Random rand = new Random();
                    L2 = Enumerable.Range(1, 8).Select(_ => rand.Next(1, 100)).ToList();
                    DisplayList("Новий список L2 згенеровано", L2);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при зчитуванні файлу: {ex.Message}", "Помилка");
                }
            }
            else
            {
                rtbOutput.AppendText($"Помилка: Файл {FILENAME} не знайдено. Спершу згенеруйте списки.\n");
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (L1.Count == 0 || L2.Count == 0)
            {
                rtbOutput.AppendText("Помилка: Списки L1 або L2 порожні. Спершу згенеруйте їх.\n");
                return;
            }

            foreach (int item in L2)
            {
                InsertIntoSortedList(L1, item);
            }

            DisplayList("МОДИФІКОВАНИЙ СПИСОК L1 (після вставки та впорядкування)", L1);
            rtbOutput.AppendText("\nОБРОБКА ЗАВЕРШЕНА. Тепер можна зберегти результат.\n");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (L1.Count == 0)
            {
                rtbOutput.AppendText("Помилка: Список L1 порожній. Спершу виконайте обробку.\n");
                return;
            }

            try
            {
                string content = "";
                for (int i = 0; i < L1.Count; i++)
                {
                    content += L1[i].ToString().PadRight(4);

                    if ((i + 1) % 8 == 0)
                    {
                        content += Environment.NewLine;
                    }
                }

                File.WriteAllText(FILENAME, content);
                rtbOutput.AppendText($"\nСписок L1 збережено у файл '{FILENAME}'.\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}", "Помилка");
            }
        }
    }
}