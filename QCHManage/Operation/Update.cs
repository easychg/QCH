using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QCHManage.Operation
{
    public class Update
    {
        /// <summary>
        /// 出磅
        /// </summary>
        /// <param name="cz_dh"></param>
        /// <param name="cz_kh"></param>
        /// <param name="cz_mz"></param>
        /// <returns></returns>
        public void update_proc_update_CZJL(string cz_kh, string cz_mz, ref string bdh, ref int returncs, string wcbj, string sby, ref string returnsby, ref float returnpz, ref float returnjz, string cz_jld)
        {
            string sql = "proc_update_CZJL";
            SqlParameter[] parm ={
                                     new SqlParameter("@cz_kh",SqlDbType.VarChar,50),
                                     new SqlParameter("@cz_mz",SqlDbType.VarChar,50),
                                     new SqlParameter("@bdh",SqlDbType.VarChar,50),
                                     new SqlParameter("@returncs",SqlDbType.Int),
                                     new SqlParameter("@wcbj",SqlDbType.VarChar,50),
                                     new SqlParameter("@cz_szq",SqlDbType.VarChar,50),
                                     new SqlParameter("@cz_sby",SqlDbType.VarChar,50),
                                     new SqlParameter("@returnsby",SqlDbType.VarChar,50),
                                     new SqlParameter("@returnpz",SqlDbType.Float ),
                                     new SqlParameter("@returnjz",SqlDbType.Float),
                                     new SqlParameter("@cz_jld",SqlDbType.VarChar,50)

                                };
            parm[2].Direction = ParameterDirection.Output;
            parm[3].Direction = ParameterDirection.Output;
            parm[7].Direction = ParameterDirection.Output;
            parm[8].Direction = ParameterDirection.Output;
            parm[9].Direction = ParameterDirection.Output;
            parm[0].Value = cz_kh;
            parm[1].Value = cz_mz;
            parm[4].Value = wcbj;
            parm[5].Value = ConnectionManger.G_MineArea;
            parm[6].Value = sby;
            parm[10].Value = cz_jld;
          


            SQLHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, parm);
            bdh = parm[2].Value.ToString();
            returncs =int.Parse( parm[3].Value.ToString());
            returnsby = parm[7].Value.ToString();
            returnpz = float.Parse(parm[8].Value.ToString());
            returnjz = float.Parse(parm[9].Value.ToString());
        }
        /// <summary>
        /// 根据磅单号修改流程
        /// </summary>
        /// <param name="bdh"></param>
        /// <param name="flowbj"></param>
        /// <returns></returns>
        public int update_Flow_bdh(string bdh,string flowbj,string wc)
        {
            //string sql = "update Flow set fw_lcjd='" + flowbj + "(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")',fw_flow='" + flowbj + "',inserttime=getdate(),wcbj='"+wc+"' where fw_bdh='" + bdh + "'";

            string sql = "update Flow set fw_lcjd=(select fw_lcjd from Flow where fw_bdh='" + bdh + "')+'" + flowbj + "(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")',fw_flow=(select fw_flow from Flow where fw_bdh='" + bdh + "')+'" + flowbj + "',wcbj='" + wc + "',updatetime=getdate() where fw_bdh='" + bdh + "'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 预称重
        /// </summary>
        /// <param name="cz_dh"></param>
        /// <param name="cz_ycmz"></param>
        /// <returns></returns>
        public int update_CZJL_cz_dh(string cz_dh, string cz_ycmz)
        {
            string sql = "update CZJL set cz_ycmz='" + cz_ycmz + "',cz_ycmzsj='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where cz_dh='" + cz_dh + "'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);

        }
        /// <summary>
        /// 出场时把标记改成完成
        /// </summary>
        /// <param name="bdh"></param>
        /// <returns></returns>
        public int update_CZJL_cz_wcbj(string bdh)
        {
            string sql = "update CZJL set cz_wcbj='完成' where cz_dh='" + bdh + "'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 在出场时把车辆改为完成
        /// </summary>
        /// <param name="cm_kcode"></param>
        /// <returns></returns>
        public int update_CarManage_cm_complete(string cm_kcode)
        {
            string sql = "update CarManage set cm_complete='完成' where cm_kcode='" + cm_kcode + "' and cm_szqy='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 实时界面根据id进行修改称重数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int update_CZJL_id(string id,string mz,string pz,string jz)
        {
            string sql = "update CZJL set cz_mz='" + mz + "',cz_pz='" + pz + "',cz_jz='" + jz + "' where cz_id='"+id+"'";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 修改预称毛重
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public int update_CZJL_id_YC(string kh,string ycmz)
        {
            string sql = "update CZJL set cz_ycmz='"+ycmz+"'' ,cz_cpzsj='"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"' where cz_id=(  select top 1 cz_id  from CZJL where cz_kh='"+kh+"' and cz_wcbj='未完成' order by cz_inserttime desc)";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 主界面中修改过磅数据
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="name"></param>
        /// <param name="gwdw"></param>
        /// <param name="mz"></param>
        /// <param name="pz"></param>
        /// <param name="jz"></param>
        /// <param name="shdw"></param>
        /// <param name="szq"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int proc_update_czjl_list(string ch, string name, string gwdw, double mz, double pz, double jz, string shdw, string szq, string id, string cz_sby)
        {
            string sql = "proc_update_czjl_list";
            SqlParameter[] parm = {
                                      new SqlParameter("@cz_ch",SqlDbType.VarChar,50),
                                      
                                      new SqlParameter("@cz_mz",SqlDbType.Decimal,18),
                                      new SqlParameter("@cz_pz",SqlDbType.Decimal,18),
                                      new SqlParameter("@cz_jz",SqlDbType.Decimal,18),
                                    
                                      new SqlParameter("@cz_szq",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_id",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_sby",SqlDbType.VarChar,50),
                                      new SqlParameter("@gn_name",SqlDbType.VarChar,50),
                                      new SqlParameter("@ru_shdw",SqlDbType.VarChar,50)


                                  };
            parm[0].Value = ch;

            parm[1].Value = mz;
            parm[2].Value = pz;
            parm[3].Value = jz;

            parm[4].Value = szq;
            parm[5].Value = id;
            parm[6].Value = cz_sby;
            parm[7].Value = name;
            parm[8].Value = shdw;

            return SQLHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, parm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hth"></param>
        /// <param name="id"></param>
        /// <param name="mz"></param>
        /// <param name="pz"></param>
        /// <param name="jz"></param>
        /// <param name="ch"></param>
        /// <param name="jsy"></param>
        /// <param name="sby"></param>
        /// <returns></returns>
        public int proc_update_czjl_contract_carmanage(string hth, string id, double mz, double pz, double jz, string ch, string jsy, string sby, string szq)
        {
            string sql = "proc_update_czjl_contract_carmanage";
            SqlParameter[] parm = {
                                      new SqlParameter("@cn_code",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_id",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_mz",SqlDbType.Decimal,18),
                                      new SqlParameter("@cz_pz",SqlDbType.Decimal,18),
                                      new SqlParameter("@cz_jz",SqlDbType.Decimal,18),
                                      new SqlParameter("@cz_ch",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_jsy",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_sby",SqlDbType.VarChar,50),
                                      new SqlParameter("@cz_szq",SqlDbType.VarChar,50)
                                  };
            parm[0].Value = hth;
            parm[1].Value = id;
            parm[2].Value = mz;
            parm[3].Value = pz;
            parm[4].Value = jz;
            parm[5].Value = ch;
            parm[6].Value = jsy;
            parm[7].Value = sby;
            parm[8].Value = szq;
            return SQLHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, parm);
        }
    }
}
