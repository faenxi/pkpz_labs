using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace lab7_2pkpz
{
    public partial class Form1 : Form
    {
        private STUDENT[] studArray = Array.Empty<STUDENT>();
        private int arraySize = 0;

        public Form1()
        {
            InitializeComponent();
            rtbOutput.AppendText("Введіть кількість студентів (N) для створення масиву.\n");
        }


        public struct STUDENT
        {
            public string NAME;
            public int GROUP;
            public int[] SES; 

            public double GetAverageGrade()
            {
                return SES.Average();
            }
        }


        private void btnCreateArray_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtN.Text, out arraySize) && arraySize > 0)
            {
                studArray = new STUDENT[arraySize];

                rtbOutput.Clear();
                rtbOutput.AppendText($"Масив на {arraySize} студентів успішно створено.\n\n");

                STUDENT[] initialData =
                {
                    new STUDENT { NAME = "Іванов А.А.", GROUP = 201, SES = new int[] {5, 5, 4, 5, 5} },
                    new STUDENT { NAME = "Петренко В.В.", GROUP = 101, SES = new int[] {3, 4, 4, 3, 3} },
                    new STUDENT { NAME = "Сидорова О.М.", GROUP = 201, SES = new int[] {5, 5, 5, 5, 5} },
                    new STUDENT { NAME = "Ковальчук Т.С.", GROUP = 105, SES = new int[] {4, 4, 4, 4, 4} }
                };

                int count = Math.Min(arraySize, initialData.Length);
                Array.Copy(initialData, studArray, count);

                rtbOutput.AppendText($"Масив заповнено фіктивними даними для {count} студентів. Натисніть 'Запустити Обробку'.\n");
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректне число N (>0).");
            }
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (studArray == null || studArray.Length == 0)
            {
                rtbOutput.AppendText("Спочатку створіть масив (Введіть N).\n");
                return;
            }

            SortByGroup();
            rtbOutput.AppendText("\n--- СОРТУВАННЯ ЗА ГРУПОЮ ВИКОНАНО ---\n");

            DisplayFilteredStudents();
        }

        private void SortByGroup()
        {
            Array.Sort(studArray, (s1, s2) => s1.GROUP.CompareTo(s2.GROUP));
        }

        private void DisplayFilteredStudents()
        {
            var filteredStudents = studArray.Where(s => s.GetAverageGrade() > 4.0).ToList();

            rtbOutput.AppendText("\n--- СТУДЕНТИ ІЗ СЕРЕДНІМ БАЛОМ > 4.0 ---\n");

            if (filteredStudents.Any())
            {
                foreach (var student in filteredStudents)
                {
                    rtbOutput.AppendText($"Прізвище: {student.NAME}, Група: {student.GROUP}\n");
                }
            }
            else
            {
                rtbOutput.AppendText("Студентів із середнім балом більшим за 4.0 не знайдено.\n");
            }
        }
    }
}