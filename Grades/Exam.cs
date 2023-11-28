namespace _02Grades;

public class Exam
{
    private int grade;
    private string description;

    public int Grade { get { return grade; } set { this.grade = value; } }
    public string Description { get { return description; } set { this.description = value; } }


    // Optional fields
    /*
        private string name;
        private DateTime date;
        private int duration;
    */

    // Add properties later

    public Exam(int grade, string description)
    {
        this.grade = grade;
        this.description = description;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Exam wurde gespeichert. \n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public Exam()
    {

    }

    public static void LoopThroughGrades(Exam[] exams)
    {
        Console.WriteLine("Es sind folgende Noten gespeichert:");
        foreach (Exam exam in exams)
        {
            Console.WriteLine("Note: {0}",exam.grade);
        }
    }

    public void ChangeGrade(Exam exam, int value)
    {
        exam.grade = value;
    }
}

