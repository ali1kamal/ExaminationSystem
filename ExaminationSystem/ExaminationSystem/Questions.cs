namespace ExaminationSystem;

public abstract class Questions
{
    public string Header { get; set; }
    public string Body { get; set; }
    public double Mark { get; set; }
    public Answer[] AnswerList { get; set; }
    public Answer RightAnswer { get; set; }
    public Answer SelectedAnswer { get; set; }
    protected Questions(string header, string body, double mark, Answer[] answers, Answer rightAnswer)
    {
        Header = header;
        Body = body;
        Mark = mark;
        AnswerList = answers;
        RightAnswer = rightAnswer;
    }
    public abstract void ShowQustion();
    public void ReadAnswer()
    {
        int answerId;
        while (true)
        {
            Console.Write("Enter your answer ID: ");
            if (int.TryParse(Console.ReadLine(), out answerId))
            {
                foreach (Answer answer in AnswerList)
                {
                    if (answer.AnswerId == answerId)
                    {
                        SelectedAnswer = answer;
                        return;
                    }
                }
            }
            Console.WriteLine("Invalid answer! Try again.");
        }
    }
    public bool IsCorrect()
    {
        return SelectedAnswer != null && RightAnswer != null && SelectedAnswer.AnswerId == RightAnswer.AnswerId;
    }
    public override string ToString()
    {
        return $"{Header}: {Body} (Mark: {Mark})";
    }
    public virtual object Clone()
    {
        Questions copy = (Questions)MemberwiseClone();

        copy.AnswerList = new Answer[AnswerList.Length];

        for (int i = 0; i < AnswerList.Length; i++)
        {
            copy.AnswerList[i] =
                (Answer)AnswerList[i].Clone();
        }

        copy.RightAnswer =
            (Answer)RightAnswer.Clone();

        if (SelectedAnswer != null)
        {
            copy.SelectedAnswer =
                (Answer)SelectedAnswer.Clone();
        }

        return copy;
    }
    public int CompareTo(Questions questions)
    {
        if (questions == null)
            return -1;

        return Mark.CompareTo(questions.Mark);
    }
}
