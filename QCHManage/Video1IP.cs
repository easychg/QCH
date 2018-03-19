using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QCHManage
{
    public partial class Video1IP : Form
    {
        private int ICount;
        public Video1IP(int icount)
        {
            InitializeComponent();
            ICount = icount;
        }
        XmlDocument xmlDoc = new XmlDocument();
        private void button1_Click(object sender, EventArgs e)
        {
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                //XmlNodeList xe1 = xe.ChildNodes;
                if (ICount == 1)
                {
                    if (xe.GetAttribute("lun") == "video1")
                    {
                        xe.InnerText = textBox1.Text;

                    }
                }
                else if (ICount == 2)
                {
                    if (xe.GetAttribute("lun") == "video2")
                    {
                        xe.InnerText = textBox1.Text;

                    }
                }
                else if (ICount == 3)
                {
                    if (xe.GetAttribute("lun") == "video3")
                    {
                        xe.InnerText = textBox1.Text;

                    }
                }
                else if (ICount == 4)
                {
                    if (xe.GetAttribute("lun") == "video4")
                    {
                        xe.InnerText = textBox1.Text;

                    }
                }
            }
            xmlDoc.Save("han.xml");//保存。
            MessageBox.Show("设置成功!");
        }

        private void Video1IP_Load(object sender, EventArgs e)
        {
          
            xmlDoc.Load("han.xml");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("han").ChildNodes;//获取bookstore节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历根节点的所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                //XmlNodeList xe1 = xe.ChildNodes;
                if (ICount == 1)
                {
                    if (xe.GetAttribute("lun") == "video1")
                    {
                        textBox1.Text = xe.InnerText.Trim();

                    }
                }
                else if (ICount == 2)
                {
                    if (xe.GetAttribute("lun") == "video2")
                    {
                        textBox1.Text = xe.InnerText.Trim();

                    }
                }
                else if (ICount == 3)
                {
                    if (xe.GetAttribute("lun") == "video3")
                    {
                        textBox1.Text = xe.InnerText.Trim();

                    }
                }
                else if (ICount == 4)
                {
                    if (xe.GetAttribute("lun") == "video4")
                    {
                        textBox1.Text = xe.InnerText.Trim();

                    }
                }
            }
            //textBox1.Text = System.Configuration.ConfigurationManager.ConnectionStrings["video1"].ToString();
        }
    }
}
