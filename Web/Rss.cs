using System;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Web;

using Studio.Web;

namespace Studio.Xml
{
	/// <summary>
	/// Rss2.0 XML标准类，用于生成Rss2.0
	/// Author:Foolin
	/// Date：2011.03.04
	/// </summary>
	public class RssBase
	{
		public RssBase(){}

		public RssBase(
			int _BoardID,
			string _Title,
			string _Link,
			string _Description,
			string _Managingeditor,
			string _Generator)
		{
			this.boardid		= _BoardID;
			this.title			= _Title;
			this.link			= _Link;
			this.description	= _Description;
			this.managingeditor	= _Managingeditor;
			this.generator		= _Generator;
			this.rssitems		= new ArrayList();
		}
		
		#region 属性
		private string title;
		public virtual string Title
		{
			get{return title;}
			set{title = value;}
		}

		private string link;
		public virtual string Link
		{
			get{return link;}
			set{link = value;}
		}

		private string description;
		public virtual string Description
		{
			get{return description;}
			set{description = value;}
		}
		
		private string managingeditor;
		public virtual string ManagingEditor
		{
			get{return managingeditor;}
			set{managingeditor = value;}
		}

		private string generator;
		public virtual string Generator
		{
			get{return generator;}
			set{generator = value;}
		}
		
		private ArrayList rssitems;
		public virtual ArrayList RssItems
		{
			get{return rssitems;}
			set{rssitems=value;}
		}
		
		private int boardid;
		public virtual int BoardID
		{
			get{return boardid;}
			set{boardid=value;}
		}
		#endregion
		
		#region 方法
		public virtual void Add(RssItemBase ri)
		{
			rssitems.Add(ri);
		}
		

		public virtual void ToXML(TextWriter tw)
		{
			tw.Write("<?xml version=\"1.0\" encoding=\"gb2312\" ?>\r\n");
			tw.Write("<rss version=\"2.0\">\r\n");
			tw.Write("<channel>\r\n");
			tw.Write("<title>{0}</title>\r\n",this.title);
			tw.Write("<link>{0}</link>\r\n",this.link);
            tw.Write("<description><![CDATA[{0}]]></description>\r\n", this.description);
			tw.Write("<managingEditor>{0}</managingEditor>\r\n",this.managingeditor);
			tw.Write("<generator>{0}</generator>\r\n",this.generator);
			for(int i=0;i<this.rssitems.Count;i++)
			{
				((RssItemBase)rssitems[i]).ToXML(tw);
			}
			tw.Write("</channel>\r\n");
			tw.Write("</rss>\r\n");
			tw.Flush();
			tw.Close();
		}

		public virtual string ToXML()
		{
			return this.ToXML("gb2312");
		}

		public virtual string ToXML(string language)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(string.Format("<?xml version=\"1.0\" encoding=\"{0}\" ?>\r\n",language));
			sb.Append("<rss version=\"2.0\">\r\n");
			sb.Append("<channel>\r\n");
			sb.Append(string.Format("<title>{0}</title>\r\n",this.title));
			sb.Append(string.Format("<link>{0}</link>\r\n",this.link));
            sb.Append(string.Format("<description><![CDATA[{0}]]></description>\r\n", this.description));
			sb.Append(string.Format("<managingEditor>{0}</managingEditor>\r\n",this.managingeditor));
			sb.Append(string.Format("<generator>{0}</generator>\r\n",this.generator));
			for(int i=0;i<this.rssitems.Count;i++)
			{
				sb.Append(((RssItemBase)rssitems[i]).ToXML());
			}
			sb.Append("</channel>\r\n");
			sb.Append("</rss>\r\n");
			return sb.ToString();
		}

		#endregion
	}

	public class RssItemBase
	{
		public RssItemBase(){}

		public RssItemBase(
			string _Title,
			string _Link,
			string _Author,
			DateTime _pubDate,
			string _Guid,
			string _Comments,
			string _Description)
		{
			this.title			= _Title;
			this.link			= _Link;
			this.author			= _Author;
			this.pubDate		= _pubDate;
			this.guid			= _Guid;
			this.comments		= _Comments;
			this.description	= _Description;
		}
		
		#region 属性
		private string title;
		public virtual string Title
		{
			get{return title;}
			set{title = value;}
		}
		private string link;
		public virtual string Link
		{
			get{return link;}
			set{link = value;}
		}
		private string author;
		public virtual string Author
		{
			get{return author;}
			set{author = value;}
		}
		private DateTime pubDate;
		public virtual DateTime PubDate
		{
			get{return pubDate;}
			set{pubDate = value;}
		}
		private string guid;
		public virtual string Guid
		{
			get{return guid;}
			set{guid = value;}
		}
		private string comments;
		public virtual string Comments
		{
			get{return comments;}
			set{comments = value;}
		}
		private string description;
		public virtual string Description
		{
			get{return description;}
			set{description = value;}
		}
		#endregion

		#region 方法
		public virtual void ToXML(TextWriter tw)
		{

			tw.Write("<item>\r\n");
            tw.Write("<title><![CDATA[{0}]]></title>\r\n", this.title);
			tw.Write("<link>{0}</link>\r\n",this.link);
			tw.Write("<author>{0}</author>\r\n",this.author);
			tw.Write("<pubDate>{0}</pubDate>\r\n",this.pubDate);
			tw.Write("<guid>{0}</guid>\r\n",this.guid);
			tw.Write("<comments>{0}</comments>\r\n",this.comments);
			tw.Write("<description><![CDATA[{0}]]></description>\r\n",this.description);
			tw.Write("</item>\r\n");
		}

		public virtual string ToXML()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<item>\r\n");
            sb.Append(string.Format("<title><![CDATA[{0}]]></title>\r\n", this.title));
			sb.Append(string.Format("<link>{0}</link>\r\n",this.link));
			sb.Append(string.Format("<author>{0}</author>\r\n",this.author));
			sb.Append(string.Format("<pubDate>{0}</pubDate>\r\n",this.pubDate));
			sb.Append(string.Format("<guid>{0}</guid>\r\n",this.guid));
			sb.Append(string.Format("<comments>{0}</comments>\r\n",this.comments));
			sb.Append(string.Format("<description><![CDATA[{0}]]></description>\r\n",this.description));
			sb.Append("</item>\r\n");
			return sb.ToString();
		}
		#endregion
	}
}
