using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_tasks
{
    public partial class task12 : Form
    {
        private bool shouldDrawGraph = false;

        private Font vertexFont = new Font("Impact", 18);

        private static Color[] vertexColors; // Массив цветов для каждой вершины

        private static int numVertices; // Количество вершин в графе

        public task12()
        {

            this.Icon = new Icon("../../icon.ico");
            InitializeComponent();
        }


        public static void GetVertexColors(int[,] adjacencyMatrix)
        {
            numVertices = adjacencyMatrix.GetLength(0);
            vertexColors = new Color[numVertices];

            // Определение заранее определенных цветов
            Color[] predefinedColors = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Aqua, Color.Black, Color.Brown, Color.DeepPink, Color.DimGray, Color.White, Color.DarkViolet };

            // Присваиваем каждой вершине изначально пустой цвет
            for (int i = 0; i < numVertices; i++)
            {
                vertexColors[i] = Color.Empty;
            }

            // Перебираем все вершины и раскрашиваем их
            for (int vertex = 0; vertex < numVertices; vertex++)
            {
                // Получаем доступные цвета для текущей вершины
                bool[] availableColors = new bool[numVertices];
                for (int i = 0; i < numVertices; i++)
                {
                    availableColors[i] = true;
                }

                // Проверяем цвета соседних вершин и помечаем их как недоступные
                for (int neighbor = 0; neighbor < numVertices; neighbor++)
                {
                    if (adjacencyMatrix[vertex, neighbor] == 1 && vertexColors[neighbor] != Color.Empty)
                    {
                        int colorIndex1 = Array.IndexOf(predefinedColors, vertexColors[neighbor]);
                        availableColors[colorIndex1] = false;
                    }
                }

                // Находим первый доступный цвет для текущей вершины
                int colorIndex = Array.IndexOf(availableColors, true);

                // Присваиваем текущей вершине найденный цвет
                vertexColors[vertex] = predefinedColors[colorIndex];
            }
        }



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



        private void button1_Click(object sender, EventArgs e)
        {
            
            this.ClientSize = new System.Drawing.Size(950, 473);
            this.close.Location = new System.Drawing.Point(925, 4);
            shouldDrawGraph = true;
            int[,] adjacencyMatrix = GetAdjacencyMatrix(richTextBox1.Text);
            GetVertexColors(adjacencyMatrix);
            pictureBox1.Invalidate();
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

                int[,] adjacencyMatrix = GetAdjacencyMatrix(richTextBox1.Text);

                bool direct = IsGraphDirected(adjacencyMatrix);

                Graphics g = e.Graphics;

                Pen pen = new Pen(Color.White, 2);

                int pictureBoxWidth = pictureBox1.Width;
                int pictureBoxHeight = pictureBox1.Height;

                int vertexRadius = Math.Min(pictureBoxWidth, pictureBoxHeight) / 10;

                int vertexCount = adjacencyMatrix.GetLength(0);

                PointF[] vertexCenters = new PointF[vertexCount];
                for (int i = 0; i < vertexCount; i++)
                {
                    float x = pictureBoxWidth / 2 + (pictureBoxWidth / 2 - vertexRadius) * (float)Math.Cos(2 * Math.PI * i / vertexCount);
                    float y = pictureBoxHeight / 2 + (pictureBoxHeight / 2 - vertexRadius) * (float)Math.Sin(2 * Math.PI * i / vertexCount);
                    vertexCenters[i] = new PointF(x, y);
                }
                // вершины графа
                for (int i = 0; i < vertexCenters.Length; i++)
                {

                    Brush vertexBrush = new SolidBrush(vertexColors[i]);
                    PointF center = vertexCenters[i];
                    float x = center.X - vertexRadius;
                    float y = center.Y - vertexRadius;
                    g.FillEllipse(vertexBrush, x, y, 2 * vertexRadius, 2 * vertexRadius);

                    // номер вершины внутри вершины
                    string vertexNumber = (i + 1).ToString();
                    SizeF numberSize = g.MeasureString(vertexNumber, vertexFont);
                    float numberX = center.X - numberSize.Width;
                    float numberY = center.Y - numberSize.Height;
                    g.DrawString(vertexNumber, vertexFont, Brushes.White, numberX, numberY);
                }

                // ребра графа
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

                            // стрелка на конце ребра
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
            float arrowSize = 30; // размер стрелки 

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process proc = Process.Start("notepad.exe");
        }
    }
}
