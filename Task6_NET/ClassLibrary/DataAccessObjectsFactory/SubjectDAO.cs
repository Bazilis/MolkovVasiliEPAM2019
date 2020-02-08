using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    /// <summary>
    /// Inherits CRUD methods for Subject database table
    /// </summary>
    public class SubjectDAO : GenericCRUD<Subject>
    {
        public SubjectDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
