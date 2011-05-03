using System;
using System.Data;
using System.Collections.Generic;
using KuaiLe.Us.Model;
namespace KuaiLe.Us.BLL
{
	/// <summary>
	/// NoticeBll
	/// </summary>
	public class NoticeBll
	{
		private readonly KuaiLe.Us.DAL.NoticeDal dal=new KuaiLe.Us.DAL.NoticeDal();
		public NoticeBll()
		{}
		#region  Method



		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(KuaiLe.Us.Model.NoticeModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(KuaiLe.Us.Model.NoticeModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void DeleteList(string IDlist )
		{
			dal.DeleteList(IDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public KuaiLe.Us.Model.NoticeModel GetModel(int ID)
		{
			
			return dal.GetModel(ID);
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
		public List<KuaiLe.Us.Model.NoticeModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<KuaiLe.Us.Model.NoticeModel> DataTableToList(DataTable dt)
		{
			List<KuaiLe.Us.Model.NoticeModel> modelList = new List<KuaiLe.Us.Model.NoticeModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KuaiLe.Us.Model.NoticeModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new KuaiLe.Us.Model.NoticeModel();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					model.Author=dt.Rows[n]["Author"].ToString();
					if(dt.Rows[n]["PostTime"].ToString()!="")
					{
						model.PostTime=DateTime.Parse(dt.Rows[n]["PostTime"].ToString());
					}
					model.PostIP=dt.Rows[n]["PostIP"].ToString();
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
        public DataSet GetList(string strWhere, string strOrder, int pageSize, int pageIndex, out int records)
        {
            return dal.GetList(strWhere, strOrder, pageSize, pageIndex, out records);
        }

		#endregion  Method
	}
}

