using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace lab8_1pkpz 
{
    public partial class Form1 : Form
    {
        private List<(string Name, double TotalScore, double TechScore, string Country)> skaterResults
            = new List<(string, double, double, string)>();

        public Form1()
        {
            InitializeComponent();
            rtbOutput.AppendText("Введіть дані фігуриста та натисніть 'Додати Фігуриста'.\n");

            skaterResults.Add(("Мівіна А.", 155.2, 78.0, "UKR"));
            skaterResults.Add(("Васько В.", 140.5, 70.5, "UKR"));
            skaterResults.Add(("Сміт Д.", 170.8, 85.1, "USA"));
            skaterResults.Add(("Вангог Л.", 120.0, 60.0, "CHN"));
        }

        private string DisplayTuple((string Name, double TotalScore, double TechScore, string Country) skater)
        {
            return $"[{skater.Country}] {skater.Name}: Заг. Бал={skater.TotalScore:F2}, Техн. Оцінка={skater.TechScore:F2}";
        }

        private string GetSpecificValue((string Name, double TotalScore, double TechScore, string Country) skater)
        {
            return $"Прізвище: {skater.Name}, Заг. Бал: {skater.TotalScore:F2}";
        }

        private void btnAddSkater_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtScore.Text, out double score) &&
                double.TryParse(txtTechScore.Text, out double techScore) &&
                !string.IsNullOrWhiteSpace(txtName.Text) &&
                !string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                skaterResults.Add((txtName.Text, score, techScore, txtCountry.Text));
                rtbOutput.AppendText($"Додано: {GetSpecificValue(skaterResults.Last())}\n");

                txtName.Clear(); txtScore.Clear(); txtTechScore.Clear(); txtCountry.Clear();
            }
            else
            {
                MessageBox.Show("Перевірте введені дані. Бали мають бути числами.", "Помилка вводу");
            }
        }

        private void btnQualify_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            if (!skaterResults.Any())
            {
                rtbOutput.AppendText("Список фігуристів порожній. Додайте дані.\n");
                return;
            }

            double averageScore = skaterResults.Average(s => s.TotalScore);
            rtbOutput.AppendText($"Середній загальний бал: {averageScore:F2}\n");

            var qualifiedSkaters = skaterResults
                .Where(s => s.TotalScore > averageScore)
                .ToList();

            int qualifiedCount = qualifiedSkaters.Count;
            rtbOutput.AppendText($"\n--- РЕЗУЛЬТАТИ КВАЛІФІКАЦІЇ ---\n");
            rtbOutput.AppendText($"Кількість спортсменів, що пройшли кваліфікацію: {qualifiedCount}\n");

            rtbOutput.AppendText("\nКваліфіковані фігуристи (вивід всіх значень кортежу):\n");
            foreach (var skater in qualifiedSkaters)
            {
                rtbOutput.AppendText(DisplayTuple(skater) + "\n");
            }
        }
    }
}