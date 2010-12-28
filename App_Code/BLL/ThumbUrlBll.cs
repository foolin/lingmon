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
	/// 业务逻辑类ThumbUrlBll 的摘要说明。
	/// </summary>
	public class ThumbUrlBll
	{
		private readonly LFL.Favorite.DAL.ThumbUrlDal dal=new LFL.Favorite.DAL.ThumbUrlDal();
		public ThumbUrlBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LFL.Favorite.Model.ThumbUrl model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.ThumbUrl model)
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
		public LFL.Favorite.Model.ThumbUrl GetModel()
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
		public List<LFL.Favorite.Model.ThumbUrl> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LFL.Favorite.Model.ThumbUrl> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.ThumbUrl> modelList = new List<LFL.Favorite.Model.ThumbUrl>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.ThumbUrl model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.ThumbUrl();
					if(dt.Rows[n]["ThumbID"].ToString()!="")
					{
						model.ThumbID=int.Parse(dt.Rows[n]["ThumbID"].ToString());
					}
					if(dt.Rows[n]["FavID"].ToString()!="")
					{
						model.FavID=int.Parse(dt.Rows[n]["FavID"].ToString());
					}
					model.ThumbImage=dt.Rows[n]["ThumbImage"].ToString();
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
					model.Target=dt.Rows[n]["Target"].ToString();
					if(dt.Rows[n]["Sort"].ToString()!="")
					{
						model.Sort=int.Parse(dt.Rows[n]["Sort"].ToString());
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
		public List<LFL.Favorite.Model.ThumbUrl> GetModelList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
		{
			return DataTableToList(dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount).Tables[0]);
		}
		*/

		#endregion  成员方法
	}
}

