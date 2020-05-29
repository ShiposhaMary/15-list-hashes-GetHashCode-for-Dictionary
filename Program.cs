using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHashCode_for_Dictionary
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return X == point.X && Y == point.Y;
        }
        public override int GetHashCode()
        {
            unchecked                  //При вычислении хеш - функции разумно всегда игнорировать переполнение.
                                       // Это можно сделать, обернув вычисление хеш - функции в конструкцию unchecked
            {                                                            
                return X * 1023 + Y;                                     
            }                                            
        }
    }

    public class Program
    {
        static void Main()
        {
            var point1 = new Point { X = 1, Y = 1 };
            var dictionary = new Dictionary<Point, string>();
            dictionary[point1] = "Test";
            Console.WriteLine(dictionary[point1]);
            var point2 = new Point { X = 1, Y = 1 };
            Console.WriteLine(dictionary[point2]);
            Console.ReadKey();
        }
    }
}
