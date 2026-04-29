using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace AspGodPractice.Utilities
{
    public static class SqlHelper
    {
        public static T MapObject<T>(SqlDataReader reader) where T : new()
        {
            T obj = new T();

            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);

                var prop = properties.FirstOrDefault(p =>
                    p.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

                if (prop != null && !reader.IsDBNull(i))
                {
                    try
                    {
                        prop.SetValue(obj, reader.GetValue(i));
                    }
                    catch (ArgumentException)
                    {
      
                    }
                }
            }
            return obj;
        }
    }
}