using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    /// <summary>
    /// Inherits CRUD methods for Student database table
    /// </summary>
    public class StudentDAO : GenericCRUD<Student>
    {
        public StudentDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
