using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/***********************************************
  *  DAL���ݲ� 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/4 0:33:02
  *  Copyright(C) 2010 �����Ŷ� ��������Ȩ������
***********************************************/
namespace LFL.Favorite.DAL
{
	/// <summary>
	/// ���ݷ�����UserDal��
	/// </summary>
	public class UserDal
	{

		DbBase db = new DbBase();

		public UserDal()
		{}

		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		//public int GetMaxId()
		//{
		//return DbBase.GetMaxID("UserID", "T_User"); 
		//}

        /// <summary>
        /// �Ƿ���ڸü�¼���ж��û�������Email
        /// </summary>
        /// <param name="model">�û�ʵ��</param>
        /// <param name="chkType">������ͣ�0=�û�����Email����飬1=�û�����2=Email</param>
        /// <returns></returns>
        public bool Exists(string strUsername, string strEmail)
        {
            if (string.IsNullOrEmpty(strUsername.Trim()) && string.IsNullOrEmpty(strEmail.Trim()))
            {
                return true;
            }

            StringBuilder strSql = new StringBuilder();
            StringBuilder strWhere = new StringBuilder();
            strSql.Append("select count(1) from T_User");
            strSql.Append(" where ");
            if (!string.IsNullOrEmpty(strUsername.Trim()))
            {
                strWhere.Append(" Username='" + strUsername + "'");
            }
            if (!string.IsNullOrEmpty(strEmail.Trim()))
            {
                if (strWhere.Length > 0)
                {
                    strWhere.Append(" or "); 
                }
                strWhere.Append(" Email='" + strEmail + "'");
            }
            strSql.Append(strWhere.ToString());
            return (db.RunSqlReturnInt(strSql.ToString()) > 0);
        }

