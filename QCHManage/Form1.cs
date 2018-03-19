using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace QCHManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //DateTime public_time = Convert.ToDateTime("2016-1-19 8:5:10");
            //int iii = (Convert.ToDateTime("2016-1-19 8:6:11") - public_time).Seconds;
            //Thread th = new Thread(new ThreadStart( t));
            //th.IsBackground = true;
          
            //th.Start();
          
            ////Thread t1 = new Thread(new ThreadStart(tb));
           
            ////t1.IsBackground = true;
            ////t1.Start();
            //while (true)
            //{
            //    label2.Text = DateTime.Now.ToString();
            //    Application.DoEvents();
            //    Thread.Sleep(100);
             

            //}
        }

        public delegate void dt();

        

        public void t()
        {
            this.Invoke((EventHandler)(delegate {
                while (true)
                {
                  
                    label1.Text = DateTime.Now.ToString();
                    Thread.Sleep(100);
                    Application.DoEvents();
                   
                   
                }
            }));
        }

        public void tb()
        {
            
            this.Invoke((EventHandler)(delegate
            {
                while (true)
                {
                    label2.Text = DateTime.Now.ToString();
                    Thread.Sleep(100);
                    Application.DoEvents();

                }
            }));
        }
    }
}
