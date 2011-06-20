using System;
using System.Data;
using System.Collections.Generic;
//曾在团队 2011年5月9日
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// MessageBll
	/// </summary>
	public partial class MessageBll
	{
		private readonly CengZai.DAL.MessageDal dal=new CengZai.DAL.MessageDal();
		public MessageBll()
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
		public bool Exists(int MsgID)
		{
			return dal.Exists(MsgID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CengZai.Model.MessageModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CengZai.Model.MessageModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MsgID)
		{
			
			return dal.Delete(MsgID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MsgIDlist )
		{
			return dal.DeleteList(MsgIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CengZai.Model.MessageModel GetModel(int MsgID)
		{
			
			return dal.GetModel(MsgID);
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
		public List<CengZai.Model.MessageModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CengZai.Model.MessageModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.MessageModel> modelList = new List<CengZai.Model.MessageModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.MessageModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.MessageModel();
					if(dt.Rows[n]["MsgID"].ToString()!="")
					{
						model.MsgID=int.Parse(dt.Rows[n]["MsgID"].ToString());
					}
					if(dt.Rows[n]["ToUserID"].ToString()!="")
					{
						model.ToUserID=int.Parse(dt.Rows[n]["ToUserID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					if(dt.Rows[n]["FromUserID"].ToString()!="")
					{
						model.FromUserID=int.Parse(dt.Rows[n]["FromUserID"].ToString());
					}
					if(dt.Rows[n]["SendTime"].ToString()!="")
					{
						model.SendTime=DateTime.Parse(dt.Rows[n]["SendTime"].ToString());
					}
					if(dt.Rows[n]["IsRead"].ToString()!="")
					{
						model.IsRead=int.Parse(dt.Rows[n]["IsRead"].ToString());
					}
					if(dt.Rows[n]["ReadTime"].ToString()!="")
					{
						model.ReadTime=DateTime.Parse(dt.Rows[n]["ReadTime"].ToString());
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

