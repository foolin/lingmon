using System;
using System.Data;
using System.Collections.Generic;
//80拼团队 2011年5月9日
using BLPin.Model;
namespace BLPin.BLL
{
	/// <summary>
	/// TwitterBll
	/// </summary>
	public partial class TwitterBll
	{
		private readonly BLPin.DAL.TwitterDal dal=new BLPin.DAL.TwitterDal();
		public TwitterBll()
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
		public bool Exists(int TwiID)
		{
			return dal.Exists(TwiID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BLPin.Model.TwitterModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BLPin.Model.TwitterModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TwiID)
		{
			
			return dal.Delete(TwiID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TwiIDlist )
		{
			return dal.DeleteList(TwiIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BLPin.Model.TwitterModel GetModel(int TwiID)
		{
			
			return dal.GetModel(TwiID);
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
		public List<BLPin.Model.TwitterModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BLPin.Model.TwitterModel> DataTableToList(DataTable dt)
		{
			List<BLPin.Model.TwitterModel> modelList = new List<BLPin.Model.TwitterModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BLPin.Model.TwitterModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BLPin.Model.TwitterModel();
					if(dt.Rows[n]["TwiID"].ToString()!="")
					{
						model.TwiID=int.Parse(dt.Rows[n]["TwiID"].ToString());
					}
					model.Content=dt.Rows[n]["Content"].ToString();
					model.Image=dt.Rows[n]["Image"].ToString();
					model.Media=dt.Rows[n]["Media"].ToString();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
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

