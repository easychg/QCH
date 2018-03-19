using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace QCHManage
{
    public class ConnectionManger
    {
        public static string G_MineArea = "五家沟";
        public static string UserName;
        public static string UserType;

        public static FrmNew G_FrmNew;
        public static FrmMain G_FrmMain;
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        //public static SqlConnection GetConnection()
        //{
        //    string str = "";

        //    str = ConfigurationManager.ConnectionStrings["QCH"].ConnectionString.ToString();

        //    SqlConnection conn = new SqlConnection(str);
        //    return conn;
        //}


        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            //string str = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

                if (xe.GetAttribute("lun") == "QCH")
                {
                    str = xe.InnerText.Trim();      //给视频赋值IP

                }
            }


            //str = ConfigurationManager.ConnectionStrings["QCH"].ConnectionString.ToString();

            SqlConnection conn = new SqlConnection(str);
            return conn;
        }

        public static string str = "";


        #region  读取XML文件


        public static string strvideo1 = "";   //视频1IP
        public static string strvideo2 = "";    //视频2IP
        public static string strvideo3 = "";    //视频3IP
        public static string strvideo4 = "";    //视频4IP

        public static string szqy = "";         //所在区域
        public static string Card_Com = "";     //IC卡刷卡器Com口
        public static string Card_Baudrate = "";//IC卡波特率
        public static string Card_Address = ""; //刷卡时车辆所在的位置



        public static string Flow = "";         //流程

        public static string led_IP;             //LED IP
        public static int led_height;             //LED的高度
        public static int led_wight;              //LED的宽度

        public static string Model_Com = "";    //模块Com口
        public static string Model_Com_Send_Txt = ""; //抬杆指令
        public static string Model_Com_Send_Txt_2 = ""; //抬杆指令2
        public static string Model_Com_Down_Txt = "";//落杆指令
                               
        public static string Yibiao_Com = "";        //仪表 端口      
        public static string Yibiao_Baute = "";        //仪表波特率     

        public static string BandDan = "";      //磅单类型                                                                                                                                   
                     
        //public static string G_MineArea = "";   //所在区

        public static string LoadPath = "";  //图片所放路径

        public static string ServerIP = "";   //服务器IP

        public static string PortNum = ""; //端口号

        public static string no_print = "";  //设置不打印的品名

        public static void readxml()
        {                                                                    
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                                    
                if (xe.GetAttribute("lun") == "video1")
                {
                    strvideo1 = xe.InnerText.Trim();      //给视频赋值IP

                }
                if (xe.GetAttribute("lun") == "video2")
                {
                    strvideo2 = xe.InnerText.Trim();
                }
                if (xe.GetAttribute("lun") == "video3")
                {
                    strvideo3 = xe.InnerText.Trim();
                }
                if (xe.GetAttribute("lun") == "video4")
                {
                    strvideo4 = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "qu")
                {
                    G_MineArea = szqy = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "Card_Com")
                {
                    Card_Com = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "Model_Com")
                {
                    Model_Com = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "flow")
                {
                    Flow = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "led_IP")
                {
                    led_IP = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "led_wight")
                {
                    led_wight = int.Parse(xe.InnerText.Trim());
                }

                if (xe.GetAttribute("lun") == "led_height")
                {
                    led_height = int.Parse(xe.InnerText.Trim());
                }

                if (xe.GetAttribute("lun") == "Model_Com_Send_Txt")
                {
                    Model_Com_Send_Txt = xe.InnerText.Trim();
                }


                if (xe.GetAttribute("lun") == "Model_Com_Send_Txt_2")
                {
                    Model_Com_Send_Txt_2 = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "Model_Com_Down_Txt")
                {
                    Model_Com_Down_Txt = xe.InnerText.Trim();
                }


                if (xe.GetAttribute("lun") == "Card_Baudrate")
                {
                    Card_Baudrate = xe.InnerText.Trim();
                }


                if (xe.GetAttribute("lun") == "Card_Address")
                {
                    Card_Address = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "Yibiao_Com")
                {
                    Yibiao_Com = xe.InnerText.Trim();
                }

                if (xe.GetAttribute("lun") == "Yibiao_Baute")
                {
                    Yibiao_Baute = xe.InnerText.Trim();
                }


                //磅单类型
                if (xe.GetAttribute("lun") == "BandDan")
                {
                    BandDan = xe.InnerText.Trim();
                }

                //图片所放位置
                if (xe.GetAttribute("lun") == "data_path")
                {
                    LoadPath  = xe.InnerText.Trim();
                }

                //不打印的品名
                if (xe.GetAttribute("lun") == "no_print")
                {
                    no_print = xe.InnerText.Trim();
                }


            }
        }

        #endregion
    }
}
