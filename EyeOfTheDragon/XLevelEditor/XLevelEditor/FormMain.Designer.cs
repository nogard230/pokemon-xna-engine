﻿namespace XLevelEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brushesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabProperties = new System.Windows.Forms.TabControl();
            this.tabTilesets = new System.Windows.Forms.TabPage();
            this.gbMovement = new System.Windows.Forms.GroupBox();
            this.cboWarpDirection = new System.Windows.Forms.ComboBox();
            this.mtbWarpY = new System.Windows.Forms.MaskedTextBox();
            this.mtbWarpX = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMovementType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTileset = new System.Windows.Forms.ComboBox();
            this.tbMapLocation = new System.Windows.Forms.TextBox();
            this.lblCursor = new System.Windows.Forms.Label();
            this.lblTilesets = new System.Windows.Forms.Label();
            this.lblCurrentTileset = new System.Windows.Forms.Label();
            this.nudCurrentTile = new System.Windows.Forms.NumericUpDown();
            this.gbDrawMode = new System.Windows.Forms.GroupBox();
            this.rbMoveType = new System.Windows.Forms.RadioButton();
            this.rbErase = new System.Windows.Forms.RadioButton();
            this.rbDraw = new System.Windows.Forms.RadioButton();
            this.lblTile = new System.Windows.Forms.Label();
            this.pbTilePreview = new System.Windows.Forms.PictureBox();
            this.tabLayers = new System.Windows.Forms.TabPage();
            this.clbLayers = new System.Windows.Forms.CheckedListBox();
            this.tabCharacters = new System.Windows.Forms.TabPage();
            this.tabChests = new System.Windows.Forms.TabPage();
            this.tbWarpLevel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDrawLayer = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pbTilesetPreview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mapDisplay = new XLevelEditor.MapDisplay();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabTilesets.SuspendLayout();
            this.gbMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentTile)).BeginInit();
            this.gbDrawMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTilePreview)).BeginInit();
            this.tabLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTilesetPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.tilesetToolStripMenuItem,
            this.mapLayerToolStripMenuItem,
            this.charactersToolStripMenuItem,
            this.chestsToolStripMenuItem,
            this.brushesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(910, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLevelToolStripMenuItem,
            this.openLevelToolStripMenuItem,
            this.saveLevelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitEditorToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "&Level";
            // 
            // newLevelToolStripMenuItem
            // 
            this.newLevelToolStripMenuItem.Name = "newLevelToolStripMenuItem";
            this.newLevelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newLevelToolStripMenuItem.Text = "&New Level";
            // 
            // openLevelToolStripMenuItem
            // 
            this.openLevelToolStripMenuItem.Name = "openLevelToolStripMenuItem";
            this.openLevelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openLevelToolStripMenuItem.Text = "&Open Level";
            // 
            // saveLevelToolStripMenuItem
            // 
            this.saveLevelToolStripMenuItem.Name = "saveLevelToolStripMenuItem";
            this.saveLevelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveLevelToolStripMenuItem.Text = "&Save Level";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // exitEditorToolStripMenuItem
            // 
            this.exitEditorToolStripMenuItem.Name = "exitEditorToolStripMenuItem";
            this.exitEditorToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitEditorToolStripMenuItem.Text = "E&xit Editor";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayGridToolStripMenuItem,
            this.gridColorToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // displayGridToolStripMenuItem
            // 
            this.displayGridToolStripMenuItem.Checked = true;
            this.displayGridToolStripMenuItem.CheckOnClick = true;
            this.displayGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayGridToolStripMenuItem.Name = "displayGridToolStripMenuItem";
            this.displayGridToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.displayGridToolStripMenuItem.Text = "&Display Grid";
            // 
            // gridColorToolStripMenuItem
            // 
            this.gridColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.yellowToolStripMenuItem,
            this.whiteToolStripMenuItem});
            this.gridColorToolStripMenuItem.Name = "gridColorToolStripMenuItem";
            this.gridColorToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.gridColorToolStripMenuItem.Text = "&Grid Color";
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.blackToolStripMenuItem.Text = "&Black";
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.blueToolStripMenuItem.Text = "B&lue";
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.redToolStripMenuItem.Text = "R&ed";
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.greenToolStripMenuItem.Text = "&Green";
            // 
            // yellowToolStripMenuItem
            // 
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.yellowToolStripMenuItem.Text = "&Yellow";
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Checked = true;
            this.whiteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.whiteToolStripMenuItem.Text = "&White";
            // 
            // tilesetToolStripMenuItem
            // 
            this.tilesetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilesetToolStripMenuItem,
            this.openTilesetToolStripMenuItem,
            this.saveTilesetToolStripMenuItem});
            this.tilesetToolStripMenuItem.Name = "tilesetToolStripMenuItem";
            this.tilesetToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tilesetToolStripMenuItem.Text = "&Tileset";
            // 
            // newTilesetToolStripMenuItem
            // 
            this.newTilesetToolStripMenuItem.Name = "newTilesetToolStripMenuItem";
            this.newTilesetToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newTilesetToolStripMenuItem.Text = "&New Tileset";
            // 
            // openTilesetToolStripMenuItem
            // 
            this.openTilesetToolStripMenuItem.Name = "openTilesetToolStripMenuItem";
            this.openTilesetToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openTilesetToolStripMenuItem.Text = "&Open Tileset";
            // 
            // saveTilesetToolStripMenuItem
            // 
            this.saveTilesetToolStripMenuItem.Name = "saveTilesetToolStripMenuItem";
            this.saveTilesetToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveTilesetToolStripMenuItem.Text = "&Save Tileset";
            // 
            // mapLayerToolStripMenuItem
            // 
            this.mapLayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLayerToolStripMenuItem,
            this.openLayerToolStripMenuItem,
            this.saveLayerToolStripMenuItem});
            this.mapLayerToolStripMenuItem.Name = "mapLayerToolStripMenuItem";
            this.mapLayerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.mapLayerToolStripMenuItem.Text = "&Map Layer";
            // 
            // newLayerToolStripMenuItem
            // 
            this.newLayerToolStripMenuItem.Name = "newLayerToolStripMenuItem";
            this.newLayerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newLayerToolStripMenuItem.Text = "&New Layer";
            // 
            // openLayerToolStripMenuItem
            // 
            this.openLayerToolStripMenuItem.Name = "openLayerToolStripMenuItem";
            this.openLayerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openLayerToolStripMenuItem.Text = "&Open Layer";
            // 
            // saveLayerToolStripMenuItem
            // 
            this.saveLayerToolStripMenuItem.Name = "saveLayerToolStripMenuItem";
            this.saveLayerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveLayerToolStripMenuItem.Text = "&Save Layer";
            // 
            // charactersToolStripMenuItem
            // 
            this.charactersToolStripMenuItem.Name = "charactersToolStripMenuItem";
            this.charactersToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.charactersToolStripMenuItem.Text = "&Characters";
            // 
            // chestsToolStripMenuItem
            // 
            this.chestsToolStripMenuItem.Name = "chestsToolStripMenuItem";
            this.chestsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.chestsToolStripMenuItem.Text = "C&hests";
            // 
            // brushesToolStripMenuItem
            // 
            this.brushesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x1ToolStripMenuItem,
            this.x2ToolStripMenuItem,
            this.x4ToolStripMenuItem,
            this.x8ToolStripMenuItem});
            this.brushesToolStripMenuItem.Name = "brushesToolStripMenuItem";
            this.brushesToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.brushesToolStripMenuItem.Text = "&Brushes";
            // 
            // x1ToolStripMenuItem
            // 
            this.x1ToolStripMenuItem.Checked = true;
            this.x1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.x1ToolStripMenuItem.Name = "x1ToolStripMenuItem";
            this.x1ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.x1ToolStripMenuItem.Text = "1 x 1";
            // 
            // x2ToolStripMenuItem
            // 
            this.x2ToolStripMenuItem.Name = "x2ToolStripMenuItem";
            this.x2ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.x2ToolStripMenuItem.Text = "2 x 2";
            // 
            // x4ToolStripMenuItem
            // 
            this.x4ToolStripMenuItem.Name = "x4ToolStripMenuItem";
            this.x4ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.x4ToolStripMenuItem.Text = "4 x 4";
            // 
            // x8ToolStripMenuItem
            // 
            this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            this.x8ToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.x8ToolStripMenuItem.Text = "8 x 8";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapDisplay);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabProperties);
            this.splitContainer1.Size = new System.Drawing.Size(910, 576);
            this.splitContainer1.SplitterDistance = 640;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.tabTilesets);
            this.tabProperties.Controls.Add(this.tabLayers);
            this.tabProperties.Controls.Add(this.tabCharacters);
            this.tabProperties.Controls.Add(this.tabChests);
            this.tabProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProperties.Location = new System.Drawing.Point(0, 0);
            this.tabProperties.Margin = new System.Windows.Forms.Padding(2);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.SelectedIndex = 0;
            this.tabProperties.Size = new System.Drawing.Size(267, 576);
            this.tabProperties.TabIndex = 1;
            // 
            // tabTilesets
            // 
            this.tabTilesets.Controls.Add(this.panel1);
            this.tabTilesets.Controls.Add(this.cboDrawLayer);
            this.tabTilesets.Controls.Add(this.label6);
            this.tabTilesets.Controls.Add(this.gbMovement);
            this.tabTilesets.Controls.Add(this.cboTileset);
            this.tabTilesets.Controls.Add(this.tbMapLocation);
            this.tabTilesets.Controls.Add(this.lblCursor);
            this.tabTilesets.Controls.Add(this.lblTilesets);
            this.tabTilesets.Controls.Add(this.lblCurrentTileset);
            this.tabTilesets.Controls.Add(this.nudCurrentTile);
            this.tabTilesets.Controls.Add(this.gbDrawMode);
            this.tabTilesets.Controls.Add(this.lblTile);
            this.tabTilesets.Controls.Add(this.pbTilePreview);
            this.tabTilesets.Location = new System.Drawing.Point(4, 22);
            this.tabTilesets.Margin = new System.Windows.Forms.Padding(2);
            this.tabTilesets.Name = "tabTilesets";
            this.tabTilesets.Padding = new System.Windows.Forms.Padding(2);
            this.tabTilesets.Size = new System.Drawing.Size(259, 550);
            this.tabTilesets.TabIndex = 0;
            this.tabTilesets.Text = "Tiles";
            this.tabTilesets.UseVisualStyleBackColor = true;
            // 
            // gbMovement
            // 
            this.gbMovement.Controls.Add(this.tbWarpLevel);
            this.gbMovement.Controls.Add(this.cboWarpDirection);
            this.gbMovement.Controls.Add(this.mtbWarpY);
            this.gbMovement.Controls.Add(this.mtbWarpX);
            this.gbMovement.Controls.Add(this.label5);
            this.gbMovement.Controls.Add(this.cboMovementType);
            this.gbMovement.Controls.Add(this.label4);
            this.gbMovement.Controls.Add(this.label1);
            this.gbMovement.Controls.Add(this.label3);
            this.gbMovement.Controls.Add(this.label2);
            this.gbMovement.Enabled = false;
            this.gbMovement.Location = new System.Drawing.Point(6, 326);
            this.gbMovement.Name = "gbMovement";
            this.gbMovement.Size = new System.Drawing.Size(245, 143);
            this.gbMovement.TabIndex = 16;
            this.gbMovement.TabStop = false;
            this.gbMovement.Text = "Movement Data";
            // 
            // cboWarpDirection
            // 
            this.cboWarpDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarpDirection.Enabled = false;
            this.cboWarpDirection.FormattingEnabled = true;
            this.cboWarpDirection.Location = new System.Drawing.Point(99, 111);
            this.cboWarpDirection.Name = "cboWarpDirection";
            this.cboWarpDirection.Size = new System.Drawing.Size(121, 21);
            this.cboWarpDirection.TabIndex = 19;
            // 
            // mtbWarpY
            // 
            this.mtbWarpY.Enabled = false;
            this.mtbWarpY.Location = new System.Drawing.Point(99, 64);
            this.mtbWarpY.Mask = "0000";
            this.mtbWarpY.Name = "mtbWarpY";
            this.mtbWarpY.Size = new System.Drawing.Size(121, 20);
            this.mtbWarpY.TabIndex = 17;
            // 
            // mtbWarpX
            // 
            this.mtbWarpX.Enabled = false;
            this.mtbWarpX.Location = new System.Drawing.Point(99, 36);
            this.mtbWarpX.Mask = "0000";
            this.mtbWarpX.Name = "mtbWarpX";
            this.mtbWarpX.Size = new System.Drawing.Size(121, 20);
            this.mtbWarpX.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Movement Type:";
            // 
            // cboMovementType
            // 
            this.cboMovementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMovementType.FormattingEnabled = true;
            this.cboMovementType.Location = new System.Drawing.Point(99, 11);
            this.cboMovementType.Name = "cboMovementType";
            this.cboMovementType.Size = new System.Drawing.Size(121, 21);
            this.cboMovementType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Warp Direction:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Warp X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Warp Level:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Warp Y:";
            // 
            // cboTileset
            // 
            this.cboTileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileset.FormattingEnabled = true;
            this.cboTileset.Location = new System.Drawing.Point(116, 475);
            this.cboTileset.Name = "cboTileset";
            this.cboTileset.Size = new System.Drawing.Size(135, 21);
            this.cboTileset.TabIndex = 10;
            // 
            // tbMapLocation
            // 
            this.tbMapLocation.Location = new System.Drawing.Point(6, 523);
            this.tbMapLocation.Margin = new System.Windows.Forms.Padding(2);
            this.tbMapLocation.Name = "tbMapLocation";
            this.tbMapLocation.Size = new System.Drawing.Size(249, 20);
            this.tbMapLocation.TabIndex = 9;
            // 
            // lblCursor
            // 
            this.lblCursor.Location = new System.Drawing.Point(6, 505);
            this.lblCursor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCursor.Name = "lblCursor";
            this.lblCursor.Size = new System.Drawing.Size(249, 19);
            this.lblCursor.TabIndex = 8;
            this.lblCursor.Text = "Map Location";
            this.lblCursor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTilesets
            // 
            this.lblTilesets.Location = new System.Drawing.Point(2, 476);
            this.lblTilesets.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTilesets.Name = "lblTilesets";
            this.lblTilesets.Size = new System.Drawing.Size(109, 19);
            this.lblTilesets.TabIndex = 7;
            this.lblTilesets.Text = "Tilesets";
            this.lblTilesets.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCurrentTileset
            // 
            this.lblCurrentTileset.Location = new System.Drawing.Point(64, 91);
            this.lblCurrentTileset.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentTileset.Name = "lblCurrentTileset";
            this.lblCurrentTileset.Size = new System.Drawing.Size(135, 19);
            this.lblCurrentTileset.TabIndex = 4;
            this.lblCurrentTileset.Text = "Current Tileset";
            this.lblCurrentTileset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudCurrentTile
            // 
            this.nudCurrentTile.Location = new System.Drawing.Point(5, 67);
            this.nudCurrentTile.Margin = new System.Windows.Forms.Padding(2);
            this.nudCurrentTile.Name = "nudCurrentTile";
            this.nudCurrentTile.Size = new System.Drawing.Size(97, 20);
            this.nudCurrentTile.TabIndex = 3;
            // 
            // gbDrawMode
            // 
            this.gbDrawMode.Controls.Add(this.rbMoveType);
            this.gbDrawMode.Controls.Add(this.rbErase);
            this.gbDrawMode.Controls.Add(this.rbDraw);
            this.gbDrawMode.Enabled = false;
            this.gbDrawMode.Location = new System.Drawing.Point(47, 6);
            this.gbDrawMode.Margin = new System.Windows.Forms.Padding(2);
            this.gbDrawMode.Name = "gbDrawMode";
            this.gbDrawMode.Padding = new System.Windows.Forms.Padding(2);
            this.gbDrawMode.Size = new System.Drawing.Size(205, 57);
            this.gbDrawMode.TabIndex = 2;
            this.gbDrawMode.TabStop = false;
            this.gbDrawMode.Text = "Draw Mode";
            // 
            // rbMoveType
            // 
            this.rbMoveType.AutoSize = true;
            this.rbMoveType.Location = new System.Drawing.Point(60, 16);
            this.rbMoveType.Name = "rbMoveType";
            this.rbMoveType.Size = new System.Drawing.Size(75, 17);
            this.rbMoveType.TabIndex = 2;
            this.rbMoveType.TabStop = true;
            this.rbMoveType.Text = "Movement";
            this.rbMoveType.UseVisualStyleBackColor = true;
            // 
            // rbErase
            // 
            this.rbErase.AutoSize = true;
            this.rbErase.Location = new System.Drawing.Point(5, 35);
            this.rbErase.Margin = new System.Windows.Forms.Padding(2);
            this.rbErase.Name = "rbErase";
            this.rbErase.Size = new System.Drawing.Size(52, 17);
            this.rbErase.TabIndex = 1;
            this.rbErase.Text = "Erase";
            this.rbErase.UseVisualStyleBackColor = true;
            // 
            // rbDraw
            // 
            this.rbDraw.AutoSize = true;
            this.rbDraw.Checked = true;
            this.rbDraw.Location = new System.Drawing.Point(5, 16);
            this.rbDraw.Margin = new System.Windows.Forms.Padding(2);
            this.rbDraw.Name = "rbDraw";
            this.rbDraw.Size = new System.Drawing.Size(50, 17);
            this.rbDraw.TabIndex = 0;
            this.rbDraw.TabStop = true;
            this.rbDraw.Text = "Draw";
            this.rbDraw.UseVisualStyleBackColor = true;
            // 
            // lblTile
            // 
            this.lblTile.Location = new System.Drawing.Point(5, 6);
            this.lblTile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(38, 14);
            this.lblTile.TabIndex = 1;
            this.lblTile.Text = "Tile";
            this.lblTile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbTilePreview
            // 
            this.pbTilePreview.Location = new System.Drawing.Point(5, 22);
            this.pbTilePreview.Margin = new System.Windows.Forms.Padding(2);
            this.pbTilePreview.Name = "pbTilePreview";
            this.pbTilePreview.Size = new System.Drawing.Size(38, 41);
            this.pbTilePreview.TabIndex = 0;
            this.pbTilePreview.TabStop = false;
            // 
            // tabLayers
            // 
            this.tabLayers.Controls.Add(this.clbLayers);
            this.tabLayers.Location = new System.Drawing.Point(4, 22);
            this.tabLayers.Margin = new System.Windows.Forms.Padding(2);
            this.tabLayers.Name = "tabLayers";
            this.tabLayers.Padding = new System.Windows.Forms.Padding(2);
            this.tabLayers.Size = new System.Drawing.Size(259, 550);
            this.tabLayers.TabIndex = 1;
            this.tabLayers.Text = "Map Layers";
            this.tabLayers.UseVisualStyleBackColor = true;
            // 
            // clbLayers
            // 
            this.clbLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLayers.FormattingEnabled = true;
            this.clbLayers.Location = new System.Drawing.Point(2, 2);
            this.clbLayers.Margin = new System.Windows.Forms.Padding(2);
            this.clbLayers.Name = "clbLayers";
            this.clbLayers.Size = new System.Drawing.Size(255, 546);
            this.clbLayers.TabIndex = 0;
            // 
            // tabCharacters
            // 
            this.tabCharacters.Location = new System.Drawing.Point(4, 22);
            this.tabCharacters.Margin = new System.Windows.Forms.Padding(2);
            this.tabCharacters.Name = "tabCharacters";
            this.tabCharacters.Size = new System.Drawing.Size(259, 550);
            this.tabCharacters.TabIndex = 2;
            this.tabCharacters.Text = "Characters";
            this.tabCharacters.UseVisualStyleBackColor = true;
            // 
            // tabChests
            // 
            this.tabChests.Location = new System.Drawing.Point(4, 22);
            this.tabChests.Margin = new System.Windows.Forms.Padding(2);
            this.tabChests.Name = "tabChests";
            this.tabChests.Size = new System.Drawing.Size(259, 550);
            this.tabChests.TabIndex = 3;
            this.tabChests.Text = "Chests";
            this.tabChests.UseVisualStyleBackColor = true;
            // 
            // tbWarpLevel
            // 
            this.tbWarpLevel.Enabled = false;
            this.tbWarpLevel.Location = new System.Drawing.Point(99, 85);
            this.tbWarpLevel.Name = "tbWarpLevel";
            this.tbWarpLevel.Size = new System.Drawing.Size(121, 20);
            this.tbWarpLevel.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Layer: ";
            // 
            // cboDrawLayer
            // 
            this.cboDrawLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrawLayer.FormattingEnabled = true;
            this.cboDrawLayer.Location = new System.Drawing.Point(143, 67);
            this.cboDrawLayer.Name = "cboDrawLayer";
            this.cboDrawLayer.Size = new System.Drawing.Size(108, 21);
            this.cboDrawLayer.TabIndex = 18;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbTilesetPreview
            // 
            this.pbTilesetPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbTilesetPreview.Location = new System.Drawing.Point(2, 2);
            this.pbTilesetPreview.Margin = new System.Windows.Forms.Padding(2);
            this.pbTilesetPreview.Name = "pbTilesetPreview";
            this.pbTilesetPreview.Size = new System.Drawing.Size(241, 203);
            this.pbTilesetPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbTilesetPreview.TabIndex = 5;
            this.pbTilesetPreview.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbTilesetPreview);
            this.panel1.Location = new System.Drawing.Point(6, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 207);
            this.panel1.TabIndex = 19;
            // 
            // mapDisplay
            // 
            this.mapDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapDisplay.Location = new System.Drawing.Point(0, 0);
            this.mapDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(640, 576);
            this.mapDisplay.TabIndex = 0;
            this.mapDisplay.Text = "mapDisplay1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Level Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.tabTilesets.ResumeLayout(false);
            this.tabTilesets.PerformLayout();
            this.gbMovement.ResumeLayout(false);
            this.gbMovement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentTile)).EndInit();
            this.gbDrawMode.ResumeLayout(false);
            this.gbDrawMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTilePreview)).EndInit();
            this.tabLayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTilesetPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chestsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MapDisplay mapDisplay;
        private System.Windows.Forms.TabControl tabProperties;
        private System.Windows.Forms.TabPage tabTilesets;
        private System.Windows.Forms.TabPage tabLayers;
        private System.Windows.Forms.TabPage tabCharacters;
        private System.Windows.Forms.TabPage tabChests;
        private System.Windows.Forms.Label lblTilesets;
        private System.Windows.Forms.Label lblCurrentTileset;
        private System.Windows.Forms.NumericUpDown nudCurrentTile;
        private System.Windows.Forms.GroupBox gbDrawMode;
        private System.Windows.Forms.RadioButton rbErase;
        private System.Windows.Forms.RadioButton rbDraw;
        private System.Windows.Forms.Label lblTile;
        private System.Windows.Forms.PictureBox pbTilePreview;
        private System.Windows.Forms.CheckedListBox clbLayers;
        private System.Windows.Forms.Timer controlTimer;
        private System.Windows.Forms.TextBox tbMapLocation;
        private System.Windows.Forms.Label lblCursor;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brushesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTilesetToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboTileset;
        private System.Windows.Forms.ComboBox cboMovementType;
        private System.Windows.Forms.RadioButton rbMoveType;
        private System.Windows.Forms.GroupBox gbMovement;
        private System.Windows.Forms.ComboBox cboWarpDirection;
        private System.Windows.Forms.MaskedTextBox mtbWarpY;
        private System.Windows.Forms.MaskedTextBox mtbWarpX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWarpLevel;
        private System.Windows.Forms.ComboBox cboDrawLayer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pbTilesetPreview;
        private System.Windows.Forms.Panel panel1;
    }
}