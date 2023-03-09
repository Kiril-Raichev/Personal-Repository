using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        class Student
        {
            public int Id { get; }
            public string Name { get; }

            public Student(int id,string name)
            {
                this.Id = id;
                this.Name = name;
            }
            public static HashSet<Student> GetCommonStudents(List<Student> l1,List<Student>l2)
            {
                HashSet<Student> hSet = new HashSet<Student>();
                foreach(var el in l1)
                {
                    foreach(var el2 in l2)
                    {
                        if (!string.IsNullOrWhiteSpace(el.Name) && !string.IsNullOrWhiteSpace(el2.Name))
                        {
                            if (el.Name.Equals(el2.Name) && el.Id.Equals(el2.Id))
                            {
                                hSet.Add(el);
                            }
                        }
                    }       
                }
                return hSet;
                
            }

            public override bool Equals(object obj)
            {
                return obj is Student student &&
                       Id == student.Id &&
                       Name == student.Name;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Name);
            }
        }

        static void Main(string[] args)
        {
            Student student1 = new Student(1, "saefaesf ");
            Student student2 = new Student(2,  "Petro");
            Student student3 = new Student(3, "Stephan");
            Student student4 = new Student(1, " ");
            Student student5 = new Student(3, "Stephan");
            Student student6 = new Student(4, "Andrey");

            List<Student> l1 = new List<Student>();
            List<Student> l2 = new List<Student>();
            l1.Add(student1);
            l1.Add(student2);
            l1.Add(student3);
            l2.Add(student4);
            l2.Add(student5);
            l2.Add(student6);

            var result = Student.GetCommonStudents(l1, l2);
            Console.WriteLine(result.Count);
            foreach(var student in result)
            {
                Console.WriteLine(student.Name + ":" + student.Id);
            }
        }
    }
}
