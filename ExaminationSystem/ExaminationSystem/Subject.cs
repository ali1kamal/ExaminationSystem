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
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam(Exam exam)
        {
            if (exam == null)
            {
                throw new ArgumentNullException(nameof(exam));
            }

            Exam = exam;
        }
        public override string ToString()
        {
            return $"Subject ID: {SubjectId}\nSubject Name: {SubjectName}";
        }
    }
}
