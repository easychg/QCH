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
    public partial class FrmTruckInfo : Form
    {
        List<string> listCarNumber = new List<string>();
        List<string> listCarType = new List<string>();
        List<string> listContractNo = new List<string>();
        List<string> listHomeUnit = new List<string>();
        public FrmTruckInfo()
        {
            InitializeComponent();
        }

        private void UpdateCarNumber()
        {
            string str = "select distinct cm_carnumber from CarManage where cm_szqy = '"+ ConnectionManger.G_MineArea +"'";
            DataTable dt = SQLHelper.GetDataSet(str,CommandType.Text).Tables[0];
            listCarNumber.Clear();
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                listCarNumber.Add(dt.Rows[i]["cm_carnumber"].ToString());
            }
            cmbCarNumber.Items.Clear();
            cmbCarNumber.Items.AddRange(listCarNumber.ToArray());

            dt.Dispose();
        }

        private void UpdataCarType()
        {
            string str = "select distinct cm_cx from CarManage  where cm_szqy = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listCarType.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listCarType.Add(dt.Rows[i]["cm_cx"].ToString());
            }
            //cmbCarType.Items.Clear();
            //cmbCarType.Items.AddRange(listCarType.ToArray());
            dt.Dispose();
        }

        private void UpdataContractNo()
        {
            string str = "select distinct cn_code from ContractNews where cn_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listContractNo.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listContractNo.Add(dt.Rows[i]["cn_code"].ToString());
            }
            cmbContractNo.Items.Clear();
            cmbContractNo.Items.AddRange(listContractNo.ToArray());
            dt.Dispose();
        }

        private void UpdataHomeUnit()
        {
            string str = "select distinct cm_homeunit from CarManage where cm_szqy = '" + ConnectionManger.G_MineArea + "' ";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listHomeUnit.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listHomeUnit.Add(dt.Rows[i]["cm_homeunit"].ToString());
            }
            cmbHomeUnit.Items.Clear();
            cmbHomeUnit.Items.AddRange(listHomeUnit.ToArray());
            dt.Dispose();
        }

        private void UpdateDataGrid(string where)
        {
            DGVTruck.AutoGenerateColumns = false;
            string str = "select  cm_kcode,cm_carnumber,cm_jsy,cn_code,cm_bzweight,cm_homeunit,(case  (select top 1 wcbj  from Flow fw where fw.fw_kh=cm.cm_kcode and fw.fw_area=cm.cm_szqy order by inserttime desc) when '完成' then '完成' else '未完成' end ) as wc,(select top 1 fw_flow  from Flow fw where fw.fw_kh=cm.cm_kcode and fw.fw_area=cm.cm_szqy order by inserttime desc) as flow,cm_id from CarManage cm where cm_szqy = '" + ConnectionManger.G_MineArea + "'" + where;
            DGVTruck.DataSource = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            if (DGVTruck.RowCount == 0) return;
            int carcount=0;
            for (int i = 0; i < DGVTruck.RowCount; i++)
            {
                if (DGVTruck.Rows[i].Cells[7].Value.ToString() == "未完成") carcount += 1;
            }
            label6.Text = "场内当前车辆为：" + carcount.ToString();
        }

        private void FrmTruckInfo_Load(object sender, EventArgs e)
        {
            UpdateDataGrid("");
        }

        private void btnCX_Click(object sender, EventArgs e)
        {
            UpdateCarNumber();
            UpdataCarType();
            UpdataContractNo();
            UpdataHomeUnit();
            GBCX.Visible = true;
        }

        private void cmbCarNumber_TextUpdate(object sender, EventArgs e)
        {
            //List<string> listNew = new List<string>();
            //cmbCarNumber.Items.Clear();
            //listNew.Clear();
            //foreach (var item in listCarNumber )
            //{
            //    if (item.Contains(cmbCarNumber.Text))
            //    {
            //        listNew.Add(item);
            //    }
            //}
            //cmbCarNumber.Items.AddRange(listNew.ToArray());
            //cmbCarNumber.SelectionStart = cmbCarNumber.Text.Length;
            //Cursor = Cursors.Default;
            //cmbCarNumber.DroppedDown = true;
        }

        private void cmbCarType_TextChanged(object sender, EventArgs e)
        {
            //List<string> listNew = new List<string>();
            //cmbCarType.Items.Clear();
            //listNew.Clear();
            //foreach (var item in listCarType)
            //{
            //    if (item.Contains(cmbCarType.Text))
            //    {
            //        listNew.Add(item);
            //    }
            //}
            //cmbCarType.Items.AddRange(listNew.ToArray());
            //cmbCarType.SelectionStart = cmbCarType.Text.Length;
            //Cursor = Cursors.Default;
            //cmbCarType.DroppedDown = true;
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

        private void cmbHomeUnit_TextUpdate(object sender, EventArgs e)
        {
            //List<string> listNew = new List<string>();
            //cmbHomeUnit.Items.Clear();
            //listNew.Clear();
            //foreach (var item in listHomeUnit)
            //{
            //    if (item.Contains(cmbHomeUnit.Text))
            //    {
            //        listNew.Add(item);
            //    }
            //}
            //cmbHomeUnit.Items.AddRange(listNew.ToArray());
            //cmbHomeUnit.SelectionStart = cmbHomeUnit.Text.Length;
            //Cursor = Cursors.Default;
            //cmbHomeUnit.DroppedDown = true;
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            string where = "";
            if (comboBox1.Text != "")
            {

                    where += " and (case  (select top 1 wcbj  from Flow fw where fw.fw_kh=cm.cm_kcode and fw.fw_area=cm.cm_szqy order by inserttime desc) when '完成' then '完成' else '未完成' end )='"+comboBox1.Text+"'";
                
            }
            if (txtCarNo.Text != "") where += " and cm_kcode = '" + txtCarNo.Text + "'";
            if (cmbCarNumber.Text != "") where += " and cm_carnumber = '" + cmbCarNumber.Text + "'";
            if (txtDriver.Text != "") where += " and cm_jsy = '" + txtDriver.Text + "'";
       
            if (cmbContractNo.Text != "") where += " and cn_code = '" + cmbContractNo.Text + "'";
            if (cmbHomeUnit.Text != "") where += " and cm_homeunit = '" + cmbHomeUnit.Text + "'";
            
            UpdateDataGrid(where);
            GBCX.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Classdata.TruckFlag = 0;
            FrmTruckAdd frm = new FrmTruckAdd();
            frm.ShowDialog ();
            UpdateDataGrid("");                                                                              
        }

        private void btnXG_Click(object sender, EventArgs e)
        {                               
            if (Truckdata.kcode == null) return;
            Classdata.TruckFlag = 1;
            FrmTruckAdd frm = new FrmTruckAdd();
            frm.ShowDialog();
            UpdateDataGrid("");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("删除后数据不可恢复，确定要删除选中数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (ConnectionManger.UserType != "管理员")
            {
                if (DGVTruck.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < DGVTruck.SelectedRows.Count; i++)
                    {
                        string swc = (DGVTruck.SelectedRows[i].Cells[7].Value).ToString();
                        if (swc == "未完成")
                        {
                            MessageBox.Show("你选中的项存在未完成的数据！");
                            return;
                        }
                    }
                }
            }

            if (DGVTruck.SelectedRows.Count > 0)
            {
                for (int i = 0; i < DGVTruck.SelectedRows.Count;i++ )
                {
                  

                    Truckdata.kcode = (DGVTruck.SelectedRows[i].Cells[0].Value).ToString();
                    string str = "delete from CarManage where cm_szqy = '" + ConnectionManger.G_MineArea + "' and cm_kcode = '" + Truckdata.kcode + "'  delete from Flow where fw_kh='" + Truckdata.kcode + "' and fw_area='" + ConnectionManger.G_MineArea + "'";
                    //string str = "delete from CarManage where cm_szqy = '" + ConnectionManger.G_MineArea + "' and cm_kcode = '" + Truckdata.kcode + "'";
                    SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                }
                UpdateDataGrid("");
            }
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            UpdateDataGrid("");
        }

        private void DGVTruck_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVTruck.SelectedRows.Count == 0)
            {
                Truckdata.id = null;
                Truckdata.kcode = null;
                Truckdata.carnumber = null;
                Truckdata.cx = null;
                Truckdata.jsy = null;
                Truckdata.lxdh = null;
                Truckdata.cpz = 0;
                Truckdata.htno = null;
                Truckdata.bzweight = 0;
                Truckdata.homeunit = null;
                return;
            }
            Truckdata.id = (DGVTruck.SelectedRows[0].Cells[8].Value).ToString();
            Truckdata.kcode = (DGVTruck.SelectedRows[0].Cells[0].Value).ToString();
            Truckdata.carnumber = (DGVTruck.SelectedRows[0].Cells[1].Value).ToString();
            //Truckdata.cx = (DGVTruck.SelectedRows[0].Cells[2].Value).ToString();
            Truckdata.jsy = (DGVTruck.SelectedRows[0].Cells[2].Value).ToString();
            //Truckdata.lxdh = (DGVTruck.SelectedRows[0].Cells[4].Value).ToString();
            //Truckdata.cpz = Convert.ToDouble(DGVTruck.SelectedRows[0].Cells[5].Value);
            Truckdata.htno = (DGVTruck.SelectedRows[0].Cells[3].Value).ToString();
            string d = DGVTruck.SelectedRows[0].Cells[4].Value.ToString();
            if (d == "")
            {
                d = "0";
            }
            Truckdata.bzweight = Convert.ToDouble(d);
            Truckdata.homeunit = (DGVTruck.SelectedRows[0].Cells[5].Value).ToString();
        }
        //清除条件
        private void button2_Click(object sender, EventArgs e)
        {
            txtCarNo.Text = ""; cmbCarNumber.Text = ""; txtDriver.Text = "";
             cmbContractNo.Text = ""; cmbHomeUnit.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GBCX.Visible = false;
        }


    }
}
