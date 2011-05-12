using System;
using System.Data;
using System.Collections.Generic;
//80拼团队 2011年5月9日
using BLPin.Model;
namespace BLPin.BLL
{
	/// <summary>
	/// LetterBll
	/// </summary>
	public partial class LetterBll
	{
		private readonly BLPin.DAL.LetterDal dal=new BLPin.DAL.LetterDal();
		public LetterBll()
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
		public bool Exists(int LoveID)
		{
			return dal.Exists(LoveID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BLPin.Model.LetterModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BLPin.Model.LetterModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LoveID)
		{
			
			return dal.Delete(LoveID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LoveIDlist )
		{
			return dal.DeleteList(LoveIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BLPin.Model.LetterModel GetModel(int LoveID)
		{
			
			return dal.GetModel(LoveID);
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
		public List<BLPin.Model.LetterModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BLPin.Model.LetterModel> DataTableToList(DataTable dt)
		{
			List<BLPin.Model.LetterModel> modelList = new List<BLPin.Model.LetterModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BLPin.Model.LetterModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BLPin.Model.LetterModel();
					if(dt.Rows[n]["LoveID"].ToString()!="")
					{
						model.LoveID=int.Parse(dt.Rows[n]["LoveID"].ToString());
					}
					if(dt.Rows[n]["ToUserID"].ToString()!="")
					{
						model.ToUserID=int.Parse(dt.Rows[n]["ToUserID"].ToString());
					}
					if(dt.Rows[n]["FromUserID"].ToString()!="")
					{
						model.FromUserID=int.Parse(dt.Rows[n]["FromUserID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					model.PostIP=dt.Rows[n]["PostIP"].ToString();
					if(dt.Rows[n]["PostTime"].ToString()!="")
					{
						model.PostTime=DateTime.Parse(dt.Rows[n]["PostTime"].ToString());
					}
					if(dt.Rows[n]["IsRead"].ToString()!="")
					{
						model.IsRead=int.Parse(dt.Rows[n]["IsRead"].ToString());
					}
					if(dt.Rows[n]["ReadTime"].ToString()!="")
					{
						model.ReadTime=DateTime.Parse(dt.Rows[n]["ReadTime"].ToString());
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

