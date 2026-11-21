namespace ExaminationSystem;

public abstract class Questions
{
    public string Header { get; set; }
    public string Body { get; set; }
    public double Mark {  get; set; }
    public Answer[] AnswerList { get; set; }
    public Answer RightAnswer { get; set; }
    protected Questions(string header,string body,double mark, Answer[] answers, Answer rightAnswer )
    {
        Header = header;
        Body = body;
        Mark = mark;
        AnswerList = answers;
        RightAnswer = rightAnswer;
    }
}
