using System;
using System.Data;
using System.Collections.Generic;
using LFL.Favorite.Model;
/***********************************************
  *  BLL业务逻辑层 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/4 0:31:58
  *  Copyright(C) 2010 灵梦团队 保留所有权利。
***********************************************/
namespace LFL.Favorite.BLL
{
	/// <summary>
	/// 业务逻辑类UserBll 的摘要说明。
	/// </summary>
	public class UserBll
	{
		private readonly LFL.Favorite.DAL.UserDal dal=new LFL.Favorite.DAL.UserDal();
		public UserBll()
		{}
		#region  成员方法

		///// <summary>
		///// 得到最大ID
		///// </summary>
		//public int GetMaxId()
		//{
			//return dal.GetMaxId();
		//}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string strUsername, string strEmail)
		{
            return dal.Exists(strUsername, strEmail);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LFL.Favorite.Model.User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.User model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UserID)
		{
			
			dal.Delete(UserID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LFL.Favorite.Model.User GetModel(int UserID)
		{
			
			return dal.GetModel(UserID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LFL.Favorite.Model.User GetModel(string strUsername)
        {

            return dal.GetModel(strUsername);
        }

        /// <summary>
        /// 激活用户：-1=激活失败，原因未知，0=激活失败，不存在用户名或者激活码错误，1=激活成功，2=已经激活
        /// </summary>
        /// <param name="strUsername"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int UserAcivate(string strUsername, string strActivateCode)
        {
            return dal.UserAtivate(strUsername, strActivateCode);
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
		public List<LFL.Favorite.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageSize">每页记录大小</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
        {
            return dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount);
        }
		
		
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageSize">每页记录大小</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public List<LFL.Favorite.Model.User> GetModelList(string strWhere,string strOrder, int pageSize, int pageIndex, out int totalCount)
        {
            return DataTableToList(dal.GetList(strWhere , strOrder, pageSize, pageIndex, out totalCount).Tables[0]);
        }
        

		#endregion  成员方法
	}
}

