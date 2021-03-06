﻿/**  版本信息模板在安装目录下，可自行修改。
* UsersInfo.cs
*
* 功 能： N/A
* 类 名： UsersInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/5/8 11:05:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// UsersInfo
	/// </summary>
	public partial class UsersInfo
	{
		private readonly Maticsoft.DAL.UsersInfo dal=new Maticsoft.DAL.UsersInfo();
		public UsersInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			return dal.Exists(UserID);
		}
        public bool yonghumingchongfu(string Username)
        {
            return dal.yonghumingchongfu(Username);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.UsersInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.UsersInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string UserID)
		{
			
			return dal.Delete(UserID);
		}
        public bool laoshixueshengyiqigundan(string UserID)
        {

            return dal.laoshixueshengyiqigundan(UserID);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.UsersInfo GetModel(string UserID)
		{
			
			return dal.GetModel(UserID);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.UsersInfo GetModelByCache(string UserID)
		{
			
			string CacheKey = "UsersInfoModel-" + UserID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.UsersInfo)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet shujukudanweilianjie()
        {
            return dal.shujukudanweilianjie();
        }
        public DataSet yonghumingjuese(string username,string juese)
        {
            return dal.yonghumingjuese(username,juese);
        }
        public DataSet yonghumingjueselaoshi(string username, string tianjiashijian1,string tianjiashijian2)
        {
            return dal.yonghumingjueselaoshi(username, tianjiashijian1 ,tianjiashijian2);
        }
        public DataSet yonghumingjuesexitongguanliyuan(string username,string tianjiashijian1, string tianjiashijian2, string shenfen)
        {
            return dal.yonghumingjuesexitongguanliyuan(username, shenfen, tianjiashijian1, tianjiashijian2);
        }
        public DataSet yonghumingjuesexitongguanliyuanquanbu(string username)
        {
            return dal.yonghumingjuesexitongguanliyuanquanbu(username);
        }
        public DataSet yonghumingjuesexuesheng(string username, string tianjiashijian1, string tianjiashijian2,string id)
        {
            return dal.yonghumingjuesexuesheng(username, tianjiashijian1,tianjiashijian2,id);
        }
        public DataSet yonghumingjuese2(string username)
        {
            return dal.yonghumingjuese2(username);
        }
        public DataSet zhidaolaoshi(string strWhere)//zy
        {
            return dal.zhidaolaoshi(strWhere);
        }
        public DataSet xuesheng(string id)//zy
        {
            return dal.xuesheng(id);
        }
        public DataSet yonghudanweilianjie(string strWhere)//zy
        {
            return dal.yonghudanweilianjie(strWhere);
        }
        public DataSet shujukulaoshilianjie()//zy
        {
            return dal.shujukulaoshilianjie();
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.UsersInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.UsersInfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.UsersInfo> modelList = new List<Maticsoft.Model.UsersInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.UsersInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
        public int zuidazhijiayi()
        {
            return dal.zuidazhijiayi();
        }
        public string danweiid(string unitname)
        {
            return dal.danweiid(unitname);
        }
        public string suoshulaoshixingming(string username)
        {
            return dal.suoshulaoshixingming(username);
        }
        public string suoshulaoshiid(string userid)
        {
            return dal.suoshulaoshiid(userid);
        }
        public string danweimingcheng(string userid)
        {
            return dal.danweimingcheng(userid);
        }
        public string danweimingchengpanduan(string userid)
        {
            return dal.danweimingchengpanduan(userid);
        }
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

