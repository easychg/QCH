using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace QCHManage
{
    public partial class Frm_Print : Form
    {
        public Frm_Print()
        {
            InitializeComponent();
        }
        DataGridViewPrint dataGridViewPrint = null;
        private void Frm_Print_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource = select.bind_distinct_shdw();
            System.Data.DataTable table = (System.Data.DataTable)comboBox1.DataSource;
            DataRow dr = table.NewRow();
            dr[0] = "全部";
            table.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "ru_shdw";
            comboBox1.SelectedIndex = 0;

            comboBox2.DataSource = select.bind_distinct_pm();
            System.Data.DataTable table1 = (System.Data.DataTable)comboBox2.DataSource;
            DataRow dr1 = table1.NewRow();
            dr1[0] = "全部";
            table1.Rows.InsertAt(dr1, 0);
            comboBox2.DataSource = table1;
            comboBox2.DisplayMember = "gn_name";
            comboBox2.SelectedIndex = 0;

            bind_gridview1();
            starttime2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            endtime2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            hz_startday.Text = DateTime.Now.ToString("yyyy-MM-dd");
            hz_endday . Text = DateTime.Now.ToString("yyyy-MM-dd");

        }
        Operation.Select select = new Operation.Select();
        public void bind_gridview1()
        {

            string where = "and convert(datetime,cz_cmzsj) between '" + Convert.ToDateTime(start_time.Text).ToString("yyyy-MM-dd") + " 00:00:00' and '" + Convert.ToDateTime(end_time.Text).ToString("yyyy-MM-dd") + " 23:59:59'";
            if (comboBox1.Text != "全部")
            {
                where += "and ru_shdw='" + comboBox1.Text + "'";
            }
            string sqlstr = "select * from CZJL where cz_wcbj='完成'  and  cz_szq='" + ConnectionManger.G_MineArea + "'" + where + " order by ru_shdw,convert(datetime,cz_cmzsj) desc";
            System.Data.DataTable dt = SQLHelper.GetDataSet("select * from CZJL where cz_wcbj='完成'  and  cz_szq='" + ConnectionManger.G_MineArea + "'" + where + " order by ru_shdw,cz_inserttime desc", CommandType.Text).Tables[0];

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;

            double sumjz = 0.0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() != "")
                {
                    sumjz += double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                }
            }
            toolStripStatusLabel2.Text = sumjz.ToString("0.0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bind_gridview1();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string time_duan = "(" + Convert.ToDateTime(start_time.Text).ToString("yyyy-MM-dd") + " 00:00:00-" + Convert.ToDateTime(end_time.Text).ToString("yyyy-MM-dd") + " 23:59:59)";
            //显示打印对话框
            PrintDialog MyDlg = new PrintDialog();
            MyDlg.Document = this.printDocument1;
            if (MyDlg.ShowDialog().Equals(DialogResult.OK))
            {
                //显示打印预览对话框
                dataGridViewPrint = new DataGridViewPrint(dataGridView1, printDocument1, true, true, "数据报表", new System.Drawing.Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true, time_duan, "按收货单位货分类统计", 560, "合计：" + toolStripStatusLabel2.Text);
                PrintPreviewDialog a = new PrintPreviewDialog();
                a.Document = this.printDocument1;
                a.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //true表示还有数据行没有打印完,则继续打
            if (dataGridViewPrint.DrawDataGridView(e.Graphics))
            {
                //附加打印页
                e.HasMorePages = true;
            }
            else
            {
                DataGridViewPrint.PageNumber = 0;
                DataGridViewPrint.mColumnPoints.Clear();
                DataGridViewPrint.mColumPointsWidth.Clear();
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
        }
        public void bind_gridview2()
        {
            if (starttime2.Text != "" & endtime2.Text != "")
            {
                string where = "and convert(datetime,cz_cmzsj) between '" + Convert.ToDateTime(starttime2.Text).ToString("yyyy-MM-dd") + " 00:00:00' and '" + Convert.ToDateTime(endtime2.Text).ToString("yyyy-MM-dd") + " 23:59:59'";
           
            if (comboBox2.Text != "全部")
            {
                where += "and gn_name='" + comboBox2.Text + "'";
            }
            string str = "select * from CZJL where cz_wcbj='完成' and  cz_szq='" + ConnectionManger.G_MineArea + "'" + where + " order by gn_name,convert(datetime,cz_cmzsj) desc";
            System.Data.DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;

            double sumjz = 0.0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[6].Value.ToString() != "")
                {
                    sumjz += double.Parse(dataGridView2.Rows[i].Cells[6].Value.ToString());
                }
            }
            toolStripStatusLabel4.Text = sumjz.ToString("0.0");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bind_gridview2();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //true表示还有数据行没有打印完,则继续打
            if (dataGridViewPrint.DrawDataGridView(e.Graphics))
            {
                //附加打印页
                e.HasMorePages = true;
            }
            else
            {
                DataGridViewPrint.PageNumber = 0;
                DataGridViewPrint.mColumnPoints.Clear();
                DataGridViewPrint.mColumPointsWidth.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string time_duan = "(" + Convert.ToDateTime(start_time.Text).ToString("yyyy-MM-dd") + " 00:00:00-" + Convert.ToDateTime(end_time.Text).ToString("yyyy-MM-dd") + " 23:59:59)";
            //显示打印对话框
            PrintDialog MyDlg = new PrintDialog();
            MyDlg.Document = this.printDocument1;
            if (MyDlg.ShowDialog().Equals(DialogResult.OK))
            {
                //显示打印预览对话框
                dataGridViewPrint = new DataGridViewPrint(dataGridView2, printDocument1, true, true, "数据报表", new System.Drawing.Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true, time_duan, "按品名分类统计", 560, "合计：" + toolStripStatusLabel2.Text);
                PrintPreviewDialog a = new PrintPreviewDialog();
                a.Document = this.printDocument2;
                a.ShowDialog();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_gridview2();
        }
        public static bool OutToExcelFromDataGridView(string title, DataGridView dgv, bool isShowExcel, string strtime, string printtype, int pagerows, double rowsheight,string  sumall)
        {
            int titleColumnSpan = 0;//标题的跨列数
            string fileName = "";//保存的excel文件名
            int columnIndex = 1;//列索引
            if (dgv.Rows.Count == 0)
                return false;
            /*保存对话框*/
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "导出Excel(*.xls)|*.xls";
            sfd.FileName = title + DateTime.Now.ToString("yyyyMMddhhmmss");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                /*建立Excel对象*/
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    MessageBox.Show("无法创建Excel对象,可能您的计算机未安装Excel!");
                    return false;
                }
                try
                {
                    double icout = dgv.Rows.Count;//数据的行数
                    int rowcount = 0;//页数
                    rowcount = Convert.ToInt32(Math.Ceiling(icout / pagerows));

                    int ilist = 1;//行号

                    excel.Application.Workbooks.Add(true);
                    excel.Visible = isShowExcel;
                    /*分析标题的跨列数*/
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible == true)
                            titleColumnSpan++;
                    }

                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                    for (int k = 0; k < rowcount; k++)
                    {
                        //设置标题
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan] as Range).Merge(); /*合并标题单元格*/
                        
                        
                        /*生成标题*/
                        excel.Cells[ilist, 1] = title;
                        Range range = (Range)(excel.Cells[ilist, 1]);
                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Bold = true;
                        range.Font.Size = 16;
                        range.RowHeight = rowsheight;
                        ilist++;

                        //设置日期段
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan] as Range).Merge();
                        excel.Cells[ilist, 1] = strtime;
                        range = (Range)(excel.Cells[ilist, 1]);
                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Bold = true;
                        range.Font.Size = 9;
                        range.RowHeight = rowsheight;
                        ilist++;

                        //设置打印日期
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, 3] as Range).Merge();
                        excel.Cells[ilist, 1] = "打印日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        range = (Range)(excel.Cells[ilist, 1]);
                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Size = 8;
                        range.RowHeight = rowsheight;

                        //显示报表类型
                        worksheet.get_Range(worksheet.Cells[ilist, titleColumnSpan - 1] as Range, worksheet.Cells[ilist, titleColumnSpan] as Range).Merge();
                        excel.Cells[ilist, 7] = printtype;
                        range = (Range)(excel.Cells[ilist, 7]);
                        (excel.Cells[ilist, 7] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Size = 9;
                        range.RowHeight = rowsheight;

                        ilist++;

                        //生成字段名称.
                        columnIndex = 1;


                        for (int i = 0; i < dgv.ColumnCount; i++)
                        {
                            if (dgv.Columns[i].Visible == true)
                            {

                                excel.Cells[ilist, columnIndex] = dgv.Columns[i].HeaderText;
                                (excel.Cells[ilist, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//字段居中
                                (excel.Cells[ilist, columnIndex] as Range).Font.Size = 9;
                                (excel.Cells[ilist, columnIndex] as Range).RowHeight = rowsheight;
                                (excel.Cells[ilist, columnIndex] as Range).Font.Bold = true;
                                (excel.Cells[ilist, columnIndex] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                (excel.Cells[ilist, columnIndex] as Range).Font.Name = "宋体";
                                columnIndex++;
                            }
                        }
                        ilist++;

                        int d = 1;
                        string content = "1";  //记录单元格内容，做比较，如果相同则合并单元格
                        string content2 = "";
                        //填充数据              
                        for (int i = k * pagerows; i < (k + 1) * pagerows; i++)
                        {
                           
                            if (i >= dgv.Rows.Count)
                            {
                                break;
                            }
                            columnIndex = 1;
                            for (int j = 0; j < dgv.ColumnCount; j++)
                            {
                                if (dgv.Columns[j].Visible == true)
                                {
                                    if (dgv[j, i].ValueType == typeof(string))
                                    {
                            
                                            excel.Cells[ilist, columnIndex] = "'" + dgv[j, i].Value.ToString();
                                   
                                    }
                                    else
                                    {
            
                                            excel.Cells[ilist, columnIndex] = dgv[j, i].Value.ToString();
                                    
                                    }
                                    if (j == 1)
                                    {
                                        content = dgv[j, i].Value.ToString();
                                        if (content == content2)
                                        {
                                            d++;
                                            if (d == 2)
                                            {
                                                excel.Cells[ilist, columnIndex] = "";
                                                worksheet.get_Range(worksheet.Cells[ilist - 1, 2] as Range, worksheet.Cells[ilist, 2] as Range).Merge(0); /*合并标题单元格*/
                                               
                                                d = 1;
                                            }
                                            
                                        }
                                        content2 = content;
                                    }



                                    (excel.Cells[ilist, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//字段居中
                                    (excel.Cells[ilist, columnIndex] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                    (excel.Cells[ilist, columnIndex] as Range).RowHeight = rowsheight;
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Size = 9;
                                    columnIndex++;
                                }
                            }
                            ilist++;
                        }
                        if ((k+1) == rowcount)
                        {
                            //设置页码
                            //worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan] as Range).Merge(); /*合并*/
                            /*生成标题*/
                            excel.Cells[ilist, 2] = "合计：";
                            (excel.Cells[ilist, 2] as Range).HorizontalAlignment = XlHAlign.xlHAlignRight;//标题居右
                            (excel.Cells[ilist, 2] as Range).Font.Size = 9;
                            (excel.Cells[ilist, 2] as Range).RowHeight = rowsheight;
                            (excel.Cells[ilist, 2] as Range).Font.Bold = true;
                            excel.Cells[ilist, 3] = "车数：" + dgv.Rows.Count;
                            (excel.Cells[ilist, 3] as Range).HorizontalAlignment = XlHAlign.xlHAlignRight;//标题居右
                            (excel.Cells[ilist, 3] as Range).Font.Size = 9;
                            (excel.Cells[ilist, 3] as Range).RowHeight = rowsheight;
                            excel.Cells[ilist, 7] = sumall;
                            (excel.Cells[ilist, 7] as Range).HorizontalAlignment = XlHAlign.xlHAlignRight;//标题居右
                            (excel.Cells[ilist, 7] as Range).Font.Size = 9;
                            (excel.Cells[ilist, 7] as Range).RowHeight = rowsheight;
                            ilist++;
                        }
                        //设置页码
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan] as Range).Merge(); /*合并*/
                       
                        /*生成标题*/
                        excel.Cells[ilist, 1] = "第" + (k + 1) + "页/共" + rowcount + "页";

                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignRight;//标题居右

                        (excel.Cells[ilist, 1] as Range).Font.Size = 9;
                        (excel.Cells[ilist, 1] as Range).RowHeight = rowsheight;
                        ilist++;

                    }
                    worksheet.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch { }
                finally
                {
                    excel.Quit();
                    excel = null;
                    GC.Collect();
                }
                //KillProcess("Excel");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool OutToExcelFromDataGridView1(string title, DataGridView dgv, bool isShowExcel, string strtime, string printtype, int pagerows, double rowsheight, string sumall)
        {
            int titleColumnSpan = 0;//标题的跨列数
            string fileName = "";//保存的excel文件名
            int columnIndex = 1;//列索引
            if (dgv.Rows.Count == 0)
                return false;
            /*保存对话框*/
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "导出Excel(*.xls)|*.xls";
            sfd.FileName = title + DateTime.Now.ToString("yyyyMMddhhmmss");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                /*建立Excel对象*/
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    MessageBox.Show("无法创建Excel对象,可能您的计算机未安装Excel!");
                    return false;
                }
                try
                {
                    double icout = dgv.Rows.Count;//数据的行数
                    int rowcount = 0;//页数
                    rowcount = Convert.ToInt32(Math.Ceiling(icout / pagerows));

                    int ilist = 1;//行号

                    excel.Application.Workbooks.Add(true);
                    excel.Visible = isShowExcel;
                    /*分析标题的跨列数*/
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible == true)
                            titleColumnSpan++;
                    }

                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                    for (int k = 0; k < rowcount; k++)
                    {
                        //设置标题
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan+2] as Range).Merge(); /*合并标题单元格*/


                        /*生成标题*/
                        excel.Cells[ilist, 1] = title;
                        Range range = (Range)(excel.Cells[ilist, 1]);
                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Bold = true;
                        range.Font.Size = 16;
                        range.RowHeight = rowsheight;
                        ilist++;

                        //设置日期段
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan+2] as Range).Merge();
                        excel.Cells[ilist, 1] = strtime;
                        range = (Range)(excel.Cells[ilist, 1]);
                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Bold = true;
                        range.Font.Size = 9;
                        range.RowHeight = rowsheight;
                        ilist++;

                        //设置打印日期
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, 3] as Range).Merge();
                        excel.Cells[ilist, 1] = "打印日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        range = (Range)(excel.Cells[ilist, 1]);
                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Size = 8;
                        range.RowHeight = rowsheight;

                        //显示报表类型
                        worksheet.get_Range(worksheet.Cells[ilist, titleColumnSpan - 1] as Range, worksheet.Cells[ilist, titleColumnSpan] as Range).Merge();
                        excel.Cells[ilist, 7] = printtype;
                        range = (Range)(excel.Cells[ilist, 7]);
                        (excel.Cells[ilist, 7] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                        range.Font.Size = 9;
                        range.RowHeight = rowsheight;

                        ilist++;

                        //生成字段名称.
                        columnIndex = 1;


                        for (int i = 0; i < dgv.ColumnCount; i++)
                        {
                            if (dgv.Columns[i].Visible == true)
                            {

                                if (columnIndex == 2)
                                {
                                    worksheet.get_Range(worksheet.Cells[ilist, 2] as Range, worksheet.Cells[ilist, 4] as Range).Merge(); /*合并标题单元格*/
                                    excel.Cells[ilist, columnIndex] = dgv.Columns[i].HeaderText;
                                    (excel.Cells[ilist, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//字段居中
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Size = 9;
                                    (excel.Cells[ilist, columnIndex] as Range).RowHeight = rowsheight;
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Bold = true;
                                    (excel.Cells[ilist, columnIndex] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                    (excel.Cells[ilist, columnIndex+1] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                    (excel.Cells[ilist, columnIndex+2] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Name = "宋体";
                                    columnIndex = 4;
                                }
                                else
                                {
                                    excel.Cells[ilist, columnIndex] = dgv.Columns[i].HeaderText;
                                    (excel.Cells[ilist, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//字段居中
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Size = 9;
                                    (excel.Cells[ilist, columnIndex] as Range).RowHeight = rowsheight;
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Bold = true;
                                    (excel.Cells[ilist, columnIndex] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Name = "宋体";
                                }
                                columnIndex++;
                            }
                        }
                        ilist++;

                        int d = 1;
                        string content = "1";  //记录单元格内容，做比较，如果相同则合并单元格
                        string content2 = "";
                        //填充数据              
                        for (int i = k * pagerows; i < (k + 1) * pagerows; i++)
                        {

                            if (i >= dgv.Rows.Count)
                            {
                                break;
                            }
                            columnIndex = 1;
                            for (int j = 0; j < dgv.ColumnCount; j++)
                            {
                                if (dgv.Columns[j].Visible == true)
                                {
                                    if (dgv[j, i].ValueType == typeof(string))
                                    {

                                        excel.Cells[ilist, columnIndex] = "'" + dgv[j, i].Value.ToString();

                                    }
                                    else
                                    {

                                        excel.Cells[ilist, columnIndex] = dgv[j, i].Value.ToString();

                                    }
                                    if (j == 1)
                                    {
                                        content = dgv[j, i].Value.ToString();
                                        if (content == content2)
                                        {
                                            d++;
                                            if (d == 2)
                                            {
                                                excel.Cells[ilist, columnIndex] = "";
                                                worksheet.get_Range(worksheet.Cells[ilist - 1, 2] as Range, worksheet.Cells[ilist, 2] as Range).Merge(0); /*合并标题单元格*/

                                                d = 1;
                                            }

                                        }
                                        content2 = content;
                                    }


                                    if (columnIndex == 2)
                                    {
                                        worksheet.get_Range(worksheet.Cells[ilist, 2] as Range, worksheet.Cells[ilist, 4] as Range).Merge(); /*合并标题单元格*/
                                        (excel.Cells[ilist, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter ;//字段居中
                                        (excel.Cells[ilist, columnIndex] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                        (excel.Cells[ilist, columnIndex + 1] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                        (excel.Cells[ilist, columnIndex + 2] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                        (excel.Cells[ilist, columnIndex] as Range).RowHeight = rowsheight;
                                        (excel.Cells[ilist, columnIndex] as Range).Font.Size = 9;
                                        columnIndex = 4;
                                    }

                                    (excel.Cells[ilist, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//字段居中
                                    (excel.Cells[ilist, columnIndex] as Range).Borders.LineStyle = XlLineStyle.xlContinuous;
                                    (excel.Cells[ilist, columnIndex] as Range).RowHeight = rowsheight;
                                    (excel.Cells[ilist, columnIndex] as Range).Font.Size = 9;
                                    columnIndex++;
                                }
                            }
                            ilist++;
                        }
                        if ((k + 1) == rowcount)
                        {
                            //设置页码
                            //worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan] as Range).Merge(); /*合并*/
                            /*生成标题*/
                            excel.Cells[ilist, 2] = "合计：";
                            (excel.Cells[ilist, 2] as Range).HorizontalAlignment = XlHAlign.xlHAlignRight;//标题居右
                            (excel.Cells[ilist, 2] as Range).Font.Size = 9;
                            (excel.Cells[ilist, 2] as Range).RowHeight = rowsheight;
                         
                            excel.Cells[ilist, 7] = sumall;
                            (excel.Cells[ilist, 7] as Range).HorizontalAlignment = XlHAlign.xlHAlignRight;//标题居右
                            (excel.Cells[ilist, 7] as Range).Font.Size = 9;
                            (excel.Cells[ilist, 7] as Range).RowHeight = rowsheight;
                            ilist++;
                        }
                        //设置页码
                        worksheet.get_Range(worksheet.Cells[ilist, 1] as Range, worksheet.Cells[ilist, titleColumnSpan+2] as Range).Merge(); /*合并*/

                        /*生成标题*/
                        excel.Cells[ilist, 1] = "第" + (k + 1) + "页/共" + rowcount + "页";

                        (excel.Cells[ilist, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignRight;//标题居右

                        (excel.Cells[ilist, 1] as Range).Font.Size = 9;
                        (excel.Cells[ilist, 1] as Range).RowHeight = rowsheight;
                        ilist++;

                    }
                    worksheet.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch { }
                finally
                {
                    excel.Quit();
                    excel = null;
                    GC.Collect();
                }
                //KillProcess("Excel");
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void KillProcess(string processName)//杀死与Excel相关的进程
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();//得到所有打开的进程
            try
            {
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(processName))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("没有要导出的数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OutToExcelFromDataGridView("按收货单位分类明细表", dataGridView1, true, DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00 至 " + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59", "按收货单位货分类统计",30,19.5,toolStripStatusLabel2.Text );
            #region 导出excel数据，纯数据
            //try
            //{
            //    saveFileDialog1.Title = "按收货单位分类导出数据";
            //    saveFileDialog1.Filter = "Excel(*.xls)|*.xls";
            //    saveFileDialog1.FileName = string.Format("按收货单位分类--{0}", DateTime.Now.ToString("yyyyMMdd"));
            //    DialogResult result = saveFileDialog1.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        //sb.Show("系统正在处理中...请稍候！", true);
            //        Microsoft.Office.Interop.Excel._Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            //        Microsoft.Office.Interop.Excel.Workbook xlbook = xlapp.Workbooks.Add(true);
            //        Microsoft.Office.Interop.Excel.Worksheet xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlbook.Worksheets[1];
            //        int colIndex = 0;
            //        int RowIndex = 1;
            //        string headInfo = "序号,收货单位,品名,车号,皮重,毛重,净重,单号";
            //        //开始写入每列的标题
            //        foreach (var s in headInfo.Split(','))
            //        {
            //            colIndex++;
            //            xlsheet.Cells[RowIndex, colIndex] = s;
            //        }

            //        //开始写入内容 
            //        int RowCount = this.dataGridView1.Rows.Count;//行数
            //        for (int i = 0; i < RowCount; i++)
            //        {
            //            RowIndex++;
            //            xlsheet.Cells[RowIndex, 1].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 1] = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //            xlsheet.Cells[RowIndex, 2].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 2] = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //            xlsheet.Cells[RowIndex, 3].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 3] = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //            xlsheet.Cells[RowIndex, 4].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 4] = dataGridView1.Rows[i].Cells[3].Value.ToString();
            //            xlsheet.Cells[RowIndex, 5].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 5] = dataGridView1.Rows[i].Cells[4].Value.ToString();
            //            xlsheet.Cells[RowIndex, 6].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 6] = dataGridView1.Rows[i].Cells[5].Value.ToString();
            //            xlsheet.Cells[RowIndex, 7].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 7] = dataGridView1.Rows[i].Cells[6].Value.ToString();
            //            xlsheet.Cells[RowIndex, 8].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 8] = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        

            //            //xlsheet.Cells[RowIndex, 9].NumberFormatLocal = "@";
            //            //xlsheet.Cells[RowIndex, 9] = dataGridView1.Rows[i].Cells["ReceiceLink"].Value.ToString();
            //            //xlsheet.Cells[RowIndex, 10].NumberFormatLocal = "@";
            //            //xlsheet.Cells[RowIndex, 10] = dataGridView1.Rows[i].Cells["Remark"].Value.ToString();
            //            //xlsheet.Cells[RowIndex, 11].NumberFormatLocal = "@";
            //            //xlsheet.Cells[RowIndex, 11] = dataGridView1.Rows[i].Cells["WriteTime"].Value.ToString();
            //        }
            //        xlbook.Saved = true;
            //        xlbook.SaveCopyAs(saveFileDialog1.FileName);
            //        xlapp.Quit();
            //        GC.Collect();

            //        #region 强行杀死最近打开的Excel进程
            //        System.Diagnostics.Process[] excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            //        System.DateTime startTime = new DateTime();
            //        int m, killId = 0;
            //        for (m = 0; m < excelProc.Length; m++)
            //        {
            //            if (startTime < excelProc[m].StartTime)
            //            {
            //                startTime = excelProc[m].StartTime;
            //                killId = m;
            //            }
            //        }
            //        if (excelProc[killId].HasExited == false)
            //        {
            //            excelProc[killId].Kill();
            //        }
            //        #endregion

            //        //sb.Close();
            //        MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch
            //{
            //    //sb.Close();
            //    MessageBox.Show("导出失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count < 1)
            {
                MessageBox.Show("没有要导出的数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OutToExcelFromDataGridView("按品名分类导出数据表", dataGridView2, true, DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00 至 " + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59", "按收品名分类统计", 30, 19.5, toolStripStatusLabel4.Text);

            #region  导出数据
            //try
            //{
            //    saveFileDialog2.Title = "按品名分类导出数据";
            //    saveFileDialog2.Filter = "Excel(*.xls)|*.xls";
            //    saveFileDialog2.FileName = string.Format("按品名分类--{0}", DateTime.Now.ToString("yyyyMMdd"));
            //    DialogResult result = saveFileDialog2.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        //sb.Show("系统正在处理中...请稍候！", true);
            //        Microsoft.Office.Interop.Excel._Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            //        Microsoft.Office.Interop.Excel.Workbook xlbook = xlapp.Workbooks.Add(true);
            //        Microsoft.Office.Interop.Excel.Worksheet xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlbook.Worksheets[1];
            //        int colIndex = 0;
            //        int RowIndex = 1;
            //        string headInfo = "序号,收货单位,品名,车号,皮重,毛重,净重,单号";
            //        //开始写入每列的标题
            //        foreach (var s in headInfo.Split(','))
            //        {
            //            colIndex++;
            //            xlsheet.Cells[RowIndex, colIndex] = s;
            //        }

            //        //开始写入内容 
            //        int RowCount = this.dataGridView2.Rows.Count;//行数
            //        for (int i = 0; i < RowCount; i++)
            //        {
            //            RowIndex++;
            //            xlsheet.Cells[RowIndex, 1].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 1] = dataGridView2.Rows[i].Cells[0].Value.ToString();
            //            xlsheet.Cells[RowIndex, 2].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 2] = dataGridView2.Rows[i].Cells[1].Value.ToString();
            //            xlsheet.Cells[RowIndex, 3].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 3] = dataGridView2.Rows[i].Cells[2].Value.ToString();
            //            xlsheet.Cells[RowIndex, 4].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 4] = dataGridView2.Rows[i].Cells[3].Value.ToString();
            //            xlsheet.Cells[RowIndex, 5].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 5] = dataGridView2.Rows[i].Cells[4].Value.ToString();
            //            xlsheet.Cells[RowIndex, 6].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 6] = dataGridView2.Rows[i].Cells[5].Value.ToString();
            //            xlsheet.Cells[RowIndex, 7].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 7] = dataGridView2.Rows[i].Cells[6].Value.ToString();
            //            xlsheet.Cells[RowIndex, 8].NumberFormatLocal = "@";
            //            xlsheet.Cells[RowIndex, 8] = dataGridView2.Rows[i].Cells[7].Value.ToString();


            //            //xlsheet.Cells[RowIndex, 9].NumberFormatLocal = "@";
            //            //xlsheet.Cells[RowIndex, 9] = dataGridView1.Rows[i].Cells["ReceiceLink"].Value.ToString();
            //            //xlsheet.Cells[RowIndex, 10].NumberFormatLocal = "@";
            //            //xlsheet.Cells[RowIndex, 10] = dataGridView1.Rows[i].Cells["Remark"].Value.ToString();
            //            //xlsheet.Cells[RowIndex, 11].NumberFormatLocal = "@";
            //            //xlsheet.Cells[RowIndex, 11] = dataGridView1.Rows[i].Cells["WriteTime"].Value.ToString();
            //        }
            //        xlbook.Saved = true;
            //        xlbook.SaveCopyAs(saveFileDialog1.FileName);
            //        xlapp.Quit();
            //        GC.Collect();

            //        #region 强行杀死最近打开的Excel进程
            //        System.Diagnostics.Process[] excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            //        System.DateTime startTime = new DateTime();
            //        int m, killId = 0;
            //        for (m = 0; m < excelProc.Length; m++)
            //        {
            //            if (startTime < excelProc[m].StartTime)
            //            {
            //                startTime = excelProc[m].StartTime;
            //                killId = m;
            //            }
            //        }
            //        if (excelProc[killId].HasExited == false)
            //        {
            //            excelProc[killId].Kill();
            //        }
            //        #endregion

            //        //sb.Close();
            //        MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch
            //{
            //    //sb.Close();
            //    MessageBox.Show("导出失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            #endregion
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sumcar = 0;
            double  sumjz = 0.0;
           System.Data. DataTable dtsum = select.bind_sjhz(hz_startday.Text, hz_endday.Text);
           if (dtsum.Rows.Count > 0)
           {
               for (int i = 0; i < dtsum.Rows.Count; i++)
               {
                   if (dtsum.Rows[i]["carnumber"].ToString() != "")
                   {
                       sumcar += Convert.ToInt32(dtsum.Rows[i]["carnumber"].ToString());
                   }
                   if (dtsum.Rows[i]["sumjz"].ToString()!="")
                   {
                       sumjz += Convert.ToDouble(dtsum.Rows[i]["sumjz"].ToString());
                   }
               }
           }

           toolStripStatusLabel6.Text = "总车数量： " + sumcar.ToString() + " 辆；总净重为： " + sumjz.ToString() + " 吨";

            dataGridView3.AutoGenerateColumns = false;

            dataGridView3.DataSource = select.bind_sjhz(hz_startday.Text, hz_endday.Text);

        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (this.dataGridView3.Rows.Count < 1)
            {
                MessageBox.Show("没有要导出的数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OutToExcelFromDataGridView1("数据汇总", dataGridView3, true, DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00 至 " + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59", "数据汇总", 30, 19.5, toolStripStatusLabel6.Text);


    
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string time_duan = "(" + Convert.ToDateTime(start_time.Text).ToString("yyyy-MM-dd") + " 00:00:00-" + Convert.ToDateTime(end_time.Text).ToString("yyyy-MM-dd") + " 23:59:59)";
            //显示打印对话框
            PrintDialog MyDlg = new PrintDialog();
            MyDlg.Document = this.printDocument1;
            if (MyDlg.ShowDialog().Equals(DialogResult.OK))
            {
                //显示打印预览对话框
                dataGridViewPrint = new DataGridViewPrint(dataGridView3, printDocument1, true, true, "数据报表", new System.Drawing.Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true, time_duan, "数据汇总", 560, "净重合计：" + toolStripStatusLabel2.Text);
                PrintPreviewDialog a = new PrintPreviewDialog();
                a.Document = this.printDocument2;
                a.ShowDialog();
            }
        }


    }
}
