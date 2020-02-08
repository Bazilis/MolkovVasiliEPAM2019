using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    /// <summary>
    /// Inherits CRUD methods for Exam database table
    /// </summary>
    public class ExamDAO : GenericCRUD<Exam>
    {
        public ExamDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
