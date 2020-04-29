using System;
using System.Collections.Generic;
using System.Globalization;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Book book = new Book("My book");

            while (true)
            {
                System.Console.WriteLine("Write a value to add to the book or q to quit");
                var input = Console.ReadLine();
                if (input =="q")
                {
                    System.Console.WriteLine("Thank you:");
                    break;
                }

                try
                { 
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch( FormatException FormatException){
                    System.Console.WriteLine(FormatException.Message);
                }
                finally{
                    System.Console.WriteLine("**");
                }
                
            }

            book.ShowStats();


        }
    }
}
