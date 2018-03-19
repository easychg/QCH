using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace QCHManage
{
    public partial class ParameterSet : Form
    {
        public ParameterSet()
        {
            InitializeComponent();
        }
        XmlDocument xmlDoc = new XmlDocument();
        private SerialPort comm = new SerialPort();
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        private void ParameterSet_Load(object sender, EventArgs e)
        {
            ConnectionManger.readxml();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboBox1.Items.AddRange(ports);
            model_com.Items.AddRange(ports);
            yb_Com.Items.AddRange(ports);
            comboBox1.Text   = ConnectionManger.Card_Com;
            comboBox2.Text = ConnectionManger.Card_Baudrate;

            txt_video1.Text = ConnectionManger.strvideo1;
            txt_video2.Text = ConnectionManger.strvideo2;
            txt_video3.Text = ConnectionManger.strvideo3;
            txt_video4.Text = ConnectionManger.strvideo4;

            model_com.Text = ConnectionManger.Model_Com;
            model_txt.Text = ConnectionManger.Model_Com_Send_Txt;
            model_baute.SelectedIndex = 0;

            comboBox3.Text = "1";

            yb_Com.Text = ConnectionManger.Yibiao_Com;
            yb_baute.Text = ConnectionManger.Yibiao_Baute;

            txt_ledip.Text = ConnectionManger.led_IP ;
            txt_ledwight.Text = ConnectionManger.led_wight.ToString();
            txt_ledheight.Text = ConnectionManger.led_height.ToString();
            try
            {
                comm.BaudRate =int.Parse( ConnectionManger.Card_Baudrate) ;
                comm.PortName = ConnectionManger.Card_Com;
                if (!comm.IsOpen)
                {
                    comm.Open();
                }
                //添加事件注册

                comm.DataReceived += comm_DataReceived;
            }
            catch (Exception ex)
            { }


            //根据当前串口对象，来判断操作
            if (comm_model.IsOpen)
            {
                //打开时点击，则关闭串口
                comm_model.Close();
            }
            else
            {
                try
                {
                //关闭时点击，则设置好端口，波特率后打开
                comm_model.PortName = ConnectionManger.Model_Com;
                comm_model.BaudRate = 9600;
                
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

        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = comm.ReadBufferSize;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据
           
            comm.Read(buf, 0, n);//读取缓冲数据
            try
            {
                //因为要访问ui资源，所以需要使用invoke方式同步ui。

                this.Invoke((EventHandler)(delegate
                {

                    Thread.Sleep(100);
                  
                    for (int i = 0; i < n; i++)
                    {
                        if (i < n - 5)
                        {
                            if (buf[i].ToString("X2") == "07" && buf[i + 1].ToString("X2") == "00" && buf[i + 2].ToString("X2") == "EE" && buf[i + 3].ToString("X2") == "00")
                            {
                                listBox2.Items.Insert (0,buf[i + 4].ToString("X2") + buf[i + 5].ToString("X2"));
                                listBox2.SelectedIndex = 0;
                            }
                        }
                    }
                }));
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

                if (xe.GetAttribute("lun") == "Card_Com")
                {
                    xe.InnerText = comboBox1.Text;
                    ConnectionManger.Card_Com = comboBox1.Text;
                }

                if (xe.GetAttribute("lun") == "Card_Baudrate")
                {
                    xe.InnerText = comboBox2.Text;
                    ConnectionManger.Card_Baudrate = comboBox2.Text;
                }


            }
            xmlDoc.Save("han.xml");//保存。
            
            MessageBox.Show("设置成功!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

                if (xe.GetAttribute("lun") == "video1")
                {
                    xe.InnerText = txt_video1.Text;
                    ConnectionManger.strvideo1 = txt_video1.Text;
                }
                if (xe.GetAttribute("lun") == "video2")
                {
                    xe.InnerText = txt_video2.Text;
                    ConnectionManger.strvideo2= txt_video2.Text;
                }

                if (xe.GetAttribute("lun") == "video3")
                {
                    xe.InnerText = txt_video3.Text;
                    ConnectionManger.strvideo3 = txt_video3.Text;
                }

                if (xe.GetAttribute("lun") == "video4")
                {
                    xe.InnerText = txt_video4.Text;
                    ConnectionManger.strvideo4= txt_video4.Text;
                }

            }
            xmlDoc.Save("han.xml");//保存。

            MessageBox.Show("设置成功!");
        }
        private SerialPort comm_model = new SerialPort();
        private StringBuilder builder_Model = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。

        private void button4_Click(object sender, EventArgs e)
        {

           

            //我们不管规则了。如果写错了一些，我们允许的，只用正则得到有效的十六进制数
            MatchCollection mc = Regex.Matches(model_txt.Text , @"(?i)[\da-f]{2}");
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
            comm_model.Read(buf, 0, n);//读取缓冲数据
            builder_Model.Clear();//清除字符串构造器的内容
            //因为要访问ui资源，所以需要使用invoke方式同步ui。
            this.Invoke((EventHandler)(delegate
            {

                //依次的拼接出16进制字符串
                foreach (byte b in buf)
                {
                    builder_Model.Append(b.ToString("X2") + " ");
                }
                model_receive_txt.Text  = builder_Model.ToString();
               
            }));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

                if (xe.GetAttribute("lun") == "Model_Com")
                {
                    xe.InnerText = model_com.Text;
                    ConnectionManger.Model_Com  = model_com.Text;
                }


                if (comboBox3.Text == "1")
                {
                    if (xe.GetAttribute("lun") == "Model_Com_Send_Txt")
                    {
                        xe.InnerText = model_txt.Text;
                        ConnectionManger.Model_Com_Send_Txt  = model_txt.Text;
                    }
                }
                else if (comboBox3.Text == "2")
                {
                    if (xe.GetAttribute("lun") == "Model_Com_Send_Txt_2")
                    {
                        xe.InnerText = model_txt.Text;
                        ConnectionManger.Model_Com_Send_Txt_2  = model_txt.Text;
                    }
                }
               

            }
            xmlDoc.Save("han.xml");//保存。

            MessageBox.Show("设置成功!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

                if (xe.GetAttribute("lun") == "led_IP")
                {
                    xe.InnerText = txt_ledip.Text ;
                    ConnectionManger.led_IP = txt_ledip.Text;
                }

                if (xe.GetAttribute("lun") == "led_wight")
                {
                    xe.InnerText = txt_ledwight.Text ;
                    ConnectionManger.led_wight  =int.Parse( txt_ledwight.Text);
                }

                if (xe.GetAttribute("lun") == "led_height")
                {
                    xe.InnerText = txt_ledheight.Text;
                    ConnectionManger.led_height  = int.Parse(txt_ledheight.Text);
                }


            }
            xmlDoc.Save("han.xml");//保存。

            MessageBox.Show("设置成功!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

                if (xe.GetAttribute("lun") == "Yibiao_Com")
                {
                    xe.InnerText = yb_Com.Text;
                    ConnectionManger.Yibiao_Com = yb_Com.Text;
                }
                if (xe.GetAttribute("lun") == "Yibiao_Baute")
                {
                    xe.InnerText = yb_baute.Text;
                    ConnectionManger.Yibiao_Baute = yb_baute.Text;
                }

              

            }
            xmlDoc.Save("han.xml");//保存。

            MessageBox.Show("设置成功!");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "1")
            {
                model_txt.Text = ConnectionManger.Model_Com_Send_Txt;
            }
            else
            {
                model_txt.Text = ConnectionManger.Model_Com_Send_Txt_2;
            }
        }
    }
}
