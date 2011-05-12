using System;
namespace BLPin.Model
{
	/// <summary>
	/// StoryModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class StoryModel
	{
		public StoryModel()
		{}
		#region Model
		private int _storyid;
		private int? _classid;
		private string _title;
		private string _content;
		private string _author;
		private string _source;
		private int? _userid;
		private string _postip;
		private DateTime? _posttime;
		private int? _status;
		private int? _views;
		private int? _comments;
		private int? _reports;
		/// <summary>
		/// 
		/// </summary>
		public int StoryID
		{
			set{ _storyid=value;}
			get{return _storyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// ���⣬��ѡ
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ���ݣ�����
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// ��Դ������дUrl��������
		/// </summary>
		public string Source
		{
			set{ _source=value;}
			get{return _source;}
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
		/// <summary>
		/// -1=������0=δ��ˣ�1=�Ѿ����
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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
		/// ������
		/// </summary>
		public int? Comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		/// <summary>
		/// �ٱ�����
		/// </summary>
		public int? Reports
		{
			set{ _reports=value;}
			get{return _reports;}
		}
		#endregion Model

	}
}

