using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {


            GradeBook book = new GradeBook();

            book.NameChanged += OnNameChange;
            book.NameChanged += new NameChangedDelegate(OnNameChange);
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            WriteResults("Average", stats.AverageGrade);
            WriteResults("Highest", stats.HighestGrade);
            WriteResults("Lowest", stats.LowestGrade);
            book.Name = "Book!";
            Console.WriteLine(book.Name);
            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.HighestGrade);
        }

        static void OnNameChange(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }


        private static void WriteResults(string description, float result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }

        private static void WriteResults(string description, int result)
        {
            Console.WriteLine("${description}: {result}");
        }
    }
}
