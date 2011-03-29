using System;
using System.Data;
using System.Collections.Generic;
using KuaiLe.Us.Model;
namespace KuaiLe.Us.BLL
{
	/// <summary>
	/// CommentBll
	/// </summary>
	public class CommentBll
	{
		private readonly KuaiLe.Us.DAL.CommentDal dal=new KuaiLe.Us.DAL.CommentDal();
		public CommentBll()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long CommentID)
		{
			return dal.Exists(CommentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(KuaiLe.Us.Model.CommentModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.CommentModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long CommentID)
		{
			
			dal.Delete(CommentID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string CommentIDlist )
		{
			dal.DeleteList(CommentIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.CommentModel GetModel(long CommentID)
		{
			
			return dal.GetModel(CommentID);
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
		public List<KuaiLe.Us.Model.CommentModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KuaiLe.Us.Model.CommentModel> DataTableToList(DataTable dt)
		{
			List<KuaiLe.Us.Model.CommentModel> modelList = new List<KuaiLe.Us.Model.CommentModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KuaiLe.Us.Model.CommentModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new KuaiLe.Us.Model.CommentModel();
                    if (dt.Rows[n]["CommentID"].ToString() != "")
                    {
                        model.CommentID = long.Parse(dt.Rows[n]["CommentID"].ToString());
                    }
                    if (dt.Rows[n]["ArtID"].ToString() != "")
                    {
                        model.ArtID = long.Parse(dt.Rows[n]["ArtID"].ToString());
                    }
					model.Comment=dt.Rows[n]["Comment"].ToString();
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.ArtID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
					if(dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
					}
					if(dt.Rows[n]["DigUp"].ToString()!="")
					{
						model.DigUp=int.Parse(dt.Rows[n]["DigUp"].ToString());
					}
					if(dt.Rows[n]["DigDown"].ToString()!="")
					{
						model.DigDown=int.Parse(dt.Rows[n]["DigDown"].ToString());
					}
					if(dt.Rows[n]["Reports"].ToString()!="")
					{
						model.Reports=int.Parse(dt.Rows[n]["Reports"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
                    model.UserName = dt.Rows[0]["UserName"].ToString();
                    model.UserIP = dt.Rows[0]["UserIP"].ToString();
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

