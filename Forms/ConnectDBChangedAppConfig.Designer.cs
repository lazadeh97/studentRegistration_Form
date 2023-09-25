namespace RegistrationOfStudents
{
    partial class ConnectDBChangedAppConfig
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectDBChangedAppConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBDataSource = new System.Windows.Forms.ComboBox();
            this.TxtInitialCatalog = new System.Windows.Forms.TextBox();
            this.TxtUserID = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnChanged = new System.Windows.Forms.Button();
            this.CbAuthenticaton = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnExecuteScript = new System.Windows.Forms.Button();
            this.menuStripDatabase = new System.Windows.Forms.MenuStrip();
            this.stripMenuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.appConfigScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipMessage = new System.Windows.Forms.ToolTip(this.components);
            this.menuStripDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "DataBase Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "İstifadəçi Adı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Şifrə:";
            // 
            // CBDataSource
            // 
            this.CBDataSource.FormattingEnabled = true;
            this.CBDataSource.Items.AddRange(new object[] {
            ".",
            "(local)",
            "DESKTOP-J0A11C6\\SQLEXPRESS"});
            this.CBDataSource.Location = new System.Drawing.Point(114, 48);
            this.CBDataSource.Name = "CBDataSource";
            this.CBDataSource.Size = new System.Drawing.Size(233, 25);
            this.CBDataSource.TabIndex = 2;
            // 
            // TxtInitialCatalog
            // 
            this.TxtInitialCatalog.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInitialCatalog.Location = new System.Drawing.Point(114, 112);
            this.TxtInitialCatalog.Name = "TxtInitialCatalog";
            this.TxtInitialCatalog.Size = new System.Drawing.Size(233, 27);
            this.TxtInitialCatalog.TabIndex = 3;
            // 
            // TxtUserID
            // 
            this.TxtUserID.Enabled = false;
            this.TxtUserID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserID.Location = new System.Drawing.Point(114, 146);
            this.TxtUserID.Name = "TxtUserID";
            this.TxtUserID.Size = new System.Drawing.Size(233, 27);
            this.TxtUserID.TabIndex = 4;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(114, 182);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(233, 27);
            this.TxtPassword.TabIndex = 5;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // BtnChanged
            // 
            this.BtnChanged.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(92)))), ((int)(((byte)(183)))));
            this.BtnChanged.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnChanged.Location = new System.Drawing.Point(204, 229);
            this.BtnChanged.Name = "BtnChanged";
            this.BtnChanged.Size = new System.Drawing.Size(143, 50);
            this.BtnChanged.TabIndex = 6;
            this.BtnChanged.Text = "DataBase ilə Əlaqə Yaradın";
            this.BtnChanged.UseVisualStyleBackColor = true;
            this.BtnChanged.Visible = false;
            this.BtnChanged.Click += new System.EventHandler(this.BtnChanged_Click);
            // 
            // CbAuthenticaton
            // 
            this.CbAuthenticaton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbAuthenticaton.FormattingEnabled = true;
            this.CbAuthenticaton.Items.AddRange(new object[] {
            "Sql Server Authentication",
            "Windows Authentication"});
            this.CbAuthenticaton.Location = new System.Drawing.Point(114, 78);
            this.CbAuthenticaton.Name = "CbAuthenticaton";
            this.CbAuthenticaton.Size = new System.Drawing.Size(233, 25);
            this.CbAuthenticaton.TabIndex = 8;
            this.CbAuthenticaton.SelectedIndexChanged += new System.EventHandler(this.CbAuthenticaton_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mənbə:";
            // 
            // BtnExecuteScript
            // 
            this.BtnExecuteScript.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(92)))), ((int)(((byte)(183)))));
            this.BtnExecuteScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnExecuteScript.Location = new System.Drawing.Point(20, 229);
            this.BtnExecuteScript.Name = "BtnExecuteScript";
            this.BtnExecuteScript.Size = new System.Drawing.Size(143, 50);
            this.BtnExecuteScript.TabIndex = 9;
            this.BtnExecuteScript.Text = "Avtomatik DataBase Yaradın";
            this.BtnExecuteScript.UseVisualStyleBackColor = true;
            this.BtnExecuteScript.Visible = false;
            this.BtnExecuteScript.Click += new System.EventHandler(this.BtnExecuteScript_Click);
            // 
            // menuStripDatabase
            // 
            this.menuStripDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.menuStripDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuDatabase});
            this.menuStripDatabase.Location = new System.Drawing.Point(0, 0);
            this.menuStripDatabase.Name = "menuStripDatabase";
            this.menuStripDatabase.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripDatabase.Size = new System.Drawing.Size(370, 24);
            this.menuStripDatabase.TabIndex = 10;
            // 
            // stripMenuDatabase
            // 
            this.stripMenuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appConfigScriptToolStripMenuItem,
            this.connectDbToolStripMenuItem});
            this.stripMenuDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripMenuDatabase.Name = "stripMenuDatabase";
            this.stripMenuDatabase.Size = new System.Drawing.Size(67, 20);
            this.stripMenuDatabase.Text = "&DataBase";
            // 
            // appConfigScriptToolStripMenuItem
            // 
            this.appConfigScriptToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("appConfigScriptToolStripMenuItem.Image")));
            this.appConfigScriptToolStripMenuItem.Name = "appConfigScriptToolStripMenuItem";
            this.appConfigScriptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.appConfigScriptToolStripMenuItem.Text = "AppConfig və Script";
            this.appConfigScriptToolStripMenuItem.Click += new System.EventHandler(this.appConfigScriptToolStripMenuItem_Click);
            // 
            // connectDbToolStripMenuItem
            // 
            this.connectDbToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectDbToolStripMenuItem.Image")));
            this.connectDbToolStripMenuItem.Name = "connectDbToolStripMenuItem";
            this.connectDbToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectDbToolStripMenuItem.Text = "Qoşulma";
            this.connectDbToolStripMenuItem.Click += new System.EventHandler(this.connectDbToolStripMenuItem_Click);
            // 
            // ConnectDBChangedAppConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(370, 296);
            this.Controls.Add(this.BtnExecuteScript);
            this.Controls.Add(this.CbAuthenticaton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnChanged);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUserID);
            this.Controls.Add(this.TxtInitialCatalog);
            this.Controls.Add(this.CBDataSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripDatabase);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripDatabase;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectDBChangedAppConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serverlə Əlaqə";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectDBChangedAppConfig_FormClosing);
            this.Load += new System.EventHandler(this.ConnectDBChangedAppConfig_Load);
            this.menuStripDatabase.ResumeLayout(false);
            this.menuStripDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBDataSource;
        private System.Windows.Forms.TextBox TxtInitialCatalog;
        private System.Windows.Forms.TextBox TxtUserID;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnChanged;
        private System.Windows.Forms.ComboBox CbAuthenticaton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnExecuteScript;
        private System.Windows.Forms.MenuStrip menuStripDatabase;
        private System.Windows.Forms.ToolStripMenuItem stripMenuDatabase;
        private System.Windows.Forms.ToolStripMenuItem appConfigScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectDbToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipMessage;
    }
}