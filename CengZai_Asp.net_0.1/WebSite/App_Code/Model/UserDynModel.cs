using System;
namespace CengZai.Model
{
	/// <summary>
	/// UserDynModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��̬���ͣ�
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

