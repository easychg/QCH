namespace QCHManage
{
    partial class FrmNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNew));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.CmbName = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtMima = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.BtnOK);
            this.GroupBox1.Controls.Add(this.CmbName);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.TxtMima);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupBox1.Location = new System.Drawing.Point(3, 190);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(443, 78);
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "用户登陆";
            // 
            // BtnOK
            // 
            this.BtnOK.BackColor = System.Drawing.Color.OrangeRed;
            this.BtnOK.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOK.ForeColor = System.Drawing.Color.White;
            this.BtnOK.Location = new System.Drawing.Point(363, 30);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(67, 35);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "登录";
            this.BtnOK.UseVisualStyleBackColor = false;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // CmbName
            // 
            this.CmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbName.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbName.FormattingEnabled = true;
            this.CmbName.Location = new System.Drawing.Point(90, 37);
            this.CmbName.Name = "CmbName";
            this.CmbName.Size = new System.Drawing.Size(90, 24);
            this.CmbName.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label2.Location = new System.Drawing.Point(186, 41);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "密  码：";
            // 
            // TxtMima
            // 
            this.TxtMima.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtMima.Location = new System.Drawing.Point(251, 36);
            this.TxtMima.Name = "TxtMima";
            this.TxtMima.PasswordChar = '*';
            this.TxtMima.Size = new System.Drawing.Size(90, 26);
            this.TxtMima.TabIndex = 2;
            this.TxtMima.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMima_KeyDown);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Location = new System.Drawing.Point(20, 41);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "用户名：";
            // 
            // FrmNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(449, 299);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用徐州圣能科技有限公司产品";
            this.Load += new System.EventHandler(this.FrmNew_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.ComboBox CmbName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtMima;
        internal System.Windows.Forms.Label Label1;
    }
}