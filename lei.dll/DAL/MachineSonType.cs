/**  版本信息模板在安装目录下，可自行修改。
* MachineSonType.cs
*
* 功 能： N/A
* 类 名： MachineSonType
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
	/// 数据访问类:MachineSonType
	/// </summary>
	public partial class MachineSonType
	{
		public MachineSonType()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MachineSonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MachineSonType");
			strSql.Append(" where MachineSonID='"+MachineSonID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.MachineSonType model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.MachineSonID != null)
			{
				strSql1.Append("MachineSonID,");
				strSql2.Append("'"+model.MachineSonID+"',");
			}
			if (model.MachineFatherID != null)
			{
				strSql1.Append("MachineFatherID,");
				strSql2.Append("'"+model.MachineFatherID+"',");
			}
			if (model.MachineSonName != null)
			{
				strSql1.Append("MachineSonName,");
				strSql2.Append("'"+model.MachineSonName+"',");
			}
			if (model.MachineSonAddTime != null)
			{
				strSql1.Append("MachineSonAddTime,");
				strSql2.Append("'"+model.MachineSonAddTime+"',");
			}
			if (model.MachineSonPicture != null)
			{
				strSql1.Append("MachineSonPicture,");
				strSql2.Append("'"+model.MachineSonPicture+"',");
			}
			if (model.MachineSonIntroduction != null)
			{
				strSql1.Append("MachineSonIntroduction,");
				strSql2.Append("'"+model.MachineSonIntroduction+"',");
			}
			if (model.EEE1 != null)
			{
				strSql1.Append("EEE1,");
				strSql2.Append("'"+model.EEE1+"',");
			}
			if (model.EEE2 != null)
			{
				strSql1.Append("EEE2,");
				strSql2.Append("'"+model.EEE2+"',");
			}
			if (model.EEE3 != null)
			{
				strSql1.Append("EEE3,");
				strSql2.Append("'"+model.EEE3+"',");
			}
			if (model.EEE4 != null)
			{
				strSql1.Append("EEE4,");
				strSql2.Append("'"+model.EEE4+"',");
			}
			if (model.EEE5 != null)
			{
				strSql1.Append("EEE5,");
				strSql2.Append("'"+model.EEE5+"',");
			}
			strSql.Append("insert into MachineSonType(");
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
		public bool Update(Maticsoft.Model.MachineSonType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MachineSonType set ");
			if (model.MachineFatherID != null)
			{
				strSql.Append("MachineFatherID='"+model.MachineFatherID+"',");
			}
			else
			{
				strSql.Append("MachineFatherID= null ,");
			}
			if (model.MachineSonName != null)
			{
				strSql.Append("MachineSonName='"+model.MachineSonName+"',");
			}
			else
			{
				strSql.Append("MachineSonName= null ,");
			}
			if (model.MachineSonAddTime != null)
			{
				strSql.Append("MachineSonAddTime='"+model.MachineSonAddTime+"',");
			}
			else
			{
				strSql.Append("MachineSonAddTime= null ,");
			}
			if (model.MachineSonPicture != null)
			{
				strSql.Append("MachineSonPicture='"+model.MachineSonPicture+"',");
			}
			else
			{
				strSql.Append("MachineSonPicture= null ,");
			}
			if (model.MachineSonIntroduction != null)
			{
				strSql.Append("MachineSonIntroduction='"+model.MachineSonIntroduction+"',");
			}
			else
			{
				strSql.Append("MachineSonIntroduction= null ,");
			}
			if (model.EEE1 != null)
			{
				strSql.Append("EEE1='"+model.EEE1+"',");
			}
			else
			{
				strSql.Append("EEE1= null ,");
			}
			if (model.EEE2 != null)
			{
				strSql.Append("EEE2='"+model.EEE2+"',");
			}
			else
			{
				strSql.Append("EEE2= null ,");
			}
			if (model.EEE3 != null)
			{
				strSql.Append("EEE3='"+model.EEE3+"',");
			}
			else
			{
				strSql.Append("EEE3= null ,");
			}
			if (model.EEE4 != null)
			{
				strSql.Append("EEE4='"+model.EEE4+"',");
			}
			else
			{
				strSql.Append("EEE4= null ,");
			}
			if (model.EEE5 != null)
			{
				strSql.Append("EEE5='"+model.EEE5+"',");
			}
			else
			{
				strSql.Append("EEE5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where MachineSonID='"+ model.MachineSonID+"' ");
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
		public bool Delete(string MachineSonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MachineSonType ");
			strSql.Append(" where MachineSonID='"+MachineSonID+"' " );
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
		public bool DeleteList(string MachineSonIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MachineSonType ");
			strSql.Append(" where MachineSonID in ("+MachineSonIDlist + ")  ");
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
		public Maticsoft.Model.MachineSonType GetModel(string MachineSonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" MachineSonID,MachineFatherID,MachineSonName,MachineSonAddTime,MachineSonPicture,MachineSonIntroduction,EEE1,EEE2,EEE3,EEE4,EEE5 ");
			strSql.Append(" from MachineSonType ");
			strSql.Append(" where MachineSonID='"+MachineSonID+"' " );
			Maticsoft.Model.MachineSonType model=new Maticsoft.Model.MachineSonType();
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
		public Maticsoft.Model.MachineSonType DataRowToModel(DataRow row)
		{
			Maticsoft.Model.MachineSonType model=new Maticsoft.Model.MachineSonType();
			if (row != null)
			{
				if(row["MachineSonID"]!=null)
				{
					model.MachineSonID=row["MachineSonID"].ToString();
				}
				if(row["MachineFatherID"]!=null)
				{
					model.MachineFatherID=row["MachineFatherID"].ToString();
				}
				if(row["MachineSonName"]!=null)
				{
					model.MachineSonName=row["MachineSonName"].ToString();
				}
				if(row["MachineSonAddTime"]!=null && row["MachineSonAddTime"].ToString()!="")
				{
					model.MachineSonAddTime=DateTime.Parse(row["MachineSonAddTime"].ToString());
				}
				if(row["MachineSonPicture"]!=null)
				{
					model.MachineSonPicture=row["MachineSonPicture"].ToString();
				}
				if(row["MachineSonIntroduction"]!=null)
				{
					model.MachineSonIntroduction=row["MachineSonIntroduction"].ToString();
				}
				if(row["EEE1"]!=null)
				{
					model.EEE1=row["EEE1"].ToString();
				}
				if(row["EEE2"]!=null)
				{
					model.EEE2=row["EEE2"].ToString();
				}
				if(row["EEE3"]!=null)
				{
					model.EEE3=row["EEE3"].ToString();
				}
				if(row["EEE4"]!=null)
				{
					model.EEE4=row["EEE4"].ToString();
				}
				if(row["EEE5"]!=null)
				{
					model.EEE5=row["EEE5"].ToString();
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
			strSql.Append("select MachineSonID,MachineFatherID,MachineSonName,MachineSonAddTime,MachineSonPicture,MachineSonIntroduction,EEE1,EEE2,EEE3,EEE4,EEE5 ");
			strSql.Append(" FROM MachineSonType ");
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
			strSql.Append(" MachineSonID,MachineFatherID,MachineSonName,MachineSonAddTime,MachineSonPicture,MachineSonIntroduction,EEE1,EEE2,EEE3,EEE4,EEE5 ");
			strSql.Append(" FROM MachineSonType ");
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
			strSql.Append("select count(1) FROM MachineSonType ");
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
				strSql.Append("order by T.MachineSonID desc");
			}
			strSql.Append(")AS Row, T.*  from MachineSonType T ");
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

