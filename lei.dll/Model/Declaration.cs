/**  版本信息模板在安装目录下，可自行修改。
* Declaration.cs
*
* 功 能： N/A
* 类 名： Declaration
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/7 10:22:13   N/A    初版
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
	/// Declaration:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Declaration
	{
		public Declaration()
		{}
		#region Model
		private string _declarationid;
		private string _userid;
		private string _repairerid;
		private string _listid;
		private string _machinename;
		private string _declarationstate;
		private string _assetsid;
		private string _model;
		private string _otherpart;
		private string _breakdown;
		private string _replacementuse;
		private string _replacementid;
		private string _unitname;
		private DateTime? _repairtime;
		private string _contact;
		private string _contactphone;
		private string _doorserver;
		private string _beyondrepairdate;
		private string _devicedescription;
		private DateTime? _estimatetime;
		private string _faultprediction;
		private string _repairtreatment;
		private string _repairername;
		private string _teachername;
		private string _teacherid;
		private string _repairplan;
		private string _partsource;
		private string _partprice;
		private DateTime? _arrivaltime;
		private string _result;
		private DateTime? _resulttime;
		private decimal? _repairprice;
		private decimal? _personmoney;
		private decimal? _actualmoney;
		private string _ccc1;
		private string _ccc2;
		private string _ccc3;
		private string _ccc4;
		private string _ccc5;
		/// <summary>
		/// 
		/// </summary>
		public string DeclarationID
		{
			set{ _declarationid=value;}
			get{return _declarationid;}
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
		public string RepairerID
		{
			set{ _repairerid=value;}
			get{return _repairerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ListID
		{
			set{ _listid=value;}
			get{return _listid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineName
		{
			set{ _machinename=value;}
			get{return _machinename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeclarationState
		{
			set{ _declarationstate=value;}
			get{return _declarationstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AssetsID
		{
			set{ _assetsid=value;}
			get{return _assetsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherPart
		{
			set{ _otherpart=value;}
			get{return _otherpart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BreakDown
		{
			set{ _breakdown=value;}
			get{return _breakdown;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplacementUse
		{
			set{ _replacementuse=value;}
			get{return _replacementuse;}
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
		public string UnitName
		{
			set{ _unitname=value;}
			get{return _unitname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RepairTime
		{
			set{ _repairtime=value;}
			get{return _repairtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DoorServer
		{
			set{ _doorserver=value;}
			get{return _doorserver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BeyondRepairDate
		{
			set{ _beyondrepairdate=value;}
			get{return _beyondrepairdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceDescription
		{
			set{ _devicedescription=value;}
			get{return _devicedescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EstimateTime
		{
			set{ _estimatetime=value;}
			get{return _estimatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FaultPrediction
		{
			set{ _faultprediction=value;}
			get{return _faultprediction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RepairTreatment
		{
			set{ _repairtreatment=value;}
			get{return _repairtreatment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RepairerName
		{
			set{ _repairername=value;}
			get{return _repairername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherName
		{
			set{ _teachername=value;}
			get{return _teachername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherID
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RepairPlan
		{
			set{ _repairplan=value;}
			get{return _repairplan;}
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
		public string PartPrice
		{
			set{ _partprice=value;}
			get{return _partprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ArrivalTime
		{
			set{ _arrivaltime=value;}
			get{return _arrivaltime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ResultTime
		{
			set{ _resulttime=value;}
			get{return _resulttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? RepairPrice
		{
			set{ _repairprice=value;}
			get{return _repairprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PersonMoney
		{
			set{ _personmoney=value;}
			get{return _personmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ActualMoney
		{
			set{ _actualmoney=value;}
			get{return _actualmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CCC1
		{
			set{ _ccc1=value;}
			get{return _ccc1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CCC2
		{
			set{ _ccc2=value;}
			get{return _ccc2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CCC3
		{
			set{ _ccc3=value;}
			get{return _ccc3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CCC4
		{
			set{ _ccc4=value;}
			get{return _ccc4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CCC5
		{
			set{ _ccc5=value;}
			get{return _ccc5;}
		}
		#endregion Model

	}
}

