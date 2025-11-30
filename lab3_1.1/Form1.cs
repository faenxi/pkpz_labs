using System.Text.RegularExpressions;

namespace lab3_1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string input = textBox1.Text;

       
            string result = Regex.Replace(input, @"\d{2}", "?");

            result = Regex.Replace(result, @"\d", "!");

            textBox2.Text = result;
        }
    }
}
