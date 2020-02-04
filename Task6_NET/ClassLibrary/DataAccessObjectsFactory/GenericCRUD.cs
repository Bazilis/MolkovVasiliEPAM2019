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
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                Type type = typeof(T);

                PropertyInfo[] classProperties = type.GetProperties();

                string tableName = type.Name;

                string sqlExpression = $"SELECT * FROM {tableName} WHERE Id = @Id";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection))
                {
                    SqlParameter idParameter = new SqlParameter("@Id", id);

                    sqlCommand.Parameters.Add(idParameter);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            object[] parameters = new object[sqlDataReader.FieldCount];

                            while (sqlDataReader.Read())
                            {
                                if (sqlDataReader.FieldCount != classProperties.Length)
                                {
                                    throw new Exception("Number of type parameters is not equal to sqlDataReader parameters");
                                }

                                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                                {
                                    parameters[i] = sqlDataReader.GetValue(i);
                                }
                            }
                            return GetObject(parameters);
                        }
                        else
                        {
                            throw new ArgumentException($"{typeof(T)} with Id={id} is not found");
                        }
                    }
                }
            }
        }

        public List<T> ReadAll()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                Type type = typeof(T);

                string tableName = type.Name;

                PropertyInfo[] classFields = type.GetProperties();

                sqlConnection.Open();

                string sqlExpression = $"SELECT * FROM {tableName}";

                using (SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        List<T> listT = new List<T>();

                        if (sqlDataReader.HasRows)
                        {
                            object[] parameters = new object[sqlDataReader.FieldCount];

                            while (sqlDataReader.Read())
                            {
                                if (sqlDataReader.FieldCount != classFields.Length)
                                {
                                    throw new Exception("Number of type parameters is not equal to sqlDataReader parameters");
                                }

                                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                                {
                                    parameters[i] = sqlDataReader.GetValue(i);
                                }

                                listT.Add(GetObject(parameters));

                                Array.Clear(parameters, 0, sqlDataReader.FieldCount);
                            }

                            return listT;
                        }
                        else
                        {
                            throw new ArgumentException($"{tableName} has no rows");
                        }
                    }
                }
            }
        }

        public void Update(T item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                Type type = item.GetType();

                PropertyInfo[] classFields = type.GetProperties();

                string tableName = type.Name;

                string valuesString = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    foreach (PropertyInfo property in classFields)
                    {
                        if (property.CanWrite)
                        {
                            if (valuesString == string.Empty)
                            {
                                valuesString += property.Name + "=@" + property.Name;

                                SqlParameter sqlParameter = new SqlParameter("@" + property.Name, property.GetValue(item));

                                sqlCommand.Parameters.Add(sqlParameter);
                            }
                            else
                            {
                                valuesString += ", " + property.Name + "=@" + property.Name;

                                SqlParameter sqlParameter = new SqlParameter("@" + property.Name, property.GetValue(item));

                                sqlCommand.Parameters.Add(sqlParameter);
                            }
                        }
                    }

                    string sqlExpression = $"UPDATE {tableName} SET {valuesString} WHERE Id = @Id";

                    SqlParameter idParameter = new SqlParameter("@Id", type.GetProperty("Id").GetValue(item));
                    sqlCommand.Parameters.Add(idParameter);

                    sqlCommand.CommandText = sqlExpression;
                    sqlCommand.Connection = sqlConnection;

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Delete(T item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                Type type = item.GetType();

                string tableName = type.Name;

                sqlConnection.Open();

                string sqlExpression = $"DELETE FROM {tableName} WHERE Id = @Id";

                using (SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection))
                {
                    SqlParameter idParameter = new SqlParameter("@Id", type.GetProperty("Id").GetValue(item));

                    sqlCommand.Parameters.Add(idParameter);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        protected T GetObject(params object[] arguments)
        {
            return (T)Activator.CreateInstance(typeof(T), arguments);
        }
    }
}
