using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QCHManage.Operation
{
    public class Delete
    {
        /// <summary>
        /// 根据信息删除流程名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int delete_FlowNews(string id)
        {
            string sql = "delete from FlowNews where fn_id='" + id + "'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 根据 品名删除流程信息
        /// </summary>
        /// <param name="panme"></param>
        /// <returns></returns>
        public int delete_FlowSet_fs_pname(string panme)
        {
            string sql = "delete from FlowSet where fs_pname='" + panme + "' and fs_area='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }


        /// <summary>
        /// 主界面中删除
        /// </summary>
        /// <param name="bdh"></param>
        /// <returns></returns>
        public int delete_CZJL_bdh(string bdh,double  jz,string code,int bj)
        {
            string sql = "proc_delete_CZJL";
            SqlParameter[] parm = {
                                      new SqlParameter("@cz_dh",SqlDbType.VarChar,100),
                                      new SqlParameter("@cz_jz",SqlDbType.Decimal,18),
                                      new SqlParameter("@cn_code",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_szq",SqlDbType.VarChar,50),
                                      new SqlParameter("@bj",SqlDbType.Int)
                                  };
            parm[0].Value = bdh;
            parm[1].Value = jz;
            parm[2].Value = code;
            parm[3].Value = ConnectionManger.G_MineArea;
            parm[4].Value = bj;
            //string sql = "delete from CZJL where cz_dh='" + bdh + "' and cz_szq='" + ConnectionManger.G_MineArea + "' delete from Flow where fw_bdh='" + bdh + "' and fw_area='" + ConnectionManger.G_MineArea + "' delete from CZPhoto where p_bdh='" + bdh + "' and p_area='"+ConnectionManger.G_MineArea+"'";
            return SQLHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, parm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int delete_FlowNews_id(string id)
        {
            string sql = "delete from FlowNews where fn_id='" + id + "'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        public int delete_CarManage(string cm_kcode)
        {
            string sql = "delete from CarManage where cm_kcode='" + cm_kcode + "' and cm_szqy='" + ConnectionManger.G_MineArea + "' and cn_code<>(select cn_code from ContractNews where cn_hwmc = '石头' and cn_area = '" + ConnectionManger.G_MineArea
                + "')   delete from Flow where fw_kh='" + cm_kcode + "' and fw_area='" + ConnectionManger.G_MineArea + "' and fw_bdh<>(select top 1 cz_dh from CZJL where gn_name = '石头' and cz_szq = '" + ConnectionManger.G_MineArea + "' and cz_kh='" + cm_kcode + "' order by cz_inserttime desc)";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }
    }
}
