using System;
using System.Data;
using System.Collections.Generic;
using LFL.Favorite.Model;
/***********************************************
  *  BLLҵ���߼��� 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/17 23:30:46
  *  Copyright(C) 2010 �����Ŷ� ��������Ȩ����
***********************************************/
namespace LFL.Favorite.BLL
{
	/// <summary>
	/// ҵ���߼���FavoriteBll ��ժҪ˵����
	/// </summary>
	public class FavoriteBll
	{
		private readonly LFL.Favorite.DAL.FavoriteDal dal=new LFL.Favorite.DAL.FavoriteDal();
		public FavoriteBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(LFL.Favorite.Model.Favorite model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LFL.Favorite.Model.Favorite model)
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
		public LFL.Favorite.Model.Favorite GetModel()
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
		public List<LFL.Favorite.Model.Favorite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LFL.Favorite.Model.Favorite> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.Favorite> modelList = new List<LFL.Favorite.Model.Favorite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.Favorite model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.Favorite();
					if(dt.Rows[n]["FavID"].ToString()!="")
					{
						model.FavID=int.Parse(dt.Rows[n]["FavID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.URL=dt.Rows[n]["URL"].ToString();
					if(dt.Rows[n]["FavCategoryID"].ToString()!="")
					{
						model.FavCategoryID=int.Parse(dt.Rows[n]["FavCategoryID"].ToString());
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
		public DataSet GetList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
		{
			return dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount);
		}
		
		
		/// <summary>
		/// ��ҳ����
		/// </summary>
		/// <param name="pageSize">ÿҳ��¼��С</param>
		/// <param name="pageIndex">��ǰ����ҳ</param>
		/// <param name="totalCount">�ܼ�¼��</param>
		/// <returns></returns>
		public List<LFL.Favorite.Model.Favorite> GetModelList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
		{
			return DataTableToList(dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount).Tables[0]);
		}
		*/

		#endregion  ��Ա����
	}
}

