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
    public partial class FrmBasicdata : Form
    {
        public FrmBasicdata()
        {
            InitializeComponent();
        }
       
        private void ShowGHDWInfo()
        {
            DGVGH.AutoGenerateColumns = false;
            string str = "select * from SupplyUnit where su_area = '"+ ConnectionManger.G_MineArea +"'";
            DGVGH.DataSource = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
        }

        private void ClearGHDW()
        {
            
            txtGHDW.Text = "";
        }

        private void ShowSHDWInfo()
        {
            DGVSH.AutoGenerateColumns = false;
            string str = "select * from ReceiveUnit where ru_area = '" + ConnectionManger.G_MineArea + "'";
            DGVSH.DataSource = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
        }

        private void ClearSHDW()
        {
          
            txtSHDW.Text = "";
        }

        private void ShowPMInfo()
        {
            DGVPM.AutoGenerateColumns = false;
            string str = "select * from GoodsName where gn_area = '" + ConnectionManger.G_MineArea + "'";
            DGVPM.DataSource = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
        }

        private void ClearPM()
        {
          
            txtPM.Text = "";
        }

        private void FrmBasicdata_Load(object sender, EventArgs e)
        {
            ShowGHDWInfo();
            //fl_cmb.SelectedIndex = 0;
            bind_flownews();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) ShowSHDWInfo();
            if (tabControl1.SelectedIndex == 2) ShowPMInfo();
        }

        private void BtnAddGH_Click(object sender, EventArgs e)
        {
            //if (txtGHNo.Text == "")
            //{
            //    MessageBox.Show("供货单位代码不允许为空！","提示信息",MessageBoxButtons.OK ,MessageBoxIcon.Error );
            //    return;
            //}
            if (txtGHDW.Text == "")
            {
                MessageBox.Show("供货单位不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string str = "select * from SupplyUnit where su_area = '" + ConnectionManger.G_MineArea + "' and su_unit = '" + txtGHDW.Text + "'";
            if (SQLHelper.IsPriExist(str))
            {
                MessageBox.Show("该供货单位已存在！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    str = "Insert into SupplyUnit(su_area,su_unit) values('" + ConnectionManger.G_MineArea + "','" + txtGHDW.Text + "')";
                    SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                    ShowGHDWInfo();
                    ClearGHDW();
                }
                catch
                {
                    MessageBox.Show("请检查所填数据是否合法!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDelGH_Click(object sender, EventArgs e)
        {
            string id = DGVGH.SelectedCells[2].Value.ToString();
            string str = "delete from SupplyUnit where su_code='" + id + "'";
            DialogResult result = MessageBox.Show("确定要删除改组数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (SQLHelper.ExecuteNonQuery(CommandType.Text, str, null)>0)
                {
                    MessageBox.Show("删除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    ShowGHDWInfo();
                    ClearGHDW();
                }
            }
            //string str = "select * from SupplyUnit where su_area = '" + ConnectionManger.G_MineArea + "' and su_unit = '" + txtGHDW.Text + "'";
            //if (SQLHelper.IsPriExist(str))
            //{
            //    DialogResult result = MessageBox.Show("确定要删除改组数据？","提示信息",MessageBoxButtons.OKCancel ,MessageBoxIcon.Question );
            //    if (result == DialogResult.Cancel)
            //    {
            //        return;
            //    }
            //    try
            //    {
            //        str = "delete from SupplyUnit where su_area = '" + ConnectionManger.G_MineArea + "' and su_unit = '" + txtGHDW.Text + "'";
            //        SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
            //        ShowGHDWInfo();
            //        ClearGHDW();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("供货信息删除失败！","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void BtnCancleGH_Click(object sender, EventArgs e)
        {
            ClearGHDW();
        }

        private void DGVGH_MouseClick(object sender, MouseEventArgs e)
        {
            if (DGVGH.SelectedRows.Count == 0)
            {
                return;
            }
          
            txtGHDW.Text = (DGVGH.SelectedRows[0].Cells[1].Value).ToString();
        }

        private void BtnAddSH_Click(object sender, EventArgs e)
        {
            //if (txtSHNo.Text == "")
            //{
            //    MessageBox.Show("收货单位代码不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (txtSHDW.Text == "")
            {
                MessageBox.Show("收货单位不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string str = "select * from ReceiveUnit where ru_unit = '" + txtSHDW.Text + "'and ru_area='" + ConnectionManger.G_MineArea + "'";
            if (SQLHelper.IsPriExist(str))
            {
                MessageBox.Show("该收货单位已存在！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    str = "Insert into ReceiveUnit ( ru_area,ru_unit) values('" + ConnectionManger.G_MineArea + "','" + txtSHDW.Text + "')";
                    SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                    ShowSHDWInfo();
                    ClearSHDW();
                }
                catch
                {
                    MessageBox.Show("请检查所填数据是否合法!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDelSH_Click(object sender, EventArgs e)
        {
            string id = DGVSH.SelectedCells[2].Value.ToString();
            string str = "delete from ReceiveUnit where ru_code='" + id + "' and ru_area='" + ConnectionManger.G_MineArea + "'";
            DialogResult result = MessageBox.Show("确定要删除改组数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (SQLHelper.ExecuteNonQuery(CommandType.Text, str, null) > 0)
                {
                    MessageBox.Show("删除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    ShowSHDWInfo();
                    ClearSHDW();
                }
            }

            //string str = "select * from ReciveUnit where su_area = '" + ConnectionManger.G_MineArea + "' and su_unit = '" + txtSHDW.Text + "'";
            //if (SQLHelper.IsPriExist(str))
            //{
            //    DialogResult result = MessageBox.Show("确定要删除改组数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (result == DialogResult.Cancel)
            //    {
            //        return;
            //    }
            //    try
            //    {
            //        str = "delete from ReciveUnit where  su_area = '" + ConnectionManger.G_MineArea + "' and  su_unit = '" + txtSHDW.Text + "'";
            //        SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
            //        ShowSHDWInfo();
            //        ClearSHDW();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("供货信息删除失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void BtnCancleSH_Click(object sender, EventArgs e)
        {
            ClearSHDW();
        }

        private void DGVSH_MouseClick(object sender, MouseEventArgs e)
        {
            if (DGVSH.SelectedRows.Count == 0)
            {
                return;
            }
            //txtSHNo.Text = (DGVSH.SelectedRows[0].Cells[0].Value).ToString();
            txtSHDW.Text = (DGVSH.SelectedRows[0].Cells[1].Value).ToString();
        }

        private void BtnAddPM_Click(object sender, EventArgs e)
        {
            //if (txtPMNo.Text == "")
            //{
            //    MessageBox.Show("品名代码不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (txtPM.Text == "")
            {
                MessageBox.Show("品名不允许为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string str = "select * from GoodsName where gn_name = '" + txtPM.Text + "' and gn_area='"+ConnectionManger.G_MineArea+"'";
            if (SQLHelper.IsPriExist(str))
            {
                MessageBox.Show("该品名已存在！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    str = "Insert into GoodsName(gn_area,gn_name) values('" + ConnectionManger.G_MineArea + "','" + txtPM.Text + "')";
                    SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                    ShowPMInfo();
                    ClearPM();
                }
                catch
                {
                    MessageBox.Show("请检查所填数据是否合法!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDelPM_Click(object sender, EventArgs e)
        {
            string id = DGVPM.SelectedCells[2].Value.ToString();
            string str = "delete from GoodsName where gn_code='" + id + "' and gn_area='" + ConnectionManger.G_MineArea + "'";
            DialogResult result = MessageBox.Show("确定要删除改组数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (SQLHelper.ExecuteNonQuery(CommandType.Text, str, null) > 0)
                {
                    MessageBox.Show("删除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    ShowPMInfo();
                    ClearPM();
                }
            }
            //string str = "select * from GoodsName where su_area = '" + ConnectionManger.G_MineArea + "' and  gn_name = '" + txtPM.Text + "'";
            //if (SQLHelper.IsPriExist(str))
            //{
            //    DialogResult result = MessageBox.Show("确定要删除改组数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (result == DialogResult.Cancel)
            //    {
            //        return;
            //    }
            //    try
            //    {
            //        str = "delete from GoodsName where su_area = '" + ConnectionManger.G_MineArea + "' and  gn_name = '" + txtPM.Text + "'";
            //        SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
            //        ShowPMInfo();
            //        ClearPM();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("供货信息删除失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void BtnCanclePM_Click(object sender, EventArgs e)
        {
            ClearPM();
        }

        private void DGVPM_MouseClick(object sender, MouseEventArgs e)
        {
            if (DGVPM.SelectedRows.Count == 0)
            {
                return;
            }
            //txtPMNo.Text = (DGVPM.SelectedRows[0].Cells[0].Value).ToString();
            txtPM.Text = (DGVPM.SelectedRows[0].Cells[1].Value).ToString();
        }
        Operation.Insert insert = new Operation.Insert();
        Operation.Select select = new Operation.Select();
        Operation.Delete delete = new Operation.Delete();
        private void button1_Click(object sender, EventArgs e)
        {
            //if (insert.insert_FlowNews(txt_fname.Text, fl_cmb.Text) > 0)
            //{
            //    bind_flownews();
            //}
        }

        public void bind_flownews()
        {
            //dataGridView1.AutoGenerateColumns =false ;
            //dataGridView1.DataSource = select.bind_FlowNews();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string id = dataGridView1.SelectedCells[0].Value.ToString();
            //if (delete.delete_FlowNews(id) > 0)
            //{
            //    bind_flownews();
            //}
        }

        private void DGVGH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in DGVGH.Rows)
            {
                row.Cells[0].Value   =row.Index+1;
            }
        }

        private void DGVSH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in DGVSH.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
        }

        private void DGVPM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in DGVPM.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
        }



    }
}
