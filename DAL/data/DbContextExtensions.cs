using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.data
{

    /// <summary>
    /// For Using sql command to return string .
    /// </summary>
    public static class DbContextExtensions
    {
        public static object? executeScalar(this DbContext context, string query, object? parameters = null)
        {   
            ArgumentNullException.ThrowIfNull(query);
            
            IDbConnection dbConnection = context.Database.GetDbConnection();

            using (IDbCommand dbCommand = dbConnection.CreateCommand() ) 
            {
                dbCommand.CommandText = query;

                if( parameters is not  null) {

                    IEnumerable<PropertyInfo> properties = parameters.GetType().GetProperties();

                    foreach(PropertyInfo property in properties)
                    {
                        IDataParameter dataParameter = dbCommand.CreateParameter();
                        
                        dataParameter.ParameterName = property.Name;

                        dataParameter.Value = property.GetValue(parameters) ?? DBNull.Value;    

                        dbCommand.Parameters.Add(dataParameter);
                    }
                }

                dbConnection.Open();    

                object? result = dbCommand.ExecuteScalar();

                dbConnection.Close();

                return result is DBNull ? null : result;
            }  
        } 

    }
}
