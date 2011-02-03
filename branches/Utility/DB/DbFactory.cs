using System;
using System.Data.OracleClient;

namespace Utility.DB
{
	/// <summary>
	/// Name:���ݴ�ȡ������
	/// Description:�������ݿ����ͺ������ַ���������ȡ��ʵ��
	/// </summary>
	public class DbFactory
	{
		/// <summary>
		/// ����һ��ִ����
		/// </summary>
		/// <param name="dbtype">���ݿ�����</param>
		/// <param name="connectString">�����ַ���</param>
		/// <returns>���ݲ���ִ����</returns>
		public static IDbExecutor CreateExecutor(DatabaseType dbtype, string connectString)
		{
			switch(dbtype)
			{
				//�������ݿ�����
				case DatabaseType.SqlServer:
				{
					return new SqlDbExecutor(connectString);;
				}
				case DatabaseType.Oracle:
				{
					return new OracleDbExecutor(connectString);
				}
				case DatabaseType.Access:
				{
					return new OleDbExecutor( connectString);
				}
				case DatabaseType.OleDb:
				{
					return new OleDbExecutor( connectString);
				}
				default://Ĭ��SQL Server
				{
					return new SqlDbExecutor(connectString);
				}
			}
		}
	}

	/// <summary>
	/// DataBase Type
	/// </summary>
	public enum DatabaseType : int
	{
		SqlServer	= 1, 
		Oracle		= 2,
		Access		= 3,
		OleDb		= 4
	}
}
