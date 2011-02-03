using System;
using System.Data;

namespace Studio.Data
{
	/// <summary>
	/// Name:���ݴ�ȡ��(ִ����)�ӿ�
	/// Description:�������ݴ�ȡ�������ӿڷ���,�߼�����ô˽ӿڽ������ݲ���,�����ǵ��þ���Ľӿ�ʵ����
	/// </summary>
	public interface IDbExecutor : IDisposable
	{
		/// <summary>
		/// ִ��SQL��䣬����ֻ����ȡ��
		/// </summary>
		/// <param name="commandText">Ҫִ�е�SQL���</param>
		/// 
		IDataReader ReadData(string commandText);


		/// <summary>
		/// ִ�д洢���̣�����ֻ����ȡ��
		/// </summary>
		/// <param name="procedureName">�洢��������</param>
		/// <param name="parameters">�������ϣ��Ѿ����ú����ơ����͡�ֵ�����û�в���������null</param>
		IDataReader ReadData(string procedureName, IDbDataParameter[] parameters);
		
		/// <summary>
		/// ������������ִ������洢���̣�����ֻ����ȡ��
		/// </summary>
		/// <param name="cmdType">��������</param>
		/// <param name="cmdText">����洢��������</param>
		/// <param name="parameters">��ѡ�������ϣ��Ѿ����ú����ơ����͡�ֵ</param>
		IDataReader ReadData( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

		/// <summary>
		/// ִ��SQL��䣬����һ������ֵ����һ�е�һ�е�ֵ��
		/// </summary>
		/// <param name="commandText">Ҫִ�е�SQL���</param>
		Object ExecuteScalar(string commandText);


		/// <summary>
		/// ִ�д洢���̣�����һ������ֵ����һ�е�һ�е�ֵ��
		/// </summary>
		/// <param name="procedureName">�洢��������</param>
		/// <param name="parameters">�������ϣ��Ѿ����ú����ơ����͡�ֵ�����û�в���������null</param>
		Object ExecuteScalar(string procedureName, IDbDataParameter[] parameters);

		/// <summary>
		/// ������������ִ������洢���̣�����һ������ֵ����һ�е�һ�е�ֵ��
		/// </summary>
		/// <param name="cmdType">��������</param>
		/// <param name="cmdText">����洢��������</param>
		/// <param name="parameters">��ѡ�������ϣ��Ѿ����ú����ơ����͡�ֵ</param>
		/// <returns></returns>
		Object ExecuteScalar( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

		/// <summary>
		/// ִ��һ��SQL��䣬������Ӱ��ļ�¼��
		/// </summary>
		/// <param name="commandText">Ҫִ�е�SQL���</param>
		int ExecuteNonQuery(string commandText);


		/// <summary>
		/// ִ�д洢���̣�������Ӱ��ļ�¼��
		/// </summary>
		/// <param name="procedureName">�洢��������</param>
		/// <param name="parameters">��������</param>
		int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters);


		/// <summary>
		/// ���ڴ��ݵ�connִ��SQL���
		/// </summary>
		/// <param name="commandText">Ҫִ�е�SQL���</param>
		/// <param name="conn">һ���򿪵�����</param>
		int ExecuteNonQuery(string commandText, IDbConnection conn);

		/// <summary>
		/// ���ڴ��ݵ�connִ�д洢����
		/// </summary>
		/// <param name="procedureName">�洢��������</param>
		/// <param name="parameters">��������</param>
		/// <param name="conn">һ���򿪵�����</param>
		int ExecuteNonQuery(string procedureName, IDbDataParameter[] parameters, IDbConnection conn);

		/// <summary>
		/// ������������ִ������洢����
		/// </summary>
		/// <param name="cmdType">��������</param>
		/// <param name="cmdText">����洢��������</param>
		/// <param name="parameters">��ѡ�������ϣ��Ѿ����ú����ơ����͡�ֵ</param>
		/// <returns>��Ӱ�������</returns>
		int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// ��������������ָ��������ִ������洢����
        /// </summary>
        /// <param name="cmdType">��������</param>
        /// <param name="cmdText">����洢��������</param>
        /// <param name="parameters">��ѡ�������ϣ��Ѿ����ú����ơ����͡�ֵ</param>
        /// <returns>��Ӱ�������</returns>
        int ExecuteNonQuery(CommandType cmdType, string cmdText, IDbTransaction tran, params IDbDataParameter[] parameters);

		/// <summary>
		/// ִ��һ��SQL��䣬������Ӱ��ļ�¼��
		/// </summary>
		/// <param name="commandText">Ҫִ�е�SQL���</param>
		/// <param name="parameters">��������</param>
		int ExecuteSql(string commandText, IDbDataParameter[] parameters);

		/// <summary>
		/// ���ڴ��ݵ�connִ��SQL���
		/// </summary>
		/// <param name="commandText">Ҫִ�е�SQL���</param>
		/// <param name="parameters">��������</param>
		/// <param name="conn">һ���򿪵�����</param>
		int ExecuteSql(string commandText, IDbDataParameter[] parameters, IDbConnection conn);

		/// <summary>
		/// ִ��SQL��䣬�������ݼ�
		/// </summary>
		/// <param name="commandText">Ҫִ�е�SQL���</param>
		DataSet GetDataSet(string commandText);


		/// <summary>
		/// ִ�д洢���̣��������ݼ�
		/// </summary>
		/// <param name="procedureName">�洢��������</param>
		/// <param name="parameters">��������</param>
		DataSet GetDataSet(string procedureName, IDbDataParameter[] parameters);

		/// <summary>
		/// ������������ִ������洢���̣����ؽ����
		/// </summary>
		/// <param name="cmdType">��������</param>
		/// <param name="cmdText">����洢��������</param>
		/// <param name="parameters">��ѡ�������ϣ��Ѿ����ú����ơ����͡�ֵ</param>
		/// <returns>�����</returns>
		DataSet GetDataSet( CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

		/// <summary>
		/// ִ�д洢���̣�����ReturnValue
		/// </summary>
		/// <param name="procedureName">�洢��������</param>
		/// <param name="parameters">��ѡ�������ϣ��Ѿ����ú����ơ����͡�ֵ</param>
		/// <returns>�洢���̵ķ���ֵ(ReturnValue)</returns>
		int ExecuteProcedure( string procedureName, params IDbDataParameter[] parameters);
	}
}
