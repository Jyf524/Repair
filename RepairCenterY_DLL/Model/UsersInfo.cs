/**  版本信息模板在安装目录下，可自行修改。
* UsersInfo.cs
*
* 功 能： N/A
* 类 名： UsersInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 11:05:38   N/A    初版
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
	/// UsersInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UsersInfo
	{
		public UsersInfo()
		{}
		#region Model
		private string _userid;
		private string _unitid;
		private string _username;
		private string _userpassword;
		private string _userrealname;
		private string _usersex;
		private string _useremail;
		private string _userprovince;
		private string _usercity;
		private string _userbirthday;
		private string _userphone;
		private string _useraddress;
		private string _useridentity;
		private string _useraddtime;
		private string _HeadPortrait;
		private string _Enabled;
		private string _aaa4;
		private string _aaa5;
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
		public string UnitID
		{
			set{ _unitid=value;}
			get{return _unitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserRealName
		{
			set{ _userrealname=value;}
			get{return _userrealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserSex
		{
			set{ _usersex=value;}
			get{return _usersex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserEmail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserProvince
		{
			set{ _userprovince=value;}
			get{return _userprovince;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserCity
		{
			set{ _usercity=value;}
			get{return _usercity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserBirthday
		{
			set{ _userbirthday=value;}
			get{return _userbirthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPhone
		{
			set{ _userphone=value;}
			get{return _userphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserAddress
		{
			set{ _useraddress=value;}
			get{return _useraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserIdentity
		{
			set{ _useridentity=value;}
			get{return _useridentity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserAddTime
		{
			set{ _useraddtime=value;}
			get{return _useraddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HeadPortrait
		{
			set{ _HeadPortrait=value;}
			get{return _HeadPortrait;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Enabled
		{
			set{ _Enabled=value;}
			get{return _Enabled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AAA4
		{
			set{ _aaa4=value;}
			get{return _aaa4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AAA5
		{
			set{ _aaa5=value;}
			get{return _aaa5;}
		}
		#endregion Model

	}
}

