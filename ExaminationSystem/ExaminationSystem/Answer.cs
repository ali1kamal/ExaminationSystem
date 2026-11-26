using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public class Answer : ICloneable , IComparable<Answer>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        }

        public int CompareTo(Answer answ)
        {
            if(answ == null) 
                return -1;
            return AnswerId.CompareTo(answ.AnswerId);
        }
        public override string ToString()
        {
            return $"{AnswerId} - {AnswerText}";
        }
    }
}
