using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
        public class Exam : IDateAndCopy
        {
            private string _nameSubject;
            private int _grade;
            private DateOnly _dateExam;

            public string NameSubject
            {
                get
                {
                    return _nameSubject;
                }

                set
                {
                    _nameSubject = value;
                }
            }

            public int Grade
            {
                get
                {
                    return _grade;
                }

                set
                {
                    _grade = value;
                }
            }


            object IDateAndCopy.DeepCopy()
            {
                return MemberwiseClone();
            }

            public DateOnly Date
            {
                get
                {
                    return _dateExam;
                }

                set
                {
                    _dateExam = value;
                }
            }

            public Exam(string nameSubject, int grade, DateOnly dateExam)
            {
                NameSubject = nameSubject;
                Grade = grade;
                Date = dateExam;
            }

            public Exam() : this(nameSubject: "English language", grade: 4, dateExam: new DateOnly(2020, 12, 19)) { }

            public override string ToString()
            {
                return $"\nSubject: {NameSubject}\nGrade: {Grade} \nDate exam: {Date}\n";
            }

            public override bool Equals(object? obj)
            {
                if (obj == null) return false;
                Exam exam = (Exam)obj;

                return exam.NameSubject == NameSubject && exam.Grade == Grade && exam.Date == Date;
            }

            public static bool operator ==(Exam exam1, Exam exam2)
            {
                return exam1.Equals(exam2);
            }

            public static bool operator !=(Exam exam1, Exam exam2)
            {
                return !(exam1 == exam2);
            }

            public override int GetHashCode()
            {
                return NameSubject.GetHashCode() * 13 + Grade.GetHashCode() * 17 + Date.GetHashCode() * 19;
            }
        }

}
