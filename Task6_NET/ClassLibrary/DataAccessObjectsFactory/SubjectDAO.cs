using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    public class SubjectDAO : GenericCRUD<Subject>
    {
        public SubjectDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
