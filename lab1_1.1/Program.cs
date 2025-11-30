using System;

namespace lab1
{
    class Program
    {
        static void IsHit(int R, int x, int y)
        {
            if ((x * x + y * y) > R * R)
            {
                Console.WriteLine("Мимо братан");
                return;
            }

            // Виправлено умову - додано оператори || для об'єднання умов
            if ((x >= 0 && y >= 0 && y > x) ||
                (x <= 0 && y <= 0 && y < x))
            {
                Console.WriteLine("Да ти снайпер");
            }
            // Виправлено умову - додано оператори || для об'єднання умов
            else if ((x >= 0 && y >= 0 && y == x) ||
                     (x <= 0 && y <= 0 && y == x) ||
                     (x * x + y * y == R * R))
            {
                Console.WriteLine("Точка належить фігурі і знаходиться на межі");
            }
            else
            {
                Console.WriteLine("Мимо братан");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введіть радіус R: ");

            // Виправлено проблему з null - використано TryParse для безпечного парсингу
            if (!int.TryParse(Console.ReadLine(), out int R))
            {
                Console.WriteLine("Невірний формат числа для R");
                return;
            }

            Console.WriteLine("Введіть координату x: ");
            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.WriteLine("Невірний формат числа для x");
                return;
            }

            Console.WriteLine("Введіть координату y: ");
            if (!int.TryParse(Console.ReadLine(), out int y))
            {
                Console.WriteLine("Невірний формат числа для y");
                return;
            }

            IsHit(R, x, y);
        }
    }
}