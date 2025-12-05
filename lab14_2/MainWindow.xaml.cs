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

namespace lab14_2 // Переконайся, що назва простору імен відповідає твоїй
{
    public partial class MainWindow : Window
    {
        // Поле для керування скасуванням всіх задач. Це безпечний спосіб зупинити потоки.
        private CancellationTokenSource cts;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обробник натискання кнопки
        private void btnStartTaskGenerator_Click(object sender, RoutedEventArgs e)
        {
            // Якщо tasks вже запущені, скасовуємо їх
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
                btnStartTaskGenerator.Content = "Запустити 3 Паралельні Генератори (Task/ThreadPool 1.2)";
                return;
            }

            // Ініціалізація нового токена для скасування та оновлення UI
            cts = new CancellationTokenSource();
            btnStartTaskGenerator.Content = "Зупинити Генератори (Task/ThreadPool 1.2)";
            lbRandomNumbers.Items.Clear();
            lbRandomNumbers.Items.Add("Запуск 3 задач...");

            // 1. Задача (потік) - швидка
            Task.Run(() => GenerateNumbersTask(1, 500, cts.Token)); // 0.5 секунди затримка

            // 2. Задача (потік) - середня
            Task.Run(() => GenerateNumbersTask(2, 1500, cts.Token)); // 1.5 секунди затримка

            // 3. Задача (потік) - повільна
            Task.Run(() => GenerateNumbersTask(3, 3000, cts.Token)); // 3 секунди затримка
        }

        /// <summary>
        /// Метод, що виконується в ThreadPool. 
        /// Генерує числа з певною затримкою.
        /// </summary>
        /// <param name="taskId">Унікальний ідентифікатор потоку/задачі.</param>
        /// <param name="delayMs">Час затримки між генераціями в мілісекундах.</param>
        /// <param name="cancellationToken">Токен для зупинки.</param>
        private void GenerateNumbersTask(int taskId, int delayMs, CancellationToken cancellationToken)
        {
            Random random = new Random();
            int counter = 0;

            // Цикл виконується, доки не буде скасування (натискання кнопки) і не досягне ліміту
            while (!cancellationToken.IsCancellationRequested && counter < 15)
            {
                counter++;
                int randomNumber = random.Next(1, 1000);
                string result = $"Task {taskId} ({delayMs}ms): {randomNumber}";

                // Оновлення UI завжди через Dispatcher.Invoke(), коли використовується Task.Run()
                Dispatcher.Invoke(() =>
                {
                    lbRandomNumbers.Items.Add(result);
                    lbRandomNumbers.ScrollIntoView(result);
                });

                try
                {
                    // Task.Delay() використовується, щоб не блокувати ThreadPool. 
                    // .Wait() використовується для синхронного очікування у фоновому потоці.
                    Task.Delay(delayMs, cancellationToken).Wait();
                }
                catch (OperationCanceledException)
                {
                    break; // Вихід при скасуванні
                }
                catch (AggregateException ae) when (ae.InnerException is OperationCanceledException)
                {
                    break;
                }
            }

            // Повідомлення про завершення (через скасування або ліміт)
            if (cancellationToken.IsCancellationRequested)
            {
                Dispatcher.Invoke(() =>
                {
                    lbRandomNumbers.Items.Add($"--- Task {taskId} CANCELED. ---");
                });
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    lbRandomNumbers.Items.Add($"--- Task {taskId} FINISHED (15 cycles). ---");
                });
            }
        }

        // Важливо: обробка закриття вікна для коректної зупинки всіх потоків
        protected override void OnClosed(EventArgs e)
        {
            cts?.Cancel(); // Скасовуємо всі запущені задачі
            base.OnClosed(e);
        }
    }
}