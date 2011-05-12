using System;
using System.Data;
using System.Collections.Generic;
//80ƴ�Ŷ� 2011��5��9��
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
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int TwiID)
		{
			return dal.Exists(TwiID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(BLPin.Model.TwitterModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(BLPin.Model.TwitterModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int TwiID)
		{
			
			return dal.Delete(TwiID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string TwiIDlist )
		{
			return dal.DeleteList(TwiIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public BLPin.Model.TwitterModel GetModel(int TwiID)
		{
			
			return dal.GetModel(TwiID);
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
		public List<BLPin.Model.TwitterModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

