
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
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelFormMain = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonToTray = new System.Windows.Forms.Button();
            this.panelLogoWIPE = new System.Windows.Forms.Panel();
            this.imageListHeaderButtons = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.panelFormMain.SuspendLayout();
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
            this.button1.TabIndex = 4;
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
            this.ToolStripMenuItemAbout,
            this.toolStripSeparator1,
            this.ToolStripMenuItemClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(166, 76);
            // 
            // ToolStripMenuItemViewLists
            // 
            this.ToolStripMenuItemViewLists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.ToolStripMenuItemViewLists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItemViewLists.Name = "ToolStripMenuItemViewLists";
            this.ToolStripMenuItemViewLists.Size = new System.Drawing.Size(165, 22);
            this.ToolStripMenuItemViewLists.Text = "Просмотреть списки";
            this.ToolStripMenuItemViewLists.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.ToolStripMenuItemClose.Text = "Закрыть";
            this.ToolStripMenuItemClose.Click += new System.EventHandler(this.ToolStripMenuItemClose_Click);
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
            this.buttonClose.Location = new System.Drawing.Point(658, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 32);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // panelFormMain
            // 
            this.panelFormMain.BackColor = System.Drawing.Color.Transparent;
            this.panelFormMain.Controls.Add(this.label5);
            this.panelFormMain.Controls.Add(this.label4);
            this.panelFormMain.Controls.Add(this.label3);
            this.panelFormMain.Controls.Add(this.label1);
            this.panelFormMain.Controls.Add(this.label2);
            this.panelFormMain.Controls.Add(this.button1);
            this.panelFormMain.Location = new System.Drawing.Point(0, 34);
            this.panelFormMain.Name = "panelFormMain";
            this.panelFormMain.Size = new System.Drawing.Size(690, 416);
            this.panelFormMain.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.label5.Location = new System.Drawing.Point(22, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.label4.Location = new System.Drawing.Point(22, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.label3.Location = new System.Drawing.Point(22, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.label2.Location = new System.Drawing.Point(22, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
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
            this.buttonToTray.Location = new System.Drawing.Point(620, 0);
            this.buttonToTray.Name = "buttonToTray";
            this.buttonToTray.Size = new System.Drawing.Size(32, 32);
            this.buttonToTray.TabIndex = 9;
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
            // imageListHeaderButtons
            // 
            this.imageListHeaderButtons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListHeaderButtons.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListHeaderButtons.TransparentColor = System.Drawing.Color.Transparent;
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
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WhoIs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.panelFormMain.ResumeLayout(false);
            this.panelFormMain.PerformLayout();
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
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelFormMain;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelLogoWIPE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageListHeaderButtons;
        private System.Windows.Forms.Button buttonToTray;
    }
}