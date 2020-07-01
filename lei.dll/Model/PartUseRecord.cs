/**  版本信息模板在安装目录下，可自行修改。
* PartUseRecord.cs
*
* 功 能： N/A
* 类 名： PartUseRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/7 10:22:16   N/A    初版
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
	/// PartUseRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PartUseRecord
	{
		public PartUseRecord()
		{}
		#region Model
		private string _partuserecordid;
		private string _partid;
		private string _repairid;
		private string _userid;
		private int? _partusenumber;
		private DateTime? _partusetime;
		/// <summary>
		/// 
		/// </summary>
		public string PartUseRecordID
		{
			set{ _partuserecordid=value;}
			get{return _partuserecordid;}
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
		public string RepairID
		{
			set{ _repairid=value;}
			get{return _repairid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PartUseNumber
		{
			set{ _partusenumber=value;}
			get{return _partusenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PartUseTime
		{
			set{ _partusetime=value;}
			get{return _partusetime;}
		}
		#endregion Model

	}
}

