#region License
//  Copyright 2010-2015 Natan Vivo - http://github.com/nvivo/dbhelpers
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

namespace NLC.YummyCate.DBUtility
{
    public partial class DBHelper
    {
        #region Constructors
        
        public DBHelper()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["MyCN"];

            _factory = DbProviderFactories.GetFactory(css.ProviderName);
            _connectionString = css.ConnectionString;
        }

        #endregion

        #region Properties

        private string _connectionString;
        private DbProviderFactory _factory;

        private string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        private DbProviderFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        #endregion

        #region Private Helpers

        protected static void FillFromReader(DbDataReader reader, int startRecord, int maxRecords, Action<DbDataReader> action)
        {
            if (startRecord < 0)
                throw new ArgumentOutOfRangeException("startRecord", "StartRecord must be zero or higher.");

            while (startRecord > 0)
            {
                if (!reader.Read())
                    return;

                startRecord--;
            }

            if (maxRecords > 0)
            {
                int i = 0;

                while (i < maxRecords && reader.Read())
                {
                    action(reader);
                    i++;
                }
            }
            else
            {
                while (reader.Read())
                    action(reader);
            }
        }

        private string GetProviderParameterFormatString()
        {
            var builder = Factory.CreateCommandBuilder();
            var type = builder.GetType();
            var method = type.GetMethod("GetParameterPlaceholder", BindingFlags.NonPublic | BindingFlags.Instance);
            var index = 42;
            var parameterName = method.Invoke(builder, new object[] { index }).ToString();
            return parameterName.Replace(index.ToString(CultureInfo.InvariantCulture), "{0}");
        }

        #endregion

        #region Helper Methods and Extension Points

        private DbConnection CreateConnection()
        {
            DbConnection connection = Factory.CreateConnection();
            connection.ConnectionString = ConnectionString;

            return connection;
        }

        private DbCommand CreateCommand(string commandText, params object[] parameters)
        {
            var len = parameters.Length;

            var command = Factory.CreateCommand();
            command.CommandType = CommandType.Text;

            if (len > 0)
            {
                var formatValues = new string[len];

                for (var i = 0; i < len; i++)
                {
                    var parameter = parameters[i];
                    var rawValue = parameter as RawValue;

                    if (rawValue != null)
                    {
                        formatValues[i] = rawValue.Value;
                    }
                    else
                    {
                        var dbParameter = Factory.CreateParameter();
                        var name = CreateParameterName(i);

                        dbParameter.ParameterName = name;
                        dbParameter.Value = parameter ?? DBNull.Value;

                        formatValues[i] = name;
                        command.Parameters.Add(dbParameter);
                    }
                }

                command.CommandText = String.Format(commandText, formatValues);
            }
            else
            {
                command.CommandText = commandText;
            }

            return command;
        }

        private string _parameterFormat;

        protected virtual string CreateParameterName(int index)
        {
            if (_parameterFormat == null)
                _parameterFormat = GetProviderParameterFormatString();

            return String.Format(_parameterFormat, index);
        }

        protected virtual Converter<DbDataReader, T> GetDataReaderConverter<T>()
            where T : new()
        {
            return new DataReaderConverter<T>().Convert;
        }

        protected virtual void OnExecuteCommand(DbCommand command)
        { }

        #endregion

        #region ExecuteNonQuery

        private int ExecuteNonQuery(DbCommand command, DbConnection connection)
        {
            OnExecuteCommand(command);

            command.Connection = connection;

            return command.ExecuteNonQuery();
        }

        private int ExecuteNonQuery(DbCommand command, DbTransaction transaction)
        {
            OnExecuteCommand(command);

            command.Connection = transaction.Connection;
            command.Transaction = transaction;

            return command.ExecuteNonQuery();
        }

        private int ExecuteNonQuery(DbCommand command)
        {
            int affectedRows;

            using (DbConnection connection = CreateConnection())
            {
                connection.Open();

                affectedRows = ExecuteNonQuery(command, connection);

                connection.Close();
            }

            return affectedRows;
        }

        #endregion

        #region ExecuteNonQuery

        private int ExecuteNonQuery(string commandText, DbConnection connection)
        {
            var command = CreateCommand(commandText);
            return ExecuteNonQuery(command, connection);
        }

        private int ExecuteNonQuery(string commandText, DbTransaction transaction)
        {
            var command = CreateCommand(commandText);
            return ExecuteNonQuery(command, transaction);
        }

        public int ExecuteNonQuery(string commandText)
        {
            var command = CreateCommand(commandText);
            return ExecuteNonQuery(command);
        }

        #endregion

        #region ExecuteReader

        private DbDataReader ExecuteReader(DbCommand command, DbConnection connection)
        {
            OnExecuteCommand(command);

            command.Connection = connection;

            return command.ExecuteReader();
        }

        private DbDataReader ExecuteReader(DbCommand command, DbTransaction transaction)
        {
            OnExecuteCommand(command);

            command.Connection = transaction.Connection;
            command.Transaction = transaction;

            return command.ExecuteReader();
        }

