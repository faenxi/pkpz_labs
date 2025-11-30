using System;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Linq;

namespace lab10_2
{
    public partial class Form1 : Form
    {
        private const int V = 6;

        private readonly string[] Vertices = { "a", "b", "c", "d", "e", "f" };

        public Form1()
        {
            InitializeComponent();
        }

        private int[,] CreateAdjacencyMatrix()
        {
            int[,] adj = new int[V, V];

            (int from, int to)[] edges = new (int, int)[]
            {
                (0, 0),
                (0, 1),
                (1, 0),
                (1, 1),
                (2, 0),
                (2, 3),
                (3, 4),
                (4, 2),
                (4, 3),
                (5, 0),
                (5, 1)
            };

            foreach (var edge in edges)
            {
                adj[edge.from, edge.to] = 1;
            }

            return adj;
        }

        private int[,] CreateIncidenceMatrix(out int edgeCount)
        {
            (int from, int to)[] edges = new (int, int)[]
            {
                (0, 0), (0, 1), (1, 0), (1, 1), (2, 0), (2, 3), (3, 4),
                (4, 2), (4, 3), (5, 0), (5, 1)
            };

            edgeCount = edges.Length;
            int[,] inc = new int[V, edgeCount];

            for (int j = 0; j < edgeCount; j++)
            {
                int from = edges[j].from;
                int to = edges[j].to;

                inc[from, j] = 1;

                if (from != to)
                {
                    inc[to, j] = -1;
                }
            }

            return inc;
        }

        private void DisplayMatrix(RichTextBox rtb, string title, int[,] matrix, string[] colHeaders = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"--- {title} ---");

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (colHeaders != null)
            {
                sb.Append("V\\E | ");
                sb.AppendLine(string.Join(" | ", colHeaders));
                sb.AppendLine(new string('-', 5 + cols * 4));
            }
            else
            {
                sb.Append("V\\V | ");
                sb.AppendLine(string.Join(" | ", Vertices));
                sb.AppendLine(new string('-', 5 + cols * 4));
            }

            for (int i = 0; i < rows; i++)
            {
                sb.Append($"{Vertices[i]}    | ");
                for (int j = 0; j < cols; j++)
                {
                    string value = matrix[i, j].ToString().PadLeft(2);
                    sb.Append($"{value} | ");
                }
                sb.AppendLine();
            }

            rtb.Text = sb.ToString();
        }

        private void btnGenerateMatrices_Click(object sender, EventArgs e)
        {
            rtbAdjacency.Clear();
            rtbIncidence.Clear();

            int[,] adjMatrix = CreateAdjacencyMatrix();
            DisplayMatrix(rtbAdjacency, "Матриця Суміжності (A)", adjMatrix);

            int edgeCount;
            int[,] incMatrix = CreateIncidenceMatrix(out edgeCount);

            string[] edgeHeaders = Enumerable.Range(1, edgeCount).Select(i => $"e{i}").ToArray();

            DisplayMatrix(rtbIncidence, "Матриця Інцидентності (I)", incMatrix, edgeHeaders);
        }
    }
}