using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class ExaminerDAO : ICRUD<Examiner>
    {
        private string ConnectionString { get; set; }

        public ExaminerDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(Examiner examiner)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                dataContext.GetTable<Examiner>().InsertOnSubmit(examiner);
                dataContext.SubmitChanges();
            }
        }

        public Examiner Read(int id)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Examiner>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Examiner> ReadAll()
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Examiner>().ToList();
            }
        }

        public void Update(Examiner ex)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Examiner examiner = dataContext.GetTable<Examiner>().FirstOrDefault(x => x.Id == ex.Id);

                examiner.Name = ex.Name;
                examiner.Surname = ex.Surname;
                examiner.Patronymic = ex.Patronymic;

                dataContext.SubmitChanges();
            }
        }

        public void Delete(Examiner ex)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Examiner examiner = dataContext.GetTable<Examiner>().FirstOrDefault(x => x.Id == ex.Id);
                dataContext.GetTable<Examiner>().DeleteOnSubmit(examiner);
                dataContext.SubmitChanges();
            }
        }
    }
}
