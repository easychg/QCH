namespace QCHManage
{
    partial class FrmTruckInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTruckInfo));
            this.DGVTruck = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCX = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnXG = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSerch = new System.Windows.Forms.Button();
            this.cmbHomeUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbContractNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GBCX = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCarNumber = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTruck)).BeginInit();
            this.panel1.SuspendLayout();
            this.GBCX.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVTruck
            // 
            this.DGVTruck.AllowUserToAddRows = false;
            this.DGVTruck.AllowUserToDeleteRows = false;
            this.DGVTruck.AllowUserToResizeRows = false;
            this.DGVTruck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTruck.BackgroundColor = System.Drawing.Color.White;
            this.DGVTruck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column11,
            this.Column10,
            this.Column3});
            this.DGVTruck.Location = new System.Drawing.Point(0, 41);
            this.DGVTruck.Name = "DGVTruck";
            this.DGVTruck.ReadOnly = true;
            this.DGVTruck.RowHeadersVisible = false;
            this.DGVTruck.RowTemplate.Height = 23;
            this.DGVTruck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTruck.Size = new System.Drawing.Size(1135, 548);
            this.DGVTruck.TabIndex = 0;
            this.DGVTruck.SelectionChanged += new System.EventHandler(this.DGVTruck_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "cm_kcode";
            this.Column1.HeaderText = "卡号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cm_carnumber";
            this.Column2.HeaderText = "车牌号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "cm_jsy";
            this.Column4.HeaderText = "驾驶员";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "cn_code";
            this.Column7.HeaderText = "合同编号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "cm_bzweight";
            this.Column8.HeaderText = "标准载重";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "cm_homeunit";
            this.Column9.HeaderText = "所属单位";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 200;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "flow";
            this.Column11.HeaderText = "流程";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "wc";
            this.Column10.HeaderText = "完成情况";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cm_id";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // btnCX
            // 
            this.btnCX.Location = new System.Drawing.Point(8, 6);
            this.btnCX.Name = "btnCX";
            this.btnCX.Size = new System.Drawing.Size(90, 23);
            this.btnCX.TabIndex = 9;
            this.btnCX.Text = "选择查询条件";
            this.btnCX.UseVisualStyleBackColor = true;
            this.btnCX.Click += new System.EventHandler(this.btnCX_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(104, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnXG
            // 
            this.btnXG.Location = new System.Drawing.Point(185, 6);
            this.btnXG.Name = "btnXG";
            this.btnXG.Size = new System.Drawing.Size(75, 23);
            this.btnXG.TabIndex = 11;
            this.btnXG.Text = "修改";
            this.btnXG.UseVisualStyleBackColor = true;
            this.btnXG.Click += new System.EventHandler(this.btnXG_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(929, 6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(287, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "刷新";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnCX);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnXG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 35);
            this.panel1.TabIndex = 14;
            // 
            // btnSerch
            // 
            this.btnSerch.Location = new System.Drawing.Point(113, 229);
            this.btnSerch.Name = "btnSerch";
            this.btnSerch.Size = new System.Drawing.Size(59, 23);
            this.btnSerch.TabIndex = 47;
            this.btnSerch.Text = "查询";
            this.btnSerch.UseVisualStyleBackColor = true;
            this.btnSerch.Click += new System.EventHandler(this.btnSerch_Click);
            // 
            // cmbHomeUnit
            // 
            this.cmbHomeUnit.FormattingEnabled = true;
            this.cmbHomeUnit.Location = new System.Drawing.Point(72, 155);
            this.cmbHomeUnit.Name = "cmbHomeUnit";
            this.cmbHomeUnit.Size = new System.Drawing.Size(177, 20);
            this.cmbHomeUnit.TabIndex = 45;
            this.cmbHomeUnit.TextUpdate += new System.EventHandler(this.cmbHomeUnit_TextUpdate);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "所属单位";
            // 
            // cmbContractNo
            // 
            this.cmbContractNo.FormattingEnabled = true;
            this.cmbContractNo.Location = new System.Drawing.Point(72, 125);
            this.cmbContractNo.Name = "cmbContractNo";
            this.cmbContractNo.Size = new System.Drawing.Size(177, 20);
            this.cmbContractNo.TabIndex = 38;
            this.cmbContractNo.TextUpdate += new System.EventHandler(this.cmbContractNo_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "合同编号";
            // 
            // GBCX
            // 
            this.GBCX.Controls.Add(this.button1);
            this.GBCX.Controls.Add(this.comboBox1);
            this.GBCX.Controls.Add(this.label3);
            this.GBCX.Controls.Add(this.button2);
            this.GBCX.Controls.Add(this.txtDriver);
            this.GBCX.Controls.Add(this.label5);
            this.GBCX.Controls.Add(this.txtCarNo);
            this.GBCX.Controls.Add(this.label2);
            this.GBCX.Controls.Add(this.btnSerch);
            this.GBCX.Controls.Add(this.cmbContractNo);
            this.GBCX.Controls.Add(this.label1);
            this.GBCX.Controls.Add(this.cmbHomeUnit);
            this.GBCX.Controls.Add(this.label7);
            this.GBCX.Controls.Add(this.cmbCarNumber);
            this.GBCX.Controls.Add(this.label4);
            this.GBCX.Location = new System.Drawing.Point(325, 92);
            this.GBCX.Name = "GBCX";
            this.GBCX.Size = new System.Drawing.Size(264, 267);
            this.GBCX.TabIndex = 16;
            this.GBCX.TabStop = false;
            this.GBCX.Text = "查询条件";
            this.GBCX.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "完成",
            "未完成"});
            this.comboBox1.Location = new System.Drawing.Point(72, 188);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 20);
            this.comboBox1.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "完成情况";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "清除条件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(72, 91);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(177, 21);
            this.txtDriver.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "驾驶员";
            // 
            // txtCarNo
            // 
            this.txtCarNo.Location = new System.Drawing.Point(72, 24);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(177, 21);
            this.txtCarNo.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "卡号";
            // 
            // cmbCarNumber
            // 
            this.cmbCarNumber.FormattingEnabled = true;
            this.cmbCarNumber.Location = new System.Drawing.Point(72, 58);
            this.cmbCarNumber.Name = "cmbCarNumber";
            this.cmbCarNumber.Size = new System.Drawing.Size(177, 20);
            this.cmbCarNumber.TabIndex = 44;
            this.cmbCarNumber.TextUpdate += new System.EventHandler(this.cmbCarNumber_TextUpdate);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "车牌号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(436, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 19);
            this.label6.TabIndex = 14;
            // 
            // FrmTruckInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 589);
            this.Controls.Add(this.GBCX);
            this.Controls.Add(this.DGVTruck);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmTruckInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车辆信息管理     ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTruckInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTruck)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBCX.ResumeLayout(false);
            this.GBCX.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVTruck;
        private System.Windows.Forms.Button btnCX;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnXG;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSerch;
        private System.Windows.Forms.ComboBox cmbHomeUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbContractNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GBCX;
        private System.Windows.Forms.TextBox txtCarNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbCarNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label6;
    }
}