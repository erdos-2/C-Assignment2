using System;

namespace CSharpAssignment2
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.Clear();

            List<Student> studentsList = new List<Student>();
            Console.WriteLine("Welcome to Student Grade Calculator!");
            Console.ReadKey();
            Console.WriteLine();
            bool invalidInput;
            int numOfStdnts = 0; // just for the sake of initialization
            do
            {
                invalidInput = false;
                try
                {
                    Console.Write("Enter the number of students: ");
                    numOfStdnts = int.Parse(Console.ReadLine());
                    if (numOfStdnts < 0)
                    {
                        invalidInput = true;
                        Console.WriteLine("Number of students should be greater than zero.\n");
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Please enter a numeric value.\n");
                    invalidInput = true;
                }
            } while (invalidInput);

            for (int i = 0; i < numOfStdnts; i++)
            {
                Student stdnt = new Student();
                Console.WriteLine("Enter Student " + (i + 1) + " Information");
            }

            Console.WriteLine("Thank You for Using Student Grade Calculator");
        }
    }

    public struct StudentScores
    {
        public float AssignmentScore { get; set; } // out of 20
        public float MidExamScore { get; set; } // out of 30
        public float FinalExamScore { get; set; } // out of 50
    }

    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public StudentScores StdntScores { get; set; }
        public float TotalScore { get; set; }
        public char Grade { get; set; }

        public Student()
        {

        }
        public Student(string ID, string name, StudentScores stdntScores, float totalScore, char grade)
        {
            this.ID = ID;
            this.Name = name;
            this.StdntScores = stdntScores;
            this.TotalScore = totalScore;
            this.Grade = grade;
        }
    }
}