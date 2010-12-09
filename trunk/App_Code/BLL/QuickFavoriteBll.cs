using System;
using System.Data;
using System.Collections.Generic;
using LFL.Favorite.Model;
/***********************************************
  *  BLL业务逻辑层 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/4 0:31:58
  *  Copyright(C) 2010 灵梦团队 保留所有权利。
***********************************************/
namespace LFL.Favorite.BLL
{
	/// <summary>
	/// 业务逻辑类QuickFavoriteBll 的摘要说明。
	/// </summary>
	public class QuickFavoriteBll
	{
		private readonly LFL.Favorite.DAL.QuickFavoriteDal dal=new LFL.Favorite.DAL.QuickFavoriteDal();
		public QuickFavoriteBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LFL.Favorite.Model.QuickFavorite model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.QuickFavorite model)
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
		public LFL.Favorite.Model.QuickFavorite GetModel()
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
		public List<LFL.Favorite.Model.QuickFavorite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LFL.Favorite.Model.QuickFavorite> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.QuickFavorite> modelList = new List<LFL.Favorite.Model.QuickFavorite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.QuickFavorite model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.QuickFavorite();
					if(dt.Rows[n]["QuickFavID"].ToString()!="")
					{
						model.QuickFavID=int.Parse(dt.Rows[n]["QuickFavID"].ToString());
					}
					if(dt.Rows[n]["FavID"].ToString()!="")
					{
						model.FavID=int.Parse(dt.Rows[n]["FavID"].ToString());
					}
					model.MinImage=dt.Rows[n]["MinImage"].ToString();
					if(dt.Rows[n]["OffsetLeft"].ToString()!="")
					{
						model.OffsetLeft=decimal.Parse(dt.Rows[n]["OffsetLeft"].ToString());
					}
					if(dt.Rows[n]["OffsetTop"].ToString()!="")
					{
						model.OffsetTop=decimal.Parse(dt.Rows[n]["OffsetTop"].ToString());
					}
					if(dt.Rows[n]["Width"].ToString()!="")
					{
						model.Width=decimal.Parse(dt.Rows[n]["Width"].ToString());
					}
					if(dt.Rows[n]["Height"].ToString()!="")
					{
						model.Height=decimal.Parse(dt.Rows[n]["Height"].ToString());
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
		public List<LFL.Favorite.Model.QuickFavorite> GetModelList(int pageSize, int pageIndex, out int totalCount)
		{
			return DataTableToList(dal.GetList(pageSize, pageIndex, out totalCount).Tables[0]);
		}
		*/

		#endregion  成员方法
	}
}

