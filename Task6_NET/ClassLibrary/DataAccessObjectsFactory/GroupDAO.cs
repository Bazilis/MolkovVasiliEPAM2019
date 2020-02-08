using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    /// <summary>
    /// Inherits CRUD methods for Group database table
    /// </summary>
    public class GroupDAO : GenericCRUD<Group>
    {
        public GroupDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
