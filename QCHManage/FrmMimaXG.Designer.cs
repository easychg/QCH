namespace QCHManage
{
    partial class FrmMimaXG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMimaXG));
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.LblInfo = new System.Windows.Forms.Label();
            this.TxtNewMima2 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtNewMima1 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtOldMima = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button2.Location = new System.Drawing.Point(126, 87);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(60, 29);
            this.Button2.TabIndex = 17;
            this.Button2.Text = "取消";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button1.Location = new System.Drawing.Point(31, 87);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(60, 29);
            this.Button1.TabIndex = 16;
            this.Button1.Text = "确认";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblInfo.Location = new System.Drawing.Point(24, 120);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(167, 19);
            this.LblInfo.TabIndex = 15;
            this.LblInfo.Text = "您的用户身份是： 管理员";
            // 
            // TxtNewMima2
            // 
            this.TxtNewMima2.Location = new System.Drawing.Point(95, 60);
            this.TxtNewMima2.Name = "TxtNewMima2";
            this.TxtNewMima2.Size = new System.Drawing.Size(108, 21);
            this.TxtNewMima2.TabIndex = 14;
            this.TxtNewMima2.UseSystemPasswordChar = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label3.Location = new System.Drawing.Point(13, 59);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(79, 19);
            this.Label3.TabIndex = 13;
            this.Label3.Text = "确认新密码";
            // 
            // TxtNewMima1
            // 
            this.TxtNewMima1.Location = new System.Drawing.Point(95, 33);
            this.TxtNewMima1.Name = "TxtNewMima1";
            this.TxtNewMima1.Size = new System.Drawing.Size(108, 21);
            this.TxtNewMima1.TabIndex = 12;
            this.TxtNewMima1.UseSystemPasswordChar = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label2.Location = new System.Drawing.Point(25, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 19);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "新  密  码";
            // 
            // TxtOldMima
            // 
            this.TxtOldMima.Location = new System.Drawing.Point(95, 6);
            this.TxtOldMima.Name = "TxtOldMima";
            this.TxtOldMima.Size = new System.Drawing.Size(108, 21);
            this.TxtOldMima.TabIndex = 10;
            this.TxtOldMima.UseSystemPasswordChar = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Location = new System.Drawing.Point(25, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 19);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "旧  密  码";
            // 
            // FrmMimaXG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 149);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.TxtNewMima2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtNewMima1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtOldMima);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMimaXG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码修改";
            this.Load += new System.EventHandler(this.FrmMimaXG_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label LblInfo;
        internal System.Windows.Forms.TextBox TxtNewMima2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtNewMima1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtOldMima;
        internal System.Windows.Forms.Label Label1;
    }
}