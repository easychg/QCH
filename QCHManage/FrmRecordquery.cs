using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace QCHManage
{
    public partial class FrmRecordquery : Form
    {
        List<string> listListNo = new List<string>();
        List<string> listCarNumber = new List<string>();
        List<string> listContractNo = new List<string>();
        List<string> listReciveUnit = new List<string>();
        int ImageFlag = 0;

        private void UpdataListNo()
        {
            string str = "select distinct cz_dh from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listListNo.Clear();
            cmbListNo.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listListNo.Add(dt.Rows[i]["cz_dh"].ToString());
            }
            cmbListNo.Items.AddRange(listListNo.ToArray());
            dt.Dispose();
        }

        private void UpdataCarNumber()
        {
            string str = "select distinct cz_ch from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listCarNumber.Clear();
            cmbCarNumber.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listCarNumber.Add(dt.Rows[i]["cz_ch"].ToString());
            }
            cmbCarNumber.Items.AddRange(listCarNumber.ToArray());
            dt.Dispose();
        }

        private void UpdataContractNo()
        {
            string str = "select distinct cn_code from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
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

        private void UpdataReciveUnit()
        {
            string str = "select distinct ru_shdw from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            listReciveUnit.Clear();
            cmbReciveUnit.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listReciveUnit.Add(dt.Rows[i]["ru_shdw"].ToString());
            }
            cmbReciveUnit.Items.AddRange(listReciveUnit.ToArray());
            dt.Dispose();
        }

        private void UpdataGoodsName()
        {
            string str = "select distinct gn_name from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            cmbGoodsName.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbGoodsName.Items.Add(dt.Rows[i]["gn_name"].ToString());
            }
            dt.Dispose();
        }

        private void UpdataSby()
        {
            string str = "select distinct cz_sby from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            cmbsby.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbsby.Items.Add(dt.Rows[i]["cz_sby"].ToString());
            }
            dt.Dispose();
        }

        private void UpdataSupplyUnit()
        {
            string str = "select distinct cz_gwdw from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            cmbSupplyUnit.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbSupplyUnit.Items.Add(dt.Rows[i]["cz_gwdw"].ToString());
            }
            dt.Dispose();
        }

        private void UpdataDGVJL(string where)
        {
            DGVJL.AutoGenerateColumns = false;
            string str = "select fw_flow,cz_dh,cz_ch,cz_kh,cz_jsy,gn_name,cz_mz,cz_pz,cz_jz,cn_code,cz_sby,cz_cpzsj,cz_cmzsj,cz_wcbj,fw_lcjd,cz_gwdw,ru_shdw from CZJL left join Flow on cz_dh = fw_bdh where cz_szq = '" + ConnectionManger.G_MineArea + "'" + where;
            DGVJL.DataSource = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
        }

        public FrmRecordquery()
        {
            InitializeComponent();
        }

        private void FrmRecordquery_Load(object sender, EventArgs e)
        {
            TimeStar.Text = (DateTime.Now.AddMonths(-1)).ToString("yyyy/MM/dd");
            btnUp.Visible = false;
            if (ConnectionManger.UserType == "管理员")
            {
                btnClearAll.Visible = true;
            }
            else
            {
                btnClearAll.Visible = false;
            }
        }

        private void btnCX_Click(object sender, EventArgs e)
        {
            UpdataListNo();
            UpdataCarNumber();
            UpdataContractNo();
            UpdataReciveUnit();
            UpdataGoodsName();
            UpdataSby();
            UpdataSupplyUnit();
            GBCX.Visible = true;
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            string where;
            string starttime, endtime;
            starttime = TimeStar.Text + " 00:00:00";
            endtime = timeEnd.Text + " 23:59:59";
            if (rBtmz.Checked)
            {
                where = " and convert(datetime,cz_cmzsj) between '" + starttime + "' and '" + endtime + "'";
            }
            else
            {
                where = " and convert(datetime,cz_cpzsj) between '" + starttime + "' and '" + endtime + "'";
            }
            if (cmbListNo.Text.Trim() != "") where += " and cz_dh = '" + cmbListNo.Text + "'";
            if (cmbCarNumber.Text.Trim() != "") where += " and cz_ch = '" + cmbCarNumber.Text + "'";
            if (txtCarNo.Text.Trim() != "") where += " and cz_kh = '" + txtCarNo.Text + "'";
            if (txtDriver.Text.Trim() != "") where += " and cz_jsy = '" + txtDriver.Text + "'";
            if (cmbGoodsName.Text.Trim() != "") where += " and gn_name = '" + cmbGoodsName.Text + "'";
            if (cmbContractNo.Text.Trim() != "") where += " and cn_code = '" + cmbContractNo.Text + "'";
            if (cmbsby.Text.Trim() != "") where += " and cz_sby = '" + cmbsby.Text + "'";
            if (cmbFlag.Text.Trim() != "") where += " and cz_wcbj = '" + cmbFlag.Text + "'";
            if (cmbSupplyUnit.Text.Trim() != "") where += " and cz_gwdw = '" + cmbSupplyUnit.Text + "'";
            if (cmbReciveUnit.Text.Trim() != "") where += " and ru_shdw = '" + cmbReciveUnit.Text + "'";

            UpdataDGVJL(where);
            GBCX.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbListNo.Text = ""; cmbCarNumber.Text = ""; txtCarNo.Text = ""; txtDriver.Text = ""; cmbGoodsName.Text = "";
            cmbContractNo.Text = ""; cmbsby.Text = ""; cmbFlag.Text = ""; cmbSupplyUnit.Text = ""; cmbReciveUnit.Text = "";
        }

        //private void DGVJL_SelectionChanged(object sender, EventArgs e)
        //{
           
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("删除后数据不可恢复，确定要删除所有数据？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                string str = "delete from CZJL where cz_szq = '" + ConnectionManger.G_MineArea + "'";
                SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                str = "delete from CZPhoto where p_area = '" + ConnectionManger.G_MineArea + "'";
                SQLHelper.ExecuteNonQuery(CommandType.Text, str, null);
                UpdataDGVJL("");
            }
            catch
            {
                MessageBox.Show("数据删除失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateImage(string bdh,int flag)
        {
            string str = "select p_photo from CZPhoto where p_bdh = '" + bdh + "' order by p_id ";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            if (flag == 0)
            {
                if (dt.Rows.Count >= 4)
                {
                    byte[] imgbyte1 = (byte[])(dt.Rows[0]["p_photo"]);
                    MemoryStream ms = new MemoryStream(imgbyte1);
                    Image img = Image.FromStream(ms);
                    pic1.Image = img;

                    byte[] imgbyte2 = (byte[])(dt.Rows[1]["p_photo"]);
                    ms = new MemoryStream(imgbyte2);
                    img = new Bitmap(ms);
                    pic2.Image = img;

                    byte[] imgbyte3 = (byte[])(dt.Rows[2]["p_photo"]);
                    ms = new MemoryStream(imgbyte3);
                    img = new Bitmap(ms);
                    pic3.Image = img;

                    byte[] imgbyte4 = (byte[])(dt.Rows[3]["p_photo"]);
                    ms = new MemoryStream(imgbyte4);
                    img = new Bitmap(ms);
                    pic4.Image = img;
                }
                else
                {
                    pic1.Image = null;
                    pic2.Image = null;
                    pic3.Image = null;
                    pic4.Image = null;
                }
            }
            if (flag == 1)
            {
                if (dt.Rows.Count >= 8)
                {
                    byte[] imgbyte1 = (byte[])(dt.Rows[4]["p_photo"]);
                    MemoryStream ms = new MemoryStream(imgbyte1);
                    Image img = Image.FromStream(ms);
                    pic1.Image = img;

                    byte[] imgbyte2 = (byte[])(dt.Rows[5]["p_photo"]);
                    ms = new MemoryStream(imgbyte2);
                    img = new Bitmap(ms);
                    pic2.Image = img;

                    byte[] imgbyte3 = (byte[])(dt.Rows[6]["p_photo"]);
                    ms = new MemoryStream(imgbyte3);
                    img = new Bitmap(ms);
                    pic3.Image = img;

                    byte[] imgbyte4 = (byte[])(dt.Rows[7]["p_photo"]);
                    ms = new MemoryStream(imgbyte4);
                    img = new Bitmap(ms);
                    pic4.Image = img;
                }
                else
                {
                    pic1.Image = null;
                    pic2.Image = null;
                    pic3.Image = null;
                    pic4.Image = null;
                }
            }
            
            dt.Dispose();
        }

        private void DGVJL_Click(object sender, EventArgs e)
        {
            if (DGVJL.SelectedRows.Count == 0)
            {
                pic1.Image = null;
                pic2.Image = null;
                pic3.Image = null;
                pic4.Image = null;
            }
            else
            {
                //byte[] imgbyte = null;
                string bdh = (DGVJL.SelectedRows[0].Cells["Column1"].Value).ToString();
                UpdateImage(bdh, ImageFlag);

                //string str = "select p_photo from CZPhoto where p_bdh = '" + bdh + "' order by p_id ";
                //SqlDataReader reader= SQLHelper.ExecuteReader(CommandType.Text ,str,null);
                //int i = 0;

                ////if (reader.Read())
                ////{
                ////    byte[] imgbyte = (byte[])(reader["p_photo"]);
                ////    MemoryStream ms = new MemoryStream(imgbyte);
                ////    Image img = Image.FromStream(ms);
                ////    if (i == 0) pic1.Image = img;
                ////}

                //while (reader.Read())
                //{
                //    byte[] imgbyte = (byte[])(reader["p_photo"]);
                //    MemoryStream ms = new MemoryStream(imgbyte);
                //    Image img = Image.FromStream(ms);
                //    if (i == 0) pic1.Image = img;
                //    else if (i == 1) pic2.Image = img;
                //    else if (i == 2) pic3.Image = img;
                //    else if (i == 3) pic4.Image = img;
                //    i += 1;
                //}
                
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ImageFlag = 0;
            string bdh = (DGVJL.SelectedRows[0].Cells["Column1"].Value).ToString();
            UpdateImage(bdh, ImageFlag);
            btnUp.Visible = false;
            btnNext.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ImageFlag = 1;
            string bdh = (DGVJL.SelectedRows[0].Cells["Column1"].Value).ToString();
            UpdateImage(bdh, ImageFlag);
            btnUp.Visible = true;
            btnNext.Visible = false;
        }

        private void cmbListNo_TextUpdate(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            cmbListNo.Items.Clear();
            listNew.Clear();
            foreach (var item in listListNo)
            {
                if (item.Contains(cmbListNo.Text))
                {
                    listNew.Add(item);
                }
            }
            cmbListNo.Items.AddRange(listNew.ToArray());
            cmbListNo.SelectionStart = cmbListNo.Text.Length;
            Cursor = Cursors.Default;
            cmbListNo.DroppedDown = true;
        }

        private void cmbCarNumber_TextUpdate(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            cmbCarNumber.Items.Clear();
            listNew.Clear();
            foreach (var item in listCarNumber)
            {
                if (item.Contains(cmbCarNumber.Text))
                {
                    listNew.Add(item);
                }
            }
            cmbCarNumber.Items.AddRange(listNew.ToArray());
            cmbCarNumber.SelectionStart = cmbCarNumber.Text.Length;
            Cursor = Cursors.Default;
            cmbCarNumber.DroppedDown = true;
        }

        private void cmbContractNo_TextUpdate(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            cmbContractNo.Items.Clear();
            listNew.Clear();
            foreach (var item in listContractNo)
            {
                if (item.Contains(cmbContractNo.Text))
                {
                    listNew.Add(item);
                }
            }
            cmbContractNo.Items.AddRange(listNew.ToArray());
            cmbContractNo.SelectionStart = cmbContractNo.Text.Length;
            Cursor = Cursors.Default;
            cmbContractNo.DroppedDown = true;
        }

        private void cmbReciveUnit_TextChanged(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            cmbReciveUnit.Items.Clear();
            listNew.Clear();
            foreach (var item in listReciveUnit)
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




    }
}
