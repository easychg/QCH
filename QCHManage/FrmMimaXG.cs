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
    public partial class FrmMimaXG : Form
    {
        public FrmMimaXG()
        {
            InitializeComponent();
        }

        private void FrmMimaXG_Load(object sender, EventArgs e)
        {
            LblInfo.Text = "您的用户身份是： " + ConnectionManger.UserName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string mimastr = "";
            string str;
            if (TxtNewMima1.Text != TxtNewMima2.Text)
            {
                MessageBox.Show("新密码输入不一致！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNewMima1.Text = "";
                TxtNewMima2.Text = "";
                return;
            }

            str = "select * from user_table where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + ConnectionManger.UserName + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                mimastr = dt.Rows[0]["user_pwd"].ToString();
            }
            dt.Dispose();

            if (TxtOldMima.Text != mimastr)
            {
                MessageBox.Show("密码输入不正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtOldMima.Text = "";
                TxtNewMima1.Text = "";
                TxtNewMima2.Text = "";
                return;
            }
            try
            {
                str = "update user_table set user_pwd = '" + TxtNewMima1.Text + "' where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + ConnectionManger.UserName + "'";
                SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                MessageBox.Show("密码修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("密码修改失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
