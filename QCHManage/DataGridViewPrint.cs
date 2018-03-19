using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QCHManage
{
    class DataGridViewPrint
    {
        //要打印的gridview
        private DataGridView TheDataGridView;

        //要传给打印机的文件
        private PrintDocument ThePrintDocument;
        //是否居中
        private bool IsCenterOnPage;
        //是否还有标题
        private bool IsWithTitle;
        //是否
        private bool IsWithPaging;
        //标题名称
        private string TheTitleText;
        //标题字体
        private Font TheTitleFont;
        //标题颜色
        private Color TheTitleColor;
        //当前的行数
        static int CurrentRow = 0;
        //页数
        public static int PageNumber = 0;
        //纸张的宽度
        private int PageWidth;
        //纸张的长度
        private int PageHeight;
        //左间距
        private int LeftMargin;
        //顶间距
        private int TopMatgin;
        //右间距
        private int RightMargin;
        //底间距
        private int BottomMargin;
        private float CurrentY;
        //列头的高度
        private float RowHeaderHeight;
        //每行的高度
        private List<float> RowsHeight;
        //每列的宽度
        private List<float> ColumnsWidth;
        //整个表格的宽度
        private float TheDataGridViewWidth;
        public static List<int[]> mColumnPoints;
        public static List<float> mColumPointsWidth;
        public static int mColumnPoint;

        private string time_duan;//标题下面的时间段
        private string type_name;//标题下面的类型
        private int intheji = 0;//设置合计的X
        private string hejicontent;//合计内容



        #region  有参构造函数
        ///
        /// 有参构造函数
        ///
        /// 要打印的DataGridView
        /// 要传给打印机的打印文件
        /// 是否居中
        /// 是否包含标题
        /// 标题名称
        /// 标题文本格式
        /// 标题的颜色
        ///
        public DataGridViewPrint(DataGridView theDataGridView, PrintDocument thePrintDocument, bool isCennterOnPage, bool isWithTitle, string theTitleText, Font theTitleFont, Color theTitleColor, bool isWithPaing,string Time_Duan,string Type_Name,int IntHj,string HjContent)
        {
            TheDataGridView = theDataGridView;
            ThePrintDocument = thePrintDocument;
            IsCenterOnPage = isCennterOnPage;
            IsWithTitle = isWithTitle;
            IsWithPaging = isWithPaing;
            TheTitleText = theTitleText;
            TheTitleFont = theTitleFont;
            TheTitleColor = theTitleColor;
            IsWithPaging = isWithPaing;
            RowsHeight = new List<float>();
            ColumnsWidth = new List<float>();
            mColumnPoints = new List<int[]>();
            mColumPointsWidth = new List<float>();
            time_duan = Time_Duan;
            type_name = Type_Name;
            intheji = IntHj;
            hejicontent = HjContent;
            //根据用户所选纸张纵向还是横向来获得纸张的高度和宽度
            if (!ThePrintDocument.DefaultPageSettings.Landscape)
            {
                //纵向
                PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
                LeftMargin = 10;
                RightMargin = 10;
                TopMatgin = 20;
                BottomMargin = 20;
            }
            else
            {
                //横向
                PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
                PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                LeftMargin = 20;
                RightMargin = 20;
                TopMatgin = 10;
                BottomMargin = 10;
            }
            //LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left;
            //RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right;
            //TopMatgin = ThePrintDocument.DefaultPageSettings.Margins.Top;
            //BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
        }
        #endregion
        //计算出每行的高度，每列的宽度
        public void Calculate(Graphics g)
        {
            //第一页，只计算一次
            if (PageNumber == 0)
            {
                //矩形的宽度和高度（有序浮点数对）
                SizeF tmpSize = new SizeF();
                Font tmpFont;
                float tmpWidth;

                TheDataGridViewWidth = 0;
                for (int i = 0; i < TheDataGridView.Columns.Count; i++)
                {
                    //获取dataGridView的列标题的样式
                    tmpFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font;
                    //如果没有文本格式，就是默认文本样式
                    if (tmpFont == null)
                    {
                        tmpFont = TheDataGridView.DefaultCellStyle.Font;
                    }
                    //根据指定的文本样式获得列头的大小

                    tmpSize = g.MeasureString(TheDataGridView.Columns[i].HeaderText, tmpFont);

                    tmpWidth = TheDataGridView.Columns[i].Width;
                    //获得列头的高度
                    //RowHeaderHeight = RowHeaderHeight >= TheDataGridView.Rows[i].Height ? RowHeaderHeight : TheDataGridView.Rows[i].Height;
                    RowHeaderHeight = 23;
                    for (int j = 0; j < TheDataGridView.Rows.Count; j++)
                    {
                        //获得行的文本样式
                        tmpFont = TheDataGridView.Rows[j].DefaultCellStyle.Font;
                        if (tmpFont == null)
                        {
                            tmpFont = TheDataGridView.DefaultCellStyle.Font;
                        }
                        //根据指定的文本样式来来测量该字符串的大小
                        //tmpSize = g.MeasureString(TheDataGridView.Rows[j], tmpFont);
                        //RowsHeight.Add(TheDataGridView.Rows[i].Height);
                        RowsHeight.Add(23);
                        //获得单元格里面字符串大小
                        tmpSize = g.MeasureString(TheDataGridView.Rows[j].Cells[i].EditedFormattedValue.ToString(), tmpFont);
                        RowsHeight.Add(23);
                        //如果单元格里面的字符串宽度要比列头的宽度大，则以最大的宽度为准
                        if (tmpSize.Width > tmpWidth)
                        {
                            tmpWidth = TheDataGridView.Columns[i].Width;
                        }
                    }
                    //把DataGridView的可见列的宽度叠加，计算出整个DataGridView的宽度
                    if (TheDataGridView.Columns[i].Visible)
                    {
                        TheDataGridViewWidth += tmpWidth;
                    }
                    //记录每一列的宽度
                    ColumnsWidth.Add(tmpWidth);
                }
                int k;
                int mStartPoint = 0;
                for (k = 0; k < TheDataGridView.Columns.Count; k++)
                {
                    if (TheDataGridView.Columns[k].Visible)
                    {
                        mStartPoint = k;
                        break;
                    }
                }
                int mEndPoint = TheDataGridView.Columns.Count;
                for (k = TheDataGridView.Columns.Count - 1; k >= 0; k--)
                {
                    if (TheDataGridView.Columns[k].Visible)
                    {
                        mEndPoint = k + 1;
                        break;
                    }
                }
                float mTempWidth = TheDataGridViewWidth;
                float mTempPrintArea = (float)PageWidth - (float)LeftMargin - (float)RightMargin;
                //只关心当DataGridView的宽度大于要打印的宽度时
                if (TheDataGridViewWidth > mTempPrintArea)
                {
                    mTempWidth = 0.0F;
                    for (k = 0; k < TheDataGridView.Columns.Count; k++)
                    {
                        if (TheDataGridView.Columns[k].Visible)
                        {
                            mTempWidth += ColumnsWidth[k];
                            //如果宽度大于页面宽度话，就定义新的列宽度
                            if (mTempWidth > mTempPrintArea)
                            {
                                mTempWidth -= ColumnsWidth[k];
                                mColumnPoints.Add(new int[] { mStartPoint, mStartPoint });
                                mColumPointsWidth.Add(mTempWidth);
                                mStartPoint = k;
                                mTempWidth = ColumnsWidth[k];
                            }
                        }
                        mEndPoint = k + 1;
                    }
                }
                mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                mColumPointsWidth.Add(mTempWidth);
                mColumnPoint = 0;
            }
        }
        //根据用户选择来绘制页码、标题和列头行
        public void DrawHeader(Graphics g)
        {
            CurrentY = (float)PageHeight - (float)BottomMargin - (float)TopMatgin - 14.0625F;
            //是否含有页码
            if (IsWithPaging)
            {
                PageNumber++;
                string PageString = "- " + PageNumber.ToString() + " -";
                //创建页码文本布局
                StringFormat PageStringFormat = new StringFormat();
                PageStringFormat.Trimming = StringTrimming.Word;
                PageStringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                PageStringFormat.Alignment = StringAlignment.Center;
                //创建页码的文本格式
                Font PageStringFont = new Font("宋体", 8, FontStyle.Regular, GraphicsUnit.Point);//打印机点的度量单位
                //创建页码的位置和大小，其中RectangleF(x,y,width,height)
                RectangleF PageStringRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(PageString, PageStringFont).Height);
                //绘制页码
                g.DrawString(PageString, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle, PageStringFormat);
                //计算出标题的起始Y坐标，如果后面没有标题，就是表格的起始Y坐标
                CurrentY += g.MeasureString(PageString, PageStringFont).Height;
            }
            CurrentY = (float)TopMatgin;
            //是否含有标题
            if (IsWithTitle)
            {
                //创建标题文本布局
                StringFormat TitleFormat = new StringFormat();
                TitleFormat.Trimming = StringTrimming.Word;
                TitleFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                //标题是否居中显示
                TitleFormat.Alignment = IsCenterOnPage ? StringAlignment.Center : StringAlignment.Near;
                //创建标题的位置和大小
                RectangleF TitleRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(TheTitleText, TheTitleFont).Height);
                //绘制标题
                g.DrawString(TheTitleText, TheTitleFont, new SolidBrush(TheTitleColor), TitleRectangle, TitleFormat);
                //计算出表格的起始Y坐标
                CurrentY += g.MeasureString(TheTitleText, TheTitleFont).Height;

                //时间段
                 TitleRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(TheTitleText, TheTitleFont).Height);

                g.DrawString(time_duan, new System.Drawing.Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(TheTitleColor), TitleRectangle, TitleFormat);
                //计算出表格的起始Y坐标
                CurrentY += 30;
                string str="打印日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                g.DrawString(str, new System.Drawing.Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(TheTitleColor), 140, CurrentY, TitleFormat);
                float  strlenth = g.MeasureString(type_name, new System.Drawing.Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Point)).Width;
                g.DrawString(type_name, new System.Drawing.Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(TheTitleColor), (float)PageWidth - strlenth + (float)RightMargin + (float)LeftMargin, CurrentY, TitleFormat);
                CurrentY += 30;
            }
            //
            float CurrentX = (float)LeftMargin;
            if (IsCenterOnPage)
            {
                CurrentX += ((float)PageWidth - (float)RightMargin - (float)LeftMargin - mColumPointsWidth[mColumnPoint]) / 2.0F;
            }
            //创建表格的列头文本的字体颜色和画笔
            Color HeaderForeColor = TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor.IsEmpty ? TheDataGridView.DefaultCellStyle.ForeColor : TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor;
            SolidBrush HeaderForeBrush = new SolidBrush(HeaderForeColor);
            //创建表格的列头文本的背景颜色和画笔
            Color HeaderBackColor = TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor.IsEmpty ? TheDataGridView.DefaultCellStyle.BackColor : TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            SolidBrush HeaderBackBrush = new SolidBrush(HeaderBackColor);
            //创建画线矩形框，矩形框的样式就是DataGridView的网格的样式
            Pen TheLinePen = new Pen(TheDataGridView.GridColor, 1);
            //创建列头的文本样式
            Font HeaderFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font == null ? TheDataGridView.DefaultCellStyle.Font : TheDataGridView.ColumnHeadersDefaultCellStyle.Font;
            //
            RectangleF HeaderBounds = new RectangleF(CurrentX, CurrentY, mColumPointsWidth[mColumnPoint], RowHeaderHeight);
            //填充矩形内部
            g.FillRectangle(HeaderBackBrush, HeaderBounds);
            //创建列头的每个单元格的布局
            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            CellFormat.Alignment = StringAlignment.Center;
            //绘制visible为ture的列头
            RectangleF CellBounds;
            float ColumnWidth;
            int a = (int)mColumnPoints[mColumnPoint].GetValue(1);
            for (int i = (int)mColumnPoints[mColumnPoint].GetValue(0); i < (int)mColumnPoints[mColumnPoint].GetValue(1); i++)
            {
                //如果列头看不见就循环下一个列头
                if (!TheDataGridView.Columns[i].Visible)
                    continue;
                //获得列宽
                ColumnWidth = ColumnsWidth[i];
                ////检查列头单元格的布局是哪里(注释原因：默认居中)
                //if (TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right"))
                //{
                //    CellFormat.Alignment = StringAlignment.Far;
                //}
                //else if (TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center"))
                //{
                //    CellFormat.Alignment = StringAlignment.Near;
                //}
                //else
                //{
                //    CellFormat.Alignment=StringAlignment.Near;
                //}
                //创建该列头单元格的位置和大小
                CellBounds = new RectangleF(CurrentX, CurrentY+6, ColumnWidth, RowHeaderHeight);
                //绘制该列头单元格内的文本
                g.DrawString(TheDataGridView.Columns[i].HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat);
                //绘制该列头单元格的边界
                if (TheDataGridView.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None)
                    g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowHeaderHeight);
                //计算一个列头单元格的起始X坐标
                CurrentX += ColumnWidth;
            }
            //计算数据行的起始Y坐标
            CurrentY += RowHeaderHeight;
        }
        //绘制该纸能容纳下的行
        //返回true说明还有更多的行没有绘制完，返回false所有行都绘制完成了
        public bool DrawRows(Graphics g)
        {
            //
            Pen TheLinePen = new Pen(TheDataGridView.GridColor, 1);
            //声明以下参数，用来绘制每个单元格
            Font RowFont;
            Color RowForeColor;
            Color RowBackColor;
            SolidBrush RowForeBrush;
            SolidBrush RowBackBrush;
            SolidBrush RowAlternatingBackBrush;
            //创建每个单元格文本的布局
            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;
            //单元格位置和大小
            RectangleF RowBounds;
            float CurrentX;
            float ColumnWidth;
            //绘制单元格（按行循环）
            while (CurrentRow < TheDataGridView.Rows.Count)
            {
                //仅打可见的行
                if (TheDataGridView.Rows[CurrentRow].Visible)
                {
                    //设置行单元格文本的字体
                    RowFont = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.Font == null ? TheDataGridView.DefaultCellStyle.Font : TheDataGridView.Rows[CurrentRow].DefaultCellStyle.Font;
                    //设置行单元格文本的字体颜色
                    RowForeColor = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.ForeColor.IsEmpty ? TheDataGridView.DefaultCellStyle.ForeColor : TheDataGridView.Rows[CurrentRow].DefaultCellStyle.ForeColor;
                    RowForeBrush = new SolidBrush(RowForeColor);
                    //设置单元格的背景颜色
                    RowBackColor = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.BackColor;
                    if (RowBackColor.IsEmpty)
                    {
                        //背景颜色
                        RowBackBrush = new SolidBrush(TheDataGridView.DefaultCellStyle.BackColor);
                        //奇数行的背景颜色
                        RowAlternatingBackBrush = new SolidBrush(TheDataGridView.AlternatingRowsDefaultCellStyle.BackColor);
                    }
                    else
                    {
                        RowBackBrush = new SolidBrush(RowBackColor);
                        RowAlternatingBackBrush = new SolidBrush(RowBackColor);
                    }
                    //计算行单元格的起始X坐标
                    CurrentX = (float)LeftMargin;
                    if (IsCenterOnPage)
                    {
                        CurrentX += ((float)PageWidth - (float)RightMargin - (float)LeftMargin - mColumPointsWidth[mColumnPoint]) / 2.0F;
                    }
                    //创建整个单元格的大小和位置
                    RowBounds = new RectangleF(CurrentX, CurrentY, mColumPointsWidth[mColumnPoint], RowsHeight[CurrentRow]);
                    //偶数行和奇数行采取不同颜色来绘制
                    if (CurrentRow % 2 == 0)
                    {
                        g.FillRectangle(RowBackBrush, RowBounds);
                    }
                    else
                    {
                        g.FillRectangle(RowAlternatingBackBrush, RowBounds);
                    }
                    //绘制该行的单元格
                    for (int CurrentCell = (int)mColumnPoints[mColumnPoint].GetValue(0); CurrentCell < (int)mColumnPoints[mColumnPoint].GetValue(1); CurrentCell++)
                    {
                        //不可见的单元格不绘制
                        if (!TheDataGridView.Columns[CurrentCell].Visible)
                        {
                            continue;
                        }
                        //检查单元格内的布局是哪里,并设置
                        if (TheDataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString().Contains("Right"))
                        {
                            CellFormat.Alignment = StringAlignment.Far;
                        }
                        else if (TheDataGridView.Columns[CurrentCell].DefaultCellStyle.Alignment.ToString().Contains("Center"))
                        {
                            CellFormat.Alignment = StringAlignment.Center;
                        }
                        else
                        {
                            CellFormat.Alignment = StringAlignment.Near;
                        }
                        ColumnWidth = ColumnsWidth[CurrentCell];
                        //创建单元格的位置和大小
                        RectangleF CellBounds = new RectangleF(CurrentX, CurrentY+6, ColumnWidth, RowsHeight[CurrentRow]);
                        //绘制文本
                        g.DrawString(TheDataGridView.Rows[CurrentRow].Cells[CurrentCell].EditedFormattedValue.ToString(), RowFont, RowForeBrush, CellBounds, CellFormat);
                        //绘制单元格
                        if (TheDataGridView.CellBorderStyle != DataGridViewCellBorderStyle.None)
                        {
                            g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowsHeight[CurrentRow]);
                        }
                        CurrentX += ColumnWidth;
                    }
                    CurrentY += RowsHeight[CurrentRow];
                    //如果行绘制到纸的底边缘，就跳出方法，告知住方法接着打下一页，至于要不要还有没有行要打，下载在调用本方法的开头就有判断
                
                    if ((int)CurrentY > (PageHeight - TopMatgin - BottomMargin - RowsHeight[CurrentRow] - 14.0625))//14.0625是页码的高度，这里直接写数值，不再用测量方法了，麻烦
                    {
                        //别忘了行数要加一行
                        CurrentRow++;
                        return true;
                    }
                }
                CurrentRow++;
            }
            //运行到这里，就说明所有行都绘制完了，行数置为0
            g.DrawString(hejicontent , new System.Drawing.Font("宋体", 12, FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(TheTitleColor), intheji , CurrentY, CellFormat);
            CurrentRow = 0;
            mColumnPoint++;
            if (mColumnPoint == mColumnPoints.Count)
            {
                mColumnPoint = 0;
                //告诉不用再打了
                return false;
            }
            else
            {
                //还得继续打
                return true;
            }
        }
        public bool DrawDataGridView(Graphics g)
        {
            try
            {
                Calculate(g);
                DrawHeader(g);
                bool bContinue = DrawRows(g);
                return bContinue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败: " + ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
