using System;
using System.Collections.Generic;

namespace ConsoleApp.DataAccessObjectsFactory
{
    public interface ICRUD<T> where T : class
    {
        void Сreate(T item);

        T Read(int id);

        List<T> ReadAll();

        void Update(T item);

        void Delete(T item);
    }
}
