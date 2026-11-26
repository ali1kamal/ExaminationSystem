namespace ExaminationSystem;

public class McqQuestions :Questions
{
    public McqQuestions(string header, string body, double mark, Answer[] answerList, Answer rightAnswer):base(header, body, mark, answerList, rightAnswer)
    {
    }
    public override void ShowQustion()
    {
        Console.WriteLine(ToString());

        foreach (Answer answer in AnswerList)
        {
            Console.WriteLine(answer);
        }
    }
    public override object Clone()
    {
        return base.Clone();
    }
}
