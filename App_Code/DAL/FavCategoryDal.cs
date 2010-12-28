using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/***********************************************
  *  DAL���ݲ� 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/17 23:34:46
  *  Copyright(C) 2010 �����Ŷ� ��������Ȩ������
***********************************************/
namespace LFL.Favorite.DAL
{
	/// <summary>
	/// ���ݷ�����FavCategoryDal��
	/// </summary>
	public class FavCategoryDal
	{

		DbBase db = new DbBase();

		public FavCategoryDal()
		{}

		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		//public int GetMaxId()
		//{
		//return DbBase.GetMaxID("FavCategoryID", "T_FavCategory"); 
		//}


		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int FavCategoryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_FavCategory");
			strSql.Append(" where FavCategoryID="+FavCategoryID+" ");
			return (db.RunSqlReturnInt(strSql.ToString()) > 0);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LFL.Favorite.Model.FavCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.CategoryName != null)
			{
				strSql1.Append("CategoryName,");
				strSql2.Append("'"+model.CategoryName+"',");
			}
			if (model.ParentID != null)
			{
				strSql1.Append("ParentID,");
				strSql2.Append(""+model.ParentID+",");
			}
			strSql.Append("insert into T_FavCategory(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";SELECT SCOPE_IDENTITY() AS [ID]");
			return db.RunSqlReturnInt(strSql.ToString());
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LFL.Favorite.Model.FavCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_FavCategory set ");
			if (model.CategoryName != null)
			{
				strSql.Append("CategoryName='"+model.CategoryName+"',");
			}
			if (model.ParentID != null)
			{
				strSql.Append("ParentID="+model.ParentID+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where FavCategoryID="+ model.FavCategoryID+" ");
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int FavCategoryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FavCategory ");
			strSql.Append(" where FavCategoryID="+FavCategoryID+" " );
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LFL.Favorite.Model.FavCategory GetModel(int FavCategoryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" from T_FavCategory ");
			strSql.Append(" where FavCategoryID="+FavCategoryID+" " );
			LFL.Favorite.Model.FavCategory model=new LFL.Favorite.Model.FavCategory();
			DataSet ds = db.GetDs(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FavCategoryID"].ToString()!="")
				{
					model.FavCategoryID=int.Parse(ds.Tables[0].Rows[0]["FavCategoryID"].ToString());
				}
				model.CategoryName=ds.Tables[0].Rows[0]["CategoryName"].ToString();
				if(ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" FROM T_FavCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetDs(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" FROM T_FavCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(string strWhere, string strOrder,int pageSize, int pageIndex, out int totalCount)
		{
			StringBuilder strSql = new StringBuilder();
			//Sql���
			strSql.Append(" Select ");
			strSql.Append(" FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" FROM T_FavCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetPageDs(strSql.ToString(), strOrder, pageSize, pageIndex, out totalCount);
		}
		*/

		#endregion  ��Ա����
	}
}

