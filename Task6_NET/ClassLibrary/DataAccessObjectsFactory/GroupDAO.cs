using System;
using ClassLibrary.DatabaseDataModels;

namespace ClassLibrary.DataAccessObjectsFactory
{
    public class GroupDAO : GenericCRUD<Group>
    {
        public GroupDAO(string connectionString) : base(connectionString)
        {

        }
    }
}
