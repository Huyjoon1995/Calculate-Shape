using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalculateShape
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Tuple<string, double>> result = GetAllArea();
            PrintResult(result);
        }

        /// <summary>
        /// Evaluate if the dimension being used is correct (none zero & none negative value)
        /// </summary>
        /// <param name="value">dimension of the area</param>
        /// <returns></returns>
        public static bool IsCorrectDimension(double value)
        {
            if(value == 0 || value < 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Print out the shape and their respective area
        /// </summary>
        /// <param name="list">list of tuple that contains the shape and its respective area</param>
        public static void PrintResult(List<Tuple<string, double>> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item.Item1 + " " + item.Item2);
            }
        }

        /// <summary>
        /// Calculate the area for each shape and store it in a list of tuple
        /// </summary>
        /// <returns>list of tuple</returns>
        public static List<Tuple<string, double>> GetAllArea()
        {
            string path = @"c:\text.txt";
            
            string line = "";

            List<Tuple<string, double>> myList = new List<Tuple<string, double>>();

            StreamReader file;
            try
            {
                file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Split(" ");
                    string type = arr[0];
                    switch (type)
                    {
                        case "rectangle":
                            if (IsCorrectDimension(Convert.ToDouble(arr[1])) && IsCorrectDimension(Convert.ToDouble(arr[2])))
                            {
                                Shape r = new Rectangle(Convert.ToDouble(arr[1]), Convert.ToDouble(arr[2]));
                                myList.Add(Tuple.Create<string, double>("rectangle", r.Area()));
                            }
                            break;
                        case "triangle":
                            if (IsCorrectDimension(Convert.ToDouble(arr[1])) && IsCorrectDimension(Convert.ToDouble(arr[2])))
                            {
                                Shape t = new Triangle(Convert.ToDouble(arr[1]), Convert.ToDouble(arr[2]));
                                myList.Add(Tuple.Create<string, double>("triangle", t.Area()));
                            }
                            break;
                        case "circle":
                            if (IsCorrectDimension(Convert.ToDouble(arr[1])))
                            {
                                Shape c = new Circle(Convert.ToDouble(arr[1]));
                                myList.Add(Tuple.Create<string, double>("circle", c.Area()));
                            }
                            break;
                        case "square":
                            if (IsCorrectDimension(Convert.ToDouble(arr[1])))
                            {
                                Shape s = new Square(Convert.ToDouble(arr[1]));
                                myList.Add(Tuple.Create<string, double>("square", s.Area()));
                            }
                            break;
                        default:
                            break;
                    }
                }
                file.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + ":  Error while attempting to read file - " + path + ". The error is - " + ex.ToString());
            }

            myList = myList.OrderByDescending(i => i.Item2).ToList();

            return myList;
        }
    }
}
