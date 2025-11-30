using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;


namespace lab8_3pkpz
{
    public partial class Form1 : Form
    {
        private bool isRunning = true;

        public Form1()
        {
            InitializeComponent();
            rtbOutput.AppendText("Додаток 'Розклад'. Введіть номер дня (1-7) і натисніть кнопку.\nВведіть 0, щоб завершити роботу.\n");
        }


        public enum DayOfWeekEnum
        {
            Вихід = 0,
            Понеділок = 1,
            Вівторок = 2,
            Середа = 3,
            Четвер = 4,
            Пятниця = 5,
            Субота = 6,
            Неділя = 7
        }

        private void btnProcessDay_Click(object sender, EventArgs e)
        {
            rtbOutput.AppendText("\n--------------------------\n");

            if (!isRunning)
            {
                rtbOutput.AppendText("Робота програми завершена. Перезапустіть додаток, щоб почати знову.\n");
                return;
            }

            if (!int.TryParse(txtDayNumber.Text, out int dayNumber))
            {
                rtbOutput.AppendText("Помилка: Введіть число від 0 до 7.\n");
                return;
            }

            if (dayNumber == (int)DayOfWeekEnum.Вихід)
            {
                isRunning = false;
                rtbOutput.AppendText("Обрано 0. Завершення роботи програми.\n");
                btnProcessDay.Enabled = false;
                return;
            }

            if (dayNumber < 1 || dayNumber > 7)
            {
                rtbOutput.AppendText("Помилка: Введіть число від 1 до 7.\n");
                return;
            }

            DayOfWeekEnum day = (DayOfWeekEnum)dayNumber;

            string result = $"День: {day.ToString()} ({dayNumber}). Розклад:\n";

            switch (day)
            {
                case DayOfWeekEnum.Понеділок:
                    result += "Розклад 1 – Понеділок (Математика – 4 уроки, Інформатика – 2 уроки)";
                    break;
                case DayOfWeekEnum.Вівторок:
                    result += "Розклад 2 – Вівторок (Мова – 4 уроки, Література – 2 уроки)";
                    break;
                case DayOfWeekEnum.Середа:
                    result += "Розклад 3 – Середа (Біологія – 3 уроки, Хімія – 3 уроки)";
                    break;
                case DayOfWeekEnum.Четвер:
                    result += "Розклад 4 – Четвер (Історія – 3 уроки, Географія – 3 уроки)";
                    break;
                case DayOfWeekEnum.Пятниця:
                    result += "Розклад 5 – П'ятниця (Фізика – 3 уроки, Математика – 2 уроки)";
                    break;
                case DayOfWeekEnum.Субота:
                    result += "Розклад 6 – Субота (Спортивні гуртки – 4 уроки)";
                    break;
                case DayOfWeekEnum.Неділя:
                    result += "Розклад 7 – Неділя (Вихідний день)";
                    break;
                default:
                    result += "Невідома помилка.";
                    break;
            }

            rtbOutput.AppendText(result + "\n");
            txtDayNumber.Clear();
        }
    }
}