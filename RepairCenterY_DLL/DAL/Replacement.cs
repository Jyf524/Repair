/**  版本信息模板在安装目录下，可自行修改。
* Replacement.cs
*
* 功 能： N/A
* 类 名： Replacement
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 11:05:36   N/A    初版
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
	/// 数据访问类:Replacement
	/// </summary>
	public partial class Replacement
	{
		public Replacement()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ReplacementID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Replacement");
			strSql.Append(" where ReplacementID='"+ReplacementID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Replacement model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ReplacementID != null)
			{
				strSql1.Append("ReplacementID,");
				strSql2.Append("'"+model.ReplacementID+"',");
			}
			if (model.MachineFatherID != null)
			{
				strSql1.Append("MachineFatherID,");
				strSql2.Append("'"+model.MachineFatherID+"',");
			}
			if (model.MachineSonID != null)
			{
				strSql1.Append("MachineSonID,");
				strSql2.Append("'"+model.MachineSonID+"',");
			}
			if (model.ReplacementModel != null)
			{
				strSql1.Append("ReplacementModel,");
				strSql2.Append("'"+model.ReplacementModel+"',");
			}
			if (model.ReplacementName != null)
			{
				strSql1.Append("ReplacementName,");
				strSql2.Append("'"+model.ReplacementName+"',");
			}
			if (model.ReplacementState != null)
			{
				strSql1.Append("ReplacementState,");
				strSql2.Append("'"+model.ReplacementState+"',");
			}
			if (model.ReplacementPicture != null)
			{
				strSql1.Append("ReplacementPicture,");
				strSql2.Append("'"+model.ReplacementPicture+"',");
			}
			if (model.ReplacementAddTime != null)
			{
				strSql1.Append("ReplacementAddTime,");
				strSql2.Append("'"+model.ReplacementAddTime+"',");
			}
			if (model.FFF1 != null)
			{
				strSql1.Append("FFF1,");
				strSql2.Append("'"+model.FFF1+"',");
			}
			if (model.FFF2 != null)
			{
				strSql1.Append("FFF2,");
				strSql2.Append("'"+model.FFF2+"',");
			}
			if (model.FFF3 != null)
			{
				strSql1.Append("FFF3,");
				strSql2.Append("'"+model.FFF3+"',");
			}
			if (model.FFF4 != null)
			{
				strSql1.Append("FFF4,");
				strSql2.Append("'"+model.FFF4+"',");
			}
			if (model.FFF5 != null)
			{
				strSql1.Append("FFF5,");
				strSql2.Append("'"+model.FFF5+"',");
			}
			strSql.Append("insert into Replacement(");
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
		public bool Update(Maticsoft.Model.Replacement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Replacement set ");
			if (model.MachineFatherID != null)
			{
				strSql.Append("MachineFatherID='"+model.MachineFatherID+"',");
			}
			else
			{
				strSql.Append("MachineFatherID= null ,");
			}
			if (model.MachineSonID != null)
			{
				strSql.Append("MachineSonID='"+model.MachineSonID+"',");
			}
			else
			{
				strSql.Append("MachineSonID= null ,");
			}
			if (model.ReplacementModel != null)
			{
				strSql.Append("ReplacementModel='"+model.ReplacementModel+"',");
			}
			else
			{
				strSql.Append("ReplacementModel= null ,");
			}
			if (model.ReplacementName != null)
			{
				strSql.Append("ReplacementName='"+model.ReplacementName+"',");
			}
			else
			{
				strSql.Append("ReplacementName= null ,");
			}
			if (model.ReplacementState != null)
			{
				strSql.Append("ReplacementState='"+model.ReplacementState+"',");
			}
			else
			{
				strSql.Append("ReplacementState= null ,");
			}
			if (model.ReplacementPicture != null)
			{
				strSql.Append("ReplacementPicture='"+model.ReplacementPicture+"',");
			}
			else
			{
				strSql.Append("ReplacementPicture= null ,");
			}
			if (model.ReplacementAddTime != null)
			{
				strSql.Append("ReplacementAddTime='"+model.ReplacementAddTime+"',");
			}
			else
			{
				strSql.Append("ReplacementAddTime= null ,");
			}
			if (model.FFF1 != null)
			{
				strSql.Append("FFF1='"+model.FFF1+"',");
			}
			else
			{
				strSql.Append("FFF1= null ,");
			}
			if (model.FFF2 != null)
			{
				strSql.Append("FFF2='"+model.FFF2+"',");
			}
			else
			{
				strSql.Append("FFF2= null ,");
			}
			if (model.FFF3 != null)
			{
				strSql.Append("FFF3='"+model.FFF3+"',");
			}
			else
			{
				strSql.Append("FFF3= null ,");
			}
			if (model.FFF4 != null)
			{
				strSql.Append("FFF4='"+model.FFF4+"',");
			}
			else
			{
				strSql.Append("FFF4= null ,");
			}
			if (model.FFF5 != null)
			{
				strSql.Append("FFF5='"+model.FFF5+"',");
			}
			else
			{
				strSql.Append("FFF5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ReplacementID='"+ model.ReplacementID+"' ");
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
		public bool Delete(string ReplacementID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Replacement ");
			strSql.Append(" where ReplacementID='"+ReplacementID+"' " );
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
		public bool DeleteList(string ReplacementIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Replacement ");
			strSql.Append(" where ReplacementID in ("+ReplacementIDlist + ")  ");
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
		public Maticsoft.Model.Replacement GetModel(string ReplacementID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ReplacementID,MachineFatherID,MachineSonID,ReplacementModel,ReplacementName,ReplacementState,ReplacementPicture,ReplacementAddTime,FFF1,FFF2,FFF3,FFF4,FFF5 ");
			strSql.Append(" from Replacement ");
			strSql.Append(" where ReplacementID='"+ReplacementID+"' " );
			Maticsoft.Model.Replacement model=new Maticsoft.Model.Replacement();
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
		public Maticsoft.Model.Replacement DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Replacement model=new Maticsoft.Model.Replacement();
			if (row != null)
			{
				if(row["ReplacementID"]!=null)
				{
					model.ReplacementID=row["ReplacementID"].ToString();
				}
				if(row["MachineFatherID"]!=null)
				{
					model.MachineFatherID=row["MachineFatherID"].ToString();
				}
				if(row["MachineSonID"]!=null)
				{
					model.MachineSonID=row["MachineSonID"].ToString();
				}
				if(row["ReplacementModel"]!=null)
				{
					model.ReplacementModel=row["ReplacementModel"].ToString();
				}
				if(row["ReplacementName"]!=null)
				{
					model.ReplacementName=row["ReplacementName"].ToString();
				}
				if(row["ReplacementState"]!=null)
				{
					model.ReplacementState=row["ReplacementState"].ToString();
				}
				if(row["ReplacementPicture"]!=null)
				{
					model.ReplacementPicture=row["ReplacementPicture"].ToString();
				}
				if(row["ReplacementAddTime"]!=null && row["ReplacementAddTime"].ToString()!="")
				{
					model.ReplacementAddTime=DateTime.Parse(row["ReplacementAddTime"].ToString());
				}
				if(row["FFF1"]!=null)
				{
					model.FFF1=row["FFF1"].ToString();
				}
				if(row["FFF2"]!=null)
				{
					model.FFF2=row["FFF2"].ToString();
				}
				if(row["FFF3"]!=null)
				{
					model.FFF3=row["FFF3"].ToString();
				}
				if(row["FFF4"]!=null)
				{
					model.FFF4=row["FFF4"].ToString();
				}
				if(row["FFF5"]!=null)
				{
					model.FFF5=row["FFF5"].ToString();
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
			strSql.Append("select ReplacementID,MachineFatherID,MachineSonID,ReplacementModel,ReplacementName,ReplacementState,ReplacementPicture,ReplacementAddTime,FFF1,FFF2,FFF3,FFF4,FFF5 ");
			strSql.Append(" FROM Replacement ");
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
			strSql.Append(" ReplacementID,MachineFatherID,MachineSonID,ReplacementModel,ReplacementName,ReplacementState,ReplacementPicture,ReplacementAddTime,FFF1,FFF2,FFF3,FFF4,FFF5 ");
			strSql.Append(" FROM Replacement ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetList1(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Replacement a,MachineFatherType b,MachineSonType c ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and a.MachineFatherID = b.MachineFatherID and a.MachineSonID = c.MachineSonID ");
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
			strSql.Append("select count(1) FROM Replacement ");
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
				strSql.Append("order by T.ReplacementID desc");
			}
			strSql.Append(")AS Row, T.*  from Replacement T ");
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
        public Maticsoft.Model.Replacement GetModelJYF(string ReplacementID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" * ");
            strSql.Append(" from Replacement a,Declaration b ");
            strSql.Append(" where b.ReplacementID='" + ReplacementID + "' and a.ReplacementID = b.ReplacementID  ");
            Maticsoft.Model.Replacement model = new Maticsoft.Model.Replacement();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

