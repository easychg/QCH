namespace QCHManage
{
    partial class FrmContractAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContractAdd));
            this.txtContractNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSumWeight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSYWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbReciveUnit = new System.Windows.Forms.ComboBox();
            this.cmbSupplyUnit = new System.Windows.Forms.ComboBox();
            this.cmbGoodsName = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtContractNo
            // 
            this.txtContractNo.Location = new System.Drawing.Point(75, 20);
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.Size = new System.Drawing.Size(168, 21);
            this.txtContractNo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "合同编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "品名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "供货单位";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "收货单位";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "t";
            // 
            // txtSumWeight
            // 
            this.txtSumWeight.Location = new System.Drawing.Point(75, 143);
            this.txtSumWeight.Name = "txtSumWeight";
            this.txtSumWeight.Size = new System.Drawing.Size(147, 21);
            this.txtSumWeight.TabIndex = 28;
            this.txtSumWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSumWeight.TextChanged += new System.EventHandler(this.txtSumWeight_TextChanged);
            this.txtSumWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSumWeight_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "合同总量";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(223, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "t";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(75, 173);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(147, 21);
            this.txtWeight.TabIndex = 31;
            this.txtWeight.Text = "0";
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "已运送量";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(285, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "保存";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(285, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "修改";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(285, 98);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 23);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSYWeight);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbReciveUnit);
            this.groupBox1.Controls.Add(this.cmbSupplyUnit);
            this.groupBox1.Controls.Add(this.cmbGoodsName);
            this.groupBox1.Controls.Add(this.txtContractNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtWeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtSumWeight);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 257);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "合同信息";
            // 
            // dtTime
            // 
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTime.Location = new System.Drawing.Point(96, 272);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(110, 21);
            this.dtTime.TabIndex = 44;
            this.dtTime.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "时间";
            this.label3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 43;
            this.label5.Text = "t";
            // 
            // txtSYWeight
            // 
            this.txtSYWeight.Location = new System.Drawing.Point(75, 203);
            this.txtSYWeight.Name = "txtSYWeight";
            this.txtSYWeight.ReadOnly = true;
            this.txtSYWeight.Size = new System.Drawing.Size(147, 21);
            this.txtSYWeight.TabIndex = 42;
            this.txtSYWeight.Text = "0";
            this.txtSYWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "剩余量";
            // 
            // cmbReciveUnit
            // 
            this.cmbReciveUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReciveUnit.FormattingEnabled = true;
            this.cmbReciveUnit.Location = new System.Drawing.Point(75, 113);
            this.cmbReciveUnit.Name = "cmbReciveUnit";
            this.cmbReciveUnit.Size = new System.Drawing.Size(168, 20);
            this.cmbReciveUnit.TabIndex = 40;
            this.cmbReciveUnit.TextUpdate += new System.EventHandler(this.cmbReciveUnit_TextUpdate);
            // 
            // cmbSupplyUnit
            // 
            this.cmbSupplyUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplyUnit.FormattingEnabled = true;
            this.cmbSupplyUnit.Location = new System.Drawing.Point(75, 83);
            this.cmbSupplyUnit.Name = "cmbSupplyUnit";
            this.cmbSupplyUnit.Size = new System.Drawing.Size(168, 20);
            this.cmbSupplyUnit.TabIndex = 39;
            this.cmbSupplyUnit.TextUpdate += new System.EventHandler(this.cmbSupplyUnit_TextUpdate);
            // 
            // cmbGoodsName
            // 
            this.cmbGoodsName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGoodsName.FormattingEnabled = true;
            this.cmbGoodsName.Location = new System.Drawing.Point(75, 52);
            this.cmbGoodsName.Name = "cmbGoodsName";
            this.cmbGoodsName.Size = new System.Drawing.Size(168, 20);
            this.cmbGoodsName.TabIndex = 37;
            this.cmbGoodsName.TextUpdate += new System.EventHandler(this.cmbGoodsName_TextUpdate);
            // 
            // FrmContractAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 257);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContractAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "合同信息录入修改";
            this.Load += new System.EventHandler(this.FrmContractAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtContractNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSumWeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGoodsName;
        private System.Windows.Forms.ComboBox cmbReciveUnit;
        private System.Windows.Forms.ComboBox cmbSupplyUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSYWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.Label label3;
    }
}