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
    public partial class FrmContractAdd : Form
    {
        List<string> listGoodsName = new List<string>();
        List<string> listSupplyUnit = new List<string>();
        List<string> listReciveUnit = new List<string>();
        public FrmContractAdd()
        {
            InitializeComponent();
        }

        private void UpdateGoodsName()
        {
            string str = "select gn_name from GoodsName where gn_area = '"+ ConnectionManger.G_MineArea +"'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            for (int i = 0;i< dt.Rows.Count; i++)
            {
                listGoodsName.Add(dt.Rows[i]["gn_name"].ToString());
            }
            cmbGoodsName.Items.AddRange(listGoodsName.ToArray());
            dt.Dispose();
        }

        private void UpdateSupplyUnit()
        {
            string str = "select su_unit from SupplyUnit where su_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listSupplyUnit.Add(dt.Rows[i]["su_unit"].ToString());
            }
            cmbSupplyUnit.Items.AddRange(listSupplyUnit.ToArray());
            dt.Dispose();
        }

        private void UpdateReciveUnit()
        {
            string str = "select ru_unit from ReceiveUnit where ru_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listReciveUnit.Add(dt.Rows[i]["ru_unit"].ToString());
            }
            cmbReciveUnit.Items.AddRange(listReciveUnit.ToArray());
            dt.Dispose();
        }

        private void FrmContractAdd_Load(object sender, EventArgs e)
        {
            UpdateGoodsName();
            UpdateSupplyUnit();
            UpdateReciveUnit();
            if (Classdata.ContractFlag == 1)
            {
                txtContractNo.Text = Contractdata.contractno;
                dtTime.Text = Contractdata.time;

                cmbGoodsName.Text = Contractdata.hwname;
                //cmbArea.Text = Contractdata.gharea;
                cmbSupplyUnit.Text = Contractdata.ghunit;
                cmbReciveUnit.Text = Contractdata.shunit;
                txtWeight.Text = (Contractdata.yysl).ToString();
                txtSumWeight.Text = (Contractdata.htzl).ToString();

                btnAdd.Visible = false;
                txtContractNo.Enabled = false;
            }
            else
            {
                btnSave.Visible = false;
            }
        }
        //FrmContractInfo frms = new FrmContractInfo();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtContractNo.Text == "")
            {
                MessageBox.Show("合同编号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbGoodsName.Text == "")
            {
                MessageBox.Show("品名不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbSupplyUnit.Text == "")
            {
                MessageBox.Show("供货单位不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbReciveUnit.Text == "")
            {
                MessageBox.Show("收货单位不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSumWeight.Text == "")
            {
                MessageBox.Show("合同总量不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtWeight.Text == "")
            {
                MessageBox.Show("已运量不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string str = "select cn_code from ContractNews where cn_area = '" + ConnectionManger.G_MineArea + "' and cn_code = '" + txtContractNo.Text + "'";
            if (SQLHelper.IsPriExist(str))
            {
                MessageBox.Show("该合同编号已存在！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    str = "Insert into ContractNews(cn_code,cn_hwmc,cn_area,su_unit,ru_unit,cn_htzl,cn_yysl,cn_time) values('" + txtContractNo.Text
                          + "','" + cmbGoodsName.Text + "','" + ConnectionManger.G_MineArea + "','" + cmbSupplyUnit.Text + "','"
                          + cmbReciveUnit.Text + "','" + txtSumWeight.Text + "','" + txtWeight.Text + "','" +DateTime.Now.ToString("yyyy-MM-dd") + "')";
                    SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                    MessageBox.Show("该合同信息添加成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //frms.UpdateDataGrid(FrmContractInfo.start, FrmContractInfo.end, "");
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
            if (txtContractNo.Text == "")
            {
                MessageBox.Show("合同编号不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbGoodsName.Text == "")
            {
                MessageBox.Show("品名不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbSupplyUnit.Text == "")
            {
                MessageBox.Show("供货单位不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbReciveUnit.Text == "")
            {
                MessageBox.Show("收货单位不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSumWeight.Text == "")
            {
                MessageBox.Show("合同总量不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string str = "update ContractNews set cn_hwmc='" + cmbGoodsName.Text + "',su_unit='" + cmbSupplyUnit.Text
                         + "',ru_unit='" + cmbReciveUnit.Text + "',cn_htzl='" + txtSumWeight.Text + "',cn_yysl='" + txtWeight.Text + "' where cn_area='" + ConnectionManger.G_MineArea + "' and cn_code='" + txtContractNo.Text +"'";
            SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
            MessageBox.Show("合同信息修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbGoodsName_TextUpdate(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            cmbGoodsName.Items.Clear();
            listNew.Clear();
            foreach(var item in listGoodsName)
            {
                if (item.Contains(cmbGoodsName.Text))
                {
                    listNew.Add(item);
                }
            }
            cmbGoodsName.Items.AddRange(listNew.ToArray());
            cmbGoodsName.SelectionStart = cmbGoodsName.Text.Length;
            Cursor = Cursors.Default;
            cmbGoodsName.DroppedDown = true;
        }

        private void cmbSupplyUnit_TextUpdate(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            cmbSupplyUnit.Items.Clear();
            listNew.Clear();
            foreach (var item in listSupplyUnit)
            {
                if (item.Contains(cmbSupplyUnit.Text))
                {
                    listNew.Add(item);
                }
            }
            cmbSupplyUnit.Items.AddRange(listNew.ToArray());
            cmbSupplyUnit.SelectionStart = cmbSupplyUnit.Text.Length;
            Cursor = Cursors.Default;
            cmbSupplyUnit.DroppedDown = true;
        }

        private void cmbReciveUnit_TextUpdate(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            cmbReciveUnit.Items.Clear();
            listNew.Clear();
            foreach(var item in listReciveUnit)
            {
                if (item.Contains(cmbReciveUnit.Text))
                {
                    listNew.Add(item);
                }
            }
            cmbReciveUnit.Items.AddRange(listNew.ToArray());
            cmbReciveUnit.SelectionStart = cmbReciveUnit.Text.Length;
            Cursor = Cursors.Default;
            cmbReciveUnit.DroppedDown = true;
        }

        private void txtSumWeight_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSumWeight.Text))
            {
                return ;
            }

            txtSYWeight.Text = (Convert.ToDouble(txtSumWeight.Text) - Convert.ToDouble(txtWeight.Text)).ToString();
        }

        private void txtSumWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
            {
                e.Handled = true;
            }
            else if (txtSumWeight.Text.Contains(".") && (e.KeyChar == 46))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 46 && txtSumWeight.Text.Length ==0)
            {
                e.Handled = true;
            }
        }
    }
}
