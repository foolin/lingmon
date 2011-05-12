using System;
namespace BLPin.Model
{
	/// <summary>
	/// StoryClassModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StoryClassModel
	{
		public StoryClassModel()
		{}
		#region Model
		private int _classid;
		private int? _parentid;
		private string _classname;
		private string _classdesc;
		/// <summary>
		/// 
		/// </summary>
		public int ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClassDesc
		{
			set{ _classdesc=value;}
			get{return _classdesc;}
		}
		#endregion Model

	}
}

