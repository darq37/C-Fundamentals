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
         book.AddGrade(0.7);
         book.AddGrade(1.4);
         book.AddGrade(2.2);
         book.AddGrade(6);

         book.ShowStats();
         



        }
    }
}
