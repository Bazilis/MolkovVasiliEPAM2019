using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    public class ResultDAO : GenericCRUD<Result>
    {
        public ResultDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
