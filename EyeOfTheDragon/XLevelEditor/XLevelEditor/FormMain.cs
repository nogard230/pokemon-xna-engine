﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GDIBitmap = System.Drawing.Bitmap;
using GDIColor = System.Drawing.Color;
using GDIImage = System.Drawing.Image;
using GDIGraphics = System.Drawing.Graphics;
using GDIGraphicsUnit = System.Drawing.GraphicsUnit;
using GDIRectangle = System.Drawing.Rectangle;

using RpgLibrary.WorldClasses;
using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;

namespace XLevelEditor
{
    public partial class FormMain : Form
    {
        #region Field Region

        SpriteBatch spriteBatch;
        LevelData levelData;

        List<Tileset> tileSets = new List<Tileset>();
        List<TilesetData> tileSetData = new List<TilesetData>();
        List<ILayer> layers = new List<ILayer>();
        MovementLayer movementLayer;
        List<GDIImage> tileSetImages = new List<GDIImage>();
        List<GDIImage> tileListImages = new List<GDIImage>();

        TileMap map;

        Camera camera;
        Engine engine;

        Point mouse = new Point();

        bool isMouseDown = false;
        bool trackMouse = false;

        Texture2D cursor;
        Texture2D grid;

        int frameCount = 0;
        int brushWidth = 1;
        Color gridColor = Color.White;

        Texture2D shadow;
        Texture2D moveTint;
        Vector2 shadowPosition = Vector2.Zero;

        #endregion

        #region Property Region

        public GraphicsDevice GraphicsDevice
        {
            get { return mapDisplay.GraphicsDevice; }
        }

        #endregion

        #region Constructor Region

        public FormMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(FormMain_Load);
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);

            tilesetToolStripMenuItem.Enabled = false;
            mapLayerToolStripMenuItem.Enabled = false;
            charactersToolStripMenuItem.Enabled = false;
            chestsToolStripMenuItem.Enabled = false;

            newLevelToolStripMenuItem.Click += new EventHandler(newLevelToolStripMenuItem_Click);
            newTilesetToolStripMenuItem.Click += new EventHandler(newTilesetToolStripMenuItem_Click);
            newLayerToolStripMenuItem.Click += new EventHandler(newLayerToolStripMenuItem_Click);

            saveLevelToolStripMenuItem.Click += new EventHandler(saveLevelToolStripMenuItem_Click);

            openLevelToolStripMenuItem.Click += new EventHandler(openLevelToolStripMenuItem_Click);

            mapDisplay.OnInitialize += new EventHandler(mapDisplay_OnInitialize);
            mapDisplay.OnDraw += new EventHandler(mapDisplay_OnDraw);

            x1ToolStripMenuItem.Click += new EventHandler(x1ToolStripMenuItem_Click);
            x2ToolStripMenuItem.Click += new EventHandler(x2ToolStripMenuItem_Click);
            x4ToolStripMenuItem.Click += new EventHandler(x4ToolStripMenuItem_Click);
            x8ToolStripMenuItem.Click += new EventHandler(x8ToolStripMenuItem_Click);

            blackToolStripMenuItem.Click += new EventHandler(blackToolStripMenuItem_Click);
            blueToolStripMenuItem.Click += new EventHandler(blueToolStripMenuItem_Click);
            redToolStripMenuItem.Click += new EventHandler(redToolStripMenuItem_Click);
            greenToolStripMenuItem.Click += new EventHandler(greenToolStripMenuItem_Click);
            yellowToolStripMenuItem.Click += new EventHandler(yellowToolStripMenuItem_Click);
            whiteToolStripMenuItem.Click += new EventHandler(whiteToolStripMenuItem_Click);

            saveTilesetToolStripMenuItem.Click += new EventHandler(saveTilesetToolStripMenuItem_Click);
            saveLayerToolStripMenuItem.Click += new EventHandler(saveLayerToolStripMenuItem_Click);

            openTilesetToolStripMenuItem.Click += new EventHandler(openTilesetToolStripMenuItem_Click);
            openLayerToolStripMenuItem.Click += new EventHandler(openLayerToolStripMenuItem_Click);

