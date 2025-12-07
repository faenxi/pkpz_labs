using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;

using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.Sequence;


namespace lab13_pkpz
{
    public partial class Form1 : Form
    {
        private const string CULTURE = Culture.English;

        public Form1()
        {
            InitializeComponent();

            txtInputFile.Text = "input.txt";
            txtOutputFile.Text = "output.txt";

            rtbOutput.AppendText("Запустіть Завдання 1.1, 1.2 або 1.3.\n");

            EnsureTestFileExists(txtInputFile.Text);
        }


        private void EnsureTestFileExists(string filename)
        {
            if (!File.Exists(filename))
            {
                string testContent =
                  "Task 1.1: I have forty-two dollars, sixteen euros, and twenty-first book. " +
                  "Today is the ninth of November, temperature is sixty-five degrees Celsius. " +
                  "My contact is one two three four five six seven eight nine zero, email: user@domain.com. " +
                  "Visit http://example.com #best_lab. " +
                  "The distance is five kilometers, and the IP is 192.168.1.1.";

                File.WriteAllText(filename, testContent);
            }
        }

        private string ReadInputFile(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show($"Помилка: Файл '{filename}' не знайдено.", "Файлова помилка");
                return null;
            }
            return File.ReadAllText(filename);
        }

        private void WriteOutputFile(string filename, string content)
        {
            try
            {
                File.WriteAllText(filename, content);
                rtbOutput.AppendText($"\n--- РЕЗУЛЬТАТ ЗБЕРЕЖЕНО У '{filename}' ---\n");
            }
            catch (Exception ex)
            {
                rtbOutput.AppendText($"Помилка запису у файл: {ex.Message}\n");
            }
        }

        private void ProcessRecognition(StringBuilder sb, Dictionary<string, int> counts, string entityName, List<ModelResult> results)
        {
            if (results.Any())
            {
                sb.AppendLine($"\n=== ЗНАЙДЕНО: {entityName} (Кількість: {results.Count}) ===");
                counts.Add(entityName, results.Count);

                foreach (var result in results)
                {
                    string value = result.Resolution != null && result.Resolution.ContainsKey("value") ? (string)result.Resolution["value"] : "N/A";
                    sb.AppendLine($"Текст: {result.Text} -> Значення: {value}");
                }
            }
            else
            {
                counts.Add(entityName, 0);
            }
        }

        private void btnTask1_1_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            string inputFile = txtInputFile.Text;
            string outputFile = "number_" + txtOutputFile.Text;
            string inputText = ReadInputFile(inputFile);

            if (inputText == null) return;
            txtInputContent.Text = inputText;

            StringBuilder outputDetails = new StringBuilder();

            // 1. 
            var results = NumberRecognizer.RecognizeNumber(inputText, CULTURE);

            StringBuilder modifiedText = new StringBuilder(inputText);
            int offset = 0;

            outputDetails.AppendLine("--- ДЕТАЛЬНИЙ ЗВІТ (ЧИСЛА) ---");

            foreach (var result in results)
            {
                string numericValue = (string)result.Resolution["value"];

                outputDetails.AppendLine($"Розпізнаний текст (число): {result.Text}");
                outputDetails.AppendLine($"Початковий індекс у рядку: {result.Start}");
                outputDetails.AppendLine($"Кінцевий індекс у рядку: {result.End}");
                outputDetails.AppendLine($"Розпізнане значення числа: {numericValue}");
                outputDetails.AppendLine();

                int start = result.Start + offset;
                int length = result.Text.Length;

                modifiedText.Remove(start, length);
                modifiedText.Insert(start, numericValue);

                offset += numericValue.Length - length;
            }

            rtbOutput.AppendText(outputDetails.ToString());
            rtbOutput.AppendText("\n--- МОДИФІКОВАНИЙ ТЕКСТ (Замінено слова на цифри) ---\n");
            rtbOutput.AppendText(modifiedText.ToString());

            WriteOutputFile(outputFile, modifiedText.ToString());
        }

        private void btnTask1_2_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            string inputFile = txtInputFile.Text;
            string outputFile = "ordinal_" + txtOutputFile.Text;
            string inputText = ReadInputFile(inputFile);

            if (inputText == null) return;
            txtInputContent.Text = inputText;

            StringBuilder outputDetails = new StringBuilder();

            var results = NumberRecognizer.RecognizeOrdinal(inputText, CULTURE);

            int count = results.Count;

            outputDetails.AppendLine($"Кількість порядкових числівників: {count}");
            outputDetails.AppendLine("------------------------------------");

            foreach (var result in results)
            {
                string numericValue = (string)result.Resolution["value"];

                outputDetails.AppendLine($"Розпізнаний текст: {result.Text,-20} -> Значення: {numericValue}");
            }

            rtbOutput.AppendText(outputDetails.ToString());

            WriteOutputFile(outputFile, outputDetails.ToString());
        }

        private void btnTask1_3_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            string inputFile = txtInputFile.Text;
            string outputFile = "entities_" + txtOutputFile.Text;
            string inputText = ReadInputFile(inputFile);

            if (inputText == null) return;
            txtInputContent.Text = inputText;

            StringBuilder outputDetails = new StringBuilder();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            ProcessRecognition(outputDetails, counts, "Валюта", NumberWithUnitRecognizer.RecognizeCurrency(inputText, CULTURE));
            ProcessRecognition(outputDetails, counts, "Розмір/Вага/Відстань", NumberWithUnitRecognizer.RecognizeDimension(inputText, CULTURE));
            ProcessRecognition(outputDetails, counts, "Температура", NumberWithUnitRecognizer.RecognizeTemperature(inputText, CULTURE));

            ProcessRecognition(outputDetails, counts, "Дата/Час", DateTimeRecognizer.RecognizeDateTime(inputText, CULTURE));

            ProcessRecognition(outputDetails, counts, "Телефон", SequenceRecognizer.RecognizePhoneNumber(inputText, CULTURE));
            ProcessRecognition(outputDetails, counts, "IP-адреса", SequenceRecognizer.RecognizeIpAddress(inputText, CULTURE));
            ProcessRecognition(outputDetails, counts, "Email", SequenceRecognizer.RecognizeEmail(inputText, CULTURE));
            ProcessRecognition(outputDetails, counts, "URL-адреса", SequenceRecognizer.RecognizeURL(inputText, CULTURE));
            ProcessRecognition(outputDetails, counts, "Хеш-тег", SequenceRecognizer.RecognizeHashtag(inputText, CULTURE));

            rtbOutput.AppendText(outputDetails.ToString());
            rtbOutput.AppendText("\n--- ЗАГАЛЬНА КІЛЬКІСТЬ РОЗПІЗНАНИХ ЗНАЧЕНЬ ---\n");

            foreach (var kvp in counts)
            {
                rtbOutput.AppendText($"{kvp.Key}: {kvp.Value}\n");
            }

            WriteOutputFile(outputFile, outputDetails.ToString() + "\n" + rtbOutput.Text);
        }
    }
}

