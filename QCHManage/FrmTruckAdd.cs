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
    public partial class FrmTruckAdd : Form
    {
        List<string> listCarType = new List<string>();
        List<string> listContractNo = new List<string>();
        List<string> listHomeUnit = new List<string>();

        public FrmTruckAdd()
        {
            InitializeComponent();
        }

        Operation.Select select = new Operation.Select();
        //private void UpdataCarType()
        //{
        //    string str = "select distinct cm_cx from CarManage  where cm_szqy = '" + ConnectionManger.G_MineArea + "'";
        //    DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        listCarType.Add(dt.Rows[i]["cm_cx"].ToString());
        //    }
           
        //    dt.Dispose();
        //}

        private void UpdataContractNo()
        {
            string str = "select distinct cn_code from ContractNews where cn_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listContractNo.Add(dt.Rows[i]["cn_code"].ToString());
            }
            cmbContractNo.Items.AddRange(listContractNo.ToArray());
            dt.Dispose();
        }

        private void UpdataHomeUnit()
        {
            string str = "select distinct cm_homeunit from CarManage where cm_szqy = '" + ConnectionManger.G_MineArea + "' ";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listHomeUnit.Add(dt.Rows[i]["cm_homeunit"].ToString());
            }
            cmbHomeUnit.Items.AddRange(listHomeUnit.ToArray());
            dt.Dispose();
        }

        private void FrmTruckAdd_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
           
            UpdataContractNo();
            UpdataHomeUnit();
            if (Classdata.TruckFlag == 1)
            {
                txtCarNo.Text = Truckdata.kcode;
                txtCarNumber.Text = Truckdata.carnumber;

                txtDriver.Text = Truckdata.jsy;


                cmbContractNo.Text = Truckdata.htno;
                txtBzWeight.Text = (Truckdata.bzweight).ToString();
                cmbHomeUnit.Text = Truckdata.homeunit;
                btnAdd.Visible  = false;
                //txtCarNo.Enabled = false;
            }
            else
            {
                btnSave.Visible = false;
            }
            timer1.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCarNo.Text == "")
            {
                MessageBox.Show("卡号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (txtCarNumber.Text == "")
            //{
            //    MessageBox.Show("车牌号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (txtDriver.Text == "")
            //{
            //    MessageBox.Show("驾驶员姓名不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (txtTare.Text == "")
            //{
            //    MessageBox.Show("汽车皮重不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (cmbContractNo.Text == "")
            {
                MessageBox.Show("合同编号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtBzWeight.Text == "")
            {
                MessageBox.Show("标准载重不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string str = "select * from CarManage where cm_szqy = '" + ConnectionManger.G_MineArea + "' and cm_kcode = '" + txtCarNo.Text + "'";
            if (SQLHelper.IsPriExist(str))
            {
                MessageBox.Show("该卡号已录入过车辆信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    //DataTable dtkh = select.select_CarManage_kh(txtCarNo.Text);
                    //if (dtkh.Rows.Count > 0)
                    //{
 
                    //}

                    str = "Insert into CarManage(cm_kcode,cm_carnumber,cm_jsy,cm_szqy,cn_code,cm_bzweight,cm_homeunit,cm_runsign) values('" + txtCarNo.Text + "','" + txtCarNumber.Text
                        + "','" + txtDriver.Text + "','" + ConnectionManger.G_MineArea + "','" + cmbContractNo.Text
                        + "','" + txtBzWeight.Text + "','" + cmbHomeUnit.Text + "','" + comboBox1.Text + "')";
                    SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                }
                catch
                {
                    MessageBox.Show("请检查所填数据是否合法!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCarNo.Text == "")
            {
                MessageBox.Show("卡号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCarNumber.Text == "")
            {
                MessageBox.Show("车牌号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (txtDriver.Text == "")
            //{
            //    MessageBox.Show("驾驶员姓名不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (txtTare.Text == "")
            //{
            //    MessageBox.Show("汽车皮重不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (cmbContractNo.Text == "")
            {
                MessageBox.Show("合同编号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtBzWeight.Text == "")
            {
                MessageBox.Show("标准载重不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string str = "update CarManage set cm_kcode = '" + txtCarNo.Text + "',cm_carnumber = '" + txtCarNumber.Text + "',cm_jsy = '" + txtDriver.Text + "',cn_code = '" + cmbContractNo.Text + "',cm_bzweight = '" + txtBzWeight.Text + "',cm_homeunit = '" + cmbHomeUnit.Text + "' where cm_szqy = '"
                + ConnectionManger.G_MineArea + "' and cm_id = '" + Truckdata.id + "'";
            SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
            MessageBox.Show("车辆基本信息修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbContractNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "select ru_unit,cn_hwmc,cn_htzl,cn_yysl,(cn_htzl-cn_yysl) as syl from ContractNews where cn_code = '" + cmbContractNo.Text + "' and cn_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtGoodsName.Text = dt.Rows[0]["cn_hwmc"].ToString();
                txtSumWeight.Text = dt.Rows[0]["cn_htzl"].ToString();
                txtWeight.Text = dt.Rows[0]["cn_yysl"].ToString();
                txtSYWeight.Text = dt.Rows[0]["syl"].ToString();
                cmbHomeUnit.Text = dt.Rows[0]["ru_unit"].ToString();
            }
            else
            {
                txtGoodsName.Text = "";
                txtSumWeight.Text = "";
                txtWeight.Text = "";
            }
        }
    }
}
