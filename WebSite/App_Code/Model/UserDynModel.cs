using System;
namespace CengZai.Model
{
	/// <summary>
	/// UserDynModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserDynModel
	{
		public UserDynModel()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private int? _dyntype;
		private string _content;
		private string _postip;
		private DateTime? _posttime;
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
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 动态类型：
		/// </summary>
		public int? DynType
		{
			set{ _dyntype=value;}
			get{return _dyntype;}
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
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		#endregion Model

	}
}

