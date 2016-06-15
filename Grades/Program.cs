using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ages = { 2, 21, 40, 72, 100 };
            foreach (int value in ages)
            {
                Console.WriteLine(value);
            }

            GradeBook book = new GradeBook();

            AddGrades(book);
            GetBookName(book);

            SaveGrades(book);

            WriteResults(book);
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResults("Average", stats.AverageGrade);
            WriteResults("Highest", stats.HighestGrade);
            WriteResults("Lowest", stats.LowestGrade);
            WriteResults(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
            //StreamWriter outputFile =  File.CreateText("grades.txt");
            // book.WriteGrades(outputFile);
            // outputFile.Close();
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Someting went wrong");
            }
        }

        private static void WriteResults(string description, string result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }

        private static void WriteResults(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
        }
    }
}
