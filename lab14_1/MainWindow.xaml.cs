using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab14_1
{
    public partial class MainWindow : Window
    {
        private Thread generatorThread;
        private bool isGenerating = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обробник натискання кнопки, створений на кроці 1
        private void btnStartGenerator_Click(object sender, RoutedEventArgs e)
        {
            if (!isGenerating)
            {
                // Запуск генератора
                isGenerating = true;
                btnStartGenerator.Content = "Зупинити Генератор (1.1)";

                generatorThread = new Thread(GenerateNumbers);
                generatorThread.IsBackground = true;
                generatorThread.Start();
            }
            else
            {
                // Зупинка генератора
                isGenerating = false;
                btnStartGenerator.Content = "Запустити Генератор (Thread 1.1)";
            }
        }

        private void GenerateNumbers()
        {
            Random random = new Random();
            while (isGenerating)
            {
                int randomNumber = random.Next(1, 101);

                // !!! Оновлення UI через Dispatcher.Invoke() !!!
                // Це обов'язково для WPF, коли оновлення йде з фонового потоку (Thread)
                Dispatcher.Invoke(() =>
                {
                    lbRandomNumbers.Items.Add(randomNumber.ToString());
                });

                Thread.Sleep(2000); // Затримка 2 секунди
            }
        }

        // Додаткова логіка для коректної зупинки потоку при закритті вікна
        protected override void OnClosed(EventArgs e)
        {
            isGenerating = false;
            base.OnClosed(e);
        }
    }
}