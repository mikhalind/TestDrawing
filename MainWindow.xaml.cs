using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestDrawing
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // случайный цвет для фигур
        public SolidColorBrush GetRandomColor()
        {
            Random rand = new Random();
            return new SolidColorBrush(Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256)));
        }

        // случайные величины для размеров фигур
        public double GetRandomValue(int min, int max) => new Random().Next(min, max);

        // очищение поля
        public void ClearCanvas() => canvas.Children.Clear();

        public void DrawTriangle(double radius, double x, double y)
        {
            // инициализация
            Polygon triang = new Polygon();
            triang.Fill = GetRandomColor();

            // выставление углов
            triang.Points.Add(new Point(x - radius, y));
            triang.Points.Add(new Point(x + 0.4472 * radius, y + 0.8944 * radius));
            triang.Points.Add(new Point(x + 0.4472 * radius, y - 0.8944 * radius));

            // поворот фигуры
            triang.RenderTransform = new RotateTransform(new Random().Next(0, 180), x, y);

            // добавление на canvas, позиционирование
            canvas.Children.Add(triang);
            Canvas.SetLeft(triang, 0);
            Canvas.SetTop(triang, 0);
        }

        public void DrawRect(double x, double y)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = GetRandomColor();
            rect.Width = GetRandomValue(10, 75);
            rect.Height = GetRandomValue(10, 100);

            rect.RenderTransform = new RotateTransform(new Random().Next(0, 180), rect.Width / 2, rect.Height / 2);

            canvas.Children.Add(rect);
            Canvas.SetLeft(rect, x - rect.Width / 2);
            Canvas.SetTop(rect, y - rect.Height / 2);
        }

        public void DrawStar(double radius, double x, double y)
        {
            Polygon star = new Polygon();
            star.Fill = GetRandomColor();

            star.Points.Add(new Point(x - radius, y));
            star.Points.Add(new Point(x - 0.31 * radius, y + 0.22 * radius));
            star.Points.Add(new Point(x - 0.31 * radius, y + 0.95 * radius));
            star.Points.Add(new Point(x + 0.12 * radius, y + 0.36 * radius));
            star.Points.Add(new Point(x + 0.81 * radius, y + 0.59 * radius));
            star.Points.Add(new Point(x + 0.38 * radius, y));
            star.Points.Add(new Point(x + 0.81 * radius, y - 0.59 * radius));
            star.Points.Add(new Point(x + 0.12 * radius, y - 0.36 * radius));
            star.Points.Add(new Point(x - 0.31 * radius, y - 0.95 * radius));
            star.Points.Add(new Point(x - 0.31 * radius, y - 0.22 * radius));

            star.RenderTransform = new RotateTransform(new Random().Next(0, 180), x, y);

            canvas.Children.Add(star);
            Canvas.SetLeft(star, 0);
            Canvas.SetTop(star, 0);
        }

        public void DrawCircle(double x, double y)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = GetRandomColor();
            ellipse.Width = GetRandomValue(10, 75);
            ellipse.Height = GetRandomValue(10, 75);

            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, x - ellipse.Width / 2);
            Canvas.SetTop(ellipse, y - ellipse.Height / 2);
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // позиция курсора
            Point p = e.GetPosition(this);

            // отрисовка фигуры в зависимости от активной radiobutton (switch .. case ?)
            if (RBtnCircle.IsChecked == true) DrawCircle(p.X, p.Y);
            else if (RBtnRect.IsChecked == true) DrawRect(p.X, p.Y);
            else if (RBtnTriangle.IsChecked == true) DrawTriangle(GetRandomValue(10, 75), p.X, p.Y);
            else if (RBtnHex.IsChecked== true) DrawStar(GetRandomValue(10, 75), p.X, p.Y);
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e) => ClearCanvas();
    }
}
