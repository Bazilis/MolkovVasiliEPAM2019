using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class SubjectDAO : ICRUD<Subject>
    {
        private string ConnectionString { get; set; }

        public SubjectDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(Subject subject)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                dataContext.GetTable<Subject>().InsertOnSubmit(subject);
                dataContext.SubmitChanges();
            }
        }

        public Subject Read(int id)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Subject>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Subject> ReadAll()
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Subject>().ToList();
            }
        }

        public void Update(Subject subj)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Subject subject = dataContext.GetTable<Subject>().FirstOrDefault(x => x.Id == subj.Id);

                subject.SubjectName = subj.SubjectName;
                subject.SubjectType = subj.SubjectType;

                dataContext.SubmitChanges();
            }
        }

        public void Delete(Subject subj)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Subject subject = dataContext.GetTable<Subject>().FirstOrDefault(x => x.Id == subj.Id);
                dataContext.GetTable<Subject>().DeleteOnSubmit(subject);
                dataContext.SubmitChanges();
            }
        }
    }
}
