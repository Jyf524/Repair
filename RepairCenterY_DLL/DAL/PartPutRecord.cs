/**  版本信息模板在安装目录下，可自行修改。
* PartPutRecord.cs
*
* 功 能： N/A
* 类 名： PartPutRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 11:05:35   N/A    初版
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
	/// 数据访问类:PartPutRecord
	/// </summary>
	public partial class PartPutRecord
	{
		public PartPutRecord()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PartPutRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PartPutRecord");
			strSql.Append(" where PartPutRecordID='"+PartPutRecordID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.PartPutRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PartPutRecordID != null)
			{
				strSql1.Append("PartPutRecordID,");
				strSql2.Append("'"+model.PartPutRecordID+"',");
			}
			if (model.PartID != null)
			{
				strSql1.Append("PartID,");
				strSql2.Append("'"+model.PartID+"',");
			}
			if (model.PartPutNumber != null)
			{
				strSql1.Append("PartPutNumber,");
				strSql2.Append(""+model.PartPutNumber+",");
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
			if (model.PartSource != null)
			{
				strSql1.Append("PartSource,");
				strSql2.Append("'"+model.PartSource+"',");
			}
			if (model.PartPrice != null)
			{
				strSql1.Append("PartPrice,");
				strSql2.Append(""+model.PartPrice+",");
			}
			if (model.PartPutTime != null)
			{
				strSql1.Append("PartPutTime,");
				strSql2.Append("'"+model.PartPutTime+"',");
			}
			if (model.yyy1 != null)
			{
				strSql1.Append("yyy1,");
				strSql2.Append("'"+model.yyy1+"',");
			}
			if (model.yyy2 != null)
			{
				strSql1.Append("yyy2,");
				strSql2.Append("'"+model.yyy2+"',");
			}
			if (model.yyy3 != null)
			{
				strSql1.Append("yyy3,");
				strSql2.Append("'"+model.yyy3+"',");
			}
			if (model.yyy4 != null)
			{
				strSql1.Append("yyy4,");
				strSql2.Append("'"+model.yyy4+"',");
			}
			if (model.yyy15 != null)
			{
				strSql1.Append("yyy15,");
				strSql2.Append("'"+model.yyy15+"',");
			}
			strSql.Append("insert into PartPutRecord(");
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
		public bool Update(Maticsoft.Model.PartPutRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PartPutRecord set ");
			if (model.PartID != null)
			{
				strSql.Append("PartID='"+model.PartID+"',");
			}
			else
			{
				strSql.Append("PartID= null ,");
			}
			if (model.PartPutNumber != null)
			{
				strSql.Append("PartPutNumber="+model.PartPutNumber+",");
			}
			else
			{
				strSql.Append("PartPutNumber= null ,");
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
				strSql.Append("PartPrice="+model.PartPrice+",");
			}
			else
			{
				strSql.Append("PartPrice= null ,");
			}
			if (model.PartPutTime != null)
			{
				strSql.Append("PartPutTime='"+model.PartPutTime+"',");
			}
			else
			{
				strSql.Append("PartPutTime= null ,");
			}
			if (model.yyy1 != null)
			{
				strSql.Append("yyy1='"+model.yyy1+"',");
			}
			else
			{
				strSql.Append("yyy1= null ,");
			}
			if (model.yyy2 != null)
			{
				strSql.Append("yyy2='"+model.yyy2+"',");
			}
			else
			{
				strSql.Append("yyy2= null ,");
			}
			if (model.yyy3 != null)
			{
				strSql.Append("yyy3='"+model.yyy3+"',");
			}
			else
			{
				strSql.Append("yyy3= null ,");
			}
			if (model.yyy4 != null)
			{
				strSql.Append("yyy4='"+model.yyy4+"',");
			}
			else
			{
				strSql.Append("yyy4= null ,");
			}
			if (model.yyy15 != null)
			{
				strSql.Append("yyy15='"+model.yyy15+"',");
			}
			else
			{
				strSql.Append("yyy15= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where PartPutRecordID='"+ model.PartPutRecordID+"' ");
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
		public bool Delete(string PartPutRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PartPutRecord ");
			strSql.Append(" where PartPutRecordID='"+PartPutRecordID+"' " );
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
		public bool DeleteList(string PartPutRecordIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PartPutRecord ");
			strSql.Append(" where PartPutRecordID in ("+PartPutRecordIDlist + ")  ");
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
		public Maticsoft.Model.PartPutRecord GetModel(string PartPutRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" PartPutRecordID,PartID,PartPutNumber,PartModel,PartPicture,PartSource,PartPrice,PartPutTime,yyy1,yyy2,yyy3,yyy4,yyy15 ");
			strSql.Append(" from PartPutRecord ");
			strSql.Append(" where PartPutRecordID='"+PartPutRecordID+"' " );
			Maticsoft.Model.PartPutRecord model=new Maticsoft.Model.PartPutRecord();
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
		public Maticsoft.Model.PartPutRecord DataRowToModel(DataRow row)
		{
			Maticsoft.Model.PartPutRecord model=new Maticsoft.Model.PartPutRecord();
			if (row != null)
			{
				if(row["PartPutRecordID"]!=null)
				{
					model.PartPutRecordID=row["PartPutRecordID"].ToString();
				}
				if(row["PartID"]!=null)
				{
					model.PartID=row["PartID"].ToString();
				}
				if(row["PartPutNumber"]!=null && row["PartPutNumber"].ToString()!="")
				{
					model.PartPutNumber=int.Parse(row["PartPutNumber"].ToString());
				}
				if(row["PartModel"]!=null)
				{
					model.PartModel=row["PartModel"].ToString();
				}
				if(row["PartPicture"]!=null)
				{
					model.PartPicture=row["PartPicture"].ToString();
				}
				if(row["PartSource"]!=null)
				{
					model.PartSource=row["PartSource"].ToString();
				}
				if(row["PartPrice"]!=null && row["PartPrice"].ToString()!="")
				{
					model.PartPrice=decimal.Parse(row["PartPrice"].ToString());
				}
				if(row["PartPutTime"]!=null && row["PartPutTime"].ToString()!="")
				{
					model.PartPutTime=DateTime.Parse(row["PartPutTime"].ToString());
				}
				if(row["yyy1"]!=null)
				{
					model.yyy1=row["yyy1"].ToString();
				}
				if(row["yyy2"]!=null)
				{
					model.yyy2=row["yyy2"].ToString();
				}
				if(row["yyy3"]!=null)
				{
					model.yyy3=row["yyy3"].ToString();
				}
				if(row["yyy4"]!=null)
				{
					model.yyy4=row["yyy4"].ToString();
				}
				if(row["yyy15"]!=null)
				{
					model.yyy15=row["yyy15"].ToString();
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
			strSql.Append("select PartPutRecordID,PartID,PartPutNumber,PartModel,PartPicture,PartSource,PartPrice,PartPutTime,yyy1,yyy2,yyy3,yyy4,yyy15 ");
			strSql.Append(" FROM PartPutRecord ");
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
			strSql.Append(" PartPutRecordID,PartID,PartPutNumber,PartModel,PartPicture,PartSource,PartPrice,PartPutTime,yyy1,yyy2,yyy3,yyy4,yyy15 ");
			strSql.Append(" FROM PartPutRecord ");
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
			strSql.Append("select count(1) FROM PartPutRecord ");
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
				strSql.Append("order by T.PartPutRecordID desc");
			}
			strSql.Append(")AS Row, T.*  from PartPutRecord T ");
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
            strSql.Append(" FROM PartPutRecord a,PartType b,Part c where a.PartID = c.PartID and b.PartTypeID = c.PartTypeID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

		#endregion  Method
		#region  MethodEx

        public DataSet GetListyyy(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("*");
            strSql.Append(" FROM PartPutRecord,PartType,Part ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where part.PartTypeID=PartType.PartTypeID  and PartPutRecord.PartID =Part.PartID and " + strWhere);
            }
            else
            {
                strSql.Append("  where part.PartTypeID=PartType.PartTypeID and  PartPutRecord.PartID =Part.PartID ");
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  MethodEx
        public Maticsoft.Model.PartPutRecord GetModelyyy(string PartID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" PartPutRecordID,PartID,PartPutNumber,PartModel,PartPicture,PartSource,PartPrice,PartPutTime,yyy1,yyy2,yyy3,yyy4,yyy15 ");
            strSql.Append(" from PartPutRecord ");
            strSql.Append(" where PartPutRecordID='" + PartID + "' ");
            Maticsoft.Model.PartPutRecord model = new Maticsoft.Model.PartPutRecord();
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
	}
}

