using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QCHManage.Operation
{
    public class Insert
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="bdh"></param>
        /// <param name="photo"></param>
        /// <returns></returns>
        public int insert_Photo(string bdh,byte[] photo)
        {
            string sql = "proc_insert_CZPhoto";
            SqlParameter[] parm = {
                                      new SqlParameter("@p_bdh",SqlDbType.VarChar,50),
                                      new SqlParameter("@p_photo",SqlDbType.Image   ),
                                      new SqlParameter("@p_area",SqlDbType.VarChar)

                                  };
            parm[0].Value = bdh;
            parm[1].Value = photo;
            parm[2].Value = ConnectionManger.G_MineArea;
            return SQLHelper.ExecuteNonQuery(CommandType.StoredProcedure , sql, parm);
        
        }

        /// <summary>
        /// 添加称重数据
        /// </summary>
        /// <param name="czszq">所在区域</param>
        /// <param name="cz_dh">磅单号</param>
        /// <param name="cz_ch">车号</param>
        /// <param name="cz_kh">卡号</param>
        /// <param name="cz_jsy">驾驶员</param>
       /// <param name="gn_name">品名</param>
        /// <param name="cz_mz">毛重</param>
        /// <param name="cz_pz">皮重</param>
        /// <param name="cz_jz">净重</param>
        /// <param name="cz_ycmz">预称毛重</param>
        /// <param name="cz_ycjz">预称净重</param>
        /// <param name="cn_code">合同编号</param>
        /// <param name="cz_sby">司磅员</param>
        /// <param name="cz_jcsj">进厂时间</param>
        /// <param name="cz_ccsj">出厂时间</param>
        /// <param name="cz_cpzsj">称皮重时间</param>
        /// <param name="cz_cmzsj">称毛重时间</param>
        /// <param name="cz_ycmzsj">预称毛重时间</param>
        /// <param name="cz_jld">计量点</param>
        /// <param name="cz_wcbj">完成标记</param>
        /// <param name="cz_gwdw">供货单位</param>
        /// <param name="ru_shdw">收货单位</param>
    
        /// <returns></returns>
        public int insert_CZJL(string czszq,string cz_dh,string cz_ch,string cz_kh,string cz_jsy,string gn_name,string cz_mz,string cz_pz,string cz_jz,string cz_ycmz,string cz_ycjz,string cn_code,string cz_sby,string cz_jcsj,string cz_ccsj,string cz_cpzsj,string cz_cmzsj,string cz_ycmzsj,string cz_jld,string cz_wcbj,string cz_gwdw,string ru_shdw)
        {
            string sql = "insert into CZJL(cz_szq,cz_dh,cz_ch,cz_kh,cz_jsy,gn_name,cz_mz,cz_pz,cz_jz,cz_ycmz,cz_ycjz,cn_code,cz_sby,cz_jcsj,cz_ccsj,cz_cpzsj,cz_cmzsj,cz_ycmzsj,cz_jld,cz_wcbj,cz_gwdw,ru_shdw,cz_inserttime) values ('" + czszq + "','" + cz_dh + "','" + cz_ch + "','" + cz_kh + "','" + cz_jsy + "','" + gn_name + "'," + cz_mz + "," + cz_pz + "," + cz_jz + ",'" + cz_ycmz + "','" + cz_ycjz + "','" + cn_code + "','" + cz_sby + "','" + cz_jcsj + "','" + cz_ccsj + "','" + cz_cpzsj + "','" + cz_cmzsj + "','" + cz_ycmzsj + "','" + cz_jld + "','" + cz_wcbj + "','" + cz_gwdw + "','" + ru_shdw + "',getdate())";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 添加流程
        /// </summary>
        /// <param name="bdh"></param>
        /// <param name="flow"></param>
        /// <returns></returns>
        public int insert_Flow(string bdh, string flow, string fw, string fw_ch)
        {
            string sql = "insert into Flow(fw_bdh,fw_lcjd,fw_flow,fw_area,wcbj,inserttime,fw_kh) values('" + bdh + "','" + flow + "','" + fw + "','" + ConnectionManger.G_MineArea + "','未完成',getdate(),'" + fw_ch + "')";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 添加 流程信息
        /// </summary>
        /// <param name="fn_name"></param>
        /// <param name="fn_type"></param>
        /// <returns></returns>
        public int insert_FlowNews(string fn_name, string fn_type)
        {
            string sql = "insert into FlowNews(fn_area,fn_name,fn_type) values('" + ConnectionManger.G_MineArea + "','" + fn_name + "','" + fn_type + "')";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }


        /// <summary>
        /// 添加流程设置
        /// </summary>
        /// <param name="fs_pname"></param>
        /// <param name="fs_flowset"></param>
        /// <returns></returns>
        public int insert_FlowSet(string fs_pname, string fs_flowset)
        {
            string sql = "insert into FlowSet(fs_flowset,fs_area,fs_pname) values('" + fs_flowset + "','" + ConnectionManger.G_MineArea + "','" + fs_pname + "')";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="address"></param>
        /// <param name="st_redline1"></param>
        /// <param name="st_redline2"></param>
        /// <param name="st_gan1"></param>
        /// <param name="st_gan2"></param>
        /// <returns></returns>
        public int insert_StatusTable(string address, int st_redline1, int st_redline2, int st_gan1, int st_gan2)
        {
            string sql = "if (select count(*) from StatusTable where st_area='" + ConnectionManger.G_MineArea + "' and st_address='" + address + "')>0 update StatusTable set st_redline1='" + st_redline1 + "',st_redline2='" + st_redline2 + "',st_gan1='" + st_gan1 + "',st_gan2='" + st_gan2 + "' else insert into StatusTable(st_area,st_address,st_redline1,st_redline2,st_gan1,st_gan2) values('" + ConnectionManger.G_MineArea + "','"+address+"','"+st_redline1+"','"+st_redline2+"','"+st_gan1+"','"+st_gan2+"')";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 添加流程名称
        /// </summary>
        /// <param name="fn_area"></param>
        /// <param name="fn_name"></param>
        /// <returns></returns>
        public int insert_FlowNews( string fn_name)
        {
            string sql = "insert into FlowNews(fn_area,fn_name) values('" + ConnectionManger.G_MineArea + "','" + fn_name + "')";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 添加状态
        /// </summary>

        /// <param name="st_bj">此为标记位，1为遥控器打开，2为刷卡打开</param>
        /// <returns></returns>
        public int insert_StatusTable(string address, string st_type, int st_status1, int st_status2, int st_bj)
        {
            string sql = " insert into StatusTable(st_area,st_address,st_type,st_status1,st_status2,st_inserttime,st_bj) values('" + ConnectionManger.G_MineArea + "','" + address + "','" + st_type + "','" + st_status1 + "','" + st_status2 + "',getdate(),'" + st_bj + "')";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 添加图片路径
        /// </summary>
        /// <param name="bdh"></param>
        /// <param name="photopath"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public int insert_PhotoPath(string bdh, string photopath)
        {
            string sql = "insert into PhotoPath(p_bdh,p_photopath,p_area) values ('" + bdh + "','" + photopath + "','" + ConnectionManger.G_MineArea + "')";
            return SQLHelper.ExecuteNonQuery(CommandType.Text, sql, null);

        }
    }
}
