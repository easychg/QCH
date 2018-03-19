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
    public partial class FrmContractInfo : Form
    {
        List<string> listGoodsName = new List<string>();
        List<string> listSupplyUnit = new List<string>();
        List<string> listReciveUnit = new List<string>();
        List<string> listContractNo = new List<string>();
        public FrmContractInfo()
        {
            InitializeComponent();
        }

        string start = DateTime.Now.AddYears  (-1).ToString("yyyy/MM/dd");
        string end = DateTime.Now.ToString("yyyy/MM/dd");

        private void UpdateContractNo()
        {
            string str = "select cn_code from ContractNews where cn_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listContractNo.Clear();
            cmbContractNo.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listContractNo.Add(dt.Rows[i]["cn_code"].ToString());
            }
            cmbContractNo.Items.AddRange(listContractNo.ToArray());
            dt.Dispose();
        }

        private void UpdateGoodsName()
        {
            string str = "select gn_name from GoodsName where gn_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listGoodsName.Clear();
            cmbGoodsName.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
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
            listSupplyUnit.Clear();
            cmbSupplyUnit.Items.Clear();
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
            listReciveUnit.Clear();
            cmbReciveUnit.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listReciveUnit.Add(dt.Rows[i]["ru_unit"].ToString());
            }
            cmbReciveUnit.Items.AddRange(listReciveUnit.ToArray());
            dt.Dispose();
        }

        private void UpdateDataGrid(string start,string end, string where)
        {
            //string str = "select cn_code,cn_time,cn_news,cn_hwmc,su_unit,ru_unit,cn_htzl,cn_yysl,(cn_htzl-cn_yysl) as syl from ContractNews where cn_time between '" + start + "' and '" + end + "' and cn_area='" + ConnectionManger.G_MineArea + "'" + where + " order by cn_code asc";
            string str = "select cn_code,cn_time,cn_news,cn_hwmc,su_unit,ru_unit,cn_htzl,cn_yysl,(cn_htzl-cn_yysl) as syl from ContractNews where cn_area='" + ConnectionManger.G_MineArea + "'" + where + " order by cn_code asc";
            DGVContract.DataSource = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
        }

        private void FrmContractInfo_Load(object sender, EventArgs e)
        {
            if (ConnectionManger.UserType == "管理员")
            {
                btnAdd.Visible = true;
                btnXG.Visible = true;
                btnDel.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                btnXG.Visible = false;
                btnDel.Visible = false;
            }
            TimeStart.Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
            start = TimeStart.Text; end = TimeEnd.Text;
            groupBoxCX.Visible = false;
            UpdateDataGrid(start, end, "");
        }

        //private void DGVContract_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (DGVContract.SelectedRows.Count == 0)
        //    {
        //        return;
        //    }
        //    Contractdata.contractno = (DGVContract.SelectedRows[0].Cells[0].Value).ToString();
        //    Contractdata.time = (DGVContract.SelectedRows[0].Cells[1].Value).ToString();
        //    Contractdata.news = (DGVContract.SelectedRows[0].Cells[2].Value).ToString();
        //    Contractdata.hwname  = (DGVContract.SelectedRows[0].Cells[3].Value).ToString();
        //    //Contractdata.gharea = (DGVContract.SelectedRows[0].Cells[4].Value).ToString();
        //    Contractdata.ghunit = (DGVContract.SelectedRows[0].Cells[4].Value).ToString();
        //    Contractdata.shunit = (DGVContract.SelectedRows[0].Cells[5].Value).ToString();
        //    Contractdata.htzl  = Convert.ToDouble(DGVContract.SelectedRows[0].Cells[6].Value);
        //    Contractdata.yysl = Convert.ToDouble(DGVContract.SelectedRows[0].Cells[7].Value);
        //}

        private void btnCX_Click(object sender, EventArgs e)
        {
            UpdateGoodsName();
            UpdateSupplyUnit();
            UpdateReciveUnit();
            UpdateContractNo();
            groupBoxCX.Visible = true;
            //panelCX.BringToFront();
            //UpdateDataGrid();
        }
        //Contractdata ddd = new Contractdata();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Classdata.ContractFlag = 0;
            FrmContractAdd frm = new FrmContractAdd();
            frm.ShowDialog();
            UpdateDataGrid(start,end,"");
        }

        private void btnXG_Click(object sender, EventArgs e)
        {
            if (Contractdata.contractno == null ) return;
            Classdata.ContractFlag = 1;
            FrmContractAdd frm = new FrmContractAdd();
            frm.ShowDialog();
            UpdateDataGrid(start, end, "");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("删除后数据不可恢复，确定要删除选中数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (DGVContract.SelectedRows.Count == 0)
            {
                return;
            }

            Contractdata.contractno = (DGVContract.SelectedRows[0].Cells[0].Value).ToString();

            string str = "delete from ContractNews where cn_code = '" + Contractdata.contractno + "' and cn_area='" + ConnectionManger.G_MineArea + "'";
            SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
            UpdateDataGrid(start, end, "");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            string where="";
            start = TimeStart.Text; end = TimeEnd.Text;
            if (cmbContractNo.Text != "") where += " and cn_code = '" + cmbContractNo.Text + "'";
            if (cmbGoodsName.Text != "") where += " and cn_hwmc = '" + cmbGoodsName.Text + "'";
            if (cmbSupplyUnit.Text != "") where += " and su_unit = '" + cmbSupplyUnit.Text + "'";
            if (cmbReciveUnit.Text != "") where += " and ru_unit = '" + cmbReciveUnit.Text + "'";
            UpdateDataGrid(start, end, where);
            groupBoxCX.Visible = false;
        }

        private void cmbContractNo_TextUpdate(object sender, EventArgs e)
        {
            //List<string> listNew = new List<string>();
            //cmbContractNo.Items.Clear();
            //listNew.Clear();
            //foreach (var item in listContractNo)
            //{
            //    if (item.Contains(cmbContractNo.Text))
            //    {
            //        listNew.Add(item);
            //    }
            //}
            //cmbContractNo.Items.AddRange(listNew.ToArray());
            //cmbContractNo.SelectionStart = cmbContractNo.Text.Length;
            //Cursor = Cursors.Default;
            //cmbContractNo.DroppedDown = true;
        }

        private void cmbGoodsName_TextUpdate(object sender, EventArgs e)
        {
            //List<string> listNew = new List<string>();
            //cmbGoodsName.Items.Clear();
            //listNew.Clear();
            //foreach (var item in listGoodsName)
            //{
            //    if (item.Contains(cmbGoodsName.Text))
            //    {
            //        listNew.Add(item);
            //    }
            //}
            //cmbGoodsName.Items.AddRange(listNew.ToArray());
            //cmbGoodsName.SelectionStart = cmbGoodsName.Text.Length;
            //Cursor = Cursors.Default;
            //cmbGoodsName.DroppedDown = true;
        }

        private void cmbSupplyUnit_TextUpdate(object sender, EventArgs e)
        {
            //List<string> listNew = new List<string>();
            //cmbSupplyUnit.Items.Clear();
            //listNew.Clear();
            //foreach (var item in listSupplyUnit)
            //{
            //    if (item.Contains(cmbSupplyUnit.Text))
            //    {
            //        listNew.Add(item);
            //    }
            //}
            //cmbSupplyUnit.Items.AddRange(listNew.ToArray());
            //cmbSupplyUnit.SelectionStart = cmbSupplyUnit.Text.Length;
            //Cursor = Cursors.Default;
            //cmbSupplyUnit.DroppedDown = true;
        }

        private void cmbReciveUnit_TextUpdate(object sender, EventArgs e)
        {
            //List<string> listNew = new List<string>();
            //cmbReciveUnit.Items.Clear();
            //listNew.Clear();
            //foreach (var item in listReciveUnit)
            //{
            //    if (item.Contains(cmbReciveUnit.Text))
            //    {
            //        listNew.Add(item);
            //    }
            //}
            //cmbReciveUnit.Items.AddRange(listNew.ToArray());
            //cmbReciveUnit.SelectionStart = cmbReciveUnit.Text.Length;
            //Cursor = Cursors.Default;
            //cmbReciveUnit.DroppedDown = true;
        }
        //清除条件
        private void button2_Click(object sender, EventArgs e)
        {
            cmbContractNo.Text = ""; cmbGoodsName.Text = ""; cmbSupplyUnit.Text = ""; cmbReciveUnit.Text = "";
        }

        private void DGVContract_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVContract.SelectedRows.Count == 0)
            {
                return;
            }
            Contractdata.contractno = (DGVContract.SelectedRows[0].Cells[0].Value).ToString();
            Contractdata.time = (DGVContract.SelectedRows[0].Cells[1].Value).ToString();
            Contractdata.news = (DGVContract.SelectedRows[0].Cells[2].Value).ToString();
            Contractdata.hwname = (DGVContract.SelectedRows[0].Cells[3].Value).ToString();
            //Contractdata.gharea = (DGVContract.SelectedRows[0].Cells[4].Value).ToString();
            Contractdata.ghunit = (DGVContract.SelectedRows[0].Cells[4].Value).ToString();
            Contractdata.shunit = (DGVContract.SelectedRows[0].Cells[5].Value).ToString();
            Contractdata.htzl = Convert.ToDouble(DGVContract.SelectedRows[0].Cells[6].Value);
            Contractdata.yysl = Convert.ToDouble(DGVContract.SelectedRows[0].Cells[7].Value);
        }

        //private AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();

        //private void DGVContract_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;
        //    if (e.Control is TextBox)
        //    {
        //        TextBox tb = (TextBox)e.Control;
        //        if (dgv.CurrentCell.OwningColumn.Name == "Name")
        //        {
        //            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //            tb.AutoCompleteCustomSource = this.autoCompleteSource;
        //        }
        //        else
        //        {
        //            tb.AutoCompleteMode = AutoCompleteMode.None;
        //        }
        //    }
        }

    }

