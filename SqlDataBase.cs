using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;


namespace Sxmobi.Tools
{

    /// <summary>
    ///SqlDataBase 的摘要说明
    /// </summary>
    public class SqlDataBase
    {

        public string SqlConnectionString = "user id=sa;password=sxmobi&8801;initial catalog=VPPAY;data source=127.0.0.1;Connect Timeout=30;";
        public static string ConnectiongString = "user id=sa;password=sxmobi&8801;initial catalog=CoopCharge;data source=127.0.0.1;Connect Timeout=30;";

        //public string SqlConnectionString = "user id=sa;password=123;initial catalog=VPPAY;data source=SXMOBILBL;Connect Timeout=30;";
        //public static string ConnectiongString = "user id=sa;password=123;initial catalog=CoopCharge;data source=SXMOBILBL;Connect Timeout=30;";
        /// <summary>
        ///指定数据库链接串
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlDataBase()
        {
        }

        /// <summary>
        ///指定数据库链接串
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlDataBase(string connectionString)
        {
            this.SqlConnectionString = connectionString;
        }

        private SqlConnection cn;		//创建SQL连接
        private SqlDataAdapter sda;		//创建SQL数据适配器
        private SqlDataReader sdr;		//创建SQL数据读取器
        private SqlCommand cmd;			//创建SQL命令对象
        private SqlParameter param;     //创建SQL参数
        private DataSet ds;				//创建数据集
        private DataView dv;			//创建视图 
        public int tCount = 0;          //数据集记录数   

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            #region
            cn = new SqlConnection(SqlConnectionString);
            cn.Open();
            #endregion
        }


        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            #region
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
            }
            #endregion
        }

        public void Dispose()
        {
            #region
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
            }
            #endregion
        }


        /// <summary>
        /// 返回DataSet数据集
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        public DataSet GetDs(string strSql)
        {
            #region
            Open();
            sda = new SqlDataAdapter(strSql, cn);
            ds = new DataSet();
            sda.Fill(ds);
            Close();
            this.tCount = ds.Tables[0].Rows.Count;
            return ds;
            #endregion
        }

        /// <summary>
        /// 添加DataSet表
        /// </summary>
        /// <param name="ds">DataSet对象</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="strTableName">表名</param>
        public void GetDs(DataSet ds, string strSql, string strTableName)
        {
            #region
            Open();
            sda = new SqlDataAdapter(strSql, cn);
            sda.Fill(ds, strTableName);
            Close();
            #endregion
        }


        /// <summary>
        /// 返回DataView数据视图
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        public DataView GetDv(string strSql)
        {
            #region
            dv = GetDs(strSql).Tables[0].DefaultView;
            return dv;
            #endregion
        }


        /// <summary>
        /// 获得DataTable对象
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public DataTable GetTable(string strSql)
        {
            #region
            return GetDs(strSql).Tables[0];
            #endregion
        }


        /// <summary>
        /// 获得SqlDataReader对象 使用完须关闭DataReader,关闭数据库连接
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string strSql)
        {
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            sdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return sdr;
            #endregion
        }



        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        public void RunSql(string strSql)
        {
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            cmd.ExecuteNonQuery();
            Close();
            #endregion
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strSql">需要执行的SQL</param>
        /// <param name="commandTimeout">超时时间</param>
        public void RunSql(string strSql, int commandTimeout)
        {
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            cmd.CommandTimeout = commandTimeout;
            cmd.ExecuteNonQuery();
            Close();
            #endregion
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public void RunSql(string strSql, params SqlParameter[] cmdParms)
        {
            #region
            Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, cn, null, strSql, cmdParms);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    Close();
                }
            }

            Close();
            #endregion
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object RunSqlReturn(string strSql, params SqlParameter[] cmdParms)
        {
            #region
            Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, cn, null, strSql, cmdParms);
                    string tReturn = Convert.ToString(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    return tReturn;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    Close();
                }
            }

            #endregion
        }



        /// <summary>
        /// 执行SQL语句，并返回第一行第一列结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public string RunSqlReturn(string strSql)
        {
            #region
            string strReturn = "";
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                strReturn = cmd.ExecuteScalar().ToString();
                //this.tCount = Convert.ToInt32(strReturn);
            }
            catch { }
            Close();
            return strReturn;
            #endregion
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName)
        {
            #region
            cmd = CreateCommand(procName, null);
            cmd.ExecuteNonQuery();
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
            #endregion
        }

        /// <summary>
        /// 执行存储过程(By Foolin)
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="commandTimeout">超时时间</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName, int commandTimeout)
        {
            #region
            cmd = CreateCommand(procName, null);
            cmd.CommandTimeout = commandTimeout;
            cmd.ExecuteNonQuery();
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
            #endregion
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName, SqlParameter[] prams)
        {
            #region
            cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
            #endregion
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="procName">存储过程名称</param>
        ///// <param name="prams">存储过程所需参数</param>
        ///// <param name="commandTimeout">超时时间</param>
        ///// <returns></returns>
        //public int RunProc(string procName, SqlParameter[] prams, int commandTimeout)
        //{
        //    #region
        //    cmd = CreateCommand(procName, prams);
        //    cmd.CommandTimeout = commandTimeout;
        //    cmd.ExecuteNonQuery();
        //    Close();
        //    return (int)cmd.Parameters["ReturnValue"].Value;
        //    #endregion
        //}

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>数据源</returns>
        public DataTable RunProcDataTalbe(string procName, SqlParameter[] prams)
        {
            cmd = CreateCommand(procName, prams);
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Close();
            return dt;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="prams"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int RunProc(string procName, SqlParameter[] prams, int timeout)
        {
            #region
            cmd = CreateCommand(procName, prams);
            cmd.CommandTimeout = timeout;  //设置超时
            cmd.ExecuteNonQuery();
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
            #endregion
        }


        /// <summary>
        /// 执行存储过程返回DataReader对象
        /// </summary>
        /// <param name="procName">Sql语句</param>
        /// <param name="dataReader">DataReader对象</param>
        public void RunProc(string procName, SqlDataReader dataReader)
        {
            #region
            cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            #endregion
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">DataReader对象</param>
        public void RunProc(string procName, SqlParameter[] prams, SqlDataReader dataReader)
        {
            #region
            cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            #endregion
        }




        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            #region
            // 确认打开连接
            Open();
            cmd = new SqlCommand(procName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            // 依次把参数传入存储过程
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }

            // 加入返回参数
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
            #endregion
        }


        /// <summary>
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            #region
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);

            #endregion
        }

        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            #region
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
            #endregion
        }


        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            #region

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
            #endregion
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }


}