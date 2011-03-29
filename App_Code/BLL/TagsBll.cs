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
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TagID)
		{
			return dal.Exists(TagID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(KuaiLe.Us.Model.TagsModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.TagsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int TagID)
		{
			
			dal.Delete(TagID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string TagIDlist )
		{
			dal.DeleteList(TagIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.TagsModel GetModel(int TagID)
		{
			
			return dal.GetModel(TagID);
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
		public List<KuaiLe.Us.Model.TagsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

