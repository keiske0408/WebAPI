using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.db;

public static class DatabaseCommands
{
    public static async Task<List<T>> SimpleQuery<T>(
        this DbContext db,
        string sql,
        Func<SqlDataReader, T> createObject,
        Dictionary<string, object> parameters = null,
        bool isStoredProcedure = false)
    {
        var results = new List<T>();
        var connection = db.Database.GetDbConnection() as SqlConnection;

        await using (connection)
        {
            await connection.OpenAsync();

            using var command = new SqlCommand(sql, connection);

            if (isStoredProcedure)
            {
                command.CommandType = CommandType.StoredProcedure;
            }

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(CreateSqlParameter(param.Key, param.Value));
                }
            }

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                results.Add(createObject(reader));
            }
        }

        return results;
    }

    public static async Task SimpleCommand(
        this DbContext db,
        string sql,
        Dictionary<string, object> parameters = null,
        bool isStoredProcedure = false)
    {
        var connection = db.Database.GetDbConnection() as SqlConnection;

        await using (connection)
        {
            await connection.OpenAsync();

            using var command = new SqlCommand(sql, connection);

            if (isStoredProcedure)
            {
                command.CommandType = CommandType.StoredProcedure;
            }

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(CreateSqlParameter(param.Key, param.Value));
                }
            }
            await command.ExecuteNonQueryAsync();
        }
    }

    public static async Task<Dictionary<string, object>> CallStoredProcedure(
        this DbContext db,
        string procedureName,
        Dictionary<string, (object Value, ParameterDirection Direction)> parameters)
    {
        var connection = db.Database.GetDbConnection() as SqlConnection;
        var outputValues = new Dictionary<string, object>();

        await using (connection)
        {
            await connection.OpenAsync();

            using var command = new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            foreach (var param in parameters)
            {
                var sqlParam = CreateSqlParameter(param.Key, param.Value);
                sqlParam.Direction = param.Value.Direction;
                command.Parameters.Add(sqlParam);
            }

            await command.ExecuteNonQueryAsync();

            foreach (SqlParameter param in command.Parameters)
            {
                if (param.Direction == ParameterDirection.Output ||
                    param.Direction == ParameterDirection.InputOutput
                    || param.Direction == ParameterDirection.ReturnValue)
                {
                    outputValues.Add(param.ParameterName, param.Value);
                }
            }
        }
        return outputValues;
    }

    private static SqlParameter CreateSqlParameter(string name, object value)
    {
        return value switch
        {
            Guid guid => new SqlParameter(name, SqlDbType.UniqueIdentifier) {Value = guid},
            int i => new SqlParameter(name, SqlDbType.Int) {Value = i},
            string s => new SqlParameter(name, SqlDbType.NVarChar) {Value = s},
            bool b => new SqlParameter(name, SqlDbType.Bit) {Value = b},
            DateTime dt => new SqlParameter(name, SqlDbType.DateTime) {Value = dt},
            null => new SqlParameter(name, SqlDbType.NVarChar) {Value = DBNull.Value},
            _ => new SqlParameter(name,value)
        };
    }
}

