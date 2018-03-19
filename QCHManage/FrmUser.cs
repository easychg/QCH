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
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void UpdateDataGridView1()
        {
            string str = "select user_name,user_pwd,user_lever from user_table where user_area = '" + ConnectionManger.G_MineArea + "' order by user_lever,user_name";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            DataGridView1.DataSource = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            dt.Dispose();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            UpdateDataGridView1();
          
        }
        //添加
        private void Button1_Click(object sender, EventArgs e)
        {
            if (TxtName.Text == "")
            {
                MessageBox.Show("用户名不允许为空！", "添加用户信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtPsw.Text == "")
            {
                MessageBox.Show("密码不允许为空！", "添加用户信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbType.Text == "")
            {
                MessageBox.Show("请选择用户类型！", "添加用户信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string str = "select * from user_table where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + TxtName.Text + "'";
            if (SQLHelper.IsPriExist(str))
            {
                MessageBox.Show("该用户信息已存在！", "添加用户信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                str = "insert into user_table values('" + TxtName.Text + "','" + TxtPsw.Text + "','" + ConnectionManger.G_MineArea + "','" + CmbType.Text + "')";
                SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                ClearUserInfo();
                UpdateDataGridView1();
                MessageBox.Show("户信息添加成功！", "添加用户信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("请检查所填用户信息是否合法！", "用户添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUserInfo()
        {
            TxtName.Text = "";
            TxtPsw.Text = "";
            CmbType.SelectedIndex = -1;
            CmbType.Text = "";
        }
        //修改
        private void Button2_Click(object sender, EventArgs e)
        {
            if (TxtName.Text == "")
            {
                MessageBox.Show("用户名不允许为空！", "用户信息修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtPsw.Text == "")
            {
                MessageBox.Show("密码不允许为空！", "用户信息修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbType.Text == "")
            {
                MessageBox.Show("请选择用户类型！", "用户信息修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string str = "select * from user_table where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + TxtName.Text + "'";
            if (SQLHelper.IsPriExist(str))
            {
                str = "update user_table set user_pwd = '" + TxtPsw.Text + "',user_lever='" + CmbType.Text + "' where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + TxtName.Text + "'";
                SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                UpdateDataGridView1();
                MessageBox.Show("用户信息修改成功！", "用户信息修改", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("该用户名不存在！", "用户信息修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string str = "select * from user_table where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + TxtName.Text + "'";
            if (SQLHelper.IsPriExist(str))
            {
                DialogResult result = MessageBox.Show("删除后数据不可恢复，确定要删除选中数据？", "用户信息删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                str = "delete from user_table where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + TxtName.Text + "'";
                SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                UpdateDataGridView1();
                MessageBox.Show("用户信息删除成功！", "用户信息删除", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("该用户名不存在！", "用户信息删除", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 0) return;
            TxtName.Text = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            TxtPsw.Text = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            CmbType.Text = DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
