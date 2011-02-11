using System;
using System.Data;
using System.Collections.Generic;
using KuaiLe.Us.Model;
namespace KuaiLe.Us.BLL
{
	/// <summary>
	/// ArticleBll
	/// </summary>
	public class ArticleBll
	{
		private readonly KuaiLe.Us.DAL.ArticleDal dal=new KuaiLe.Us.DAL.ArticleDal();
		public ArticleBll()
		{}
		#region  Method
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long ArtID)
		{
			return dal.Exists(ArtID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(KuaiLe.Us.Model.ArticleModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(KuaiLe.Us.Model.ArticleModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long ArtID)
		{
			
			dal.Delete(ArtID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void DeleteList(string ArtIDlist )
		{
			dal.DeleteList(ArtIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public KuaiLe.Us.Model.ArticleModel GetModel(long ArtID)
		{
			
			return dal.GetModel(ArtID);
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
		public List<KuaiLe.Us.Model.ArticleModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<KuaiLe.Us.Model.ArticleModel> DataTableToList(DataTable dt)
		{
			List<KuaiLe.Us.Model.ArticleModel> modelList = new List<KuaiLe.Us.Model.ArticleModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KuaiLe.Us.Model.ArticleModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new KuaiLe.Us.Model.ArticleModel();
                    if (dt.Rows[n]["ArtID"].ToString() != "")
                    {
                        model.ArtID = long.Parse(dt.Rows[n]["ArtID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					model.Tags=dt.Rows[n]["Tags"].ToString();
					if(dt.Rows[n]["IsAnonym"].ToString()!="")
					{
						model.IsAnonym=int.Parse(dt.Rows[n]["IsAnonym"].ToString());
					}
					if(dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
					}
					if(dt.Rows[n]["Hits"].ToString()!="")
					{
						model.Hits=int.Parse(dt.Rows[n]["Hits"].ToString());
					}
					if(dt.Rows[n]["DigUp"].ToString()!="")
					{
						model.DigUp=int.Parse(dt.Rows[n]["DigUp"].ToString());
					}
					if(dt.Rows[n]["DigDown"].ToString()!="")
					{
						model.DigDown=int.Parse(dt.Rows[n]["DigDown"].ToString());
					}
					if(dt.Rows[n]["Comments"].ToString()!="")
					{
						model.Comments=int.Parse(dt.Rows[n]["Comments"].ToString());
					}
					if(dt.Rows[n]["Reports"].ToString()!="")
					{
						model.Reports=int.Parse(dt.Rows[n]["Reports"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
                    model.UserIP = dt.Rows[n]["UserIP"].ToString();
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

