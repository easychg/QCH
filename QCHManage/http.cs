using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace QCHManage
{
    public partial class http : Form
    {
        public http()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:8928/http.aspx";
            string strXml = "<xml>fdsf</xml>";
            int timeout = 2;
            GetPostResult(url, strXml, timeout);
            //ServiceReference1.WebService1SoapClient myWebService = new ServiceReference1.WebService1SoapClient("WebService1Soap");
            //string aa=myWebService.HelloWorld("aa");

        }
        /// <summary>
        /// post给定的url并获取返回的数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private string GetPostResult(string url, string strXml, int timeout)
        {
            string result;
            try
            {
                
                //strXml = strXml.Remove(0, strXml.IndexOf("<"));
                //将数据以数据流方式提交到网关
                WebRequest myWebRequest = WebRequest.Create(url);
                myWebRequest.Method = "POST";
                //myWebRequest.Timeout = timeout;
                myWebRequest.ContentType = "text/xml";

                byte[] data = Encoding.UTF8.GetBytes(strXml);
                myWebRequest.ContentLength = data.Length;
                //添加Request.ContentType,否则对方可能无法接收
                //myWebRequest.ContentType = "text/html";
                myWebRequest.GetRequestStream().Write(data, 0, data.Length);


                HttpWebResponse rep2 = (HttpWebResponse)myWebRequest.GetResponse();


                //获取返回的数据
                //WebResponse myWebResponse = myWebRequest.GetResponse();
                StreamReader sr = new StreamReader(rep2.GetResponseStream());
                result = sr.ReadToEnd();
                result = result.Replace("/r/n", "");
                sr.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.ToString());
                result = "error";
            }
            return result;
        }
    }
}
