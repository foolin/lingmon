using System;
namespace KuaiLe.Us.Model
{
	/// <summary>
	/// TagsModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TagsModel
	{
		public TagsModel()
		{}
		#region Model
		private int _tagid;
		private int? _artid;
		private string _tag;
		/// <summary>
		/// 
		/// </summary>
		public int TagID
		{
			set{ _tagid=value;}
			get{return _tagid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ArtID
		{
			set{ _artid=value;}
			get{return _artid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		#endregion Model

	}
}

