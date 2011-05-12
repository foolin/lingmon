using System;
using System.Data;
using System.Collections.Generic;
//�����Ŷ� 2011��5��9��
using CengZai.Model;
namespace CengZai.BLL
{
	/// <summary>
	/// UserBll
	/// </summary>
	public partial class UserBll
	{
		private readonly CengZai.DAL.UserDal dal=new CengZai.DAL.UserDal();
		public UserBll()
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
		public bool Exists(int UserID)
		{
			return dal.Exists(UserID);
		}

        /// <summary>
        /// �ж��Ƿ���ڸ�����
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool Exists(string email)
        {
            return dal.Exists(email);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(CengZai.Model.UserModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(CengZai.Model.UserModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int UserID)
		{
			
			return dal.Delete(UserID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CengZai.Model.UserModel GetModel(int UserID)
		{
			
			return dal.GetModel(UserID);
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
		public List<CengZai.Model.UserModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CengZai.Model.UserModel> DataTableToList(DataTable dt)
		{
			List<CengZai.Model.UserModel> modelList = new List<CengZai.Model.UserModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CengZai.Model.UserModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CengZai.Model.UserModel();
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					model.Email=dt.Rows[n]["Email"].ToString();
					model.Password=dt.Rows[n]["Password"].ToString();
					model.NickName=dt.Rows[n]["NickName"].ToString();
					if(dt.Rows[n]["Sex"].ToString()!="")
					{
						model.Sex=int.Parse(dt.Rows[n]["Sex"].ToString());
					}
					if(dt.Rows[n]["Birth"].ToString()!="")
					{
						model.Birth=DateTime.Parse(dt.Rows[n]["Birth"].ToString());
					}
					model.Motto=dt.Rows[n]["Motto"].ToString();
					model.Face=dt.Rows[n]["Face"].ToString();
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
					if(dt.Rows[n]["FindPwdTime"].ToString()!="")
					{
						model.FindPwdTime=DateTime.Parse(dt.Rows[n]["FindPwdTime"].ToString());
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

