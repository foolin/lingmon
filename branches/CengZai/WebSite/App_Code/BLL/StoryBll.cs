using System;
using System.Data;
using System.Collections.Generic;
//曾在团队 2011年5月9日
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// StoryBll
	/// </summary>
	public partial class StoryBll
	{
		private readonly CengZai.DAL.StoryDal dal=new CengZai.DAL.StoryDal();
		public StoryBll()
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
		public bool Exists(int StoryID)
		{
			return dal.Exists(StoryID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CengZai.Model.StoryModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CengZai.Model.StoryModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoryID)
		{
			
			return dal.Delete(StoryID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StoryIDlist )
		{
			return dal.DeleteList(StoryIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CengZai.Model.StoryModel GetModel(int StoryID)
		{
			
			return dal.GetModel(StoryID);
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
		public List<CengZai.Model.StoryModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CengZai.Model.StoryModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.StoryModel> modelList = new List<CengZai.Model.StoryModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.StoryModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.StoryModel();
					if(dt.Rows[n]["StoryID"].ToString()!="")
					{
						model.StoryID=int.Parse(dt.Rows[n]["StoryID"].ToString());
					}
					if(dt.Rows[n]["ClassID"].ToString()!="")
					{
						model.ClassID=int.Parse(dt.Rows[n]["ClassID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					model.Author=dt.Rows[n]["Author"].ToString();
					model.Source=dt.Rows[n]["Source"].ToString();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					model.PostIP=dt.Rows[n]["PostIP"].ToString();
					if(dt.Rows[n]["PostTime"].ToString()!="")
					{
						model.PostTime=DateTime.Parse(dt.Rows[n]["PostTime"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Views"].ToString()!="")
					{
						model.Views=int.Parse(dt.Rows[n]["Views"].ToString());
					}
					if(dt.Rows[n]["Comments"].ToString()!="")
					{
						model.Comments=int.Parse(dt.Rows[n]["Comments"].ToString());
					}
					if(dt.Rows[n]["Reports"].ToString()!="")
					{
						model.Reports=int.Parse(dt.Rows[n]["Reports"].ToString());
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

