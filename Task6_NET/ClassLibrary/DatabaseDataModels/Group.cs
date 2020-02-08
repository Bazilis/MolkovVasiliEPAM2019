using System;

namespace ClassLibrary.DatabaseDataModels
{
    /// <summary>
    /// Data model for Group database table
    /// </summary>
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
