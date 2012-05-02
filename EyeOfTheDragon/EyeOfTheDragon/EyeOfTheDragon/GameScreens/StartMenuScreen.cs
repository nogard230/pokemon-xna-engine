using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using XRpgLibrary;
using XRpgLibrary.Controls;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;

using XRpgLibrary.ItemClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.CharacterClasses;
using XRpgLibrary.CharacterClasses;

using EyesOfTheDragon.Components;
using RpgLibrary.SkillClasses;
using RpgLibrary.WorldClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        #region Field region

        Texture2D backgroundImage;
        Texture2D pixel;
        LinkLabel startGame;
        LinkLabel loadGame;
        LinkLabel BattleTest;
        LinkLabel exitGame;
        float maxItemWidth = 0f;
        Texture2D characterImage;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;

            pixel = Content.Load<Texture2D>(@"Backgrounds\pixel");

            backgroundImage = Content.Load<Texture2D>(@"Backgrounds\menubackground");

            characterImage = Content.Load<Texture2D>(@"PlayerSprites\hero");

            startGame = new LinkLabel();
            startGame.Text = "New Game";
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            startGame.Selected += new EventHandler(menuItem_Selected);

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "Continue";
            loadGame.Size = loadGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.Selected += menuItem_Selected;

            ControlManager.Add(loadGame);

            BattleTest = new LinkLabel();
            BattleTest.Text = "Test Battle System";
            BattleTest.Size = BattleTest.SpriteFont.MeasureString(BattleTest.Text);
            BattleTest.Selected += menuItem_Selected;

            ControlManager.Add(BattleTest);

            exitGame = new LinkLabel();
            exitGame.Text = "Quit";
            exitGame.Size = exitGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.Selected += menuItem_Selected;

            ControlManager.Add(exitGame);

            ControlManager.NextControl();

            ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);

            Vector2 position = new Vector2(350, 300);
            foreach (Control c in ControlManager)
            {
                if (c is LinkLabel)
                {
                    if (c.Size.X > maxItemWidth)
                        maxItemWidth = c.Size.X;

                    c.Position = position;
                    position.Y += c.Size.Y + 5f;
                }
            }

            ControlManager_FocusChanged(startGame, null);
        }

        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {

            if (sender == startGame)
                InputHandler.Flush();

                CreatePlayer();
                CreateWorld();

                Transition(ChangeType.Change, GameRef.GamePlayScreen);

            if (sender == loadGame)
                Transition(ChangeType.Push, GameRef.LoadGameScreen);

            if (sender == BattleTest)
            {
                GameRef.BattleScreen = new BattleScreen(Game, StateManager);
                Transition(ChangeType.Push, GameRef.BattleScreen);
            }

            if (sender == exitGame)
                GameRef.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(
                backgroundImage,
                GameRef.ScreenRectangle,
                Color.White);

            GameRef.SpriteBatch.Draw(pixel, new Rectangle(50, 50, 924, 668), Color.LightBlue);

            ControlManager.Draw(GameRef.SpriteBatch);

            if (Transitioning)
            {
                FadeBackBufferTo(GameRef.SpriteBatch, Color.Black, (float)transitionTimer.Milliseconds / 750f, GameRef.ScreenRectangle);
            }

            GameRef.SpriteBatch.End();
        }

        private void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 4, 6);
            animations.Add(AnimationKey.Up, animation);

            animation = new Animation(3, 32, 32, 4, 38);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 4, 70);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 4, 102);
            animations.Add(AnimationKey.Right, animation);

            AnimatedSprite sprite = new AnimatedSprite(
                characterImage,
                animations);
            EntityGender gender = EntityGender.Male;

            //if (genderSelector.SelectedIndex == 1)
            //    gender = EntityGender.Female;

            Entity entity = new Entity(
                "Hero",
                DataManager.EntityData["Fighter"],
                gender,
                EntityType.Character);

            foreach (string s in DataManager.SkillData.Keys)
            {
                Skill skill = Skill.FromSkillData(DataManager.SkillData[s]);
                entity.Skills.Add(s, skill);
            }

            Character character = new Character(entity, sprite);

            GamePlayScreen.Player = new Player(GameRef, character);
        }

        private void CreateWorld()
        {
            //Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            //Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            //tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset2");
            //Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            //MapLayer layer = new MapLayer(100, 100);

            //for (int y = 0; y < layer.Height; y++)
            //{
            //    for (int x = 0; x < layer.Width; x++)
            //    {
            //        Tile tile = new Tile(0, 0);

            //        layer.SetTile(x, y, tile);
            //    }
            //}

            //MapLayer splatter = new MapLayer(100, 100);

            //Random random = new Random();

            //for (int i = 0; i < 100; i++)
            //{
            //    int x = random.Next(0, 100);
            //    int y = random.Next(0, 100);
            //    int index = random.Next(2, 14);

            //    Tile tile = new Tile(index, 0);
            //    splatter.SetTile(x, y, tile);
            //}

            //splatter.SetTile(1, 0, new Tile(0, 1));
            //splatter.SetTile(2, 0, new Tile(2, 1));
            //splatter.SetTile(3, 0, new Tile(0, 1));

            //MovementLayer movement = new MovementLayer(100, 100);

            //for (int y = 0; y < layer.Height; y++)
            //{
            //    for (int x = 0; x < layer.Width; x++)
            //    {
            //        movement.SetTile(x, y, (MoveType.Normal));
            //    }
            //}
            //WarpTile warpTile = new WarpTile(new Point(6, 6), null, Direction.Left);
            //movement.SetTile(2, 0, warpTile);

            //TileMap map = new TileMap(tileset1, layer);
            //map.AddTileset(tileset2);
            //map.AddLayer(splatter);
            //map.AddLayer(movement);

            //Level level = new Level(map);

            //ChestData chestData = Game.Content.Load<ChestData>(@"Game\Chests\Potion");

            //Chest chest = new Chest(chestData);

            //BaseSprite chestSprite = new BaseSprite(
            //    containers,
            //    new Rectangle(0, 0, 32, 32),
            //    new Point(10, 10));

            //ItemSprite itemSprite = new ItemSprite(
            //    chest,
            //    chestSprite);
            //level.Items.Add(itemSprite);

            LevelData levelData = Game.Content.Load<LevelData>(@"Game\Levels\MTest");
            MapData mapData = Game.Content.Load<MapData>(@"Game\Levels\Maps\MTest");

            List<Tileset> tilesets = new List<Tileset>();
            List<MapLayer> layers = new List<MapLayer>();
            TileMap map;

            foreach (TilesetData tileSetData in mapData.Tilesets)
            {
                Stream stream = new FileStream(tileSetData.TilesetImageName, FileMode.Open, FileAccess.Read);
                Texture2D image = Texture2D.FromStream(GraphicsDevice, stream);
                Tileset tileset = new Tileset(image, tileSetData.TilesWide, tileSetData.TilesHigh, tileSetData.TileWidthInPixels, tileSetData.TileHeightInPixels);
                tilesets.Add(tileset);
            }

            foreach (MapLayerData layerData in mapData.Layers)
            {
                layers.Add(MapLayer.FromMapLayerData(layerData));
            }

            map = new TileMap(tilesets[0], (MapLayer)layers[0]);

            for (int i = 1; i < tilesets.Count; i++)
                map.AddTileset(tilesets[i]);

            for (int i = 1; i < layers.Count; i++)
                map.AddLayer(layers[i]);

            map.AddLayer(MovementLayer.FromMovementLayerData(mapData.MovementLayer));

            Level level = new Level(map);

            level.Characters.Add(GamePlayScreen.Player.Character);

            World world = new World(GameRef, GameRef.ScreenRectangle);
            world.Levels.Add(level);
            world.CurrentLevel = 0;

            foreach (MiscItemData data in DataManager.MiscData.Values)
            {
                world.ItemManager.AddMiscItem(new MiscItem(data));
            }

            foreach (RecoveryItemData data in DataManager.RecoveryData.Values)
            {
                world.ItemManager.AddRecoveryItem(new RecoveryItem(data));
            }

            foreach (TMItemData data in DataManager.TMData.Values)
            {
                world.ItemManager.AddTM(new TMItem(data));
            }

            foreach (BerryItemData data in DataManager.BerryData.Values)
            {
                world.ItemManager.AddBerryItem(new BerryItem(data));
            }

            foreach (KeyItemData data in DataManager.KeyItemData.Values)
            {
                world.ItemManager.AddKeyItem(new KeyItem(data));
            }

            GamePlayScreen.World = world;
        }

        #endregion

        #region Game State Method Region
        #endregion

    }
}
