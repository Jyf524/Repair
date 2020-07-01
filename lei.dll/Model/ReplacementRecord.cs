/**  版本信息模板在安装目录下，可自行修改。
* ReplacementRecord.cs
*
* 功 能： N/A
* 类 名： ReplacementRecord
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
	/// ReplacementRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ReplacementRecord
	{
		public ReplacementRecord()
		{}
		#region Model
		private string _replacementrecordid;
		private string _replacementid;
		private string _replacementname;
		private DateTime? _replacementlendtime;
		private DateTime? _replacementbacktime;
		private string _userid;
		private string _ggg1;
		private string _ggg2;
		private string _ggg3;
		private string _ggg4;
		private string _ggg5;
		/// <summary>
		/// 
		/// </summary>
		public string ReplacementRecordID
		{
			set{ _replacementrecordid=value;}
			get{return _replacementrecordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplacementID
		{
			set{ _replacementid=value;}
			get{return _replacementid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplacementName
		{
			set{ _replacementname=value;}
			get{return _replacementname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReplacementLendTime
		{
			set{ _replacementlendtime=value;}
			get{return _replacementlendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReplacementBackTime
		{
			set{ _replacementbacktime=value;}
			get{return _replacementbacktime;}
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
		public string GGG1
		{
			set{ _ggg1=value;}
			get{return _ggg1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GGG2
		{
			set{ _ggg2=value;}
			get{return _ggg2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GGG3
		{
			set{ _ggg3=value;}
			get{return _ggg3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GGG4
		{
			set{ _ggg4=value;}
			get{return _ggg4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GGG5
		{
			set{ _ggg5=value;}
			get{return _ggg5;}
		}
		#endregion Model

	}
}

