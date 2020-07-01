/**  版本信息模板在安装目录下，可自行修改。
* UnitsInfo.cs
*
* 功 能： N/A
* 类 名： UnitsInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 11:05:37   N/A    初版
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
	/// UnitsInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UnitsInfo
	{
		public UnitsInfo()
		{}
		#region Model
		private string _unitid;
		private string _unitname;
		private string _unitcode;
		private string _unitphone;
		private string _unitprovince;
		private string _unitcity;
		private string _unitaddress;
		private string _unituserid;
        private DateTime? _AddTime;
		
		private string _bbb2;
		private string _bbb3;
		private string _bbb4;
		private string _bbb5;
		/// <summary>
		/// 
		/// </summary>
		public string UnitID
		{
			set{ _unitid=value;}
			get{return _unitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitName
		{
			set{ _unitname=value;}
			get{return _unitname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitCode
		{
			set{ _unitcode=value;}
			get{return _unitcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitPhone
		{
			set{ _unitphone=value;}
			get{return _unitphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unitprovince
		{
			set{ _unitprovince=value;}
			get{return _unitprovince;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitCity
		{
			set{ _unitcity=value;}
			get{return _unitcity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitAddress
		{
			set{ _unitaddress=value;}
			get{return _unitaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitUserID
		{
			set{ _unituserid=value;}
			get{return _unituserid;}
		}
		/// <summary>
		/// 
		/// </summary>
        /// 
        public DateTime? AddTime
		{
            set { _AddTime = value; }
            get { return _AddTime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string BBB2
		{
			set{ _bbb2=value;}
			get{return _bbb2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BBB3
		{
			set{ _bbb3=value;}
			get{return _bbb3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BBB4
		{
			set{ _bbb4=value;}
			get{return _bbb4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BBB5
		{
			set{ _bbb5=value;}
			get{return _bbb5;}
		}
		#endregion Model

	}
}

