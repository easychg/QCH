using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QCHManage.Operation
{
    public class Select
    {
        /// <summary>
        /// 实时界面中刷卡后显示
        /// </summary>
        /// <param name="cm_kcode"></param>
        /// <returns></returns>
        public DataTable  bind_CarManage(string cm_kcode)
        {
            string sql = "select * from  CarManage cm inner join ContractNews cn on cm.cn_code=cn.cn_code where cm_kcode='" + cm_kcode + "' and cm.cm_szqy=cn.cn_area and cm_szqy='" + ConnectionManger.G_MineArea + "' ";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

       /// <summary>
       /// 实时界面中显示的数据列表
       /// </summary>
       /// <returns></returns>
        public DataTable bind_CZJL(string szqy)
        {
            string strorder = "";
            if (ConnectionManger.Flow == "进磅")
            {
                strorder = "cz_cpzsj";
            }
            else
            {
                strorder = "cz_cmzsj";
            }
            string sql = "select *,(cn_htzl-cz_yiyun) as syl from CZJL cz inner join ContractNews cn on cz.cn_code=cn.cn_code and cz.cz_szq=cn.cn_area left join Flow fw on cz.cz_dh=fw.fw_bdh where cz_szq='" + szqy + "' and ((convert(datetime,cz_cpzsj) between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' )or (cz_wcbj='未完成'))   order by convert(datetime,"+strorder+") desc   ";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 未完成
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public DataTable bind_CZJL_KH_weiwancheng(string kh)
        {
            string sql = "select * from Flow where fw_bdh=(select top 1 cz_dh from CZJL where cz_kh='" + kh + "'  and  cz_wcbj='未完成'  order by cz_inserttime desc)";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }
        /// <summary>
        /// 查看磅单号并设置磅单号
        /// </summary>
        /// <param name="bdh"></param>
        /// <returns></returns>
        public DataTable bind_bdh(string bdh)
        {
            //string sql = "select top 1 substring(cz_dh,10,4) as bdh from CZJL where substring(cz_dh,0,10)='" + bdh + "'  order by cz_inserttime desc";
            string sql = "select top 1 substring(cz_dh,10,4) as bdh from CZJL where substring(cz_dh,0,10)='" + bdh + "'  and cz_szq='" + ConnectionManger.G_MineArea + "' order by cz_inserttime desc";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        public SqlDataReader read_img()
        {
            string sql = "select  * from CZPhoto";
            return SQLHelper.ExecuteReader(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 在出磅时重复刷卡提示
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public DataTable read_Flow_CZJL_lc(string kh)
        {
            string sql = "select * from Flow where fw_bdh=(select top 1 cz_dh from CZJL where cz_kh='"+kh+"' order by cz_inserttime desc)";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }
        /// <summary>
        /// 南阳坡查看流程
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public DataTable read_Flow_CZJL_lc_nyp(string kh)
        {
            string sql = "select top 1 * from Flow where fw_kh='" + kh + "' and wcbj='未完成' and fw_area='"+ConnectionManger.G_MineArea+"' order by inserttime desc";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 绑定流程
        /// </summary>
        /// <returns></returns>
        public DataTable bind_FlowNews()
        {
            string sql = "select * from FlowNews where fn_area='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 绑定品名
        /// </summary>
        /// <returns></returns>
        public DataTable bind_pinming()
        {
            string sql = "select * from GoodsName where gn_area = '" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }
        /// <summary>
        /// 根据品名查看流程信息
        /// </summary>
        /// <param name="fs_pname"></param>
        /// <returns></returns>
        public SqlDataReader read_FlowSet_fs_pname_flowset(string fs_pname)
        {
            string sql = "select * from FlowSet where fs_area= '" + ConnectionManger.G_MineArea + "' and fs_pname='" + fs_pname + "'";
            return SQLHelper.ExecuteReader(CommandType.Text, sql, null);
        }


        //public DataTable bind_fs_pname_FlowSet(string pname)
        //{ 
        //}

        /// <summary>
        /// 查看是否已经刷过卡
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public DataTable bind_CZJL_cz_kh(string kh)
        {
            string sql = "select * from CZJL where cz_kh='" + kh + "' and cz_wcbj='未完成'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 根据卡号查看时间是否过1分钟
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public DataTable bind_CZJL_bdh_time(string kh)
        {
            string sql = "select * from CZJL where cz_dh=(select top 1 cz_dh from CZJL where cz_kh='" + kh + "' and  cz_wcbj='未完成' and  cz_szq='" + ConnectionManger.G_MineArea + "' order by cz_inserttime desc ) and cz_szq='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }


        /// <summary>
        /// 查看磅单号
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public DataTable bind_bdh_Flow(string kh)
        {
            string sql = "select top 1 * from CZJL where cz_kh='" + kh + "' and cz_szq='" + ConnectionManger.G_MineArea + "' and cz_wcbj='未完成' order by cz_inserttime desc";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 根据磅单号查看流程
        /// </summary>
        /// <param name="bdh"></param>
        /// <returns></returns>
        public DataTable bind_lc_flow(string bdh)
        {
            string sql = "select * from Flow where fw_bdh='" + bdh + "' and fw_area='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 根据卡号查看载重信息
        /// </summary>
        /// <param name="carcode"></param>
        /// <returns></returns>
        public SqlDataReader read_CarManage_cm_bzweight(string kh)
        {
            string sql = "select * from CarManage where cm_kcode='" + kh + "' and cm_szqy='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.ExecuteReader(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 主界面中双击根据自动编号显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable  bind_CZJL_id(string id)
        {
            string sql = "select * from CZJL where cz_id='" + id + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 在添加车辆信息时读取是否有相同的卡号
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public DataTable select_CarManage_kh(string kh)
        {
            string sql = "select * from CarManage where cm_kcode='" + kh + "' and cm_szqy='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 查看品名是否支持打印
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public DataTable select_print_table()
        {
            string sql = "select * from print_table where p_area='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 按收货单位做报表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable bind_gridview1(string where)
        {
            string sql = "select * from CZJL where 1=1" + where + " order by ru_shdw,cz_inserttime desc";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 收货单位
        /// </summary>
        /// <returns></returns>
        public DataTable bind_distinct_shdw()
        {
            string sql = "select distinct ru_shdw from CZJL where cz_szq='"+ConnectionManger.G_MineArea+"'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }
        /// <summary>
        /// 品名
        /// </summary>
        /// <returns></returns>
        public DataTable bind_distinct_pm()
        {
            string sql = "select distinct gn_name from CZJL  where cz_szq='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 绑定流程名称
        /// </summary>
        /// <returns></returns>
        public DataTable bind_FlowNews_fn_area()
        {
            string sql = "select * from FlowNews where fn_area='" + ConnectionManger.G_MineArea + "'";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 根据品名、及区域查看流程
        /// </summary>
        /// <param name="pname"></param>
        /// <returns></returns>
        public DataTable bind_FlowSet_fs_area_fs_pname(string pname)
        {
            string sql = "select * from FlowSet where  fs_area='" + ConnectionManger.G_MineArea + "' and fs_pname='" + pname + "' ";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }




        public DataTable bind_sjhz(string startday,string endday)
        {
            string sql = "select count(*) as carnumber,sum(cz_jz) as sumjz,ru_shdw,gn_name,(cn_htzl-cn_yysl) as syl from CZJL cz inner join ContractNews cn on cn.cn_code=cz.cn_code where cz_szq='" + ConnectionManger.G_MineArea + "' and cn.cn_area=cz.cz_szq and cz_wcbj='完成' and convert(datetime,cz_cmzsj) between '" +
                startday + " 00:00:00' and '" + endday + " 23:59:59' group by ru_shdw,gn_name,(cn_htzl-cn_yysl) ";
            return SQLHelper.GetDataSet(sql, CommandType.Text).Tables[0];
        }

        
    }
}
