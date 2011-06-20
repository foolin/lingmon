using System;
using System.Data;
using System.Collections.Generic;
//曾在团队 2011年5月9日
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// BlogBll
	/// </summary>
	public partial class BlogBll
	{
		private readonly CengZai.DAL.BlogDal dal=new CengZai.DAL.BlogDal();
		public BlogBll()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BlogID)
		{
			return dal.Exists(BlogID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CengZai.Model.BlogModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CengZai.Model.BlogModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BlogID)
		{
			
			return dal.Delete(BlogID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BlogIDlist )
		{
			return dal.DeleteList(BlogIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CengZai.Model.BlogModel GetModel(int BlogID)
		{
			
			return dal.GetModel(BlogID);
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
		public List<CengZai.Model.BlogModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CengZai.Model.BlogModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.BlogModel> modelList = new List<CengZai.Model.BlogModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.BlogModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.BlogModel();
					if(dt.Rows[n]["BlogID"].ToString()!="")
					{
						model.BlogID=int.Parse(dt.Rows[n]["BlogID"].ToString());
					}
					model.Blog=dt.Rows[n]["Blog"].ToString();
					model.BlogName=dt.Rows[n]["BlogName"].ToString();
					model.BlogDesc=dt.Rows[n]["BlogDesc"].ToString();
					if(dt.Rows[n]["Privacy"].ToString()!="")
					{
						model.Privacy=int.Parse(dt.Rows[n]["Privacy"].ToString());
					}
					if(dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

