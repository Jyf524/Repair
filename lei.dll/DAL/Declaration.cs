/**  版本信息模板在安装目录下，可自行修改。
* Declaration.cs
*
* 功 能： N/A
* 类 名： Declaration
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/7 10:22:14   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Declaration
	/// </summary>
	public partial class Declaration
	{
		public Declaration()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DeclarationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Declaration");
			strSql.Append(" where DeclarationID='"+DeclarationID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Declaration model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.DeclarationID != null)
			{
				strSql1.Append("DeclarationID,");
				strSql2.Append("'"+model.DeclarationID+"',");
			}
			if (model.UserID != null)
			{
				strSql1.Append("UserID,");
				strSql2.Append("'"+model.UserID+"',");
			}
			if (model.RepairerID != null)
			{
				strSql1.Append("RepairerID,");
				strSql2.Append("'"+model.RepairerID+"',");
			}
			if (model.ListID != null)
			{
				strSql1.Append("ListID,");
				strSql2.Append("'"+model.ListID+"',");
			}
			if (model.MachineName != null)
			{
				strSql1.Append("MachineName,");
				strSql2.Append("'"+model.MachineName+"',");
			}
			if (model.DeclarationState != null)
			{
				strSql1.Append("DeclarationState,");
				strSql2.Append("'"+model.DeclarationState+"',");
			}
			if (model.AssetsID != null)
			{
				strSql1.Append("AssetsID,");
				strSql2.Append("'"+model.AssetsID+"',");
			}
			if (model.Model != null)
			{
				strSql1.Append("Model,");
				strSql2.Append("'"+model.Model+"',");
			}
			if (model.OtherPart != null)
			{
				strSql1.Append("OtherPart,");
				strSql2.Append("'"+model.OtherPart+"',");
			}
			if (model.BreakDown != null)
			{
				strSql1.Append("BreakDown,");
				strSql2.Append("'"+model.BreakDown+"',");
			}
			if (model.ReplacementUse != null)
			{
				strSql1.Append("ReplacementUse,");
				strSql2.Append("'"+model.ReplacementUse+"',");
			}
			if (model.ReplacementID != null)
			{
				strSql1.Append("ReplacementID,");
				strSql2.Append("'"+model.ReplacementID+"',");
			}
			if (model.UnitName != null)
			{
				strSql1.Append("UnitName,");
				strSql2.Append("'"+model.UnitName+"',");
			}
			if (model.RepairTime != null)
			{
				strSql1.Append("RepairTime,");
				strSql2.Append("'"+model.RepairTime+"',");
			}
			if (model.Contact != null)
			{
				strSql1.Append("Contact,");
				strSql2.Append("'"+model.Contact+"',");
			}
			if (model.ContactPhone != null)
			{
				strSql1.Append("ContactPhone,");
				strSql2.Append("'"+model.ContactPhone+"',");
			}
			if (model.DoorServer != null)
			{
				strSql1.Append("DoorServer,");
				strSql2.Append("'"+model.DoorServer+"',");
			}
			if (model.BeyondRepairDate != null)
			{
				strSql1.Append("BeyondRepairDate,");
				strSql2.Append("'"+model.BeyondRepairDate+"',");
			}
			if (model.DeviceDescription != null)
			{
				strSql1.Append("DeviceDescription,");
				strSql2.Append("'"+model.DeviceDescription+"',");
			}
			if (model.EstimateTime != null)
			{
				strSql1.Append("EstimateTime,");
				strSql2.Append("'"+model.EstimateTime+"',");
			}
			if (model.FaultPrediction != null)
			{
				strSql1.Append("FaultPrediction,");
				strSql2.Append("'"+model.FaultPrediction+"',");
			}
			if (model.RepairTreatment != null)
			{
				strSql1.Append("RepairTreatment,");
				strSql2.Append("'"+model.RepairTreatment+"',");
			}
			if (model.RepairerName != null)
			{
				strSql1.Append("RepairerName,");
				strSql2.Append("'"+model.RepairerName+"',");
			}
			if (model.TeacherName != null)
			{
				strSql1.Append("TeacherName,");
				strSql2.Append("'"+model.TeacherName+"',");
			}
			if (model.TeacherID != null)
			{
				strSql1.Append("TeacherID,");
				strSql2.Append("'"+model.TeacherID+"',");
			}
			if (model.RepairPlan != null)
			{
				strSql1.Append("RepairPlan,");
				strSql2.Append("'"+model.RepairPlan+"',");
			}
			if (model.PartSource != null)
			{
				strSql1.Append("PartSource,");
				strSql2.Append("'"+model.PartSource+"',");
			}
			if (model.PartPrice != null)
			{
				strSql1.Append("PartPrice,");
				strSql2.Append("'"+model.PartPrice+"',");
			}
			if (model.ArrivalTime != null)
			{
				strSql1.Append("ArrivalTime,");
				strSql2.Append("'"+model.ArrivalTime+"',");
			}
			if (model.Result != null)
			{
				strSql1.Append("Result,");
				strSql2.Append("'"+model.Result+"',");
			}
			if (model.ResultTime != null)
			{
				strSql1.Append("ResultTime,");
				strSql2.Append("'"+model.ResultTime+"',");
			}
			if (model.RepairPrice != null)
			{
				strSql1.Append("RepairPrice,");
				strSql2.Append(""+model.RepairPrice+",");
			}
			if (model.PersonMoney != null)
			{
				strSql1.Append("PersonMoney,");
				strSql2.Append(""+model.PersonMoney+",");
			}
			if (model.ActualMoney != null)
			{
				strSql1.Append("ActualMoney,");
				strSql2.Append(""+model.ActualMoney+",");
			}
			if (model.CCC1 != null)
			{
				strSql1.Append("CCC1,");
				strSql2.Append("'"+model.CCC1+"',");
			}
			if (model.CCC2 != null)
			{
				strSql1.Append("CCC2,");
				strSql2.Append("'"+model.CCC2+"',");
			}
			if (model.CCC3 != null)
			{
				strSql1.Append("CCC3,");
				strSql2.Append("'"+model.CCC3+"',");
			}
			if (model.CCC4 != null)
			{
				strSql1.Append("CCC4,");
				strSql2.Append("'"+model.CCC4+"',");
			}
			if (model.CCC5 != null)
			{
				strSql1.Append("CCC5,");
				strSql2.Append("'"+model.CCC5+"',");
			}
			strSql.Append("insert into Declaration(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Declaration model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Declaration set ");
			if (model.UserID != null)
			{
				strSql.Append("UserID='"+model.UserID+"',");
			}
			else
			{
				strSql.Append("UserID= null ,");
			}
			if (model.RepairerID != null)
			{
				strSql.Append("RepairerID='"+model.RepairerID+"',");
			}
			else
			{
				strSql.Append("RepairerID= null ,");
			}
			if (model.ListID != null)
			{
				strSql.Append("ListID='"+model.ListID+"',");
			}
			else
			{
				strSql.Append("ListID= null ,");
			}
			if (model.MachineName != null)
			{
				strSql.Append("MachineName='"+model.MachineName+"',");
			}
			else
			{
				strSql.Append("MachineName= null ,");
			}
			if (model.DeclarationState != null)
			{
				strSql.Append("DeclarationState='"+model.DeclarationState+"',");
			}
			else
			{
				strSql.Append("DeclarationState= null ,");
			}
			if (model.AssetsID != null)
			{
				strSql.Append("AssetsID='"+model.AssetsID+"',");
			}
			else
			{
				strSql.Append("AssetsID= null ,");
			}
			if (model.Model != null)
			{
				strSql.Append("Model='"+model.Model+"',");
			}
			else
			{
				strSql.Append("Model= null ,");
			}
			if (model.OtherPart != null)
			{
				strSql.Append("OtherPart='"+model.OtherPart+"',");
			}
			else
			{
				strSql.Append("OtherPart= null ,");
			}
			if (model.BreakDown != null)
			{
				strSql.Append("BreakDown='"+model.BreakDown+"',");
			}
			else
			{
				strSql.Append("BreakDown= null ,");
			}
			if (model.ReplacementUse != null)
			{
				strSql.Append("ReplacementUse='"+model.ReplacementUse+"',");
			}
			else
			{
				strSql.Append("ReplacementUse= null ,");
			}
			if (model.ReplacementID != null)
			{
				strSql.Append("ReplacementID='"+model.ReplacementID+"',");
			}
			else
			{
				strSql.Append("ReplacementID= null ,");
			}
			if (model.UnitName != null)
			{
				strSql.Append("UnitName='"+model.UnitName+"',");
			}
			else
			{
				strSql.Append("UnitName= null ,");
			}
			if (model.RepairTime != null)
			{
				strSql.Append("RepairTime='"+model.RepairTime+"',");
			}
			else
			{
				strSql.Append("RepairTime= null ,");
			}
			if (model.Contact != null)
			{
				strSql.Append("Contact='"+model.Contact+"',");
			}
			else
			{
				strSql.Append("Contact= null ,");
			}
			if (model.ContactPhone != null)
			{
				strSql.Append("ContactPhone='"+model.ContactPhone+"',");
			}
			else
			{
				strSql.Append("ContactPhone= null ,");
			}
			if (model.DoorServer != null)
			{
				strSql.Append("DoorServer='"+model.DoorServer+"',");
			}
			else
			{
				strSql.Append("DoorServer= null ,");
			}
			if (model.BeyondRepairDate != null)
			{
				strSql.Append("BeyondRepairDate='"+model.BeyondRepairDate+"',");
			}
			else
			{
				strSql.Append("BeyondRepairDate= null ,");
			}
			if (model.DeviceDescription != null)
			{
				strSql.Append("DeviceDescription='"+model.DeviceDescription+"',");
			}
			else
			{
				strSql.Append("DeviceDescription= null ,");
			}
			if (model.EstimateTime != null)
			{
				strSql.Append("EstimateTime='"+model.EstimateTime+"',");
			}
			else
			{
				strSql.Append("EstimateTime= null ,");
			}
			if (model.FaultPrediction != null)
			{
				strSql.Append("FaultPrediction='"+model.FaultPrediction+"',");
			}
			else
			{
				strSql.Append("FaultPrediction= null ,");
			}
			if (model.RepairTreatment != null)
			{
				strSql.Append("RepairTreatment='"+model.RepairTreatment+"',");
			}
			else
			{
				strSql.Append("RepairTreatment= null ,");
			}
			if (model.RepairerName != null)
			{
				strSql.Append("RepairerName='"+model.RepairerName+"',");
			}
			else
			{
				strSql.Append("RepairerName= null ,");
			}
			if (model.TeacherName != null)
			{
				strSql.Append("TeacherName='"+model.TeacherName+"',");
			}
			else
			{
				strSql.Append("TeacherName= null ,");
			}
			if (model.TeacherID != null)
			{
				strSql.Append("TeacherID='"+model.TeacherID+"',");
			}
			else
			{
				strSql.Append("TeacherID= null ,");
			}
			if (model.RepairPlan != null)
			{
				strSql.Append("RepairPlan='"+model.RepairPlan+"',");
			}
			else
			{
				strSql.Append("RepairPlan= null ,");
			}
			if (model.PartSource != null)
			{
				strSql.Append("PartSource='"+model.PartSource+"',");
			}
			else
			{
				strSql.Append("PartSource= null ,");
			}
			if (model.PartPrice != null)
			{
				strSql.Append("PartPrice='"+model.PartPrice+"',");
			}
			else
			{
				strSql.Append("PartPrice= null ,");
			}
			if (model.ArrivalTime != null)
			{
				strSql.Append("ArrivalTime='"+model.ArrivalTime+"',");
			}
			else
			{
				strSql.Append("ArrivalTime= null ,");
			}
			if (model.Result != null)
			{
				strSql.Append("Result='"+model.Result+"',");
			}
			else
			{
				strSql.Append("Result= null ,");
			}
			if (model.ResultTime != null)
			{
				strSql.Append("ResultTime='"+model.ResultTime+"',");
			}
			else
			{
				strSql.Append("ResultTime= null ,");
			}
			if (model.RepairPrice != null)
			{
				strSql.Append("RepairPrice="+model.RepairPrice+",");
			}
			else
			{
				strSql.Append("RepairPrice= null ,");
			}
			if (model.PersonMoney != null)
			{
				strSql.Append("PersonMoney="+model.PersonMoney+",");
			}
			else
			{
				strSql.Append("PersonMoney= null ,");
			}
			if (model.ActualMoney != null)
			{
				strSql.Append("ActualMoney="+model.ActualMoney+",");
			}
			else
			{
				strSql.Append("ActualMoney= null ,");
			}
			if (model.CCC1 != null)
			{
				strSql.Append("CCC1='"+model.CCC1+"',");
			}
			else
			{
				strSql.Append("CCC1= null ,");
			}
			if (model.CCC2 != null)
			{
				strSql.Append("CCC2='"+model.CCC2+"',");
			}
			else
			{
				strSql.Append("CCC2= null ,");
			}
			if (model.CCC3 != null)
			{
				strSql.Append("CCC3='"+model.CCC3+"',");
			}
			else
			{
				strSql.Append("CCC3= null ,");
			}
			if (model.CCC4 != null)
			{
				strSql.Append("CCC4='"+model.CCC4+"',");
			}
			else
			{
				strSql.Append("CCC4= null ,");
			}
			if (model.CCC5 != null)
			{
				strSql.Append("CCC5='"+model.CCC5+"',");
			}
			else
			{
				strSql.Append("CCC5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where DeclarationID='"+ model.DeclarationID+"' ");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DeclarationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Declaration ");
			strSql.Append(" where DeclarationID='"+DeclarationID+"' " );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string DeclarationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Declaration ");
			strSql.Append(" where DeclarationID in ("+DeclarationIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Declaration GetModel(string DeclarationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" DeclarationID,UserID,RepairerID,ListID,MachineName,DeclarationState,AssetsID,Model,OtherPart,BreakDown,ReplacementUse,ReplacementID,UnitName,RepairTime,Contact,ContactPhone,DoorServer,BeyondRepairDate,DeviceDescription,EstimateTime,FaultPrediction,RepairTreatment,RepairerName,TeacherName,TeacherID,RepairPlan,PartSource,PartPrice,ArrivalTime,Result,ResultTime,RepairPrice,PersonMoney,ActualMoney,CCC1,CCC2,CCC3,CCC4,CCC5 ");
			strSql.Append(" from Declaration ");
			strSql.Append(" where DeclarationID='"+DeclarationID+"' " );
			Maticsoft.Model.Declaration model=new Maticsoft.Model.Declaration();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Declaration DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Declaration model=new Maticsoft.Model.Declaration();
			if (row != null)
			{
				if(row["DeclarationID"]!=null)
				{
					model.DeclarationID=row["DeclarationID"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["RepairerID"]!=null)
				{
					model.RepairerID=row["RepairerID"].ToString();
				}
				if(row["ListID"]!=null)
				{
					model.ListID=row["ListID"].ToString();
				}
				if(row["MachineName"]!=null)
				{
					model.MachineName=row["MachineName"].ToString();
				}
				if(row["DeclarationState"]!=null)
				{
					model.DeclarationState=row["DeclarationState"].ToString();
				}
				if(row["AssetsID"]!=null)
				{
					model.AssetsID=row["AssetsID"].ToString();
				}
				if(row["Model"]!=null)
				{
					model.Model=row["Model"].ToString();
				}
				if(row["OtherPart"]!=null)
				{
					model.OtherPart=row["OtherPart"].ToString();
				}
				if(row["BreakDown"]!=null)
				{
					model.BreakDown=row["BreakDown"].ToString();
				}
				if(row["ReplacementUse"]!=null)
				{
					model.ReplacementUse=row["ReplacementUse"].ToString();
				}
				if(row["ReplacementID"]!=null)
				{
					model.ReplacementID=row["ReplacementID"].ToString();
				}
				if(row["UnitName"]!=null)
				{
					model.UnitName=row["UnitName"].ToString();
				}
				if(row["RepairTime"]!=null && row["RepairTime"].ToString()!="")
				{
					model.RepairTime=DateTime.Parse(row["RepairTime"].ToString());
				}
				if(row["Contact"]!=null)
				{
					model.Contact=row["Contact"].ToString();
				}
				if(row["ContactPhone"]!=null)
				{
					model.ContactPhone=row["ContactPhone"].ToString();
				}
				if(row["DoorServer"]!=null)
				{
					model.DoorServer=row["DoorServer"].ToString();
				}
				if(row["BeyondRepairDate"]!=null)
				{
					model.BeyondRepairDate=row["BeyondRepairDate"].ToString();
				}
				if(row["DeviceDescription"]!=null)
				{
					model.DeviceDescription=row["DeviceDescription"].ToString();
				}
				if(row["EstimateTime"]!=null && row["EstimateTime"].ToString()!="")
				{
					model.EstimateTime=DateTime.Parse(row["EstimateTime"].ToString());
				}
				if(row["FaultPrediction"]!=null)
				{
					model.FaultPrediction=row["FaultPrediction"].ToString();
				}
				if(row["RepairTreatment"]!=null)
				{
					model.RepairTreatment=row["RepairTreatment"].ToString();
				}
				if(row["RepairerName"]!=null)
				{
					model.RepairerName=row["RepairerName"].ToString();
				}
				if(row["TeacherName"]!=null)
				{
					model.TeacherName=row["TeacherName"].ToString();
				}
				if(row["TeacherID"]!=null)
				{
					model.TeacherID=row["TeacherID"].ToString();
				}
				if(row["RepairPlan"]!=null)
				{
					model.RepairPlan=row["RepairPlan"].ToString();
				}
				if(row["PartSource"]!=null)
				{
					model.PartSource=row["PartSource"].ToString();
				}
				if(row["PartPrice"]!=null)
				{
					model.PartPrice=row["PartPrice"].ToString();
				}
				if(row["ArrivalTime"]!=null && row["ArrivalTime"].ToString()!="")
				{
					model.ArrivalTime=DateTime.Parse(row["ArrivalTime"].ToString());
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["ResultTime"]!=null && row["ResultTime"].ToString()!="")
				{
					model.ResultTime=DateTime.Parse(row["ResultTime"].ToString());
				}
				if(row["RepairPrice"]!=null && row["RepairPrice"].ToString()!="")
				{
					model.RepairPrice=decimal.Parse(row["RepairPrice"].ToString());
				}
				if(row["PersonMoney"]!=null && row["PersonMoney"].ToString()!="")
				{
					model.PersonMoney=decimal.Parse(row["PersonMoney"].ToString());
				}
				if(row["ActualMoney"]!=null && row["ActualMoney"].ToString()!="")
				{
					model.ActualMoney=decimal.Parse(row["ActualMoney"].ToString());
				}
				if(row["CCC1"]!=null)
				{
					model.CCC1=row["CCC1"].ToString();
				}
				if(row["CCC2"]!=null)
				{
					model.CCC2=row["CCC2"].ToString();
				}
				if(row["CCC3"]!=null)
				{
					model.CCC3=row["CCC3"].ToString();
				}
				if(row["CCC4"]!=null)
				{
					model.CCC4=row["CCC4"].ToString();
				}
				if(row["CCC5"]!=null)
				{
					model.CCC5=row["CCC5"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DeclarationID,UserID,RepairerID,ListID,MachineName,DeclarationState,AssetsID,Model,OtherPart,BreakDown,ReplacementUse,ReplacementID,UnitName,RepairTime,Contact,ContactPhone,DoorServer,BeyondRepairDate,DeviceDescription,EstimateTime,FaultPrediction,RepairTreatment,RepairerName,TeacherName,TeacherID,RepairPlan,PartSource,PartPrice,ArrivalTime,Result,ResultTime,RepairPrice,PersonMoney,ActualMoney,CCC1,CCC2,CCC3,CCC4,CCC5 ");
			strSql.Append(" FROM Declaration ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" DeclarationID,UserID,RepairerID,ListID,MachineName,DeclarationState,AssetsID,Model,OtherPart,BreakDown,ReplacementUse,ReplacementID,UnitName,RepairTime,Contact,ContactPhone,DoorServer,BeyondRepairDate,DeviceDescription,EstimateTime,FaultPrediction,RepairTreatment,RepairerName,TeacherName,TeacherID,RepairPlan,PartSource,PartPrice,ArrivalTime,Result,ResultTime,RepairPrice,PersonMoney,ActualMoney,CCC1,CCC2,CCC3,CCC4,CCC5 ");
			strSql.Append(" FROM Declaration ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Declaration ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.DeclarationID desc");
			}
			strSql.Append(")AS Row, T.*  from Declaration T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

