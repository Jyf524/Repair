/**  版本信息模板在安装目录下，可自行修改。
* PartType.cs
*
* 功 能： N/A
* 类 名： PartType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 10:34:31   N/A    初版
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
	/// 数据访问类:PartType
	/// </summary>
	public partial class PartType
	{
		public PartType()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PartTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PartType");
			strSql.Append(" where PartTypeID='"+PartTypeID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.PartType model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PartTypeID != null)
			{
				strSql1.Append("PartTypeID,");
				strSql2.Append("'"+model.PartTypeID+"',");
			}
			if (model.PartTypeName != null)
			{
				strSql1.Append("PartTypeName,");
				strSql2.Append("'"+model.PartTypeName+"',");
			}
			if (model.PartTypeAddTime != null)
			{
				strSql1.Append("PartTypeAddTime,");
				strSql2.Append("'"+model.PartTypeAddTime+"',");
			}
			if (model.PartTypePicture != null)
			{
				strSql1.Append("PartTypePicture,");
				strSql2.Append("'"+model.PartTypePicture+"',");
			}
			if (model.PartTypeIntroduction != null)
			{
				strSql1.Append("PartTypeIntroduction,");
				strSql2.Append("'"+model.PartTypeIntroduction+"',");
			}
			if (model.HHH1 != null)
			{
				strSql1.Append("HHH1,");
				strSql2.Append("'"+model.HHH1+"',");
			}
			if (model.HHH2 != null)
			{
				strSql1.Append("HHH2,");
				strSql2.Append("'"+model.HHH2+"',");
			}
			if (model.HHH3 != null)
			{
				strSql1.Append("HHH3,");
				strSql2.Append("'"+model.HHH3+"',");
			}
			if (model.HHH4 != null)
			{
				strSql1.Append("HHH4,");
				strSql2.Append("'"+model.HHH4+"',");
			}
			if (model.HHH5 != null)
			{
				strSql1.Append("HHH5,");
				strSql2.Append("'"+model.HHH5+"',");
			}
			strSql.Append("insert into PartType(");
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
		public bool Update(Maticsoft.Model.PartType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PartType set ");
			if (model.PartTypeName != null)
			{
				strSql.Append("PartTypeName='"+model.PartTypeName+"',");
			}
			else
			{
				strSql.Append("PartTypeName= null ,");
			}
			if (model.PartTypeAddTime != null)
			{
				strSql.Append("PartTypeAddTime='"+model.PartTypeAddTime+"',");
			}
			else
			{
				strSql.Append("PartTypeAddTime= null ,");
			}
			if (model.PartTypePicture != null)
			{
				strSql.Append("PartTypePicture='"+model.PartTypePicture+"',");
			}
			else
			{
				strSql.Append("PartTypePicture= null ,");
			}
			if (model.PartTypeIntroduction != null)
			{
				strSql.Append("PartTypeIntroduction='"+model.PartTypeIntroduction+"',");
			}
			else
			{
				strSql.Append("PartTypeIntroduction= null ,");
			}
			if (model.HHH1 != null)
			{
				strSql.Append("HHH1='"+model.HHH1+"',");
			}
			else
			{
				strSql.Append("HHH1= null ,");
			}
			if (model.HHH2 != null)
			{
				strSql.Append("HHH2='"+model.HHH2+"',");
			}
			else
			{
				strSql.Append("HHH2= null ,");
			}
			if (model.HHH3 != null)
			{
				strSql.Append("HHH3='"+model.HHH3+"',");
			}
			else
			{
				strSql.Append("HHH3= null ,");
			}
			if (model.HHH4 != null)
			{
				strSql.Append("HHH4='"+model.HHH4+"',");
			}
			else
			{
				strSql.Append("HHH4= null ,");
			}
			if (model.HHH5 != null)
			{
				strSql.Append("HHH5='"+model.HHH5+"',");
			}
			else
			{
				strSql.Append("HHH5= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where PartTypeID='"+ model.PartTypeID+"' ");
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
		public bool Delete(string PartTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PartType ");
			strSql.Append(" where PartTypeID='"+PartTypeID+"' " );
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
		public bool DeleteList(string PartTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PartType ");
			strSql.Append(" where PartTypeID in ("+PartTypeIDlist + ")  ");
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
		public Maticsoft.Model.PartType GetModel(string PartTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" PartTypeID,PartTypeName,PartTypeAddTime,PartTypePicture,PartTypeIntroduction,HHH1,HHH2,HHH3,HHH4,HHH5 ");
			strSql.Append(" from PartType ");
			strSql.Append(" where PartTypeID='"+PartTypeID+"' " );
			Maticsoft.Model.PartType model=new Maticsoft.Model.PartType();
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
		public Maticsoft.Model.PartType DataRowToModel(DataRow row)
		{
			Maticsoft.Model.PartType model=new Maticsoft.Model.PartType();
			if (row != null)
			{
				if(row["PartTypeID"]!=null)
				{
					model.PartTypeID=row["PartTypeID"].ToString();
				}
				if(row["PartTypeName"]!=null)
				{
					model.PartTypeName=row["PartTypeName"].ToString();
				}
				if(row["PartTypeAddTime"]!=null && row["PartTypeAddTime"].ToString()!="")
				{
					model.PartTypeAddTime=DateTime.Parse(row["PartTypeAddTime"].ToString());
				}
				if(row["PartTypePicture"]!=null)
				{
					model.PartTypePicture=row["PartTypePicture"].ToString();
				}
				if(row["PartTypeIntroduction"]!=null)
				{
					model.PartTypeIntroduction=row["PartTypeIntroduction"].ToString();
				}
				if(row["HHH1"]!=null)
				{
					model.HHH1=row["HHH1"].ToString();
				}
				if(row["HHH2"]!=null)
				{
					model.HHH2=row["HHH2"].ToString();
				}
				if(row["HHH3"]!=null)
				{
					model.HHH3=row["HHH3"].ToString();
				}
				if(row["HHH4"]!=null)
				{
					model.HHH4=row["HHH4"].ToString();
				}
				if(row["HHH5"]!=null)
				{
					model.HHH5=row["HHH5"].ToString();
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
			strSql.Append("select PartTypeID,PartTypeName,PartTypeAddTime,PartTypePicture,PartTypeIntroduction,HHH1,HHH2,HHH3,HHH4,HHH5 ");
			strSql.Append(" FROM PartType ");
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
			strSql.Append(" PartTypeID,PartTypeName,PartTypeAddTime,PartTypePicture,PartTypeIntroduction,HHH1,HHH2,HHH3,HHH4,HHH5 ");
			strSql.Append(" FROM PartType ");
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
			strSql.Append("select count(1) FROM PartType ");
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
				strSql.Append("order by T.PartTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from PartType T ");
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

