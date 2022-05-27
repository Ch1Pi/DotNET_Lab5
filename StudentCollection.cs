using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class StudentCollection
    {
        private List<Student>? _students;


        public void Add(Student student)
        {
            if (_students == null)
            {
                _students = new List<Student>();
            }
            _students.Add(student);
          
        }

        public void AddDefaults()
        {

            Add(new Student());
            Add(new Student(new Person("Oleh", "Arnenko", new DateOnly(2005, 09, 29)), Education.Master, 205) { Exams = new List<Exam>() { new Exam(), new Exam("Programming", 2, new DateOnly(2021, 6, 3)) } });
        }

        public void AddStudents(Student[] students)
        {


            int j = 0;
            while (j < students.Length)
            {
                Add(students[j]);
                j++;
            }
        }
 
   


        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            if (_students != null)
            {

                foreach (Student stud in _students)
                {
                    res.Append($"Info about student:\n{stud.Person}\nEducation: {stud.Educate}\nGroup: {stud.Group}\n\nList exams:\n\n");
                    if (stud.Exams != null)
                    {
                        foreach (Exam ex in stud.Exams)
                        {
                            res.Append(ex);
                        }
                    }

                    res.Append("\nList zaliks:\n\n");

                    if (stud.Tests != null)
                    {
                        foreach (Test test in stud.Tests)
                        {
                            res.Append(test);
                        }
                    }

                    res.Append("\n");
                }

                return $"Info about all students:\n{res}";
            }

            else
            {
                return "List is null";
            }
        }

        public string ToShortString()
        {
            StringBuilder res = new StringBuilder();

            if (_students != null && _students.Count != 0)
            {
                foreach (Student stud in _students)
                {
                    res.Append($"Info about student:\n{stud.Person}\nEducation: {stud.Educate}\nGroup: {stud.Group}\nAverage grade: {stud.AverageGrade}\nNumber tests: ");
                    if (stud.Tests == null)
                    {
                        res.Append("0\nNumber exams: ");
                    }
                    else
                    {
                        res.Append($"{stud.Tests.Count}\nNumber exams: ");
                    }

                    if (stud.Exams == null)
                    {
                        res.Append("0\n\n");
                    }
                    else
                    {
                        res.Append($"{stud.Exams.Count}\n\n");
                    }

                }

                return $"Info about students: {res}";
            }
            else
            {
                return "List is null";
            }
        }

        public void SortBySurname()
        {

            if (_students != null)
            {
                _students.Sort();
            }
        }

        public void SortByDate()
        {
            if (_students != null)
            {
                _students.Sort(new Person());
            }
        }

        public void SortByGrade()
        {
            if (_students != null)
            {
                _students.Sort(new StudentComparer());
            }
        }

        public double MaxGrade
        {
            get
            {
                if (_students == null || _students.Count == 0)
                {
                    return 0;
                }

                else
                {
                    return _students.Max(x => x.AverageGrade);

                }
            }
        }

        public IEnumerable<Student> TypeEducation
        {
            get
            {
                if (_students == null || _students.Count == 0)
                {
                    return Enumerable.Empty<Student>();
                }
                return _students.Where(student => student.Educate == Education.Master);

            }
        }

        public List<Student> AverageMarkGroup(double mark)
        {




            return (_students?.GroupBy(stud => stud.AverageGrade).FirstOrDefault(x => x.Key == mark) ?? Enumerable.Empty<Student>()).ToList(); ;



        }
    }
}
