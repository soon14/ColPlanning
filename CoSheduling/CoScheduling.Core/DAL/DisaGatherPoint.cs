﻿//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区交点数据访问类
// 创建时间:2013.12.3
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;

namespace CoScheduling.Core.DAL
{
    /// <summary>
    /// 数据访问类 DisaGatherPoint
    /// </summary>
    public class DisaGatherPoint
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.DisaGatherPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO DisaGatherPoint(");
            strSql.Append("PID,PName,LAT,LON)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_PID,@in_PName,@in_LAT,@in_LON)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                 new SqlParameter("@in_PID", SqlDbType.Int),
				 new SqlParameter("@in_PName", SqlDbType.NVarChar),
				 new SqlParameter("@in_LAT", SqlDbType.Decimal),
				 new SqlParameter("@in_LON", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.PName;
            cmdParms[2].Value = model.LAT;
            cmdParms[3].Value = model.LON;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.DisaGatherPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE DisaGatherPoint SET ");
            strSql.Append("PID=@in_PID,");
            strSql.Append("PName=@in_PName,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("LON=@in_LON");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                 new SqlParameter("@in_PID", SqlDbType.Int),
				 new SqlParameter("@in_PName", SqlDbType.NVarChar),
				 new SqlParameter("@in_LAT", SqlDbType.Decimal),
				 new SqlParameter("@in_LON", SqlDbType.Decimal),
				 new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.PName;
            cmdParms[2].Value = model.LAT;
            cmdParms[3].Value = model.LON;
            cmdParms[4].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Updates(Model.DisaGatherPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE DisaGatherPoint SET ");
            strSql.Append("PName=@in_PName");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				 new SqlParameter("@in_PName", SqlDbType.NVarChar),
				 new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.PName;
            cmdParms[1].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        public int Updatecount(Model.DisaGatherPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE DisaGatherPoint SET ");
            strSql.Append("UCount=@in_UCount");
            strSql.Append(" WHERE PName=@in_PName");
            SqlParameter[] cmdParms = new SqlParameter[]{
				 new SqlParameter("@in_UCount", SqlDbType.Int),
				 new SqlParameter("@in_PName", SqlDbType.NVarChar)};

            cmdParms[0].Value = model.UCount;
            cmdParms[1].Value = model.PName;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM DisaGatherPoint ");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_ID",System.Data.SqlDbType.Int, ID)};
            cmdParms[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据任务区ID删除数据
        /// </summary>
        public int Deletes(int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM DisaGatherPoint ");
            strSql.Append(" WHERE PID=@in_PID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_PID",System.Data.SqlDbType.Int, PID)
                                      };
            cmdParms[0].Value = PID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("DisaGatherPoint");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Core.Model.DisaGatherPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM DisaGatherPoint");
            strSql.Append(" WHERE PName='" + model.PName + "' AND ID<>" + model.ID + " and PID=" + model.PID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.DisaGatherPoint GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DisaGatherPoint ");
            strSql.Append(" WHERE ID=" + ID);
            Model.DisaGatherPoint model = null;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    model = GetModel(dr);
                }
                return model;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.DisaGatherPoint> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM DisaGatherPoint");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.DisaGatherPoint> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.DisaGatherPoint> GetList(int pid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM DisaGatherPoint where PID=" + pid );
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.DisaGatherPoint> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("DisaGatherPoint", condition);
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM DisaGatherPoint");
            if (!string.IsNullOrEmpty(WhereClause))
                strSql.Append(" where " + WhereClause);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                if (dr.Read())
                {
                    int cnt = int.Parse(dr[0].ToString());
                    return (int)Math.Ceiling((double)(Convert.ToDouble(cnt.ToString()) / Convert.ToDouble(PageSize.ToString())));
                }
                else return 0;
            }
        }

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public List<Model.DisaGatherPoint> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                            "    FROM " +
                                       " ( " +
                                       " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM DisaGatherPoint "
                                            + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                        ") A " +
                                "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.DisaGatherPoint> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.DisaGatherPoint GetModel(DbDataReader dr)
        {
            Model.DisaGatherPoint model = new Model.DisaGatherPoint();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.PName = DbHelperSQL.GetString(dr["PName"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.DisaGatherPoint> GetList(DbDataReader dr)
        {
            List<Model.DisaGatherPoint> lst = new List<Model.DisaGatherPoint>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
