using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Utility;
using Utility.DB;
using System.Data.SqlClient;

namespace KuaiLe.Us.Common
{

    /// <summary>
    ///KuaiLe.Us.Common.DbBase 的摘要说明
    /// </summary>
    public class DbBase : SqlDataBase
    {
        public DbBase()
            : base(SysConfig.ConnectionString)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }


        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strSort"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetPageDs(string strSql, string strSort, int pageSize, int pageIndex, out int totalCount)
        {
            DataSet dsReturn = null;
            SqlParameter records = NewParam("@TotalCount", 0, DbType.Int32, 32, true);
            SqlParameter[] sqlParams = {
                                   NewParam("@SQL", strSql) //SQL语句
                                   , NewParam("@Sort", strSort) //排序
                                   , NewParam("@PageSize", pageSize)    //每页记录数大小
                                   , NewParam("@PageIndex", pageIndex)  //索引页：从1开始
                                   , records }; //返回的总记录数
            dsReturn = GetProcDs("Wb_Paging", sqlParams);
            totalCount = (int)records.Value;

            return dsReturn;
        }


    }

}
