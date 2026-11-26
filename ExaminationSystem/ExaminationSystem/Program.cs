namespace ExaminationSystem;

internal class Program
{
    #region ManinFunction
    static void Main(string[] args)
    {
        Subject subject = CreateSubject();

        int examType = ChooseExamType();

        TimeSpan examTime = ReadExamTime();

        int numberOfQuestions = ReadPositiveInt(
            "Enter number of questions: ");

        Questions[] questions = CreateQuestions(
            numberOfQuestions, examType);

        Exam exam = CreateExam(
            examType, examTime, questions);

        subject.CreateExam(exam);

        Console.WriteLine("\nPress Y to start the exam.");
        string choice = Console.ReadLine() ?? "";

        if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            exam.ShowExam();
        }
        else
        {
            Console.WriteLine("Exam was not started.");
        }
    }
    #endregion

    #region Create Subject
    public static Subject CreateSubject()
    {
        Console.WriteLine("=== Create Subject ===");

        int id = ReadPositiveInt("Enter Subject ID: ");

        Console.Write("Enter Subject Name: ");
        string name = Console.ReadLine() ?? "";

        return new Subject(id, name);
    }
    #endregion

    #region Exam Type(Final or Practical)
    public static int ChooseExamType()
    {
        Console.WriteLine("\nChoose Exam Type:");
        Console.WriteLine("1. Final Exam");
        Console.WriteLine("2. Practical Exam");

        int choice;

        do
        {
            choice = ReadPositiveInt("Your choice: ");

            if (choice != 1 && choice != 2)
            {
                Console.WriteLine("Please enter 1 or 2.");
            }

        } while (choice != 1 && choice != 2);

        return choice;
    }
    #endregion

    #region EXam Time
    public static TimeSpan ReadExamTime()
    {
        int minutes = ReadPositiveInt(
            "Enter exam duration in minutes: ");

        return TimeSpan.FromMinutes(minutes);
    }
    #endregion

    #region creating Quesrion
    public static Questions[] CreateQuestions(int count, int examType)
    {
        Questions[] questions = new Questions[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n=== Question {i + 1} ===");

            if (examType == 1)
            {
                questions[i] = CreateFinalQuestion();
            }
            else
            {
                questions[i] = CreateMCQQuestion();
            }
        }

        return questions;
    }
    #endregion


    #region If final Exam
    public static Questions CreateFinalQuestion()
    {
        Console.WriteLine("\nChoose Question Type:");
        Console.WriteLine("1. MCQ");
        Console.WriteLine("2. True / False");

        int choice;

        do
        {
            choice = ReadPositiveInt("Your choice: ");

            if (choice != 1 && choice != 2)
            {
                Console.WriteLine("Please enter 1 or 2.");
            }

        } while (choice != 1 && choice != 2);

        if (choice == 1)
        {
            return CreateMCQQuestion();
        }

        return CreateTrueFalseQuestion();
    }
    #endregion


    #region Mcq
    public static McqQuestions CreateMCQQuestion()
    {
        Console.Write("Enter question header: ");
        string header = Console.ReadLine() ?? "";

        Console.Write("Enter question body: ");
        string body = Console.ReadLine() ?? "";

        int mark = ReadPositiveInt("Enter question mark: ");

        Answer[] answers = CreateAnswers(4);

        int rightAnswerId = ReadAnswerId(answers.Length);

        Answer rightAnswer = answers[rightAnswerId - 1];

        return new McqQuestions(header, body, mark, answers, rightAnswer);
    }
    #endregion

    #region TrueFalse
    public static TrueFalseQuestion CreateTrueFalseQuestion()
    {
        Console.Write("Enter question: ");
        string body = Console.ReadLine() ?? "";

        int mark = ReadPositiveInt("Enter question mark: ");

        Answer[] answers =
        {
        new Answer(1, "True"),
        new Answer(2, "False")
        };

        int rightAnswerId = ReadAnswerId(2);

        Answer rightAnswer = answers[rightAnswerId - 1];

        return new TrueFalseQuestion(
            "True/False", body, mark, answers, rightAnswer);
    }
    #endregion

    #region Answers
    public static Answer[] CreateAnswers(int count)
    {
        Answer[] answers = new Answer[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Enter answer {i + 1}: ");

            string answerText = Console.ReadLine() ?? "";

            answers[i] = new Answer(i + 1, answerText);
        }

        return answers;
    }

    public static int ReadAnswerId(int numberOfAnswers)
    {
        int id;

        do
        {
            id = ReadPositiveInt("Enter correct answer ID: ");

            if (id < 1 || id > numberOfAnswers)
            {
                Console.WriteLine(
                    $"Enter a number between 1 and {numberOfAnswers}.");
            }

        } while (id < 1 || id > numberOfAnswers);

        return id;
    }
    #endregion



    #region Create Exam
    public static Exam CreateExam(int examType, TimeSpan examTime, Questions[] questions)
    {
        if (examType == 1)
        {
            return new FinalExam(examTime, questions);
        }

        return new ParcitcalExam(examTime, questions);
    } 
    #endregion

    public static int ReadPositiveInt(string message)
    {
        int number;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a valid positive number.");
        }
    }
}
