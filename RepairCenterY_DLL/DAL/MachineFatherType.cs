/**  版本信息模板在安装目录下，可自行修改。
* MachineFatherType.cs
*
* 功 能： N/A
* 类 名： MachineFatherType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 11:05:34   N/A    初版
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
	/// 数据访问类:MachineFatherType
	/// </summary>
	public partial class MachineFatherType
	{
		public MachineFatherType()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MachineFatherID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MachineFatherType");
			strSql.Append(" where MachineFatherID='"+MachineFatherID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.MachineFatherType model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.MachineFatherID != null)
			{
				strSql1.Append("MachineFatherID,");
				strSql2.Append("'"+model.MachineFatherID+"',");
			}
			if (model.MachineFatherName != null)
			{
				strSql1.Append("MachineFatherName,");
				strSql2.Append("'"+model.MachineFatherName+"',");
			}
			if (model.MachineFatherAddTime != null)
			{
				strSql1.Append("MachineFatherAddTime,");
				strSql2.Append("'"+model.MachineFatherAddTime+"',");
			}
			if (model.MachineFatherPicture != null)
			{
				strSql1.Append("MachineFatherPicture,");
				strSql2.Append("'"+model.MachineFatherPicture+"',");
			}
			if (model.MachineFatherIntroduction != null)
			{
				strSql1.Append("MachineFatherIntroduction,");
				strSql2.Append("'"+model.MachineFatherIntroduction+"',");
			}
			if (model.DDD1 != null)
			{
				strSql1.Append("DDD1,");
				strSql2.Append("'"+model.DDD1+"',");
			}
			if (model.DDD2 != null)
			{
				strSql1.Append("DDD2,");
				strSql2.Append("'"+model.DDD2+"',");
			}
			if (model.DDD3 != null)
			{
				strSql1.Append("DDD3,");
				strSql2.Append("'"+model.DDD3+"',");
			}
			if (model.DDD4 != null)
			{
				strSql1.Append("DDD4,");
				strSql2.Append("'"+model.DDD4+"',");
			}
			if (model.DDD5 != null)
			{
				strSql1.Append("DDD5,");
				strSql2.Append("'"+model.DDD5+"',");
			}
			strSql.Append("insert into MachineFatherType(");
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
		public bool Update(Maticsoft.Model.MachineFatherType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MachineFatherType set ");
			if (model.MachineFatherName != null)
			{
				strSql.Append("MachineFatherName='"+model.MachineFatherName+"',");
			}
			else
			{
				strSql.Append("MachineFatherName= null ,");
			}
			if (model.MachineFatherAddTime != null)
			{
				strSql.Append("MachineFatherAddTime='"+model.MachineFatherAddTime+"',");
			}
			else
			{
				strSql.Append("MachineFatherAddTime= null ,");
			}
			if (model.MachineFatherPicture != null)
			{
				strSql.Append("MachineFatherPicture='"+model.MachineFatherPicture+"',");
			}
			else
			{
				strSql.Append("MachineFatherPicture= null ,");
			}
			if (model.MachineFatherIntroduction != null)
			{
				strSql.Append("MachineFatherIntroduction='"+model.MachineFatherIntroduction+"',");
			}
			else
			{
				strSql.Append("MachineFatherIntroduction= null ,");
			}
			if (model.DDD1 != null)
			{
				strSql.Append("DDD1='"+model.DDD1+"',");
			}
			else
			{
				strSql.Append("DDD1= null ,");
			}
			if (model.DDD2 != null)
			{
				strSql.Append("DDD2='"+model.DDD2+"',");
			}
			else
			{
				strSql.Append("DDD2= null ,");
			}
			if (model.DDD3 != null)
			{
				strSql.Append("DDD3='"+model.DDD3+"',");
			}
			else
			{
				strSql.Append("DDD3= null ,");
			}
			if (model.DDD4 != null)
			{
				strSql.Append("DDD4='"+model.DDD4+"',");
			}
			else
			{
				strSql.Append("DDD4= null ,");
			}
			if (model.DDD5 != null)
			{
				strSql.Append("DDD5='"+model.DDD5+"',");
			}
			else
			{
				strSql.Append("DDD5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where MachineFatherID='"+ model.MachineFatherID+"' ");
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
		public bool Delete(string MachineFatherID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MachineFatherType ");
			strSql.Append(" where MachineFatherID='"+MachineFatherID+"' " );
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
		public bool DeleteList(string MachineFatherIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MachineFatherType ");
			strSql.Append(" where MachineFatherID in ("+MachineFatherIDlist + ")  ");
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
		public Maticsoft.Model.MachineFatherType GetModel(string MachineFatherID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" MachineFatherID,MachineFatherName,MachineFatherAddTime,MachineFatherPicture,MachineFatherIntroduction,DDD1,DDD2,DDD3,DDD4,DDD5 ");
			strSql.Append(" from MachineFatherType ");
			strSql.Append(" where MachineFatherID='"+MachineFatherID+"' " );
			Maticsoft.Model.MachineFatherType model=new Maticsoft.Model.MachineFatherType();
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
		public Maticsoft.Model.MachineFatherType DataRowToModel(DataRow row)
		{
			Maticsoft.Model.MachineFatherType model=new Maticsoft.Model.MachineFatherType();
			if (row != null)
			{
				if(row["MachineFatherID"]!=null)
				{
					model.MachineFatherID=row["MachineFatherID"].ToString();
				}
				if(row["MachineFatherName"]!=null)
				{
					model.MachineFatherName=row["MachineFatherName"].ToString();
				}
				if(row["MachineFatherAddTime"]!=null && row["MachineFatherAddTime"].ToString()!="")
				{
					model.MachineFatherAddTime=DateTime.Parse(row["MachineFatherAddTime"].ToString());
				}
				if(row["MachineFatherPicture"]!=null)
				{
					model.MachineFatherPicture=row["MachineFatherPicture"].ToString();
				}
				if(row["MachineFatherIntroduction"]!=null)
				{
					model.MachineFatherIntroduction=row["MachineFatherIntroduction"].ToString();
				}
				if(row["DDD1"]!=null)
				{
					model.DDD1=row["DDD1"].ToString();
				}
				if(row["DDD2"]!=null)
				{
					model.DDD2=row["DDD2"].ToString();
				}
				if(row["DDD3"]!=null)
				{
					model.DDD3=row["DDD3"].ToString();
				}
				if(row["DDD4"]!=null)
				{
					model.DDD4=row["DDD4"].ToString();
				}
				if(row["DDD5"]!=null)
				{
					model.DDD5=row["DDD5"].ToString();
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
			strSql.Append("select MachineFatherID,MachineFatherName,MachineFatherAddTime,MachineFatherPicture,MachineFatherIntroduction,DDD1,DDD2,DDD3,DDD4,DDD5 ");
			strSql.Append(" FROM MachineFatherType ");
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
			strSql.Append(" MachineFatherID,MachineFatherName,MachineFatherAddTime,MachineFatherPicture,MachineFatherIntroduction,DDD1,DDD2,DDD3,DDD4,DDD5 ");
			strSql.Append(" FROM MachineFatherType ");
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
			strSql.Append("select count(1) FROM MachineFatherType ");
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
				strSql.Append("order by T.MachineFatherID desc");
			}
			strSql.Append(")AS Row, T.*  from MachineFatherType T ");
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

