/**  版本信息模板在安装目录下，可自行修改。
* PartPutRecord.cs
*
* 功 能： N/A
* 类 名： PartPutRecord
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
	/// PartPutRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PartPutRecord
	{
		public PartPutRecord()
		{}
		#region Model
		private string _partputrecordid;
		private string _partid;
		private int? _partputnumber;
		private string _partmodel;
		private string _partpicture;
		private string _partsource;
		private decimal? _partprice;
		private DateTime? _partputtime;
		private string _yyy1;
		private string _yyy2;
		private string _yyy3;
		private string _yyy4;
		private string _yyy15;
		/// <summary>
		/// 
		/// </summary>
		public string PartPutRecordID
		{
			set{ _partputrecordid=value;}
			get{return _partputrecordid;}
		}
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
		public int? PartPutNumber
		{
			set{ _partputnumber=value;}
			get{return _partputnumber;}
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
		public string PartSource
		{
			set{ _partsource=value;}
			get{return _partsource;}
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
		public DateTime? PartPutTime
		{
			set{ _partputtime=value;}
			get{return _partputtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yyy1
		{
			set{ _yyy1=value;}
			get{return _yyy1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yyy2
		{
			set{ _yyy2=value;}
			get{return _yyy2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yyy3
		{
			set{ _yyy3=value;}
			get{return _yyy3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yyy4
		{
			set{ _yyy4=value;}
			get{return _yyy4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yyy15
		{
			set{ _yyy15=value;}
			get{return _yyy15;}
		}
		#endregion Model

	}
}

