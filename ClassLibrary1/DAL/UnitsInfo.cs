/**  版本信息模板在安装目录下，可自行修改。
* UnitsInfo.cs
*
* 功 能： N/A
* 类 名： UnitsInfo
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
	/// 数据访问类:UnitsInfo
	/// </summary>
	public partial class UnitsInfo
	{
		public UnitsInfo()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UnitID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UnitsInfo");
			strSql.Append(" where UnitID='"+UnitID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.UnitsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.UnitID != null)
			{
				strSql1.Append("UnitID,");
				strSql2.Append("'"+model.UnitID+"',");
			}
			if (model.UnitName != null)
			{
				strSql1.Append("UnitName,");
				strSql2.Append("'"+model.UnitName+"',");
			}
			if (model.UnitCode != null)
			{
				strSql1.Append("UnitCode,");
				strSql2.Append("'"+model.UnitCode+"',");
			}
			if (model.UnitPhone != null)
			{
				strSql1.Append("UnitPhone,");
				strSql2.Append("'"+model.UnitPhone+"',");
			}
			if (model.Unitprovince != null)
			{
				strSql1.Append("Unitprovince,");
				strSql2.Append("'"+model.Unitprovince+"',");
			}
			if (model.UnitCity != null)
			{
				strSql1.Append("UnitCity,");
				strSql2.Append("'"+model.UnitCity+"',");
			}
			if (model.UnitAddress != null)
			{
				strSql1.Append("UnitAddress,");
				strSql2.Append("'"+model.UnitAddress+"',");
			}
			if (model.UnitUserID != null)
			{
				strSql1.Append("UnitUserID,");
				strSql2.Append("'"+model.UnitUserID+"',");
			}
			if (model.BBB1 != null)
			{
				strSql1.Append("BBB1,");
				strSql2.Append("'"+model.BBB1+"',");
			}
			if (model.BBB2 != null)
			{
				strSql1.Append("BBB2,");
				strSql2.Append("'"+model.BBB2+"',");
			}
			if (model.BBB3 != null)
			{
				strSql1.Append("BBB3,");
				strSql2.Append("'"+model.BBB3+"',");
			}
			if (model.BBB4 != null)
			{
				strSql1.Append("BBB4,");
				strSql2.Append("'"+model.BBB4+"',");
			}
			if (model.BBB5 != null)
			{
				strSql1.Append("BBB5,");
				strSql2.Append("'"+model.BBB5+"',");
			}
			strSql.Append("insert into UnitsInfo(");
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
		public bool Update(Maticsoft.Model.UnitsInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UnitsInfo set ");
			if (model.UnitName != null)
			{
				strSql.Append("UnitName='"+model.UnitName+"',");
			}
			else
			{
				strSql.Append("UnitName= null ,");
			}
			if (model.UnitCode != null)
			{
				strSql.Append("UnitCode='"+model.UnitCode+"',");
			}
			else
			{
				strSql.Append("UnitCode= null ,");
			}
			if (model.UnitPhone != null)
			{
				strSql.Append("UnitPhone='"+model.UnitPhone+"',");
			}
			else
			{
				strSql.Append("UnitPhone= null ,");
			}
			if (model.Unitprovince != null)
			{
				strSql.Append("Unitprovince='"+model.Unitprovince+"',");
			}
			else
			{
				strSql.Append("Unitprovince= null ,");
			}
			if (model.UnitCity != null)
			{
				strSql.Append("UnitCity='"+model.UnitCity+"',");
			}
			else
			{
				strSql.Append("UnitCity= null ,");
			}
			if (model.UnitAddress != null)
			{
				strSql.Append("UnitAddress='"+model.UnitAddress+"',");
			}
			else
			{
				strSql.Append("UnitAddress= null ,");
			}
			if (model.UnitUserID != null)
			{
				strSql.Append("UnitUserID='"+model.UnitUserID+"',");
			}
			else
			{
				strSql.Append("UnitUserID= null ,");
			}
			if (model.BBB1 != null)
			{
				strSql.Append("BBB1='"+model.BBB1+"',");
			}
			else
			{
				strSql.Append("BBB1= null ,");
			}
			if (model.BBB2 != null)
			{
				strSql.Append("BBB2='"+model.BBB2+"',");
			}
			else
			{
				strSql.Append("BBB2= null ,");
			}
			if (model.BBB3 != null)
			{
				strSql.Append("BBB3='"+model.BBB3+"',");
			}
			else
			{
				strSql.Append("BBB3= null ,");
			}
			if (model.BBB4 != null)
			{
				strSql.Append("BBB4='"+model.BBB4+"',");
			}
			else
			{
				strSql.Append("BBB4= null ,");
			}
			if (model.BBB5 != null)
			{
				strSql.Append("BBB5='"+model.BBB5+"',");
			}
			else
			{
				strSql.Append("BBB5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where UnitID='"+ model.UnitID+"' ");
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
		public bool Delete(string UnitID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UnitsInfo ");
			strSql.Append(" where UnitID='"+UnitID+"' " );
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
		public bool DeleteList(string UnitIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UnitsInfo ");
			strSql.Append(" where UnitID in ("+UnitIDlist + ")  ");
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
		public Maticsoft.Model.UnitsInfo GetModel(string UnitID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" UnitID,UnitName,UnitCode,UnitPhone,Unitprovince,UnitCity,UnitAddress,UnitUserID,BBB1,BBB2,BBB3,BBB4,BBB5 ");
			strSql.Append(" from UnitsInfo ");
			strSql.Append(" where UnitID='"+UnitID+"' " );
			Maticsoft.Model.UnitsInfo model=new Maticsoft.Model.UnitsInfo();
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
		public Maticsoft.Model.UnitsInfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.UnitsInfo model=new Maticsoft.Model.UnitsInfo();
			if (row != null)
			{
				if(row["UnitID"]!=null)
				{
					model.UnitID=row["UnitID"].ToString();
				}
				if(row["UnitName"]!=null)
				{
					model.UnitName=row["UnitName"].ToString();
				}
				if(row["UnitCode"]!=null)
				{
					model.UnitCode=row["UnitCode"].ToString();
				}
				if(row["UnitPhone"]!=null)
				{
					model.UnitPhone=row["UnitPhone"].ToString();
				}
				if(row["Unitprovince"]!=null)
				{
					model.Unitprovince=row["Unitprovince"].ToString();
				}
				if(row["UnitCity"]!=null)
				{
					model.UnitCity=row["UnitCity"].ToString();
				}
				if(row["UnitAddress"]!=null)
				{
					model.UnitAddress=row["UnitAddress"].ToString();
				}
				if(row["UnitUserID"]!=null)
				{
					model.UnitUserID=row["UnitUserID"].ToString();
				}
				if(row["BBB1"]!=null)
				{
					model.BBB1=row["BBB1"].ToString();
				}
				if(row["BBB2"]!=null)
				{
					model.BBB2=row["BBB2"].ToString();
				}
				if(row["BBB3"]!=null)
				{
					model.BBB3=row["BBB3"].ToString();
				}
				if(row["BBB4"]!=null)
				{
					model.BBB4=row["BBB4"].ToString();
				}
				if(row["BBB5"]!=null)
				{
					model.BBB5=row["BBB5"].ToString();
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
			strSql.Append("select UnitID,UnitName,UnitCode,UnitPhone,Unitprovince,UnitCity,UnitAddress,UnitUserID,BBB1,BBB2,BBB3,BBB4,BBB5 ");
			strSql.Append(" FROM UnitsInfo ");
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
			strSql.Append(" UnitID,UnitName,UnitCode,UnitPhone,Unitprovince,UnitCity,UnitAddress,UnitUserID,BBB1,BBB2,BBB3,BBB4,BBB5 ");
			strSql.Append(" FROM UnitsInfo ");
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
			strSql.Append("select count(1) FROM UnitsInfo ");
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
				strSql.Append("order by T.UnitID desc");
			}
			strSql.Append(")AS Row, T.*  from UnitsInfo T ");
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

