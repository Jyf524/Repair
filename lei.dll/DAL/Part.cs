﻿/**  版本信息模板在安装目录下，可自行修改。
* Part.cs
*
* 功 能： N/A
* 类 名： Part
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/7 10:22:15   N/A    初版
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
	/// 数据访问类:Part
	/// </summary>
	public partial class Part
	{
		public Part()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PartID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Part");
			strSql.Append(" where PartID='"+PartID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Part model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PartID != null)
			{
				strSql1.Append("PartID,");
				strSql2.Append("'"+model.PartID+"',");
			}
			if (model.PartTypeID != null)
			{
				strSql1.Append("PartTypeID,");
				strSql2.Append("'"+model.PartTypeID+"',");
			}
			if (model.PartName != null)
			{
				strSql1.Append("PartName,");
				strSql2.Append("'"+model.PartName+"',");
			}
			if (model.PartModel != null)
			{
				strSql1.Append("PartModel,");
				strSql2.Append("'"+model.PartModel+"',");
			}
			if (model.PartPicture != null)
			{
				strSql1.Append("PartPicture,");
				strSql2.Append("'"+model.PartPicture+"',");
			}
			if (model.PartIntroduction != null)
			{
				strSql1.Append("PartIntroduction,");
				strSql2.Append("'"+model.PartIntroduction+"',");
			}
			if (model.PartStock != null)
			{
				strSql1.Append("PartStock,");
				strSql2.Append(""+model.PartStock+",");
			}
			if (model.PartPrice != null)
			{
				strSql1.Append("PartPrice,");
				strSql2.Append(""+model.PartPrice+",");
			}
			if (model.PartAddTime != null)
			{
				strSql1.Append("PartAddTime,");
				strSql2.Append("'"+model.PartAddTime+"',");
			}
			strSql.Append("insert into Part(");
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
		public bool Update(Maticsoft.Model.Part model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Part set ");
			if (model.PartTypeID != null)
			{
				strSql.Append("PartTypeID='"+model.PartTypeID+"',");
			}
			else
			{
				strSql.Append("PartTypeID= null ,");
			}
			if (model.PartName != null)
			{
				strSql.Append("PartName='"+model.PartName+"',");
			}
			else
			{
				strSql.Append("PartName= null ,");
			}
			if (model.PartModel != null)
			{
				strSql.Append("PartModel='"+model.PartModel+"',");
			}
			else
			{
				strSql.Append("PartModel= null ,");
			}
			if (model.PartPicture != null)
			{
				strSql.Append("PartPicture='"+model.PartPicture+"',");
			}
			else
			{
				strSql.Append("PartPicture= null ,");
			}
			if (model.PartIntroduction != null)
			{
				strSql.Append("PartIntroduction='"+model.PartIntroduction+"',");
			}
			else
			{
				strSql.Append("PartIntroduction= null ,");
			}
			if (model.PartStock != null)
			{
				strSql.Append("PartStock="+model.PartStock+",");
			}
			else
			{
				strSql.Append("PartStock= null ,");
			}
			if (model.PartPrice != null)
			{
				strSql.Append("PartPrice="+model.PartPrice+",");
			}
			else
			{
				strSql.Append("PartPrice= null ,");
			}
			if (model.PartAddTime != null)
			{
				strSql.Append("PartAddTime='"+model.PartAddTime+"',");
			}
			else
			{
				strSql.Append("PartAddTime= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where PartID='"+ model.PartID+"' ");
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
		public bool Delete(string PartID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Part ");
			strSql.Append(" where PartID='"+PartID+"' " );
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
		public bool DeleteList(string PartIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Part ");
			strSql.Append(" where PartID in ("+PartIDlist + ")  ");
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
		public Maticsoft.Model.Part GetModel(string PartID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" PartID,PartTypeID,PartName,PartModel,PartPicture,PartIntroduction,PartStock,PartPrice,PartAddTime ");
			strSql.Append(" from Part ");
			strSql.Append(" where PartID='"+PartID+"' " );
			Maticsoft.Model.Part model=new Maticsoft.Model.Part();
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
		public Maticsoft.Model.Part DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Part model=new Maticsoft.Model.Part();
			if (row != null)
			{
				if(row["PartID"]!=null)
				{
					model.PartID=row["PartID"].ToString();
				}
				if(row["PartTypeID"]!=null)
				{
					model.PartTypeID=row["PartTypeID"].ToString();
				}
				if(row["PartName"]!=null)
				{
					model.PartName=row["PartName"].ToString();
				}
				if(row["PartModel"]!=null)
				{
					model.PartModel=row["PartModel"].ToString();
				}
				if(row["PartPicture"]!=null)
				{
					model.PartPicture=row["PartPicture"].ToString();
				}
				if(row["PartIntroduction"]!=null)
				{
					model.PartIntroduction=row["PartIntroduction"].ToString();
				}
				if(row["PartStock"]!=null && row["PartStock"].ToString()!="")
				{
					model.PartStock=int.Parse(row["PartStock"].ToString());
				}
				if(row["PartPrice"]!=null && row["PartPrice"].ToString()!="")
				{
					model.PartPrice=decimal.Parse(row["PartPrice"].ToString());
				}
				if(row["PartAddTime"]!=null && row["PartAddTime"].ToString()!="")
				{
					model.PartAddTime=DateTime.Parse(row["PartAddTime"].ToString());
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
			strSql.Append("select PartID,PartTypeID,PartName,PartModel,PartPicture,PartIntroduction,PartStock,PartPrice,PartAddTime ");
			strSql.Append(" FROM Part ");
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
			strSql.Append(" PartID,PartTypeID,PartName,PartModel,PartPicture,PartIntroduction,PartStock,PartPrice,PartAddTime ");
			strSql.Append(" FROM Part ");
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
			strSql.Append("select count(1) FROM Part ");
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
				strSql.Append("order by T.PartID desc");
			}
			strSql.Append(")AS Row, T.*  from Part T ");
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

