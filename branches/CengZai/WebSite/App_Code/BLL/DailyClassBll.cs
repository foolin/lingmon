using System;
using System.Data;
using System.Collections.Generic;
//80拼团队 2011年5月9日
using BLPin.Model;
namespace BLPin.BLL
{
	/// <summary>
	/// DailyClassBll
	/// </summary>
	public partial class DailyClassBll
	{
		private readonly BLPin.DAL.DailyClassDal dal=new BLPin.DAL.DailyClassDal();
		public DailyClassBll()
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
		public bool Exists(int ClassID)
		{
			return dal.Exists(ClassID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BLPin.Model.DailyClassModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BLPin.Model.DailyClassModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ClassID)
		{
			
			return dal.Delete(ClassID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ClassIDlist )
		{
			return dal.DeleteList(ClassIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BLPin.Model.DailyClassModel GetModel(int ClassID)
		{
			
			return dal.GetModel(ClassID);
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
		public List<BLPin.Model.DailyClassModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BLPin.Model.DailyClassModel> DataTableToList(DataTable dt)
		{
			List<BLPin.Model.DailyClassModel> modelList = new List<BLPin.Model.DailyClassModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BLPin.Model.DailyClassModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BLPin.Model.DailyClassModel();
					if(dt.Rows[n]["ClassID"].ToString()!="")
					{
						model.ClassID=int.Parse(dt.Rows[n]["ClassID"].ToString());
					}
					if(dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=int.Parse(dt.Rows[n]["ParentID"].ToString());
					}
					model.ClassName=dt.Rows[n]["ClassName"].ToString();
					model.ClassDesc=dt.Rows[n]["ClassDesc"].ToString();
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

