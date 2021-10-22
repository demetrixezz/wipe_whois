
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
            this.panelMenuDataRight = new System.Windows.Forms.Panel();
            this.panelMenuLeft = new System.Windows.Forms.Panel();
            this.panelMenuAutorize = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.panelPass = new System.Windows.Forms.Panel();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.labelLoginDescription = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelMenuInfoDB = new System.Windows.Forms.Panel();
            this.buttonInfoAdmin = new System.Windows.Forms.Button();
            this.buttonCheckRegistryData = new System.Windows.Forms.Button();
            this.labelMenuInfo = new System.Windows.Forms.Label();
            this.pictureBoxBottomPanelMenuInfoDB = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopPanelMenuInfoDB = new System.Windows.Forms.PictureBox();
            this.panelMenuLeftPanelButtons = new System.Windows.Forms.Panel();
            this.panelMenuLeftPanelButtonSettings = new System.Windows.Forms.Panel();
            this.buttonPanelMenuLeftPanelButtonSettingsSounds = new WhoIs.ButtonRounded();
            this.buttonPanelMenuLeftPanelButtonSettingsActors = new WhoIs.ButtonRounded();
            this.buttonMenuLeftAdministrations = new WhoIs.ButtonRounded();
            this.buttonMenuLeftSettings = new WhoIs.ButtonRounded();
            this.buttonMenuLeftViewDatas = new WhoIs.ButtonRounded();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonToTray = new System.Windows.Forms.Button();
            this.panelLogoWIPE = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.panelFormMain.SuspendLayout();
            this.panelMenuLeft.SuspendLayout();
            this.panelMenuAutorize.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelPass.SuspendLayout();
            this.panelMenuInfoDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomPanelMenuInfoDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopPanelMenuInfoDB)).BeginInit();
            this.panelMenuLeftPanelButtons.SuspendLayout();
            this.panelMenuLeftPanelButtonSettings.SuspendLayout();
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
            this.contextMenuStrip.Size = new System.Drawing.Size(166, 98);
            // 
            // ToolStripMenuItemViewLists
            // 
            this.ToolStripMenuItemViewLists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.ToolStripMenuItemViewLists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItemViewLists.Name = "ToolStripMenuItemViewLists";
            this.ToolStripMenuItemViewLists.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemViewLists.Text = "Просмотреть списки";
            this.ToolStripMenuItemViewLists.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripMenuItemViewLists.Click += new System.EventHandler(this.ToolStripMenuItemViewLists_Click);
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
            this.panelFormMain.Controls.Add(this.panelMenuDataRight);
            this.panelFormMain.Controls.Add(this.panelMenuLeft);
            this.panelFormMain.Controls.Add(this.labelStatus);
            this.panelFormMain.Controls.Add(this.button1);
            this.panelFormMain.Location = new System.Drawing.Point(0, 34);
            this.panelFormMain.Name = "panelFormMain";
            this.panelFormMain.Size = new System.Drawing.Size(690, 416);
            this.panelFormMain.TabIndex = 8;
            // 
            // panelMenuDataRight
            // 
            this.panelMenuDataRight.Location = new System.Drawing.Point(237, 0);
            this.panelMenuDataRight.Name = "panelMenuDataRight";
            this.panelMenuDataRight.Size = new System.Drawing.Size(453, 378);
            this.panelMenuDataRight.TabIndex = 9;
            // 
            // panelMenuLeft
            // 
            this.panelMenuLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.panelMenuLeft.Controls.Add(this.panelMenuAutorize);
            this.panelMenuLeft.Controls.Add(this.panelMenuInfoDB);
            this.panelMenuLeft.Controls.Add(this.panelMenuLeftPanelButtons);
            this.panelMenuLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLeft.Name = "panelMenuLeft";
            this.panelMenuLeft.Size = new System.Drawing.Size(236, 378);
            this.panelMenuLeft.TabIndex = 6;
            // 
            // panelMenuAutorize
            // 
            this.panelMenuAutorize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.panelMenuAutorize.Controls.Add(this.panelLogin);
            this.panelMenuAutorize.Controls.Add(this.panelPass);
            this.panelMenuAutorize.Controls.Add(this.labelLoginDescription);
            this.panelMenuAutorize.Controls.Add(this.buttonLogin);
            this.panelMenuAutorize.Location = new System.Drawing.Point(230, 37);
            this.panelMenuAutorize.Name = "panelMenuAutorize";
            this.panelMenuAutorize.Size = new System.Drawing.Size(236, 130);
            this.panelMenuAutorize.TabIndex = 7;
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
            this.textBoxLogin.TabStop = false;
            this.textBoxLogin.TextChanged += new System.EventHandler(this.TextBoxLogin_TextChanged);
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
            this.textBoxPass.TabIndex = 0;
            this.textBoxPass.TabStop = false;
            this.textBoxPass.UseSystemPasswordChar = true;
            this.textBoxPass.TextChanged += new System.EventHandler(this.TextBoxPass_TextChanged);
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
            // panelMenuLeftPanelButtons
            // 
            this.panelMenuLeftPanelButtons.Controls.Add(this.panelMenuLeftPanelButtonSettings);
            this.panelMenuLeftPanelButtons.Controls.Add(this.buttonMenuLeftAdministrations);
            this.panelMenuLeftPanelButtons.Controls.Add(this.buttonMenuLeftSettings);
            this.panelMenuLeftPanelButtons.Controls.Add(this.buttonMenuLeftViewDatas);
            this.panelMenuLeftPanelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLeftPanelButtons.Name = "panelMenuLeftPanelButtons";
            this.panelMenuLeftPanelButtons.Size = new System.Drawing.Size(236, 378);
            this.panelMenuLeftPanelButtons.TabIndex = 11;
            // 
            // panelMenuLeftPanelButtonSettings
            // 
            this.panelMenuLeftPanelButtonSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelMenuLeftPanelButtonSettings.Controls.Add(this.buttonPanelMenuLeftPanelButtonSettingsSounds);
            this.panelMenuLeftPanelButtonSettings.Controls.Add(this.buttonPanelMenuLeftPanelButtonSettingsActors);
            this.panelMenuLeftPanelButtonSettings.Location = new System.Drawing.Point(0, 70);
            this.panelMenuLeftPanelButtonSettings.Name = "panelMenuLeftPanelButtonSettings";
            this.panelMenuLeftPanelButtonSettings.Size = new System.Drawing.Size(236, 97);
            this.panelMenuLeftPanelButtonSettings.TabIndex = 11;
            // 
            // buttonPanelMenuLeftPanelButtonSettingsSounds
            // 
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.FlatAppearance.BorderSize = 0;
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.Location = new System.Drawing.Point(10, 50);
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.Name = "buttonPanelMenuLeftPanelButtonSettingsSounds";
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.RoundedHeight = 12;
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.RoundedWidth = 12;
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.Size = new System.Drawing.Size(216, 41);
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.TabIndex = 2;
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.Text = "Настройки звуков";
            this.buttonPanelMenuLeftPanelButtonSettingsSounds.UseVisualStyleBackColor = false;
            // 
            // buttonPanelMenuLeftPanelButtonSettingsActors
            // 
            this.buttonPanelMenuLeftPanelButtonSettingsActors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonPanelMenuLeftPanelButtonSettingsActors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPanelMenuLeftPanelButtonSettingsActors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonPanelMenuLeftPanelButtonSettingsActors.FlatAppearance.BorderSize = 0;
            this.buttonPanelMenuLeftPanelButtonSettingsActors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            this.buttonPanelMenuLeftPanelButtonSettingsActors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonPanelMenuLeftPanelButtonSettingsActors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPanelMenuLeftPanelButtonSettingsActors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonPanelMenuLeftPanelButtonSettingsActors.Location = new System.Drawing.Point(10, 5);
            this.buttonPanelMenuLeftPanelButtonSettingsActors.Name = "buttonPanelMenuLeftPanelButtonSettingsActors";
            this.buttonPanelMenuLeftPanelButtonSettingsActors.RoundedHeight = 12;
            this.buttonPanelMenuLeftPanelButtonSettingsActors.RoundedWidth = 12;
            this.buttonPanelMenuLeftPanelButtonSettingsActors.Size = new System.Drawing.Size(216, 41);
            this.buttonPanelMenuLeftPanelButtonSettingsActors.TabIndex = 1;
            this.buttonPanelMenuLeftPanelButtonSettingsActors.Text = "Выбор ассистента";
            this.buttonPanelMenuLeftPanelButtonSettingsActors.UseVisualStyleBackColor = false;
            // 
            // buttonMenuLeftAdministrations
            // 
            this.buttonMenuLeftAdministrations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonMenuLeftAdministrations.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonMenuLeftAdministrations.FlatAppearance.BorderSize = 0;
            this.buttonMenuLeftAdministrations.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            this.buttonMenuLeftAdministrations.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonMenuLeftAdministrations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuLeftAdministrations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonMenuLeftAdministrations.Location = new System.Drawing.Point(160, 10);
            this.buttonMenuLeftAdministrations.Name = "buttonMenuLeftAdministrations";
            this.buttonMenuLeftAdministrations.RoundedHeight = 12;
            this.buttonMenuLeftAdministrations.RoundedWidth = 12;
            this.buttonMenuLeftAdministrations.Size = new System.Drawing.Size(68, 58);
            this.buttonMenuLeftAdministrations.TabIndex = 10;
            this.buttonMenuLeftAdministrations.Text = "Admin";
            this.buttonMenuLeftAdministrations.UseVisualStyleBackColor = false;
            // 
            // buttonMenuLeftSettings
            // 
            this.buttonMenuLeftSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonMenuLeftSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMenuLeftSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonMenuLeftSettings.FlatAppearance.BorderSize = 0;
            this.buttonMenuLeftSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            this.buttonMenuLeftSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonMenuLeftSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuLeftSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonMenuLeftSettings.Location = new System.Drawing.Point(12, 10);
            this.buttonMenuLeftSettings.Name = "buttonMenuLeftSettings";
            this.buttonMenuLeftSettings.RoundedHeight = 12;
            this.buttonMenuLeftSettings.RoundedWidth = 12;
            this.buttonMenuLeftSettings.Size = new System.Drawing.Size(68, 58);
            this.buttonMenuLeftSettings.TabIndex = 0;
            this.buttonMenuLeftSettings.Text = "Settings";
            this.buttonMenuLeftSettings.UseVisualStyleBackColor = false;
            this.buttonMenuLeftSettings.Click += new System.EventHandler(this.ButtonMenuLeftSettings_Click);
            // 
            // buttonMenuLeftViewDatas
            // 
            this.buttonMenuLeftViewDatas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonMenuLeftViewDatas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonMenuLeftViewDatas.FlatAppearance.BorderSize = 0;
            this.buttonMenuLeftViewDatas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            this.buttonMenuLeftViewDatas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonMenuLeftViewDatas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuLeftViewDatas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonMenuLeftViewDatas.Location = new System.Drawing.Point(86, 10);
            this.buttonMenuLeftViewDatas.Name = "buttonMenuLeftViewDatas";
            this.buttonMenuLeftViewDatas.RoundedHeight = 12;
            this.buttonMenuLeftViewDatas.RoundedWidth = 12;
            this.buttonMenuLeftViewDatas.Size = new System.Drawing.Size(68, 58);
            this.buttonMenuLeftViewDatas.TabIndex = 9;
            this.buttonMenuLeftViewDatas.Text = "Data";
            this.buttonMenuLeftViewDatas.UseVisualStyleBackColor = false;
            this.buttonMenuLeftViewDatas.Click += new System.EventHandler(this.ButtonMenuLeftViewDatas_Click);
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
            this.panelMenuAutorize.ResumeLayout(false);
            this.panelMenuAutorize.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelPass.ResumeLayout(false);
            this.panelPass.PerformLayout();
            this.panelMenuInfoDB.ResumeLayout(false);
            this.panelMenuInfoDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomPanelMenuInfoDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopPanelMenuInfoDB)).EndInit();
            this.panelMenuLeftPanelButtons.ResumeLayout(false);
            this.panelMenuLeftPanelButtonSettings.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelPass;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelMenuInfoDB;
        private System.Windows.Forms.PictureBox pictureBoxTopPanelMenuInfoDB;
        private System.Windows.Forms.PictureBox pictureBoxBottomPanelMenuInfoDB;
        private System.Windows.Forms.Label labelMenuInfo;
        private System.Windows.Forms.Button buttonInfoAdmin;
        private System.Windows.Forms.Button buttonCheckRegistryData;
        private System.Windows.Forms.Panel panelMenuDataRight;
        private ButtonRounded buttonMenuLeftSettings;
        private ButtonRounded buttonMenuLeftAdministrations;
        private ButtonRounded buttonMenuLeftViewDatas;
        private System.Windows.Forms.Panel panelMenuLeftPanelButtons;
        private System.Windows.Forms.Panel panelMenuLeftPanelButtonSettings;
        private ButtonRounded buttonPanelMenuLeftPanelButtonSettingsSounds;
        private ButtonRounded buttonPanelMenuLeftPanelButtonSettingsActors;
    }
}