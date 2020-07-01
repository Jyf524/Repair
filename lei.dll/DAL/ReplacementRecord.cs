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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:ReplacementRecord
	/// </summary>
	public partial class ReplacementRecord
	{
		public ReplacementRecord()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ReplacementRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ReplacementRecord");
			strSql.Append(" where ReplacementRecordID='"+ReplacementRecordID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.ReplacementRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ReplacementRecordID != null)
			{
				strSql1.Append("ReplacementRecordID,");
				strSql2.Append("'"+model.ReplacementRecordID+"',");
			}
			if (model.ReplacementID != null)
			{
				strSql1.Append("ReplacementID,");
				strSql2.Append("'"+model.ReplacementID+"',");
			}
			if (model.ReplacementName != null)
			{
				strSql1.Append("ReplacementName,");
				strSql2.Append("'"+model.ReplacementName+"',");
			}
			if (model.ReplacementLendTime != null)
			{
				strSql1.Append("ReplacementLendTime,");
				strSql2.Append("'"+model.ReplacementLendTime+"',");
			}
			if (model.ReplacementBackTime != null)
			{
				strSql1.Append("ReplacementBackTime,");
				strSql2.Append("'"+model.ReplacementBackTime+"',");
			}
			if (model.UserID != null)
			{
				strSql1.Append("UserID,");
				strSql2.Append("'"+model.UserID+"',");
			}
			if (model.GGG1 != null)
			{
				strSql1.Append("GGG1,");
				strSql2.Append("'"+model.GGG1+"',");
			}
			if (model.GGG2 != null)
			{
				strSql1.Append("GGG2,");
				strSql2.Append("'"+model.GGG2+"',");
			}
			if (model.GGG3 != null)
			{
				strSql1.Append("GGG3,");
				strSql2.Append("'"+model.GGG3+"',");
			}
			if (model.GGG4 != null)
			{
				strSql1.Append("GGG4,");
				strSql2.Append("'"+model.GGG4+"',");
			}
			if (model.GGG5 != null)
			{
				strSql1.Append("GGG5,");
				strSql2.Append("'"+model.GGG5+"',");
			}
			strSql.Append("insert into ReplacementRecord(");
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
		public bool Update(Maticsoft.Model.ReplacementRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ReplacementRecord set ");
			if (model.ReplacementID != null)
			{
				strSql.Append("ReplacementID='"+model.ReplacementID+"',");
			}
			else
			{
				strSql.Append("ReplacementID= null ,");
			}
			if (model.ReplacementName != null)
			{
				strSql.Append("ReplacementName='"+model.ReplacementName+"',");
			}
			else
			{
				strSql.Append("ReplacementName= null ,");
			}
			if (model.ReplacementLendTime != null)
			{
				strSql.Append("ReplacementLendTime='"+model.ReplacementLendTime+"',");
			}
			else
			{
				strSql.Append("ReplacementLendTime= null ,");
			}
			if (model.ReplacementBackTime != null)
			{
				strSql.Append("ReplacementBackTime='"+model.ReplacementBackTime+"',");
			}
			else
			{
				strSql.Append("ReplacementBackTime= null ,");
			}
			if (model.UserID != null)
			{
				strSql.Append("UserID='"+model.UserID+"',");
			}
			else
			{
				strSql.Append("UserID= null ,");
			}
			if (model.GGG1 != null)
			{
				strSql.Append("GGG1='"+model.GGG1+"',");
			}
			else
			{
				strSql.Append("GGG1= null ,");
			}
			if (model.GGG2 != null)
			{
				strSql.Append("GGG2='"+model.GGG2+"',");
			}
			else
			{
				strSql.Append("GGG2= null ,");
			}
			if (model.GGG3 != null)
			{
				strSql.Append("GGG3='"+model.GGG3+"',");
			}
			else
			{
				strSql.Append("GGG3= null ,");
			}
			if (model.GGG4 != null)
			{
				strSql.Append("GGG4='"+model.GGG4+"',");
			}
			else
			{
				strSql.Append("GGG4= null ,");
			}
			if (model.GGG5 != null)
			{
				strSql.Append("GGG5='"+model.GGG5+"',");
			}
			else
			{
				strSql.Append("GGG5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ReplacementRecordID='"+ model.ReplacementRecordID+"' ");
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
		public bool Delete(string ReplacementRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ReplacementRecord ");
			strSql.Append(" where ReplacementRecordID='"+ReplacementRecordID+"' " );
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
		public bool DeleteList(string ReplacementRecordIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ReplacementRecord ");
			strSql.Append(" where ReplacementRecordID in ("+ReplacementRecordIDlist + ")  ");
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
		public Maticsoft.Model.ReplacementRecord GetModel(string ReplacementRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ReplacementRecordID,ReplacementID,ReplacementName,ReplacementLendTime,ReplacementBackTime,UserID,GGG1,GGG2,GGG3,GGG4,GGG5 ");
			strSql.Append(" from ReplacementRecord ");
			strSql.Append(" where ReplacementRecordID='"+ReplacementRecordID+"' " );
			Maticsoft.Model.ReplacementRecord model=new Maticsoft.Model.ReplacementRecord();
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
		public Maticsoft.Model.ReplacementRecord DataRowToModel(DataRow row)
		{
			Maticsoft.Model.ReplacementRecord model=new Maticsoft.Model.ReplacementRecord();
			if (row != null)
			{
				if(row["ReplacementRecordID"]!=null)
				{
					model.ReplacementRecordID=row["ReplacementRecordID"].ToString();
				}
				if(row["ReplacementID"]!=null)
				{
					model.ReplacementID=row["ReplacementID"].ToString();
				}
				if(row["ReplacementName"]!=null)
				{
					model.ReplacementName=row["ReplacementName"].ToString();
				}
				if(row["ReplacementLendTime"]!=null && row["ReplacementLendTime"].ToString()!="")
				{
					model.ReplacementLendTime=DateTime.Parse(row["ReplacementLendTime"].ToString());
				}
				if(row["ReplacementBackTime"]!=null && row["ReplacementBackTime"].ToString()!="")
				{
					model.ReplacementBackTime=DateTime.Parse(row["ReplacementBackTime"].ToString());
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["GGG1"]!=null)
				{
					model.GGG1=row["GGG1"].ToString();
				}
				if(row["GGG2"]!=null)
				{
					model.GGG2=row["GGG2"].ToString();
				}
				if(row["GGG3"]!=null)
				{
					model.GGG3=row["GGG3"].ToString();
				}
				if(row["GGG4"]!=null)
				{
					model.GGG4=row["GGG4"].ToString();
				}
				if(row["GGG5"]!=null)
				{
					model.GGG5=row["GGG5"].ToString();
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
			strSql.Append("select ReplacementRecordID,ReplacementID,ReplacementName,ReplacementLendTime,ReplacementBackTime,UserID,GGG1,GGG2,GGG3,GGG4,GGG5 ");
			strSql.Append(" FROM ReplacementRecord ");
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
			strSql.Append(" ReplacementRecordID,ReplacementID,ReplacementName,ReplacementLendTime,ReplacementBackTime,UserID,GGG1,GGG2,GGG3,GGG4,GGG5 ");
			strSql.Append(" FROM ReplacementRecord ");
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
			strSql.Append("select count(1) FROM ReplacementRecord ");
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
				strSql.Append("order by T.ReplacementRecordID desc");
			}
			strSql.Append(")AS Row, T.*  from ReplacementRecord T ");
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

