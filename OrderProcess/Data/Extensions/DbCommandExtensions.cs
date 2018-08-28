using System;
using System.Data;

namespace OrderProcess.Data.Extensions
{
    public static class DbCommandExtensions
    {
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");
            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            command.Parameters.Add(p);
        }

        public static IDbCommand Page(this IDbCommand command, int pageNumber, int pageSize)
        {
            // modify command.CommandText here.

            return command;
        }
    }
}