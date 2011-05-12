using System;
using System.Data;
using System.Collections.Generic;
//�����Ŷ� 2011��5��9��
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
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int MsgID)
		{
			return dal.Exists(MsgID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(CengZai.Model.MessageModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(CengZai.Model.MessageModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int MsgID)
		{
			
			return dal.Delete(MsgID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string MsgIDlist )
		{
			return dal.DeleteList(MsgIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CengZai.Model.MessageModel GetModel(int MsgID)
		{
			
			return dal.GetModel(MsgID);
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
		public List<CengZai.Model.MessageModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

