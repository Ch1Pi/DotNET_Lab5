using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class StudentComparer : IComparer<Student>
    {
        public int Compare(Student? student1, Student? student2)
        {

            if (student1 == null && student2 == null)
            {
                return 0;
            }
            else if (student1! != null && student2! != null)
            {
                return student1.AverageGrade.CompareTo(student2.AverageGrade);
            }

            else if (student1 == null && student2 != null)
            {
                return -1;
            }

            else if (student1 != null && student2 == null)
            {
                return 1;
            }



            return 0;
        }
    }
}
