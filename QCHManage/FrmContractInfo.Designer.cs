namespace QCHManage
{
    partial class FrmContractInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContractInfo));
            this.DGVContract = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.剩余量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStart = new System.Windows.Forms.DateTimePicker();
            this.TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnCX = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnXG = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbReciveUnit = new System.Windows.Forms.ComboBox();
            this.cmbSupplyUnit = new System.Windows.Forms.ComboBox();
            this.cmbGoodsName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbContractNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxCX = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVContract)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxCX.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVContract
            // 
            this.DGVContract.AllowUserToAddRows = false;
            this.DGVContract.AllowUserToDeleteRows = false;
            this.DGVContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVContract.BackgroundColor = System.Drawing.Color.White;
            this.DGVContract.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.剩余量});
            this.DGVContract.Location = new System.Drawing.Point(0, 43);
            this.DGVContract.Name = "DGVContract";
            this.DGVContract.ReadOnly = true;
            this.DGVContract.RowHeadersVisible = false;
            this.DGVContract.RowTemplate.Height = 23;
            this.DGVContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVContract.Size = new System.Drawing.Size(1103, 546);
            this.DGVContract.TabIndex = 0;
            this.DGVContract.SelectionChanged += new System.EventHandler(this.DGVContract_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "cn_code";
            this.Column1.HeaderText = "合同编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cn_time";
            this.Column2.HeaderText = "时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cn_news";
            this.Column3.HeaderText = "合同信息";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "cn_hwmc";
            this.Column4.HeaderText = "货物名称";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "su_unit";
            this.Column6.HeaderText = "供货单位";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "ru_unit";
            this.Column7.HeaderText = "收货单位";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "cn_htzl";
            this.Column8.HeaderText = "合同总量";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "cn_yysl";
            this.Column9.HeaderText = "已运送量";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // 剩余量
            // 
            this.剩余量.DataPropertyName = "syl";
            this.剩余量.HeaderText = "剩余量";
            this.剩余量.Name = "剩余量";
            this.剩余量.ReadOnly = true;
            // 
            // TimeStart
            // 
            this.TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeStart.Location = new System.Drawing.Point(39, 27);
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.Size = new System.Drawing.Size(104, 21);
            this.TimeStart.TabIndex = 1;
            // 
            // TimeEnd
            // 
            this.TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeEnd.Location = new System.Drawing.Point(164, 27);
            this.TimeEnd.Name = "TimeEnd";
            this.TimeEnd.Size = new System.Drawing.Size(104, 21);
            this.TimeEnd.TabIndex = 2;
            // 
            // btnCX
            // 
            this.btnCX.Location = new System.Drawing.Point(4, 7);
            this.btnCX.Name = "btnCX";
            this.btnCX.Size = new System.Drawing.Size(90, 23);
            this.btnCX.TabIndex = 4;
            this.btnCX.Text = "选择查询条件";
            this.btnCX.UseVisualStyleBackColor = true;
            this.btnCX.Click += new System.EventHandler(this.btnCX_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(100, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnXG
            // 
            this.btnXG.Location = new System.Drawing.Point(181, 7);
            this.btnXG.Name = "btnXG";
            this.btnXG.Size = new System.Drawing.Size(75, 23);
            this.btnXG.TabIndex = 6;
            this.btnXG.Text = "修改";
            this.btnXG.UseVisualStyleBackColor = true;
            this.btnXG.Click += new System.EventHandler(this.btnXG_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(965, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(343, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbReciveUnit
            // 
            this.cmbReciveUnit.FormattingEnabled = true;
            this.cmbReciveUnit.Location = new System.Drawing.Point(68, 141);
            this.cmbReciveUnit.Name = "cmbReciveUnit";
            this.cmbReciveUnit.Size = new System.Drawing.Size(200, 20);
            this.cmbReciveUnit.TabIndex = 46;
            this.cmbReciveUnit.TextUpdate += new System.EventHandler(this.cmbReciveUnit_TextUpdate);
            // 
            // cmbSupplyUnit
            // 
            this.cmbSupplyUnit.FormattingEnabled = true;
            this.cmbSupplyUnit.Location = new System.Drawing.Point(68, 115);
            this.cmbSupplyUnit.Name = "cmbSupplyUnit";
            this.cmbSupplyUnit.Size = new System.Drawing.Size(200, 20);
            this.cmbSupplyUnit.TabIndex = 45;
            this.cmbSupplyUnit.TextUpdate += new System.EventHandler(this.cmbSupplyUnit_TextUpdate);
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.FormattingEnabled = true;
            this.cmbGoodsName.Location = new System.Drawing.Point(68, 89);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(200, 20);
            this.cmbGoodsName.TabIndex = 44;
            this.cmbGoodsName.TextUpdate += new System.EventHandler(this.cmbGoodsName_TextUpdate);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "品名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "收货单位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "供货单位";
            // 
            // cmbContractNo
            // 
            this.cmbContractNo.FormattingEnabled = true;
            this.cmbContractNo.Location = new System.Drawing.Point(68, 63);
            this.cmbContractNo.Name = "cmbContractNo";
            this.cmbContractNo.Size = new System.Drawing.Size(200, 20);
            this.cmbContractNo.TabIndex = 38;
            this.cmbContractNo.TextUpdate += new System.EventHandler(this.cmbContractNo_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "合同编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "至";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCX);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnXG);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 37);
            this.panel1.TabIndex = 10;
            // 
            // groupBoxCX
            // 
            this.groupBoxCX.Controls.Add(this.button2);
            this.groupBoxCX.Controls.Add(this.button1);
            this.groupBoxCX.Controls.Add(this.label5);
            this.groupBoxCX.Controls.Add(this.cmbReciveUnit);
            this.groupBoxCX.Controls.Add(this.label8);
            this.groupBoxCX.Controls.Add(this.TimeStart);
            this.groupBoxCX.Controls.Add(this.cmbSupplyUnit);
            this.groupBoxCX.Controls.Add(this.TimeEnd);
            this.groupBoxCX.Controls.Add(this.label7);
            this.groupBoxCX.Controls.Add(this.cmbGoodsName);
            this.groupBoxCX.Controls.Add(this.label4);
            this.groupBoxCX.Controls.Add(this.label3);
            this.groupBoxCX.Controls.Add(this.cmbContractNo);
            this.groupBoxCX.Controls.Add(this.label1);
            this.groupBoxCX.Location = new System.Drawing.Point(374, 86);
            this.groupBoxCX.Name = "groupBoxCX";
            this.groupBoxCX.Size = new System.Drawing.Size(354, 172);
            this.groupBoxCX.TabIndex = 11;
            this.groupBoxCX.TabStop = false;
            this.groupBoxCX.Text = "查新条件";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "清除条件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "时间";
            // 
            // FrmContractInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 589);
            this.Controls.Add(this.groupBoxCX);
            this.Controls.Add(this.DGVContract);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContractInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "合同信息";
            this.Load += new System.EventHandler(this.FrmContractInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVContract)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxCX.ResumeLayout(false);
            this.groupBoxCX.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVContract;
        private System.Windows.Forms.DateTimePicker TimeStart;
        private System.Windows.Forms.DateTimePicker TimeEnd;
        private System.Windows.Forms.Button btnCX;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnXG;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbContractNo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbReciveUnit;
        private System.Windows.Forms.ComboBox cmbSupplyUnit;
        private System.Windows.Forms.ComboBox cmbGoodsName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxCX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn 剩余量;
    }
}