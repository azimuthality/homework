using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Second_Lab
{
    interface Initial
    {
        string GetInitial();
    }
    interface Post : Initial
    {
        string GetPost();
    }
    interface Grop : Initial
    {
        string GetGroup();
    }
    interface Contact : Post
    {
        Student GetContSt(string name, string grup);
        Teacher GetContPr(string name, teacher dolj);
    }
    interface LS : Post
    {
        string GetLecture();
    }
    interface Declared : Grop
    {
        string GetDeclared();
    }
    public abstract class Person
    {
        string Name;
        public Person(string name)
        {
            this.Name = name;
        }
        public string GetInitial()
        {
            return Name;
        }
    }
    public class Officer : Person
    {
        string dolj;
        public Officer(string name, string dolj) : base(name)
        {
            this.dolj = dolj;
        }
        public string GetPost()
        {
            return dolj;
        }
    }
    public class HR_Officer : Officer, Contact
    {
        public HR_Officer(string name) : base(name, "Кадровик")
        {

        }
        public Student GetContSt(string nameS, string grup)
        {
            return new Student(nameS, grup);
        }
        public Teacher GetContPr(string namePr, teacher dolj)
        {
            return new Teacher(namePr, dolj);
        }
    }
    public enum teacher
    {
        Assistant = 0,
        StLecturer = 1
    }

    public class Teacher : Officer, LS
    {
        static string[] dol = new string[] { "Ассистент", "Старший преподаватель" };
        public Teacher(string Name, teacher dolj) : base(Name, dol[(int)dolj])
        {

        }
        public string GetLecture()
        {
            return "Проводит занятия по БД";
        }
    }
    public class Student : Person, Declared
    {
        string Group;
        public Student(string Name, string Grup) : base(Name)
        {
            this.Group = Grup;
        }
        public string GetGroup()
        {
            return Group;
        }
        public string GetDeclared()
        {
            return "Заявление на отчисление";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            HR_Officer one = new HR_Officer("Иванова Елена Вячеславовна.");
            Console.WriteLine(one.GetInitial());
            Console.WriteLine(one.GetPost() + "\n");
            Student four = one.GetContSt("Нохрин Илья Андреевич.", "2-1П11");
            
            Console.WriteLine(four.GetInitial());
            Console.WriteLine(four.GetGroup() + "\n");

            Teacher five = one.GetContPr("Соколов Данил Олегович.", teacher.Assistant);
            Console.WriteLine(five.GetInitial());
            Console.WriteLine(five.GetPost() + "\n");

            Teacher two = new Teacher("Осокин Сергей Алексеевич.", teacher.StLecturer);
            Console.WriteLine(two.GetInitial());
            Console.WriteLine(two.GetPost());
            Console.WriteLine(two.GetLecture() + "\n");
            Console.ReadKey();
        }
    }
}
