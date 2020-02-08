using System;

namespace ClassLibrary.DatabaseDataModels
{
    /// <summary>
    /// Data model for Subject database table
    /// </summary>
    public class Subject
    {
        public int Id { get; private set; }
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }

        public Subject(int id, string subjectName, string subjectType)
        {
            Id = id;
            SubjectName = subjectName;
            SubjectType = subjectType;
        }

        public Subject(string subjectName, string subjectType)
        {
            SubjectName = subjectName;
            SubjectType = subjectType;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Subject name: {SubjectName}, Subject type: {SubjectType}";
        }
    }
}
