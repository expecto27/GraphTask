using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_tasks
{
    public partial class task9 : Form
    {

        private List<Point> nodes; // Список вершин
        private List<Edge> edges; // Список ребер

        private int[,] adjacencyMatrix; // Матрица смежности
        private int numNodes; // Количество вершин
        private int[,] shortestPathsMatrix;
        private string[,] pathVerticesMatrix;

        private Random random;

        public task9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParseAdjacencyMatrix();
            if (adjacencyMatrix != null)
            {
                DrawGraph();
                FloydAlgorithm();
                DisplayShortestPaths();
            }
            else
            {
                MessageBox.Show("Please parse the adjacency matrix first.");
            }
        }

        private bool ParseAdjacencyMatrix()
        {
            // Получение матрицы смежности из RichTextBox
            string[] lines = rtbMatrix.Text.Trim().Split('\n');
            numNodes = lines.Length;
            adjacencyMatrix = new int[numNodes, numNodes];

            try
            {
                for (int i = 0; i < numNodes; i++)
                {
                    string[] values = lines[i].Trim().Split(' ');
                    for (int j = 0; j < numNodes; j++)
                    {
                        adjacencyMatrix[i, j] = int.Parse(values[j]);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при разборе матрицы смежности: " + ex.Message);
                return false;
            }
        }

        private void DrawGraph()
        {
            // Очистка PictureBox
            picGraph.Image = null;
            picGraph.Refresh();

            // Инициализация списков вершин и ребер
            nodes = new List<Point>();
            edges = new List<Edge>();

            Random random = new Random();

            // Определение координат вершин
            int nodeSize = 40;
            int padding = 20;
            int maxX = picGraph.Width - nodeSize - padding;
            int maxY = picGraph.Height - nodeSize - padding;

            for (int i = 0; i < numNodes; i++)
            {
                int x = random.Next(padding, maxX);
                int y = random.Next(padding, maxY);

                Point node = new Point(x, y);

                // Проверка наложения вершин
                while (nodes.Any(n => Distance(node, n) < nodeSize + padding))
                {
                    x = random.Next(padding, maxX);
                    y = random.Next(padding, maxY);
                    node = new Point(x, y);
                }

                nodes.Add(node);
            }

            // Создание ребер и определение их весов
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = i + 1; j < numNodes; j++)
                {
                    if (adjacencyMatrix[i, j] > 0)
                    {
                        int weight = adjacencyMatrix[i, j];
                        edges.Add(new Edge(i, j, weight));
                    }
                }
            }

            // Отрисовка графа
            Bitmap bmp = new Bitmap(picGraph.Width, picGraph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Edge edge in edges)
                {
                    Point node1 = nodes[edge.Node1];
                    Point node2 = nodes[edge.Node2];

                    g.DrawLine(Pens.Black, node1, node2);
                    Point midpoint = new Point((node1.X + node2.X) / 2, (node1.Y + node2.Y) / 2);
                    g.DrawString(edge.Weight.ToString(), Font, Brushes.White, midpoint);
                }

                for (int i = 0; i < numNodes; i++)
                {
                    Point node = nodes[i];

                    int nodeX = node.X - nodeSize / 2;
                    int nodeY = node.Y - nodeSize / 2;

                    g.FillEllipse(Brushes.White, nodeX, nodeY, nodeSize, nodeSize);
                    g.DrawEllipse(Pens.Black, nodeX, nodeY, nodeSize, nodeSize);
                    g.DrawString((i + 1).ToString(), Font, Brushes.Black, node.X - 8, node.Y - 8);
                }
            }

            picGraph.Image = bmp;
        }

        private double Distance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void FloydAlgorithm()
        {
            int size = adjacencyMatrix.GetLength(0);
            shortestPathsMatrix = (int[,])adjacencyMatrix.Clone();
            pathVerticesMatrix = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (adjacencyMatrix[i, j] != int.MaxValue && i != j)
                    {
                        pathVerticesMatrix[i, j] = (i + 1).ToString() + " -> " + (j + 1).ToString();
                    }
                    else
                    {
                        pathVerticesMatrix[i, j] = "";
                    }
                }
            }

            for (int k = 0; k < size; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (shortestPathsMatrix[i, k] != int.MaxValue && shortestPathsMatrix[k, j] != int.MaxValue &&
                            shortestPathsMatrix[i, k] + shortestPathsMatrix[k, j] < shortestPathsMatrix[i, j])
                        {
                            shortestPathsMatrix[i, j] = shortestPathsMatrix[i, k] + shortestPathsMatrix[k, j];
                            pathVerticesMatrix[i, j] = pathVerticesMatrix[i, k] + " -> " + (j + 1).ToString();
                        }
                    }
                }
            }
        }

        private void DisplayShortestPaths()
        {
            int size = shortestPathsMatrix.GetLength(0);
            richTextBoxResult.Text = "";

            richTextBoxResult.AppendText(Environment.NewLine + "Shortest Paths:" + Environment.NewLine);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (shortestPathsMatrix[i, j] != int.MaxValue && i != j)
                    {
                        richTextBoxResult.AppendText("From " + (i + 1).ToString() + " to " + (j + 1).ToString() +
                            ": " + pathVerticesMatrix[i, j] + " (Sum: " + shortestPathsMatrix[i, j] + ")" +
                            Environment.NewLine);
                    }
                }
            }
        }




        public class Edge
        {
            public int Node1 { get; set; } // Вершина 1
            public int Node2 { get; set; } // Вершина 2
            public int Weight { get; set; } // Вес ребра

            public Edge(int node1, int node2, int weight)
            {
                Node1 = node1;
                Node2 = node2;
                Weight = weight;
            }
        }

    }
}
