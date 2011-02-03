﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Utility.DB
{
    /// <summary>
    /// 数据辅助类
    /// </summary>
    public class DataHelper
    {
        public DataHelper()
        {
        }

        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//返回的查询结果
        }
    }
}
