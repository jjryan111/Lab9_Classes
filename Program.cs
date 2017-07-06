using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class CircleApp
    {
        public CircleApp (double radius)
        {
            Circle c = new Circle(radius);
            string finalCirc = c.GetFormattedCicumference();
            string finalArea = c.GetFormattedArea();
            Console.WriteLine("Area: {0}   Circumference: {1}", finalArea, finalCirc);

        }
    }
    public class Circle
    {
        private double radius; 
        private double circumference;
        private double area;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetCircumference()
        {
            circumference = (radius * 2) * Math.PI;
            return circumference;
        }

        public string GetFormattedCicumference()
        {
            circumference = GetCircumference();
            string fcircum = string.Format("{0, 0:F2}", circumference);
            return fcircum;
        }

        public double GetArea()
        {
            area = Math.Pow(radius, 2) * Math.PI;
            return area;
        }

        public string GetFormattedArea()
        {
            area = GetArea();
            string farea = string.Format("{0, 0:F2}", area);
            return farea;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string yesNo = "y";
            int numCirc = 0;
            Console.WriteLine("Welcome to the Circle Tester!");
            while (yesNo == "y")
            {
                numCirc++;
                double radius = GetInput("Enter radius: ", "Cicles must have a radius greater than 0!", 0, int.MaxValue);
                CircleApp c = new CircleApp(radius);
                yesNo = ynInput();
            }
            Console.WriteLine("You created " + numCirc + " circle(s).");
        }

        public static double GetInput(string question, string error, int bottomNum, int topNum)
        {
            bool validInput = false;
            double exitNum = 0;
            while (!validInput)
            {
                Console.Write(question);
                bool inp = double.TryParse(Console.ReadLine(), out exitNum);
                if (!inp || exitNum <= bottomNum || exitNum > topNum)
                {
                    Console.WriteLine(error);
                }
                else
                {
                    validInput = true;
                }
            }
            return exitNum;
        }

        public static string ynInput()
        // Gets a y or n.
        {
            string input = "";
            bool invalid = true;
            while (invalid)
            {
                Console.Write("\nAnother circle? (y/n): ");
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "y" || input == "n")
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter y or n.");
                }
            }
            return input;
        }
    }
}
