namespace QCHManage
{
    partial class FrmRecordquery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecordquery));
            this.btnCX = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GBCX = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rBtpz = new System.Windows.Forms.RadioButton();
            this.rBtmz = new System.Windows.Forms.RadioButton();
            this.cmbListNo = new System.Windows.Forms.ComboBox();
            this.cmbFlag = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbReciveUnit = new System.Windows.Forms.ComboBox();
            this.cmbSupplyUnit = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbsby = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbGoodsName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.TimeStar = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSerch = new System.Windows.Forms.Button();
            this.cmbContractNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCarNumber = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DGVJL = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.GBCX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVJL)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCX
            // 
            this.btnCX.Location = new System.Drawing.Point(19, 12);
            this.btnCX.Name = "btnCX";
            this.btnCX.Size = new System.Drawing.Size(75, 23);
            this.btnCX.TabIndex = 0;
            this.btnCX.Text = "查询条件";
            this.btnCX.UseVisualStyleBackColor = true;
            this.btnCX.Click += new System.EventHandler(this.btnCX_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(355, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "打印磅单";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(100, 12);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(87, 23);
            this.btnClearAll.TabIndex = 7;
            this.btnClearAll.Text = "清空所有记录";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Visible = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(193, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.GBCX);
            this.groupBox1.Controls.Add(this.DGVJL);
            this.groupBox1.Location = new System.Drawing.Point(3, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 626);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询结果";
            // 
            // GBCX
            // 
            this.GBCX.Controls.Add(this.btnClear);
            this.GBCX.Controls.Add(this.rBtpz);
            this.GBCX.Controls.Add(this.rBtmz);
            this.GBCX.Controls.Add(this.cmbListNo);
            this.GBCX.Controls.Add(this.cmbFlag);
            this.GBCX.Controls.Add(this.label3);
            this.GBCX.Controls.Add(this.cmbReciveUnit);
            this.GBCX.Controls.Add(this.cmbSupplyUnit);
            this.GBCX.Controls.Add(this.label13);
            this.GBCX.Controls.Add(this.label14);
            this.GBCX.Controls.Add(this.cmbsby);
            this.GBCX.Controls.Add(this.label12);
            this.GBCX.Controls.Add(this.cmbGoodsName);
            this.GBCX.Controls.Add(this.label11);
            this.GBCX.Controls.Add(this.label10);
            this.GBCX.Controls.Add(this.label9);
            this.GBCX.Controls.Add(this.timeEnd);
            this.GBCX.Controls.Add(this.TimeStar);
            this.GBCX.Controls.Add(this.label8);
            this.GBCX.Controls.Add(this.txtDriver);
            this.GBCX.Controls.Add(this.label5);
            this.GBCX.Controls.Add(this.txtCarNo);
            this.GBCX.Controls.Add(this.label2);
            this.GBCX.Controls.Add(this.btnSerch);
            this.GBCX.Controls.Add(this.cmbContractNo);
            this.GBCX.Controls.Add(this.label1);
            this.GBCX.Controls.Add(this.cmbCarNumber);
            this.GBCX.Controls.Add(this.label4);
            this.GBCX.Location = new System.Drawing.Point(452, 60);
            this.GBCX.Name = "GBCX";
            this.GBCX.Size = new System.Drawing.Size(328, 340);
            this.GBCX.TabIndex = 17;
            this.GBCX.TabStop = false;
            this.GBCX.Text = "查询条件";
            this.GBCX.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(253, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(68, 23);
            this.btnClear.TabIndex = 76;
            this.btnClear.Text = "清除条件";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rBtpz
            // 
            this.rBtpz.AutoSize = true;
            this.rBtpz.Location = new System.Drawing.Point(152, 22);
            this.rBtpz.Name = "rBtpz";
            this.rBtpz.Size = new System.Drawing.Size(71, 16);
            this.rBtpz.TabIndex = 75;
            this.rBtpz.Text = "皮重时间";
            this.rBtpz.UseVisualStyleBackColor = true;
            // 
            // rBtmz
            // 
            this.rBtmz.AutoSize = true;
            this.rBtmz.Checked = true;
            this.rBtmz.Location = new System.Drawing.Point(51, 22);
            this.rBtmz.Name = "rBtmz";
            this.rBtmz.Size = new System.Drawing.Size(71, 16);
            this.rBtmz.TabIndex = 74;
            this.rBtmz.TabStop = true;
            this.rBtmz.Text = "毛重时间";
            this.rBtmz.UseVisualStyleBackColor = true;
            // 
            // cmbListNo
            // 
            this.cmbListNo.FormattingEnabled = true;
            this.cmbListNo.Location = new System.Drawing.Point(75, 72);
            this.cmbListNo.Name = "cmbListNo";
            this.cmbListNo.Size = new System.Drawing.Size(173, 20);
            this.cmbListNo.TabIndex = 73;
            this.cmbListNo.TextUpdate += new System.EventHandler(this.cmbListNo_TextUpdate);
            // 
            // cmbFlag
            // 
            this.cmbFlag.FormattingEnabled = true;
            this.cmbFlag.Items.AddRange(new object[] {
            "完成",
            "未完成"});
            this.cmbFlag.Location = new System.Drawing.Point(75, 254);
            this.cmbFlag.Name = "cmbFlag";
            this.cmbFlag.Size = new System.Drawing.Size(173, 20);
            this.cmbFlag.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 71;
            this.label3.Text = "完成标记";
            // 
            // cmbReciveUnit
            // 
            this.cmbReciveUnit.FormattingEnabled = true;
            this.cmbReciveUnit.Location = new System.Drawing.Point(75, 306);
            this.cmbReciveUnit.Name = "cmbReciveUnit";
            this.cmbReciveUnit.Size = new System.Drawing.Size(173, 20);
            this.cmbReciveUnit.TabIndex = 69;
            this.cmbReciveUnit.TextChanged += new System.EventHandler(this.cmbReciveUnit_TextChanged);
            // 
            // cmbSupplyUnit
            // 
            this.cmbSupplyUnit.FormattingEnabled = true;
            this.cmbSupplyUnit.Location = new System.Drawing.Point(75, 280);
            this.cmbSupplyUnit.Name = "cmbSupplyUnit";
            this.cmbSupplyUnit.Size = new System.Drawing.Size(173, 20);
            this.cmbSupplyUnit.TabIndex = 68;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 67;
            this.label13.Text = "收货单位";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 66;
            this.label14.Text = "供货单位";
            // 
            // cmbsby
            // 
            this.cmbsby.FormattingEnabled = true;
            this.cmbsby.Location = new System.Drawing.Point(75, 230);
            this.cmbsby.Name = "cmbsby";
            this.cmbsby.Size = new System.Drawing.Size(173, 20);
            this.cmbsby.TabIndex = 65;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "司磅员";
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.FormattingEnabled = true;
            this.cmbGoodsName.Location = new System.Drawing.Point(75, 178);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(173, 20);
            this.cmbGoodsName.TabIndex = 63;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 62;
            this.label11.Text = "品名";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 60;
            this.label10.Text = "磅单号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 59;
            this.label9.Text = "至";
            // 
            // timeEnd
            // 
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeEnd.Location = new System.Drawing.Point(160, 45);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Size = new System.Drawing.Size(88, 21);
            this.timeEnd.TabIndex = 58;
            // 
            // TimeStar
            // 
            this.TimeStar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeStar.Location = new System.Drawing.Point(51, 45);
            this.TimeStar.Name = "TimeStar";
            this.TimeStar.Size = new System.Drawing.Size(88, 21);
            this.TimeStar.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "时间";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(75, 151);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(173, 21);
            this.txtDriver.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "驾驶员";
            // 
            // txtCarNo
            // 
            this.txtCarNo.Location = new System.Drawing.Point(75, 124);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(173, 21);
            this.txtCarNo.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "卡号";
            // 
            // btnSerch
            // 
            this.btnSerch.Location = new System.Drawing.Point(254, 45);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(60, 23);
            this.btnSerch.TabIndex = 47;
            this.btnSerch.Text = "查询";
            this.btnSerch.UseVisualStyleBackColor = true;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // cmbContractNo
            // 
            this.cmbContractNo.FormattingEnabled = true;
            this.cmbContractNo.Location = new System.Drawing.Point(75, 204);
            this.cmbContractNo.Name = "cmbContractNo";
            this.cmbContractNo.Size = new System.Drawing.Size(173, 20);
            this.cmbContractNo.TabIndex = 38;
            this.cmbContractNo.TextUpdate += new System.EventHandler(this.cmbContractNo_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "合同编号";
            // 
            // cmbCarNumber
            // 
            this.cmbCarNumber.FormattingEnabled = true;
            this.cmbCarNumber.Location = new System.Drawing.Point(75, 98);
            this.cmbCarNumber.Name = "cmbCarNumber";
            this.cmbCarNumber.Size = new System.Drawing.Size(173, 20);
            this.cmbCarNumber.TabIndex = 44;
            this.cmbCarNumber.TextUpdate += new System.EventHandler(this.cmbCarNumber_TextUpdate);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "车牌号";
            // 
            // DGVJL
            // 
            this.DGVJL.AllowUserToAddRows = false;
            this.DGVJL.AllowUserToDeleteRows = false;
            this.DGVJL.AllowUserToResizeRows = false;
            this.DGVJL.BackgroundColor = System.Drawing.Color.White;
            this.DGVJL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVJL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column15,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column16,
            this.Column13,
            this.Column14});
            this.DGVJL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVJL.Location = new System.Drawing.Point(3, 17);
            this.DGVJL.Name = "DGVJL";
            this.DGVJL.RowHeadersVisible = false;
            this.DGVJL.RowTemplate.Height = 23;
            this.DGVJL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVJL.Size = new System.Drawing.Size(837, 606);
            this.DGVJL.TabIndex = 0;
            this.DGVJL.Click += new System.EventHandler(this.DGVJL_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.pic4);
            this.panel1.Controls.Add(this.pic3);
            this.panel1.Controls.Add(this.pic2);
            this.panel1.Controls.Add(this.pic1);
            this.panel1.Location = new System.Drawing.Point(850, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 629);
            this.panel1.TabIndex = 10;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(144, 603);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(37, 603);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "上一页";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // pic4
            // 
            this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic4.Location = new System.Drawing.Point(3, 453);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(254, 144);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic4.TabIndex = 3;
            this.pic4.TabStop = false;
            // 
            // pic3
            // 
            this.pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic3.Location = new System.Drawing.Point(3, 303);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(254, 144);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic3.TabIndex = 2;
            this.pic3.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic2.Location = new System.Drawing.Point(3, 153);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(254, 144);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 1;
            this.pic2.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic1.Location = new System.Drawing.Point(3, 3);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(254, 144);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClearAll);
            this.panel2.Controls.Add(this.btnCX);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 50);
            this.panel2.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "cz_dh";
            this.Column1.HeaderText = "磅单号";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cz_ch";
            this.Column2.HeaderText = "车号";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cz_kh";
            this.Column3.HeaderText = "卡号";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "cz_jsy";
            this.Column4.HeaderText = "驾驶员";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "gn_name";
            this.Column5.HeaderText = "品名";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "cz_mz";
            this.Column6.HeaderText = "毛重";
            this.Column6.Name = "Column6";
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "cz_pz";
            this.Column15.HeaderText = "皮重";
            this.Column15.Name = "Column15";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "cz_jz";
            this.Column7.HeaderText = "净重";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "cn_code";
            this.Column8.HeaderText = "合同编号";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "cz_sby";
            this.Column9.HeaderText = "司磅员";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "cz_cpzsj";
            this.Column10.HeaderText = "皮重时间";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "cz_cmzsj";
            this.Column11.HeaderText = "毛重时间";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "cz_wcbj";
            this.Column12.HeaderText = "完成标记";
            this.Column12.Name = "Column12";
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column16.DataPropertyName = "fw_flow";
            this.Column16.HeaderText = "流程进度";
            this.Column16.Name = "Column16";
            this.Column16.Width = 200;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "cz_gwdw";
            this.Column13.HeaderText = "供货单位";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "ru_shdw";
            this.Column14.HeaderText = "收货单位";
            this.Column14.Name = "Column14";
            // 
            // FrmRecordquery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 682);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRecordquery";
            this.Text = "记录查询更改";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRecordquery_Load);
            this.groupBox1.ResumeLayout(false);
            this.GBCX.ResumeLayout(false);
            this.GBCX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVJL)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCX;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.GroupBox GBCX;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCarNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.ComboBox cmbContractNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCarNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker TimeStar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbGoodsName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.ComboBox cmbsby;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbReciveUnit;
        private System.Windows.Forms.ComboBox cmbSupplyUnit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView DGVJL;
        private System.Windows.Forms.ComboBox cmbFlag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbListNo;
        private System.Windows.Forms.RadioButton rBtpz;
        private System.Windows.Forms.RadioButton rBtmz;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}