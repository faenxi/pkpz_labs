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
using System.Collections.Generic;
using System.Net.NetworkInformation; 
using System.Threading.Tasks;

namespace lab14_4 // ПЕРЕВІРТЕ: Назва простору імен має відповідати вашому проєкту
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnPingStart_Click(object sender, RoutedEventArgs e)
        {
            // Очищення списку та вимкнення кнопки на час роботи
            lbActiveHosts.Items.Clear();
            btnPingStart.IsEnabled = false;

            // Отримуємо базову адресу (наприклад, "192.168.1.")
            string baseAddress = txtBaseAddress.Text.Trim();
            if (string.IsNullOrWhiteSpace(baseAddress) || !baseAddress.EndsWith("."))
            {
                MessageBox.Show("Будь ласка, введіть коректний початок IP-адреси (наприклад, 192.168.1.).");
                btnPingStart.IsEnabled = true;
                return;
            }

            lbActiveHosts.Items.Add($"Сканування мережі {baseAddress}1 - {baseAddress}254...");

            // Створюємо список задач для ПАРАЛЕЛЬНОГО пінгування
            var pingTasks = new List<Task>();

            // Діапазон адрес хостів: від 1 до 254 включно 
            for (int i = 1; i < 255; i++)
            {
                string ip = baseAddress + i;

                // Створюємо задачу для пінгування (використовуємо Task.Run, щоб пінг виконувався в пулі потоків)
                pingTasks.Add(Task.Run(() => PingHost(ip)));
            }

            // Асинхронно чекаємо завершення ВСІХ 254 задач
            await Task.WhenAll(pingTasks);

            lbActiveHosts.Items.Add("--- Сканування завершено! ---");
            btnPingStart.IsEnabled = true;
        }

        /// <summary>
        /// Метод, що виконується в окремому потоці (Task), для пінгування одного хоста.
        /// </summary>
        /// <param name="ipAddress">Повна IP-адреса для перевірки.</param>
        private void PingHost(string ipAddress)
        {
            // Використовуємо using для коректного звільнення ресурсу Ping
            using (Ping pinger = new Ping())
            {
                try
                {
                    // Відправляємо ping-запит, таймаут 1000 мс (1 секунда)
                    PingReply reply = pinger.Send(ipAddress, 1000);

                    // Перевіряємо статус відповіді
                    if (reply.Status == IPStatus.Success) // "Success" означає, що хост активний
                    {
                        // Оновлення UI через Dispatcher.Invoke(), оскільки це фоновий потік Task.Run()
                        Dispatcher.Invoke(() =>
                        {
                            lbActiveHosts.Items.Add($"✅ Активний: {ipAddress} ({reply.RoundtripTime} ms)");
                        });
                    }
                    // Якщо хост неактивний, ми не виводимо його в список.
                }
                catch (Exception)
                {
                    // Ігноруємо винятки (наприклад, мережа недоступна)
                }
            }
        }
    }
}