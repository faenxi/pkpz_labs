using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Linq.Expressions;

public class ArrayStack
{
    private int[] stackArray;
    private int top;

    public ArrayStack(int maxSize)
    {
        stackArray = new int[maxSize];
        top = -1;
    }

    public void Push(int element)
    {
        if (top == stackArray.Length - 1)
        {
            throw new InvalidOperationException("Стек переповнений.");
        }
        stackArray[++top] = element;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Стек порожній.");
        }
        return stackArray[top--];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public int Count
    {
        get { return top + 1; }
    }
}

namespace lab9_3
{
    public partial class Form1 : Form
    {
        private const string FILENAME = "expression.txt";

        public Form1()
        {
            InitializeComponent();
            EnsureTestFileExists();
            rtbOutput.AppendText($"Натисніть кнопку, щоб зчитати вираз з '{FILENAME}' та перевірити баланс дужок.\n");
        }

        private void EnsureTestFileExists()
        {
            if (!File.Exists(FILENAME))
            {
                string testExpression = "(1+2)*((4-a)*(3))/(2+7+6)";
                File.WriteAllText(FILENAME, testExpression);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            txtExpression.Clear();

            if (!File.Exists(FILENAME))
            {
                rtbOutput.AppendText($"ПОМИЛКА: Файл '{FILENAME}' не знайдено.");
                return;
            }
            string expression = File.ReadAllText(FILENAME).Trim();
            txtExpression.Text = expression;
            rtbOutput.AppendText($"Зчитаний вираз: {expression}\n");

            ArrayStack stack = new ArrayStack(expression.Length);
            List<(int Open, int Close)> matchedPairs = new List<(int, int)>();

            bool isBalanced = true;

            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];

                if (current == '(')
                {
                    stack.Push(i + 1);
                }
                else if (current == ')')
                {
                    if (stack.IsEmpty())
                    {
                        isBalanced = false;
                        break;
                    }

                    int openPosition = stack.Pop();

                    matchedPairs.Add((openPosition, i + 1));
                }
            }

            if (!stack.IsEmpty())
            {
                isBalanced = false;
            }

            rtbOutput.AppendText("\n--- РЕЗУЛЬТАТ ПЕРЕВІРКИ ---\n");

            if (isBalanced)
            {
                rtbOutput.AppendText("Усі дужки ЗБАЛАНСОВАНІ.\n");
                rtbOutput.AppendText("Позиції збалансованих пар (за зростанням номерів дужок, що закриваються):\n");

                var sortedPairs = matchedPairs.OrderBy(p => p.Close).ToList();

                foreach (var pair in sortedPairs)
                {
                    rtbOutput.AppendText($"\tВідкриваюча: {pair.Open} -> Закриваюча: {pair.Close}\n");
                }
            }
            else
            {
                rtbOutput.AppendText("ДУЖКИ НЕ ЗБАЛАНСОВАНІ. (Повідомлення про це)\n");

                if (!stack.IsEmpty())
                {
                    rtbOutput.AppendText($"Причина: Залишилося {stack.Count} дужок, що відкриваються, без пари.\n");
                }
                else
                {
                    rtbOutput.AppendText($"Причина: Знайдено зайву дужку, що закривається.\n");
                }
            }
        }
    }
}