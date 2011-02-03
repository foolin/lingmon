using System;
using System.Data;
using System.Data.OracleClient;

namespace Utility.DB
{
    /// <summary>
    /// Name:Oracle数据存取器
    /// Description:实现基于Oracle的定义数据存取器
    /// </summary>
    public class OracleDbExecutor : IDbExecutor
    {
        public OracleDbExecutor() { }

        public OracleDbExecutor(string connectString)
        {
            this.ConnectionString = connectString;
        }

        string _connectString;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return _connectString; }
            set { _connectString = value; }
        }

        #region IDbExecutor 成员

        public IDataReader ReadData(string commandText)
        {
            return this.ReadData(CommandType.Text, commandText);
        }

        public IDataReader ReadData(string procedureName, IDbDataParameter[] parameters)
        {
            return this.ReadData(CommandType.StoredProcedure, procedureName, parameters);
        }

        public IDataReader ReadData(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = new OracleCommand(ConvertSql(cmdText), conn);
            cmd.CommandType = cmdType;
            try
            {
                conn.Open();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(ConvertParameter((OracleParameter)parameters[i], cmdType));
                    }
                }
                return cmd.ExecuteReader();//CommandBehavior.CloseConnection
            }
            catch (Exception ex) { throw ex; }
        }


        public Object ExecuteScalar(string commandText)
        {
            return this.ExecuteScalar(CommandType.Text, commandText);
        }

        public Object ExecuteScalar(string procedureName, IDbDataParameter[] parameters)
        {
            return this.ExecuteScalar(CommandType.StoredProcedure, procedureName, parameters);
        }

        public Object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = new OracleCommand(ConvertSql(cmdText), conn);
            cmd.CommandType = cmdType;
            try
            {
                conn.Open();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(ConvertParameter((OracleParameter)parameters[i], cmdType));
                    }
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Dispose(); conn.Dispose();
            }
        }

        public int ExecuteNonQuery(string commandText)
        {
            return this.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public int ExecuteSql(string commandText, IDbDataParameter[] parameters)
        {
            return this.ExecuteNonQuery(CommandType.Text, commandText, parameters);
        }

        public int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters)
        {
            return this.ExecuteNonQuery(CommandType.StoredProcedure, procedureName, parameters);
        }

        public int ExecuteNonQuery(string commandText, IDbConnection conn)
        {
            OracleCommand cmd = new OracleCommand(commandText, (OracleConnection)conn);
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Dispose();
            }
        }

        public int ExecuteSql(string commandText, IDbDataParameter[] parameters, IDbConnection conn)
        {
            OracleCommand cmd = new OracleCommand(ConvertSql(commandText), (OracleConnection)conn);
            try
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add((OracleParameter)parameters[i]);
                    }
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Dispose();
            }
        }

        public int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters, IDbConnection conn)
        {
            OracleCommand cmd = new OracleCommand(procedureName, (OracleConnection)conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(ConvertParameter((OracleParameter)parameters[i], CommandType.StoredProcedure));
                    }
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Dispose();
            }
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = new OracleCommand(ConvertSql(cmdText), conn);
            cmd.CommandType = cmdType;
            try
            {
                conn.Open();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(ConvertParameter((OracleParameter)parameters[i], cmdType));
                    }
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Dispose(); conn.Dispose();
            }
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, IDbTransaction tran, params IDbDataParameter[] parameters)
        {
            OracleCommand cmd = new OracleCommand(ConvertSql(cmdText));
            cmd.Transaction = (OracleTransaction)tran;
            cmd.Connection = cmd.Transaction.Connection;
            cmd.CommandType = cmdType;
            try
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(ConvertParameter((OracleParameter)parameters[i], cmdType));
                    }
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Dispose();
            }
        }

        public DataSet GetDataSet(string commandText)
        {
            return this.GetDataSet(CommandType.Text, commandText);
        }

        public DataSet GetDataSet(string procedureName, IDbDataParameter[] parameters)
        {
            return this.GetDataSet(CommandType.StoredProcedure, procedureName, parameters);
        }

        public DataSet GetDataSet(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = new OracleCommand(ConvertSql(cmdText), conn);
            cmd.CommandType = cmdType;
            OracleDataAdapter ada = new OracleDataAdapter(cmd);
            try
            {
                conn.Open();
                //****参数约定：如果没有指定p_ds参数，约定为返回单个结果集，否则由调用程序创建结果集参数（游标类型）
                if (cmdType == CommandType.StoredProcedure && (parameters.Length == 0 || parameters[0].ParameterName.Contains("p_ds") == false))
                {
                    OracleParameter p_ds = new OracleParameter("p_ds", OracleType.Cursor, 8000, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull);
                    cmd.Parameters.Add(p_ds);
                }
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(ConvertParameter((OracleParameter)parameters[i], cmdType));
                    }
                }
                DataSet ds = new DataSet();
                ada.Fill(ds);
                return ds;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Parameters.Clear(); cmd.Dispose(); ada.Dispose(); conn.Dispose();
            }
        }

        public int ExecuteProcedure(string procedureName, params IDbDataParameter[] parameters)
        {
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            OracleCommand cmd = new OracleCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add(ConvertParameter((OracleParameter)parameters[i], CommandType.StoredProcedure));
                    }
                }
                OracleParameter paramReturn = new OracleParameter("ReturnValue", OracleType.Int32, 4);
                paramReturn.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(paramReturn);

                cmd.ExecuteNonQuery();

                return (int)paramReturn.Value;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Dispose(); conn.Dispose();
            }
        }

        string ConvertSql(string sql)
        {
            return sql.Replace("@", ":").Replace("= ''", " is null").Replace("=''", " is null");
        }

        OracleParameter ConvertParameter(OracleParameter parameter, CommandType cmdType)
        {
            if (cmdType == CommandType.StoredProcedure)
                parameter.ParameterName = parameter.ParameterName.Replace(":", "p_");
            return parameter;
        }

        public void Dispose()
        {
            // TODO:  添加 DataAgent.Dispose 实现
        }
        #endregion
    }
}
