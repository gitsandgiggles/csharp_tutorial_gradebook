using System;
using System.Collections.Generic;

namespace GradeBook
{    
    class Program
    {
        static void Main(string[] args)
        {
            
            // test 2 for VSC and github
            var book = new Book("Liz's grade book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.ShowStatistics();           
        }
    }
}
