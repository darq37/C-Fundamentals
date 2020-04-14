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
            grades = new List<double> { };
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        internal void ShowStats()
        {
            var stats = GetStatistics();
            System.Console.WriteLine($"Average grade: {stats.Average:F2}");
            System.Console.WriteLine($"Lowest grade: {stats.Low}");
            System.Console.WriteLine($"Highest grade: {stats.High:F2}");
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;

        }
    }
}