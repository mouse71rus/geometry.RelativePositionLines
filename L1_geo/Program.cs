using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L1_geo
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1, p2, p3, p4;
            double x, y;

            Console.WriteLine("p1: (x1, y1)");
            Console.Write("x1: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y1: ");
            y = Convert.ToDouble(Console.ReadLine());
            p1 = new Point(x, y);
            Console.WriteLine("p1: " + p1.ToString());
            Console.WriteLine();

            Console.WriteLine("p2: (x2, y2)");
            Console.Write("x2: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y2: ");
            y = Convert.ToDouble(Console.ReadLine());
            p2 = new Point(x, y);
            Console.WriteLine("p2: " + p2.ToString());
            Console.WriteLine();

            Console.WriteLine("p3: (x3, y3)");
            Console.Write("x3: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y3: ");
            y = Convert.ToDouble(Console.ReadLine());
            p3 = new Point(x, y);
            Console.WriteLine("p3: " + p3.ToString());
            Console.WriteLine();

            Console.WriteLine("p4: (x4, y4)");
            Console.Write("x4: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y4: ");
            y = Convert.ToDouble(Console.ReadLine());
            p4 = new Point(x, y);
            Console.WriteLine("p4: " + p4.ToString());
            Console.WriteLine();

            Vector v_p1p2 = new Vector(p1, p2);
            Vector v_p3p4 = new Vector(p3, p4);

            double res = v_p1p2.PseudoscalarMultiply(v_p3p4);
            if (res == 0)
            {
                Vector v_p1p3 = new Vector(p1, p3);
                if (v_p1p2.PseudoscalarMultiply(v_p1p3) == 0)
                {
                    Console.WriteLine("Прямые совпадают.");
                }
                else
                {
                    Console.WriteLine("Прямые параллельны.");
                }
            }
            else
            {
                Vector v_p3p1 = new Vector(p3, p1);

                double p1M_length = (v_p3p4.PseudoscalarMultiply(v_p3p1) / res) * v_p1p2.length;

                Point M = new Point(p1M_length, p1, v_p1p2);

                Console.WriteLine("Прямые пересекаются в точке М" + M.ToString());
            }

            Console.ReadKey();
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {
            X = 0.0f;
            Y = 0.0f;
        }
        public Point(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
        public Point(double vector_length, Point p, Vector v)
        {
            X = p.X + ((v.p * vector_length) / v.length);
            Y = p.Y + ((v.q * vector_length) / v.length);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }

    public class Vector
    {
        public double p;
        public double q;
        public double length
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.p, 2) + Math.Pow(this.q, 2));
            }
        }
        public Vector(Point p1, Point p2)
        {
            this.p = p2.X - p1.X;
            this.q = p2.Y - p1.Y;
        }

        
        //Псевдоскалярное произведение векторов
        public double PseudoscalarMultiply(Vector v2)
        {
            return this.p * v2.q - v2.p * this.q;
        }


    }

}
