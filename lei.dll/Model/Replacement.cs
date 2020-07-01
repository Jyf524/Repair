/**  版本信息模板在安装目录下，可自行修改。
* Replacement.cs
*
* 功 能： N/A
* 类 名： Replacement
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
	/// Replacement:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Replacement
	{
		public Replacement()
		{}
		#region Model
		private string _replacementid;
		private string _machinefatherid;
		private string _machinesonid;
		private string _replacementmodel;
		private string _replacementname;
		private string _replacementstate;
		private string _replacementpicture;
		private DateTime? _replacementaddtime;
		private string _fff1;
		private string _fff2;
		private string _fff3;
		private string _fff4;
		private string _fff5;
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
		public string MachineFatherID
		{
			set{ _machinefatherid=value;}
			get{return _machinefatherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineSonID
		{
			set{ _machinesonid=value;}
			get{return _machinesonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplacementModel
		{
			set{ _replacementmodel=value;}
			get{return _replacementmodel;}
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
		public string ReplacementState
		{
			set{ _replacementstate=value;}
			get{return _replacementstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplacementPicture
		{
			set{ _replacementpicture=value;}
			get{return _replacementpicture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReplacementAddTime
		{
			set{ _replacementaddtime=value;}
			get{return _replacementaddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FFF1
		{
			set{ _fff1=value;}
			get{return _fff1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FFF2
		{
			set{ _fff2=value;}
			get{return _fff2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FFF3
		{
			set{ _fff3=value;}
			get{return _fff3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FFF4
		{
			set{ _fff4=value;}
			get{return _fff4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FFF5
		{
			set{ _fff5=value;}
			get{return _fff5;}
		}
		#endregion Model

	}
}

