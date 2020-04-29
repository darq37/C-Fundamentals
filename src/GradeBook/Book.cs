using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        private string name { get; set; }
        private List<double> grades;
        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }


        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public void ShowStats()
        {
            var stats = GetStatistics();
            System.Console.WriteLine($"Average grade: {stats.Average:F2}");
            System.Console.WriteLine($"Lowest grade: {stats.Low}");
            System.Console.WriteLine($"Highest grade: {stats.High:F2}");
            System.Console.WriteLine($"Letter: {stats.Letter}");
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach (double grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }

            return result;

        }
    }
}