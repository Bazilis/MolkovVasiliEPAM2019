using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class GroupDAO : ICRUD<Group>
    {
        private string ConnectionString { get; set; }

        public GroupDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(Group group)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                dataContext.GetTable<Group>().InsertOnSubmit(group);
                dataContext.SubmitChanges();
            }
        }

        public Group Read(int id)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Group>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Group> ReadAll()
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Group>().ToList();
            }
        }

        public void Update(Group gr)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Group group = dataContext.GetTable<Group>().FirstOrDefault(x => x.Id == gr.Id);

                group.GroupName = gr.GroupName;
                group.SpecialtyId = gr.SpecialtyId;

                dataContext.SubmitChanges();
            }
        }

        public void Delete(Group gr)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Group group = dataContext.GetTable<Group>().FirstOrDefault(x => x.Id == gr.Id);
                dataContext.GetTable<Group>().DeleteOnSubmit(group);
                dataContext.SubmitChanges();
            }
        }
    }
}
