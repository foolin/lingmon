using System;
namespace CengZai.Model
{
	/// <summary>
	/// WikiModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WikiModel
	{
		public WikiModel()
		{}
		#region Model
		private int _wikiid;
		private string _word;
		private int? _verid;
		private int? _views;
		private int? _edits;
		private int? _createuserid;
		private DateTime? _createtime;
		private int? _updateuserid;
		private DateTime? _updatetime;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int WikiID
		{
			set{ _wikiid=value;}
			get{return _wikiid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Word
		{
			set{ _word=value;}
			get{return _word;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VerID
		{
			set{ _verid=value;}
			get{return _verid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Views
		{
			set{ _views=value;}
			get{return _views;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Edits
		{
			set{ _edits=value;}
			get{return _edits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUserID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
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
		/// 
		/// </summary>
		public int? UpdateUserID
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

