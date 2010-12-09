using System;
using System.Data;
using System.Collections.Generic;
using LFL.Favorite.Model;
/***********************************************
  *  BLLҵ���߼��� 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/4 0:31:57
  *  Copyright(C) 2010 �����Ŷ� ��������Ȩ����
***********************************************/
namespace LFL.Favorite.BLL
{
	/// <summary>
	/// ҵ���߼���FavCategoryBll ��ժҪ˵����
	/// </summary>
	public class FavCategoryBll
	{
		private readonly LFL.Favorite.DAL.FavCategoryDal dal=new LFL.Favorite.DAL.FavCategoryDal();
		public FavCategoryBll()
		{}
		#region  ��Ա����

		///// <summary>
		///// �õ����ID
		///// </summary>
		//public int GetMaxId()
		//{
			//return dal.GetMaxId();
		//}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int FavCategoryID)
		{
			return dal.Exists(FavCategoryID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LFL.Favorite.Model.FavCategory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LFL.Favorite.Model.FavCategory model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int FavCategoryID)
		{
			
			dal.Delete(FavCategoryID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LFL.Favorite.Model.FavCategory GetModel(int FavCategoryID)
		{
			
			return dal.GetModel(FavCategoryID);
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
		public List<LFL.Favorite.Model.FavCategory> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LFL.Favorite.Model.FavCategory> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.FavCategory> modelList = new List<LFL.Favorite.Model.FavCategory>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.FavCategory model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.FavCategory();
					if(dt.Rows[n]["FavCategoryID"].ToString()!="")
					{
						model.FavCategoryID=int.Parse(dt.Rows[n]["FavCategoryID"].ToString());
					}
					model.CategoryName=dt.Rows[n]["CategoryName"].ToString();
					if(dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=int.Parse(dt.Rows[n]["ParentID"].ToString());
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
		public List<LFL.Favorite.Model.FavCategory> GetModelList(int pageSize, int pageIndex, out int totalCount)
		{
			return DataTableToList(dal.GetList(pageSize, pageIndex, out totalCount).Tables[0]);
		}
		*/

		#endregion  ��Ա����
	}
}

