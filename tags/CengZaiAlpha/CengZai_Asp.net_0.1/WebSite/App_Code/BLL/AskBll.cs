using System;
using System.Data;
using System.Collections.Generic;
//曾在团队 2011年5月9日
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// AskBll
	/// </summary>
	public partial class AskBll
	{
		private readonly CengZai.DAL.AskDal dal=new CengZai.DAL.AskDal();
		public AskBll()
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
		public bool Exists(int AskID)
		{
			return dal.Exists(AskID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CengZai.Model.AskModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CengZai.Model.AskModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AskID)
		{
			
			return dal.Delete(AskID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string AskIDlist )
		{
			return dal.DeleteList(AskIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CengZai.Model.AskModel GetModel(int AskID)
		{
			
			return dal.GetModel(AskID);
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
		public List<CengZai.Model.AskModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CengZai.Model.AskModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.AskModel> modelList = new List<CengZai.Model.AskModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.AskModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.AskModel();
					if(dt.Rows[n]["AskID"].ToString()!="")
					{
						model.AskID=int.Parse(dt.Rows[n]["AskID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					if(dt.Rows[n]["RewardCredit"].ToString()!="")
					{
						model.RewardCredit=decimal.Parse(dt.Rows[n]["RewardCredit"].ToString());
					}
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["PostTime"].ToString()!="")
					{
						model.PostTime=DateTime.Parse(dt.Rows[n]["PostTime"].ToString());
					}
					if(dt.Rows[n]["IsAnonym"].ToString()!="")
					{
						model.IsAnonym=int.Parse(dt.Rows[n]["IsAnonym"].ToString());
					}
					if(dt.Rows[n]["ReplyID"].ToString()!="")
					{
						model.ReplyID=int.Parse(dt.Rows[n]["ReplyID"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Views"].ToString()!="")
					{
						model.Views=int.Parse(dt.Rows[n]["Views"].ToString());
					}
					if(dt.Rows[n]["Replys"].ToString()!="")
					{
						model.Replys=int.Parse(dt.Rows[n]["Replys"].ToString());
					}
					if(dt.Rows[n]["Reports"].ToString()!="")
					{
						model.Reports=int.Parse(dt.Rows[n]["Reports"].ToString());
					}
					if(dt.Rows[n]["IsLock"].ToString()!="")
					{
						model.IsLock=int.Parse(dt.Rows[n]["IsLock"].ToString());
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

