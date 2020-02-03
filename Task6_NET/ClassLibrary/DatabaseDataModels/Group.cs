using System;

namespace ClassLibrary.DatabaseDataModels
{
    public class Group
    {
        public int Id { get; private set; }
        public string GroupName { get; set; }

        public Group(int id, string groupName)
        {
            Id = id;
            GroupName = groupName;
        }

        public Group(string groupName)
        {
            GroupName = groupName;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Group name: {GroupName}";
        }
    }
}
