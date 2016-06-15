using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        private List<float> grades;
        public GradeBook() {
            grades = new List<float>();
            name = "Hi!";
        }

        public GradeStatistics ComputeStatistics() {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach(float grade in grades)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public string Name {
            get {
                return name;
            }
            set {
                if (String.IsNullOrEmpty(value)) {
                    return;
                }
                if(name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = name;
                    args.NewName = value;
                    NameChanged(this, args);
                }
                name = value;
            }
        }
        public event NameChangedDelegate NameChanged;
        private string name;
    }
}
