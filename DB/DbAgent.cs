using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;

namespace Utility.DB
{
    /// <summary>
    /// Name:Sql数据代理类，通过继承，可支持MSSql、Access、Oracle数据库
    /// Description:为数据逻辑层提供实现基础
    /// </summary>
    public abstract class DbAgent : IDisposable
    {
        string _connectString;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected virtual string ConnectionString
        {
            get { return _connectString; }
            set { _connectString = value; }
        }

        DatabaseType _dbtype;
        /// <summary>
        /// 数据库类型
        /// </summary>
        protected virtual DatabaseType DBType
        {
            get { return _dbtype; }
            set { _dbtype = value; }
        }

        /// <summary>
        /// 创建一个数据库连接
        /// </summary>
        protected virtual IDbConnection NewConnection()
        {
            switch (this.DBType)
            {
                case DatabaseType.SqlServer:
                    {
                        return new SqlConnection(this.ConnectionString);
                    }
                case DatabaseType.Oracle:
                    {
                        return new OracleConnection(this.ConnectionString);
                    }
                case DatabaseType.Access:
                    {
                        return new OleDbConnection(this.ConnectionString);
                    }
                case DatabaseType.OleDb:
                    {
                        return new OleDbConnection(this.ConnectionString);
                    }
                default:
                    {
                        return new SqlConnection(this.ConnectionString);
                    }
            }
        }

        /// <summary>
        ///创建一个数据库连接
        /// </summary>
        /// <param name="name">存储过程参数名称</param>
        /// <param name="valu">传进的值</param>
        /// <param name="type">数据类型</param>
        /// <param name="len">类型长度</param>
        /// <param name="output">是否为输出参数</param>
        /// <returns>参数类</returns>
        protected virtual IDbDataParameter NewParam(string name, object valu, DbType type, int len, bool output)
        {
            IDbDataParameter param;
            switch (this.DBType)
            {
                case DatabaseType.SqlServer:
                    {
                        param = new SqlParameter();
                        param.ParameterName = name;
                        break;
                    }
                case DatabaseType.Oracle:
                    {
                        param = new OracleParameter();
                        param.ParameterName = name.Replace("@", ":");
                        break;
                    }
                case DatabaseType.Access:
                    {
                        param = new OleDbParameter();
                        param.ParameterName = name;
                        break;
                    }
                case DatabaseType.OleDb:
                    {
                        param = new OleDbParameter();
                        param.ParameterName = name;
                        break;
                    }
                default:
                    {
                        param = new SqlParameter();
                        param.ParameterName = name;
                        break;
                    }
            }

            param.DbType = type;
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
        ///创建一个数据库连接
        /// </summary>
        /// <param name="name">存储过程参数名称</param>
        /// <param name="valu">传进的值</param>
        /// <param name="type">数据类型</param>
        /// <param name="len">类型长度</param>
        /// <param name="output">是否为输出参数</param>
        /// <returns>参数类</returns>
        protected virtual IDbDataParameter NewOracleParam(string name, object valu, OracleType type, int len, bool output)
        {
            IDbDataParameter param;
            param = new OracleParameter(name.Replace("@", ":"), type);
            
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
        /// 创建一个数据库连接
        /// </summary>
        protected virtual IDbDataParameter NewParam(string name, object valu, DbType type, int len)
        {
            return this.NewParam(name, valu, type, len, false);
        }

        /// <summary>
        /// 创建一个数据库连接
        /// </summary>
        protected virtual IDbDataParameter NewParam(string name, object valu)
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
            //	return this.NewParam(name, valu, DbType.String, 0, false);
        }

        public DbAgent() { }

        public DbAgent(DatabaseType dbType, string connectString)
        {
            this.DBType = dbType;
            this.ConnectionString = connectString;
        }

        /// <summary>
        /// 根据数据库类别和连接字符串创建一个执行者
        /// </summary>
        protected virtual IDbExecutor NewExecutor()
        {
            return DbFactory.CreateExecutor(this.DBType, this.ConnectionString);
        }

        #region IDisposable 成员

        public void Dispose()
        {
            // TODO:  添加 DataAgent.Dispose 实现
        }

        #endregion
    }
}
