using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BLPin.Helper;
namespace BLPin.DAL
{
	/// <summary>
	/// 数据访问类:StoryClassDal
	/// </summary>
	public partial class StoryClassDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public StoryClassDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("ClassID", "T_StoryClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ClassID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_StoryClass");
			strSql.Append(" where ClassID=@ClassID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)};
			parameters[0].Value = ClassID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BLPin.Model.StoryClassModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_StoryClass(");
			strSql.Append("ParentID,ClassName,ClassDesc)");
			strSql.Append(" values (");
			strSql.Append("@ParentID,@ClassName,@ClassDesc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,20),
					new SqlParameter("@ClassDesc", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.ClassName;
			parameters[2].Value = model.ClassDesc;

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
		public bool Update(BLPin.Model.StoryClassModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_StoryClass set ");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("ClassDesc=@ClassDesc");
			strSql.Append(" where ClassID=@ClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,20),
					new SqlParameter("@ClassDesc", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassID", SqlDbType.Int,4)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.ClassName;
			parameters[2].Value = model.ClassDesc;
			parameters[3].Value = model.ClassID;

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
		public bool Delete(int ClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_StoryClass ");
			strSql.Append(" where ClassID=@ClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)
};
			parameters[0].Value = ClassID;

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
		public bool DeleteList(string ClassIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_StoryClass ");
			strSql.Append(" where ClassID in ("+ClassIDlist + ")  ");
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
		public BLPin.Model.StoryClassModel GetModel(int ClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ClassID,ParentID,ClassName,ClassDesc from T_StoryClass ");
			strSql.Append(" where ClassID=@ClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)
};
			parameters[0].Value = ClassID;

			BLPin.Model.StoryClassModel model=new BLPin.Model.StoryClassModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ClassID"].ToString()!="")
				{
					model.ClassID=int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
				}
				model.ClassName=ds.Tables[0].Rows[0]["ClassName"].ToString();
				model.ClassDesc=ds.Tables[0].Rows[0]["ClassDesc"].ToString();
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
			strSql.Append("select ClassID,ParentID,ClassName,ClassDesc ");
			strSql.Append(" FROM T_StoryClass ");
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
			strSql.Append(" ClassID,ParentID,ClassName,ClassDesc ");
			strSql.Append(" FROM T_StoryClass ");
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
			parameters[0].Value = "T_StoryClass";
			parameters[1].Value = "ClassID";
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

