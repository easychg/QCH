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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "当前用户为：" + ConnectionManger.UserName;

            toolStripStatusLabel2.Text = "徐州圣能科技有限公司";

            if (ConnectionManger.UserType == "管理员")
            {
                button3.Visible = true;
                button2.Visible = true;
                button5.Visible = true;
            }
            else
            {
                button3.Visible = false;
            }
            panelWeight.Left = 0; panelWeight.Top = 2;
            panelWeight.Width = this.Width;
            panelWeight.BringToFront();
        }

        private void 称重管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelWeight.Left = 0; panelWeight.Top = 2;
            panelWeight.Width = this.Width;
            panelWeight.BringToFront();
        }

        private void 用户权限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelUser.Left = 0; panelUser.Top = 2;
            panelUser.Width = this.Width;
            panelUser.BringToFront();
        }

        private void 系统维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSystem.Left = 0; panelSystem.Top = 2;
            panelSystem.Width = this.Width;
            panelSystem.BringToFront();
        }

        private void 通讯设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelComm.Left = 0; panelComm.Top = 2;
            panelComm.Width = this.Width;
            panelComm.BringToFront();
        }

        private void 安装与帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panelHelp.Left = 0; panelHelp.Top = 2;
            //panelHelp.Width = this.Width;
            //panelHelp.BringToFront();
        }
        //称重过磅记录
        private void BtnWeighRecord_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmContractInfo frm = new FrmContractInfo();
            frm.ShowDialog();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            FrmBasicdata frm = new FrmBasicdata();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMimaXG frm = new FrmMimaXG();
            frm.ShowDialog();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            FrmRecordquery frm = new FrmRecordquery();
            frm.ShowDialog();
        }

        private void BtnKJInfo_Click(object sender, EventArgs e)
        {
            FrmTruckInfo frm = new FrmTruckInfo();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUser frm = new FrmUser();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParameterSet frm = new ParameterSet();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FlowSet frm = new FlowSet();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_SystemSet frm = new Frm_SystemSet();
            frm.ShowDialog();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Frm_Print frm = new Frm_Print();
            frm.ShowDialog();
        }
    }
}
