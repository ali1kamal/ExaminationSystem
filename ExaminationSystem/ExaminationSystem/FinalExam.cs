

namespace ExaminationSystem;

public class FinalExam : Exam
{
    public FinalExam(TimeSpan time, Questions[] questions) : base(time, questions)
    {
        foreach (Questions question in Questions)
        {
            if (!(question is McqQuestions ||
                  question is TrueFalseQuestion))
            {
                throw new ArgumentException(
                    "Invalid question type for Final Exam");
            }
        }
    }
    public override void ShowExam()
    {
        Console.WriteLine("\n========== FINAL EXAM ==========\n");

        StartExam();

        Console.WriteLine("\n========== FINAL EXAM RESULTS ==========\n");

        foreach (Questions question in Questions)
        {
            Console.WriteLine(question.Body);

            Console.WriteLine(
                "Your Answer => " +
                (question.SelectedAnswer?.AnswerText ?? "No Answer"));

            Console.WriteLine(
                "Correct Answer => " +
                question.RightAnswer.AnswerText);

            Console.WriteLine();
        }

        Console.WriteLine(
            $"Your Grade is {CalculateGrade()} from {Questions.Sum(q => q.Mark)}");

        Console.WriteLine($"Time = {ElapsedTime}");

        Console.WriteLine("Thank you!");
    }
}
