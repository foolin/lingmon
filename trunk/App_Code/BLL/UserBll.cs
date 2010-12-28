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
	/// ҵ���߼���UserBll ��ժҪ˵����
	/// </summary>
	public class UserBll
	{
		private readonly LFL.Favorite.DAL.UserDal dal=new LFL.Favorite.DAL.UserDal();
		public UserBll()
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
        public bool Exists(string strUsername, string strEmail)
		{
            return dal.Exists(strUsername, strEmail);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LFL.Favorite.Model.User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LFL.Favorite.Model.User model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int UserID)
		{
			
			dal.Delete(UserID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LFL.Favorite.Model.User GetModel(int UserID)
		{
			
			return dal.GetModel(UserID);
		}

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LFL.Favorite.Model.User GetModel(string strUsername)
        {

            return dal.GetModel(strUsername);
        }

        /// <summary>
        /// �����û���-1=����ʧ�ܣ�ԭ��δ֪��0=����ʧ�ܣ��������û������߼��������1=����ɹ���2=�Ѿ�����
        /// </summary>
        /// <param name="strUsername"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int UserAcivate(string strUsername, string strActivateCode)
        {
            return dal.UserAtivate(strUsername, strActivateCode);
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
		public List<LFL.Favorite.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LFL.Favorite.Model.User> DataTableToList(DataTable dt)
		{
			List<LFL.Favorite.Model.User> modelList = new List<LFL.Favorite.Model.User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LFL.Favorite.Model.User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LFL.Favorite.Model.User();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					model.Username=dt.Rows[n]["Username"].ToString();
					model.Nickname=dt.Rows[n]["Nickname"].ToString();
					model.Password=dt.Rows[n]["Password"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.Sex=dt.Rows[n]["Sex"].ToString();
					model.ActivateCode=dt.Rows[n]["ActivateCode"].ToString();
					if(dt.Rows[n]["RegTime"].ToString()!="")
					{
						model.RegTime=DateTime.Parse(dt.Rows[n]["RegTime"].ToString());
					}
					model.RegIP=dt.Rows[n]["RegIP"].ToString();
					if(dt.Rows[n]["LastLoginTime"].ToString()!="")
					{
						model.LastLoginTime=DateTime.Parse(dt.Rows[n]["LastLoginTime"].ToString());
					}
					model.LastLoginIP=dt.Rows[n]["LastLoginIP"].ToString();
					if(dt.Rows[n]["LoginCount"].ToString()!="")
					{
						model.LoginCount=int.Parse(dt.Rows[n]["LoginCount"].ToString());
					}
					if(dt.Rows[n]["Level"].ToString()!="")
					{
						model.Level=int.Parse(dt.Rows[n]["Level"].ToString());
					}
					if(dt.Rows[n]["Credit"].ToString()!="")
					{
						model.Credit=decimal.Parse(dt.Rows[n]["Credit"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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
        public List<LFL.Favorite.Model.User> GetModelList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
        {
            return DataTableToList(dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount).Tables[0]);
        }
        

		#endregion  ��Ա����
	}
}

