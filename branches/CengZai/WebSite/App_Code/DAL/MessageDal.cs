using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BLPin.Helper;
namespace BLPin.DAL
{
	/// <summary>
	/// 数据访问类:MessageDal
	/// </summary>
	public partial class MessageDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public MessageDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("MsgID", "T_Message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MsgID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Message");
			strSql.Append(" where MsgID=@MsgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgID", SqlDbType.Int,4)};
			parameters[0].Value = MsgID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BLPin.Model.MessageModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Message(");
			strSql.Append("ToUserID,Title,Content,FromUserID,SendTime,IsRead,ReadTime)");
			strSql.Append(" values (");
			strSql.Append("@ToUserID,@Title,@Content,@FromUserID,@SendTime,@IsRead,@ReadTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ToUserID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NVarChar,300),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ToUserID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.FromUserID;
			parameters[4].Value = model.SendTime;
			parameters[5].Value = model.IsRead;
			parameters[6].Value = model.ReadTime;

			object obj = db.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BLPin.Model.MessageModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Message set ");
			strSql.Append("ToUserID=@ToUserID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("FromUserID=@FromUserID,");
			strSql.Append("SendTime=@SendTime,");
			strSql.Append("IsRead=@IsRead,");
			strSql.Append("ReadTime=@ReadTime");
			strSql.Append(" where MsgID=@MsgID");
			SqlParameter[] parameters = {
					new SqlParameter("@ToUserID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NVarChar,300),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@MsgID", SqlDbType.Int,4)};
			parameters[0].Value = model.ToUserID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.FromUserID;
			parameters[4].Value = model.SendTime;
			parameters[5].Value = model.IsRead;
			parameters[6].Value = model.ReadTime;
			parameters[7].Value = model.MsgID;

			int rows=db.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MsgID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Message ");
			strSql.Append(" where MsgID=@MsgID");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgID", SqlDbType.Int,4)
};
			parameters[0].Value = MsgID;

			int rows=db.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MsgIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Message ");
			strSql.Append(" where MsgID in ("+MsgIDlist + ")  ");
			int rows=db.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BLPin.Model.MessageModel GetModel(int MsgID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MsgID,ToUserID,Title,Content,FromUserID,SendTime,IsRead,ReadTime from T_Message ");
			strSql.Append(" where MsgID=@MsgID");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgID", SqlDbType.Int,4)
};
			parameters[0].Value = MsgID;

			BLPin.Model.MessageModel model=new BLPin.Model.MessageModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MsgID"].ToString()!="")
				{
					model.MsgID=int.Parse(ds.Tables[0].Rows[0]["MsgID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserID"].ToString()!="")
				{
					model.ToUserID=int.Parse(ds.Tables[0].Rows[0]["ToUserID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["FromUserID"].ToString()!="")
				{
					model.FromUserID=int.Parse(ds.Tables[0].Rows[0]["FromUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MsgID,ToUserID,Title,Content,FromUserID,SendTime,IsRead,ReadTime ");
			strSql.Append(" FROM T_Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" MsgID,ToUserID,Title,Content,FromUserID,SendTime,IsRead,ReadTime ");
			strSql.Append(" FROM T_Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Message";
			parameters[1].Value = "MsgID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return db.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

