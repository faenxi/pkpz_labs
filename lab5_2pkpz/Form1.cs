using System;
using System.Windows.Forms;



namespace lab5_2pkpz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rbProfessor.Checked = true;
            lblSpecificField.Text = "Кількість публікацій:";
        }

 

        public interface IVykladach
        {
            string CalculateWorkload(int hours);

            string ConductLecture(string subject);
        }

        public interface IZVO
        {
            bool GetAccreditation(int level);

            string AcceptStudent(string studentName);
        }


        public abstract class Vykladach
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Department { get; set; }

            public Vykladach(string name, int age, string department)
            {
                Name = name;
                Age = age;
                Department = department;
            }

            public string DisplayInfo()
            {
                return $"Ім'я: {Name}, Вік: {Age}, Кафедра: {Department}";
            }
        }


        public class Professor : Vykladach, IVykladach, IZVO
        {
            public int PublicationCount { get; set; }

            public Professor(string name, int age, string department, int pubCount)
                : base(name, age, department)
            {
                PublicationCount = pubCount;
            }

            public string CalculateWorkload(int hours)
            {
                return $"{Name} (Професор): Розраховане навантаження: {hours * 1.5} годин (враховано дослідження).";
            }

            public string ConductLecture(string subject)
            {
                return $"{Name} читає поглиблену лекцію з **{subject}**.";
            }

            public bool GetAccreditation(int level)
            {
                return level > 3;
            }

            public string AcceptStudent(string studentName)
            {
                return $"Професор {Name} прийняв **{studentName}** на програму PhD.";
            }

            public string LeadResearchProject(string projectTitle)
            {
                return $"Унікальний 1: {Name} керує проєктом: *{projectTitle}*.";
            }

            public string ServeOnAcademicCouncil()
            {
                return $"Унікальний 2: {Name} є членом Вченої Ради.";
            }
        }

        public class Dotsent : Vykladach, IVykladach, IZVO
        {
            public int CourseCount { get; set; }

            public Dotsent(string name, int age, string department, int courseCount)
                : base(name, age, department)
            {
                CourseCount = courseCount;
            }

            public string CalculateWorkload(int hours)
            {
                return $"{Name} (Доцент): Розраховане навантаження: {hours} годин (зосереджено на викладанні).";
            }

            public string ConductLecture(string subject)
            {
                return $"{Name} проводить практичне заняття з **{subject}**.";
            }

            public bool GetAccreditation(int level)
            {
                return level >= 2;
            }

            public string AcceptStudent(string studentName)
            {
                return $"Доцент {Name} прийняв **{studentName}** на магістерську програму.";
            }

            public string DevelopSyllabus(string course)
            {
                return $"Унікальний 1: {Name} розробляє навчальний план для курсу: *{course}*.";
            }

            public string CheckExams(int count)
            {
                return $"Унікальний 2: {Name} перевіряє {count} екзаменаційних робіт.";
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            rtbOutput.AppendText("--- Результати ---\n\n");

            if (!int.TryParse(txtAge.Text, out int age) ||
                !int.TryParse(txtSpecificField.Text, out int specificValue))
            {
                rtbOutput.AppendText("Помилка: Вік та Специфічне поле повинні бути числами!");
                return;
            }

            string name = txtName.Text;
            string department = txtDepartment.Text;
            Vykladach person = null;

            if (rbProfessor.Checked)
            {
                person = new Professor(name, age, department, specificValue);
                rtbOutput.AppendText("Створено об'єкт: **Професор**\n");
            }
            else if (rbDotsent.Checked)
            {
                person = new Dotsent(name, age, department, specificValue);
                rtbOutput.AppendText("Створено об'єкт: **Доцент**\n");
            }

            if (person != null)
            {
                rtbOutput.AppendText("Загальна інформація: " + person.DisplayInfo() + "\n");

                IVykladach teacher = person as IVykladach;
                IZVO hei = person as IZVO;

                rtbOutput.AppendText("\n-- IVykladach Methods --\n");
                rtbOutput.AppendText(teacher.CalculateWorkload(35) + "\n");
                rtbOutput.AppendText(teacher.ConductLecture("Квантова фізика") + "\n");

                rtbOutput.AppendText("\n-- IZVO Methods --\n");
                rtbOutput.AppendText("Акредитація (Рівень 4): " + (hei.GetAccreditation(4) ? "Отримано" : "Не отримано") + "\n");
                rtbOutput.AppendText(hei.AcceptStudent("Наталія Коваленко") + "\n");

                rtbOutput.AppendText("\n-- Unique Methods --\n");
                if (person is Professor prof)
                {
                    rtbOutput.AppendText(prof.LeadResearchProject("Теорія інформації") + "\n");
                    rtbOutput.AppendText(prof.ServeOnAcademicCouncil() + "\n");
                }
                else if (person is Dotsent dotsent)
                {
                    rtbOutput.AppendText(dotsent.DevelopSyllabus("Програмування на C#") + "\n");
                    rtbOutput.AppendText(dotsent.CheckExams(120) + "\n");
                }
            }
        }

        private void rbProfessor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProfessor.Checked)
            {
                lblSpecificField.Text = "Кількість публікацій:";
            }
        }

        private void rbDotsent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDotsent.Checked)
            {
                lblSpecificField.Text = "Кількість курсів:";
            }
        }
    }
}

