using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using ConsoleApp.DatabaseDataModels;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public class SpecialtyDAO : ICRUD<Specialty>
    {
        private string ConnectionString { get; set; }

        public SpecialtyDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(Specialty specialty)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                dataContext.GetTable<Specialty>().InsertOnSubmit(specialty);
                dataContext.SubmitChanges();
            }
        }

        public Specialty Read(int id)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Specialty>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Specialty> ReadAll()
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                return dataContext.GetTable<Specialty>().ToList();
            }
        }

        public void Update(Specialty spec)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Specialty specialty = dataContext.GetTable<Specialty>().FirstOrDefault(x => x.Id == spec.Id);

                specialty.SpecialtyCode = spec.SpecialtyCode;
                specialty.SpecialtyName = spec.SpecialtyName;
                specialty.SpecialtyDescribe = spec.SpecialtyDescribe;

                dataContext.SubmitChanges();
            }
        }

        public void Delete(Specialty spec)
        {
            using (DataContext dataContext = new DataContext(ConnectionString))
            {
                Specialty specialty = dataContext.GetTable<Specialty>().FirstOrDefault(x => x.Id == spec.Id);
                dataContext.GetTable<Specialty>().DeleteOnSubmit(specialty);
                dataContext.SubmitChanges();
            }
        }
    }
}
