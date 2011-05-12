using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BLPin.Helper;
namespace BLPin.DAL
{
	/// <summary>
	/// 数据访问类:WikiVerDal
	/// </summary>
	public partial class WikiVerDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public WikiVerDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("VerID", "T_WikiVer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_WikiVer");
			strSql.Append(" where VerID=@VerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@VerID", SqlDbType.Int,4)};
			parameters[0].Value = VerID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BLPin.Model.WikiVerModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_WikiVer(");
			strSql.Append("Content,Supply,Reason,UserID,PostIP,PostTime,Status,StatusMsg)");
			strSql.Append(" values (");
			strSql.Append("@Content,@Supply,@Reason,@UserID,@PostIP,@PostTime,@Status,@StatusMsg)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Supply", SqlDbType.NVarChar,500),
					new SqlParameter("@Reason", SqlDbType.NVarChar,300),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@StatusMsg", SqlDbType.NVarChar,300)};
			parameters[0].Value = model.Content;
			parameters[1].Value = model.Supply;
			parameters[2].Value = model.Reason;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.StatusMsg;

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
		public bool Update(BLPin.Model.WikiVerModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_WikiVer set ");
			strSql.Append("Content=@Content,");
			strSql.Append("Supply=@Supply,");
			strSql.Append("Reason=@Reason,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PostIP=@PostIP,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("Status=@Status,");
			strSql.Append("StatusMsg=@StatusMsg");
			strSql.Append(" where VerID=@VerID");
			SqlParameter[] parameters = {
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Supply", SqlDbType.NVarChar,500),
					new SqlParameter("@Reason", SqlDbType.NVarChar,300),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@StatusMsg", SqlDbType.NVarChar,300),
					new SqlParameter("@VerID", SqlDbType.Int,4)};
			parameters[0].Value = model.Content;
			parameters[1].Value = model.Supply;
			parameters[2].Value = model.Reason;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.StatusMsg;
			parameters[8].Value = model.VerID;

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
		public bool Delete(int VerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_WikiVer ");
			strSql.Append(" where VerID=@VerID");
			SqlParameter[] parameters = {
					new SqlParameter("@VerID", SqlDbType.Int,4)
};
			parameters[0].Value = VerID;

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
		public bool DeleteList(string VerIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_WikiVer ");
			strSql.Append(" where VerID in ("+VerIDlist + ")  ");
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
		public BLPin.Model.WikiVerModel GetModel(int VerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VerID,Content,Supply,Reason,UserID,PostIP,PostTime,Status,StatusMsg from T_WikiVer ");
			strSql.Append(" where VerID=@VerID");
			SqlParameter[] parameters = {
					new SqlParameter("@VerID", SqlDbType.Int,4)
};
			parameters[0].Value = VerID;

			BLPin.Model.WikiVerModel model=new BLPin.Model.WikiVerModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["VerID"].ToString()!="")
				{
					model.VerID=int.Parse(ds.Tables[0].Rows[0]["VerID"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Supply=ds.Tables[0].Rows[0]["Supply"].ToString();
				model.Reason=ds.Tables[0].Rows[0]["Reason"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.PostIP=ds.Tables[0].Rows[0]["PostIP"].ToString();
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.StatusMsg=ds.Tables[0].Rows[0]["StatusMsg"].ToString();
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
			strSql.Append("select VerID,Content,Supply,Reason,UserID,PostIP,PostTime,Status,StatusMsg ");
			strSql.Append(" FROM T_WikiVer ");
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
			strSql.Append(" VerID,Content,Supply,Reason,UserID,PostIP,PostTime,Status,StatusMsg ");
			strSql.Append(" FROM T_WikiVer ");
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
			parameters[0].Value = "T_WikiVer";
			parameters[1].Value = "VerID";
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

