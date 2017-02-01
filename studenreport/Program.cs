using System;
using System.Collections.Generic;
using System.Linq;
namespace studenreport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int len = 0;
                char choice = 'Y';
                //Student[] studentobj = new Student[100];
                //Student tempObj = new Student();
                List<Student> studentobj = new List<Student>();

                do
                {
                    var student = new Student();
                    ////studentobj[len] = new Student();
                    Console.Write("Enter Roll no:");
                    student.RollNo = Convert.ToInt32(Console.ReadLine());
                    //studentobj.Add(new Student() {RollNo=Convert.ToInt32(Console.ReadLine()) });
                    //studentobj[len].RollNo = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name:");
                    student.Name = Console.ReadLine();
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write("enter marks[" + j + "]=");
                        student.Marks = new List<int>();
                        student.Marks.Add(Convert.ToInt32(Console.ReadLine()));
                       foreach(int d in student.Marks)
                        {
                            student.Total += d;
                        }
                    }
                    student.Percentage = student.Total / 3;
                    Console.Write("add another student details?(Y/N): ");
                    choice = Convert.ToChar(Console.ReadLine());
                    studentobj.Add(student);
                } while (choice == 'Y' || choice == 'y');
                studentobj.Sort();
         
                Console.WriteLine("____________________________________");
                Console.WriteLine("Rank\tRollNo\tName\tPercentage");
                Console.WriteLine("____________________________________");
                int i = 0;
                foreach(var temp in studentobj)
                {   
                    Console.WriteLine((i+1)+"\t"+temp.RollNo + "\t" + temp.Name + "\t" + temp.Percentage);i++;
                }
                Console.WriteLine("____________________________________");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            Console.ReadLine();


        }
    }
    
    class Student:IComparable<Student>
    {
        private string name;
        private int rollNo;
        private int[] marks = new int[3];
        private int total = 0;
        private float percentage;
        public int RollNo
        {
            get { return rollNo; }
            set { rollNo = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<int> Marks
        {
            get;
            set;
        }
        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        public float Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }
        public int CompareTo(Student comparePart)

        {
            if (comparePart == null)
                return 1;

            else
               return -1*this.Total.CompareTo(comparePart.Total);
        }
       

    }
}