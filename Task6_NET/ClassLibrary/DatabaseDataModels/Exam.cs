using System;

namespace ClassLibrary.DatabaseDataModels
{
    public class Exam
    {
        public int Id { get; private set; }
        public int SessionNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }

        public Exam(int id, int subjectId, DateTime examDate, int sessionNumber, int groupId)
        {
            Id = id;
            SubjectId = subjectId;
            ExamDate = examDate;
            SessionNumber = sessionNumber;
            GroupId = groupId;
        }

        public Exam(int subjectId, DateTime examDate, int sessionNumber, int groupId)
        {
            SubjectId = subjectId;
            ExamDate = examDate;
            SessionNumber = sessionNumber;
            GroupId = groupId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Subject Id: {SubjectId}, Exam date: {ExamDate}, Session number: {SessionNumber}, Group Id: {GroupId}";
        }
    }
}
