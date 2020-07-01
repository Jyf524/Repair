/**  版本信息模板在安装目录下，可自行修改。
* PartUseRecord.cs
*
* 功 能： N/A
* 类 名： PartUseRecord
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
	/// 数据访问类:PartUseRecord
	/// </summary>
	public partial class PartUseRecord
	{
		public PartUseRecord()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PartUseRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PartUseRecord");
			strSql.Append(" where PartUseRecordID='"+PartUseRecordID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.PartUseRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PartUseRecordID != null)
			{
				strSql1.Append("PartUseRecordID,");
				strSql2.Append("'"+model.PartUseRecordID+"',");
			}
			if (model.PartID != null)
			{
				strSql1.Append("PartID,");
				strSql2.Append("'"+model.PartID+"',");
			}
			if (model.RepairID != null)
			{
				strSql1.Append("RepairID,");
				strSql2.Append("'"+model.RepairID+"',");
			}
			if (model.UserID != null)
			{
				strSql1.Append("UserID,");
				strSql2.Append("'"+model.UserID+"',");
			}
			if (model.PartUseNumber != null)
			{
				strSql1.Append("PartUseNumber,");
				strSql2.Append(""+model.PartUseNumber+",");
			}
			if (model.PartUseTime != null)
			{
				strSql1.Append("PartUseTime,");
				strSql2.Append("'"+model.PartUseTime+"',");
			}
			if (model.Partmoney != null)
			{
				strSql1.Append("Partmoney,");
				strSql2.Append("'"+model.Partmoney+"',");
			}
			if (model.tt2 != null)
			{
				strSql1.Append("tt2,");
				strSql2.Append("'"+model.tt2+"',");
			}
			if (model.tt3 != null)
			{
				strSql1.Append("tt3,");
				strSql2.Append("'"+model.tt3+"',");
			}
			if (model.tt4 != null)
			{
				strSql1.Append("tt4,");
				strSql2.Append(""+model.tt4+",");
			}
			if (model.tt5 != null)
			{
				strSql1.Append("tt5,");
				strSql2.Append("'"+model.tt5+"',");
			}
			if (model.tt6 != null)
			{
				strSql1.Append("tt6,");
				strSql2.Append("'"+model.tt6+"',");
			}
			strSql.Append("insert into PartUseRecord(");
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
		public bool Update(Maticsoft.Model.PartUseRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PartUseRecord set ");
			if (model.PartID != null)
			{
				strSql.Append("PartID='"+model.PartID+"',");
			}
			else
			{
				strSql.Append("PartID= null ,");
			}
			if (model.RepairID != null)
			{
				strSql.Append("RepairID='"+model.RepairID+"',");
			}
			else
			{
				strSql.Append("RepairID= null ,");
			}
			if (model.UserID != null)
			{
				strSql.Append("UserID='"+model.UserID+"',");
			}
			else
			{
				strSql.Append("UserID= null ,");
			}
			if (model.PartUseNumber != null)
			{
				strSql.Append("PartUseNumber="+model.PartUseNumber+",");
			}
			else
			{
				strSql.Append("PartUseNumber= null ,");
			}
			if (model.PartUseTime != null)
			{
				strSql.Append("PartUseTime='"+model.PartUseTime+"',");
			}
			else
			{
				strSql.Append("PartUseTime= null ,");
			}
			if (model.Partmoney != null)
			{
				strSql.Append("Partmoney='"+model.Partmoney+"',");
			}
			else
			{
				strSql.Append("Partmoney= null ,");
			}
			if (model.tt2 != null)
			{
				strSql.Append("tt2='"+model.tt2+"',");
			}
			else
			{
				strSql.Append("tt2= null ,");
			}
			if (model.tt3 != null)
			{
				strSql.Append("tt3='"+model.tt3+"',");
			}
			else
			{
				strSql.Append("tt3= null ,");
			}
			if (model.tt4 != null)
			{
				strSql.Append("tt4="+model.tt4+",");
			}
			else
			{
				strSql.Append("tt4= null ,");
			}
			if (model.tt5 != null)
			{
				strSql.Append("tt5='"+model.tt5+"',");
			}
			else
			{
				strSql.Append("tt5= null ,");
			}
			if (model.tt6 != null)
			{
				strSql.Append("tt6='"+model.tt6+"',");
			}
			else
			{
				strSql.Append("tt6= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where PartUseRecordID='"+ model.PartUseRecordID+"' ");
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
		public bool Delete(string PartUseRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PartUseRecord ");
			strSql.Append(" where PartUseRecordID='"+PartUseRecordID+"' " );
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
		public bool DeleteList(string PartUseRecordIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PartUseRecord ");
			strSql.Append(" where PartUseRecordID in ("+PartUseRecordIDlist + ")  ");
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
		public Maticsoft.Model.PartUseRecord GetModel(string PartUseRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" PartUseRecordID,PartID,RepairID,UserID,PartUseNumber,PartUseTime,Partmoney,tt2,tt3,tt4,tt5,tt6 ");
			strSql.Append(" from PartUseRecord ");
			strSql.Append(" where PartUseRecordID='"+PartUseRecordID+"' " );
			Maticsoft.Model.PartUseRecord model=new Maticsoft.Model.PartUseRecord();
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
		public Maticsoft.Model.PartUseRecord DataRowToModel(DataRow row)
		{
			Maticsoft.Model.PartUseRecord model=new Maticsoft.Model.PartUseRecord();
			if (row != null)
			{
				if(row["PartUseRecordID"]!=null)
				{
					model.PartUseRecordID=row["PartUseRecordID"].ToString();
				}
				if(row["PartID"]!=null)
				{
					model.PartID=row["PartID"].ToString();
				}
				if(row["RepairID"]!=null)
				{
					model.RepairID=row["RepairID"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["PartUseNumber"]!=null && row["PartUseNumber"].ToString()!="")
				{
					model.PartUseNumber=int.Parse(row["PartUseNumber"].ToString());
				}
				if(row["PartUseTime"]!=null && row["PartUseTime"].ToString()!="")
				{
					model.PartUseTime=DateTime.Parse(row["PartUseTime"].ToString());
				}
				if(row["Partmoney"]!=null)
				{
                    model.Partmoney = decimal.Parse( row["Partmoney"].ToString());
				}
				if(row["tt2"]!=null)
				{
					model.tt2=row["tt2"].ToString();
				}
				if(row["tt3"]!=null)
				{
					model.tt3=row["tt3"].ToString();
				}
				if(row["tt4"]!=null && row["tt4"].ToString()!="")
				{
					model.tt4=(byte[])row["tt4"];
				}
				if(row["tt5"]!=null)
				{
					model.tt5=row["tt5"].ToString();
				}
				if(row["tt6"]!=null)
				{
					model.tt6=row["tt6"].ToString();
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
			strSql.Append("select PartUseRecordID,PartID,RepairID,UserID,PartUseNumber,PartUseTime,Partmoney,tt2,tt3,tt4,tt5,tt6 ");
			strSql.Append(" FROM PartUseRecord ");
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
			strSql.Append(" PartUseRecordID,PartID,RepairID,UserID,PartUseNumber,PartUseTime,Partmoney,tt2,tt3,tt4,tt5,tt6 ");
			strSql.Append(" FROM PartUseRecord ");
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
			strSql.Append("select count(1) FROM PartUseRecord ");
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
				strSql.Append("order by T.PartUseRecordID desc");
			}
			strSql.Append(")AS Row, T.*  from PartUseRecord T ");
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

        public DataSet GetListw1(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM PartUseRecord a,UsersInfo b where a.UserID = b.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

