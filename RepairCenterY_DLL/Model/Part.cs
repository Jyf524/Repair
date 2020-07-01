/**  版本信息模板在安装目录下，可自行修改。
* Part.cs
*
* 功 能： N/A
* 类 名： Part
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 11:05:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Part:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Part
	{
		public Part()
		{}
		#region Model
		private string _partid;
		private string _parttypeid;
		private string _partname;
		private string _partpicture;
		private string _partintroduction;
		private DateTime? _partaddtime;
		private string _as1;
		private string _as2;
		private string _as3;
		private string _as4;
		private string _as5;
		private string _as6;
		/// <summary>
		/// 
		/// </summary>
		public string PartID
		{
			set{ _partid=value;}
			get{return _partid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartTypeID
		{
			set{ _parttypeid=value;}
			get{return _parttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartName
		{
			set{ _partname=value;}
			get{return _partname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartPicture
		{
			set{ _partpicture=value;}
			get{return _partpicture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartIntroduction
		{
			set{ _partintroduction=value;}
			get{return _partintroduction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PartAddTime
		{
			set{ _partaddtime=value;}
			get{return _partaddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string as1
		{
			set{ _as1=value;}
			get{return _as1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string as2
		{
			set{ _as2=value;}
			get{return _as2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string as3
		{
			set{ _as3=value;}
			get{return _as3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string as4
		{
			set{ _as4=value;}
			get{return _as4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string as5
		{
			set{ _as5=value;}
			get{return _as5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string as6
		{
			set{ _as6=value;}
			get{return _as6;}
		}
		#endregion Model

	}
}

