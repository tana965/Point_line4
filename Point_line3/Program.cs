using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Security.AccessControl;

namespace point_line1


{

    //interface IComparable
    //{
    //    bool Equals(object p);
    //    int GetHashCode();
    //}
    class Point : IComparable
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(int x)
        {
            X = x;
            Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X} : {Y})";
        }

        public override bool Equals(object p)
        {
            Point temp = (Point)p;
            if (this.X == temp.X && this.Y == temp.Y)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a.Equals(b));
        }
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }

    class ColoredPoint : Point
    {
        private string Color;
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ColoredPoint():base()
        {
            Color = "red";
        }

            

        public ColoredPoint(int x, int y, string col) : base(x, y)
        {
            Color = col;
        }
        public override string ToString()
        {
            return $"({X} : {Y}) Color= {Color}\n";
        }
        public override bool Equals(object p)
        {
            ColoredPoint temp = (ColoredPoint)p;
            if (this.X == temp.X && this.Y == temp.Y && this.Color == temp.Color)
                return true;
            else
                return false;
        }
        public static bool operator ==(ColoredPoint a, ColoredPoint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ColoredPoint a, ColoredPoint b)
        {
            return !(a.Equals(b));
        }
    }

    class MultiAngle : Point
    {
        protected Point[] Points = new Point[100];
        protected int Angles = 0;
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public MultiAngle()
        {
            Points[0] = new Point(0, 0);
            Angles = 1;
        }
        public MultiAngle(params Point[] p)
        {
            Array.Copy(p, Points, p.Length);
            Angles = p.Length;
        }

        public override string ToString()
        {
            string s;
            if (Angles == 2)
                s = "Линия: \n";
            else
                s = $"{Angles}-угольник: \n";
            for (int i = 0; i < Angles; i++)
                s += Points[i].ToString();

            return s;
        }
        public override bool Equals(object p)
        {
            bool Check = true;
            MultiAngle temp = (MultiAngle)p;
            if (Angles == temp.Angles)
            {
                for (int i = 0; i < Angles; i++)
                {
                    if (!this.Points[i].Equals(temp.Points[i]))
                        Check = false;
                }
            }
            return Check;
        }
        public static bool operator ==(MultiAngle a, MultiAngle b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(MultiAngle a, MultiAngle b)
        {
            return !(a.Equals(b));
        }

        public void MoveToX(int x)
        {
            for (int i = 0; i < Angles; i++)
                Points[i] = new Point(Points[i].X + x, Points[i].Y);
        }

        public void MoveToY(int y)
        {
            for (int i = 0; i < Angles; i++)
                Points[i] = new Point(Points[i].X, Points[i].Y + y);
        }

        public void Move(int x, int y)
        {
            for (int i = 0; i < Angles; i++)
                Points[i] = new Point(Points[i].X + x, Points[i].Y + y);
        }
    }

    class ColoredLine : MultiAngle
    {
        private string Color;
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public ColoredLine(params Point[] p)
        {
            Array.Copy(p, Points, p.Length);
            Angles = p.Length;

        }
        public ColoredLine(string col, params Point[] p)
        {
            Array.Copy(p, Points, p.Length);
            Angles = p.Length;
            Color = col;
        }
        public override string ToString()
        {
            string s;
            if (Angles == 2)
                s = "Линия: \n";
            else
                s = $"{Angles}-угольник: \n";
            for (int i = 0; i < Angles; i++)
                s += Points[i].ToString();
            s += "Color= " + Color;
            return s;
        }
        public override bool Equals(object p)
        {
            bool Check = true;
            ColoredLine temp = (ColoredLine)p;
            if (Angles == temp.Angles)
            {
                for (int i = 0; i < Angles; i++)
                {
                    if (!this.Points[i].Equals(temp.Points[i]))
                        Check = false;
                }
            }
            if (this.Color != temp.Color)
                Check = false;
            return Check;
        }
        public static bool operator ==(ColoredLine a, ColoredLine b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ColoredLine a, ColoredLine b)
        {
            return !(a.Equals(b));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("введите 2 точки:");
            int s = int.Parse(Console.ReadLine());
            int s2 = int.Parse(Console.ReadLine());
            int s3 = int.Parse(Console.ReadLine());
            int s4 = int.Parse(Console.ReadLine());
            Point p = new Point(s, s2);
            Point p1 = new Point(s3, s4);
            Console.WriteLine("--------------------\n");
            Console.WriteLine("\nСложение точек: ");
            Console.WriteLine(p.ToString() + " + " + p1.ToString());
            Point p2 = p + p1;
            Console.WriteLine("Ответ: " + p2.ToString());
            Console.WriteLine("--------------------\n");
            Console.WriteLine("\nСравнение линий:\n");
            Console.WriteLine("--------------------");
            Console.WriteLine("Введите ещё 2 точки");

            int s5 = int.Parse(Console.ReadLine());
            int s6 = int.Parse(Console.ReadLine());
            int s7 = int.Parse(Console.ReadLine());
            int s8 = int.Parse(Console.ReadLine());
            Point g4 = new Point(s5, s6);
            Point g5 = new Point(s7, s8);
            Console.WriteLine("--------------------\n");

            MultiAngle l = new MultiAngle(p, p1);
            MultiAngle l1 = new MultiAngle(g4, g5);
            Console.WriteLine(l.ToString());
            Console.WriteLine(l1.ToString());
            Console.WriteLine(l == l1);
            Console.WriteLine("--------------------");
            Console.WriteLine("\nЦветная линия: ");
            Console.WriteLine("--------------------");
            Console.WriteLine("Введите цвет линии:");
            string s17 = Console.ReadLine();
            Console.WriteLine("--------------------");
            ColoredLine cl = new ColoredLine(s17, p, p1);
            Console.WriteLine(cl.ToString());
            Console.WriteLine("--------------------");
            Console.WriteLine("\nЦветная точка:");
            Console.WriteLine("--------------------");
            Console.WriteLine("Введите цвет точки :");

            string s18 = Console.ReadLine();
            Console.WriteLine("--------------------\n");
            Console.WriteLine("Введите точку:");
            int s20 = int.Parse(Console.ReadLine());
            int s21 = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------------");
            ColoredPoint cp = new ColoredPoint(s20, s21, s18);
            Console.WriteLine(cp.ToString());
            Console.WriteLine("--------------------");
            Console.WriteLine("\nМногоугольник:");
            Console.WriteLine("--------------------");
            Console.WriteLine("Введите точки для триугольника:");

            int s16 = int.Parse(Console.ReadLine());
            int s11 = int.Parse(Console.ReadLine());
            int s12 = int.Parse(Console.ReadLine());
            int s13 = int.Parse(Console.ReadLine());
            int s14 = int.Parse(Console.ReadLine());
            int s15 = int.Parse(Console.ReadLine());

            Point g6 = new Point(s16, s11);
            Point g7 = new Point(s12, s13);
            Point g8 = new Point(s14, s15);

            MultiAngle m = new MultiAngle(g6, g7, g8);
            Console.WriteLine(m.ToString());
            Console.WriteLine("--------------------");
            Console.WriteLine("Перемещение многоугольника");
            Console.WriteLine("--------------------");
            Console.WriteLine("Введите насколько переместить многоугольник 2 точки:");
            int s9 = int.Parse(Console.ReadLine());
            int s10 = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------------");
            Console.WriteLine("\nМногоугольник перемещён:");
            m.Move(s9, s10);
            Console.WriteLine(m.ToString());
            Console.WriteLine("--------------------");
        }
    }
}
