using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sxmobi.Utility.DB
{
    public class SqlDataBase
    {
        //获取数据库连接字符串
        private string SqlConnectionString;

        private SqlConnection cn;		//创建SQL连接
        private SqlDataAdapter sda;		//创建SQL数据适配器
        private SqlDataReader sdr;		//创建SQL数据读取器
        private SqlCommand cmd;			//创建SQL命令对象
        private SqlParameter param;     //创建SQL参数
        private DataSet ds;				//创建数据集
        private DataView dv;			//创建视图

        public SqlDataBase()
        {
            //SqlConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            //SqlConnectionString = SysConfig.ConnectionString();
        }


        public SqlDataBase(string ConnectionString)
        {
            SqlConnectionString = ConnectionString;
        }

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

        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="strSql"></param>
        public void RunSql(string strSql)
        {
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            try
            {
            	cmd.ExecuteNonQuery();
          	}
          	finally
          	{
            	Close();
            }
            #endregion
        }
        /// <summary>
        /// 执行SQL语句，并传超时时间
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="timeout">超时时间</param>
        public void RunSql(string strSql, int timeout)
        {
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            try
            {
                cmd.CommandTimeout = timeout;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                Close();
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
            }
            catch
            {
                throw;
            }
            Close();
            return strReturn;
            #endregion
        }
        /// <summary>
        /// 执行SQL语句，并返回第一行第一列结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>返回第一行第一列结果</returns>
        public string RunSqlReturn(string strSql, int timeout)
        {
            #region
            string strReturn = "";
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                cmd.CommandTimeout = timeout;
                strReturn = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                throw;
            }
            Close();
            return strReturn;
            #endregion
        }

        /// <summary>
        /// 执行SQL语句，并返回第一行第一列Int结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>如果返回数据不是整型，则返回-1</returns>
        public int RunSqlReturnInt(string strSql)
        {
            #region
            string strReturn = "";
            int intReturn = -1;
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                strReturn = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                throw;
            }
            Close();
            try
            {
                intReturn = int.Parse(strReturn);
            }
            catch
            {
                intReturn = -1;
            }
            return intReturn;
            #endregion
        }
        /// <summary>
        /// 执行SQL语句，并返回第一行第一列Int结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>如果返回数据不是整型，则返回-1</returns>
        public int RunSqlReturnInt(string strSql, int timeout)
        {
            #region
            string strReturn = "";
            int intReturn = 0;
            Open();
            try
            {
                cmd = new SqlCommand(strSql, cn);
                cmd.CommandTimeout = timeout;
                strReturn = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                throw;
            }
            Close();
            try
            {
                intReturn = int.Parse(strReturn);
            }
            catch
            {
                intReturn = -1;
            }
            return intReturn;
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
        /// 获得SqlDataReader对象 使用完须关闭DataReader,关闭数据库连接
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>SqlDataReader数据</returns>
        public SqlDataReader GetDataReader(string strSql, int timeout)
        {
            #region
            Open();
            cmd = new SqlCommand(strSql, cn);
            cmd.CommandTimeout = timeout;
            sdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return sdr;
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
        /// 分页获得DataSet对象,第一个表保存记录总数，第二个表保存读取的对应页的记录
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public DataSet GetDataSetByPage(string strSql, string orderBy, int pageSize, int pageNo)
        {
            #region
            StringBuilder tmpSql = new StringBuilder();
            tmpSql.Append("select count(*) " + strSql.Substring(strSql.ToLower().IndexOf("from")));
            tmpSql.Append("; select * from (" + strSql.Substring(0, strSql.ToLower().IndexOf("from")) + ",row_number() over (" + orderBy + ") as rownum " + strSql.Substring(strSql.ToLower().IndexOf("from")) + ") as tmpTable where rownum between " + (pageSize * (pageNo) + 1).ToString() + " and " + (pageSize * (pageNo + 1)).ToString());

            return GetDs(tmpSql.ToString());
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
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <returns>返回存储过程返回值</returns>
        /// <param name="timeout">执行超时时间</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName, int timeout)
        {
            #region
            cmd = CreateCommand(procName, null);
            cmd.CommandTimeout = timeout;
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
        public int RunProc(string procName, SqlParameter[] prams, int timeout)
        {
            #region
            cmd = CreateCommand(procName, prams);
            cmd.CommandTimeout = timeout;
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
        /// <returns>数据源</returns>
        public DataTable GetProcTable(string procName, SqlParameter[] prams)
        {
            //cmd = CreateCommand(procName, prams);
            //sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //Close();
            //return dt;
            return GetProcDs(procName, prams).Tables[0];
        }



        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>数据源</returns>
        public DataTable GetProcTable(string procName, SqlParameter[] prams, int timeout)
        {
            //cmd = CreateCommand(procName, prams);
            //cmd.CommandTimeout = timeout;
            //sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //Close();
            //return dt;
            return GetProcDs(procName, prams, timeout).Tables[0];
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>数据源</returns>
        public DataSet GetProcDs(string procName, SqlParameter[] prams)
        {
            cmd = CreateCommand(procName, prams);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
            Close();
            return ds;
        }



        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>数据源</returns>
        public DataSet GetProcDs(string procName, SqlParameter[] prams, int timeout)
        {
            cmd = CreateCommand(procName, prams);
            cmd.CommandTimeout = timeout;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
            Close();
            return ds;
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
        /// 执行存储过程返回DataReader对象
        /// </summary>
        /// <param name="procName">Sql语句</param>
        /// <param name="dataReader">DataReader对象</param>
        /// <param name="timeout">超时时间</param>
        public void RunProc(string procName, SqlDataReader dataReader, int timeout)
        {
            #region
            cmd = CreateCommand(procName, null);
            cmd.CommandTimeout = timeout;
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
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">DataReader对象</param>
        /// <param name="timeout">超时时间</param>
        public void RunProc(string procName, SqlParameter[] prams, SqlDataReader dataReader, int timeout)
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
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns>返回SqlCommand对象</returns>
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams, int timeout)
        {
            #region
            // 确认打开连接
            Open();
            cmd = new SqlCommand(procName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = timeout;

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


        #region 新增存储过程参数2010-09-23 by Foolin
        /// <summary>
        ///创建一个存储过程对象
        /// </summary>
        /// <param name="name">存储过程参数名称</param>
        /// <param name="valu">传进的值</param>
        /// <param name="type">数据类型</param>
        /// <param name="len">类型长度</param>
        /// <param name="output">是否为输出参数</param>
        /// <returns>参数类</returns>
        public SqlParameter NewParam(string name, object valu, DbType type, int len, bool output)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = type;
            param.ParameterName = name;
            param.Value = valu;
            if (len > 0)
            {
                param.Size = len;
            }

            if (output)
            {
                param.Direction = ParameterDirection.Output;
            }
            return param;
        }



        /// <summary>
        /// 创建一个存储过程对象
        /// </summary>
        public SqlParameter NewParam(string name, object valu, DbType type, int len)
        {
            return this.NewParam(name, valu, type, len, false);
        }

        /// <summary>
        /// 创建一个存储过程对象
        /// </summary>
        public SqlParameter NewParam(string name, object valu)
        {
            switch (valu.GetType().Name)
            {
                case "String":
                    return this.NewParam(name, valu, DbType.String, 0);
                case "DateTime":
                    return this.NewParam(name, valu, DbType.DateTime, 8);
                case "Boolean":
                    return this.NewParam(name, valu, DbType.Boolean, 1);
                case "Int32":
                    return this.NewParam(name, valu, DbType.Int32, 4);
                case "Int16":
                    return this.NewParam(name, valu, DbType.Int16, 2);
                default:
                    return this.NewParam(name, valu, DbType.String, 0);
            }
        }

        #endregion


        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public void RunTran(string strSql)
        {
            Open();
            SqlTransaction myTran;
            SqlCommand myComm = new SqlCommand();

            //创建一个事务
            myTran = cn.BeginTransaction();
            //从此开始，基于该连接的数据操作都被认为是事务的一部分
            //下面绑定连接和事务对象
            myComm.Connection = cn;
            myComm.Transaction = myTran;

            try
            {
                myComm.CommandText = strSql;
                myComm.ExecuteNonQuery();


                //提交事务
                myTran.Commit();
            }
            catch
            {
                myTran.Rollback();
                throw;
            }
            finally
            {
                Close();
            }

        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public void RunTran(string strSql, int timeout)
        {
            Open();
            SqlTransaction myTran;
            SqlCommand myComm = new SqlCommand();

            //创建一个事务
            myTran = cn.BeginTransaction();
            //从此开始，基于该连接的数据操作都被认为是事务的一部分
            //下面绑定连接和事务对象
            myComm.Connection = cn;
            myComm.Transaction = myTran;

            try
            {
                myComm.CommandText = strSql;
                myComm.CommandTimeout = timeout;
                myComm.ExecuteNonQuery();


                //提交事务
                myTran.Commit();
            }
            catch
            {
                myTran.Rollback();
                throw;
            }
            finally
            {
                Close();
            }

        }


        ///// <summary>
        ///// 存储过程分页
        ///// </summary>
        ///// <param name="strSql"></param>
        ///// <param name="strSort"></param>
        ///// <param name="pageSize"></param>
        ///// <param name="pageIndex"></param>
        ///// <param name="totalCount"></param>
        ///// <returns></returns>
        //public DataSet GetPageDs(string strSql, string strSort, int pageSize, int pageIndex, out int totalCount)
        //{
        //    DataSet dsReturn = null;
        //    SqlParameter records = NewParam("@TotalCount", 0, DbType.Int32, 32, true);
        //    SqlParameter[] sqlParams = {
        //                               NewParam("@SQL", strSql) //SQL语句
        //                               , NewParam("@Sort", strSort) //排序
        //                               , NewParam("@PageSize", pageSize)    //每页记录数大小
        //                               , NewParam("@PageIndex", pageIndex)  //索引页：从1开始
        //                               , records }; //返回的总记录数
        //    dsReturn = GetProcDs("PR_Paging", sqlParams);
        //    totalCount = (int)records.Value;

        //    return dsReturn;
        //}

        ///// <summary>
        ///// 存储过程分页
        ///// </summary>
        ///// <param name="strSql"></param>
        ///// <param name="strSort"></param>
        ///// <param name="pageSize"></param>
        ///// <param name="pageIndex"></param>
        ///// <param name="totalCount"></param>
        ///// <returns></returns>
        //public DataTable GetPageTable(string strSql, string strSort, int pageSize, int pageIndex, out int totalCount)
        //{
        //    return GetPageDs(strSql, strSort, pageSize, pageIndex, out totalCount).Tables[0];
        //}

    }
}