            foreach (MoveType type in Enum.GetValues(typeof(MoveType)))
                cboMovementType.Items.Add(type);
            cboMovementType.SelectedIndex = 0;

            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                cboWarpDirection.Items.Add(direction);
            cboWarpDirection.SelectedIndex = 0;

            panel1.AutoScroll = true;
        }

        #endregion

        #region Grid Color Event Handler Region

        void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.White;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = true;
        }

        void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Yellow;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = true;
            whiteToolStripMenuItem.Checked = false;
        }

        void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Green;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Red;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Blue;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Black;
            blackToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }

        #endregion

        #region Brush Event Handler Region

        void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = true;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;

            brushWidth = 1;
        }

        void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;

            brushWidth = 2;
        }

        void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = true;
            x8ToolStripMenuItem.Checked = false;

            brushWidth = 4;
        }

        void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = true;

            brushWidth = 8;
        }

        #endregion

        #region Form Event Handler Region

        void FormMain_Load(object sender, EventArgs e)
        {
            cboTileset.SelectedIndexChanged += new EventHandler(cboTileset_SelectedIndexChanged);
            nudCurrentTile.ValueChanged += new EventHandler(nudCurrentTile_ValueChanged);

            Rectangle viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);
            camera = new Camera(viewPort);

            engine = new Engine(32, 32);

            controlTimer.Tick += new EventHandler(controlTimer_Tick);
            controlTimer.Enabled = true;
            controlTimer.Interval = 17;

            tbMapLocation.TextAlign = HorizontalAlignment.Center;
            pbTilesetPreview.MouseDown += new MouseEventHandler(pbTilesetPreview_MouseDown);

            mapDisplay.SizeChanged += new EventHandler(mapDisplay_SizeChanged);
        }

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        void mapDisplay_SizeChanged(object sender, EventArgs e)
        {
            Rectangle viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);
            Vector2 cameraPosition = camera.Position;

            camera = new Camera(viewPort, cameraPosition);
            camera.LockCamera();

            mapDisplay.Invalidate();
        }

        void controlTimer_Tick(object sender, EventArgs e)
        {
            frameCount = ++frameCount % 6;
            mapDisplay.Invalidate();
            Logic();
        }

        #endregion

        #region Tile Tab Event Handler Region

        void pbTilesetPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (cboTileset.Items.Count == 0)
                return;

            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            int index = cboTileset.SelectedIndex;

            float xScale = (float)tileSetImages[index].Width /
                pbTilesetPreview.Width;

            float yScale = (float)tileSetImages[index].Height /
                pbTilesetPreview.Height;

            Point previewPoint = new Point(e.X, e.Y);

            Point tilesetPoint = new Point((int)(previewPoint.X * xScale), (int)(previewPoint.Y * yScale));

            Point tile = new Point(
                tilesetPoint.X / tileSets[index].TileWidth,
                tilesetPoint.Y / tileSets[index].TileHeight);

            nudCurrentTile.Value = tile.Y * tileSets[index].TilesWide + tile.X;
        }

        void cboTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTileset.SelectedItem != null)
            {
                nudCurrentTile.Value = 0;
                nudCurrentTile.Maximum = tileSets[cboTileset.SelectedIndex].SourceRectangles.Length - 1;
                FillPreviews();
            }
        }

        void nudCurrentTile_ValueChanged(object sender, EventArgs e)
        {
            if (cboTileset.SelectedItem != null)
            {
                FillPreviews();
            }
        }

        private void FillPreviews()
        {
            int selected = cboTileset.SelectedIndex;
            int tile = (int)nudCurrentTile.Value;

            GDIImage preview = (GDIImage)new GDIBitmap(pbTilePreview.Width, pbTilePreview.Height);

            GDIRectangle dest = new GDIRectangle(0, 0, preview.Width, preview.Height);
            GDIRectangle source = new GDIRectangle(
                tileSets[selected].SourceRectangles[tile].X,
                tileSets[selected].SourceRectangles[tile].Y,
                tileSets[selected].SourceRectangles[tile].Width,
                tileSets[selected].SourceRectangles[tile].Height);

            GDIGraphics g = GDIGraphics.FromImage(preview);
            g.DrawImage(tileSetImages[selected], dest, source, GDIGraphicsUnit.Pixel);

            pbTilesetPreview.Image = tileSetImages[selected];
            pbTilePreview.Image = preview;
            
        }

        #endregion

        #region New Menu Item Event Handler Region

        void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLevel frmNewLevel = new FormNewLevel())
            {
                frmNewLevel.ShowDialog();

                if (frmNewLevel.OKPressed)
                {
                    levelData = frmNewLevel.LevelData;
                    tilesetToolStripMenuItem.Enabled = true;
                    gbDrawMode.Enabled = true;

                    movementLayer = new MovementLayer(levelData.MapWidth, levelData.MapHeight);
                }
            }
        }

        void newTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewTileset frmNewTileset = new FormNewTileset())
            {
                frmNewTileset.ShowDialog();

                if (frmNewTileset.OKPressed)
                {
                    TilesetData data = frmNewTileset.TilesetData;

                    try
                    {
                        GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                        tileSetImages.Add(image);

                        Stream stream = new FileStream(data.TilesetImageName, FileMode.Open, FileAccess.Read);

                        Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);

                        Tileset tileset = new Tileset(
                                texture,
                                data.TilesWide,
                                data.TilesHigh,
                                data.TileWidthInPixels,
                                data.TileHeightInPixels);

                        tileSets.Add(tileset);
                        tileSetData.Add(data);

                        if (map != null)
                            map.AddTileset(tileset);

                        stream.Close();
                        stream.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading file.\n" + ex.Message, "Error reading image");
                        return;
                    }

                    cboTileset.Items.Add(data.TilesetName);

                    if (cboTileset.SelectedItem == null)
                        cboTileset.SelectedIndex = 0;

                    mapLayerToolStripMenuItem.Enabled = true;
                }
            }
        }

        void newLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLayer frmNewLayer = new FormNewLayer(levelData.MapWidth, levelData.MapHeight))
            {
                frmNewLayer.ShowDialog();

                if (frmNewLayer.OKPressed)
                {
                    MapLayerData data = frmNewLayer.MapLayerData;

                    if (clbLayers.Items.Contains(data.MapLayerName))
                    {
                        MessageBox.Show("Layer with name " + data.MapLayerName + " exists.", "Existing layer");
                        return;
                    }

                    MapLayer layer = MapLayer.FromMapLayerData(data);
                    clbLayers.Items.Add(data.MapLayerName, true);
                    clbLayers.SelectedIndex = clbLayers.Items.Count - 1;

                    cboDrawLayer.Items.Add(data.MapLayerName);
                    cboDrawLayer.SelectedIndex = clbLayers.Items.Count - 1;

                    layers.Add(layer);

                    if (map == null)
                    {
                        map = new TileMap(tileSets[0], (MapLayer)layers[0]);

                        for (int i = 1; i < tileSets.Count; i++)
                            map.AddTileset(tileSets[1]);

                        for (int i = 1; i < layers.Count; i++)
                            map.AddLayer(layers[1]);
                    }

                    charactersToolStripMenuItem.Enabled = true;
                    chestsToolStripMenuItem.Enabled = true;
                }
            }
        }

        #endregion

        #region Map Display Event Handler Region

        void mapDisplay_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            shadow = new Texture2D(GraphicsDevice, 20, 20, false, SurfaceFormat.Color);

            Color[] data = new Color[shadow.Width * shadow.Height];
            Color tint = Color.Blue;
            tint.A = 25;

            for (int i = 0; i < shadow.Width * shadow.Height; i++)
                data[i] = tint;

            shadow.SetData<Color>(data);

            mapDisplay.MouseEnter += new EventHandler(mapDisplay_MouseEnter);
            mapDisplay.MouseLeave += new EventHandler(mapDisplay_MouseLeave);
            mapDisplay.MouseMove += new MouseEventHandler(mapDisplay_MouseMove);
            mapDisplay.MouseDown += new MouseEventHandler(mapDisplay_MouseDown);
            mapDisplay.MouseUp += new MouseEventHandler(mapDisplay_MouseUp);

            try
            {
                using (Stream stream = new FileStream(@"Content\grid.png", FileMode.Open, FileAccess.Read))
                {
                    grid = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }

                using (Stream stream = new FileStream(@"Content\cursor.png", FileMode.Open, FileAccess.Read))
                {
                    cursor = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading images");
                grid = null;
                cursor = null;
            }
        }

        void mapDisplay_OnDraw(object sender, EventArgs e)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Render();
        }

        void mapDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }

        void mapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = true;
        }

        void mapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            mouse.X = e.X;
            mouse.Y = e.Y;
        }

        void mapDisplay_MouseLeave(object sender, EventArgs e)
        {
            trackMouse = false;
        }

        void mapDisplay_MouseEnter(object sender, EventArgs e)
        {
            trackMouse = true;
        }

        #endregion

        #region Display Rendering and Logic Region

        private void Render()
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                camera.Transformation);
            for (int i = 0; i < layers.Count; i++)
            {
                

                if (clbLayers.GetItemChecked(i))
                    layers[i].Draw(spriteBatch, camera, tileSets);

                Rectangle destination = new Rectangle(
                    (int)shadowPosition.X * Engine.TileWidth,
                    (int)shadowPosition.Y * Engine.TileHeight,
                    brushWidth * Engine.TileWidth,
                    brushWidth * Engine.TileHeight);

                Color tint = Color.White;
                tint.A = 1;

                spriteBatch.Draw(shadow, destination, tint);
            }

            if (rbMoveType.Checked)
            {
                gbMovement.Enabled = true;
            }
            else
            {
                gbMovement.Enabled = false;
            }

            if (cboMovementType.SelectedItem.ToString().Equals("Warp"))
            {
                mtbWarpX.Enabled = true;
                mtbWarpY.Enabled = true;
                tbWarpLevel.Enabled = true;
                cboWarpDirection.Enabled = true;
            }
            else
            {
                mtbWarpX.Enabled = false;
                mtbWarpY.Enabled = false;
                tbWarpLevel.Enabled = false;
                cboWarpDirection.Enabled = false;
            }

            if (rbMoveType.Checked)
            {
                for (int j = 0; j < movementLayer.Height; j++)
                {
                    for (int k = 0; k < movementLayer.Height; k++)
                    {
                        moveTint = new Texture2D(GraphicsDevice, 20, 20, false, SurfaceFormat.Color);
                        Color[] data = new Color[moveTint.Width * moveTint.Height];
                        MoveType type = movementLayer.GetTile(j, k).TileType;
                        Color mTint = Color.Blue;
                        if (type == MoveType.Normal)
                            continue;
                        if (type == MoveType.Grass)
                            mTint = Color.Green;
                        if (type == MoveType.Blocked)
                            mTint = Color.Red;
                        if (type == MoveType.Surf)
                            mTint = Color.Blue;
                        if (type == MoveType.Warp)
                            mTint = Color.Purple;
                        if (type == MoveType.Waterfall)
                            mTint = Color.LightBlue;
                        if (type == MoveType.Wirlpool)
                            mTint = Color.LightCyan;
                        if (type == MoveType.Dive)
                            mTint = Color.DarkBlue;

                        mTint.A = 25;

                        for (int l = 0; l < moveTint.Width * moveTint.Height; l++)
                            data[l] = mTint;

                        moveTint.SetData<Color>(data);

                        Rectangle destination = new Rectangle(
                            j * Engine.TileWidth,
                            k * Engine.TileHeight,
                            Engine.TileWidth,
                            Engine.TileHeight);

                        spriteBatch.Draw(moveTint, destination, mTint);
                    }
                }
            }

            spriteBatch.End();
            DrawDisplay();
        }

        private void DrawDisplay()
        {
            if (map == null)
                return;

            Rectangle destination = new Rectangle(
                0,
                0,
                Engine.TileWidth,
                Engine.TileHeight);

            if (displayGridToolStripMenuItem.Checked)
            {
                int maxX = mapDisplay.Width / Engine.TileWidth + 1;
                int maxY = mapDisplay.Height / Engine.TileHeight + 1;

                spriteBatch.Begin();

                for (int y = 0; y < maxY; y++)
                {
                    destination.Y = y * Engine.TileHeight;

                    for (int x = 0; x < maxX; x++)
                    {
                        destination.X = x * Engine.TileWidth;

                        spriteBatch.Draw(grid, destination, gridColor);
                    }
                }

                spriteBatch.End();
            }

            spriteBatch.Begin();

            destination.X = mouse.X;
            destination.Y = mouse.Y;

            if (rbDraw.Checked)
            {
                spriteBatch.Draw(
                    tileSets[cboTileset.SelectedIndex].Texture,
                    destination,
                    tileSets[cboTileset.SelectedIndex].SourceRectangles[(int)nudCurrentTile.Value],
                    Color.White);
            }

            Color lowAlpha = Color.White;
            lowAlpha.A = 5;

            spriteBatch.Draw(cursor, destination, lowAlpha);

            spriteBatch.End();
        }

        private void Logic()
        {
            if (layers.Count == 0)
                return;

            Vector2 position = camera.Position;

            if (trackMouse)
            {
                if (frameCount == 0)
                {
                    if (mouse.X < Engine.TileWidth)
                        position.X -= Engine.TileWidth;

                    if (mouse.X > mapDisplay.Width - Engine.TileWidth)
                        position.X += Engine.TileWidth;

                    if (mouse.Y < Engine.TileHeight)
                        position.Y -= Engine.TileHeight;

                    if (mouse.Y > mapDisplay.Height - Engine.TileHeight)
                        position.Y += Engine.TileHeight;

                    camera.Position = position;
                    camera.LockCamera();
                }

                position.X = mouse.X + camera.Position.X;
                position.Y = mouse.Y + camera.Position.Y;

                Point tile = Engine.VectorToCell(position);
                shadowPosition = new Vector2(tile.X, tile.Y);

                tbMapLocation.Text =
                    "( " + tile.X.ToString() + ", " + tile.Y.ToString() + " )";

                if (isMouseDown)
                {
                    if (rbDraw.Checked)
                        SetTiles(tile, (int)nudCurrentTile.Value, cboTileset.SelectedIndex);

                    if (rbErase.Checked)
                        SetTiles(tile, -1, -1);

                    if (rbMoveType.Checked)
                        SetMoveType(tile, (MoveType)cboMovementType.SelectedItem);
                }
            }
        }

        private void SetMoveType(Point tile, MoveType type)
        {
            if (type != MoveType.Warp)
            {
                movementLayer.SetTile(tile.X, tile.Y, type);
            }
            else
            {
                try
                {
                    int warpX = -1;
                    int warpY = -1;
                    if (!int.TryParse(mtbWarpX.Text, out warpX))
                    {
                        MessageBox.Show("Warp X must be an integer value.");
                        return;
                    }

                    if (!int.TryParse(mtbWarpY.Text, out warpY))
                    {
                        MessageBox.Show("Warp Y must be an integer value.");
                        return;
                    }

                    Direction direction = (Direction)Enum.Parse(typeof(Direction), cboWarpDirection.SelectedItem.ToString());
                    WarpTile warpTile = new WarpTile(new Point(warpX, warpY), tbWarpLevel.Text, direction);
                    movementLayer.SetTile(tile.X, tile.Y, warpTile);
                }
                catch (ArgumentException)
                {

                }
                
            }
        }

        private void SetTiles(Point tile, int tileIndex, int tileset)
        {
            int selected = cboDrawLayer.SelectedIndex;

            if (layers[selected] is MapLayer)
            {
                for (int y = 0; y < brushWidth; y++)
                {
                    if (tile.Y + y >= ((MapLayer)layers[selected]).Height)
                        break;

                    for (int x = 0; x < brushWidth; x++)
                    {
                        if (tile.X + x < ((MapLayer)layers[selected]).Width)
                            ((MapLayer)layers[selected]).SetTile(
                                tile.X + x,
                                tile.Y + y,
                                tileIndex,
                                tileset);
                    }
                }
            }
        }

        #endregion

        #region Save Menu Item Event Handler Region

        void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map == null)
                return;

            List<MapLayerData> mapLayerData = new List<MapLayerData>();

            for (int i = 0; i < clbLayers.Items.Count; i++)
            {
                if (layers[i] is MapLayer)
                {
                    MapLayerData data = new MapLayerData(
                        clbLayers.Items[i].ToString(),
                        ((MapLayer)layers[i]).Width,
                        ((MapLayer)layers[i]).Height);

                    for (int y = 0; y < ((MapLayer)layers[i]).Height; y++)
                        for (int x = 0; x < ((MapLayer)layers[i]).Width; x++)
                            data.SetTile(
                                x,
                                y,
                                ((MapLayer)layers[i]).GetTile(x, y).TileIndex,
                                ((MapLayer)layers[i]).GetTile(x, y).Tileset);

                    mapLayerData.Add(data);
                }
            }

            MovementLayerData movementData = new MovementLayerData("Movement", movementLayer.Width, movementLayer.Height);

            MapData mapData = new MapData(levelData.MapName, tileSetData, mapLayerData, movementData);
            for (int y = 0; y < movementLayer.Height; y++)
                for (int x = 0; x < movementLayer.Width; x++)
                    movementData.SetTile(x, y, movementLayer.GetTile(x, y));

            mapData.MovementLayer = movementData;

            FolderBrowserDialog fbDialog = new FolderBrowserDialog();

            fbDialog.Description = "Select Game Folder";
            fbDialog.SelectedPath = Application.StartupPath;

            DialogResult result = fbDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (!File.Exists(fbDialog.SelectedPath + @"\Game.xml"))
                {
                    MessageBox.Show("Game not found", "Error");
                    return;
                }

                string LevelPath = Path.Combine(fbDialog.SelectedPath, @"Levels\");
                string MapPath = Path.Combine(LevelPath, @"Maps\");

                if (!Directory.Exists(LevelPath))
                    Directory.CreateDirectory(LevelPath);

                if (!Directory.Exists(MapPath))
                    Directory.CreateDirectory(MapPath);

                XnaSerializer.Serialize<LevelData>(LevelPath + levelData.LevelName + ".xml", levelData);
                XnaSerializer.Serialize<MapData>(MapPath + mapData.MapName + ".xml", mapData);
            }
        }

        void saveTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tileSetData.Count == 0)
                return;

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Filter = "Tileset Data (*.tdat)|*.tdat";
            sfDialog.CheckPathExists = true;
            sfDialog.OverwritePrompt = true;
            sfDialog.ValidateNames = true;

            DialogResult result = sfDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            try
            {
                XnaSerializer.Serialize<TilesetData>(
                    sfDialog.FileName,
                    tileSetData[cboTileset.SelectedIndex]);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error saving tileset");
            }
        }

        void saveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layers.Count == 0)
                return;

            if (layers[clbLayers.SelectedIndex] is MapLayer)
            {
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.Filter = "Map Layer Data (*.mldt)|*.mldt";
                sfDialog.CheckPathExists = true;
                sfDialog.OverwritePrompt = true;
                sfDialog.ValidateNames = true;

                DialogResult result = sfDialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                MapLayerData data = new MapLayerData(
                    clbLayers.SelectedItem.ToString(),
                    ((MapLayer)layers[clbLayers.SelectedIndex]).Width,
                    ((MapLayer)layers[clbLayers.SelectedIndex]).Height);

                for (int y = 0; y < ((MapLayer)layers[clbLayers.SelectedIndex]).Height; y++)
                {
                    for (int x = 0; x < ((MapLayer)layers[clbLayers.SelectedIndex]).Width; x++)
                    {
                        data.SetTile(
                            x,
                            y,
                            ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).TileIndex,
                            ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).Tileset);
                    }
                }

                try
                {
                    XnaSerializer.Serialize<MapLayerData>(sfDialog.FileName, data);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error saving map layer data");
                }
            }
        }

        #endregion

        #region Open Menu Event Handler Region

        void openLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Level Files (*.xml)|*.xml";
            ofDialog.CheckFileExists = true;
            ofDialog.CheckPathExists = true;

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string path = Path.GetDirectoryName(ofDialog.FileName);

            LevelData newLevel = null;
            MapData mapData = null;

            try
            {
                newLevel = XnaSerializer.Deserialize<LevelData>(ofDialog.FileName);
                mapData = XnaSerializer.Deserialize<MapData>(path + @"\Maps\" + newLevel.MapName + ".xml");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading level");
                return;
            }

            tileSetImages.Clear();
            tileSetData.Clear();
            tileSets.Clear();
            layers.Clear();
            cboTileset.Items.Clear();
            clbLayers.Items.Clear();

            levelData = newLevel;

            foreach (TilesetData data in mapData.Tilesets)
            {
                Texture2D texture = null;

                tileSetData.Add(data);
                cboTileset.Items.Add(data.TilesetName);

                GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                tileSetImages.Add(image);

                using (Stream stream = new FileStream(data.TilesetImageName, FileMode.Open, FileAccess.Read))
                {
                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                    tileSets.Add(
                        new Tileset(
                            texture,
                            data.TilesWide,
                            data.TilesHigh,
                            data.TileWidthInPixels,
                            data.TileHeightInPixels));
                }
            }

            foreach (MapLayerData data in mapData.Layers)
            {
                clbLayers.Items.Add(data.MapLayerName, true);
                cboDrawLayer.Items.Add(data.MapLayerName);
                layers.Add(MapLayer.FromMapLayerData(data));
            }

            movementLayer = MovementLayer.FromMovementLayerData(mapData.MovementLayer);

            cboTileset.SelectedIndex = 0;
            clbLayers.SelectedIndex = 0;
            cboDrawLayer.SelectedIndex = 0;
            nudCurrentTile.Value = 0;

            map = new TileMap(tileSets[0], (MapLayer)layers[0]);

            for (int i = 1; i < tileSets.Count; i++)
                map.AddTileset(tileSets[i]);

            for (int i = 1; i < layers.Count; i++)
                map.AddLayer(layers[i]);

            map.AddLayer(movementLayer);

            tilesetToolStripMenuItem.Enabled = true;
            mapLayerToolStripMenuItem.Enabled = true;
            charactersToolStripMenuItem.Enabled = true;
            chestsToolStripMenuItem.Enabled = true;
            gbDrawMode.Enabled = true;
        }

        void openTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Tileset Data (*.tdat)|*.tdat";
            ofDialog.CheckPathExists = true;
            ofDialog.CheckFileExists = true;

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            TilesetData data = null;
            Texture2D texture = null;
            Tileset tileset = null;
            GDIImage image = null;

            try
            {
                data = XnaSerializer.Deserialize<TilesetData>(ofDialog.FileName);
                using (Stream stream = new FileStream(data.TilesetImageName, FileMode.Open, FileAccess.Read))
                {
                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }

                image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);

                tileset = new Tileset(
                    texture,
                    data.TilesWide,
                    data.TilesHigh,
                    data.TileWidthInPixels,
                    data.TileHeightInPixels);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading tileset");
                return;
            }

            for (int i = 0; i < cboTileset.Items.Count; i++)
            {
                if (cboTileset.Items[i].ToString() == data.TilesetName)
                {
                    MessageBox.Show("Level already contains a tileset with this name.", "Existing tileset");
                    return;
                }
            }

            tileSetData.Add(data);
            tileSets.Add(tileset);

            cboTileset.Items.Add(data.TilesetName);
            pbTilesetPreview.Image = image;
            tileSetImages.Add(image);

            cboTileset.SelectedIndex = cboTileset.Items.Count - 1;
            nudCurrentTile.Value = 0;

            mapLayerToolStripMenuItem.Enabled = true;

        }

        void openLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Map Layer Data (*.mldt)|*.mldt";
            ofDialog.CheckPathExists = true;
            ofDialog.CheckFileExists = true;

            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            MapLayerData data = null;

            try
            {
                data = XnaSerializer.Deserialize<MapLayerData>(ofDialog.FileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading map layer");
                return;
            }

            for (int i = 0; i < clbLayers.Items.Count; i++)
            {
                if (clbLayers.Items[i].ToString() == data.MapLayerName)
                {
                    MessageBox.Show("Layer by that name already exists.", "Existing layer");
                    return;
                }
            }

            clbLayers.Items.Add(data.MapLayerName, true);
            cboDrawLayer.Items.Add(data.MapLayerName);

            layers.Add(MapLayer.FromMapLayerData(data));

            if (map == null)
            {
                map = new TileMap(tileSets[0], (MapLayer)layers[0]);

                for (int i = 1; i < tileSets.Count; i++)
                    map.AddTileset(tileSets[i]);
            }
        }

        #endregion

    }
}
