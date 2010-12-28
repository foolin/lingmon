using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/***********************************************
  *  DAL数据层 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/17 23:34:46
  *  Copyright(C) 2010 灵梦团队 保留所有权利。。
***********************************************/
namespace LFL.Favorite.DAL
{
	/// <summary>
	/// 数据访问类ThumbUrlDal。
	/// </summary>
	public class ThumbUrlDal
	{

		DbBase db = new DbBase();

		public ThumbUrlDal()
		{}

		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LFL.Favorite.Model.ThumbUrl model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ThumbID != null)
			{
				strSql1.Append("ThumbID,");
				strSql2.Append(""+model.ThumbID+",");
			}
			if (model.FavID != null)
			{
				strSql1.Append("FavID,");
				strSql2.Append(""+model.FavID+",");
			}
			if (model.ThumbImage != null)
			{
				strSql1.Append("ThumbImage,");
				strSql2.Append("'"+model.ThumbImage+"',");
			}
			if (model.OffsetLeft != null)
			{
				strSql1.Append("OffsetLeft,");
				strSql2.Append(""+model.OffsetLeft+",");
			}
			if (model.OffsetTop != null)
			{
				strSql1.Append("OffsetTop,");
				strSql2.Append(""+model.OffsetTop+",");
			}
			if (model.Width != null)
			{
				strSql1.Append("Width,");
				strSql2.Append(""+model.Width+",");
			}
			if (model.Height != null)
			{
				strSql1.Append("Height,");
				strSql2.Append(""+model.Height+",");
			}
			if (model.Target != null)
			{
				strSql1.Append("Target,");
				strSql2.Append("'"+model.Target+"',");
			}
			if (model.Sort != null)
			{
				strSql1.Append("Sort,");
				strSql2.Append(""+model.Sort+",");
			}
			strSql.Append("insert into T_ThumbUrl(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.ThumbUrl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_ThumbUrl set ");
			if (model.ThumbID != null)
			{
				strSql.Append("ThumbID="+model.ThumbID+",");
			}
			if (model.FavID != null)
			{
				strSql.Append("FavID="+model.FavID+",");
			}
			if (model.ThumbImage != null)
			{
				strSql.Append("ThumbImage='"+model.ThumbImage+"',");
			}
			if (model.OffsetLeft != null)
			{
				strSql.Append("OffsetLeft="+model.OffsetLeft+",");
			}
			if (model.OffsetTop != null)
			{
				strSql.Append("OffsetTop="+model.OffsetTop+",");
			}
			if (model.Width != null)
			{
				strSql.Append("Width="+model.Width+",");
			}
			if (model.Height != null)
			{
				strSql.Append("Height="+model.Height+",");
			}
			if (model.Target != null)
			{
				strSql.Append("Target='"+model.Target+"',");
			}
			if (model.Sort != null)
			{
				strSql.Append("Sort="+model.Sort+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ");
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ThumbUrl ");
			strSql.Append(" where " );
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LFL.Favorite.Model.ThumbUrl GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ThumbID,FavID,ThumbImage,OffsetLeft,OffsetTop,Width,Height,Target,Sort ");
			strSql.Append(" from T_ThumbUrl ");
			strSql.Append(" where " );
			LFL.Favorite.Model.ThumbUrl model=new LFL.Favorite.Model.ThumbUrl();
			DataSet ds = db.GetDs(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ThumbID"].ToString()!="")
				{
					model.ThumbID=int.Parse(ds.Tables[0].Rows[0]["ThumbID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FavID"].ToString()!="")
				{
					model.FavID=int.Parse(ds.Tables[0].Rows[0]["FavID"].ToString());
				}
				model.ThumbImage=ds.Tables[0].Rows[0]["ThumbImage"].ToString();
				if(ds.Tables[0].Rows[0]["OffsetLeft"].ToString()!="")
				{
					model.OffsetLeft=decimal.Parse(ds.Tables[0].Rows[0]["OffsetLeft"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OffsetTop"].ToString()!="")
				{
					model.OffsetTop=decimal.Parse(ds.Tables[0].Rows[0]["OffsetTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Width"].ToString()!="")
				{
					model.Width=decimal.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Height"].ToString()!="")
				{
					model.Height=decimal.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
				}
				model.Target=ds.Tables[0].Rows[0]["Target"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
			strSql.Append("select ThumbID,FavID,ThumbImage,OffsetLeft,OffsetTop,Width,Height,Target,Sort ");
			strSql.Append(" FROM T_ThumbUrl ");
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
			strSql.Append(" ThumbID,FavID,ThumbImage,OffsetLeft,OffsetTop,Width,Height,Target,Sort ");
			strSql.Append(" FROM T_ThumbUrl ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(string strWhere, string strOrder,int pageSize, int pageIndex, out int totalCount)
		{
			StringBuilder strSql = new StringBuilder();
			//Sql语句
			strSql.Append(" Select ");
			strSql.Append(" ThumbID,FavID,ThumbImage,OffsetLeft,OffsetTop,Width,Height,Target,Sort ");
			strSql.Append(" FROM T_ThumbUrl ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetPageDs(strSql.ToString(), strOrder, pageSize, pageIndex, out totalCount);
		}
		

		#endregion  成员方法
	}
}

