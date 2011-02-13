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
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long DigID)
		{
			return dal.Exists(DigID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(KuaiLe.Us.Model.DigModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(KuaiLe.Us.Model.DigModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long DigID)
		{
			
			dal.Delete(DigID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void DeleteList(string DigIDlist )
		{
			dal.DeleteList(DigIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public KuaiLe.Us.Model.DigModel GetModel(long DigID)
		{
			
			return dal.GetModel(DigID);
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
		public List<KuaiLe.Us.Model.DigModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

