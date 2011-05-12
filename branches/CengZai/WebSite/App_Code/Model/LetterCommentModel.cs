using System;
namespace BLPin.Model
{
	/// <summary>
	/// LetterCommentModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class LetterCommentModel
	{
		public LetterCommentModel()
		{}
		#region Model
		private int _id;
		private int _artid;
		private string _letter;
		private int _userid;
		private string _postip;
		private DateTime _posttime;
		private int? _reports;
		private int? _islock;
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
		public int ArtID
		{
			set{ _artid=value;}
			get{return _artid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Letter
		{
			set{ _letter=value;}
			get{return _letter;}
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
		/// <summary>
		/// 0=������1=����
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

