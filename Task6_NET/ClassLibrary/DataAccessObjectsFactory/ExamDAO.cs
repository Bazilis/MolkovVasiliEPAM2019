using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    public class ExamDAO : GenericCRUD<Exam>
    {
        public ExamDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
