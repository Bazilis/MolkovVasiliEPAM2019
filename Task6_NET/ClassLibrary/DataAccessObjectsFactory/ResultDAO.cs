using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    /// <summary>
    /// Inherits CRUD methods for Result database table
    /// </summary>
    public class ResultDAO : GenericCRUD<Result>
    {
        public ResultDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
