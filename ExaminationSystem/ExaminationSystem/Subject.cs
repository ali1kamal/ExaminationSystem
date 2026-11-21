using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        public void CreateExam(Exam exam)
        {
            Console.WriteLine("Creating Exam not completed yet");
        }
    }
}
