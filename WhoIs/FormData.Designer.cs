
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
            this.panelMenuFormData = new System.Windows.Forms.Panel();
            this.panelDataFormData = new System.Windows.Forms.Panel();
            this.panelDataSquadMyFormData = new System.Windows.Forms.Panel();
            this.dataGridViewSquadMy = new System.Windows.Forms.DataGridView();
            this.labelViewWIPE = new System.Windows.Forms.Label();
            this.panelFormDataHead.SuspendLayout();
            this.panelFormData.SuspendLayout();
            this.panelDataFormData.SuspendLayout();
            this.panelDataSquadMyFormData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSquadMy)).BeginInit();
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
            this.panelFormData.Controls.Add(this.panelDataFormData);
            this.panelFormData.Controls.Add(this.panelMenuFormData);
            this.panelFormData.Location = new System.Drawing.Point(0, 34);
            this.panelFormData.Name = "panelFormData";
            this.panelFormData.Size = new System.Drawing.Size(900, 506);
            this.panelFormData.TabIndex = 1;
            // 
            // panelMenuFormData
            // 
            this.panelMenuFormData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.panelMenuFormData.Location = new System.Drawing.Point(0, 0);
            this.panelMenuFormData.Name = "panelMenuFormData";
            this.panelMenuFormData.Size = new System.Drawing.Size(212, 468);
            this.panelMenuFormData.TabIndex = 0;
            // 
            // panelDataFormData
            // 
            this.panelDataFormData.Controls.Add(this.panelDataSquadMyFormData);
            this.panelDataFormData.Location = new System.Drawing.Point(213, 0);
            this.panelDataFormData.Name = "panelDataFormData";
            this.panelDataFormData.Size = new System.Drawing.Size(688, 468);
            this.panelDataFormData.TabIndex = 1;
            // 
            // panelDataSquadMyFormData
            // 
            this.panelDataSquadMyFormData.Controls.Add(this.labelViewWIPE);
            this.panelDataSquadMyFormData.Controls.Add(this.dataGridViewSquadMy);
            this.panelDataSquadMyFormData.Location = new System.Drawing.Point(0, 0);
            this.panelDataSquadMyFormData.Name = "panelDataSquadMyFormData";
            this.panelDataSquadMyFormData.Size = new System.Drawing.Size(676, 466);
            this.panelDataSquadMyFormData.TabIndex = 0;
            // 
            // dataGridViewSquadMy
            // 
            this.dataGridViewSquadMy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.dataGridViewSquadMy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewSquadMy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSquadMy.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewSquadMy.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSquadMy.Name = "dataGridViewSquadMy";
            this.dataGridViewSquadMy.Size = new System.Drawing.Size(676, 436);
            this.dataGridViewSquadMy.TabIndex = 0;
            // 
            // labelViewWIPE
            // 
            this.labelViewWIPE.AutoSize = true;
            this.labelViewWIPE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.labelViewWIPE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.labelViewWIPE.Location = new System.Drawing.Point(4, 9);
            this.labelViewWIPE.Name = "labelViewWIPE";
            this.labelViewWIPE.Size = new System.Drawing.Size(133, 15);
            this.labelViewWIPE.TabIndex = 1;
            this.labelViewWIPE.Text = "Список пилотов WIPE";
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.panelFormData);
            this.Controls.Add(this.panelFormDataHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormData";
            this.Text = "FormData";
            this.panelFormDataHead.ResumeLayout(false);
            this.panelFormDataHead.PerformLayout();
            this.panelFormData.ResumeLayout(false);
            this.panelDataFormData.ResumeLayout(false);
            this.panelDataSquadMyFormData.ResumeLayout(false);
            this.panelDataSquadMyFormData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSquadMy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormDataHead;
        private System.Windows.Forms.Panel panelFormData;
        private System.Windows.Forms.Button buttonPanelDataClose;
        private System.Windows.Forms.Label labelPanelDataHeader;
        private System.Windows.Forms.Panel panelMenuFormData;
        private System.Windows.Forms.Panel panelDataFormData;
        private System.Windows.Forms.Panel panelDataSquadMyFormData;
        private System.Windows.Forms.DataGridView dataGridViewSquadMy;
        private System.Windows.Forms.Label labelViewWIPE;
    }
}