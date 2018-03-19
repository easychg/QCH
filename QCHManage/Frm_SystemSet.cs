using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QCHManage
{
    public partial class Frm_SystemSet : Form
    {
        public Frm_SystemSet()
        {
            InitializeComponent();
        }

        private void Frm_SystemSet_Load(object sender, EventArgs e)
        {
            DataTable dt = SQLHelper.GetDataSet("select * from print_table where p_area='"+ConnectionManger.G_MineArea+"'", CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    string p = dt.Rows[0][i + 2].ToString();
                    if (p == "1")
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
           
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] p = new string[9];//存放状态
            for (int i = 0; i < 8; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    p[i] = "1";
                }
                else
                {
                    p[i] = "0";
                }
            }
            string str = "if (select count(*) from print_table where p_area='" + ConnectionManger.G_MineArea + "')>0 update print_table set  p_kuaimei='" + p[0] + "',p_shitou='" + p[1] + "',p_hunmei='" + p[2] + "',P_yuanmei='" + p[3] + "',P_jingmei='" + p[4] + "',p_sanmei='" + p[5] + "',P_meizha='" + p[6] + "',p_weitan='" + p[7] + "' where p_area='" + ConnectionManger.G_MineArea + "' else insert into print_table (p_area,p_kuaimei,p_shitou,p_hunmei,P_yuanmei,P_jingmei,p_sanmei,P_meizha,p_weitan) values('" + ConnectionManger.G_MineArea + "','" + p[0] + "','" + p[1] + "','" + p[2] + "','" + p[3] + "','" + p[4] + "','" + p[5] + "','" + p[6] + "','" + p[7] + "')";
            if (SQLHelper.ExecuteNonQuery(CommandType.Text, str, null) > 0)
            {
                MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
        }
    }
}
