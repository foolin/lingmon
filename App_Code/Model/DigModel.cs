using System;
namespace KuaiLe.Us.Model
{
	/// <summary>
	/// DigModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class DigModel
	{
		public DigModel()
		{}
		#region Model
		private long _digid;
		private long _srcid;
		private string _srctype;
		private int? _userid;
		private string _userip;
		private int? _digtype;
		/// <summary>
		/// 
		/// </summary>
		public long DigID
		{
			set{ _digid=value;}
			get{return _digid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long SrcID
		{
			set{ _srcid=value;}
			get{return _srcid;}
		}
		/// <summary>
		/// Article=文章，Comment=评论
		/// </summary>
		public string SrcType
		{
			set{ _srctype=value;}
			get{return _srctype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserIP
		{
			set{ _userip=value;}
			get{return _userip;}
		}
		/// <summary>
		/// 0=顶，1=踩，2=举报
		/// </summary>
		public int? DigType
		{
			set{ _digtype=value;}
			get{return _digtype;}
		}
		#endregion Model

	}


    public enum SrcType
    {
        Article = 0,
        Comment = 1
    }

}

