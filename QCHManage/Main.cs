using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Xml;
using System.Threading;
//using ReaderB;
using System.IO.Ports;
using System.Speech.Synthesis;
using System.Drawing.Printing;

//using Microsoft.International.Formatters;
//using Microsoft.International;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;


using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading; 




//在此声明：韩洪伦真是好人啊！注释的这么清楚。我也感觉自己是好人。嘿嘿.....

namespace QCHManage
{
    public partial class Main : Form
    {
        Operation.Insert insert = new Operation.Insert();
        Operation.Update update = new Operation.Update();
        Operation.Delete delete = new Operation.Delete();

        public Main()
        {
            InitializeComponent();
            //skinEngine1.SkinFile = "RealOne.ssk";
            ConnectionManger.readxml();
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();  //初始化SDK
          
        }
        public delegate void processDelete();

        private string publi_led = ""; //大屏显示
        private int public_while = 0; //当选择自动称重时为0，不选中时为1
        private string public_xg_id = "";  //双击数据列表修改数据所需的ID
        private int public_exit = 0;  //当为0时表示程序运行，为1时表示程序不运行
        int heightpan;


        private void Form2_Load(object sender, EventArgs e)
        {
            if (ConnectionManger.UserType == "管理员")
            {
                btntg1.Visible = true;
                btntg2.Visible = true;
            }
            else
            {
                btntg1.Visible = false;
                btntg2.Visible = false;
            }
            read_print_table();
            txtcz_sby.Text = ConnectionManger.UserName;
            //停止大屏
            if (hLed != 0)
            {
                DLL.EndSend(hLed);
                hLed = 0;
            }
            //打开视频
            video();
            //if (ConnectionManger.UserType == "管理员")
            //{
            //    checkBox1.Visible = true;
            //}
            //else
            //{
            //    checkBox1.Visible = false;
            //}
            checkBox1.Enabled = true;
            checkBox1_CheckedChanged(sender, e);
     
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = select.bind_CZJL(ConnectionManger.szqy);
            bind_data();
            bind_hth();
            readcode();//打开串口
            receive_model();//打开ModulBus
            read_yibiao();//打开称重仪表

            //Thread dd = new Thread(yibiaodelete);
            //dd.IsBackground = true;
            //dd.Start();

            //Thread dd2 = new Thread(statustimedelete);
            //dd2.IsBackground = true;
            //dd2.Start();



            //Thread dd3 = new Thread(read_all);
            //dd3.IsBackground = true;
            //dd3.Start();

            //Thread dd4 = new Thread(status_delete);
            //dd4.IsBackground = true;
            //dd4.Start();
            read_all();

            //Thread th = new Thread(new ThreadStart(read_all));
            //th.Start();

        }


        public string h(double d)
        {
            string t = "";
            if (d > 29 && d < 40)
            {
                t = (d - 30).ToString();
            }
            else
            {
                t = (d - 31).ToString();
            }
            return t;
        }

        private int itimebz = 0;//时间标志，2为进场刷卡

        private void status_delete()
        {
            while (true)
            {
                status();
                Thread.Sleep(50);
            }
        }
        public void status()
        {
            try
            {
                //this.Invoke((EventHandler)(delegate
                //{
                    send_model("40 30 31 0d");
                    if (fullbyte.Length < 4)
                    {
                        return;
                    }
                    //Thread.Sleep(500);
                    if (fullbyte.Length > 5)
                    {
                        string s = fullbyte[4].ToString("X");
                        string b = h(Convert.ToDouble(s)).ToString();
                        string ejz = Convert.ToDouble(Convert.ToString(Convert.ToInt32(b), 2)).ToString("0000");


                        if (itimebz == 2)
                        {  //进场
                            string bj = ejz.Substring(2, 2);  //获取进场的到位指令
                            if (bj == "10")  //10为抬杆，01为落杆
                            {
                                insert.insert_StatusTable(ConnectionManger.Card_Address, "道闸", 2, 0, 2);//(位置，类型，0——没有，1——落杆或没有遮挡，2——抬杆或遮挡，0——没有，1——落杆或没有遮挡，2——抬杆或遮挡，此为标记位，1为遥控器打开，2为刷卡打开）
                                //send_model("40 30 31 30 30 0d");

                            }
                            else if (bj == "11")
                            { }
                            else
                            {
                                piclg1.Visible = true;
                                itimebz = 0;
                            }
                        }
                        else if (itimebz == 3)
                        {//出场

                            string bj = ejz.Substring(0, 2);  //获取出场的到位指令
                            if (bj == "10")  //10为抬杆，01为落杆
                            {
                                insert.insert_StatusTable(ConnectionManger.Card_Address, "道闸", 2, 0, 2);//(位置，类型，0——没有，1——落杆或没有遮挡，2——抬杆或遮挡，0——没有，1——落杆或没有遮挡，2——抬杆或遮挡，此为标记位，1为遥控器打开，2为刷卡打开）
                                //send_model("40 30 31 30 30 0d");

                            }
                            else if (bj == "11")
                            { }
                            else
                            {
                                piclg2.Visible = true;
                                itimebz = 0;
                            }
                        }
                        else if (itimebz == 0)
                        {
                            string i1 = ejz.Substring(0, 2);
                            string i2 = ejz.Substring(2, 2);
                            if (i1 == "10")
                            {
                                insert.insert_StatusTable(ConnectionManger.Card_Address, "道闸", 2, 0, 1);
                            }
                            if (i2 == "10")
                            {
                                insert.insert_StatusTable(ConnectionManger.Card_Address, "道闸", 2, 0, 1);
                            }

                            piclg2.Visible = true;
                            piclg1.Visible = true;
                        }
                    }
                //}));
            }
            catch (Exception ex)
            { }
        }

