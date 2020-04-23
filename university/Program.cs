using System;
using System.Collections.Generic;

namespace university
{
    class Program
    {
        static void Main()
        {
            Person[] people = new Person[]
            {
                new Student("Aleksej","Gusejnov","Math and CS"),
                new Teacher("Igor","Ivanov","Math and CS"),
                new Teacher("Andrey","Rurikovich","English"),
                new Teacher("Dmitriy","Romanov","Math and CS"),
                new HeadOfDepartment("Joseph","Blazkowicz","Math and CS"),
            };
            for (int i = 0; i < people.Length; i++)
            {
                for (int j = i + 1; j < people.Length; j++) 
                {
                    if (people[i].Equals(people[j]))
                    {
                        Console.WriteLine($"{people[i]} is equal to {people[j]}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
    public abstract class Person
    {        
        public string Name { get; set; }
        public string Surname { get; set; }
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
    public class Student : Person
    {
        public string Department { get; set; }
        public List<int> Marks { get; set; } = new List<int>();
        public Student(string name, string surname, string department) : base(name, surname)
        {
            Department = department;
        }
    }
    public class Teacher : Person
    {
        public string Department { get; set; }
        List<string> Subjects { get; set; } = new List<string>() { "English" }; 
        public Teacher(string name, string surname, string department) : base(name, surname)
        {
            Department = department;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
                return false;

            else
            {
                var temp = (Teacher)obj;
                return (Department == temp.Department && Subjects == temp.Subjects) ? true : false; //если два преподавателя работают в одном факультете и преподают одинаковые предметы, то они "одинаковы"
            }
        }
    }
    public class HeadOfDepartment : Teacher
    {
        public HeadOfDepartment(string name, string surname, string department) : base(name, surname, department) { }
        public Teacher HireTeacher(string name, string surname) //нанять учителя
        {
            return new Teacher(name, surname, this.Department);
        }
    }
}
