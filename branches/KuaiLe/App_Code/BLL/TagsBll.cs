using System;
using System.Data;
using System.Collections.Generic;
using KuaiLe.Us.Model;
namespace KuaiLe.Us.BLL
{
	/// <summary>
	/// TagsBll
	/// </summary>
	public class TagsBll
	{
		private readonly KuaiLe.Us.DAL.TagsDal dal=new KuaiLe.Us.DAL.TagsDal();
		public TagsBll()
		{}
		#region  Method


		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int TagID)
		{
			return dal.Exists(TagID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(KuaiLe.Us.Model.TagsModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(KuaiLe.Us.Model.TagsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int TagID)
		{
			
			dal.Delete(TagID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void DeleteList(string TagIDlist )
		{
			dal.DeleteList(TagIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public KuaiLe.Us.Model.TagsModel GetModel(int TagID)
		{
			
			return dal.GetModel(TagID);
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
		public List<KuaiLe.Us.Model.TagsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<KuaiLe.Us.Model.TagsModel> DataTableToList(DataTable dt)
		{
			List<KuaiLe.Us.Model.TagsModel> modelList = new List<KuaiLe.Us.Model.TagsModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KuaiLe.Us.Model.TagsModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new KuaiLe.Us.Model.TagsModel();
					if(dt.Rows[n]["TagID"].ToString()!="")
					{
						model.TagID=int.Parse(dt.Rows[n]["TagID"].ToString());
					}
					if(dt.Rows[n]["ArtID"].ToString()!="")
					{
						model.ArtID=int.Parse(dt.Rows[n]["ArtID"].ToString());
					}
					model.Tag=dt.Rows[n]["Tag"].ToString();
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

