using System.Diagnostics;

namespace ExaminationSystem;

public abstract class Exam
{
    public TimeSpan Time {  get; set; }
    public Questions[] Questions { get; set; }
    public int NumberOfQeustions { get; set; }
    public int NumberOfQuestions
    {
        get { return Questions.Length; }
    }
    public TimeSpan ElapsedTime { get; private set; }
    public Exam(TimeSpan time, Questions[] questions)
    {
        Time = time;
        Questions = questions;
    }
    public void StartExam()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        foreach (Questions question in Questions)
        {
            question.ShowQustion();
            question.ReadAnswer();

            Console.WriteLine();
        }

        stopwatch.Stop();

        ElapsedTime = stopwatch.Elapsed;
    }

    public double CalculateGrade()
    {
        double grade = 0;

        foreach (Questions question in Questions)
        {
            if (question.IsCorrect())
            {
                grade += question.Mark;
            }
        }

        return grade;
    }
    public abstract void ShowExam();
}
