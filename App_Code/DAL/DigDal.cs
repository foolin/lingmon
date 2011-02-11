using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace KuaiLe.Us.DAL
{
	/// <summary>
	/// 数据访问类:DigDal
	/// </summary>
	public class DigDal
	{
        KuaiLe.Us.Common.DbBase db = new KuaiLe.Us.Common.DbBase();

		public DigDal()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long DigID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Dig");
			strSql.Append(" where DigID=@DigID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DigID", SqlDbType.BigInt)};
			parameters[0].Value = DigID;

			return db.RunSqlReturnInt(strSql.ToString(),parameters) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KuaiLe.Us.Model.DigModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Dig(");
			strSql.Append("SrcID,SrcType,UserID,UserIP,DigType)");
			strSql.Append(" values (");
			strSql.Append("@SrcID,@SrcType,@UserID,@UserIP,@DigType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SrcID", SqlDbType.BigInt,8),
					new SqlParameter("@SrcType", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserIP", SqlDbType.NVarChar,50),
					new SqlParameter("@DigType", SqlDbType.Int,4)};
			parameters[0].Value = model.SrcID;
			parameters[1].Value = model.SrcType;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserIP;
			parameters[4].Value = model.DigType;

			return db.RunSqlReturnInt(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.DigModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Dig set ");
			strSql.Append("SrcID=@SrcID,");
			strSql.Append("SrcType=@SrcType,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserIP=@UserIP,");
			strSql.Append("DigType=@DigType");
			strSql.Append(" where DigID=@DigID");
			SqlParameter[] parameters = {
					new SqlParameter("@DigID", SqlDbType.BigInt,8),
					new SqlParameter("@SrcID", SqlDbType.BigInt,8),
					new SqlParameter("@SrcType", SqlDbType.NVarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserIP", SqlDbType.NVarChar,50),
					new SqlParameter("@DigType", SqlDbType.Int,4)};
			parameters[0].Value = model.DigID;
			parameters[1].Value = model.SrcID;
			parameters[2].Value = model.SrcType;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserIP;
			parameters[5].Value = model.DigType;

			db.RunSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long DigID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Dig ");
			strSql.Append(" where DigID=@DigID");
			SqlParameter[] parameters = {
					new SqlParameter("@DigID", SqlDbType.BigInt)
};
			parameters[0].Value = DigID;

			db.RunSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string DigIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Dig ");
			strSql.Append(" where DigID in ("+DigIDlist + ")  ");
			db.RunTran(strSql.ToString());

		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.DigModel GetModel(long DigID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DigID,SrcID,SrcType,UserID,UserIP,DigType from T_Dig ");
			strSql.Append(" where DigID=@DigID");
			SqlParameter[] parameters = {
					new SqlParameter("@DigID", SqlDbType.BigInt)
};
			parameters[0].Value = DigID;

			KuaiLe.Us.Model.DigModel model=new KuaiLe.Us.Model.DigModel();
			DataSet ds=db.GetDs(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DigID"].ToString()!="")
				{
					model.DigID=long.Parse(ds.Tables[0].Rows[0]["DigID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SrcID"].ToString()!="")
				{
					model.SrcID=long.Parse(ds.Tables[0].Rows[0]["SrcID"].ToString());
				}
				model.SrcType=ds.Tables[0].Rows[0]["SrcType"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.UserIP=ds.Tables[0].Rows[0]["UserIP"].ToString();
				if(ds.Tables[0].Rows[0]["DigType"].ToString()!="")
				{
					model.DigType=int.Parse(ds.Tables[0].Rows[0]["DigType"].ToString());
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
			strSql.Append("select DigID,SrcID,SrcType,UserID,UserIP,DigType ");
			strSql.Append(" FROM T_Dig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetDs(strSql.ToString());
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
			strSql.Append(" DigID,SrcID,SrcType,UserID,UserIP,DigType ");
			strSql.Append(" FROM T_Dig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
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
			parameters[0].Value = "T_Dig";
			parameters[1].Value = "";
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

