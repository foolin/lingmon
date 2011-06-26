using System;
using System.Data;
using System.Collections.Generic;
//�����Ŷ� 2011��5��9��
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// WikiVerBll
	/// </summary>
	public partial class WikiVerBll
	{
		private readonly CengZai.DAL.WikiVerDal dal=new CengZai.DAL.WikiVerDal();
		public WikiVerBll()
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
		public bool Exists(int VerID)
		{
			return dal.Exists(VerID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(CengZai.Model.WikiVerModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(CengZai.Model.WikiVerModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int VerID)
		{
			
			return dal.Delete(VerID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string VerIDlist )
		{
			return dal.DeleteList(VerIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CengZai.Model.WikiVerModel GetModel(int VerID)
		{
			
			return dal.GetModel(VerID);
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
		public List<CengZai.Model.WikiVerModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CengZai.Model.WikiVerModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.WikiVerModel> modelList = new List<CengZai.Model.WikiVerModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.WikiVerModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.WikiVerModel();
					if(dt.Rows[n]["VerID"].ToString()!="")
					{
						model.VerID=int.Parse(dt.Rows[n]["VerID"].ToString());
					}
					model.Content=dt.Rows[n]["Content"].ToString();
					model.Supply=dt.Rows[n]["Supply"].ToString();
					model.Reason=dt.Rows[n]["Reason"].ToString();
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
					model.StatusMsg=dt.Rows[n]["StatusMsg"].ToString();
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
