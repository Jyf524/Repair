/**  版本信息模板在安装目录下，可自行修改。
* MachineFatherType.cs
*
* 功 能： N/A
* 类 名： MachineFatherType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 10:34:30   N/A    初版
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
	/// MachineFatherType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MachineFatherType
	{
		public MachineFatherType()
		{}
		#region Model
		private string _machinefatherid;
		private string _machinefathername;
		private DateTime? _machinefatheraddtime;
		private string _machinefatherpicture;
		private string _machinefatherintroduction;
		private string _ddd1;
		private string _ddd2;
		private string _ddd3;
		private string _ddd4;
		private string _ddd5;
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
		public string MachineFatherName
		{
			set{ _machinefathername=value;}
			get{return _machinefathername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MachineFatherAddTime
		{
			set{ _machinefatheraddtime=value;}
			get{return _machinefatheraddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineFatherPicture
		{
			set{ _machinefatherpicture=value;}
			get{return _machinefatherpicture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineFatherIntroduction
		{
			set{ _machinefatherintroduction=value;}
			get{return _machinefatherintroduction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DDD1
		{
			set{ _ddd1=value;}
			get{return _ddd1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DDD2
		{
			set{ _ddd2=value;}
			get{return _ddd2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DDD3
		{
			set{ _ddd3=value;}
			get{return _ddd3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DDD4
		{
			set{ _ddd4=value;}
			get{return _ddd4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DDD5
		{
			set{ _ddd5=value;}
			get{return _ddd5;}
		}
		#endregion Model

	}
}

