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
    public partial class task7 : Form
    {
        private List<Point> nodes; // Список вершин
        private List<Edge> edges; // Список ребер

        private int[,] adjacencyMatrix; // Матрица смежности
        private int numNodes; // Количество вершин

        private Random random;
        public task7()
        {
            InitializeComponent();
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
            for (int i = 0; i < numNodes; i++)
            {
                int x = random.Next(50, picGraph.Width - 50);
                int y = random.Next(50, picGraph.Height - 50);

                nodes.Add(new Point(x, y));
            }

            // Создание ребер и определение их весов
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = i + 1; j < numNodes; j++)
                {
                    if (adjacencyMatrix[i, j] > 0)
                    {
                        int weight = random.Next(1, 10); // Генерация случайного веса ребра
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
                    g.DrawString(edge.Weight.ToString(), Font, Brushes.Black, midpoint);
                }

                for (int i = 0; i < numNodes; i++)
                {
                    Point node = nodes[i];

                    // Проверка, чтобы вершины не выходили за границы PictureBox
                    int nodeSize = 45;
                    int nodeX = node.X - nodeSize / 2;
                    int nodeY = node.Y - nodeSize / 2;

                    if (nodeX < 0)
                        nodeX = 0;
                    else if (nodeX + nodeSize > picGraph.Width)
                        nodeX = picGraph.Width - nodeSize;

                    if (nodeY < 0)
                        nodeY = 0;
                    else if (nodeY + nodeSize > picGraph.Height)
                        nodeY = picGraph.Height - nodeSize;

                    g.FillEllipse(Brushes.White, nodeX, nodeY, nodeSize, nodeSize);
                    g.DrawEllipse(Pens.Black, nodeX, nodeY, nodeSize, nodeSize);
                    g.DrawString((i + 1).ToString(), Font, Brushes.Black, node.X - 8, node.Y - 8);
                }
            }

            picGraph.Image = bmp;
        }

        private void FindMinimumSpanningTree()
        {
            List<int> selectedNodes = new List<int>(); // Список выбранных вершин
            List<Edge> mstEdges = new List<Edge>(); // Список ребер минимального остовного дерева

            selectedNodes.Add(0); // Начальная вершина

            while (selectedNodes.Count < numNodes)
            {
                int minWeight = int.MaxValue;
                Edge minEdge = null;

                foreach (Edge edge in edges)
                {
                    if (selectedNodes.Contains(edge.Node1) && !selectedNodes.Contains(edge.Node2))
                    {
                        if (edge.Weight < minWeight)
                        {
                            minWeight = edge.Weight;
                            minEdge = edge;
                        }
                    }
                    else if (selectedNodes.Contains(edge.Node2) && !selectedNodes.Contains(edge.Node1))
                    {
                        if (edge.Weight < minWeight)
                        {
                            minWeight = edge.Weight;
                            minEdge = edge;
                        }
                    }
                }

                if (minEdge != null)
                {
                    mstEdges.Add(minEdge);
                    if (!selectedNodes.Contains(minEdge.Node1))
                        selectedNodes.Add(minEdge.Node1);
                    if (!selectedNodes.Contains(minEdge.Node2))
                        selectedNodes.Add(minEdge.Node2);
                }
                else
                {
                    // Если не удалось добавить ребро, чтобы пройти через все вершины, выберите оставшиеся вершины случайным образом
                    for (int i = 0; i < numNodes; i++)
                    {
                        if (!selectedNodes.Contains(i))
                        {
                            int randomNode = i;
                            int randomEdgeIndex = random.Next(edges.Count);
                            Edge randomEdge = edges[randomEdgeIndex];
                            if (selectedNodes.Contains(randomEdge.Node1))
                                randomNode = randomEdge.Node2;
                            else if (selectedNodes.Contains(randomEdge.Node2))
                                randomNode = randomEdge.Node1;

                            mstEdges.Add(new Edge(randomNode, i, randomEdge.Weight));
                            selectedNodes.Add(i);
                            break;
                        }
                    }
                }
            }

            edges = mstEdges;
        }

        private void DrawMinimumSpanningTree()
        {
            // Очистка PictureBox
            picMST.Image = null;
            picMST.Refresh();

            // Отрисовка минимального остовного дерева
            Bitmap bmp = new Bitmap(picMST.Width, picMST.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Edge edge in edges)
                {
                    Point node1 = nodes[edge.Node1];
                    Point node2 = nodes[edge.Node2];

                    g.DrawLine(Pens.Red, node1, node2);
                    g.DrawString(edge.Weight.ToString(), Font, Brushes.Black,
                        (node1.X + node2.X) / 2, (node1.Y + node2.Y) / 2);
                }

                for (int i = 0; i < numNodes; i++)
                {
                    Point node = nodes[i];
                    g.FillEllipse(Brushes.Green, node.X - 20, node.Y - 20, 45, 45);
                    g.DrawEllipse(Pens.Black, node.X - 20, node.Y - 20, 45, 45);
                    g.DrawString((i + 1).ToString(), Font, Brushes.Black, node.X - 8, node.Y - 8);
                }
            }

            picMST.Image = bmp;

            int mstSum = edges.Sum(e => e.Weight);
            //lblMSTSum.Text = $"Sum: {mstSum}";
        }

        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.btnDrawGraph.Location = new System.Drawing.Point(575, 37);
            this.close.Location = new System.Drawing.Point(989, 9);
            if (ParseAdjacencyMatrix())
            {
                DrawGraph();
                FindMinimumSpanningTree();
                DrawMinimumSpanningTree();
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

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            main M = new main();
            M.ShowDialog();
            this.Close();
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

    }
}
