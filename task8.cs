using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Graph_tasks.task7;

namespace Graph_tasks
{
    public partial class task8 : Form
    {

        private List<Point> nodes; // Список вершин
        private List<Edge> edges; // Список ребер

        private int[,] adjacencyMatrix; // Матрица смежности
        private int numNodes; // Количество вершин

        private int startNode;

        private Random random;
        public task8()
        {

            this.Icon = new Icon("../../icon.ico");
            InitializeComponent();
        }

        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            if (ParseAdjacencyMatrix())
            {
                DrawGraph();
            }
            kp_Click();
            this.ClientSize = new System.Drawing.Size(950, 473);
            this.close.Location = new System.Drawing.Point(925, 4);
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
                for (int i = 0; i < numNodes; i++)
                {
                    Point node = nodes[i];

                    int nodeX = node.X - nodeSize / 2;
                    int nodeY = node.Y - nodeSize / 2;

                   
                    Brush nodeBrush = Brushes.Green;
                    if (i + 1 == startNode) // Проверка, является ли текущая вершина начальной вершиной
                    {
                        nodeBrush = Brushes.Red;
                    }

                    g.FillEllipse(nodeBrush, nodeX, nodeY, nodeSize, nodeSize);
                    g.DrawEllipse(Pens.Black, nodeX, nodeY, nodeSize, nodeSize);
                    g.DrawString((i + 1).ToString(), Font, Brushes.White, node.X - 8, node.Y - 8);
                }

                foreach (Edge edge in edges)
                {
                    Point node1 = nodes[edge.Node1];
                    Point node2 = nodes[edge.Node2];

                    g.DrawLine(Pens.Black, node1, node2);
                    Point midpoint = new Point((node1.X + node2.X) / 2, (node1.Y + node2.Y) / 2);
                    g.DrawString(edge.Weight.ToString(), Font, Brushes.White, midpoint);
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

        private Dictionary<int, int> FindShortestPaths(int startNode)
        {
            int[] distance = new int[numNodes];
            bool[] visited = new bool[numNodes];

            
            for (int i = 0; i < numNodes; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            
            distance[startNode - 1] = 0;

            
            for (int count = 0; count < numNodes - 1; count++)
            {
                int minDistance = int.MaxValue;
                int minIndex = -1;

               
                for (int i = 0; i < numNodes; i++)
                {
                    if (!visited[i] && distance[i] < minDistance)
                    {
                        minDistance = distance[i];
                        minIndex = i;
                    }
                }

                
                visited[minIndex] = true;

                
                for (int i = 0; i < numNodes; i++)
                {
                    if (!visited[i] && adjacencyMatrix[minIndex, i] > 0 && distance[minIndex] != int.MaxValue &&
                        distance[minIndex] + adjacencyMatrix[minIndex, i] < distance[i])
                    {
                        distance[i] = distance[minIndex] + adjacencyMatrix[minIndex, i];
                    }
                }
            }

            
            Dictionary<int, int> shortestPaths = new Dictionary<int, int>();
            for (int i = 0; i < numNodes; i++)
            {
                if (i != startNode - 1)
                {
                    shortestPaths.Add(i + 1, distance[i]);
                }
            }

            return shortestPaths;
        }

        private void DisplayShortestPaths(Dictionary<int, int> shortestPaths)
        {
        rtbShortestPaths.Clear();
        int totalWeight = 0;
         foreach (var kvp in shortestPaths)
            {
                rtbShortestPaths.AppendText($"Кратчайший путь до вершины №{kvp.Key} составляет: {kvp.Value}\n");
                totalWeight += kvp.Value;
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

        private void kp_Click()
        {
            if (!int.TryParse(txtStartNode.Text, out startNode))
            {
                MessageBox.Show("Не задана стартовая вершина.");
                return;
            }

            if (startNode < 1 || startNode > numNodes)
            {
                MessageBox.Show("Номер вершины не соответствует их колличеству.");
                return;
            }

            Dictionary<int, int> shortestPaths = FindShortestPaths(startNode);
            DisplayShortestPaths(shortestPaths);
        }
        Point last;
        private void task1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - last.X;
                this.Top += e.Y - last.Y;
            }
        }

        private void task1_MouseDown(object sender, MouseEventArgs e)
        {
            last = new Point(e.X, e.Y);
        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            main M = new main();
            M.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process proc = Process.Start("notepad.exe");
        }
    }
}
