using System;
using System.Data;
using System.Collections.Generic;
using KuaiLe.Us.Model;
namespace KuaiLe.Us.BLL
{
	/// <summary>
	/// UserBll
	/// </summary>
	public class UserBll
	{
		private readonly KuaiLe.Us.DAL.UserDal dal=new KuaiLe.Us.DAL.UserDal();
		public UserBll()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserID)
		{
			return dal.Exists(UserID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }

        /// <summary>
        /// 是否存在电子邮箱
        /// </summary>
        public bool ChkEmail(string Email)
        {
            return dal.ChkEmail(Email);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(KuaiLe.Us.Model.UserModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.UserModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long UserID)
		{
			
			dal.Delete(UserID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string UserIDlist )
		{
			dal.DeleteList(UserIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.UserModel GetModel(long UserID)
		{
			
			return dal.GetModel(UserID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KuaiLe.Us.Model.UserModel GetModel(string strUserName)
        {

            return dal.GetModel(strUserName, false);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KuaiLe.Us.Model.UserModel GetModel(string strUserNameOrEmail, bool isEmail )
        {

            return dal.GetModel(strUserNameOrEmail, false);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KuaiLe.Us.Model.UserModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KuaiLe.Us.Model.UserModel> DataTableToList(DataTable dt)
		{
			List<KuaiLe.Us.Model.UserModel> modelList = new List<KuaiLe.Us.Model.UserModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KuaiLe.Us.Model.UserModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new KuaiLe.Us.Model.UserModel();
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
					model.UserName=dt.Rows[n]["UserName"].ToString();
					model.Nickname=dt.Rows[n]["Nickname"].ToString();
					model.Password=dt.Rows[n]["Password"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					if(dt.Rows[n]["Sex"].ToString()!="")
					{
						model.Sex=int.Parse(dt.Rows[n]["Sex"].ToString());
					}
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string strOrder, int pageSize, int pageIndex, out int records)
        {
            return dal.GetList(strWhere, strOrder, pageSize, pageIndex, out records);
        }

		#endregion  Method
	}
}

