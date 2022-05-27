using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab5
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            //1)
            Student student = new Student(new Person("Taras","Shevchenko",new DateOnly(2001,1,1)), Education.Master, 201);

            WriteLine(student.DeepCopy());
            //2)
            WriteLine("Введіть назву файлу, в який ви хочете записати дані про об'єкт:");
            student.Save(ReadLine());
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            Student student2 = new Student();
            student2.Load(ReadLine());
            WriteLine(student2);

            //3)
            student.AddFromConsole();
            WriteLine("Введіть назву файлу, в який ви хочете записати дані про об'єкт:");
            student.Save(ReadLine());
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            student.Load(ReadLine());
        

            //4)
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            Student.Load(ReadLine(), student);
            student.AddFromConsole();
            WriteLine("Введіть назву файлу, в який ви хочете записати дані про об'єкт:");
            Student.Save(ReadLine(), student);
            WriteLine("Введіть назву файлу, з якого ви хочете зчитати дані про об'єкт:");
            Student.Load(ReadLine(), student);



        }
    }
}
