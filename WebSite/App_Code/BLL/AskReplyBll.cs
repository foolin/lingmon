using System;
using System.Data;
using System.Collections.Generic;
//�����Ŷ� 2011��5��9��
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// AskReplyBll
	/// </summary>
	public partial class AskReplyBll
	{
		private readonly CengZai.DAL.AskReplyDal dal=new CengZai.DAL.AskReplyDal();
		public AskReplyBll()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ReplyID)
		{
			return dal.Exists(ReplyID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(CengZai.Model.AskReplyModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(CengZai.Model.AskReplyModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ReplyID)
		{
			
			return dal.Delete(ReplyID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string ReplyIDlist )
		{
			return dal.DeleteList(ReplyIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CengZai.Model.AskReplyModel GetModel(int ReplyID)
		{
			
			return dal.GetModel(ReplyID);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CengZai.Model.AskReplyModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CengZai.Model.AskReplyModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.AskReplyModel> modelList = new List<CengZai.Model.AskReplyModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.AskReplyModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.AskReplyModel();
					if(dt.Rows[n]["ReplyID"].ToString()!="")
					{
						model.ReplyID=int.Parse(dt.Rows[n]["ReplyID"].ToString());
					}
					if(dt.Rows[n]["AskID"].ToString()!="")
					{
						model.AskID=int.Parse(dt.Rows[n]["AskID"].ToString());
					}
					model.Content=dt.Rows[n]["Content"].ToString();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["PostTime"].ToString()!="")
					{
						model.PostTime=DateTime.Parse(dt.Rows[n]["PostTime"].ToString());
					}
					model.PostIP=dt.Rows[n]["PostIP"].ToString();
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

