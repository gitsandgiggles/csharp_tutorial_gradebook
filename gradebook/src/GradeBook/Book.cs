using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        private List<double> grades;
        private string name;   
        private Statistics stats;
        bool hasStats;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
            stats = new Statistics();
            stats.Average = 0.0;
            stats.High = double.MinValue;
            stats.Low = double.MaxValue;
            hasStats = false;
        }

        public void AddGrade(double g)
        {
            grades.Add(g);
        }

        public void ShowStatistics()
        {
            if (!hasStats) {
                calcStats();
            }
            writeStats();
        }

        private void calcStats()
        {
            foreach(double grade in grades)
            {
                stats.High = Math.Max(stats.High, grade);
                stats.Low = Math.Min(stats.Low, grade);
                stats.Average += grade;
            }
            stats.Average /= grades.Count;
            hasStats = true;
        }

        public Statistics GetStatistics()
        {
            if (!hasStats) {
                calcStats();
            }
            return stats;

        }

        private void writeStats()
        {
            if (hasStats)
            {
                Console.WriteLine($"average is {stats.Average:N1}");
                Console.WriteLine($"highest grade is {stats.High:N1}");
                Console.WriteLine($"lowest grade is {stats.Low:N1}");
            }
            else
            {
                Console.WriteLine("No stats have been calculated");
            }
        }
    }

    

}

         




            
