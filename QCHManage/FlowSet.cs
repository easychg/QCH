using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QCHManage
{
    public partial class FlowSet : Form
    {
        public FlowSet()
        {
            InitializeComponent();
        }

        Operation.Select select = new Operation.Select();
        Operation.Insert insert = new Operation.Insert();
        Operation.Delete delete = new Operation.Delete();
        private void FlowSet_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = select.bind_pinming();
            comboBox1.DisplayMember = "gn_name";

            //listBox1.Items.Clear();
            //DataTable dt = select.bind_FlowNews();
            //if (dt.Rows.Count > 0)
            //{
            //    for(int i=0;i<dt.Rows.Count;i++)
            //    {
            //      listBox1. Items.Add(dt.Rows[i]["fn_name"].ToString());
            //    }
            //}

            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = select.bind_FlowNews_fn_area();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //右移
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            //listBox1.Items.Remove(listBox1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //左移
            //listBox1.Items.Add(listBox2.SelectedItem.ToString());
            listBox2.Items.Remove(listBox2.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //在文本中显示
            string str = "";
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                str += listBox2.Items[i].ToString()+"-";
            }
            textBox1.Text = str.Substring(0, str.LastIndexOf("-"));

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //添加流程
            if (insert.insert_FlowSet(comboBox1.Text, textBox1.Text) > 0)
            {
                MessageBox.Show("设置成功!");
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据下位内容显示
            SqlDataReader dr = select.read_FlowSet_fs_pname_flowset(comboBox1.Text);
            if (dr.Read())
            {
                textBox1.Text = dr["fs_flowset"].ToString();
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (delete.delete_FlowSet_fs_pname(comboBox1.Text) > 0)
            {
                MessageBox.Show("删除成功");
                comboBox1_SelectedIndexChanged(null, e);
            }
        }

      

      

      

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.DataSource = select.bind_pinming();
            //comboBox1.DisplayMember = "gn_name";

            //listBox1.Items.Clear();
            //DataTable dt = select.bind_FlowNews();
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        listBox1.Items.Add(dt.Rows[i]["fn_name"].ToString());
            //    }
            //}

            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = select.bind_FlowNews_fn_area();
        }
    }
}
