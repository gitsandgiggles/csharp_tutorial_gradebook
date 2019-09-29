using System;
using Xunit;

namespace GradeBook.Tests
{

    public class TypeTests
    {

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            Assert.Equal(3,x);

            SetInt(x);
            Assert.Equal(3,x);

            SetInt(ref x);
            Assert.Equal(42,x);
        }

        private void SetInt(ref Int32 x)
        {
            // int is an alias for the C# struct Int32 , 32 bit sigend integer
            x = 42;
        }

        private void SetInt(Int32 x)
        {
            // int is an alias for the C# struct Int32 , 32 bit sigend integer
            x = 42;
        }


        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name",book1.Name);

        }

        void GetBookSetName(out Book book, string newName)
        {
            // out is like ref except it assumes parameter is uninitialised 
            // and will be initialised in the method. Out is for Output - it's expected to be
            // an ouput of the method.
            book = new Book(newName);
        }
           
        
        
        
        
        
        
        [Fact]
        public void CSharpIsPassByValue ()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");  //book1 value (obj ref) was not changed by the function call

            Assert.Equal("Book 1",book1.Name);

        }

        void GetBookSetName(Book book, string newName)
        {
            book = new Book(newName);
        }
        
        [Fact]
        public void StringsAreClassesButBehaveLikeTypeValues()
        {

            string name = "Liz";
            var upper = MakeUpperCase(name);
            Assert.Equal("Liz", name);
            Assert.Equal("LIZ", upper);

        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
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
