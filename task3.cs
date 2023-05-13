using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_tasks
{
    public partial class task3 : Form
    {
        public task3()
        {
            InitializeComponent();
        }
        private bool shouldDrawGraph = false;
        private Font vertexFont = new Font("Impact", 18);

        private PointF GetVertexCenter(int vertexIndex, int vertexCount, int vertexRadius)
        {
            // Получите размеры элемента PictureBox/Panel, на котором будет рисоваться граф
            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;

            // Рассчитайте координаты центра каждой вершины графа
            float x = pictureBoxWidth / 2 + (pictureBoxWidth / 2 - vertexRadius) * (float)Math.Cos(2 * Math.PI * vertexIndex / vertexCount);
            float y = pictureBoxHeight / 2 + (pictureBoxHeight / 2 - vertexRadius) * (float)Math.Sin(2 * Math.PI * vertexIndex / vertexCount);

            return new PointF(x, y);
        }

        private void BFS(int[,] adjacencyMatrix, int startVertex, bool[] visited)
        {
            int vertexCount = adjacencyMatrix.GetLength(0);
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                label3.Text += (currentVertex + 1) + " ";

                for (int i = 0; i < vertexCount; i++)
                {
                    if (adjacencyMatrix[currentVertex, i] != 0 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }

        private void PerformBFS(int[,] adjacencyMatrix)
        {
            int vertexCount = adjacencyMatrix.GetLength(0);
            bool[] visited = new bool[vertexCount];

            // Найдите вершину, из которой есть путь в первую вершину (vertex 0)
            int startVertex = FindStartVertex(adjacencyMatrix, 0);

            // Если такая вершина найдена, начните обход с неё
            if (startVertex != -1)
            {
                BFS(adjacencyMatrix, startVertex, visited);
            }

            // Продолжите обход для остальных непосещенных вершин
            for (int i = 0; i < vertexCount; i++)
            {
                if (!visited[i])
                {
                    BFS(adjacencyMatrix, i, visited);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Посещенные вершины: ";
            this.ClientSize = new System.Drawing.Size(950, 473);
            this.close.Location = new System.Drawing.Point(925, 4);
            shouldDrawGraph = true;
            pictureBox1.Invalidate();

            int[,] adjacencyMatrix = GetAdjacencyMatrix(richTextBox1.Text);
            PerformBFS(adjacencyMatrix);
        }

        private int FindStartVertex(int[,] adjacencyMatrix, int targetVertex)
        {
            int vertexCount = adjacencyMatrix.GetLength(0);

            for (int i = 0; i < vertexCount; i++)
            {
                if (adjacencyMatrix[i, targetVertex] != 0)
                {
                    return FindStartVertex(adjacencyMatrix, i);
                }
            }

            return -1; // Если не найдена ни одна вершина с путём в целевую вершину
        }


        

        private int[,] GetAdjacencyMatrix(string input)
        {
            if (shouldDrawGraph)
            {
                // Разделите входную строку на строки по переводу строки
                string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // Определите размеры матрицы на основе количества строк
                int rows = lines.Length;
                int cols = lines[0].Split(' ').Length;

                // Создайте новую матрицу смежности
                int[,] adjacencyMatrix = new int[rows, cols];

                // Заполните матрицу смежности значениями из входной строки
                for (int i = 0; i < rows; i++)
                {
                    string[] values = lines[i].Split(' ');
                    for (int j = 0; j < cols; j++)
                    {
                        adjacencyMatrix[i, j] = int.Parse(values[j]);
                    }
                }

                return adjacencyMatrix;
            }
            return null;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (shouldDrawGraph)
            {

                int[,] adjacencyMatrix = GetAdjacencyMatrix(richTextBox1.Text); // Получите матрицу смежности вашего графа

                bool direct = IsGraphDirected(adjacencyMatrix);

                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.White, 2);

                // Получите размеры элемента PictureBox/Panel, на котором будет рисоваться граф
                int pictureBoxWidth = pictureBox1.Width;
                int pictureBoxHeight = pictureBox1.Height;

                // Вычислите радиус вершин графа на основе размеров элемента PictureBox/Panel
                int vertexRadius = Math.Min(pictureBoxWidth, pictureBoxHeight) / 10;

                int vertexCount = adjacencyMatrix.GetLength(0);

                // Рассчитайте координаты центра каждой вершины графа
                PointF[] vertexCenters = new PointF[vertexCount];
                for (int i = 0; i < vertexCount; i++)
                {
                    float x = pictureBoxWidth / 2 + (pictureBoxWidth / 2 - vertexRadius) * (float)Math.Cos(2 * Math.PI * i / vertexCount);
                    float y = pictureBoxHeight / 2 + (pictureBoxHeight / 2 - vertexRadius) * (float)Math.Sin(2 * Math.PI * i / vertexCount);
                    vertexCenters[i] = new PointF(x, y);
                }
                // Отрисуйте вершины графа
                Brush vertexBrush = Brushes.Green;
                for (int i = 0; i < vertexCenters.Length; i++)
                {
                    PointF center = vertexCenters[i];
                    float x = center.X - vertexRadius;
                    float y = center.Y - vertexRadius;
                    g.FillEllipse(vertexBrush, x, y, 2 * vertexRadius, 2 * vertexRadius);

                    // Выведите номер вершины внутри вершины
                    string vertexNumber = (i + 1).ToString();
                    SizeF numberSize = g.MeasureString(vertexNumber, vertexFont);
                    float numberX = center.X - numberSize.Width;
                    float numberY = center.Y - numberSize.Height;
                    g.DrawString(vertexNumber, vertexFont, Brushes.White, numberX, numberY);
                }

                // Отрисуйте ребра графа
                Pen edgePen = new Pen(Color.White, 2);
                edgePen.EndCap = LineCap.ArrowAnchor;

                for (int i = 0; i < vertexCount; i++)
                {
                    for (int j = 0; j < vertexCount; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1 && i != j)
                        {

                            PointF startPoint = vertexCenters[i];
                            PointF endPoint = vertexCenters[j];
                            g.DrawLine(edgePen, startPoint, endPoint);

                            // Отрисуйте стрелку на конце ребра
                            if (direct && adjacencyMatrix[i, j] != adjacencyMatrix[j, i]) DrawArrow(g, edgePen, startPoint, endPoint);
                        }
                    }
                }
            }
        }
        private bool IsGraphDirected(int[,] adjacencyMatrix)
        {
            int size = adjacencyMatrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (adjacencyMatrix[i, j] != adjacencyMatrix[j, i])
                    {
                        return true; // Если найдена различная пара значений, граф является ориентированным
                    }
                }
            }

            return false; // Если все пары значений совпадают, граф не является ориентированным
        }

        private void DrawArrow(Graphics g, Pen pen, PointF startPoint, PointF endPoint)
        {
            float arrowSize = 30; // Измените размер стрелки по вашему усмотрению

            PointF[] arrowHead = new PointF[2];
            float angle = (float)Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
            float sinAngle = (float)Math.Sin(angle);
            float cosAngle = (float)Math.Cos(angle);

            arrowHead[0] = endPoint;
            arrowHead[1] = new PointF(endPoint.X - arrowSize * cosAngle + arrowSize * 0.5f * sinAngle,
                                      endPoint.Y - arrowSize * sinAngle - arrowSize * 0.5f * cosAngle);

            PointF[] arrowHead1 = new PointF[2];
            arrowHead1[0] = endPoint;
            arrowHead1[1] = new PointF(endPoint.X - arrowSize * cosAngle - arrowSize * 0.5f * sinAngle,
                                    endPoint.Y - arrowSize * sinAngle + arrowSize * 0.5f * cosAngle);
            g.DrawLines(pen, arrowHead1);
            g.DrawLines(pen, arrowHead);
        }



        private void close_Click(object sender, EventArgs e)
        {
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
