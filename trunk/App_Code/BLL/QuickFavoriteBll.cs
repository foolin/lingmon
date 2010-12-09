using System;
using System.Data;
using System.Collections.Generic;
using LFL.Favorite.Model;
/***********************************************
  *  BLLҵ���߼��� 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/4 0:31:58
  *  Copyright(C) 2010 �����Ŷ� ��������Ȩ����
***********************************************/
namespace LFL.Favorite.BLL
{
	/// <summary>
	/// ҵ���߼���QuickFavoriteBll ��ժҪ˵����
	/// </summary>
	public class QuickFavoriteBll
	{
		private readonly LFL.Favorite.DAL.QuickFavoriteDal dal=new LFL.Favorite.DAL.QuickFavoriteDal();
		public QuickFavoriteBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(LFL.Favorite.Model.QuickFavorite model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LFL.Favorite.Model.QuickFavorite model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			dal.Delete();
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LFL.Favorite.Model.QuickFavorite GetModel()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel();
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
		public List<LFL.Favorite.Model.QuickFavorite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LFL.Favorite.Model.QuickFavorite> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.QuickFavorite> modelList = new List<LFL.Favorite.Model.QuickFavorite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.QuickFavorite model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.QuickFavorite();
					if(dt.Rows[n]["QuickFavID"].ToString()!="")
					{
						model.QuickFavID=int.Parse(dt.Rows[n]["QuickFavID"].ToString());
					}
					if(dt.Rows[n]["FavID"].ToString()!="")
					{
						model.FavID=int.Parse(dt.Rows[n]["FavID"].ToString());
					}
					model.MinImage=dt.Rows[n]["MinImage"].ToString();
					if(dt.Rows[n]["OffsetLeft"].ToString()!="")
					{
						model.OffsetLeft=decimal.Parse(dt.Rows[n]["OffsetLeft"].ToString());
					}
					if(dt.Rows[n]["OffsetTop"].ToString()!="")
					{
						model.OffsetTop=decimal.Parse(dt.Rows[n]["OffsetTop"].ToString());
					}
					if(dt.Rows[n]["Width"].ToString()!="")
					{
						model.Width=decimal.Parse(dt.Rows[n]["Width"].ToString());
					}
					if(dt.Rows[n]["Height"].ToString()!="")
					{
						model.Height=decimal.Parse(dt.Rows[n]["Height"].ToString());
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

		/*
		/// <summary>
		/// ��ҳ����
		/// </summary>
		/// <param name="pageSize">ÿҳ��¼��С</param>
		/// <param name="pageIndex">��ǰ����ҳ</param>
		/// <param name="totalCount">�ܼ�¼��</param>
		/// <returns></returns>
		public DataSet GetList(int pageSize, int pageIndex, out int totalCount)
		{
			return dal.GetList(pageSize, pageIndex, out totalCount);
		}
		
		
		/// <summary>
		/// ��ҳ����
		/// </summary>
		/// <param name="pageSize">ÿҳ��¼��С</param>
		/// <param name="pageIndex">��ǰ����ҳ</param>
		/// <param name="totalCount">�ܼ�¼��</param>
		/// <returns></returns>
		public List<LFL.Favorite.Model.QuickFavorite> GetModelList(int pageSize, int pageIndex, out int totalCount)
		{
			return DataTableToList(dal.GetList(pageSize, pageIndex, out totalCount).Tables[0]);
		}
		*/

		#endregion  ��Ա����
	}
}

