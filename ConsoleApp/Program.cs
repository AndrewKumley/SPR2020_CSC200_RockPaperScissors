using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personA = new Person("Riey", "Jackson", 8);
            Person personB = new Person("Sarah", "Millerson", 25);

            Console.WriteLine(personA.Greet());
            Console.WriteLine(personA.Greet(personB));
            Console.WriteLine(personB.Greet(personA));

            Teacher teacherA = new Teacher("Richard", "Konasa", 32);
            Console.WriteLine(teacherA.Greet());
        }
    }
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public virtual string Greet()
        {
            return "Hello, my name is " + firstName + ".";
        }

        public virtual string Greet(Person person)
        {
            return "Hello " + person.FirstName + ", how are you?";
        }
    }

    class Student : Person
    {
        private int grade;

        public Student(string firstName, string lastName, int age, int grade) : base(firstName, lastName, age)
        {
            this.grade = grade;
        }

        public int Grade
        {
            get { return grade; }
        }

        public override string Greet()
        {
            return "Yo, I am " + FirstName + ".";
        }

        public override string Greet(Person person)
        {
            return "Yo" + person.FirstName + ", what's up?";
        }
    }

    class Teacher : Person
    {
        private string[] classes;
        public Teacher(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            classes = new string[0];
        }

        public string[] Classes
        {
            get { return classes; }
        }
        
        public void AddClass(string className)
        {
            string[] _classes = new string[classes.Length + 1];
            classes.CopyTo(_classes, 0);
            _classes[_classes.Length - 1] = className;
            classes = _classes;
        }
    }
}
