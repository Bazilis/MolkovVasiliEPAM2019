using System;
using System.Collections.Generic;

namespace ClassLibrary.DataAccessObjectsFactory
{
    /// <summary>
    /// Defining CRUD methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICRUD<T> where T : class
    {
        void Сreate(T item);

        T Read(int id);

        List<T> ReadAll();

        void Update(T item);

        void Delete(T item);
    }
}
