namespace MouvtorPlayer
{
    partial class FrmMouvtorPlayer
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.TSMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIAction = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIStopRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBPlayPause = new System.Windows.Forms.ToolStripButton();
            this.TSBRecordAndStop = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSLRecordInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSLPlayInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSLInpitDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIFile,
            this.TSMIAction});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(836, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // TSMIFile
            // 
            this.TSMIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIOpen,
            this.toolStripMenuItem1,
            this.TSMIQuit});
            this.TSMIFile.Name = "TSMIFile";
            this.TSMIFile.Size = new System.Drawing.Size(37, 20);
            this.TSMIFile.Text = "&File";
            // 
            // TSMIOpen
            // 
            this.TSMIOpen.Image = global::MouvtorPlayer.Properties.Resources.folder_stand;
            this.TSMIOpen.Name = "TSMIOpen";
            this.TSMIOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.TSMIOpen.Size = new System.Drawing.Size(152, 22);
            this.TSMIOpen.Text = "&Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // TSMIQuit
            // 
            this.TSMIQuit.Image = global::MouvtorPlayer.Properties.Resources.cross;
            this.TSMIQuit.Name = "TSMIQuit";
            this.TSMIQuit.ShortcutKeyDisplayString = "Ctrl+Q";
            this.TSMIQuit.Size = new System.Drawing.Size(152, 22);
            this.TSMIQuit.Text = "&Quit";
            this.TSMIQuit.Click += new System.EventHandler(this.TSMIQuit_Click);
            // 
            // TSMIAction
            // 
            this.TSMIAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIPlay,
            this.pauseToolStripMenuItem,
            this.toolStripMenuItem2,
            this.TSMIRecord,
            this.TSMIStopRecord});
            this.TSMIAction.Name = "TSMIAction";
            this.TSMIAction.Size = new System.Drawing.Size(54, 20);
            this.TSMIAction.Text = "&Action";
            // 
            // TSMIPlay
            // 
            this.TSMIPlay.Image = global::MouvtorPlayer.Properties.Resources.control_play_blue;
            this.TSMIPlay.Name = "TSMIPlay";
            this.TSMIPlay.ShortcutKeyDisplayString = "Ctrl+P";
            this.TSMIPlay.Size = new System.Drawing.Size(176, 22);
            this.TSMIPlay.Text = "&Play";
            this.TSMIPlay.Click += new System.EventHandler(this.TSMIPlay_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Image = global::MouvtorPlayer.Properties.Resources.control_pause_blue;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.pauseToolStripMenuItem.Text = "Pa&use";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
            // 
            // TSMIRecord
            // 
            this.TSMIRecord.Image = global::MouvtorPlayer.Properties.Resources.bullet_red;
            this.TSMIRecord.Name = "TSMIRecord";
            this.TSMIRecord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.TSMIRecord.Size = new System.Drawing.Size(176, 22);
            this.TSMIRecord.Text = "&Record";
            this.TSMIRecord.Click += new System.EventHandler(this.TSMIRecord_Click);
            // 
            // TSMIStopRecord
            // 
            this.TSMIStopRecord.Image = global::MouvtorPlayer.Properties.Resources.shape_square;
            this.TSMIStopRecord.Name = "TSMIStopRecord";
            this.TSMIStopRecord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.TSMIStopRecord.Size = new System.Drawing.Size(176, 22);
            this.TSMIStopRecord.Text = "S&top record";
            this.TSMIStopRecord.Click += new System.EventHandler(this.TSMIStopRecord_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBOpen,
            this.toolStripSeparator1,
            this.TSBPlayPause,
            this.TSBRecordAndStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(836, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBOpen
            // 
            this.TSBOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBOpen.Image = global::MouvtorPlayer.Properties.Resources.folder_stand;
            this.TSBOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBOpen.Name = "TSBOpen";
            this.TSBOpen.Size = new System.Drawing.Size(23, 22);
            this.TSBOpen.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSBPlayPause
            // 
            this.TSBPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBPlayPause.Image = global::MouvtorPlayer.Properties.Resources.control_play_blue;
            this.TSBPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBPlayPause.Name = "TSBPlayPause";
            this.TSBPlayPause.Size = new System.Drawing.Size(23, 22);
            this.TSBPlayPause.Text = "Play";
            this.TSBPlayPause.Click += new System.EventHandler(this.TSBPlayPause_Click);
            // 
            // TSBRecordAndStop
            // 
            this.TSBRecordAndStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBRecordAndStop.Image = global::MouvtorPlayer.Properties.Resources.bullet_red;
            this.TSBRecordAndStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBRecordAndStop.Name = "TSBRecordAndStop";
            this.TSBRecordAndStop.Size = new System.Drawing.Size(23, 22);
            this.TSBRecordAndStop.Text = "Record";
            this.TSBRecordAndStop.Click += new System.EventHandler(this.TSBRecordAndStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSLRecordInfo,
            this.TSSLPlayInfo,
            this.TSSLInpitDeviceType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(836, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSSLRecordInfo
            // 
            this.TSSLRecordInfo.Name = "TSSLRecordInfo";
            this.TSSLRecordInfo.Size = new System.Drawing.Size(64, 17);
            this.TSSLRecordInfo.Text = "Not record";
            // 
            // TSSLPlayInfo
            // 
            this.TSSLPlayInfo.Name = "TSSLPlayInfo";
            this.TSSLPlayInfo.Size = new System.Drawing.Size(65, 17);
            this.TSSLPlayInfo.Text = "Not played";
            // 
            // TSSLInpitDeviceType
            // 
            this.TSSLInpitDeviceType.Name = "TSSLInpitDeviceType";
            this.TSSLInpitDeviceType.Size = new System.Drawing.Size(108, 17);
            this.TSSLInpitDeviceType.Text = "Input Device Type :";
            // 
            // FrmMouvtorPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 509);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FrmMouvtorPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouvtor Player";
            this.Load += new System.EventHandler(this.FrmMouvtorPlayer_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TSMIFile;
        private System.Windows.Forms.ToolStripMenuItem TSMIOpen;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMIQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TSMIAction;
        private System.Windows.Forms.ToolStripMenuItem TSMIPlay;
        private System.Windows.Forms.ToolStripMenuItem TSMIRecord;
        private System.Windows.Forms.ToolStripMenuItem TSMIStopRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TSBOpen;
        private System.Windows.Forms.ToolStripButton TSBPlayPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSBRecordAndStop;
        private System.Windows.Forms.ToolStripStatusLabel TSSLRecordInfo;
        private System.Windows.Forms.ToolStripStatusLabel TSSLPlayInfo;
        private System.Windows.Forms.ToolStripStatusLabel TSSLInpitDeviceType;
    }
}

