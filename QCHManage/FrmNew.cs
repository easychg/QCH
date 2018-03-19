using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QCHManage
{
    public partial class FrmNew : Form
    {
        public FrmNew()
        {
            InitializeComponent();
        }

        //public void readxml()
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load("han.xml");
        //    XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
        //    foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
        //    {
        //        XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

        //        //if (xe.GetAttribute("lun") == "video1")
        //        //{
        //        //    strvideo1 = xe.InnerText.Trim();      //给视频赋值IP

        //        //}
        //        //if (xe.GetAttribute("lun") == "video2")
        //        //{
        //        //    strvideo2 = xe.InnerText.Trim();
        //        //}
        //        //if (xe.GetAttribute("lun") == "video3")
        //        //{
        //        //    strvideo3 = xe.InnerText.Trim();
        //        //}
        //        //if (xe.GetAttribute("lun") == "video4")
        //        //{
        //        //    strvideo4 = xe.InnerText.Trim();
        //        //}

        //        if (xe.GetAttribute("lun") == "qu")
        //        {
        //            ConnectionManger.G_MineArea = xe.InnerText.Trim();
        //        }

        //        //if (xe.GetAttribute("lun") == "Com")
        //        //{
        //        //    Com = xe.InnerText.Trim();
        //        //}

        //        //if (xe.GetAttribute("lun") == "Com")
        //        //{
        //        //    Com = xe.InnerText.Trim();
        //        //}

        //    }
        //}


        private void FrmNew_Load(object sender, EventArgs e)
        {
            //readxml();
            ConnectionManger.readxml();
            string str = "select * from user_table where user_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CmbName.Items.Add(dt.Rows[i]["user_name"].ToString());
            }
            dt.Dispose();
            if (CmbName.Items.Count > 0) CmbName.SelectedIndex = 0;
            TxtMima.Focus();
            TxtMima.Select();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string mimastr="";
            string str = "select * from user_table where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + CmbName.Text + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ConnectionManger.UserName = dt.Rows[0]["user_name"].ToString();
                ConnectionManger.UserType = dt.Rows[0]["user_lever"].ToString();
                mimastr = dt.Rows[0]["user_pwd"].ToString();
            }
            if (mimastr != TxtMima.Text)
            {
                MessageBox.Show("密码输入不正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtMima.Text = "";
                TxtMima.Focus();
                TxtMima.Select();
            }
            else
            {
                this.Hide();
                ConnectionManger.G_FrmMain.Show();
                ConnectionManger.G_FrmMain.BringToFront();
            }
        }

        private void TxtMima_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string mimastr = "";
                string str = "select * from user_table where user_area = '" + ConnectionManger.G_MineArea + "' and user_name = '" + CmbName.Text + "'";
                DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ConnectionManger.UserName = dt.Rows[0]["user_name"].ToString();
                    ConnectionManger.UserType = dt.Rows[0]["user_lever"].ToString();
                    mimastr = dt.Rows[0]["user_pwd"].ToString();
                }
                if (mimastr != TxtMima.Text)
                {
                    MessageBox.Show("密码输入不正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMima.Text = "";
                    TxtMima.Focus();
                    TxtMima.Select();
                }
                else
                {
                    this.Hide();
                    ConnectionManger.G_FrmMain.Show();
                    ConnectionManger.G_FrmMain.BringToFront();
                }
            }
        }
    }
}