        private DbDataReader ExecuteReader(DbCommand command)
        {
            OnExecuteCommand(command);

            DbConnection connection = CreateConnection();
            command.Connection = connection;
            connection.Open();

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region ExecuteReader

        private DbDataReader ExecuteReader(string commandText, DbConnection connection)
        {
            var command = CreateCommand(commandText);
            return ExecuteReader(command, connection);
        }

        private DbDataReader ExecuteReader(string commandText, DbTransaction transaction)
        {
            var command = CreateCommand(commandText);
            return ExecuteReader(command, transaction);
        }

        public DbDataReader ExecuteReader(string commandText)
        {
            var command = CreateCommand(commandText);
            return ExecuteReader(command);
        }

        #endregion

        #region ExecuteScalar

        private object ExecuteScalar(DbCommand command, DbConnection connection)
        {
            OnExecuteCommand(command);

            command.Connection = connection;

            var value = command.ExecuteScalar();

            return value;
        }

        private object ExecuteScalar(DbCommand command, DbTransaction transaction)
        {
            OnExecuteCommand(command);

            command.Connection = transaction.Connection;
            command.Transaction = transaction;

            var value = command.ExecuteScalar();

            return value;
        }

        private object ExecuteScalar(DbCommand command)
        {
            using (DbConnection connection = CreateConnection())
            {
                connection.Open();

                var o = ExecuteScalar(command, connection);

                connection.Close();

                return o;
            }

        }

        #endregion

        #region ExecuteScalar

        private object ExecuteScalar(string commandText, DbConnection connection)
        {
            var command = CreateCommand(commandText);
            return ExecuteScalar(command, connection);
        }

        private object ExecuteScalar(string commandText, DbTransaction transaction)
        {
            var command = CreateCommand(commandText);
            return ExecuteScalar(command, transaction);
        }
        
        public object ExecuteScalar(string commandText)
        {
            var command = CreateCommand(commandText);
            return ExecuteScalar(command);
        }
        
        #endregion

        #region ExecuteList<T>

        private List<T> ExecuteList<T>(DbCommand command, Converter<DbDataReader, T> converter, int startRecord, int maxRecords, DbConnection connection)
        {
            var list = new List<T>();

            using (DbDataReader reader = ExecuteReader(command, connection))
            {
                FillFromReader(reader, startRecord, maxRecords, r =>
                {
                    list.Add(converter(reader));
                });

                reader.Close();
            }

            return list;
        }

        private List<T> ExecuteList<T>(DbCommand command, Converter<DbDataReader, T> converter, int startRecord, int maxRecords, DbTransaction transaction)
        {
            var list = new List<T>();

            using (DbDataReader reader = ExecuteReader(command, transaction))
            {
                FillFromReader(reader, startRecord, maxRecords, r =>
                {
                    list.Add(converter(reader));
                });

                reader.Close();
            }

            return list;
        }

        private List<T> ExecuteList<T>(DbCommand command, Converter<DbDataReader, T> converter, int startRecord, int maxRecords)
        {
            List<T> list;

            using (DbConnection connection = CreateConnection())
            {
                connection.Open();

                list = ExecuteList<T>(command, converter, startRecord, maxRecords, connection);

                connection.Close();
            }

            return list;
        }

        private List<T> ExecuteList<T>(DbCommand command, Converter<DbDataReader, T> converter, DbConnection connection)
        {
            return ExecuteList<T>(command, converter, 0, 0, connection);
        }

        private List<T> ExecuteList<T>(DbCommand command, Converter<DbDataReader, T> converter, DbTransaction transaction)
        {
            return ExecuteList<T>(command, converter, 0, 0, transaction);
        }

        private List<T> ExecuteList<T>(DbCommand command, Converter<DbDataReader, T> converter)
        {
            return ExecuteList<T>(command, converter, 0, 0);
        }

        private List<T> ExecuteList<T>(DbCommand command, DbConnection connection)
            where T : new()
        {
            var converter = GetDataReaderConverter<T>();
            return ExecuteList<T>(command, converter, connection);
        }

        private List<T> ExecuteList<T>(DbCommand command, DbTransaction transaction)
            where T : new()
        {
            var converter = GetDataReaderConverter<T>();
            return ExecuteList<T>(command, converter, transaction);
        }

        private List<T> ExecuteList<T>(DbCommand command)
            where T : new()
        {
            var converter = GetDataReaderConverter<T>();
            return ExecuteList<T>(command, converter);
        }

        #endregion

        #region ExecuteList<T>

        private List<T> ExecuteList<T>(string commandText, DbConnection connection)
            where T : new()
        {
            var command = CreateCommand(commandText);
            return ExecuteList<T>(command, connection);
        }

        private List<T> ExecuteList<T>(string commandText, DbTransaction transaction)
            where T : new()
        {
            var command = CreateCommand(commandText);
            return ExecuteList<T>(command, transaction);
        }
        
        public List<T> ExecuteList<T>(string commandText)
            where T : new()
        {
            var command = CreateCommand(commandText);
            return ExecuteList<T>(command);
        }

        #endregion
    }
}