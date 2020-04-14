using System;
using Xunit;
using GradeBook;


namespace Gradebook.Tests
{
    public class BookTest
    {
        [Fact] // An XUnit attribute. Annotation like @Test in JUnit
        public void Test1()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(90.1);
            book.AddGrade(75.6);
            book.AddGrade(9.8);
            //act
            var result = book.GetStatistics();
            
            
            //assert
           Assert.Equal(58.5, result.Average, 1);
           Assert.Equal(90.1, result.High, 1);
           Assert.Equal(9.8, result.Low, 1);
        }
    }
}
