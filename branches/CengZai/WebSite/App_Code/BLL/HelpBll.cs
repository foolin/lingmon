using System;
using System.Data;
using System.Collections.Generic;
//�����Ŷ� 2011��5��9��
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// HelpBll
	/// </summary>
	public partial class HelpBll
	{
		private readonly CengZai.DAL.HelpDal dal=new CengZai.DAL.HelpDal();
		public HelpBll()
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
		public bool Exists(int HelpID)
		{
			return dal.Exists(HelpID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(CengZai.Model.HelpModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(CengZai.Model.HelpModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int HelpID)
		{
			
			return dal.Delete(HelpID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string HelpIDlist )
		{
			return dal.DeleteList(HelpIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CengZai.Model.HelpModel GetModel(int HelpID)
		{
			
			return dal.GetModel(HelpID);
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
		public List<CengZai.Model.HelpModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CengZai.Model.HelpModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.HelpModel> modelList = new List<CengZai.Model.HelpModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.HelpModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.HelpModel();
					if(dt.Rows[n]["HelpID"].ToString()!="")
					{
						model.HelpID=int.Parse(dt.Rows[n]["HelpID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					model.PostIP=dt.Rows[n]["PostIP"].ToString();
					if(dt.Rows[n]["PostTime"].ToString()!="")
					{
						model.PostTime=DateTime.Parse(dt.Rows[n]["PostTime"].ToString());
					}
					if(dt.Rows[n]["HelperID"].ToString()!="")
					{
						model.HelperID=int.Parse(dt.Rows[n]["HelperID"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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

