using System;
using System.Reflection;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace ClassLibrary.DataAccessObjectsFactory
{
    public class GenericCRUD<T> : ICRUD<T> where T : class
    {
        private string ConnectionString { get; set; }

        public GenericCRUD(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Сreate(T item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                Type type = item.GetType();

                PropertyInfo[] classProperties = type.GetProperties();

                string tableName = type.Name;

                string columns = string.Empty;

                string valuesString = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    foreach (PropertyInfo property in classProperties)
                    {
                        if (property.CanWrite)
                        {
                            if (columns == string.Empty)
                            {
                                columns += property.Name;
                                valuesString += "@" + property.Name;

                                SqlParameter sqlParameter = new SqlParameter("@" + property.Name, property.GetValue(item));

                                sqlCommand.Parameters.Add(sqlParameter);
                            }
                            else
                            {
                                columns += ", " + property.Name;
                                valuesString += ", @" + property.Name;

                                SqlParameter sqlParameter = new SqlParameter("@" + property.Name, property.GetValue(item));

                                sqlCommand.Parameters.Add(sqlParameter);
                            }
                        }
                    }

                    string sqlExpression = $"INSERT INTO {tableName} ({columns}) VALUES ({valuesString})";

                    sqlCommand.CommandText = sqlExpression;
                    sqlCommand.Connection = sqlConnection;

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }
    }
}
