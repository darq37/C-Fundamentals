using System;
using Xunit;
using GradeBook;


namespace Gradebook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookDoesNotReturnSameObject()
        {
            var book1 = GetBook("Book_1");
            var book2 = GetBook("Book_2");
            
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void ShouldPassByValue()
        {
            var x = GetThree();
            Assert.Equal(3, x);
        }
        [Fact]
        public void ShouldPassByReference()
        {
            var x = GetThree();
            SetToFourtyTwo(ref x);
            // passing by reference change the original value of x
            //Objects are always passed by reference
            // Basic Types are passed by values
            // Structs behave liek basic types, they are passed by value as well
            Assert.Equal(42, x);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private String MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        private int GetThree()
        {
            return 3;
        }

        private void SetToFourtyTwo(ref int x)
        {
            x = 42;
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }


    }
}
