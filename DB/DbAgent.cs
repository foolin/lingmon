using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;

namespace Utility.DB
{
    /// <summary>
    /// Name:Sql���ݴ����࣬ͨ���̳У���֧��MSSql��Access��Oracle���ݿ�
    /// Description:Ϊ�����߼����ṩʵ�ֻ���
    /// </summary>
    public abstract class DbAgent : IDisposable
    {
        string _connectString;
        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        protected virtual string ConnectionString
        {
            get { return _connectString; }
            set { _connectString = value; }
        }

        DatabaseType _dbtype;
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        protected virtual DatabaseType DBType
        {
            get { return _dbtype; }
            set { _dbtype = value; }
        }

        /// <summary>
        /// ����һ�����ݿ�����
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
        ///����һ�����ݿ�����
        /// </summary>
        /// <param name="name">�洢���̲�������</param>
        /// <param name="valu">������ֵ</param>
        /// <param name="type">��������</param>
        /// <param name="len">���ͳ���</param>
        /// <param name="output">�Ƿ�Ϊ�������</param>
        /// <returns>������</returns>
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
        ///����һ�����ݿ�����
        /// </summary>
        /// <param name="name">�洢���̲�������</param>
        /// <param name="valu">������ֵ</param>
        /// <param name="type">��������</param>
        /// <param name="len">���ͳ���</param>
        /// <param name="output">�Ƿ�Ϊ�������</param>
        /// <returns>������</returns>
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
        /// ����һ�����ݿ�����
        /// </summary>
        protected virtual IDbDataParameter NewParam(string name, object valu, DbType type, int len)
        {
            return this.NewParam(name, valu, type, len, false);
        }

        /// <summary>
        /// ����һ�����ݿ�����
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
        /// �������ݿ����������ַ�������һ��ִ����
        /// </summary>
        protected virtual IDbExecutor NewExecutor()
        {
            return DbFactory.CreateExecutor(this.DBType, this.ConnectionString);
        }

        #region IDisposable ��Ա

        public void Dispose()
        {
            // TODO:  ��� DataAgent.Dispose ʵ��
        }

        #endregion
    }
}
