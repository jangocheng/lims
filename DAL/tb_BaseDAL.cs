﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace DAL
{
    /// <summary>
    /// 数据访问类:tb_Base
    /// </summary>
    public class tb_BaseDAL
    {
        public tb_BaseDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Base");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(tb_Base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Base(");
            strSql.Append("pId,baseName,temp1,temp2)");
            strSql.Append(" values (");
            strSql.Append("@pId,@baseName,@temp1,@temp2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pId", SqlDbType.Int,4),
					new SqlParameter("@baseName", SqlDbType.NVarChar,200),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text)};
            parameters[0].Value = model.pId;
            parameters[1].Value = model.baseName;
            parameters[2].Value = model.temp1;
            parameters[3].Value = model.temp2;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(tb_Base model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Base set ");
            strSql.Append("pId=@pId,");
            strSql.Append("baseName=@baseName,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@pId", SqlDbType.Int,4),
					new SqlParameter("@baseName", SqlDbType.NVarChar,200),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.pId;
            parameters[1].Value = model.baseName;
            parameters[2].Value = model.temp1;
            parameters[3].Value = model.temp2;
            parameters[4].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Base ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public tb_Base GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,pId,baseName,temp1,temp2 from tb_Base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_Base model = new tb_Base();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public tb_Base DataRowToModel(DataRow row)
        {
            tb_Base model = new tb_Base();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["pId"] != null && row["pId"].ToString() != "")
                {
                    model.pId = int.Parse(row["pId"].ToString());
                }
                if (row["baseName"] != null)
                {
                    model.baseName = row["baseName"].ToString();
                }
                if (row["temp1"] != null)
                {
                    model.temp1 = row["temp1"].ToString();
                }
                if (row["temp2"] != null)
                {
                    model.temp2 = row["temp2"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pId,baseName,temp1,temp2 ");
            strSql.Append(" FROM tb_Base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public List<tb_Base> GetBaseList()
        {
            List<tb_Base> list = null;
           StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tb_Base  ");
            using (IDbConnection conn = new SqlConnection(PubConstant.GetConnectionString()))
            {
                list = conn.Query<tb_Base>(strSql.ToString())?.ToList();
            }
            return list;
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,pId,baseName,temp1,temp2 ");
            strSql.Append(" FROM tb_Base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_Base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Base T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_Base";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}