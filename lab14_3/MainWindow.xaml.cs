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
using System.Threading.Tasks;

namespace lab14_3 // Переконайся, що назва простору імен відповідає твоїй
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Ключове слово 'async' дозволяє використовувати 'await' всередині цього методу
        private async void btnStartDownload_Click(object sender, RoutedEventArgs e)
        {
            btnStartDownload.IsEnabled = false; // Вимкнути кнопку під час завантаження
            pbDownloadProgress.Value = 0;       // Скидання прогресу
            txtStatus.Text = "Завантаження розпочато...";

            try
            {
                // Запускаємо асинхронну імітацію завантаження
                await SimulateDownloadAsync(5000); // 5000 мс = 5 секунд

                // Цей код виконається тільки після того, як SimulateDownloadAsync завершиться
                pbDownloadProgress.Value = 100;
                txtStatus.Text = "Завантаження завершено успішно!";
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"Помилка завантаження: {ex.Message}";
            }
            finally
            {
                btnStartDownload.IsEnabled = true; // Знову активуємо кнопку
            }
        }

        /// <summary>
        /// Асинхронний метод, що імітує завантаження файлу.
        /// </summary>
        /// <param name="totalDelayMs">Загальний час затримки в мілісекундах.</param>
        /// <returns>Task, що позначає завершення операції.</returns>
        private async Task SimulateDownloadAsync(int totalDelayMs)
        {
            int steps = 50; // Кількість кроків оновлення прогресу
            int delayPerStep = totalDelayMs / steps; // 5000 мс / 50 кроків = 100 мс на крок
            double progressIncrement = 100.0 / steps;

            for (int i = 0; i < steps; i++)
            {
                // await Task.Delay() – не блокує UI-потік, дозволяючи йому оновлювати ProgressBar.
                await Task.Delay(delayPerStep);

                // Оновлення UI:
                // Оскільки 'await' автоматично повертає виконання в контекст UI-потоку,
                // ми можемо оновлювати елементи UI (ProgressBar) напряму.
                pbDownloadProgress.Value += progressIncrement;
                txtStatus.Text = $"Прогрес: {pbDownloadProgress.Value:F0}%";
            }
        }
    }
}