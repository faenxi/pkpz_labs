/*using System;



class Program
{
    static void Main()
    {
        int[,] matrix = new int[7, 5];
        Random random = new Random();

        int count = 0;
        int sum = 0;

        Console.WriteLine("Матриця:");
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = random.Next(-50, 50);
                Console.Write(matrix[i, j] + " ");

                if (matrix[i, j] % 7 == 0 && matrix[i, j] != 0)
                {
                    count++;
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\nКількість: {count}");
        if (count > 0)
        {
            Console.WriteLine($"Середнє: {(double)sum / count:F2}");
        }
    }
} 
*/


using System;

class Program
{
    static void Main()
    {
        int[][] jaggedArray = CreateJaggedArray(out int size);

        Console.WriteLine("\nЗубчастий масив:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + "\t");
            }
            Console.WriteLine();
        }

        int maxColumns = 0;
        for (int i = 0; i < size; i++)
            if (jaggedArray[i].Length > maxColumns)
                maxColumns = jaggedArray[i].Length;

        int[] minInColumns = new int[maxColumns];
        for (int col = 0; col < maxColumns; col++)
        {
            bool exists = false;
            int minVal = int.MaxValue;

            for (int row = 0; row < size; row++)
            {
                if (jaggedArray[row].Length > col)
                {
                    if (!exists || jaggedArray[row][col] < minVal)
                    {
                        minVal = jaggedArray[row][col];
                        exists = true;
                    }
                }
            }

            if (exists)
                minInColumns[col] = minVal;
            else
                minInColumns[col] = int.MinValue;
        }

        Console.WriteLine("\nМінімальні елементи по стовпцях:");
        for (int i = 0; i < maxColumns; i++)
        {
            if (minInColumns[i] != int.MinValue)
                Console.Write(minInColumns[i] + " ");
        }
    }

    static int[][] CreateJaggedArray(out int size)
    {
        while (true)
        {
            Console.Write("Введіть кількість рядків масиву: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out size) && size > 0)
                break;
            Console.WriteLine("Некоректне значення! Спробуйте ще раз.");
        }

        int[][] array = new int[size][];
        Random rnd = new Random();

        for (int i = 0; i < size; i++)
        {
            int length = rnd.Next(1, 6);
            array[i] = new int[length];
            for (int j = 0; j < length; j++)
                array[i][j] = rnd.Next(-10, 10);
        }

        return array;
    }
}
