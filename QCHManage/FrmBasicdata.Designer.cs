namespace QCHManage
{
    partial class FrmBasicdata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBasicdata));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnCancleGH = new System.Windows.Forms.Button();
            this.BtnDelGH = new System.Windows.Forms.Button();
            this.BtnAddGH = new System.Windows.Forms.Button();
            this.txtGHDW = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.DGVGH = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnCancleSH = new System.Windows.Forms.Button();
            this.BtnDelSH = new System.Windows.Forms.Button();
            this.BtnAddSH = new System.Windows.Forms.Button();
            this.txtSHDW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVSH = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnCanclePM = new System.Windows.Forms.Button();
            this.BtnDelPM = new System.Windows.Forms.Button();
            this.BtnAddPM = new System.Windows.Forms.Button();
            this.txtPM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DGVPM = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGH)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSH)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPM)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(418, 307);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnCancleGH);
            this.tabPage1.Controls.Add(this.BtnDelGH);
            this.tabPage1.Controls.Add(this.BtnAddGH);
            this.tabPage1.Controls.Add(this.txtGHDW);
            this.tabPage1.Controls.Add(this.Label7);
            this.tabPage1.Controls.Add(this.DGVGH);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(410, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "供货单位";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnCancleGH
            // 
            this.BtnCancleGH.Location = new System.Drawing.Point(296, 64);
            this.BtnCancleGH.Name = "BtnCancleGH";
            this.BtnCancleGH.Size = new System.Drawing.Size(75, 23);
            this.BtnCancleGH.TabIndex = 101;
            this.BtnCancleGH.Text = "取消";
            this.BtnCancleGH.UseVisualStyleBackColor = true;
            this.BtnCancleGH.Click += new System.EventHandler(this.BtnCancleGH_Click);
            // 
            // BtnDelGH
            // 
            this.BtnDelGH.Location = new System.Drawing.Point(168, 64);
            this.BtnDelGH.Name = "BtnDelGH";
            this.BtnDelGH.Size = new System.Drawing.Size(75, 23);
            this.BtnDelGH.TabIndex = 100;
            this.BtnDelGH.Text = "删除";
            this.BtnDelGH.UseVisualStyleBackColor = true;
            this.BtnDelGH.Click += new System.EventHandler(this.BtnDelGH_Click);
            // 
            // BtnAddGH
            // 
            this.BtnAddGH.Location = new System.Drawing.Point(40, 64);
            this.BtnAddGH.Name = "BtnAddGH";
            this.BtnAddGH.Size = new System.Drawing.Size(75, 23);
            this.BtnAddGH.TabIndex = 99;
            this.BtnAddGH.Text = "添加";
            this.BtnAddGH.UseVisualStyleBackColor = true;
            this.BtnAddGH.Click += new System.EventHandler(this.BtnAddGH_Click);
            // 
            // txtGHDW
            // 
            this.txtGHDW.Location = new System.Drawing.Point(80, 36);
            this.txtGHDW.Name = "txtGHDW";
            this.txtGHDW.Size = new System.Drawing.Size(306, 21);
            this.txtGHDW.TabIndex = 98;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(24, 41);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(53, 12);
            this.Label7.TabIndex = 97;
            this.Label7.Text = "供货单位";
            // 
            // DGVGH
            // 
            this.DGVGH.AllowUserToAddRows = false;
            this.DGVGH.AllowUserToDeleteRows = false;
            this.DGVGH.AllowUserToResizeColumns = false;
            this.DGVGH.AllowUserToResizeRows = false;
            this.DGVGH.BackgroundColor = System.Drawing.Color.White;
            this.DGVGH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DGVGH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVGH.Location = new System.Drawing.Point(3, 95);
            this.DGVGH.Name = "DGVGH";
            this.DGVGH.RowHeadersVisible = false;
            this.DGVGH.RowTemplate.Height = 23;
            this.DGVGH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVGH.Size = new System.Drawing.Size(404, 183);
            this.DGVGH.TabIndex = 96;
            this.DGVGH.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DGVGH_RowPostPaint);
            this.DGVGH.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGVGH_MouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnCancleSH);
            this.tabPage2.Controls.Add(this.BtnDelSH);
            this.tabPage2.Controls.Add(this.BtnAddSH);
            this.tabPage2.Controls.Add(this.txtSHDW);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DGVSH);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(410, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "收货单位";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnCancleSH
            // 
            this.BtnCancleSH.Location = new System.Drawing.Point(296, 64);
            this.BtnCancleSH.Name = "BtnCancleSH";
            this.BtnCancleSH.Size = new System.Drawing.Size(75, 23);
            this.BtnCancleSH.TabIndex = 101;
            this.BtnCancleSH.Text = "取消";
            this.BtnCancleSH.UseVisualStyleBackColor = true;
            this.BtnCancleSH.Click += new System.EventHandler(this.BtnCancleSH_Click);
            // 
            // BtnDelSH
            // 
            this.BtnDelSH.Location = new System.Drawing.Point(168, 64);
            this.BtnDelSH.Name = "BtnDelSH";
            this.BtnDelSH.Size = new System.Drawing.Size(75, 23);
            this.BtnDelSH.TabIndex = 100;
            this.BtnDelSH.Text = "删除";
            this.BtnDelSH.UseVisualStyleBackColor = true;
            this.BtnDelSH.Click += new System.EventHandler(this.BtnDelSH_Click);
            // 
            // BtnAddSH
            // 
            this.BtnAddSH.Location = new System.Drawing.Point(40, 64);
            this.BtnAddSH.Name = "BtnAddSH";
            this.BtnAddSH.Size = new System.Drawing.Size(75, 23);
            this.BtnAddSH.TabIndex = 99;
            this.BtnAddSH.Text = "添加";
            this.BtnAddSH.UseVisualStyleBackColor = true;
            this.BtnAddSH.Click += new System.EventHandler(this.BtnAddSH_Click);
            // 
            // txtSHDW
            // 
            this.txtSHDW.Location = new System.Drawing.Point(80, 36);
            this.txtSHDW.Name = "txtSHDW";
            this.txtSHDW.Size = new System.Drawing.Size(306, 21);
            this.txtSHDW.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 97;
            this.label3.Text = "收货单位";
            // 
            // DGVSH
            // 
            this.DGVSH.AllowUserToAddRows = false;
            this.DGVSH.AllowUserToDeleteRows = false;
            this.DGVSH.AllowUserToResizeColumns = false;
            this.DGVSH.AllowUserToResizeRows = false;
            this.DGVSH.BackgroundColor = System.Drawing.Color.White;
            this.DGVSH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column4});
            this.DGVSH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVSH.Location = new System.Drawing.Point(3, 95);
            this.DGVSH.Name = "DGVSH";
            this.DGVSH.RowHeadersVisible = false;
            this.DGVSH.RowTemplate.Height = 23;
            this.DGVSH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSH.Size = new System.Drawing.Size(404, 183);
            this.DGVSH.TabIndex = 96;
            this.DGVSH.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DGVSH_RowPostPaint);
            this.DGVSH.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGVSH_MouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnCanclePM);
            this.tabPage3.Controls.Add(this.BtnDelPM);
            this.tabPage3.Controls.Add(this.BtnAddPM);
            this.tabPage3.Controls.Add(this.txtPM);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.DGVPM);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(410, 281);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "品名";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnCanclePM
            // 
            this.BtnCanclePM.Location = new System.Drawing.Point(296, 64);
            this.BtnCanclePM.Name = "BtnCanclePM";
            this.BtnCanclePM.Size = new System.Drawing.Size(75, 23);
            this.BtnCanclePM.TabIndex = 101;
            this.BtnCanclePM.Text = "取消";
            this.BtnCanclePM.UseVisualStyleBackColor = true;
            this.BtnCanclePM.Click += new System.EventHandler(this.BtnCanclePM_Click);
            // 
            // BtnDelPM
            // 
            this.BtnDelPM.Location = new System.Drawing.Point(168, 64);
            this.BtnDelPM.Name = "BtnDelPM";
            this.BtnDelPM.Size = new System.Drawing.Size(75, 23);
            this.BtnDelPM.TabIndex = 100;
            this.BtnDelPM.Text = "删除";
            this.BtnDelPM.UseVisualStyleBackColor = true;
            this.BtnDelPM.Click += new System.EventHandler(this.BtnDelPM_Click);
            // 
            // BtnAddPM
            // 
            this.BtnAddPM.Location = new System.Drawing.Point(40, 64);
            this.BtnAddPM.Name = "BtnAddPM";
            this.BtnAddPM.Size = new System.Drawing.Size(75, 23);
            this.BtnAddPM.TabIndex = 99;
            this.BtnAddPM.Text = "添加";
            this.BtnAddPM.UseVisualStyleBackColor = true;
            this.BtnAddPM.Click += new System.EventHandler(this.BtnAddPM_Click);
            // 
            // txtPM
            // 
            this.txtPM.Location = new System.Drawing.Point(59, 36);
            this.txtPM.Name = "txtPM";
            this.txtPM.Size = new System.Drawing.Size(327, 21);
            this.txtPM.TabIndex = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 97;
            this.label5.Text = "品名";
            // 
            // DGVPM
            // 
            this.DGVPM.AllowUserToAddRows = false;
            this.DGVPM.AllowUserToDeleteRows = false;
            this.DGVPM.AllowUserToResizeColumns = false;
            this.DGVPM.AllowUserToResizeRows = false;
            this.DGVPM.BackgroundColor = System.Drawing.Color.White;
            this.DGVPM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column5});
            this.DGVPM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVPM.Location = new System.Drawing.Point(3, 95);
            this.DGVPM.Name = "DGVPM";
            this.DGVPM.RowHeadersVisible = false;
            this.DGVPM.RowTemplate.Height = 23;
            this.DGVPM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPM.Size = new System.Drawing.Size(404, 183);
            this.DGVPM.TabIndex = 96;
            this.DGVPM.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DGVPM_RowPostPaint);
            this.DGVPM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGVPM_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "su_unit";
            this.Column2.HeaderText = "供货单位";
            this.Column2.Name = "Column2";
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "su_code";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ru_unit";
            this.dataGridViewTextBoxColumn2.HeaderText = "收货单位";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ru_code";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "序号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "gn_name";
            this.dataGridViewTextBoxColumn4.HeaderText = "品名";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "gn_code";
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // FrmBasicdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 307);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBasicdata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基础数据维护";
            this.Load += new System.EventHandler(this.FrmBasicdata_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGH)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSH)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.Button BtnCancleGH;
        internal System.Windows.Forms.Button BtnDelGH;
        internal System.Windows.Forms.Button BtnAddGH;
        internal System.Windows.Forms.TextBox txtGHDW;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.DataGridView DGVGH;
        internal System.Windows.Forms.Button BtnCancleSH;
        internal System.Windows.Forms.Button BtnDelSH;
        internal System.Windows.Forms.Button BtnAddSH;
        internal System.Windows.Forms.TextBox txtSHDW;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGVSH;
        internal System.Windows.Forms.Button BtnCanclePM;
        internal System.Windows.Forms.Button BtnDelPM;
        internal System.Windows.Forms.Button BtnAddPM;
        internal System.Windows.Forms.TextBox txtPM;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DGVPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;

    }
}