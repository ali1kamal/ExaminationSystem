

namespace ExaminationSystem;

public class ParcitcalExam : Exam
{
    public ParcitcalExam(TimeSpan time, Questions[] questions)
    : base(time, questions)
    {
        foreach (Questions question in Questions)
        {
            if (!(question is McqQuestions))
            {
                throw new ArgumentException(
                    "Practical Exam accepts MCQ only");
            }
        }
    }
    public override void ShowExam()
    {
        Console.WriteLine("\n========== PRACTICAL EXAM ==========\n");

        StartExam();

        Console.WriteLine("\n========== PRACTICAL EXAM RESULTS ==========\n");

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
