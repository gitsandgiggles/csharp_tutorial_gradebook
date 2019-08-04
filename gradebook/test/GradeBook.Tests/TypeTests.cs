using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void CSharpIsPassByValue ()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1",book1.Name);

        }

        void GetBookSetName(Book book, string newName)
        {
            book = new Book(newName);
        }
        
        
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name",book1.Name);

        }

        void SetName(Book book, string newName)
        {
            book.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1,book2);

        }
        
        [Fact]
        public void TwoVarsCanRefrenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));

        }
        Book GetBook(string name)
        // default visibility is private
        {
            return new Book(name);
        }
    }
}