        /// <summary>
        /// �����û���-1=����ʧ�ܣ�ԭ��δ֪��0=����ʧ�ܣ��������û������߼��������1=����ɹ���2=�Ѿ�����
        /// </summary>
        /// <param name="strUsername"></param>
        /// <param name="strAtivateCode"></param>
        /// <returns></returns>
        public int UserAtivate(string strUsername, string strActivateCode)
        {
            if (string.IsNullOrEmpty(strUsername.Trim()) || string.IsNullOrEmpty(strActivateCode.Trim()))
            {
                return 0;
            }
            
            LFL.Favorite.Model.User model = GetModel(strUsername);
            //������
            if(model == null)
            {
                return 0;
            }
            //�Ѿ�����
            if(model.Status > 0)
            {
                return 2;
            }
            //���������
            if(!model.ActivateCode.Equals(strActivateCode))
            {
                return 0;
            }
            //����״̬Ϊ1
            model.Status = 1;
            try
            {
                Update(model);
                //����ɹ�
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
                return -1;
            }
            
            return 0;
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LFL.Favorite.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Username != null)
			{
				strSql1.Append("Username,");
				strSql2.Append("'"+model.Username+"',");
			}
			if (model.Nickname != null)
			{
				strSql1.Append("Nickname,");
				strSql2.Append("'"+model.Nickname+"',");
			}
			if (model.Password != null)
			{
				strSql1.Append("Password,");
				strSql2.Append("'"+model.Password+"',");
			}
			if (model.Email != null)
			{
				strSql1.Append("Email,");
				strSql2.Append("'"+model.Email+"',");
			}
			if (model.Sex != null)
			{
				strSql1.Append("Sex,");
				strSql2.Append("'"+model.Sex+"',");
			}
			if (model.ActivateCode != null)
			{
				strSql1.Append("ActivateCode,");
				strSql2.Append("'"+model.ActivateCode+"',");
			}
			if (model.RegTime != null)
			{
				strSql1.Append("RegTime,");
				strSql2.Append("'"+model.RegTime+"',");
			}
			if (model.RegIP != null)
			{
				strSql1.Append("RegIP,");
				strSql2.Append("'"+model.RegIP+"',");
			}
			if (model.LastLoginTime != null)
			{
				strSql1.Append("LastLoginTime,");
				strSql2.Append("'"+model.LastLoginTime+"',");
			}
			if (model.LastLoginIP != null)
			{
				strSql1.Append("LastLoginIP,");
				strSql2.Append("'"+model.LastLoginIP+"',");
			}
			if (model.LoginCount != null)
			{
				strSql1.Append("LoginCount,");
				strSql2.Append(""+model.LoginCount+",");
			}
			if (model.Level != null)
			{
				strSql1.Append("Level,");
				strSql2.Append(""+model.Level+",");
			}
			if (model.Credit != null)
			{
				strSql1.Append("Credit,");
				strSql2.Append(""+model.Credit+",");
			}
			if (model.Status != null)
			{
				strSql1.Append("Status,");
				strSql2.Append(""+model.Status+",");
			}
			strSql.Append("insert into T_User(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";SELECT SCOPE_IDENTITY() AS [ID]");
			return db.RunSqlReturnInt(strSql.ToString());
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LFL.Favorite.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_User set ");
			if (model.Username != null)
			{
				strSql.Append("Username='"+model.Username+"',");
			}
			if (model.Nickname != null)
			{
				strSql.Append("Nickname='"+model.Nickname+"',");
			}
			if (model.Password != null)
			{
				strSql.Append("Password='"+model.Password+"',");
			}
			if (model.Email != null)
			{
				strSql.Append("Email='"+model.Email+"',");
			}
			if (model.Sex != null)
			{
				strSql.Append("Sex='"+model.Sex+"',");
			}
			if (model.ActivateCode != null)
			{
				strSql.Append("ActivateCode='"+model.ActivateCode+"',");
			}
			if (model.RegTime != null)
			{
				strSql.Append("RegTime='"+model.RegTime+"',");
			}
			if (model.RegIP != null)
			{
				strSql.Append("RegIP='"+model.RegIP+"',");
			}
			if (model.LastLoginTime != null)
			{
				strSql.Append("LastLoginTime='"+model.LastLoginTime+"',");
			}
			if (model.LastLoginIP != null)
			{
				strSql.Append("LastLoginIP='"+model.LastLoginIP+"',");
			}
			if (model.LoginCount != null)
			{
				strSql.Append("LoginCount="+model.LoginCount+",");
			}
			if (model.Level != null)
			{
				strSql.Append("Level="+model.Level+",");
			}
			if (model.Credit != null)
			{
				strSql.Append("Credit="+model.Credit+",");
			}
			if (model.Status != null)
			{
				strSql.Append("Status="+model.Status+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where UserID="+ model.UserID+" ");
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_User ");
			strSql.Append(" where UserID="+UserID+" " );
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LFL.Favorite.Model.User GetModel(int UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" UserID,Username,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status ");
			strSql.Append(" from T_User ");
			strSql.Append(" where UserID="+UserID+" " );
			LFL.Favorite.Model.User model=new LFL.Favorite.Model.User();
			DataSet ds = db.GetDs(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.Username=ds.Tables[0].Rows[0]["Username"].ToString();
				model.Nickname=ds.Tables[0].Rows[0]["Nickname"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.ActivateCode=ds.Tables[0].Rows[0]["ActivateCode"].ToString();
				if(ds.Tables[0].Rows[0]["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
				}
				model.RegIP=ds.Tables[0].Rows[0]["RegIP"].ToString();
				if(ds.Tables[0].Rows[0]["LastLoginTime"].ToString()!="")
				{
					model.LastLoginTime=DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
				}
				model.LastLoginIP=ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
				if(ds.Tables[0].Rows[0]["LoginCount"].ToString()!="")
				{
					model.LoginCount=int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level"].ToString()!="")
				{
					model.Level=int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Credit"].ToString()!="")
				{
					model.Credit=decimal.Parse(ds.Tables[0].Rows[0]["Credit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}


        /// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LFL.Favorite.Model.User GetModel(string strUsername)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" UserID,Username,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status ");
			strSql.Append(" from T_User ");
			strSql.Append(" where Username='"+strUsername+"' " );
			LFL.Favorite.Model.User model=new LFL.Favorite.Model.User();
			DataSet ds = db.GetDs(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.Username=ds.Tables[0].Rows[0]["Username"].ToString();
				model.Nickname=ds.Tables[0].Rows[0]["Nickname"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.ActivateCode=ds.Tables[0].Rows[0]["ActivateCode"].ToString();
				if(ds.Tables[0].Rows[0]["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
				}
				model.RegIP=ds.Tables[0].Rows[0]["RegIP"].ToString();
				if(ds.Tables[0].Rows[0]["LastLoginTime"].ToString()!="")
				{
					model.LastLoginTime=DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
				}
				model.LastLoginIP=ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
				if(ds.Tables[0].Rows[0]["LoginCount"].ToString()!="")
				{
					model.LoginCount=int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level"].ToString()!="")
				{
					model.Level=int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Credit"].ToString()!="")
				{
					model.Credit=decimal.Parse(ds.Tables[0].Rows[0]["Credit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID,Username,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status ");
			strSql.Append(" FROM T_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetDs(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" UserID,Username,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status ");
			strSql.Append(" FROM T_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int pageSize, int pageIndex, out int totalCount)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSort = new StringBuilder();
			//Sql���
			strSql.Append(" UserID,Username,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status ");
			strSql.Append(" FROM T_User ");
			//����
			//strSort.Append(" ID Asc");
			
			return db.GetPageDs(strSql.ToString(), strSort.ToString(), pageSize, pageIndex, out totalCount);
		}
		*/

		#endregion  ��Ա����
	}
}

