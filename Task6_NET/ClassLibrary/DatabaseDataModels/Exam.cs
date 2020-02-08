using System;

namespace ClassLibrary.DatabaseDataModels
{
    /// <summary>
    /// Data model for Exam database table
    /// </summary>
    public class Exam
    {
        public int Id { get; private set; }
        public int SessionNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }

        public Exam(int id, int sessionNumber, DateTime examDate, int groupId, int subjectId)
        {
            Id = id;
            SessionNumber = sessionNumber;
            ExamDate = examDate;
            GroupId = groupId;
            SubjectId = subjectId;
        }

        public Exam(int sessionNumber, DateTime examDate, int groupId, int subjectId)
        {
            SessionNumber = sessionNumber;
            ExamDate = examDate;
            GroupId = groupId;
            SubjectId = subjectId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Session number: {SessionNumber}, Exam date: {ExamDate}, Group Id: {GroupId}, Subject Id: {SubjectId}";
        }
    }
}
