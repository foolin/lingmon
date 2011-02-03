using System;
using System.Data;
using System.Data.SqlClient;

namespace Utility.DB
{
	/// <summary>
	/// Name:Sql Server数据存取器
	/// Description:实现基于Sql Server的定义数据存取器
    /// </summary>
	public class SqlDbExecutor : IDbExecutor
	{
		public SqlDbExecutor(){}

		public SqlDbExecutor(string connectString)
		{
			this.ConnectionString = connectString;
		}

		string _connectString;
		/// <summary>
		/// 连接字符串
		/// </summary>
		public string ConnectionString
		{
			get{return _connectString;}
			set{_connectString = value;}
		}

		#region IDbExecutor 成员

		public IDataReader ReadData(string commandText)
		{
			return this.ReadData( CommandType.Text, commandText);
		}

		public IDataReader ReadData(string procedureName, IDbDataParameter[] parameters)
		{
			return this.ReadData( CommandType.StoredProcedure, procedureName, parameters);
		}

		public IDataReader ReadData( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
		{
			SqlConnection conn = new SqlConnection(this.ConnectionString);
			SqlCommand cmd = new SqlCommand(cmdText, conn);
			cmd.CommandType = cmdType;
			try
			{
				conn.Open();
				if(parameters != null)
				{
					for(int i=0;i<parameters.Length;i++)
					{
						cmd.Parameters.Add((SqlParameter)parameters[i]);
					}
				}
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " SQL:" + cmdText, ex);
            }
        }


		public Object ExecuteScalar(string commandText)
		{
			return this.ExecuteScalar( CommandType.Text, commandText);
		}

		public Object ExecuteScalar(string procedureName, IDbDataParameter[] parameters)
		{
			return this.ExecuteScalar( CommandType.StoredProcedure, procedureName, parameters);
		}

		public Object ExecuteScalar( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
		{
			SqlConnection conn = new SqlConnection(this.ConnectionString);
			SqlCommand cmd = new SqlCommand(cmdText,conn);
			cmd.CommandType = cmdType;
			try
			{
				conn.Open();
				if(parameters != null)
				{
					for(int i=0;i<parameters.Length;i++)
					{
						cmd.Parameters.Add((SqlParameter)parameters[i]);
					}
				}
				return cmd.ExecuteScalar();
			}
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " SQL:" + cmdText, ex);
            }
            finally
			{
				cmd.Dispose();conn.Dispose();
			}
		}

		public int ExecuteNonQuery(string commandText)
		{
			return this.ExecuteNonQuery( CommandType.Text, commandText);
		}

		public int ExecuteSql(string commandText, IDbDataParameter[] parameters)
		{
			return this.ExecuteNonQuery( CommandType.Text, commandText, parameters);
		}

		public int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters)
		{
			return this.ExecuteNonQuery( CommandType.StoredProcedure, procedureName, parameters);		
		}

		public int ExecuteNonQuery(string commandText, IDbConnection conn)
		{
			SqlCommand cmd = new SqlCommand(commandText, (SqlConnection)conn);
            
			try
			{
				return cmd.ExecuteNonQuery();
			}
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " SQL:" + commandText, ex);
            }
            finally
			{
				cmd.Dispose();
			}
		}

		public int ExecuteSql(string commandText, IDbDataParameter[] parameters, IDbConnection conn)
		{
			SqlCommand cmd = new SqlCommand(commandText,(SqlConnection)conn);
			try
			{
				if(parameters != null)
				{
					for(int i=0;i<parameters.Length;i++)
					{
						cmd.Parameters.Add((SqlParameter)parameters[i]);
					}
				}
				return cmd.ExecuteNonQuery();
			}
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " SQL:" + commandText, ex);
            }
            finally
			{
				cmd.Dispose();
			}		
		}

		public int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters, IDbConnection conn)
		{
			SqlCommand cmd = new SqlCommand(procedureName, (SqlConnection)conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				if(parameters != null)
				{
					for(int i=0;i<parameters.Length;i++)
					{
						cmd.Parameters.Add((SqlParameter)parameters[i]);
					}
				}
				return cmd.ExecuteNonQuery();
			}
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " Procedure:" + procedureName, ex);
            }
            finally
			{
				cmd.Dispose();
			}		
		}

		public int ExecuteNonQuery( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
		{
			SqlConnection conn = new SqlConnection(this.ConnectionString);
			SqlCommand cmd = new SqlCommand(cmdText,conn);
			cmd.CommandType = cmdType;
			try
			{
				conn.Open();
				if(parameters != null)
				{
					for(int i=0;i<parameters.Length;i++)
					{
						cmd.Parameters.Add((SqlParameter)parameters[i]);
					}
				}
				return cmd.ExecuteNonQuery();
			}
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " SQL:" + cmdText, ex);
            }
            finally
			{
				cmd.Dispose();conn.Dispose();
			}
		}

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, IDbTransaction tran, params IDbDataParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(cmdText);
            cmd.Transaction = (SqlTransaction)tran;
            cmd.Connection = cmd.Transaction.Connection;
            cmd.CommandType = cmdType;
            try
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.Parameters.Add((SqlParameter)parameters[i]);
                    }
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " SQL:" + cmdText, ex);
            }
            finally
            {
                cmd.Dispose(); 
            }
        }

		public DataSet GetDataSet(string commandText)
		{
			return this.GetDataSet( CommandType.Text, commandText);
		}

		public DataSet GetDataSet(string procedureName, IDbDataParameter[] parameters)
		{
			return this.GetDataSet( CommandType.StoredProcedure, procedureName, parameters);
		}

		public DataSet GetDataSet( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
		{
			SqlConnection conn = new SqlConnection(this.ConnectionString);
			SqlCommand cmd = new SqlCommand(cmdText,conn);
			cmd.CommandType = cmdType;
			SqlDataAdapter ada = new SqlDataAdapter(cmd);
			try
			{
				conn.Open();
				if(parameters != null)
				{
					for(int i=0;i<parameters.Length;i++)
					{
						cmd.Parameters.Add((SqlParameter)parameters[i]);
					}
				}
				DataSet ds = new DataSet();
				ada.Fill(ds);
				return ds;
			}
			catch(Exception ex)
            {
                throw new ApplicationException(ex.Message + " SQL:" + cmdText, ex);
            }
			finally
			{
				cmd.Parameters.Clear();cmd.Dispose();ada.Dispose();conn.Dispose();
			}
		}

		public int ExecuteProcedure( string procedureName, params IDbDataParameter[] parameters)
		{
			SqlConnection conn = new SqlConnection(this.ConnectionString);
			SqlCommand cmd = new SqlCommand(procedureName,conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				conn.Open();
				if(parameters != null)
				{
					for(int i=0;i<parameters.Length;i++)
					{
						cmd.Parameters.Add((SqlParameter)parameters[i]);
					}
				}

				SqlParameter paramReturn = new SqlParameter("@ReturnValue", SqlDbType.Int, 4);
				paramReturn.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add( paramReturn);

				cmd.ExecuteNonQuery();

				return (int)paramReturn.Value;
			}
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message + " Procedure:" + procedureName, ex);
            }
            finally
			{
				cmd.Dispose();conn.Dispose();
			}
		}

		public void Dispose()
		{
			// TODO:  添加 DataAgent.Dispose 实现
		}
		#endregion
	}
}
