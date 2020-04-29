using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {

        public string Name { get;  private set; }
        private List<double> grades;


        public Book(string name)
        {
            
            this.Name = name;
            grades = new List<double>();
        }



        public void AddGrade(char letter)
        {
            
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public event GradeAddedDelegate GradeAdded;

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