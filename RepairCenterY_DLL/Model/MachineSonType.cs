/**  版本信息模板在安装目录下，可自行修改。
* MachineSonType.cs
*
* 功 能： N/A
* 类 名： MachineSonType
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
	/// MachineSonType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MachineSonType
	{
		public MachineSonType()
		{}
		#region Model
		private string _machinesonid;
		private string _machinefatherid;
		private string _machinesonname;
		private DateTime? _machinesonaddtime;
		private string _machinesonpicture;
		private string _machinesonintroduction;
		private string _eee1;
		private string _eee2;
		private string _eee3;
		private string _eee4;
		private string _eee5;
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
		public string MachineFatherID
		{
			set{ _machinefatherid=value;}
			get{return _machinefatherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineSonName
		{
			set{ _machinesonname=value;}
			get{return _machinesonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MachineSonAddTime
		{
			set{ _machinesonaddtime=value;}
			get{return _machinesonaddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineSonPicture
		{
			set{ _machinesonpicture=value;}
			get{return _machinesonpicture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineSonIntroduction
		{
			set{ _machinesonintroduction=value;}
			get{return _machinesonintroduction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EEE1
		{
			set{ _eee1=value;}
			get{return _eee1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EEE2
		{
			set{ _eee2=value;}
			get{return _eee2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EEE3
		{
			set{ _eee3=value;}
			get{return _eee3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EEE4
		{
			set{ _eee4=value;}
			get{return _eee4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EEE5
		{
			set{ _eee5=value;}
			get{return _eee5;}
		}
		#endregion Model

	}
}

