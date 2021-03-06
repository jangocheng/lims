﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类:tb_DrugLock
    /// </summary>
    public partial class tb_DrugLockDAL
    {
        public tb_DrugLockDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DrugLock");
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
        public int Add(tb_DrugLock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DrugLock(");
            strSql.Append("temp2,pic,lockName,mark,createUser,createDate,updateUser,updateDate,lockType,temp1");
            strSql.Append(") values (");
            strSql.Append("@temp2,@pic,@lockName,@mark,@createUser,@createDate,@updateUser,@updateDate,@lockType,@temp1");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@temp2", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@pic", SqlDbType.NVarChar,256) ,
                        new SqlParameter("@lockName", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@mark", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@createUser", SqlDbType.Int,4) ,
                        new SqlParameter("@createDate", SqlDbType.DateTime) ,
                        new SqlParameter("@updateUser", SqlDbType.Int,4) ,
                        new SqlParameter("@updateDate", SqlDbType.DateTime) ,
                        new SqlParameter("@lockType", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@temp1", SqlDbType.NVarChar,-1)

            };

            parameters[0].Value = model.temp2;
            parameters[1].Value = model.pic;
            parameters[2].Value = model.lockName;
            parameters[3].Value = model.mark;
            parameters[4].Value = model.createUser;
            parameters[5].Value = model.createDate;
            parameters[6].Value = model.updateUser;
            parameters[7].Value = model.updateDate;
            parameters[8].Value = model.lockType;
            parameters[9].Value = model.temp1;

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
        public bool Update(tb_DrugLock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DrugLock set ");

            strSql.Append(" temp2 = @temp2 , ");
            strSql.Append(" pic = @pic , ");
            strSql.Append(" lockName = @lockName , ");
            strSql.Append(" mark = @mark , ");
            strSql.Append(" createUser = @createUser , ");
            strSql.Append(" createDate = @createDate , ");
            strSql.Append(" updateUser = @updateUser , ");
            strSql.Append(" updateDate = @updateDate , ");
            strSql.Append(" lockType = @lockType , ");
            strSql.Append(" temp1 = @temp1  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.Int,4) ,
                        new SqlParameter("@temp2", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@pic", SqlDbType.NVarChar,256) ,
                        new SqlParameter("@lockName", SqlDbType.NVarChar,-1) ,
                        new SqlParameter("@mark", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@createUser", SqlDbType.Int,4) ,
                        new SqlParameter("@createDate", SqlDbType.DateTime) ,
                        new SqlParameter("@updateUser", SqlDbType.Int,4) ,
                        new SqlParameter("@updateDate", SqlDbType.DateTime) ,
                        new SqlParameter("@lockType", SqlDbType.NVarChar,100) ,
                        new SqlParameter("@temp1", SqlDbType.NVarChar,-1)

            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.temp2;
            parameters[2].Value = model.pic;
            parameters[3].Value = model.lockName;
            parameters[4].Value = model.mark;
            parameters[5].Value = model.createUser;
            parameters[6].Value = model.createDate;
            parameters[7].Value = model.updateUser;
            parameters[8].Value = model.updateDate;
            parameters[9].Value = model.lockType;
            parameters[10].Value = model.temp1;
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
            strSql.Append("delete from tb_DrugLock ");
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
            strSql.Append("delete from tb_DrugLock ");
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
        public tb_DrugLock GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_DrugLock ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_DrugLock model = new tb_DrugLock();
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
        public tb_DrugLock DataRowToModel(DataRow row)
        {
            tb_DrugLock model = new tb_DrugLock();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lockName"] != null)
                {
                    model.lockName = row["lockName"].ToString();
                }
                if (row["mark"] != null)
                {
                    model.mark = row["mark"].ToString();
                }
                if (row["createUser"] != null && row["createUser"].ToString() != "")
                {
                    model.createUser = int.Parse(row["createUser"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["updateUser"] != null && row["updateUser"].ToString() != "")
                {
                    model.updateUser = int.Parse(row["updateUser"].ToString());
                }
                if (row["updateDate"] != null && row["updateDate"].ToString() != "")
                {
                    model.updateDate = DateTime.Parse(row["updateDate"].ToString());
                }
                if (row["lockType"] != null)
                {
                    model.lockType = row["lockType"].ToString();
                }
                if (row["temp1"] != null)
                {
                    model.temp1 = row["temp1"].ToString();
                }
                if (row["temp2"] != null)
                {
                    model.temp2 = row["temp2"].ToString();
                }
                if (row["pic"] != null)
                {
                    model.pic = row["pic"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_DrugLock ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" * ");
            strSql.Append(" FROM tb_DrugLock ");
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
            strSql.Append("select count(1) FROM tb_DrugLock ");
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
            strSql.Append(@")AS Row, T.*  from tb_DrugLock T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetModelList(int _areaid)
        {
            string sql = @"SELECT dbo.tb_DrugLock.* FROM dbo.tb_Area INNER JOIN
                                  dbo.tb_InPersonnel ON dbo.tb_Area.AreaID = dbo.tb_InPersonnel.AreaID INNER JOIN
                                  dbo.tb_DrugLock ON dbo.tb_InPersonnel.PersonnelID = dbo.tb_DrugLock.createUser where tb_Area.AreaID = " + _areaid;
            return DbHelperSQL.Query(sql);
        }
        #endregion  ExtensionMethod


    }
}
