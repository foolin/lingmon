using System;
namespace BLPin.Model
{
	/// <summary>
	/// BlogModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ���ͱ�ʶ
		/// </summary>
		public string Blog
		{
			set{ _blog=value;}
			get{return _blog;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string BlogName
		{
			set{ _blogname=value;}
			get{return _blogname;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string BlogDesc
		{
			set{ _blogdesc=value;}
			get{return _blogdesc;}
		}
		/// <summary>
		/// 0=���Լ�����1=���ѿɼ���2=��վע���û��ɼ���3=�κ��˿ɼ�
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
		/// 0=������1=��֤��-1=����
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

