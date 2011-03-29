using System;
using System.Data;
using System.Collections.Generic;
using KuaiLe.Us.Model;
namespace KuaiLe.Us.BLL
{
	/// <summary>
	/// DigBll
	/// </summary>
	public class DigBll
	{
		private readonly KuaiLe.Us.DAL.DigDal dal=new KuaiLe.Us.DAL.DigDal();
		public DigBll()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long DigID)
		{
			return dal.Exists(DigID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(KuaiLe.Us.Model.DigModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.DigModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long DigID)
		{
			
			dal.Delete(DigID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string DigIDlist )
		{
			dal.DeleteList(DigIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.DigModel GetModel(long DigID)
		{
			
			return dal.GetModel(DigID);
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
		public List<KuaiLe.Us.Model.DigModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KuaiLe.Us.Model.DigModel> DataTableToList(DataTable dt)
		{
			List<KuaiLe.Us.Model.DigModel> modelList = new List<KuaiLe.Us.Model.DigModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KuaiLe.Us.Model.DigModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new KuaiLe.Us.Model.DigModel();
					//model.DigID=dt.Rows[n]["DigID"].ToString();
					//model.SrcID=dt.Rows[n]["SrcID"].ToString();
					model.SrcType=dt.Rows[n]["SrcType"].ToString();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					model.UserIP=dt.Rows[n]["UserIP"].ToString();
					if(dt.Rows[n]["DigType"].ToString()!="")
					{
						model.DigType=int.Parse(dt.Rows[n]["DigType"].ToString());
					}
                    if (dt.Rows[n]["DigTime"].ToString() != "")
                    {
                        model.DigTime = DateTime.Parse(dt.Rows[n]["DigTime"].ToString());
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

