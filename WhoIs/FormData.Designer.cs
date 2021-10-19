
namespace WhoIs
{
    partial class FormData
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormData));
            this.panelFormDataHead = new System.Windows.Forms.Panel();
            this.labelPanelDataHeader = new System.Windows.Forms.Label();
            this.buttonPanelDataClose = new System.Windows.Forms.Button();
            this.panelFormData = new System.Windows.Forms.Panel();
            this.labelStatusFormData = new System.Windows.Forms.Label();
            this.panelControlsFormData = new System.Windows.Forms.Panel();
            this.panelMenuFormData = new System.Windows.Forms.Panel();
            this.buttonPilots = new WhoIs.ButtonRounded();
            this.buttonSquadrons = new WhoIs.ButtonRounded();
            this.panelFormDataHead.SuspendLayout();
            this.panelFormData.SuspendLayout();
            this.panelMenuFormData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormDataHead
            // 
            this.panelFormDataHead.BackColor = System.Drawing.Color.Transparent;
            this.panelFormDataHead.Controls.Add(this.labelPanelDataHeader);
            this.panelFormDataHead.Controls.Add(this.buttonPanelDataClose);
            this.panelFormDataHead.Location = new System.Drawing.Point(0, 0);
            this.panelFormDataHead.Name = "panelFormDataHead";
            this.panelFormDataHead.Size = new System.Drawing.Size(900, 34);
            this.panelFormDataHead.TabIndex = 0;
            // 
            // labelPanelDataHeader
            // 
            this.labelPanelDataHeader.AutoSize = true;
            this.labelPanelDataHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelDataHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelPanelDataHeader.Location = new System.Drawing.Point(7, 10);
            this.labelPanelDataHeader.Name = "labelPanelDataHeader";
            this.labelPanelDataHeader.Size = new System.Drawing.Size(115, 15);
            this.labelPanelDataHeader.TabIndex = 2;
            this.labelPanelDataHeader.Text = "Просмотр списков";
            // 
            // buttonPanelDataClose
            // 
            this.buttonPanelDataClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanelDataClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPanelDataClose.BackgroundImage")));
            this.buttonPanelDataClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPanelDataClose.FlatAppearance.BorderSize = 0;
            this.buttonPanelDataClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.buttonPanelDataClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonPanelDataClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPanelDataClose.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonPanelDataClose.Location = new System.Drawing.Point(871, 4);
            this.buttonPanelDataClose.Name = "buttonPanelDataClose";
            this.buttonPanelDataClose.Size = new System.Drawing.Size(24, 24);
            this.buttonPanelDataClose.TabIndex = 1;
            this.buttonPanelDataClose.TabStop = false;
            this.buttonPanelDataClose.UseVisualStyleBackColor = true;
            this.buttonPanelDataClose.Click += new System.EventHandler(this.ButtonPanelDataClose_Click);
            // 
            // panelFormData
            // 
            this.panelFormData.BackColor = System.Drawing.Color.Transparent;
            this.panelFormData.Controls.Add(this.labelStatusFormData);
            this.panelFormData.Controls.Add(this.panelControlsFormData);
            this.panelFormData.Controls.Add(this.panelMenuFormData);
            this.panelFormData.Location = new System.Drawing.Point(0, 34);
            this.panelFormData.Name = "panelFormData";
            this.panelFormData.Size = new System.Drawing.Size(900, 506);
            this.panelFormData.TabIndex = 1;
            // 
            // labelStatusFormData
            // 
            this.labelStatusFormData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatusFormData.AutoSize = true;
            this.labelStatusFormData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelStatusFormData.Location = new System.Drawing.Point(12, 479);
            this.labelStatusFormData.Name = "labelStatusFormData";
            this.labelStatusFormData.Size = new System.Drawing.Size(0, 13);
            this.labelStatusFormData.TabIndex = 6;
            // 
            // panelControlsFormData
            // 
            this.panelControlsFormData.Location = new System.Drawing.Point(211, 0);
            this.panelControlsFormData.Name = "panelControlsFormData";
            this.panelControlsFormData.Size = new System.Drawing.Size(688, 468);
            this.panelControlsFormData.TabIndex = 1;
            // 
            // panelMenuFormData
            // 
            this.panelMenuFormData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.panelMenuFormData.Controls.Add(this.buttonPilots);
            this.panelMenuFormData.Controls.Add(this.buttonSquadrons);
            this.panelMenuFormData.Location = new System.Drawing.Point(0, 0);
            this.panelMenuFormData.Name = "panelMenuFormData";
            this.panelMenuFormData.Size = new System.Drawing.Size(210, 468);
            this.panelMenuFormData.TabIndex = 0;
            // 
            // buttonPilots
            // 
            this.buttonPilots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonPilots.FlatAppearance.BorderSize = 0;
            this.buttonPilots.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            this.buttonPilots.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonPilots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPilots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonPilots.Location = new System.Drawing.Point(108, 6);
            this.buttonPilots.Name = "buttonPilots";
            this.buttonPilots.RoundedHeight = 12;
            this.buttonPilots.RoundedWidth = 12;
            this.buttonPilots.Size = new System.Drawing.Size(98, 80);
            this.buttonPilots.TabIndex = 2;
            this.buttonPilots.TabStop = false;
            this.buttonPilots.Text = "Пилоты";
            this.buttonPilots.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPilots.UseVisualStyleBackColor = false;
            this.buttonPilots.Click += new System.EventHandler(this.ButtonPilots_Click);
            // 
            // buttonSquadrons
            // 
            this.buttonSquadrons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(59)))), ((int)(((byte)(64)))));
            this.buttonSquadrons.FlatAppearance.BorderSize = 0;
            this.buttonSquadrons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(79)))), ((int)(((byte)(94)))));
            this.buttonSquadrons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.buttonSquadrons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSquadrons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonSquadrons.Location = new System.Drawing.Point(6, 6);
            this.buttonSquadrons.Name = "buttonSquadrons";
            this.buttonSquadrons.RoundedHeight = 12;
            this.buttonSquadrons.RoundedWidth = 12;
            this.buttonSquadrons.Size = new System.Drawing.Size(98, 80);
            this.buttonSquadrons.TabIndex = 1;
            this.buttonSquadrons.TabStop = false;
            this.buttonSquadrons.Text = "Эскадры";
            this.buttonSquadrons.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSquadrons.UseVisualStyleBackColor = false;
            this.buttonSquadrons.Click += new System.EventHandler(this.ButtonSquadrons_Click);
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.panelFormDataHead);
            this.Controls.Add(this.panelFormData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormData";
            this.panelFormDataHead.ResumeLayout(false);
            this.panelFormDataHead.PerformLayout();
            this.panelFormData.ResumeLayout(false);
            this.panelFormData.PerformLayout();
            this.panelMenuFormData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormDataHead;
        private System.Windows.Forms.Panel panelFormData;
        private System.Windows.Forms.Button buttonPanelDataClose;
        private System.Windows.Forms.Label labelPanelDataHeader;
        private System.Windows.Forms.Panel panelControlsFormData;
        private System.Windows.Forms.Panel panelMenuFormData;
        private System.Windows.Forms.Label labelStatusFormData;
        private ButtonRounded buttonPilots;
        private ButtonRounded buttonSquadrons;
    }
}