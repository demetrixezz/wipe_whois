
namespace WhoIs
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.button1 = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemViewLists = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFormMain = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panelMenuLeft = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelMenuInfoDB = new System.Windows.Forms.Panel();
            this.buttonInfoAdmin = new System.Windows.Forms.Button();
            this.buttonCheckRegistryData = new System.Windows.Forms.Button();
            this.labelMenuInfo = new System.Windows.Forms.Label();
            this.pictureBoxBottomPanelMenuInfoDB = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopPanelMenuInfoDB = new System.Windows.Forms.PictureBox();
            this.panelMenuAutorize = new System.Windows.Forms.Panel();
            this.panelPass = new System.Windows.Forms.Panel();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLoginDescription = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonToTray = new System.Windows.Forms.Button();
            this.panelLogoWIPE = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.panelFormMain.SuspendLayout();
            this.panelMenuLeft.SuspendLayout();
            this.panelMenuInfoDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomPanelMenuInfoDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopPanelMenuInfoDB)).BeginInit();
            this.panelMenuAutorize.SuspendLayout();
            this.panelPass.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(77)))), ((int)(((byte)(83)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.button1.Location = new System.Drawing.Point(495, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 21);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "Временно для работы со звуком";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipText = "Продолжаем работать в фоновом режиме";
            this.NotifyIcon.BalloonTipTitle = "Программа свёрнута в трей";
            this.NotifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "WhoIs";
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemViewLists,
            this.ToolStripMenuItemHelp,
            this.ToolStripMenuItemAbout,
            this.toolStripSeparator1,
            this.ToolStripMenuItemClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(166, 120);
            // 
            // ToolStripMenuItemViewLists
            // 
            this.ToolStripMenuItemViewLists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.ToolStripMenuItemViewLists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItemViewLists.Name = "ToolStripMenuItemViewLists";
            this.ToolStripMenuItemViewLists.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemViewLists.Text = "Просмотреть списки";
            this.ToolStripMenuItemViewLists.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripMenuItemViewLists.Click += new System.EventHandler(this.ToolStripMenuItemViewLists_Click_1);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemHelp.Text = "Справка";
            this.ToolStripMenuItemHelp.Click += new System.EventHandler(this.ToolStripMenuItemHelp_Click);
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemAbout.Text = "О программе";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // ToolStripMenuItemClose
            // 
            this.ToolStripMenuItemClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.ToolStripMenuItemClose.Name = "ToolStripMenuItemClose";
            this.ToolStripMenuItemClose.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemClose.Text = "LogOFF";
            this.ToolStripMenuItemClose.Click += new System.EventHandler(this.ToolStripMenuItemClose_Click);
            // 
            // panelFormMain
            // 
            this.panelFormMain.BackColor = System.Drawing.Color.Transparent;
            this.panelFormMain.Controls.Add(this.button2);
            this.panelFormMain.Controls.Add(this.listBox1);
            this.panelFormMain.Controls.Add(this.panelMenuLeft);
            this.panelFormMain.Controls.Add(this.labelStatus);
            this.panelFormMain.Controls.Add(this.button1);
            this.panelFormMain.Location = new System.Drawing.Point(0, 34);
            this.panelFormMain.Name = "panelFormMain";
            this.panelFormMain.Size = new System.Drawing.Size(690, 416);
            this.panelFormMain.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(77)))), ((int)(((byte)(83)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.button2.Location = new System.Drawing.Point(269, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 21);
            this.button2.TabIndex = 8;
            this.button2.TabStop = false;
            this.button2.Text = "Окно данных";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(244, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(436, 93);
            this.listBox1.TabIndex = 7;
            // 
            // panelMenuLeft
            // 
            this.panelMenuLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.panelMenuLeft.Controls.Add(this.panelLogo);
            this.panelMenuLeft.Controls.Add(this.panelMenuInfoDB);
            this.panelMenuLeft.Controls.Add(this.panelMenuAutorize);
            this.panelMenuLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLeft.Name = "panelMenuLeft";
            this.panelMenuLeft.Size = new System.Drawing.Size(236, 378);
            this.panelMenuLeft.TabIndex = 6;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.BackgroundImage = global::WhoIs.Properties.Resources.WIPE_text;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Location = new System.Drawing.Point(21, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(195, 36);
            this.panelLogo.TabIndex = 6;
            // 
            // panelMenuInfoDB
            // 
            this.panelMenuInfoDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.panelMenuInfoDB.Controls.Add(this.buttonInfoAdmin);
            this.panelMenuInfoDB.Controls.Add(this.buttonCheckRegistryData);
            this.panelMenuInfoDB.Controls.Add(this.labelMenuInfo);
            this.panelMenuInfoDB.Controls.Add(this.pictureBoxBottomPanelMenuInfoDB);
            this.panelMenuInfoDB.Controls.Add(this.pictureBoxTopPanelMenuInfoDB);
            this.panelMenuInfoDB.Location = new System.Drawing.Point(230, 37);
            this.panelMenuInfoDB.Name = "panelMenuInfoDB";
            this.panelMenuInfoDB.Size = new System.Drawing.Size(236, 130);
            this.panelMenuInfoDB.TabIndex = 8;
            // 
            // buttonInfoAdmin
            // 
            this.buttonInfoAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.buttonInfoAdmin.FlatAppearance.BorderSize = 0;
            this.buttonInfoAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(77)))), ((int)(((byte)(83)))));
            this.buttonInfoAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.buttonInfoAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfoAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonInfoAdmin.Location = new System.Drawing.Point(152, 67);
            this.buttonInfoAdmin.Name = "buttonInfoAdmin";
            this.buttonInfoAdmin.Size = new System.Drawing.Size(70, 30);
            this.buttonInfoAdmin.TabIndex = 5;
            this.buttonInfoAdmin.Text = "Сообщить";
            this.buttonInfoAdmin.UseVisualStyleBackColor = false;
            this.buttonInfoAdmin.Click += new System.EventHandler(this.ButtonInfoAdmin_Click);
            // 
            // buttonCheckRegistryData
            // 
            this.buttonCheckRegistryData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.buttonCheckRegistryData.FlatAppearance.BorderSize = 0;
            this.buttonCheckRegistryData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(77)))), ((int)(((byte)(83)))));
            this.buttonCheckRegistryData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.buttonCheckRegistryData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckRegistryData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonCheckRegistryData.Location = new System.Drawing.Point(152, 33);
            this.buttonCheckRegistryData.Name = "buttonCheckRegistryData";
            this.buttonCheckRegistryData.Size = new System.Drawing.Size(70, 30);
            this.buttonCheckRegistryData.TabIndex = 4;
            this.buttonCheckRegistryData.Text = "Проверить";
            this.buttonCheckRegistryData.UseVisualStyleBackColor = false;
            this.buttonCheckRegistryData.Click += new System.EventHandler(this.ButtonCheckRegistryData_Click);
            // 
            // labelMenuInfo
            // 
            this.labelMenuInfo.AutoSize = true;
            this.labelMenuInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelMenuInfo.Location = new System.Drawing.Point(11, 31);
            this.labelMenuInfo.Name = "labelMenuInfo";
            this.labelMenuInfo.Size = new System.Drawing.Size(130, 65);
            this.labelMenuInfo.TabIndex = 2;
            this.labelMenuInfo.Text = "Если данные верны, но \r\nника нет в базе данных:\r\nпопроси в дискорде \r\nаббатов или" +
    " командира\r\nдобавить тебя в базу. \r\n";
            // 
            // pictureBoxBottomPanelMenuInfoDB
            // 
            this.pictureBoxBottomPanelMenuInfoDB.BackgroundImage = global::WhoIs.Properties.Resources.Dividing_line;
            this.pictureBoxBottomPanelMenuInfoDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBottomPanelMenuInfoDB.ErrorImage = null;
            this.pictureBoxBottomPanelMenuInfoDB.InitialImage = null;
            this.pictureBoxBottomPanelMenuInfoDB.Location = new System.Drawing.Point(4, 107);
            this.pictureBoxBottomPanelMenuInfoDB.Name = "pictureBoxBottomPanelMenuInfoDB";
            this.pictureBoxBottomPanelMenuInfoDB.Size = new System.Drawing.Size(230, 22);
            this.pictureBoxBottomPanelMenuInfoDB.TabIndex = 1;
            this.pictureBoxBottomPanelMenuInfoDB.TabStop = false;
            // 
            // pictureBoxTopPanelMenuInfoDB
            // 
            this.pictureBoxTopPanelMenuInfoDB.BackgroundImage = global::WhoIs.Properties.Resources.Dividing_line;
            this.pictureBoxTopPanelMenuInfoDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTopPanelMenuInfoDB.ErrorImage = null;
            this.pictureBoxTopPanelMenuInfoDB.InitialImage = null;
            this.pictureBoxTopPanelMenuInfoDB.Location = new System.Drawing.Point(4, 3);
            this.pictureBoxTopPanelMenuInfoDB.Name = "pictureBoxTopPanelMenuInfoDB";
            this.pictureBoxTopPanelMenuInfoDB.Size = new System.Drawing.Size(230, 22);
            this.pictureBoxTopPanelMenuInfoDB.TabIndex = 0;
            this.pictureBoxTopPanelMenuInfoDB.TabStop = false;
            // 
            // panelMenuAutorize
            // 
            this.panelMenuAutorize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.panelMenuAutorize.Controls.Add(this.panelPass);
            this.panelMenuAutorize.Controls.Add(this.panelLogin);
            this.panelMenuAutorize.Controls.Add(this.labelLoginDescription);
            this.panelMenuAutorize.Controls.Add(this.buttonLogin);
            this.panelMenuAutorize.Location = new System.Drawing.Point(230, 37);
            this.panelMenuAutorize.Name = "panelMenuAutorize";
            this.panelMenuAutorize.Size = new System.Drawing.Size(236, 130);
            this.panelMenuAutorize.TabIndex = 7;
            // 
            // panelPass
            // 
            this.panelPass.Controls.Add(this.labelPass);
            this.panelPass.Controls.Add(this.textBoxPass);
            this.panelPass.Location = new System.Drawing.Point(21, 38);
            this.panelPass.Margin = new System.Windows.Forms.Padding(0);
            this.panelPass.Name = "panelPass";
            this.panelPass.Size = new System.Drawing.Size(195, 26);
            this.panelPass.TabIndex = 7;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelPass.Location = new System.Drawing.Point(4, 5);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(45, 13);
            this.labelPass.TabIndex = 3;
            this.labelPass.Text = "Пароль";
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.textBoxPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.textBoxPass.Location = new System.Drawing.Point(67, 3);
            this.textBoxPass.MaxLength = 100;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(125, 20);
            this.textBoxPass.TabIndex = 2;
            this.textBoxPass.UseSystemPasswordChar = true;
            this.textBoxPass.TextChanged += new System.EventHandler(this.TextBoxPass_TextChanged);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(this.textBoxLogin);
            this.panelLogin.Location = new System.Drawing.Point(21, 9);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(195, 26);
            this.panelLogin.TabIndex = 6;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelLogin.Location = new System.Drawing.Point(3, 5);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(38, 13);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.textBoxLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.textBoxLogin.Location = new System.Drawing.Point(67, 3);
            this.textBoxLogin.MaxLength = 32;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(125, 20);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.TextChanged += new System.EventHandler(this.TextBoxLogin_TextChanged);
            // 
            // labelLoginDescription
            // 
            this.labelLoginDescription.AutoSize = true;
            this.labelLoginDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelLoginDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelLoginDescription.Location = new System.Drawing.Point(23, 105);
            this.labelLoginDescription.Name = "labelLoginDescription";
            this.labelLoginDescription.Size = new System.Drawing.Size(0, 13);
            this.labelLoginDescription.TabIndex = 5;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(77)))), ((int)(((byte)(83)))));
            this.buttonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(67)))), ((int)(((byte)(73)))));
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonLogin.Location = new System.Drawing.Point(23, 70);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(191, 23);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 389);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 5;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelHeader.Location = new System.Drawing.Point(35, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(43, 15);
            this.labelHeader.TabIndex = 7;
            this.labelHeader.Text = "WhoIs";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelHeader.Controls.Add(this.buttonToTray);
            this.panelHeader.Controls.Add(this.panelLogoWIPE);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Controls.Add(this.buttonClose);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(690, 34);
            this.panelHeader.TabIndex = 7;
            // 
            // buttonToTray
            // 
            this.buttonToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToTray.BackgroundImage = global::WhoIs.Properties.Resources.ToTray;
            this.buttonToTray.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonToTray.FlatAppearance.BorderSize = 0;
            this.buttonToTray.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonToTray.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonToTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToTray.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonToTray.Location = new System.Drawing.Point(635, 4);
            this.buttonToTray.Name = "buttonToTray";
            this.buttonToTray.Size = new System.Drawing.Size(24, 24);
            this.buttonToTray.TabIndex = 0;
            this.buttonToTray.TabStop = false;
            this.buttonToTray.UseVisualStyleBackColor = true;
            this.buttonToTray.Click += new System.EventHandler(this.ButtonToTray_Click);
            // 
            // panelLogoWIPE
            // 
            this.panelLogoWIPE.BackgroundImage = global::WhoIs.Properties.Resources.WIPE_logo;
            this.panelLogoWIPE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogoWIPE.Location = new System.Drawing.Point(-2, -2);
            this.panelLogoWIPE.Name = "panelLogoWIPE";
            this.panelLogoWIPE.Size = new System.Drawing.Size(38, 38);
            this.panelLogoWIPE.TabIndex = 8;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonClose.Location = new System.Drawing.Point(662, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(24, 24);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFormMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WhoIs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.panelFormMain.ResumeLayout(false);
            this.panelFormMain.PerformLayout();
            this.panelMenuLeft.ResumeLayout(false);
            this.panelMenuInfoDB.ResumeLayout(false);
            this.panelMenuInfoDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomPanelMenuInfoDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopPanelMenuInfoDB)).EndInit();
            this.panelMenuAutorize.ResumeLayout(false);
            this.panelMenuAutorize.PerformLayout();
            this.panelPass.ResumeLayout(false);
            this.panelPass.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemViewLists;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.Panel panelFormMain;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelLogoWIPE;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonToTray;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.Panel panelMenuLeft;
        private System.Windows.Forms.Panel panelMenuAutorize;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelLoginDescription;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelPass;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelMenuInfoDB;
        private System.Windows.Forms.PictureBox pictureBoxTopPanelMenuInfoDB;
        private System.Windows.Forms.PictureBox pictureBoxBottomPanelMenuInfoDB;
        private System.Windows.Forms.Label labelMenuInfo;
        private System.Windows.Forms.Button buttonInfoAdmin;
        private System.Windows.Forms.Button buttonCheckRegistryData;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
    }
}