        public void bind_hth()
        {
            string str = "select cn_code from ContractNews where cn_area = '" + ConnectionManger.G_MineArea + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            for (int i=0;i<dt.Rows.Count;i++)
            {
                Com_hth.Items.Add(dt.Rows[i]["cn_code"]);
            }
            dt.Dispose();
        }
        public void bind_data()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = select.bind_CZJL(ConnectionManger.szqy);
            double summz = 0.0, sumpz = 0.0, sumjz = 0.0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "")
                {
                    summz += 0;
                }
                else
                {
                    summz += double.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                }

                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "")
                {
                    sumpz += 0;
                }
                else
                {
                    sumpz += double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                }

                if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "")
                {
                    sumjz += 0;
                }
                else
                {
                    sumjz += double.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                }
                
            }
            toolStripStatusLabel2.Text = "毛重："+ summz.ToString("0.0");
            toolStripStatusLabel3.Text = "皮重：" + sumpz.ToString("0.0");
            toolStripStatusLabel4.Text = "净重：" + sumjz.ToString("0.0");
        }
        private string[] public_name = null ;//存放可打印的数组
        

        public void read_print_table()
        {
            //if (ConnectionManger.no_print != "")
            //{
                public_name = ConnectionManger.no_print.Split('、');
            //}
            //int t = public_name.Length;
            //string[] pname = { "块煤", "石头", "混煤", "原煤", "精煤", "矿渣", "煤渣", "尾炭" };

     

            //DataTable dtfull =select. select_print_table();
            //if (dtfull.Rows.Count > 0)
            //{
            //    for (int i = 0; i < 8; i++)
            //    {
            //        string t = dtfull.Rows[0][i + 2].ToString();
            //        if (t == "1")
            //        {
            //            public_name[i] = pname[i];
            //        }
            //    }
            //}

        }

        #region  ModulBus协议读取、发送模块命令
        private SerialPort comm_model = new SerialPort();
        private StringBuilder builder_Model = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        private string strback = "";               //发送数据返回值
        private byte[]  fullbyte=null;//记录收到的值
        public void receive_model()
        {
            //根据当前串口对象，来判断操作
            if (comm_model.IsOpen)
            {
                //打开时点击，则关闭串口
                comm_model.Close();
            }
            else
            {
                //关闭时点击，则设置好端口，波特率后打开
                comm_model.PortName = ConnectionManger.Model_Com;
                comm_model.BaudRate = 9600;
                try
                {
                    comm_model.Open();
                }
                catch (Exception ex)
                {
                    //捕获到异常信息，创建一个新的comm对象，之前的不能用了。
                    comm_model = new SerialPort();
                   
                }
                //添加事件注册
                //comm_model.DataReceived += comm_DataReceived_Model;
            }
        }

   


        public void send_model(string str)
        {
            try
            {
                if (!comm_model.IsOpen)
                {
                    //打开时点击，则关闭串口
                    comm_model.Open();
                }

                //我们不管规则了。如果写错了一些，我们允许的，只用正则得到有效的十六进制数
                MatchCollection mc = Regex.Matches(str, @"(?i)[\da-f]{2}");
                List<byte> buf_model = new List<byte>();//填充到这个临时列表中
                //依次添加到列表中
                foreach (Match m in mc)
                {
                    buf_model.Add(byte.Parse(Convert.ToInt32(m.Value, 16).ToString()));
                }
                //转换列表为数组后发送
                comm_model.Write(buf_model.ToArray(), 0, buf_model.Count);
                
                Thread.Sleep(1000);


           
               
                int n = comm_model.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
                byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据
                fullbyte = new byte[n];
                
                comm_model.Read(buf, 0, n);//读取缓冲数据
               
                builder_Model.Clear();//清除字符串构造器的内容

                if (mc.Count == 4)
                {
                   
                    if (n < 5)
                    {
                        send_model(str);
                    }
                    else
                    {

                      //
                        if (buf[0].ToString("X") == "3E" && buf[5].ToString("X") == "D")
                        {
                            fullbyte = buf;
                        }
                    }
                  
                }
                //因为要访问ui资源，所以需要使用invoke方式同步ui。
                this.Invoke((EventHandler)(delegate
                {

                    //依次的拼接出16进制字符串
                    foreach (byte b in buf)
                    {

                        builder_Model.Append(b.ToString("X2"));
                    }
                    strback = builder_Model.ToString();
                    //label5.Text = builder_Model.ToString();

                }));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("控制模块有问题，请把控制模块断电重新上电！");
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            //send_model("40 30 31 0d");
            led_send(lbl_weight.Text,2);
        }
        #endregion


        #region  打印


        public void print()
        {
            //设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            this.printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custum", printDocument1.DefaultPageSettings.PaperSize.Width, printDocument1.DefaultPageSettings.PaperSize.Height);
            int i = printDocument1.DefaultPageSettings.PaperSize.Width;
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            ////将写好的格式给打印预览控件以便预览
            //printPreviewDialog1.Document = printDocument1;
            ////显示打印预览
            //DialogResult result = printPreviewDialog1.ShowDialog();

            printDocument1.Print();//直接打印


            
        }
        /// <summary>
        /// 把收到的值大写
        /// </summary>
        /// <param name="str"></param>
        private string bigwrite(string str)
        {
            string bigzhi = "";
            string[] bigdata = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };

            string[] bigwei = { "千", "百", "拾", "点" };
            str = Convert.ToDouble(str).ToString("0.0");
            int strlen = str.Length;
            int[] strdata = new int[strlen];//把字符串转换成数组
            int d = 0;
            int[] strwei = new int[strlen];
            for (int i = 0; i < strlen; i++)
            {
                string std = str.Substring(strlen - i - 1, 1);
                if (std != ".")
                {
                    strdata[d] = int.Parse(std);
                    d++;
                }
                if (d > 2)
                {
                    strwei[d - 3] = d - 3;
                }

            }
            if (strlen == 6)
            {
                //千位数
                bigzhi = bigdata[strdata[4]] + bigwei[0] + bigdata[strdata[3]] + bigwei[1] + bigdata[strdata[2]] + bigwei[2] + bigdata[strdata[1]] + bigwei[3] + bigdata[strdata[0]];
            }
            else if (strlen == 5)
            {
                //百位数
                bigzhi = bigdata[strdata[3]] + bigwei[1] + bigdata[strdata[2]] + bigwei[2] + bigdata[strdata[1]] + bigwei[3] + bigdata[strdata[0]];
            }
            else if (strlen == 4)
            {
                //十位数
                bigzhi = bigdata[strdata[2]] + bigwei[2] + bigdata[strdata[1]] + bigwei[3] + bigdata[strdata[0]];
            }
            else if (strlen == 3)
            {
                //个位数
                bigzhi = bigdata[strdata[1]] + bigwei[3] + bigdata[strdata[0]] ;
            }
            else
            {
                //小数
                bigzhi = "零"+ bigwei[3] + bigdata[strdata[0]];
            }


            return bigzhi;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region 带边框
           
            /*如果需要改变自己 可以在new Font(new FontFamily("黑体"),11）中的“黑体”改成自己要的字体就行了，黑体 后面的数字代表字体的大小 */
            //e.Graphics.DrawString("中煤集团山西华昱能源有限公司（壹号煤场）销煤票", new Font(new FontFamily("宋体"), 14), System.Drawing.Brushes.Black, 170, 30);



            //e.Graphics.DrawString("重量单位", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 70);

            //e.Graphics.DrawString("吨", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 100, 70);
            //e.Graphics.DrawString(DateTime.Now.ToString("yy  MM   dd"), new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 280,40);
            ////e.Graphics.DrawString("编号", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 600, 70);
            //e.Graphics.DrawString(public_bdh, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 650, 40);


            //画横向边框
            //for (int i = 0; i < 6; i++)
            //{
            //    e.Graphics.DrawLine(Pens.Black, 8, 90+i*40, 810, 90+i*40);
            //}
            
            
            //e.Graphics.DrawLine(Pens.Black, 8, 90, 8,290);      //左竖边框1
            //e.Graphics.DrawLine(Pens.Black, 90, 90, 90, 290);   //左竖边框2

            //e.Graphics.DrawLine(Pens.Black, 150, 210, 150, 290); //左竖边框3

            //e.Graphics.DrawLine(Pens.Black, 300, 90, 300, 250); //左竖边框4

            //e.Graphics.DrawLine(Pens.Black, 400, 170,400, 250); //左竖边框5

            //e.Graphics.DrawLine(Pens.Black, 500, 90, 500, 290);   //左竖边框6

            //e.Graphics.DrawLine(Pens.Black, 650, 90, 650, 290);   //左竖边框7


            //e.Graphics.DrawLine(Pens.Black, 810, 90, 810, 290); //右竖边框
         
            //第一列
            //e.Graphics.DrawString("供货单位", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 105);

            //e.Graphics.DrawString(txtcz_gwdw.Text , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 100, 105);

            //e.Graphics.DrawString("收货单位", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 145);

            //e.Graphics.DrawString(txtru_shdw.Text , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 100, 145);

            //e.Graphics.DrawString("物资名称", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 185);

            //e.Graphics.DrawString(txtgn_name.Text , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 100, 185);

            //e.Graphics.DrawString("发货数量", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 225);
            //e.Graphics.DrawString("实发数量", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 265);
            //e.Graphics.DrawString("过磅员", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 305);

            //e.Graphics.DrawString("开票人", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 390, 305);


            ////第二列
            //e.Graphics.DrawString("规格", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 105, 225);
            //e.Graphics.DrawString("大写", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 105, 265);

            //string bigdata=InternationalNumericFormatter.FormatWithCulture("Ln",Convert.ToDouble(txtcz_jz.Text),null,new CultureInfo("zh-CHS"));


            //e.Graphics.DrawString(bigdata  , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 165, 265);

            //e.Graphics.DrawString("承运单位", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 370, 105);
            //e.Graphics.DrawString("毛重", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 330, 185);

            //e.Graphics.DrawString(txtcz_mz.Text , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 330, 225);

            //e.Graphics.DrawString("皮重", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 430, 185);

            //e.Graphics.DrawString(txtcz_pz.Text , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 430, 225);


            //e.Graphics.DrawString("车号", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 550, 105);

            //e.Graphics.DrawString(txtcz_ch.Text , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 550, 145);

            //e.Graphics.DrawString("司机", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 700, 105);

            //e.Graphics.DrawString(txtcz_jsy.Text , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 700, 145);
            #endregion

            #region 不带边框


            //e.Graphics.DrawString("//////////////////////////", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 160, 30);//划掉物资名称
            e.Graphics.DrawString(DateTime.Now.ToString("壹号煤场"), new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 300, 40);//标题
            e.Graphics.DrawString(DateTime.Now.ToString("yy    MM   dd"), new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 360, 55);//日期
            ////e.Graphics.DrawString("编号", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 600, 70);
            e.Graphics.DrawString(public_bdh, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 500, 60);//编号



            //第一列
            //e.Graphics.DrawString("供货单位", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 105);

            //e.Graphics.DrawString(txtcz_gwdw.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 100, 105);

            //e.Graphics.DrawString("收货单位", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 145);

            e.Graphics.DrawString(txtcz_gwdw.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 160, 85);//发货单位

            //e.Graphics.DrawString("/////////////", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 160, 140);//划掉收货单位
            //e.Graphics.DrawString("////////////", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 160, 170);//划掉物资名称

            e.Graphics.DrawString(txtru_shdw.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 160, 110);//收货单位

            //e.Graphics.DrawString("物资名称", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 185);

            //e.Graphics.DrawString(txtgn_name.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 100, 185);

            //e.Graphics.DrawString("发货数量", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 225);
            //e.Graphics.DrawString("实发数量", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 265);
            //e.Graphics.DrawString("过磅员", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 20, 305);

            //e.Graphics.DrawString("开票人", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 390, 305);
            e.Graphics.DrawString(fullsby , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 160, 220);//过磅员

            //第二列
            //e.Graphics.DrawString("规格", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 105, 225);
            //e.Graphics.DrawString("大写", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 105, 265);

            //string bigdata = InternationalNumericFormatter.FormatWithCulture("Ln", Convert.ToDouble(txtcz_jz.Text), null, new CultureInfo("zh-CHS"));


            //e.Graphics.DrawString(bigdata, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 165, 265);

            //e.Graphics.DrawString("承运单位", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 370, 105);
            //e.Graphics.DrawString("毛重", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 330, 185);

            e.Graphics.DrawString(txtgn_name.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 160, 140);//规格

            e.Graphics.DrawString(txtcz_mz.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 340, 170);//毛重

            //e.Graphics.DrawString("皮重", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 430, 185);

            e.Graphics.DrawString(fullpz, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black,440, 170);//皮重

            e.Graphics.DrawString(fulljz , new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 550, 170);//净重
            if (fulljz == "")
            {
                fulljz = "0.0";
            }
            e.Graphics.DrawString(bigwrite( fulljz), new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 230, 190);//大写
            //e.Graphics.DrawString(fulljz, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 580, 230);//小写
             
            //e.Graphics.DrawString("车号", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 550, 105);

            e.Graphics.DrawString(txtcz_ch.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 530, 110);//车号

            //e.Graphics.DrawString("司机", new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 700, 105);

            //e.Graphics.DrawString(txtcz_jsy.Text, new Font(new FontFamily("宋体"), 10), System.Drawing.Brushes.Black, 700, 145);
            #endregion
        }
    
        #endregion

        #region 语音播报

        private static readonly SpeechSynthesizer Talker = new SpeechSynthesizer();
       
        public void voice(string strspeech)
        {
            Talker.Rate = 2;
            Talker.Volume = 100;
            Talker.SelectVoiceByHints(VoiceGender.Male , VoiceAge.Child  , 1, System.Globalization.CultureInfo.CurrentCulture );
            Talker.SpeakAsync(strspeech);
        }


        #endregion



        #region 大屏显示

        private int hLed;
        private void led_send(string strled,int i)
        {
            hLed = DLL.StartSend();
            DLL.SetTransMode(hLed, 1, 0, 2, 1);
            DLL.SetNetworkPara(hLed, 1, ConnectionManger.led_IP);
            DLL.AddControl(hLed, 1, 1);
            DLL.AddProgram(hLed, 1, 0);
            if (i == 1)
            {
                DLL.AddLnTxtString(hLed, 1, 1, 0, 0, ConnectionManger.led_wight, ConnectionManger.led_height, strled, "宋体", 12, 255, false, false, false, 32, 80, 0);
            }
            else if(i==2)
            {
                DLL.AddQuitText(hLed, 1, 1, 0, 0, ConnectionManger.led_wight, ConnectionManger.led_height, 255, "宋体", 12, 0, 0, 0, strled);
            }
            DLL.SendControl(hLed, 1, IntPtr.Zero);  //发送
        }


        public void led_show()
        {
 
        }


        #endregion



        #region 称重仪表   
        private SerialPort yibiao_comm = new SerialPort();
        private StringBuilder yibiao_builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        private long yibiao_received_count = 0;//接收计数

        public void read_yibiao()
        {
            try
            {
                yibiao_comm.BaudRate =int.Parse( ConnectionManger.Yibiao_Baute);
                yibiao_comm.PortName = ConnectionManger.Yibiao_Com;
                if (!yibiao_comm.IsOpen)
                {
                    yibiao_comm.Open();
                }

            }
            catch (Exception ex)
            { }
        }



        /// <summary>
        /// 循环读取
        /// </summary>
        public void read_all()
        {
            while (1 == 1)
            {
                if (public_while == 0)
                {
                    try
                    {
                        if (public_exit == 0) yibiao_Receive();    //没仪表测试不用  仪表重量
                        Application.DoEvents();
                        Thread.Sleep(50);
                        if (public_exit == 0) statustime();//红外对射状态
                        Application.DoEvents();
                        Thread.Sleep(50);
                        if (public_exit == 0) comm_IcReceive();
                        Application.DoEvents();
                        Thread.Sleep(50);
                        if (public_exit == 0) status();
                        Application.DoEvents();
                        Thread.Sleep(50);
                    }
                    catch (Exception ex)
                    { }
                }
                else
                {
                    Thread.Sleep(100);
                    comm.DiscardInBuffer();
                    comm.DiscardOutBuffer();
                    Application.DoEvents();
                }
                if (public_exit == 1) break;
                //Thread.Sleep(100);
            }
        }

        private void statustimedelete()
        {
            while (true)
            {
                statustime();
                Thread.Sleep(50);
            }
        }

        //红外对射状态实时显示
        public string publicstatus = "";//公共状态
        public void statustime()
        {
            //if (picgreen1.InvokeRequired)
            //{
            //    processDelete pd = new processDelete(statustime);
            //    this.Invoke(pd);
            //}
            //else
            //{
                send_model("40 30 31 0d");
                string s = fullbyte[4].ToString("X");
                if (s == "31")
                {
                    picgreen1.Visible = false;
                    picgreen2.Visible = true;
                }
                if (s == "32")
                {
                    picgreen2.Visible = false;
                    picgreen1.Visible = true;
                }
                if (s == "33")
                {
                    picgreen2.Visible = false;
                    picgreen1.Visible = false;
                }
                if (s == "30")
                {
                    picgreen2.Visible = true;
                    picgreen1.Visible = true;
                }
                publicstatus = s;
            //}
        }

        private void yibiaodelete()
        {
            while (true)
            {
                yibiao_Receive();
                Thread.Sleep(50);
            }
        }

        public double OldWeight = 0;
        public void yibiao_Receive()
        {
            //if (lbl_weight.InvokeRequired)
            //{
            //    processDelete pd = new processDelete(yibiao_Receive);
            //    this.Invoke(pd);
            //}
            //else
            //{

                yibiao_comm.DiscardInBuffer();
                yibiao_comm.DiscardOutBuffer();    //清除
                while (yibiao_comm.BytesToRead < 24)
                {
                    Application.DoEvents();
                    Thread.Sleep(1);
                }

                int ybweight;

                int n = 24;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
                byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据

                yibiao_comm.Read(buf, 0, n);//读取缓冲数据

                try
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (buf[i].ToString("X2") == "02")
                            {
                                if (buf[i + 11] == 3)
                                {
                                    ybweight = (buf[i + 2] - 48) * 100000 + (buf[i + 3] - 48) * 10000 + (buf[i + 4] - 48) * 1000 + (buf[i + 5] - 48) * 100;
                                    lbl_weight.Text = (ybweight / Math.Pow(10, buf[i + 8] - 48)).ToString("0.0");
                                    i = n;

                                    if ((DateTime.Now - public_time).Seconds + (DateTime.Now - public_time).Minutes * 60 + (DateTime.Now - public_time).Hours * 3600 + (DateTime.Now - public_time).Days * 24 * 3600 > 6)
                                    {
                                        if (OldWeight != Convert.ToDouble(lbl_weight.Text))
                                        {
                                            led_send(lbl_weight.Text, 2);
                                            public_time = DateTime.Now;
                                            OldWeight = Convert.ToDouble(lbl_weight.Text);
                                        }
                                    }
                                }
                            }
                        }

                    }));
                }
                catch (Exception ex)
                { }
            //}
        }

        #endregion                                                    
       
            

        #region 通过串口读取卡号

        private SerialPort comm = new SerialPort();
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        private long received_count = 0;//接收计数

        /// <summary>
        /// 通过串口读取卡号
        /// </summary>
        public void readcode()
        {
            try
            {
                comm.BaudRate = 57600;
                comm.PortName = ConnectionManger.Card_Com;
                if (!comm.IsOpen)
                {
                    comm.Open();
                }
               
            }
            catch (Exception ex)
            { }
        }
        Operation.Select select = new Operation.Select();
        private string htcode = "";
        private string cm_runsign = "";  //通过标志

        private string[] flowtxt =null  ; //存放流程信息
        private string fullsby = "";  //司磅员
        private string fullpz = "";  //皮重
        private string fulljz = "0";  //净重   这三个是用于打印

        private int ilook = 0;  //
        public DateTime public_time = DateTime.Now;


        public string[] flowname = null; //记录流程
        DateTime sktime1 = DateTime.Now;  //

        private void comm_IcReceive_Delete()
        {
            while (true)
            {
                comm_IcReceive();
                Thread.Sleep(100);
            }
        }

    

        private void comm_IcReceive()
        {

            if (comm.BytesToRead < 8)
            {
                return;
            }

          
            //DateTime sktime2 = DateTime.Now;
            //int int_sktime1=sktime1.Hour*60*60+sktime1.Minute*60+sktime1.Second;
            //int int_sktime2=sktime2.Hour*60*60+sktime2.Minute*60+sktime2.Second;

            //if (int_sktime1 - int_sktime2 > 10)
            //{
               
            //    return;
            //}

            int izd = 0;
            while (publicstatus != "30")
            {
                statustime();
                izd++;
                if (izd > 2) break;
            }

            if (publicstatus != "30")
            {
                voice("红外对射器被遮挡");
                comm.DiscardInBuffer();
                comm.DiscardOutBuffer();
                return;
            }

            int n = 16;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据
            received_count += n;//增加接收计数
            comm.Read(buf, 0, n);//读取缓冲数据
            builder.Clear();//清除字符串构造器的内容
            try
            {

                int itcout = 0;//标记车辆表里是否有此卡信息 1为有0为没有
                this.Invoke((EventHandler)(delegate
                {



                    Thread.Sleep(1);

                    for (int i = 0; i < n; i++)
                    {
                        if (i < n - 5)
                        {
                            if (buf[i].ToString("X2") == "07" && buf[i + 1].ToString("X2") == "00" && buf[i + 2].ToString("X2") == "EE" && buf[i + 3].ToString("X2") == "00")
                            {


                                txtcz_kh.Text = buf[i + 4].ToString("X2") + buf[i + 5].ToString("X2");
                                DataTable dt = select.bind_CarManage(txtcz_kh.Text);
                                if (dt.Rows.Count > 0)
                                {
                                    itcout = 1;

                                    DataTable dtflow = select.bind_FlowSet_fs_area_fs_pname(dt.Rows[0]["cn_hwmc"].ToString());
                                    if (dtflow.Rows.Count > 0)
                                    {
                                        //flowname = dtflow.Rows[0].ToString().Split('-');
                                        flowname = dtflow.Rows[0]["fs_flowset"].ToString().Split('-');
                                        //flowname = new string[fs_flowset.Length ];
                                    }

                                    string bdh_pic = "";
                                    


                                    double dmz, dpz;
                                    if (string.IsNullOrEmpty(txtcz_mz.Text))
                                    {
                                        dmz = 0.0;
                                    }
                                    else
                                    {
                                        dmz = Convert.ToDouble(txtcz_mz.Text);
                                    }

                                    if (string.IsNullOrEmpty(txtcz_pz.Text))
                                    {
                                        dpz = 0.0;
                                    }
                                    else
                                    {
                                        dpz = Convert.ToDouble(txtcz_pz.Text);
                                    }
                                    txtcz_jz.Text = Math.Abs(dmz - dpz).ToString("0.0");




                                    #region 判断进磅模式
                                    //适合用在五家沟的进磅
                                    if (ConnectionManger.Flow == "进磅")
                                    {
                                        DataTable dtsj = select.bind_CZJL_bdh_time(txtcz_kh.Text);
                                        if (dtsj.Rows.Count > 0)
                                        {

                                            voice("你已进磅不能重复刷卡！");
                                            //timer3.Enabled = true;
                                            return;


                                        }
                                        else
                                        {
                                            txtcz_pz.Text = lbl_weight.Text;

                                        }
                                        voice("刷卡成功！");

                                        txtcz_ch.Text = dt.Rows[0]["cm_carnumber"].ToString();
                                        txtcz_jsy.Text = dt.Rows[0]["cm_jsy"].ToString();
                                        txtgn_name.Text = dt.Rows[0]["cn_hwmc"].ToString();
                                        txtcz_gwdw.Text = dt.Rows[0]["su_unit"].ToString();
                                        txtru_shdw.Text = dt.Rows[0]["ru_unit"].ToString();
                                        htcode = dt.Rows[0]["cn_code"].ToString();
                                        cm_runsign = dt.Rows[0]["cm_runsign"].ToString();


                                        #region 根据数据库中数据计算磅单
                                        string daystring = DateTime.Now.ToString(ConnectionManger.BandDan);

                                        string bdh = "";
                                        DataTable dtbdh = select.bind_bdh(daystring);
                                        if (dtbdh.Rows.Count > 0)
                                        {
                                            int xuhao = int.Parse(dtbdh.Rows[0]["bdh"].ToString());
                                            bdh = daystring + (xuhao + 1).ToString("0000");
                                        }
                                        else
                                        {
                                            bdh = daystring + "0001";
                                        }


                                        bdh_pic = bdh;

                                        //public_bdh = bdh; //给磅单号赋值

                                        #endregion


                                        string strmz = "";
                                        string strpz = "";
                                        string strjz = "";
                                        if (string.IsNullOrEmpty(txtcz_mz.Text))
                                        {
                                            strmz = "NULL";
                                        }
                                        else
                                        {
                                            strmz = txtcz_mz.Text;
                                        }
                                        if (string.IsNullOrEmpty(txtcz_pz.Text))
                                        {
                                            strpz = "NULL";
                                        }
                                        else
                                        {
                                            strpz = txtcz_pz.Text;
                                        }

                                        strjz = "NULL";

                                      
                                       publi_led = "重量为：" + txtcz_pz.Text + "吨";
                                   

                                        insert.insert_Flow(bdh, "进磅(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")", "进磅", txtcz_kh.Text);
                                        insert.insert_CZJL(ConnectionManger.szqy, bdh, txtcz_ch.Text, txtcz_kh.Text, txtcz_jsy.Text, txtgn_name.Text, strmz, strpz, strjz, "", "", htcode, txtcz_sby.Text, "", "", DateTime.Now.ToString(), "", "", ConnectionManger.Card_Address, "未完成", txtcz_gwdw.Text, txtru_shdw.Text);




                                        //insert.insert_Photo(bdh, byteimg1);
                                        //insert.insert_Photo(bdh, byteimg2);
                                        //insert.insert_Photo(bdh, byteimg3);
                                        //insert.insert_Photo(bdh, byteimg4);

                                        #region  进磅抬杆


                                        strback = "";
                                        send_model(ConnectionManger.Model_Com_Send_Txt);
                                        int icounts = 0;
                                        while (!strback.Equals("3E0D"))
                                        {
                                            icounts++;
                                            Thread.Sleep(500);
                                            strback = "";
                                            send_model(ConnectionManger.Model_Com_Send_Txt);

                                            if (icounts > 6) break;
                                        }

                                        piclg1.Visible = false;
                                        itimebz = 2;

                                        #endregion



                                        #region 存储图片
                                        insert.insert_PhotoPath(bdh, "pic/" +  bdh + "_1.bmp");
                                        insert.insert_PhotoPath(bdh, "pic/" +  bdh + "_2.bmp");
                                        insert.insert_PhotoPath(bdh, "pic/" +  bdh + "_3.bmp");
                                        insert.insert_PhotoPath(bdh, "pic/" +  bdh + "_4.bmp");






                                        CHCNetSDK.NET_DVR_CapturePicture(playHandle1, ConnectionManger.LoadPath + bdh + "_1.bmp");


                                        CHCNetSDK.NET_DVR_CapturePicture(playHandle2, ConnectionManger.LoadPath + bdh + "_2.bmp");


                                        CHCNetSDK.NET_DVR_CapturePicture(playHandle3, ConnectionManger.LoadPath + bdh + "_3.bmp");


                                        CHCNetSDK.NET_DVR_CapturePicture(playHandle4, ConnectionManger.LoadPath + bdh + "_4.bmp");


                                        //Thread.Sleep(200);

                                        //byte[] byteimg1 = GetPictureData("BMP_test1.bmp");      //把图片转换成二进制文件
                                        //byte[] byteimg2 = GetPictureData("BMP_test2.bmp");
                                        //byte[] byteimg3 = GetPictureData("BMP_test3.bmp");
                                        //byte[] byteimg4 = GetPictureData("BMP_test4.bmp");

                                        #endregion

                                   

                                    


                                        voice("重量" + txtcz_pz.Text + "吨,请下磅");
                                        led_send("重量为：" + txtcz_pz.Text + "吨", 2);

                                        Thread.Sleep(1000);
                                        send_model("40 30 31 30 30 0d");

                                    }

                                    #endregion

                                    #region 判断出磅模式
                                    if (ConnectionManger.Flow == "出磅")
                                    {
                                        voice("刷卡成功！");


                                        //刷卡之后等3秒钟，等待数据稳定
                                        DateTime wait1 = DateTime.Now;
                                        DateTime wait2 = DateTime.Now;

                                        int int_wait1 = wait1.Hour * 60 * 60 + wait1.Minute * 60 + wait1.Second;
                                        int int_wait2 = wait2.Hour * 60 * 60 + wait2.Minute * 60 + wait2.Second;
                                        int int_count = 0;
                                        while (int_wait2 - int_wait1 < 2)
                                        {
                                            wait2 = DateTime.Now;
                                            int_wait2 = wait2.Hour * 60 * 60 + wait2.Minute * 60 + wait2.Second;
                                            yibiao_Receive();
                                            txtcz_mz.Text = lbl_weight.Text;
                                            Thread.Sleep(10);
                                        }


                                        //根据卡号查询是否超出载重
                                        SqlDataReader drbzweight = select.read_CarManage_cm_bzweight(txtcz_kh.Text);
                                        if (drbzweight.Read())
                                        {
                                            double d1 = Convert.ToDouble(drbzweight["cm_bzweight"].ToString());
                                            double d2 = Convert.ToDouble(txtcz_mz.Text);
                                            if (d2 > d1)
                                            {
                                                voice("此车已超出载重！");

                                                drbzweight.Close();
                                                //timer3.Enabled = true;
                                                return;
                                            }
                                        }
                                        drbzweight.Close();


                                        DataTable dtpmlc = select.read_Flow_CZJL_lc_nyp(txtcz_kh.Text); //查看流程是否对应，
                                        if (dtpmlc.Rows.Count > 0)
                                        {


                                            string lcjl = dtpmlc.Rows[0]["fw_flow"].ToString();
                                            string[] strcb = lcjl.Split('-');
                                            if (strcb.Length > 0)
                                            {
                                                if (strcb[0] != flowname[0])
                                                {

                                                    voice("流程错误！");

                                                    txtcz_kh.Text = "";
                                                    //timer3.Enabled = true;
                                                    return;
                                                }
                                            }

                                            //if (strcb[strcb.Length - 1] != flowname[strcb.Length - 1])
                                            //{
                                            //    voice("流程错误！");
                                            //    txtcz_kh.Text = "";
                                            //    return;
                                            //}

                                            //if (strcb[strcb.Length - 1] == "出磅")
                                            //{
                                            //    voice("你已出磅，不能重复刷卡");
                                            //    txtcz_kh.Text = "";
                                            //    return;
                                            //}

                                        }
                                        else
                                        {
                                            voice("流程错误！");

                                            txtcz_kh.Text = "";
                                            //timer3.Enabled = true;
                                            return;
                                        }


                                      


                                        DataTable dtsk = select.bind_CZJL_cz_kh(txtcz_kh.Text);
                                        //当已存在时说明已刷卡
                                        if (dtsk.Rows.Count > 0)
                                        {
                                            //txtcz_mz.Text = lbl_weight.Text;
                                            string cbbd2 = "";
                                            DataTable dtcbbd2 = select.bind_bdh_Flow(txtcz_kh.Text);
                                            if (dtcbbd2.Rows.Count > 0)
                                            {
                                                cbbd2 = dtcbbd2.Rows[0]["cz_dh"].ToString();
                                                public_bdh = cbbd2;
                                            }


                                            string nowbdh = ""; //通过存储过程返回磅单号
                                            int returncs = 0;
                                            string returnsby = "";
                                            float returnpz = 0.0f;
                                            float returnjz = 0.0f;
                                            update.update_proc_update_CZJL(txtcz_kh.Text, txtcz_mz.Text, ref nowbdh, ref returncs, "完成", txtcz_sby.Text, ref returnsby, ref returnpz, ref returnjz, ConnectionManger.Card_Address);


                                            if (returncs == 1)
                                            {
                                                voice("已超出合同总量！");
                                                txtcz_kh.Text = "";
                                                txtcz_ch.Text = "";
                                                txtcz_jsy.Text = "";
                                                txtgn_name.Text = "";
                                                txtcz_gwdw.Text = "";
                                                txtru_shdw.Text = "";
                                                txtcz_mz.Text = "";
                                                txtcz_pz.Text = "";
                                                txtcz_jz.Text = "";
                                                //timer3.Enabled = true;
                                                timer1.Enabled = false;

                                                return;
                                            }
                                            update.update_Flow_bdh(cbbd2, "-出磅", "完成");
                                            update.update_CZJL_cz_wcbj(cbbd2);
                                            update.update_CarManage_cm_complete(txtcz_kh.Text);
                                            delete.delete_CarManage(txtcz_kh.Text);

                                            #region 存储图片
                                            insert.insert_PhotoPath(cbbd2, "pic/"  + cbbd2 + "_5.bmp");
                                            insert.insert_PhotoPath(cbbd2, "pic/"  + cbbd2 + "_6.bmp");
                                            insert.insert_PhotoPath(cbbd2, "pic/"  + cbbd2 + "_7.bmp");
                                            insert.insert_PhotoPath(cbbd2, "pic/" + cbbd2 + "_8.bmp");







                                            CHCNetSDK.NET_DVR_CapturePicture(playHandle1, ConnectionManger.LoadPath + cbbd2 + "_5.bmp");


                                            CHCNetSDK.NET_DVR_CapturePicture(playHandle2, ConnectionManger.LoadPath + cbbd2 + "_6.bmp");


                                            CHCNetSDK.NET_DVR_CapturePicture(playHandle3, ConnectionManger.LoadPath + cbbd2 + "_7.bmp");


                                            CHCNetSDK.NET_DVR_CapturePicture(playHandle4, ConnectionManger.LoadPath + cbbd2 + "_8.bmp");


                                            //Thread.Sleep(200);

                                            //byte[] byteimg1 = GetPictureData("BMP_test1.bmp");      //把图片转换成二进制文件
                                            //byte[] byteimg2 = GetPictureData("BMP_test2.bmp");
                                            //byte[] byteimg3 = GetPictureData("BMP_test3.bmp");
                                            //byte[] byteimg4 = GetPictureData("BMP_test4.bmp");

                                            #endregion

                                            //insert.insert_Photo(cbbd2, byteimg1);
                                            //insert.insert_Photo(cbbd2, byteimg2);
                                            //insert.insert_Photo(cbbd2, byteimg3);
                                            //insert.insert_Photo(cbbd2, byteimg4);

                                            bdh_pic = cbbd2;

                                            #region 出磅时抬杆
                                            //出磅时抬杆


                                            strback = "";

                                            send_model(ConnectionManger.Model_Com_Send_Txt);  //出场抬杆
                                            int icounts = 0;

                                            while (!strback.Equals("3E0D"))
                                            {
                                                icounts++;
                                                Thread.Sleep(100);
                                                strback = "";
                                                send_model(ConnectionManger.Model_Com_Send_Txt);  //出场抬杆
                                                if (icounts > 3) break;
                                            }

                                            itimebz = 3;
                                            piclg2.Visible = false;


                                            txtcz_ch.Text = dt.Rows[0]["cm_carnumber"].ToString();
                                            txtcz_jsy.Text = dt.Rows[0]["cm_jsy"].ToString();
                                            txtgn_name.Text = dt.Rows[0]["cn_hwmc"].ToString();
                                            txtcz_gwdw.Text = dt.Rows[0]["su_unit"].ToString();
                                            txtru_shdw.Text = dt.Rows[0]["ru_unit"].ToString();
                                            htcode = dt.Rows[0]["cn_code"].ToString();
                                            cm_runsign = dt.Rows[0]["cm_runsign"].ToString();

                                            Thread.Sleep(1000);
                                            send_model("40 30 31 30 30 0d");

                                            #endregion


                                            txtcz_pz.Text = returnpz.ToString();
                                            txtcz_jz.Text = returnjz.ToString();
                                            fullsby = returnsby;
                                            fullpz = returnpz.ToString();
                                            fulljz = returnjz.ToString();
                                            led_send("重量" + txtcz_mz.Text + "吨，净重" + fulljz + "吨", 2);
                                            voice("当前重量为：" + txtcz_mz.Text + "吨,净重为：" + fulljz + "吨！请下磅");
                                            //for (int t = 0; t < public_name.Length; t++)
                                            //{
                                            //    if (txtgn_name.Text == public_name[t])
                                            //    { }
                                            //}
                                            //print();


                                            int p_y_n = 1;
                                            for (int t1 = 0; t1 < public_name.Length; t1++)
                                            {
                                                if (txtgn_name.Text  == public_name[t1])
                                                {
                                                    p_y_n = 0;
                                                }
                                            }
                                            if (p_y_n == 1)
                                            {
                                                print();
                                            }
                                        }


                                    }
                                    #endregion

                                    //#region 判断预称重
                                    //if (ConnectionManger.Flow == "预称重")
                                    //{
                                    //    string yczbd = "";
                                    //    DataTable dtycz = select.bind_bdh_Flow(txtcz_kh.Text);
                                    //    if (dtycz.Rows.Count > 0)
                                    //    {
                                    //        yczbd = dtycz.Rows[0]["fw_bdh"].ToString();
                                    //    }

                                    //    update.update_CZJL_cz_dh(yczbd, lbl_weight.Text);//更新预称重信息

                                    //    DataTable dtbdflow = select.bind_lc_flow(yczbd);
                                    //    if (dtbdflow.Rows.Count > 0)
                                    //    {
                                    //        string[] s = dtbdflow.Rows[0]["fw_flow"].ToString().Split('-');
                                    //        if (s[s.Length - 1] == "预称重")
                                    //        {

                                    //            //已经进入预称重之内

                                    //            update.update_CZJL_id_YC(txtcz_kh.Text, lbl_weight.Text);


                                    //            #region 出预称重时抬杆
                                    //            //出磅时抬杆


                                    //            strback = "";

                                    //            send_model(ConnectionManger.Model_Com_Send_Txt_2);  //出场抬杆
                                    //            int icounts = 0;

                                    //            while (!strback.Equals("3E0D"))
                                    //            {
                                    //                icounts++;
                                    //                Thread.Sleep(100);
                                    //                strback = "";
                                    //                send_model(ConnectionManger.Model_Com_Send_Txt_2);  //出场抬杆
                                    //                if (icounts > 3) break;
                                    //            }

                                    //            itimebz = 3;
                                    //            piclg2.Visible = false;


                                    //            Thread.Sleep(1000);
                                    //            send_model("40 30 31 30 30 0d");

                                    //            #endregion
                                    //        }
                                    //        else
                                    //        {

                                    //            //未进入预称重之内

                                    //            #region 进预称重时抬杆
                                    //            //出磅时抬杆


                                    //            strback = "";

                                    //            send_model(ConnectionManger.Model_Com_Send_Txt);  //抬杆
                                    //            int icounts = 0;

                                    //            while (!strback.Equals("3E0D"))
                                    //            {
                                    //                icounts++;
                                    //                Thread.Sleep(100);
                                    //                strback = "";
                                    //                send_model(ConnectionManger.Model_Com_Send_Txt);  //抬杆
                                    //                if (icounts > 3) break;
                                    //            }

                                    //            itimebz = 3;
                                    //            piclg2.Visible = false;


                                    //            Thread.Sleep(1000);
                                    //            send_model("40 30 31 30 30 0d");

                                    //            #endregion

                                    //            update.update_Flow_bdh(yczbd, "-预称重", "未完成");

                                    //        }
                                    //    }
                                    //    //voice("预称重量为：" + lbl_weight.Text + ",请下磅");
                                    //}
                                    //#endregion


                                    //#region  元宝湾
                                    //if (ConnectionManger.Flow == "元宝湾")
                                    //{
                                    //    //根据卡号查询是否超出载重
                                    //    SqlDataReader drbzweight = select.read_CarManage_cm_bzweight(txtcz_kh.Text);
                                    //    if (drbzweight.Read())
                                    //    {
                                    //        double d1 = Convert.ToDouble(drbzweight["cm_bzweight"].ToString());
                                    //        double d2 = Convert.ToDouble(lbl_weight.Text);
                                    //        if (d2 > d1)
                                    //        {
                                    //            voice("此车已超出载重！");

                                    //            drbzweight.Close();
                                    //            //timer3.Enabled = true;
                                    //            return;
                                    //        }
                                    //    }
                                    //    drbzweight.Close();




                                    //    DataTable dtsj = select.bind_CZJL_bdh_time(txtcz_kh.Text);
                                    //    if (dtsj.Rows.Count > 0)
                                    //    {
                                    //        DateTime time1 = Convert.ToDateTime(dtsj.Rows[0]["cz_inserttime"].ToString());
                                    //        DateTime time2 = DateTime.Now;
                                    //        int d = (time2 - time1).Seconds + (time2 - time1).Minutes * 60 + (time2 - time1).Hours * 60 * 60;
                                    //        if (d < 60)
                                    //        {
                                    //            voice("不能重复刷卡！");
                                    //            //timer3.Enabled = true;
                                    //            return;
                                    //        }
                                    //        txtcz_mz.Text = lbl_weight.Text;

                                    //    }
                                    //    else
                                    //    {
                                    //        txtcz_pz.Text = lbl_weight.Text;

                                    //    }




                                    //    DataTable dtsk = select.bind_CZJL_cz_kh(txtcz_kh.Text);
                                    //    //当已存在时说明已刷卡
                                    //    if (dtsk.Rows.Count > 0)
                                    //    {
                                    //        txtcz_mz.Text = lbl_weight.Text;
                                    //        string cbbd2 = "";
                                    //        DataTable dtcbbd2 = select.bind_bdh_Flow(txtcz_kh.Text);
                                    //        if (dtcbbd2.Rows.Count > 0)
                                    //        {
                                    //            cbbd2 = dtcbbd2.Rows[0]["fw_bdh"].ToString();
                                    //            public_bdh = cbbd2;
                                    //        }


                                    //        string nowbdh = ""; //通过存储过程返回磅单号
                                    //        int returncs = 0;
                                    //        string returnsby = "";
                                    //        float returnpz = 0.0f;
                                    //        float returnjz = 0.0f;
                                    //        update.update_proc_update_CZJL(txtcz_kh.Text, txtcz_mz.Text, ref nowbdh, ref returncs, "完成", txtcz_sby.Text, ref returnsby, ref returnpz, ref returnjz, ConnectionManger.Card_Address);

                                    //        //led_send("当前重量为：" + txtcz_mz.Text + "吨", 2);
                                    //        //publi_led="重量为：" + txtcz_mz.Text + "吨,净重为：" + fulljz + ";
                                    //        if (returncs == 1)
                                    //        {
                                    //            voice("已超出合同总量！");
                                    //            txtcz_kh.Text = "";
                                    //            txtcz_ch.Text = "";
                                    //            txtcz_jsy.Text = "";
                                    //            txtgn_name.Text = "";
                                    //            txtcz_gwdw.Text = "";
                                    //            txtru_shdw.Text = "";
                                    //            txtcz_mz.Text = "";
                                    //            txtcz_pz.Text = "";
                                    //            txtcz_jz.Text = "";
                                    //            //timer3.Enabled = true;
                                    //            timer1.Enabled = false;

                                    //            return;
                                    //        }

                                    //        txtcz_pz.Text = returnpz.ToString();
                                    //        txtcz_jz.Text = returnjz.ToString();
                                    //        fullsby = returnsby;
                                    //        fullpz = returnpz.ToString();
                                    //        fulljz = returnjz.ToString();
                                    //        led_send("重量" + txtcz_mz.Text + "吨，净重" + fulljz + "吨", 2);
                                    //        voice("当前重量为：" + txtcz_mz.Text + "吨,净重为：" + fulljz + "吨！请下磅");

                                    //    }


                                    //    //DataTable dtsk = select.bind_CZJL_cz_kh(txtcz_kh.Text);
                                    //    //当已存在时说明已刷卡
                                    //    if (dtsk.Rows.Count > 0)
                                    //    {
                                    //        txtcz_mz.Text = lbl_weight.Text;
                                    //        string cbbd2 = "";
                                    //        DataTable dtcbbd2 = select.bind_bdh_Flow(txtcz_kh.Text);
                                    //        if (dtcbbd2.Rows.Count > 0)
                                    //        {
                                    //            cbbd2 = dtcbbd2.Rows[0]["fw_bdh"].ToString();
                                    //            public_bdh = cbbd2;
                                    //        }


                                    //        update.update_Flow_bdh(cbbd2, "-出磅", "完成");

                                    //        //insert.insert_Photo(cbbd2, byteimg1);
                                    //        //insert.insert_Photo(cbbd2, byteimg2);
                                    //        //insert.insert_Photo(cbbd2, byteimg3);
                                    //        //insert.insert_Photo(cbbd2, byteimg4);
                                    //        //}






                                    //    }
                                    //    else
                                    //    {

                                    //        txtcz_pz.Text = lbl_weight.Text;
                                    //        string jbbd1 = "";
                                    //        DataTable dtjbbd1 = select.bind_bdh_Flow(txtcz_kh.Text);
                                    //        if (dtjbbd1.Rows.Count > 0)
                                    //        {
                                    //            jbbd1 = dtjbbd1.Rows[0]["fw_bdh"].ToString();
                                    //            public_bdh = jbbd1;
                                    //        }

                                    //        string strmz = "";
                                    //        string strpz = "";
                                    //        string strjz = "";
                                    //        if (string.IsNullOrEmpty(txtcz_mz.Text))
                                    //        {
                                    //            strmz = "NULL";
                                    //        }
                                    //        else
                                    //        {
                                    //            strmz = txtcz_mz.Text;
                                    //        }
                                    //        if (string.IsNullOrEmpty(txtcz_pz.Text))
                                    //        {
                                    //            strpz = "NULL";
                                    //        }
                                    //        else
                                    //        {
                                    //            strpz = txtcz_pz.Text;
                                    //        }

                                    //        strjz = "NULL";



                                    //        publi_led = "重量为：" + txtcz_pz.Text + "吨";

                                    //        voice("重量为：" + txtcz_pz.Text + "吨,请下磅");
                                    //        led_send("重量为：" + txtcz_pz.Text + "吨", 2);


                                    //        insert.insert_CZJL(ConnectionManger.szqy, jbbd1, txtcz_ch.Text, txtcz_kh.Text, txtcz_jsy.Text, txtgn_name.Text, strmz, strpz, strjz, "", "", htcode, txtcz_sby.Text, "", "", DateTime.Now.ToString(), "", "", ConnectionManger.Card_Address, "未完成", txtcz_gwdw.Text, txtru_shdw.Text);


                                    //        update.update_Flow_bdh(jbbd1, "-进磅", "未完成");

                                    //        //insert.insert_Photo(jbbd1, byteimg1);
                                    //        //insert.insert_Photo(jbbd1, byteimg2);
                                    //        //insert.insert_Photo(jbbd1, byteimg3);
                                    //        //insert.insert_Photo(jbbd1, byteimg4);


                                    //    }





                                    //}

                                    //#endregion





                                    public_time = DateTime.Now;
                                    bind_data();

                                    //DateTime show_time1 = DateTime.Now;
                                    //DateTime show_time2 = DateTime.Now;
                                    //while(show_time2.Second-show_time1.Second<5)
                                    //{
                                    //    show_time2 = DateTime.Now;
                                    //    Thread.Sleep(10);
                                    //}
                                    //txtcz_kh.Text = "";
                                    //txtcz_ch.Text = "";
                                    //txtcz_jsy.Text = "";
                                    //txtgn_name.Text = "";
                                    //txtcz_gwdw.Text = "";
                                    //txtru_shdw.Text = "";
                                    //txtcz_mz.Text = "";
                                    //txtcz_pz.Text = "";
                                    //txtcz_jz.Text = "";

                                    if (timer1.Enabled == false)
                                    {
                                        timer1.Enabled = true;

                                    }







                                }//判断是否为车辆管理表中的数据结尾

                            }//判断是否为对应的数据结尾

                        }
                        i = n;
                    }

                }));

                if (itcout == 0)
                {
                    voice("此卡信息没有录入系统！");

                }
                sktime1 = DateTime.Now;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

        }



       private string public_bdh = ConnectionManger.BandDan;

    
        private void timer1_Tick(object sender, EventArgs e)
        {





         

            if (cm_runsign == "全部通过")
            {
                send_model(ConnectionManger.Model_Com_Send_Txt);
              
                while (strback.Equals(ConnectionManger.Model_Com_Send_Txt))
                {


                    send_model(ConnectionManger.Model_Com_Send_Txt);
                    Thread.Sleep(400);
                }
            }
            else
            {



                //#region 生成图片并转换成二进制


              

                //CHCNetSDK.NET_DVR_CapturePicture(playHandle1, "BMP_test1.bmp");

                //CHCNetSDK.NET_DVR_CapturePicture(playHandle2, "BMP_test2.bmp");
                //CHCNetSDK.NET_DVR_CapturePicture(playHandle3, "BMP_test3.bmp");

                //CHCNetSDK.NET_DVR_CapturePicture(playHandle4, "BMP_test4.bmp");

                //Thread.Sleep(200);

                //byte[] byteimg1 = GetPictureData("BMP_test1.bmp");      //把图片转换成二进制文件
                //byte[] byteimg2 = GetPictureData("BMP_test2.bmp");
                //byte[] byteimg3 = GetPictureData("BMP_test3.bmp");
                //byte[] byteimg4 = GetPictureData("BMP_test4.bmp");

                //#endregion

                //double dmz, dpz;
                //if (string.IsNullOrEmpty(txtcz_mz.Text))
                //{
                //    dmz = 0.0;
                //}
                //else
                //{
                //    dmz = Convert.ToDouble(txtcz_mz.Text);
                //}

                //if (string.IsNullOrEmpty(txtcz_pz.Text))
                //{
                //    dpz = 0.0;
                //}
                //else
                //{
                //    dpz = Convert.ToDouble(txtcz_pz.Text);
                //}
                //txtcz_jz.Text = Math.Abs(dmz - dpz).ToString("0.0");


                string strvoice = "";//定义大屏显示的字符串，好像没用，哈哈......



                #region 进磅
                if (ConnectionManger.Flow == "进磅")
                {
                    //#region 根据数据库中数据计算磅单
                    //string daystring = DateTime.Now.ToString(ConnectionManger.BandDan );

                    //string bdh = "";
                    //DataTable dtbdh = select.bind_bdh(daystring);
                    //if (dtbdh.Rows.Count > 0)
                    //{
                    //    int xuhao = int.Parse(dtbdh.Rows[0]["bdh"].ToString());
                    //    bdh = daystring + (xuhao + 1).ToString("0000");
                    //}
                    //else
                    //{
                    //    bdh = daystring + "0001";
                    //}


                    ////public_bdh = bdh; //给磅单号赋值

                    //#endregion

               
                    //string strmz = "";
                    //string strpz = "";
                    //string strjz = "";
                    //if (string.IsNullOrEmpty(txtcz_mz.Text))
                    //{
                    //    strmz = "NULL";
                    //}
                    //else
                    //{
                    //    strmz = txtcz_mz.Text;
                    //}
                    //if (string.IsNullOrEmpty(txtcz_pz.Text))
                    //{
                    //    strpz = "NULL";
                    //}
                    //else
                    //{
                    //    strpz = txtcz_pz.Text;
                    //}

                    //strjz = "NULL";

                    //#region  进磅抬杆

                    
                    //strback = "";
                    //send_model(ConnectionManger.Model_Com_Send_Txt);
                    //int icounts = 0;
                    //while (!strback.Equals("3E0D"))
                    //{
                    //    icounts++;
                    //    Thread.Sleep(400);
                    //    strback = "";
                    //    send_model(ConnectionManger.Model_Com_Send_Txt);

                    //    if (icounts > 4) break;
                    //}

                    //piclg1.Visible = false;
                    //itimebz = 2;

                    //#endregion

                    //Thread.Sleep(1000);
                    //send_model("40 30 31 30 30 0d");



                    //publi_led = "重量为：" + txtcz_pz.Text + "吨";

                    //voice("重量为：" + txtcz_pz.Text + "吨,请下磅");
                    //led_send("重量为：" + txtcz_pz.Text + "吨", 2);

                    //insert.insert_Flow(bdh, "进磅(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")", "进磅", txtcz_kh.Text);
                    //insert.insert_CZJL(ConnectionManger.szqy, bdh, txtcz_ch.Text, txtcz_kh.Text, txtcz_jsy.Text, txtgn_name.Text, strmz, strpz, strjz, "", "", htcode, txtcz_sby.Text, "", "", DateTime.Now.ToString(), "", "", ConnectionManger.Card_Address, "未完成", txtcz_gwdw.Text, txtru_shdw.Text);




                    //insert.insert_Photo(bdh, byteimg1);
                    //insert.insert_Photo(bdh, byteimg2);
                    //insert.insert_Photo(bdh, byteimg3);
                    //insert.insert_Photo(bdh, byteimg4);

                }
                #endregion


                #region 出磅
                if (ConnectionManger.Flow == "出磅")
                {

                }
                #endregion 
                #region 皮毛同称
                if (ConnectionManger.Flow == "皮毛同称")
                {
                    //DataTable dtsk = select.bind_CZJL_cz_kh(txtcz_kh.Text);
                    ////当已存在时说明已刷卡
                    //if (dtsk.Rows.Count > 0)
                    //{
                    //    txtcz_mz.Text = lbl_weight.Text;
                    //    string cbbd2 = "";
                    //    DataTable dtcbbd2 = select.bind_bdh_Flow(txtcz_kh.Text);
                    //    if (dtcbbd2.Rows.Count > 0)
                    //    {
                    //        cbbd2 = dtcbbd2.Rows[0]["fw_bdh"].ToString();
                    //        public_bdh = cbbd2;
                    //    }


                    //    update.update_Flow_bdh(cbbd2, "-出磅", "未完成");

                    //    insert.insert_Photo(cbbd2, byteimg1);
                    //    insert.insert_Photo(cbbd2, byteimg2);
                    //    insert.insert_Photo(cbbd2, byteimg3);
                    //    insert.insert_Photo(cbbd2, byteimg4);
                    //    //}


                    //    for (int i = 0; i < public_name.Length; i++)
                    //    {
                    //        if (public_name[i] == txtgn_name.Text)
                    //        {
                    //            print(); //不用时注释掉
                    //            break;
                    //        }

                    //    }




                    //}
                    //else
                    //{

                    //    txtcz_pz.Text = lbl_weight.Text;
                    //    string jbbd1 = "";
                    //    DataTable dtjbbd1 = select.bind_bdh_Flow(txtcz_kh.Text);
                    //    if (dtjbbd1.Rows.Count > 0)
                    //    {
                    //        jbbd1 = dtjbbd1.Rows[0]["fw_bdh"].ToString();
                    //        public_bdh = jbbd1;
                    //    }

                    //    string strmz = "";
                    //    string strpz = "";
                    //    string strjz = "";
                    //    if (string.IsNullOrEmpty(txtcz_mz.Text))
                    //    {
                    //        strmz = "NULL";
                    //    }
                    //    else
                    //    {
                    //        strmz = txtcz_mz.Text;
                    //    }
                    //    if (string.IsNullOrEmpty(txtcz_pz.Text))
                    //    {
                    //        strpz = "NULL";
                    //    }
                    //    else
                    //    {
                    //        strpz = txtcz_pz.Text;
                    //    }

                    //    strjz = "NULL";



                    //    publi_led = "重量为：" + txtcz_pz.Text + "吨";

                    //    voice("重量为：" + txtcz_pz.Text + "吨,请下磅");
                    //    led_send("重量为：" + txtcz_pz.Text + "吨", 2);


                    //    insert.insert_CZJL(ConnectionManger.szqy, jbbd1, txtcz_ch.Text, txtcz_kh.Text, txtcz_jsy.Text, txtgn_name.Text, strmz, strpz, strjz, "", "", htcode, txtcz_sby.Text, "", "", DateTime.Now.ToString(), "", "", ConnectionManger.Card_Address, "未完成", txtcz_gwdw.Text, txtru_shdw.Text);


                    //    update.update_Flow_bdh(jbbd1, "-进磅", "未完成");

                    //    insert.insert_Photo(jbbd1, byteimg1);
                    //    insert.insert_Photo(jbbd1, byteimg2);
                    //    insert.insert_Photo(jbbd1, byteimg3);
                    //    insert.insert_Photo(jbbd1, byteimg4);


                    //}

                }
                #endregion








                //dataGridView1.AutoGenerateColumns = false;
                //dataGridView1.DataSource = select.bind_CZJL(ConnectionManger.szqy);

                //bind_data();
              
           

            
             
               

            }


            txtcz_kh.Text = "";
            txtcz_ch.Text = "";
            txtcz_jsy.Text = "";
            txtgn_name.Text = "";
            txtcz_gwdw.Text = "";
            txtru_shdw.Text = "";
            txtcz_mz.Text = "";
            txtcz_pz.Text = "";
            txtcz_jz.Text = "";
          
            timer1.Enabled = false;
        }


     

        #endregion


        #region 视频



        private Int32 m_lUserID1 = -1, m_lUserID2 = -1, m_lUserID3 = -1, m_lUserID4 = -1;
        private Int32 m_lRealHandle1 =-1, m_lRealHandle2 = -1,m_lRealHandle3 =-1, m_lRealHandle4 = -1;
        private bool m_bInitSDK = false;



        private int user = 0;
        private int playHandle1 = 0, playHandle2 = 0, playHandle3 = 0, playHandle4 = 0;
        public void video()
        {

            bool tag = HikSDK.NET_DVR_Init();
            HikSDK.LPNET_DVR_DEVICEINFO_V301 dev = new HikSDK.LPNET_DVR_DEVICEINFO_V301();
            user = HikSDK.NET_DVR_Login_V30(ConnectionManger.strvideo1, 8000, "admin", "123456789.", out dev);
            HikSDK.NET_DVR_CLIENTINFO cl1 = new HikSDK.NET_DVR_CLIENTINFO();
            cl1.hPlayWnd = picvideo1.Handle ;
            cl1.lChannel = 1;
            cl1.lLinkMode = 0;
            //return;  /////////*******************************************************如果下载或回放,必须先停止播放
            playHandle1 = HikSDK.NET_DVR_RealPlay(user, ref cl1);

            //bool tag2 = HikSDK.NET_DVR_Init();
            //HikSDK.LPNET_DVR_DEVICEINFO_V301 dev2 = new HikSDK.LPNET_DVR_DEVICEINFO_V301();
            user = HikSDK.NET_DVR_Login_V30(ConnectionManger.strvideo2, 8000, "admin", "123456789.", out dev);
            HikSDK.NET_DVR_CLIENTINFO cl2 = new HikSDK.NET_DVR_CLIENTINFO();
            cl2.hPlayWnd = picvideo2.Handle;
            cl2.lChannel = 1;
            cl2.lLinkMode = 0;
            //return;  /////////*******************************************************如果下载或回放,必须先停止播放
            playHandle2 = HikSDK.NET_DVR_RealPlay(user, ref cl2);


            //HikSDK.LPNET_DVR_DEVICEINFO_V301 dev3 = new HikSDK.LPNET_DVR_DEVICEINFO_V301();
            user = HikSDK.NET_DVR_Login_V30(ConnectionManger.strvideo3, 8000, "admin", "123456789.", out dev);
            HikSDK.NET_DVR_CLIENTINFO cl3 = new HikSDK.NET_DVR_CLIENTINFO();
            cl3.hPlayWnd = picvideo3.Handle;
            cl3.lChannel = 1;
            cl3.lLinkMode = 0;
            //return;  /////////*******************************************************如果下载或回放,必须先停止播放
            playHandle3 = HikSDK.NET_DVR_RealPlay(user, ref cl3);


            user = HikSDK.NET_DVR_Login_V30(ConnectionManger.strvideo4, 8000, "admin", "123456789.", out dev);
            HikSDK.NET_DVR_CLIENTINFO cl4 = new HikSDK.NET_DVR_CLIENTINFO();
            cl4.hPlayWnd = picvideo4.Handle;
            cl4.lChannel = 1;
            cl4.lLinkMode = 0;
            //return;  /////////*******************************************************如果下载或回放,必须先停止播放
            playHandle4 = HikSDK.NET_DVR_RealPlay(user, ref cl4);

           

            //if (m_lUserID1 < 0)
            //{


            //    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo1 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            //    //登录设备 Login the device
            //    m_lUserID1 = CHCNetSDK.NET_DVR_Login_V30(ConnectionManger.strvideo1, 8000, "admin", "123456789.", ref DeviceInfo1);

            //    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //    lpPreviewInfo.hPlayWnd = picvideo1.Handle;//预览窗口
            //    lpPreviewInfo.lChannel = 1;//预te览的设备通道
            //    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            //    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            //    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

            //    IntPtr pUser = new IntPtr();//用户数据

            //    //打开预览 Start live view 
            //    m_lRealHandle1 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID1, ref lpPreviewInfo, null, pUser);
            //}
            //if (m_lUserID2 < 0)
            //{


            //    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo2 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            //    //登录设备 Login the device
            //    m_lUserID2 = CHCNetSDK.NET_DVR_Login_V30(ConnectionManger.strvideo2, 8000, "admin", "123456789.", ref DeviceInfo2);

            //    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //    lpPreviewInfo.hPlayWnd = picvideo2.Handle;//预览窗口
            //    lpPreviewInfo.lChannel = 1;//预te览的设备通道
            //    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            //    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            //    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

            //    IntPtr pUser = new IntPtr();//用户数据

            //    //打开预览 Start live view 
            //    m_lRealHandle2 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID2, ref lpPreviewInfo, null, pUser);
            //}

            //if (m_lUserID3 < 0)
            //{


            //    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo3 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            //    //登录设备 Login the device
            //    m_lUserID3 = CHCNetSDK.NET_DVR_Login_V30(ConnectionManger.strvideo3, 8000, "admin", "123456789.", ref DeviceInfo3);

            //    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //    lpPreviewInfo.hPlayWnd = picvideo3.Handle;//预览窗口
            //    lpPreviewInfo.lChannel = 1;//预te览的设备通道
            //    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            //    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            //    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

            //    IntPtr pUser = new IntPtr();//用户数据

            //    //打开预览 Start live view 
            //    m_lRealHandle3 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID3, ref lpPreviewInfo, null, pUser);
            //}

            //if (m_lUserID4 < 0)
            //{


            //    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo4 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            //    //登录设备 Login the device
            //    m_lUserID4 = CHCNetSDK.NET_DVR_Login_V30(ConnectionManger.strvideo4, 8000, "admin", "123456789.", ref DeviceInfo4);

            //    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //    lpPreviewInfo.hPlayWnd = picvideo4.Handle;//预览窗口
            //    lpPreviewInfo.lChannel = 1;//预te览的设备通道
            //    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            //    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            //    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

            //    IntPtr pUser = new IntPtr();//用户数据

            //    //打开预览 Start live view 
            //    m_lRealHandle4 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID4, ref lpPreviewInfo, null, pUser);
            //}

        }
        #endregion

        #region  读取XML文件

       
        //private string strvideo1 = "";   //视频1IP
        //private string strvideo2 = "";   //视频2IP
        //private string strvideo3 = "";   //视频3IP
        //private string strvideo4 = "";   //视频4IP

        //private string szqy = "";        //所在区域
        //private string Com = "";         //Com口
        //private string Flow = "进磅";    //流程
        //public void readxml()
        //{
        //    XmlDocument xmlDoc=new XmlDocument();
        //    xmlDoc.Load("han.xml");
        //    XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
        //    foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
        //    {
        //        XmlElement xe=(XmlElement)xn;//将子节点类型转换为XmlElement类型
             
        //        if (xe.GetAttribute("lun") == "video1")
        //        {
        //            strvideo1 = xe.InnerText.Trim();      //给视频赋值IP
                  
        //        }
        //        if (xe.GetAttribute("lun") == "video2")
        //        {
        //            strvideo2 = xe.InnerText.Trim();
        //        }
        //        if (xe.GetAttribute("lun") == "video3")
        //        {
        //            strvideo3 = xe.InnerText.Trim();
        //        }
        //        if (xe.GetAttribute("lun") == "video4")
        //        {
        //            strvideo4 = xe.InnerText.Trim();   
        //        }

        //        if (xe.GetAttribute("lun") == "qu")
        //        {
        //            szqy = xe.InnerText.Trim();   
        //        }

        //        if (xe.GetAttribute("lun") == "Com")
        //        {
        //            Com  = xe.InnerText.Trim();
        //        }

        //        if (xe.GetAttribute("lun") == "Com")
        //        {
        //            Com = xe.InnerText.Trim();
        //        }
        //        if (xe.GetAttribute("lun") == "flow")
        //        {
        //            Flow = xe.InnerText.Trim();
        //        }
                
        //    }
        //}

        #endregion


        #region 把图片转换成二进制

      
        public byte[] GetPictureData(string imagepath)
        {
            /**/
            ////根据图片文件的路径使用文件流打开，并保存为byte[] 
            

            FileStream fs = new FileStream(imagepath, FileMode.Open);//可以是其他重载方法 
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            
            return byData;
        }

        public byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
        {
            //将Image转换成流数据，并保存为byte[] 
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }

        #endregion

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region 生成图片并转换成二进制




            CHCNetSDK.NET_DVR_CapturePicture(playHandle1, "BMP_test1.bmp");

            CHCNetSDK.NET_DVR_CapturePicture(playHandle2, "BMP_test2.bmp");
            CHCNetSDK.NET_DVR_CapturePicture(playHandle3, "BMP_test3.bmp");

            CHCNetSDK.NET_DVR_CapturePicture(playHandle4, "BMP_test4.bmp");

            Thread.Sleep(200);

            byte[] byteimg1 = GetPictureData("BMP_test1.bmp");      //把图片转换成二进制文件
            byte[] byteimg2 = GetPictureData("BMP_test2.bmp");
            byte[] byteimg3 = GetPictureData("BMP_test3.bmp");
            byte[] byteimg4 = GetPictureData("BMP_test4.bmp");

            #endregion
 
            double dmz, dpz;
            if (string.IsNullOrEmpty(txtcz_mz.Text))
            {
                dmz = 0.00;
            }
            else
            {
                dmz = Convert.ToDouble(txtcz_mz.Text);
            }

            if (string.IsNullOrEmpty(txtcz_pz.Text))
            {
                dpz = 0.00;
            }
            else
            {
                dpz = Convert.ToDouble(txtcz_pz.Text);
            }
            txtcz_jz.Text = Math.Abs(dmz - dpz).ToString("0.00");


            if (ConnectionManger.Flow == "皮毛同称")
            {
                DataTable dtsk = select.bind_CZJL_cz_kh(txtcz_kh.Text);
                //当已存在时说明已刷卡
                if (dtsk.Rows.Count > 0)
                {
                    txtcz_mz.Text = lbl_weight.Text;
                    string cbbd2 = "";
                    DataTable dtcbbd2 = select.bind_bdh_Flow(txtcz_kh.Text);
                    if (dtcbbd2.Rows.Count > 0)
                    {
                        cbbd2 = dtcbbd2.Rows[0]["fw_bdh"].ToString();
                        public_bdh = cbbd2;
                    }


                    update.update_Flow_bdh(cbbd2, "-出磅", "未完成");

                    insert.insert_Photo(cbbd2, byteimg1);
                    insert.insert_Photo(cbbd2, byteimg2);
                    insert.insert_Photo(cbbd2, byteimg3);
                    insert.insert_Photo(cbbd2, byteimg4);
                    //}


                    //print(); //不用时注释掉


                }
                else
                {
                    txtcz_pz.Text = lbl_weight.Text;
                    string jbbd1 = "";
                    DataTable dtjbbd1 = select.bind_bdh_Flow(txtcz_kh.Text);
                    if (dtjbbd1.Rows.Count > 0)
                    {
                        jbbd1 = dtjbbd1.Rows[0]["fw_bdh"].ToString();
                        public_bdh = jbbd1;
                    }

                    string strmz = "";
                    string strpz = "";
                    string strjz = "";
                    if (string.IsNullOrEmpty(txtcz_mz.Text))
                    {
                        strmz = "NULL";
                    }
                    else
                    {
                        strmz = txtcz_mz.Text;
                    }
                    if (string.IsNullOrEmpty(txtcz_pz.Text))
                    {
                        strpz = "NULL";
                    }
                    else
                    {
                        strpz = txtcz_pz.Text;
                    }

                    strjz = "NULL";
                   
                    voice("重量为：" + txtcz_pz.Text + "吨,请下磅");
                    led_send("重量为：" + txtcz_pz.Text + "吨", 2);
                    insert.insert_CZJL(ConnectionManger.szqy, jbbd1, txtcz_ch.Text, txtcz_kh.Text, txtcz_jsy.Text, txtgn_name.Text, strmz, strpz, strjz, "", "", htcode, txtcz_sby.Text, "", "", DateTime.Now.ToString(), "", "", ConnectionManger.Card_Address, "未完成", txtcz_gwdw.Text, txtru_shdw.Text);
                    update.update_Flow_bdh(jbbd1, "-进磅", "未完成");

                    insert.insert_Photo(jbbd1, byteimg1);
                    insert.insert_Photo(jbbd1, byteimg2);
                    insert.insert_Photo(jbbd1, byteimg3);
                    insert.insert_Photo(jbbd1, byteimg4);

                
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < public_name.Length; i++)
            //{
            //    if (public_name[i] == txtgn_name.Text)
            //    {
                    fulljz = txtcz_jz.Text;
                    fullsby = txtcz_sby.Text;
                    fullpz = txtcz_pz.Text;
                    print();
            //    }
            //}
            
            //led_send("当前重量为30吨,请下磅");
            //voice("当前重量为30吨,请下磅");
        
        }


        #region 设置视频高度
        private void Main_Resize(object sender, EventArgs e)
        {
          

            heightpan = (panel6.Height - 30) / 4;
            picvideo1.Location = new Point(6, 5);
            picvideo2.Location = new Point(6, heightpan + 10);
            picvideo3.Location = new Point(6, 2 * heightpan + 15);
            picvideo4.Location = new Point(6, 3 * heightpan + 20);
            picvideo1.Height = picvideo2.Height = picvideo3.Height = picvideo4.Height = heightpan;

          
        }
        #endregion


    

        private void picvideo1_Click(object sender, EventArgs e)
        {
            
        }

        private void picvideo2_Click(object sender, EventArgs e)
        {

        }

        #region 系统管理员权限 双击视频可以设置IP
      
        private void picvideo2_DoubleClick(object sender, EventArgs e)
        {
            //Video1IP v1 = new Video1IP(2);
            //v1.ShowDialog();
            //m_lUserID1 = m_lUserID2 = m_lUserID3 = m_lUserID4 = -1;
            //ConnectionManger.readxml();
            //video();
        }

        private void picvideo1_DoubleClick(object sender, EventArgs e)
        {
            //Video1IP v1 = new Video1IP(1);
            //v1.ShowDialog();
            //m_lUserID1 = m_lUserID2 = m_lUserID3 = m_lUserID4 = -1;
            //ConnectionManger.readxml();
            //video();
        }

        private void picvideo3_DoubleClick(object sender, EventArgs e)
        {
            //Video1IP v1 = new Video1IP(3);
            //v1.ShowDialog();
            //m_lUserID1 = m_lUserID2 = m_lUserID3 = m_lUserID4 = -1;
            //ConnectionManger.readxml();
            //video();
        }

        private void picvideo4_DoubleClick(object sender, EventArgs e)
        {
            //Video1IP v1 = new Video1IP(4);
            //v1.ShowDialog();
            //m_lUserID1 = m_lUserID2 = m_lUserID3 = m_lUserID4 = -1;
            //ConnectionManger.readxml();
            //video();
        }

        #endregion

        //退出
        private void button3_Click(object sender, EventArgs e)
        {
            comm.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            public_exit = 1;
            try
            {
                comm.DiscardInBuffer();
                comm.DiscardOutBuffer();
                comm.Dispose();
                comm.Close();
                yibiao_comm.Dispose();
                yibiao_comm.Close();
                comm_model.Dispose();
                comm_model.Close();
            }
            catch (Exception ex)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int icounts = 0;
            send_model(ConnectionManger.Model_Com_Send_Txt);
            while (!strback.Equals("3E0D"))
            {
                icounts++;

                Thread.Sleep(400);
                send_model(ConnectionManger.Model_Com_Send_Txt);
                if (icounts > 3) break;
            }
            piclg1.Visible = false;
            Thread.Sleep(5000);

            send_model(ConnectionManger.Model_Com_Down_Txt);
            while (!strback.Equals("3E0D"))
            {

                Thread.Sleep(400);
                send_model(ConnectionManger.Model_Com_Down_Txt);

            }
            piclg1.Visible = true ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            send_model(ConnectionManger.Model_Com_Down_Txt);
            while (!strback.Equals("3E0D"))
            {

                Thread.Sleep(400);
                send_model(ConnectionManger.Model_Com_Down_Txt);

            }

            piclg1.Visible = true;
        }

    
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox2.Checked == false)
            //{
            //    panel6.Visible = false;
            //    panel7.Dock = DockStyle.Fill;
            //}
            //else
            //{
            //    try
            //    {
            //        panel6.Visible = true;
            //        this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //              | System.Windows.Forms.AnchorStyles.Left)
            //              | System.Windows.Forms.AnchorStyles.Right)));

            //        video();
            //    }
            //    catch (Exception ex)
            //    { }
            //}
        }

        private void gan_down_time_Tick(object sender, EventArgs e)
        {
            //send_model(ConnectionManger.Model_Com_Down_Txt);
            //while (!strback.Equals("3E0D"))
            //{

            //    Thread.Sleep(400);
            //    send_model(ConnectionManger.Model_Com_Send_Txt);

            //}

            piclg1.Visible = true;
            gan_down_time.Enabled = false;
        }

        private string address = "";//位置
        private int st_redline1, st_redline2, st_gan1, st_gan2;
        private void status_time_Tick(object sender, EventArgs e)
        {
            //send_model("40 30 31 0d");
            while (fullbyte.Length < 5)
            {
                send_model("40 30 31 0d");
            }
            if (fullbyte.Length > 5)
            {
                
            }


            insert.insert_StatusTable(address, st_redline1, st_redline2, st_gan1, st_gan2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                btnlg1.Enabled = false;
                btnlg2.Enabled = false;
                btntg1.Enabled = false;
                btntg2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                txtcz_mz.ReadOnly = true;
                txtcz_pz.ReadOnly = true;
                

                txtcz_ch.Text = "";
                txtcz_jsy.Text = "";
                txtgn_name.Text = "";
                txtcz_gwdw.Text = "";
                txtru_shdw.Text = "";
                txtcz_kh.Text = "";
                txtcz_mz.Text = "";
                txtcz_pz.Text = "";
                txtcz_jz.Text = "";

                public_while = 0;
                dataGridView1.ContextMenuStrip = null;
               
                Com_hth.Visible = false;
                label2.Visible = false;

            }
            else
            {
                dataGridView1.ContextMenuStrip = this.contextMenuStrip1;

                if (ConnectionManger.UserType == "管理员")
                {
                    btnlg1.Enabled = true;
                    //btnlg2.Enabled = true;
                    btntg1.Enabled = true;
                    //btntg2.Enabled = true;
                }
                else
                {
                    btnlg1.Enabled = false;
                    //btnlg2.Enabled = false;  
                    btntg1.Enabled = false;
                    btntg2.Enabled = false;
                }
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                txtcz_mz.ReadOnly = false ;
                txtcz_pz.ReadOnly = false;
                public_while = 1;
            }
        }

     
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                Com_hth.Visible = true;
                label2.Visible = true;
                string id = dataGridView1.SelectedCells[0].Value.ToString();
                public_xg_id = id;
                DataTable dtgridview = select.bind_CZJL_id(id);
                if (dtgridview.Rows.Count > 0)
                {
                    public_bdh = dtgridview.Rows[0]["cz_dh"].ToString();
                    txtcz_ch.Text = dtgridview.Rows[0]["cz_ch"].ToString();
                    txtcz_jsy.Text = dtgridview.Rows[0]["cz_jsy"].ToString();
                    txtgn_name.Text = dtgridview.Rows[0]["gn_name"].ToString();
                    txtcz_gwdw.Text = dtgridview.Rows[0]["cz_gwdw"].ToString();
                    txtru_shdw.Text = dtgridview.Rows[0]["ru_shdw"].ToString();
                    txtcz_kh.Text = dtgridview.Rows[0]["cz_kh"].ToString();
                    txtcz_mz.Text = dtgridview.Rows[0]["cz_mz"].ToString();
                    txtcz_pz.Text = dtgridview.Rows[0]["cz_pz"].ToString();
                    txtcz_jz.Text = dtgridview.Rows[0]["cz_jz"].ToString();
                    Com_hth.Text = dtgridview.Rows[0]["cn_code"].ToString();
                }
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            double mz, pz;
            if (ConnectionManger.UserType == "管理员")
            {
                if (txtcz_jz.Text == "") txtcz_jz.Text = "0.0";
                if (txtcz_mz.Text == "")
                { mz = 0.0; }
                else
                { mz = Convert.ToDouble(txtcz_mz.Text); }
                if (txtcz_pz.Text == "")
                { pz = 0.0; }
                else {pz= Convert.ToDouble(txtcz_pz.Text);}
                string id = dataGridView1.SelectedCells[0].Value.ToString();//获取数据列表id
                string nowbdh = dataGridView1.SelectedCells[2].Value.ToString();
                //if (update.proc_update_czjl_list(txtcz_ch.Text, txtgn_name.Text, txtcz_gwdw.Text, Convert.ToDouble(txtcz_mz.Text),
                //    Convert.ToDouble(txtcz_pz.Text), Convert.ToDouble(txtcz_jz.Text), txtru_shdw.Text, ConnectionManger.G_MineArea, id, txtcz_sby.Text) > 0)
                //{
                //    MessageBox.Show("修改成功！");
                //    bind_data();
                //}

                if (update.proc_update_czjl_contract_carmanage(Com_hth.Text, id, mz, pz,
                    Convert.ToDouble(txtcz_jz.Text), txtcz_ch.Text, txtcz_jsy.Text, txtcz_sby.Text, ConnectionManger.G_MineArea) > 0)
                {
                    MessageBox.Show("修改成功！");
                    bind_data();
                }

                Com_hth.Visible = false ;
                label2.Visible = false;
                //string nowbdh = ""; //通过存储过程返回磅单号
                //int returncs = 0;
                //string returnsby = "";
                //float returnpz = 0.0f;
                //float returnjz = 0.0f;
                //update.update_proc_update_CZJL(txtcz_kh.Text, txtcz_mz.Text, ref nowbdh, ref returncs, "完成", txtcz_sby.Text, ref returnsby, ref returnpz, ref returnjz, ConnectionManger.Card_Address);


                //if (returncs == 1)
                //{
                //    voice("已超出合同总量！");
                //    txtcz_kh.Text = "";
                //    txtcz_ch.Text = "";
                //    txtcz_jsy.Text = "";
                //    txtgn_name.Text = "";
                //    txtcz_gwdw.Text = "";
                //    txtru_shdw.Text = "";
                //    txtcz_mz.Text = "";
                //    txtcz_pz.Text = "";
                //    txtcz_jz.Text = "";
                //    //timer3.Enabled = true;
                //    timer1.Enabled = false;

                //    return;
                //}


                //update.update_Flow_bdh(nowbdh, "-出磅", "完成");
                //update.update_CZJL_cz_wcbj(nowbdh);
                //update.update_CarManage_cm_complete(txtcz_kh.Text);
            }
        }

        private void txtcz_mz_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            bool IsContainsDot = this.txtcz_mz.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }

        
        }

        private void txtcz_pz_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool IsContainsDot = this.txtcz_pz.Text.Contains(".");
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入 
            {
                e.Handled = true;
            }

           
        }

        private void txtcz_mz_TextChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (txtcz_pz.Text == "")
                {
                    txtcz_pz.Text = "0";
                }
                if (txtcz_mz.Text == "")
                {
                    txtcz_mz.Text = "0";
                }
                txtcz_jz.Text = Math.Abs(Convert.ToDouble(txtcz_mz.Text) - Convert.ToDouble(txtcz_pz.Text)).ToString("0.0");
            }

        }

        private void txtcz_pz_TextChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (txtcz_pz.Text == "")
                {
                    txtcz_pz.Text = "0";
                }
                if (txtcz_mz.Text != "")
                {
                    txtcz_jz.Text = Math.Abs(Convert.ToDouble(txtcz_mz.Text) - Convert.ToDouble(txtcz_pz.Text)).ToString("0.0");
                }
                
            }

        }
        //Operation.Delete delete = new Operation.Delete();
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConnectionManger.UserType == "管理员")
            {
                if (checkBox1.Checked == false)
                {

                    string bdh = dataGridView1.SelectedCells[2].Value.ToString();//
                    string wcbj = dataGridView1.SelectedCells[19].Value.ToString();
                    string code = dataGridView1.SelectedCells[20].Value.ToString();//合同号
                    double jz = 0.0;
                    if (dataGridView1.SelectedCells[9].Value.ToString() != "")
                    {
                        jz = Convert.ToDouble(dataGridView1.SelectedCells[9].Value.ToString());
                    }

                    //if (wcbj == "完成")
                    //{
                    //    MessageBox.Show("不能删除已完成的信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    int bj = 1;
                    if (wcbj == "完成")
                    {
                        bj = 2;
                    }
                    else
                    {
                        bj = 1;
                    }
                    if (delete.delete_CZJL_bdh(bdh, jz, code, bj) > 0)
                    {
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bind_data();
                        //dataGridView1.AutoGenerateColumns = false;
                        //dataGridView1.DataSource = select.bind_CZJL(ConnectionManger.szqy);
                    }

                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            bind_data();
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = select.bind_CZJL(ConnectionManger.szqy);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[1].Value = row.Index + 1;
            }
        }

        private void btntg2_Click(object sender, EventArgs e)
        {
            int icounts = 0;
            send_model(ConnectionManger.Model_Com_Send_Txt_2);
            while (!strback.Equals("3E0D"))
            {
                icounts++;

                Thread.Sleep(400);
                send_model(ConnectionManger.Model_Com_Send_Txt_2);
                if (icounts > 3) break;
            }
            piclg2.Visible = false;
        }

        private void Com_hth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "select * from ContractNews where cn_code = '" + Com_hth.Text + "'";
            DataTable dt = SQLHelper.GetDataSet(str, CommandType.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtcz_gwdw.Text = dt.Rows[0]["su_unit"].ToString();
                txtru_shdw.Text = dt.Rows[0]["ru_unit"].ToString();
                txtgn_name.Text = dt.Rows[0]["cn_hwmc"].ToString();
            }
        }

        private void btnlg2_Click(object sender, EventArgs e)
        {

        }
    

    

      

    }
}
