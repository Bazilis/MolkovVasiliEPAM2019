using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    public class StudentDAO : GenericCRUD<Student>
    {
        public StudentDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
