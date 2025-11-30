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
            if (x >= 0 && y >= 0 && y > x)
            {
                Console.WriteLine("Да ти снайпер");
            }
            else if (x <= 0 && y <= 0 && y < x)
            {
                Console.WriteLine("Да ти снайпер");
            }
            else if ((x >= 0 && y >= 0 && y == x)
                     (x <= 0 && y <= 0 && y == x)
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
            Console.WriteLine("Введіть координати: ");
            int R = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());



            IsHit(R, x, y);

        }
    }
}