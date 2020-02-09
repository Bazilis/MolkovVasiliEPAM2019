using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class ExamDAO : ICRUD<Exam>
    {
        private string ConnectionString { get; set; }

        public ExamDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(Exam exam)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                dataContext.GetTable<Exam>().InsertOnSubmit(exam);
                dataContext.SubmitChanges();
            }
        }

        public Exam Read(int id)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Exam>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Exam> ReadAll()
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Exam>().ToList();
            }
        }

        public void Update(Exam ex)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Exam exam = dataContext.GetTable<Exam>().FirstOrDefault(x => x.Id == ex.Id);

                exam.SessionNumber = ex.SessionNumber;
                exam.ExamDate = ex.ExamDate;
                exam.GroupId = ex.GroupId;
                exam.SubjectId = ex.SubjectId;
                exam.ExaminerId = ex.ExaminerId;

                dataContext.SubmitChanges();
            }
        }

        public void Delete(Exam item)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Exam exam = dataContext.GetTable<Exam>().FirstOrDefault(x => x.Id == item.Id);
                dataContext.GetTable<Exam>().DeleteOnSubmit(exam);
                dataContext.SubmitChanges();
            }
        }
    }
}
