/**  版本信息模板在安装目录下，可自行修改。
* Part.cs
*
* 功 能： N/A
* 类 名： Part
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
		private string _partmodel;
		private string _partpicture;
		private string _partintroduction;
		private int? _partstock;
		private decimal? _partprice;
		private DateTime? _partaddtime;
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
		public string PartModel
		{
			set{ _partmodel=value;}
			get{return _partmodel;}
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
		public int? PartStock
		{
			set{ _partstock=value;}
			get{return _partstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PartPrice
		{
			set{ _partprice=value;}
			get{return _partprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PartAddTime
		{
			set{ _partaddtime=value;}
			get{return _partaddtime;}
		}
		#endregion Model

	}
}

