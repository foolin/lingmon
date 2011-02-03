using System;
using System.Data;

namespace Studio.Data
{
	/// <summary>
	/// Name:数据存取器(执行者)接口
	/// Description:定义数据存取器公共接口方法,逻辑层调用此接口进行数据操作,而不是调用具体的接口实现类
	/// </summary>
	public interface IDbExecutor : IDisposable
	{
		/// <summary>
		/// 执行SQL语句，返回只进读取器
		/// </summary>
		/// <param name="commandText">要执行的SQL语句</param>
		/// 
		IDataReader ReadData(string commandText);


		/// <summary>
		/// 执行存储过程，返回只进读取器
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">参数集合，已经设置好名称、类型、值，如果没有参数，传递null</param>
		IDataReader ReadData(string procedureName, IDbDataParameter[] parameters);
		
		/// <summary>
		/// 根据命令类型执行语句或存储过程，返回只进读取器
		/// </summary>
		/// <param name="cmdType">命令类型</param>
		/// <param name="cmdText">语句或存储过程名称</param>
		/// <param name="parameters">可选参数集合，已经设置好名称、类型、值</param>
		IDataReader ReadData( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

		/// <summary>
		/// 执行SQL语句，返回一个数据值（第一行第一列的值）
		/// </summary>
		/// <param name="commandText">要执行的SQL语句</param>
		Object ExecuteScalar(string commandText);


		/// <summary>
		/// 执行存储过程，返回一个数据值（第一行第一列的值）
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">参数集合，已经设置好名称、类型、值，如果没有参数，传递null</param>
		Object ExecuteScalar(string procedureName, IDbDataParameter[] parameters);

		/// <summary>
		/// 根据命令类型执行语句或存储过程，返回一个数据值（第一行第一列的值）
		/// </summary>
		/// <param name="cmdType">命令类型</param>
		/// <param name="cmdText">语句或存储过程名称</param>
		/// <param name="parameters">可选参数集合，已经设置好名称、类型、值</param>
		/// <returns></returns>
		Object ExecuteScalar( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

		/// <summary>
		/// 执行一条SQL语句，返回受影响的纪录数
		/// </summary>
		/// <param name="commandText">要执行的SQL语句</param>
		int ExecuteNonQuery(string commandText);


		/// <summary>
		/// 执行存储过程，返回受影响的纪录数
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">参数集合</param>
		int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters);


		/// <summary>
		/// 基于传递的conn执行SQL语句
		/// </summary>
		/// <param name="commandText">要执行的SQL语句</param>
		/// <param name="conn">一个打开的连接</param>
		int ExecuteNonQuery(string commandText, IDbConnection conn);

		/// <summary>
		/// 基于传递的conn执行存储过程
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">参数集合</param>
		/// <param name="conn">一个打开的连接</param>
		int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters, IDbConnection conn);

		/// <summary>
		/// 根据命令类型执行语句或存储过程
		/// </summary>
		/// <param name="cmdType">命令类型</param>
		/// <param name="cmdText">语句或存储过程名称</param>
		/// <param name="parameters">可选参数集合，已经设置好名称、类型、值</param>
		/// <returns>受影响的行数</returns>
		int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// 根据命令类型在指定事务中执行语句或存储过程
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">语句或存储过程名称</param>
        /// <param name="parameters">可选参数集合，已经设置好名称、类型、值</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(CommandType cmdType, string cmdText, IDbTransaction tran, params IDbDataParameter[] parameters);

		/// <summary>
		/// 执行一条SQL语句，返回受影响的纪录数
		/// </summary>
		/// <param name="commandText">要执行的SQL语句</param>
		/// <param name="parameters">参数集合</param>
		int ExecuteSql(string commandText, IDbDataParameter[] parameters);

		/// <summary>
		/// 基于传递的conn执行SQL语句
		/// </summary>
		/// <param name="commandText">要执行的SQL语句</param>
		/// <param name="parameters">参数集合</param>
		/// <param name="conn">一个打开的连接</param>
		int ExecuteSql(string commandText, IDbDataParameter[] parameters, IDbConnection conn);

		/// <summary>
		/// 执行SQL语句，返回数据集
		/// </summary>
		/// <param name="commandText">要执行的SQL语句</param>
		DataSet GetDataSet(string commandText);


		/// <summary>
		/// 执行存储过程，返回数据集
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">参数集合</param>
		DataSet GetDataSet(string procedureName, IDbDataParameter[] parameters);

		/// <summary>
		/// 根据命令类型执行语句或存储过程，返回结果集
		/// </summary>
		/// <param name="cmdType">命令类型</param>
		/// <param name="cmdText">语句或存储过程名称</param>
		/// <param name="parameters">可选参数集合，已经设置好名称、类型、值</param>
		/// <returns>结果集</returns>
		DataSet GetDataSet( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

		/// <summary>
		/// 执行存储过程，返回ReturnValue
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">可选参数集合，已经设置好名称、类型、值</param>
		/// <returns>存储过程的返回值(ReturnValue)</returns>
		int ExecuteProcedure( string procedureName, params IDbDataParameter[] parameters);
	}
}
