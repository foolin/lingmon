using System;
using System.Data;
using System.Collections.Generic;
//�����Ŷ� 2011��5��9��
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// WikiBll
	/// </summary>
	public partial class WikiBll
	{
		private readonly CengZai.DAL.WikiDal dal=new CengZai.DAL.WikiDal();
		public WikiBll()
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
		public bool Exists(int WikiID)
		{
			return dal.Exists(WikiID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(CengZai.Model.WikiModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(CengZai.Model.WikiModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int WikiID)
		{
			
			return dal.Delete(WikiID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string WikiIDlist )
		{
			return dal.DeleteList(WikiIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CengZai.Model.WikiModel GetModel(int WikiID)
		{
			
			return dal.GetModel(WikiID);
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
		public List<CengZai.Model.WikiModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CengZai.Model.WikiModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.WikiModel> modelList = new List<CengZai.Model.WikiModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.WikiModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.WikiModel();
					if(dt.Rows[n]["WikiID"].ToString()!="")
					{
						model.WikiID=int.Parse(dt.Rows[n]["WikiID"].ToString());
					}
					model.Word=dt.Rows[n]["Word"].ToString();
					if(dt.Rows[n]["VerID"].ToString()!="")
					{
						model.VerID=int.Parse(dt.Rows[n]["VerID"].ToString());
					}
					if(dt.Rows[n]["Views"].ToString()!="")
					{
						model.Views=int.Parse(dt.Rows[n]["Views"].ToString());
					}
					if(dt.Rows[n]["Edits"].ToString()!="")
					{
						model.Edits=int.Parse(dt.Rows[n]["Edits"].ToString());
					}
					if(dt.Rows[n]["CreateUserID"].ToString()!="")
					{
						model.CreateUserID=int.Parse(dt.Rows[n]["CreateUserID"].ToString());
					}
					if(dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
					}
					if(dt.Rows[n]["UpdateUserID"].ToString()!="")
					{
						model.UpdateUserID=int.Parse(dt.Rows[n]["UpdateUserID"].ToString());
					}
					if(dt.Rows[n]["UpdateTime"].ToString()!="")
					{
						model.UpdateTime=DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
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

