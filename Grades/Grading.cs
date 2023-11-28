using System.Numerics;

namespace _02Grades;

public class Grading
{

    public static void Main(string[] args)
    {
        Random rnd = new Random();

        int[] grades = new int[10];
        for (int i = 0; i < 10; i++)
        {
            grades[i] = rnd.Next(1,7);
            Console.WriteLine(grades[i]);
        }
        Console.WriteLine("Guteste Note ist: {0}", GetBestGrade(grades));
        Console.WriteLine("Unguteste Note ist: {0}", GetWorstGrade(grades));

        int numberOfExams = 10;
        Exam[] exams = new Exam[numberOfExams];

        for (int i = 0;i < numberOfExams; i++)
        {
            exams[i] = new Exam(GetUserInputGrade("Bitte eine Note eingeben."),GetUserInputString("Bitte eine Beschreibung eingeben"));
        }
        
    }

    public static int GetUserInputGrade(string message)
    {
        Console.WriteLine(message);
        int value = 0;
        while(!int.TryParse(Console.ReadLine(), out value) || !(value > 0 && value < 7))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fehler. Bitte eine Zahl eingeben.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        return value;
    }

    public static string GetUserInputString(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    public static int GetBestGrade(int[] grades)
    {
        if (grades.Length == 0)
            return 0;

        int bestGrade = 1;
        foreach (int grade in grades)
        {
            if (bestGrade == 6)
                return 6;

            if(bestGrade > grade)
                bestGrade = grade;
        }

        return bestGrade;
    }

    public static int GetWorstGrade(int[] grades)
    {
        if (grades.Length == 0)
            return 0;

        int bestGrade = 6;
        foreach (int grade in grades)
        {
            if (bestGrade == 1)
                return 1;

            if (bestGrade < grade)
                bestGrade = grade;
        }

        return bestGrade;
    }
}