using System;
using System.Data;
using System.Collections.Generic;
using LFL.Favorite.Model;
/***********************************************
  *  BLL业务逻辑层 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/17 23:30:46
  *  Copyright(C) 2010 灵梦团队 保留所有权利。
***********************************************/
namespace LFL.Favorite.BLL
{
	/// <summary>
	/// 业务逻辑类FavoriteBll 的摘要说明。
	/// </summary>
	public class FavoriteBll
	{
		private readonly LFL.Favorite.DAL.FavoriteDal dal=new LFL.Favorite.DAL.FavoriteDal();
		public FavoriteBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LFL.Favorite.Model.Favorite model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.Favorite model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LFL.Favorite.Model.Favorite GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
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
		public List<LFL.Favorite.Model.Favorite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LFL.Favorite.Model.Favorite> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.Favorite> modelList = new List<LFL.Favorite.Model.Favorite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.Favorite model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.Favorite();
					if(dt.Rows[n]["FavID"].ToString()!="")
					{
						model.FavID=int.Parse(dt.Rows[n]["FavID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.URL=dt.Rows[n]["URL"].ToString();
					if(dt.Rows[n]["FavCategoryID"].ToString()!="")
					{
						model.FavCategoryID=int.Parse(dt.Rows[n]["FavCategoryID"].ToString());
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
		public DataSet GetList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
		{
			return dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount);
		}
		
		
		/// <summary>
		/// 分页数据
		/// </summary>
		/// <param name="pageSize">每页记录大小</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="totalCount">总记录数</param>
		/// <returns></returns>
		public List<LFL.Favorite.Model.Favorite> GetModelList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
		{
			return DataTableToList(dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount).Tables[0]);
		}
		*/

		#endregion  成员方法
	}
}

