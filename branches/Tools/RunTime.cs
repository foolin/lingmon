using System;
using System.Collections.Generic;
using System.Text;

namespace Sxmobi.Tools
{
    /// <summary>
    /// 计算执行时间
    /// Author:  Foolin
    /// Created: 2010-08-08
    /// </summary>
    public class RunTime
    {
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceCounter(ref long count);
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceFrequency(ref long count);

        private long startCount = 0;
        private long endCount = 0;
        private long freq = 0;
        private double result = 0;

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            //重置0
            startCount = 0;
            endCount = 0;
            freq = 0;
            result = 0;
            //开始记录
            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref startCount);
        }

        /// <summary>
        /// 停止执行
        /// </summary>
        public void End()
        {
            long count = 0;
            QueryPerformanceCounter(ref endCount);
            count = endCount - startCount;
            result = (double)(count) / (double)freq; 
        }

        /// <summary>
        /// 返回执行时间，单位秒
        /// </summary>
        /// <returns></returns>
        public double GetResult()
        {
            return result;
        }

        /// <summary>
        /// 返回执行时间，默认4位
        /// </summary>
        /// <returns></returns>
        public double GetResultFormat()
        {
            return Math.Round(result, 4);
        }

        /// <summary>
        /// 返回执行时间
        /// </summary>
        /// <param name="digits">小数点精确位数</param>
        /// <returns></returns>
        public double GetResultFormat(int digits)
        {
            return Math.Round(result, digits);
        }

        /// <summary>
        /// 返回执行时间字符串
        /// </summary>
        /// <returns></returns>
        public string GetResultString()
        {
            return "耗时: " + GetResult() + " 秒";
        }

        /// <summary>
        /// 返回执行时间字符串，默认小数点后4位
        /// </summary>
        /// <returns></returns>
        public string GetResultFormatString()
        {
            return "耗时: " + GetResultFormat() + " 秒";
        }

        /// <summary>
        /// 返回执行时间字符串
        /// </summary>
        /// <param name="digits">精确小数点后位数</param>
        /// <returns></returns>
        public string GetResultFormatString(int digits)
        {
            return "耗时: " + GetResultFormat(digits) + " 秒";
        }

    }
}
