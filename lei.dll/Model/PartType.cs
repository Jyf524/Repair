/**  版本信息模板在安装目录下，可自行修改。
* PartType.cs
*
* 功 能： N/A
* 类 名： PartType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/7 10:22:15   N/A    初版
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
	/// PartType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PartType
	{
		public PartType()
		{}
		#region Model
		private string _parttypeid;
		private string _parttypename;
		private DateTime? _parttypeaddtime;
		private string _parttypepicture;
		private string _parttypeintroduction;
		private string _hhh1;
		private string _hhh2;
		private string _hhh3;
		private string _hhh4;
		private string _hhh5;
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
		public string PartTypeName
		{
			set{ _parttypename=value;}
			get{return _parttypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PartTypeAddTime
		{
			set{ _parttypeaddtime=value;}
			get{return _parttypeaddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartTypePicture
		{
			set{ _parttypepicture=value;}
			get{return _parttypepicture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartTypeIntroduction
		{
			set{ _parttypeintroduction=value;}
			get{return _parttypeintroduction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HHH1
		{
			set{ _hhh1=value;}
			get{return _hhh1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HHH2
		{
			set{ _hhh2=value;}
			get{return _hhh2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HHH3
		{
			set{ _hhh3=value;}
			get{return _hhh3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HHH4
		{
			set{ _hhh4=value;}
			get{return _hhh4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HHH5
		{
			set{ _hhh5=value;}
			get{return _hhh5;}
		}
		#endregion Model

	}
}

