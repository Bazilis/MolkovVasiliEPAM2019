using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class StudentDAO : ICRUD<Student>
    {
        private string ConnectionString { get; set; }

        public StudentDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(Student student)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                dataContext.GetTable<Student>().InsertOnSubmit(student);
                dataContext.SubmitChanges();
            }
        }

        public Student Read(int id)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Student>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Student> ReadAll()
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Student>().ToList();
            }
        }

        public void Update(Student st)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Student student = dataContext.GetTable<Student>().FirstOrDefault(x => x.Id == st.Id);

                student.Name = st.Name;
                student.Surname = st.Surname;
                student.Patronymic = st.Patronymic;
                student.Gender = st.Gender;
                student.DateOfBirth = st.DateOfBirth;
                student.GroupId = st.GroupId;

                dataContext.SubmitChanges();
            }
        }

        public void Delete(Student st)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Student student = dataContext.GetTable<Student>().FirstOrDefault(x => x.Id == st.Id);
                dataContext.GetTable<Student>().DeleteOnSubmit(student);
                dataContext.SubmitChanges();
            }
        }
    }
}
