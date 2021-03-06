﻿/**  版本信息模板在安装目录下，可自行修改。
* UsersInfo.cs
*
* 功 能： N/A
* 类 名： UsersInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 10:34:33   N/A    初版
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
	/// 数据访问类:UsersInfo
	/// </summary>
	public partial class UsersInfo
	{
		public UsersInfo()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UsersInfo");
			strSql.Append(" where UserID='"+UserID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.UsersInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.UserID != null)
			{
				strSql1.Append("UserID,");
				strSql2.Append("'"+model.UserID+"',");
			}
			if (model.UnitID != null)
			{
				strSql1.Append("UnitID,");
				strSql2.Append("'"+model.UnitID+"',");
			}
			if (model.UserName != null)
			{
				strSql1.Append("UserName,");
				strSql2.Append("'"+model.UserName+"',");
			}
			if (model.UserPassword != null)
			{
				strSql1.Append("UserPassword,");
				strSql2.Append("'"+model.UserPassword+"',");
			}
			if (model.UserRealName != null)
			{
				strSql1.Append("UserRealName,");
				strSql2.Append("'"+model.UserRealName+"',");
			}
			if (model.UserSex != null)
			{
				strSql1.Append("UserSex,");
				strSql2.Append("'"+model.UserSex+"',");
			}
			if (model.UserEmail != null)
			{
				strSql1.Append("UserEmail,");
				strSql2.Append("'"+model.UserEmail+"',");
			}
			if (model.UserProvince != null)
			{
				strSql1.Append("UserProvince,");
				strSql2.Append("'"+model.UserProvince+"',");
			}
			if (model.UserCity != null)
			{
				strSql1.Append("UserCity,");
				strSql2.Append("'"+model.UserCity+"',");
			}
			if (model.UserBirthday != null)
			{
				strSql1.Append("UserBirthday,");
				strSql2.Append("'"+model.UserBirthday+"',");
			}
			if (model.UserPhone != null)
			{
				strSql1.Append("UserPhone,");
				strSql2.Append("'"+model.UserPhone+"',");
			}
			if (model.UserAddress != null)
			{
				strSql1.Append("UserAddress,");
				strSql2.Append("'"+model.UserAddress+"',");
			}
			if (model.UserIdentity != null)
			{
				strSql1.Append("UserIdentity,");
				strSql2.Append("'"+model.UserIdentity+"',");
			}
			if (model.UserAddTime != null)
			{
				strSql1.Append("UserAddTime,");
				strSql2.Append("'"+model.UserAddTime+"',");
			}
			if (model.AAA2 != null)
			{
				strSql1.Append("AAA2,");
				strSql2.Append("'"+model.AAA2+"',");
			}
			if (model.AAA3 != null)
			{
				strSql1.Append("AAA3,");
				strSql2.Append("'"+model.AAA3+"',");
			}
			if (model.AAA4 != null)
			{
				strSql1.Append("AAA4,");
				strSql2.Append("'"+model.AAA4+"',");
			}
			if (model.AAA5 != null)
			{
				strSql1.Append("AAA5,");
				strSql2.Append("'"+model.AAA5+"',");
			}
			strSql.Append("insert into UsersInfo(");
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
		public bool Update(Maticsoft.Model.UsersInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UsersInfo set ");
			if (model.UnitID != null)
			{
				strSql.Append("UnitID='"+model.UnitID+"',");
			}
			else
			{
				strSql.Append("UnitID= null ,");
			}
			if (model.UserName != null)
			{
				strSql.Append("UserName='"+model.UserName+"',");
			}
			else
			{
				strSql.Append("UserName= null ,");
			}
			if (model.UserPassword != null)
			{
				strSql.Append("UserPassword='"+model.UserPassword+"',");
			}
			else
			{
				strSql.Append("UserPassword= null ,");
			}
			if (model.UserRealName != null)
			{
				strSql.Append("UserRealName='"+model.UserRealName+"',");
			}
			else
			{
				strSql.Append("UserRealName= null ,");
			}
			if (model.UserSex != null)
			{
				strSql.Append("UserSex='"+model.UserSex+"',");
			}
			else
			{
				strSql.Append("UserSex= null ,");
			}
			if (model.UserEmail != null)
			{
				strSql.Append("UserEmail='"+model.UserEmail+"',");
			}
			else
			{
				strSql.Append("UserEmail= null ,");
			}
			if (model.UserProvince != null)
			{
				strSql.Append("UserProvince='"+model.UserProvince+"',");
			}
			else
			{
				strSql.Append("UserProvince= null ,");
			}
			if (model.UserCity != null)
			{
				strSql.Append("UserCity='"+model.UserCity+"',");
			}
			else
			{
				strSql.Append("UserCity= null ,");
			}
			if (model.UserBirthday != null)
			{
				strSql.Append("UserBirthday='"+model.UserBirthday+"',");
			}
			else
			{
				strSql.Append("UserBirthday= null ,");
			}
			if (model.UserPhone != null)
			{
				strSql.Append("UserPhone='"+model.UserPhone+"',");
			}
			else
			{
				strSql.Append("UserPhone= null ,");
			}
			if (model.UserAddress != null)
			{
				strSql.Append("UserAddress='"+model.UserAddress+"',");
			}
			else
			{
				strSql.Append("UserAddress= null ,");
			}
			if (model.UserIdentity != null)
			{
				strSql.Append("UserIdentity='"+model.UserIdentity+"',");
			}
			else
			{
				strSql.Append("UserIdentity= null ,");
			}
			if (model.UserAddTime != null)
			{
				strSql.Append("UserAddTime='"+model.UserAddTime+"',");
			}
			else
			{
				strSql.Append("UserAddTime= null ,");
			}
			if (model.AAA2 != null)
			{
				strSql.Append("AAA2='"+model.AAA2+"',");
			}
			else
			{
				strSql.Append("AAA2= null ,");
			}
			if (model.AAA3 != null)
			{
				strSql.Append("AAA3='"+model.AAA3+"',");
			}
			else
			{
				strSql.Append("AAA3= null ,");
			}
			if (model.AAA4 != null)
			{
				strSql.Append("AAA4='"+model.AAA4+"',");
			}
			else
			{
				strSql.Append("AAA4= null ,");
			}
			if (model.AAA5 != null)
			{
				strSql.Append("AAA5='"+model.AAA5+"',");
			}
			else
			{
				strSql.Append("AAA5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where UserID='"+ model.UserID+"' ");
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
		public bool Delete(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UsersInfo ");
			strSql.Append(" where UserID='"+UserID+"' " );
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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UsersInfo ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public Maticsoft.Model.UsersInfo GetModel(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" UserID,UnitID,UserName,UserPassword,UserRealName,UserSex,UserEmail,UserProvince,UserCity,UserBirthday,UserPhone,UserAddress,UserIdentity,UserAddTime,AAA2,AAA3,AAA4,AAA5 ");
			strSql.Append(" from UsersInfo ");
			strSql.Append(" where UserID='"+UserID+"' " );
			Maticsoft.Model.UsersInfo model=new Maticsoft.Model.UsersInfo();
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
		public Maticsoft.Model.UsersInfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.UsersInfo model=new Maticsoft.Model.UsersInfo();
			if (row != null)
			{
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["UnitID"]!=null)
				{
					model.UnitID=row["UnitID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserPassword"]!=null)
				{
					model.UserPassword=row["UserPassword"].ToString();
				}
				if(row["UserRealName"]!=null)
				{
					model.UserRealName=row["UserRealName"].ToString();
				}
				if(row["UserSex"]!=null)
				{
					model.UserSex=row["UserSex"].ToString();
				}
				if(row["UserEmail"]!=null)
				{
					model.UserEmail=row["UserEmail"].ToString();
				}
				if(row["UserProvince"]!=null)
				{
					model.UserProvince=row["UserProvince"].ToString();
				}
				if(row["UserCity"]!=null)
				{
					model.UserCity=row["UserCity"].ToString();
				}
				if(row["UserBirthday"]!=null)
				{
					model.UserBirthday=row["UserBirthday"].ToString();
				}
				if(row["UserPhone"]!=null)
				{
					model.UserPhone=row["UserPhone"].ToString();
				}
				if(row["UserAddress"]!=null)
				{
					model.UserAddress=row["UserAddress"].ToString();
				}
				if(row["UserIdentity"]!=null)
				{
					model.UserIdentity=row["UserIdentity"].ToString();
				}
				if(row["UserAddTime"]!=null)
				{
					model.UserAddTime=row["UserAddTime"].ToString();
				}
				if(row["AAA2"]!=null)
				{
					model.AAA2=row["AAA2"].ToString();
				}
				if(row["AAA3"]!=null)
				{
					model.AAA3=row["AAA3"].ToString();
				}
				if(row["AAA4"]!=null)
				{
					model.AAA4=row["AAA4"].ToString();
				}
				if(row["AAA5"]!=null)
				{
					model.AAA5=row["AAA5"].ToString();
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
			strSql.Append("select UserID,UnitID,UserName,UserPassword,UserRealName,UserSex,UserEmail,UserProvince,UserCity,UserBirthday,UserPhone,UserAddress,UserIdentity,UserAddTime,AAA2,AAA3,AAA4,AAA5 ");
			strSql.Append(" FROM UsersInfo ");
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
			strSql.Append(" UserID,UnitID,UserName,UserPassword,UserRealName,UserSex,UserEmail,UserProvince,UserCity,UserBirthday,UserPhone,UserAddress,UserIdentity,UserAddTime,AAA2,AAA3,AAA4,AAA5 ");
			strSql.Append(" FROM UsersInfo ");
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
			strSql.Append("select count(1) FROM UsersInfo ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from UsersInfo T ");
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

