using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class ResultDAO : ICRUD<Result>
    {
        private string ConnectionString { get; set; }

        public ResultDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(Result res)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                dataContext.GetTable<Result>().InsertOnSubmit(res);
                dataContext.SubmitChanges();
            }
        }

        public Result Read(int id)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Result>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Result> ReadAll()
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Result>().ToList();
            }
        }

        public void Update(Result res)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Result result = dataContext.GetTable<Result>().FirstOrDefault(x => x.Id == res.Id);

                result.ExamId = res.ExamId;
                result.StudentId = res.StudentId;
                result.StudentsGrade = res.StudentsGrade;

                dataContext.SubmitChanges();
            }
        }

        public void Delete(Result res)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Result result = dataContext.GetTable<Result>().FirstOrDefault(x => x.Id == res.Id);
                dataContext.GetTable<Result>().DeleteOnSubmit(result);
                dataContext.SubmitChanges();
            }
        }
    }
}
