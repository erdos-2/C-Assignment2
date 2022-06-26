using System.Globalization;

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
                        Console.WriteLine("Number of students should be greater than zero.\n");
                        invalidInput = true;
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

                Console.WriteLine("\nEnter Student " + (i + 1) + " Information\n");

                do
                {
                    invalidInput = false;
                    Console.Write("ID: ");
                    stdnt.ID = Console.ReadLine();
                    if (stdnt.ID.Length == 0 || stdnt.ID.Length > 6)
                    {
                        Console.WriteLine("Make sure you entered a valid ID.\n");
                        invalidInput = true;
                    }
                } while (invalidInput);

                do
                {
                    invalidInput = false;
                    Console.Write("Name: ");
                    stdnt.Name = Console.ReadLine();
                    if (stdnt.Name == "")
                    {
                        Console.WriteLine("Make sure you entered a valid name.\n");
                        invalidInput = true;
                    }
                } while (invalidInput);

                do
                {
                    try
                    {
                        invalidInput = false;
                        Console.Write("Assignment Score (0-20): ");
                        stdnt.Scores["Assignment Score"] = float.Parse(Console.ReadLine());
                        if (stdnt.Scores["Assignment Score"] < 0 || stdnt.Scores["Assignment Score"] > 20)
                        {
                            Console.WriteLine("Assignment Score should be between 0 and 20.\n");
                            invalidInput = true;
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Make sure you entered a numeric value.\n");
                        invalidInput = true;
                    }
                } while (invalidInput);

                do
                {
                    try
                    {
                        invalidInput = false;
                        Console.Write("Mid-Exam Score (0-30): ");
                        stdnt.Scores["Mid-Exam Score"] = float.Parse(Console.ReadLine());
                        if (stdnt.Scores["Mid-Exam Score"] < 0 || stdnt.Scores["Mid-Exam Score"] > 30)
                        {
                            Console.WriteLine("Mid-Exam Score should be between 0 and 30.\n");
                            invalidInput = true;
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Make sure you entered a numeric value.\n");
                        invalidInput = true;
                    }
                } while (invalidInput);

                do
                {
                    try
                    {
                        invalidInput = false;
                        Console.Write("Final-Exam Score (0-50): ");
                        stdnt.Scores["Final-Exam Score"] = float.Parse(Console.ReadLine());
                        if (stdnt.Scores["Final-Exam Score"] < 0 || stdnt.Scores["Final-Exam Score"] > 50)
                        {
                            Console.WriteLine("Final-Exam Score should be between 0 and 50.\n");
                            invalidInput = true;
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Make sure you entered a numeric value.\n");
                        invalidInput = true;
                    }
                } while (invalidInput);


                foreach (float score in stdnt.Scores.Values)
                {
                    stdnt.TotalScore += score;
                }

                if (stdnt.TotalScore >= 85)
                    stdnt.Grade = 'A';
                else if (stdnt.TotalScore >= 75)
                    stdnt.Grade = 'B';
                else if (stdnt.TotalScore >= 65)
                    stdnt.Grade = 'C';
                else if (stdnt.TotalScore >= 50)
                    stdnt.Grade = 'D';
                else
                    stdnt.Grade = 'F';

                studentsList.Add(stdnt);
                Console.WriteLine();
            }

            for (int i = 0; i < studentsList.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < studentsList.Count; j++)
                {
                    int length = Math.Min(studentsList[j].Name.Length, studentsList[minIndex].Name.Length);

                    if (String.Compare(studentsList[j].Name, 0, studentsList[minIndex].Name, 0, length,
                    new CultureInfo("en-US"), System.Globalization.CompareOptions.IgnoreCase) < 0)
                    {
                        minIndex = j;
                    }
                }

                Student tempStudent = studentsList[i];
                studentsList[i] = studentsList[minIndex];
                studentsList[minIndex] = tempStudent;
            }

            Console.Clear();
            Console.WriteLine("\nID\t\tName\t\t\tAssignment\tMid-Exam\tFinal-Exam\tTotal\tGrade\n");
            foreach (Student stdnt in studentsList)
            {
                Console.WriteLine(stdnt.ID + "\t\t" + stdnt.Name + "\t\t" + stdnt.Scores["Assignment Score"] +
                "\t\t" + stdnt.Scores["Mid-Exam Score"] + "\t\t" + stdnt.Scores["Final-Exam Score"] + "\t\t" +
                stdnt.TotalScore + "\t" + stdnt.Grade);
            }

            Console.WriteLine("\nThank you for using Student Grade Calculator");
        }
    }

    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Dictionary<string, float> Scores;
        public float TotalScore { get; set; }
        public char Grade { get; set; }

        public Student()
        {
            Scores = new Dictionary<string, float> {
                {"Assignment Score", 0F},
                {"Mid-Exam Score", 0F},
                {"Final-Exam Score", 0F},
            };
        }
    }
}