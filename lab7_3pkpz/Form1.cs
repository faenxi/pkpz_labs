using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections;

namespace lab7_3pkpz
{
    public partial class Form1 : Form
    {
        private List<RadioSession> sessions = new List<RadioSession>();

        public Form1()
        {
            InitializeComponent();
            rtbOutput.AppendText("Введіть дані сеансу та натисніть 'Додати Сеанс'.\n");

            sessions.Add(new RadioSession { CallSign = "ABC01", Frequency = 100.1, Date = "01102025", StartTime = "10:00:00", EndTime = "10:05:00", GroupCount = "A1234" });
            sessions.Add(new RadioSession { CallSign = "XYZ02", Frequency = 98.5, Date = "01102025", StartTime = "11:30:00", EndTime = "11:30:30", GroupCount = "B5678" });
            sessions.Add(new RadioSession { CallSign = "RTY03", Frequency = 102.7, Date = "15092025", StartTime = "14:00:00", EndTime = "14:10:00", GroupCount = "C9012" });
            sessions.Add(new RadioSession { CallSign = "DPL04", Frequency = 100.1, Date = "15092025", StartTime = "14:05:00", EndTime = "14:05:05", GroupCount = "D3456" });
        }

        public struct RadioSession
        {
            public string CallSign;
            public double Frequency;
            public string Date;
            public string StartTime;
            public string EndTime;
            public string GroupCount;

            public DateTime FullStartTime
            {
                get { return DateTime.ParseExact(Date + StartTime, "ddMMyyyyHH:mm:ss", null); }
            }

            public DateTime FullEndTime
            {
                get { return DateTime.ParseExact(Date + EndTime, "ddMMyyyyHH:mm:ss", null); }
            }

            public double GetDurationInSeconds()
            {
                return (FullEndTime - FullStartTime).TotalSeconds;
            }

            public double GetDurationInMinutes()
            {
                return (FullEndTime - FullStartTime).TotalMinutes;
            }
        }

        public static class Validator
        {
            public const string DatePattern = @"^\d{8}$";
            public const string TimePattern = @"^\d{2}:\d{2}:\d{2}$";

            public static bool IsValidSession(RadioSession session)
            {
                if (!Regex.IsMatch(session.Date, DatePattern) ||
                    !Regex.IsMatch(session.StartTime, TimePattern) ||
                    !Regex.IsMatch(session.EndTime, TimePattern))
                {
                    return false;
                }

                if (session.GroupCount.Length != 5)
                {
                    return false;
                }

                try
                {
                    if (session.FullStartTime >= session.FullEndTime)
                    {
                        return false;
                    }
                }
                catch (FormatException)
                {
                    return false;
                }

                return true;
            }
        }

        private void DisplayOutput(string title, IEnumerable<string> results)
        {
            rtbOutput.AppendText($"\n--- {title} ---\n");
            if (results == null || !results.Any())
            {
                rtbOutput.AppendText("Не знайдено записів, що відповідають критеріям.\n");
                return;
            }
            foreach (var item in results)
            {
                rtbOutput.AppendText(item + "\n");
            }
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            RadioSession newSession = new RadioSession
            {
                CallSign = txtCallSign.Text,
                Frequency = double.TryParse(txtFrequency.Text, out double f) ? f : 0,
                Date = txtDate.Text,
                StartTime = txtStartTime.Text,
                EndTime = txtEndTime.Text,
                GroupCount = txtGroupCount.Text
            };

            if (Validator.IsValidSession(newSession))
            {
                sessions.Add(newSession);
                rtbOutput.AppendText($"Сеанс {newSession.CallSign} від {newSession.Date} успішно додано. Всього сеансів: {sessions.Count}.\n");

                txtCallSign.Clear(); txtFrequency.Clear(); txtDate.Clear();
                txtStartTime.Clear();