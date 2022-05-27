using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab5
{
        public class Student : Person, IDateAndCopy
        {
            private Education _education;
            private int _group;
            private List<Exam>? _exams;
            private List<Test>? _tests;

            public Student(Person person, Education education, int group)
            {
                Person = person;
                Educate = education;
                Group = group;

            }

            public Student() : this(person: new Person(), education: Education.Bachelor, group: 101)
            {
                Exams = new List<Exam>() { new Exam(), new Exam("Programming", 5, new DateOnly(2021, 6, 3)) };
                Tests = new List<Test>() { new Test(), new Test("C++", false), new Test("Java", true) };
            }


            public Person Person
            {
                get
                {
                    return new Person(Name, Surname, Date);
                }

                set
                {
                    Name = value.Name;
                    Surname = value.Surname;
                    Date = value.Date;
                }

            }


            public Education Educate
            {
                get
                {
                    return _education;
                }

                set
                {
                    _education = value;
                }
            }

            public int Group
            {
                get
                {
                    return _group;
                }

                set
                {
                    if (value <= 100 || value > 699)
                    {
                        throw new Exception("Number group must be more than 100 and less than 700");
                    }

                    _group = value;
                }
            }

            public List<Exam>? Exams
            {
                get
                {
                    return _exams;
                }

                set
                {
                    _exams = value;
                }
            }

            public List<Test>? Tests
            {
                get
                {
                    return _tests;
                }

                set
                {
                    _tests = value;
                }
            }

            public double AverageGrade
            {
                get
                {
                    double average = 0;
                    if (Exams == null || Exams.Count == 0) return 0;
                    foreach (Exam exam in Exams)
                    {
                        average += exam.Grade;
                    }
                    return average / Exams.Count;
                }
            }

            public bool this[Education educate]
            {
                get
                {
                    return educate == Educate;
                }
            }

            public void AddExams(Exam[] newExams)
            {
                if (Exams == null)
                {
                    Exams = new List<Exam>();
                }

                int j = 0;
                while (j < newExams.Length)
                {
                    Exams.Add(newExams[j]);
                    j++;
                }
            }

            public void AddTests(Test[] newTests)
            {

                if (Tests == null)
                {
                    Tests = new List<Test>();
                }

                int j = 0;
                while (j < newTests.Length)
                {
                    Tests.Add(newTests[j]);
                    j++;
                }
            }

            public override string ToString()
            {

                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();

                if (Exams != null)
                {
                    foreach (Exam ex in Exams)
                    {
                        sb.Append(ex);
                    }
                }

                if (Tests != null)
                {
                    foreach (Test test in Tests)
                    {
                        sb1.Append(test);
                    }
                }

                return $"Info about student:\n{Person}\nEducation: {Educate}\nGroup: {Group}\n\nList exams:\n\n{sb}\nList zaliks:\n\n{sb1}\n";
            }


        public Student DeepCopy()
        {
       
            using (MemoryStream memory = new MemoryStream())
            {
                XmlSerializer XML = new XmlSerializer(typeof(Student));
                XML.Serialize(memory, this);
                memory.Seek(0, SeekOrigin.Begin);
                Student student = (Student)XML.Deserialize(memory);
                return student;
            }

        }
          public bool Save(string filename)
            {

            try
            {
                if (!File.Exists(filename)) { Console.WriteLine("Вказаного файлу не існує, тому його було створено"); }
                using (FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(Student));
                    XML.Serialize(fileStream, this);
                }
                Console.WriteLine("Серіалізація відбулася успішно");
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Помилка при запису об'єкта у файл\n{e}\n");
                return false;
            }
               
           }

            public bool Load(string filename)
        {
            try
            {
                if (!File.Exists(filename)) { Console.WriteLine("Вказаного файлу не існує"); }
                using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(Student));

                    Student student = (Student)XML.Deserialize(fileStream);
                    Educate = student.Educate;
                    Person = student.Person;
                    Group = student.Group;
                    Exams = student.Exams;
                    Tests = student.Tests;
                    return true;

                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Помилка при десеріалізації\n{e}\n");
                return false;
            }
        }

        public static bool Save(string filename, Student student)
        {
            return student.Save(filename);
        }

        public static bool Load(string filename, Student student)
        {
            return student.Load(filename);
        }

        public bool AddFromConsole()
        {
           Console.WriteLine("Введіть назву предмету, оцінку та дату екзамену формату yyyy-mm-dd.\nВ якості розділювачів використовуйте символ ','");
           string[] information = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string nameSubject = information[0];
                int grade = Convert.ToInt32(information[1]);
                DateOnly dateExam = DateOnly.Parse(information[2]);
                AddExams(new Exam[] { new Exam(nameSubject, grade, dateExam) });
                Console.WriteLine("Предмет додано успішно");
                return true;
            }     
            catch(Exception e)
            {
                Console.WriteLine($"Увага! Допущені помилки при введені\n{e}\n");
                return false;
            }
        }
    
      
            public List<object> AllExamsAndTests()
            {
                List<object> temp = new List<object>();

                if (Exams != null)
                {
                    foreach (Exam exam in Exams)
                    {
                        temp.Add(exam);
                    }
                }

                if (Tests != null)
                {
                    foreach (Test test in Tests)
                    {
                        temp.Add(test);
                    }
                }
                return temp;

            }

            public List<Exam> AllGoodExams(int grade)
            {

                List<Exam> temp = new List<Exam>();

                if (Exams != null)
                {
                    foreach (Exam exam in Exams)
                    {
                        if (exam.Grade > grade)
                        {
                            temp.Add(exam);
                        }
                    }
                }

                return temp;
            }



            public new string ToShortString()
            {
                return $"Info about student:\n{Person}\nEducation: {Educate}\nGroup: {Group}\nAverage grade: {AverageGrade}\n";
            }

            public override bool Equals(object? obj)
            {
                if (obj == null) return false;
                Student student = (Student)obj;
                if (Exams != null && student.Exams != null)
                {
                    if (Exams.Count != student.Exams.Count) return false;

                    int i = 0;
                    while (i < Exams.Count && Exams[i] != null && student.Exams[i] != null && Exams[i] == student.Exams[i])
                    {
                        i++;

                    }
                    if (i < Exams.Count) return false;
                    return student.Person == Person && student.Educate == Educate && student.Group == Group && student.Exams == Exams;
                }
                else
                {
                    return false;
                }
            }

            public static bool operator ==(Student student1, Student student2)
            {

                return student1.Equals(student2);

            }

            public static bool operator !=(Student student1, Student student2)
            {
                return !(student1 == student2);
            }

            public override int GetHashCode()
            {
                int sum = 0;
                foreach (object obj in AllExamsAndTests())
                {
                    sum += obj.GetHashCode();
                }
                return Person.GetHashCode() * 13 + Educate.GetHashCode() * 17 + Group.GetHashCode() * 19 + sum;
            }
        }
}
