using System;
using System.Data;
using System.Collections.Generic;
using LFL.Favorite.Model;
/***********************************************
  *  BLL业务逻辑层 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/4 0:31:57
  *  Copyright(C) 2010 灵梦团队 保留所有权利。
***********************************************/
namespace LFL.Favorite.BLL
{
	/// <summary>
	/// 业务逻辑类FavCategoryBll 的摘要说明。
	/// </summary>
	public class FavCategoryBll
	{
		private readonly LFL.Favorite.DAL.FavCategoryDal dal=new LFL.Favorite.DAL.FavCategoryDal();
		public FavCategoryBll()
		{}
		#region  成员方法

		///// <summary>
		///// 得到最大ID
		///// </summary>
		//public int GetMaxId()
		//{
			//return dal.GetMaxId();
		//}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FavCategoryID)
		{
			return dal.Exists(FavCategoryID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LFL.Favorite.Model.FavCategory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.FavCategory model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FavCategoryID)
		{
			
			dal.Delete(FavCategoryID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LFL.Favorite.Model.FavCategory GetModel(int FavCategoryID)
		{
			
			return dal.GetModel(FavCategoryID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LFL.Favorite.Model.FavCategory> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LFL.Favorite.Model.FavCategory> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.FavCategory> modelList = new List<LFL.Favorite.Model.FavCategory>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.FavCategory model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.FavCategory();
					if(dt.Rows[n]["FavCategoryID"].ToString()!="")
					{
						model.FavCategoryID=int.Parse(dt.Rows[n]["FavCategoryID"].ToString());
					}
					model.CategoryName=dt.Rows[n]["CategoryName"].ToString();
					if(dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=int.Parse(dt.Rows[n]["ParentID"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/*
		/// <summary>
		/// 分页数据
		/// </summary>
		/// <param name="pageSize">每页记录大小</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="totalCount">总记录数</param>
		/// <returns></returns>
		public DataSet GetList(int pageSize, int pageIndex, out int totalCount)
		{
			return dal.GetList(pageSize, pageIndex, out totalCount);
		}
		
		
		/// <summary>
		/// 分页数据
		/// </summary>
		/// <param name="pageSize">每页记录大小</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="totalCount">总记录数</param>
		/// <returns></returns>
		public List<LFL.Favorite.Model.FavCategory> GetModelList(int pageSize, int pageIndex, out int totalCount)
		{
			return DataTableToList(dal.GetList(pageSize, pageIndex, out totalCount).Tables[0]);
		}
		*/

		#endregion  成员方法
	}
}

