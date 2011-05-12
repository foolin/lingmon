using System;
namespace BLPin.Model
{
	/// <summary>
	/// BlogModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BlogModel
	{
		public BlogModel()
		{}
		#region Model
		private int _blogid;
		private string _blog;
		private string _blogname;
		private string _blogdesc;
		private int? _privacy;
		private DateTime? _createtime;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int BlogID
		{
			set{ _blogid=value;}
			get{return _blogid;}
		}
		/// <summary>
		/// 博客标识
		/// </summary>
		public string Blog
		{
			set{ _blog=value;}
			get{return _blog;}
		}
		/// <summary>
		/// 博客名称
		/// </summary>
		public string BlogName
		{
			set{ _blogname=value;}
			get{return _blogname;}
		}
		/// <summary>
		/// 博客描述
		/// </summary>
		public string BlogDesc
		{
			set{ _blogdesc=value;}
			get{return _blogdesc;}
		}
		/// <summary>
		/// 0=仅自己看，1=好友可见，2=本站注册用户可见，3=任何人可见
		/// </summary>
		public int? Privacy
		{
			set{ _privacy=value;}
			get{return _privacy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 0=正常，1=认证，-1=冻结
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

