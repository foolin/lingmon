using System;
namespace CengZai.Model
{
	/// <summary>
	/// TwitterCommentModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TwitterCommentModel
	{
		public TwitterCommentModel()
		{}
		#region Model
		private int _id;
		private int _twitterid;
		private string _content;
		private int _userid;
		private string _postip;
		private DateTime _posttime;
		private int? _reports;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TwitterID
		{
			set{ _twitterid=value;}
			get{return _twitterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Reports
		{
			set{ _reports=value;}
			get{return _reports;}
		}
		#endregion Model

	}
}

