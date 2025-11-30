using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


namespace lab6_3pkpz
{
    public partial class Form1 : Form
    {
        private TreeCollection collection;

        public Form1()
        {
            InitializeComponent();
            collection = new TreeCollection();
            DisplayTrees("Початковий список (IENUMERABLE):");
        }

        public class Tree : IComparable<Tree>
        {
            public string Species { get; set; }
            public int Height { get; set; }
            public decimal Price { get; set; }

            public Tree(string species, int height, decimal price)
            {
                Species = species;
                Height = height;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Species} | Висота: {Height} м | Ціна: {Price:C}";
            }

            public int CompareTo(Tree other)
            {
                if (other == null) return 1;
                return this.Price.CompareTo(other.Price);
            }
        }

        public class TreeComparer : IComparer<Tree>
        {
            public int Compare(Tree x, Tree y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                int heightComparison = x.Height.CompareTo(y.Height);

                if (heightComparison != 0)
                {
                    return heightComparison;
                }
                else
                {
                    return x.Price.CompareTo(y.Price);
                }
            }
        }

        public class TreeCollection : IEnumerable<Tree>
        {
            private List<Tree> trees;

            public TreeCollection()
            {
                trees = new List<Tree>
                {
                    new Tree("Дуб", 15, 2500.00m),
                    new Tree("Ялина", 8, 1200.00m),
                    new Tree("Клен", 15, 1800.00m),
                    new Tree("Сосна", 12, 950.00m),
                    new Tree("Береза", 5, 500.00m)
                };
            }

            public IEnumerator<Tree> GetEnumerator()
            {
                return trees.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void SortTrees(IComparer<Tree> comparer = null)
            {
                if (comparer != null)
                {
                    trees.Sort(comparer);
                }
                else
                {
                    trees.Sort();
                }
            }

            public void AddTree(Tree tree)
            {
                trees.Add(tree);
            }
        }

        private void DisplayTrees(string title)
        {
            rtbOutput.Clear();
            rtbOutput.AppendText($"\n--- {title} ---\n");
            foreach (var tree in collection)
            {
                rtbOutput.AppendText(tree.ToString() + "\n");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtHeight.Text, out int height) && decimal.TryParse(txtPrice.Text, out decimal price))
            {
                collection.AddTree(new Tree(txtName.Text, height, price));
                txtName.Text = "";
                txtHeight.Text = "";
                txtPrice.Text = "";
                DisplayTrees("Список оновлено (додано нове дерево):");
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть числові значення для Висоти та Ціни.", "Помилка вводу");
            }
        }

        private void btnSortPrice_Click(object sender, EventArgs e)
        {
            collection.SortTrees();
            DisplayTrees("Список, упорядкований за ЦІНОЮ (IComparable):");
        }

        private void btnSortHeightPrice_Click(object sender, EventArgs e)
        {
            collection.SortTrees(new TreeComparer());
            DisplayTrees("Список, упорядкований за ВИСОТОЮ, потім ЦІНОЮ (IComparer):");
        }
    }
}