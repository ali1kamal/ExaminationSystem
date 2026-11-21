using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public class Exam : Questions
    {
        public int Time {  get; set; }
        public int NumberOfQeustions { get; set; }
        public Exam(string header, string body, double mark, Answer[] answers, Answer rightAnswer,int time, int NumberOfQeustions):base(header, body, mark, answers, rightAnswer)
        {
            Time = time;
            this.NumberOfQeustions = NumberOfQeustions;
        }
        public ExamType ExamType { get; set; }
    }
}
