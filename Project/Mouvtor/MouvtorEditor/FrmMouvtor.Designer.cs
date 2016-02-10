namespace MouvtorEditor
{
    partial class FrmEditor
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
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.TSBOpen = new System.Windows.Forms.ToolStripButton();
            this.TSBSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBRecordAndStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TSCBXInputDevice = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBLine = new System.Windows.Forms.ToolStripButton();
            this.TSBPencil = new System.Windows.Forms.ToolStripButton();
            this.TSBCursor = new System.Windows.Forms.ToolStripButton();
            this.TSBRectangleSelection = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.TSMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMISave = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIAction = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIStopRecording = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMITools = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIDrawLine = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPencil = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIMouse = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIRectangleSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSLRecordInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.DZEditor = new MouvtorCommon.DrawingZone();
            this.ToolStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBOpen,
            this.TSBSave,
            this.toolStripSeparator1,
            this.TSBRecordAndStop,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.TSCBXInputDevice,
            this.toolStripSeparator3,
            this.TSBLine,
            this.TSBPencil,
            this.TSBCursor,
            this.TSBRectangleSelection});
            this.ToolStrip.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(784, 25);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "TSMenu";
            // 
            // TSBOpen
            // 
            this.TSBOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBOpen.Image = global::MouvtorEditor.Properties.Resources.folder_stand;
            this.TSBOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBOpen.Name = "TSBOpen";
            this.TSBOpen.Size = new System.Drawing.Size(23, 22);
            this.TSBOpen.Text = "Open";
            // 
            // TSBSave
            // 
            this.TSBSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBSave.Image = global::MouvtorEditor.Properties.Resources.diskette;
            this.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBSave.Name = "TSBSave";
            this.TSBSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TSBSave.Size = new System.Drawing.Size(23, 22);
            this.TSBSave.Text = "Save";
            this.TSBSave.Click += new System.EventHandler(this.TSBSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSBRecordAndStop
            // 
            this.TSBRecordAndStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBRecordAndStop.Image = global::MouvtorEditor.Properties.Resources.bullet_red;
            this.TSBRecordAndStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBRecordAndStop.Name = "TSBRecordAndStop";
            this.TSBRecordAndStop.Size = new System.Drawing.Size(23, 22);
            this.TSBRecordAndStop.Text = "Record";
            this.TSBRecordAndStop.Click += new System.EventHandler(this.TSBRecordAndStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Input device :";
            // 
            // TSCBXInputDevice
            // 
            this.TSCBXInputDevice.Items.AddRange(new object[] {
            "Mouse",
            "3D Mouse",
            "Leap motion",
            "Touch screen"});
            this.TSCBXInputDevice.Name = "TSCBXInputDevice";
            this.TSCBXInputDevice.Size = new System.Drawing.Size(121, 25);
            this.TSCBXInputDevice.Text = "Input device";
            this.TSCBXInputDevice.SelectedIndexChanged += new System.EventHandler(this.TSCBXInputDevice_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // TSBLine
            // 
            this.TSBLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBLine.Image = global::MouvtorEditor.Properties.Resources.draw_line;
            this.TSBLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBLine.Name = "TSBLine";
            this.TSBLine.Size = new System.Drawing.Size(23, 22);
            this.TSBLine.Text = "Draw lines";
            // 
            // TSBPencil
            // 
            this.TSBPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBPencil.Image = global::MouvtorEditor.Properties.Resources.pencil;
            this.TSBPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBPencil.Name = "TSBPencil";
            this.TSBPencil.Size = new System.Drawing.Size(23, 22);
            this.TSBPencil.Text = "Pencil";
            this.TSBPencil.Click += new System.EventHandler(this.TSBPencil_Click);
            // 
            // TSBCursor
            // 
            this.TSBCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBCursor.Image = global::MouvtorEditor.Properties.Resources.cursor;
            this.TSBCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBCursor.Name = "TSBCursor";
            this.TSBCursor.Size = new System.Drawing.Size(23, 22);
            this.TSBCursor.Text = "Cursor";
            // 
            // TSBRectangleSelection
            // 
            this.TSBRectangleSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBRectangleSelection.Image = global::MouvtorEditor.Properties.Resources.select_restangular;
            this.TSBRectangleSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBRectangleSelection.Name = "TSBRectangleSelection";
            this.TSBRectangleSelection.Size = new System.Drawing.Size(23, 22);
            this.TSBRectangleSelection.Text = "Rectangle selection";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIFile,
            this.TSMIAction,
            this.TSMITools});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // TSMIFile
            // 
            this.TSMIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIOpen,
            this.toolStripMenuItem1,
            this.TSMISave,
            this.TSMISaveAs,
            this.toolStripMenuItem2,
            this.TSMIQuit});
            this.TSMIFile.Name = "TSMIFile";
            this.TSMIFile.Size = new System.Drawing.Size(35, 20);
            this.TSMIFile.Text = "&File";
            // 
            // TSMIOpen
            // 
            this.TSMIOpen.Image = global::MouvtorEditor.Properties.Resources.folder_stand;
            this.TSMIOpen.Name = "TSMIOpen";
            this.TSMIOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.TSMIOpen.Size = new System.Drawing.Size(171, 22);
            this.TSMIOpen.Text = "&Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // TSMISave
            // 
            this.TSMISave.Image = global::MouvtorEditor.Properties.Resources.diskette;
            this.TSMISave.Name = "TSMISave";
            this.TSMISave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.TSMISave.Size = new System.Drawing.Size(171, 22);
            this.TSMISave.Text = "&Save";
            // 
            // TSMISaveAs
            // 
            this.TSMISaveAs.Image = global::MouvtorEditor.Properties.Resources.file_save_as;
            this.TSMISaveAs.Name = "TSMISaveAs";
            this.TSMISaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.TSMISaveAs.Size = new System.Drawing.Size(171, 22);
            this.TSMISaveAs.Text = "Sav&e as";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
            // 
            // TSMIQuit
            // 
            this.TSMIQuit.Image = global::MouvtorEditor.Properties.Resources.cross;
            this.TSMIQuit.Name = "TSMIQuit";
            this.TSMIQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.TSMIQuit.Size = new System.Drawing.Size(171, 22);
            this.TSMIQuit.Text = "&Quit";
            this.TSMIQuit.Click += new System.EventHandler(this.TSMIQuit_Click);
            // 
            // TSMIAction
            // 
            this.TSMIAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIRecord,
            this.TSMIStopRecording});
            this.TSMIAction.Name = "TSMIAction";
            this.TSMIAction.Size = new System.Drawing.Size(49, 20);
            this.TSMIAction.Text = "A&ction";
            // 
            // TSMIRecord
            // 
            this.TSMIRecord.Image = global::MouvtorEditor.Properties.Resources.bullet_red;
            this.TSMIRecord.Name = "TSMIRecord";
            this.TSMIRecord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.TSMIRecord.Size = new System.Drawing.Size(182, 22);
            this.TSMIRecord.Text = "&Record";
            this.TSMIRecord.Click += new System.EventHandler(this.TSMIRecord_Click);
            // 
            // TSMIStopRecording
            // 
            this.TSMIStopRecording.Image = global::MouvtorEditor.Properties.Resources.shape_square;
            this.TSMIStopRecording.Name = "TSMIStopRecording";
            this.TSMIStopRecording.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.TSMIStopRecording.Size = new System.Drawing.Size(182, 22);
            this.TSMIStopRecording.Text = "S&top recording";
            this.TSMIStopRecording.Click += new System.EventHandler(this.TSMIStopRecording_Click);
            // 
            // TSMITools
            // 
            this.TSMITools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIDrawLine,
            this.TSMIPencil,
            this.TSMIMouse,
            this.TSMIRectangleSelection});
            this.TSMITools.Name = "TSMITools";
            this.TSMITools.Size = new System.Drawing.Size(44, 20);
            this.TSMITools.Text = "Too&ls";
            // 
            // TSMIDrawLine
            // 
            this.TSMIDrawLine.Image = global::MouvtorEditor.Properties.Resources.draw_line;
            this.TSMIDrawLine.Name = "TSMIDrawLine";
            this.TSMIDrawLine.ShortcutKeyDisplayString = "";
            this.TSMIDrawLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.TSMIDrawLine.Size = new System.Drawing.Size(206, 22);
            this.TSMIDrawLine.Text = "Draw &line";
            // 
            // TSMIPencil
            // 
            this.TSMIPencil.Image = global::MouvtorEditor.Properties.Resources.pencil;
            this.TSMIPencil.Name = "TSMIPencil";
            this.TSMIPencil.ShortcutKeyDisplayString = "";
            this.TSMIPencil.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.TSMIPencil.Size = new System.Drawing.Size(206, 22);
            this.TSMIPencil.Text = "&Pencil";
            // 
            // TSMIMouse
            // 
            this.TSMIMouse.Image = global::MouvtorEditor.Properties.Resources.cursor;
            this.TSMIMouse.Name = "TSMIMouse";
            this.TSMIMouse.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.TSMIMouse.Size = new System.Drawing.Size(206, 22);
            this.TSMIMouse.Text = "&Mouse";
            // 
            // TSMIRectangleSelection
            // 
            this.TSMIRectangleSelection.Image = global::MouvtorEditor.Properties.Resources.select_restangular;
            this.TSMIRectangleSelection.Name = "TSMIRectangleSelection";
            this.TSMIRectangleSelection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.TSMIRectangleSelection.Size = new System.Drawing.Size(206, 22);
            this.TSMIRectangleSelection.Text = "Rect&angle selection";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSLRecordInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSSLRecordInfo
            // 
            this.TSSLRecordInfo.BackColor = System.Drawing.SystemColors.Control;
            this.TSSLRecordInfo.Name = "TSSLRecordInfo";
            this.TSSLRecordInfo.Size = new System.Drawing.Size(58, 17);
            this.TSSLRecordInfo.Text = "Not record";
            // 
            // DZEditor
            // 
            this.DZEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DZEditor.IsDrawing = false;
            this.DZEditor.Location = new System.Drawing.Point(0, 49);
            this.DZEditor.Name = "DZEditor";
            this.DZEditor.Size = new System.Drawing.Size(784, 491);
            this.DZEditor.TabIndex = 3;
            this.DZEditor.SizeChanged += new System.EventHandler(this.DZEditor_SizeChanged);
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.DZEditor);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FrmEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouvtor Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton TSBSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSBRecordAndStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSBOpen;
        private System.Windows.Forms.ToolStripButton TSBPencil;
        private System.Windows.Forms.ToolStripButton TSBLine;
        private System.Windows.Forms.ToolStripButton TSBCursor;
        private System.Windows.Forms.ToolStripButton TSBRectangleSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox TSCBXInputDevice;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TSMIFile;
        private System.Windows.Forms.ToolStripMenuItem TSMIAction;
        private System.Windows.Forms.ToolStripMenuItem TSMITools;
        private System.Windows.Forms.ToolStripMenuItem TSMIOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TSMISave;
        private System.Windows.Forms.ToolStripMenuItem TSMISaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TSMIQuit;
        private System.Windows.Forms.ToolStripMenuItem TSMIRecord;
        private System.Windows.Forms.ToolStripMenuItem TSMIStopRecording;
        private System.Windows.Forms.ToolStripMenuItem TSMIDrawLine;
        private System.Windows.Forms.ToolStripMenuItem TSMIPencil;
        private System.Windows.Forms.ToolStripMenuItem TSMIMouse;
        private System.Windows.Forms.ToolStripMenuItem TSMIRectangleSelection;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TSSLRecordInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private MouvtorCommon.DrawingZone DZEditor;
    }
}

