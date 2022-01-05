using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.Input;
using GameDev_EindWerk1.Enemies;
using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1.buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace GameDev_EindWerk1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Texture2D _enemy1Runsheet;
        private Texture2D _enemy2Runsheet;
        private Texture2D _enemy1DeadSheet;
        private Texture2D _enemy2DeadSheet;
        private SpriteBatch _spriteBatch;
        private Texture2D _level1Background;
        private Texture2D _runTexture;
        private Texture2D _playButton;
        private Texture2D _resumeButton;
        private Texture2D _quitButton;
        private Texture2D _bacbBttn;
        private Texture2D _mainMenuBG;
        private Texture2D _level1Bttn;
        private Texture2D _level2Bttn;
        private Texture2D _cursor;
        private Texture2D _kunai;
        private Hero hero;
        private RobotEnemy robot;
        private Button playBttn;
        private Button quitBttn;
        private Button level1Bttn;
        private Button level2Bttn;
        private Button backBtnn;
        private Button resumeBttn;
        private Background playingBackground;
        private Background menuBackground;
        private int counter = 0;
        private GUI gui;
        private Kunai k1;
        private Kunai k2;
        private Kunai k3;
        private GameState state;
        private Cursor cursor;
        public Rectangle clientbounds;
        public SpriteFont font;
        public Damage damage;
        public ZombieEnemy zombie;
  
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;

        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _enemy1Runsheet = Content.Load<Texture2D>(@"enemySprites\robot\runsheet");
            _enemy1DeadSheet = Content.Load<Texture2D>(@"enemysprites\robot\dead");
            _enemy2Runsheet = Content.Load<Texture2D>(@"enemySprites\dragon\zombieSheet");
            _enemy2DeadSheet = Content.Load<Texture2D>(@"enemysprites\dragon\dead");
            _playButton = Content.Load<Texture2D>(@"buttons\play_button");
            _resumeButton = Content.Load<Texture2D>(@"buttons\resume");
            _quitButton = Content.Load<Texture2D>(@"buttons\quit");
            _bacbBttn = Content.Load<Texture2D>(@"buttons\backBttn");
            _runTexture = Content.Load<Texture2D>("runSheet");//added running sprite from sheet
            _mainMenuBG = Content.Load<Texture2D>(@"buttons\plain_bg");
            _level1Background = Content.Load<Texture2D>("BG");//added background
            _cursor = Content.Load<Texture2D>("rotated_cursor");
            _level1Bttn = Content.Load<Texture2D>(@"buttons\level1");
            _level2Bttn = Content.Load<Texture2D>(@"buttons\level2");
            font = Content.Load<SpriteFont>(@"buttons\osaka");
            _kunai = Content.Load<Texture2D>("kunaiSheet");
            InitializeGameObjects();

        }

        private void InitializeGameObjects()
        {
            state = GameState.MENU;
            clientbounds = Window.ClientBounds;
            playBttn = new Button(_playButton, 201, 65, 300, 845);
            quitBttn = new Button(_quitButton, 214, 65, 700, 845);
            level1Bttn = new Button(_level1Bttn, 528, 65, 420, 655);
            level2Bttn = new Button(_level2Bttn, 537, 65, 520, 655);
            backBtnn = new Button(_bacbBttn, 531, 55, 600, 655);
            resumeBttn = new Button(_resumeButton, 374, 55, 500, 755);
            playingBackground = new Background(_level1Background);
            menuBackground = new Background(_mainMenuBG);
            hero = new Hero(_runTexture, new KeyboardReader(),_kunai, font);
            robot = new RobotEnemy(_enemy1Runsheet, _enemy1DeadSheet, new KeyboardReader(), font);
            cursor = new Cursor(_cursor, new MouseReader());
            gui = new GUI(cursor, playBttn, quitBttn, backBtnn, resumeBttn, level1Bttn, level2Bttn);
            k1 = new Kunai(_kunai, new KeyboardReader(), hero);
            k2 = new Kunai(_kunai, new KeyboardReader(), hero);
            k3 = new Kunai(_kunai, new KeyboardReader(), hero);
            zombie = new ZombieEnemy(_enemy2Runsheet, _enemy2DeadSheet, new KeyboardReader(), font);
            damage = new Damage(hero, robot,zombie, k1);
        }

        protected override void Update(GameTime gameTime)
        {
            
            state = gui.SetMenu();
            MouseState mState = Mouse.GetState();

            #region fullscreen logic

            if (Keyboard.GetState().IsKeyDown(Keys.F12))
            {
                counter++;
                if (counter % 2 == 0)
                {
                    _graphics.PreferredBackBufferHeight = 1000;
                    _graphics.PreferredBackBufferWidth = 1080;
                }
                else
                {
                    _graphics.PreferredBackBufferHeight = 1080;
                    _graphics.PreferredBackBufferWidth = 1920;
                }
                _graphics.ApplyChanges();
            } //pressing F12 to go to fullscreen
            #endregion

            switch (state)
            {
                case GameState.MENU:
                    break;
                case GameState.PLAYING:
                    damage.Update();
                    hero.Update(gameTime);
                    k1.EnemyHit = damage.EnemyHit;//sorry, dit ziet er niet goed uit. ik kon geen oplossing vinden zonder een major refactoring.
                    robot.Update(gameTime);
                    zombie.Update(gameTime);
                    k1.Update(gameTime);
                    k2.Update(gameTime);
                    k3.Update(gameTime);
                    break;
                case GameState.PAUSED:
                    break;
                case GameState.GAME_OVER:
                    break;
                case GameState.QUIT:
                    break;
                default:
                    break;
            }

            Debug.WriteLine($"hero:{hero.position}\tzombie:{zombie.position}");

            
            cursor.Update(gameTime);

            base.Update(gameTime);


        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.White);
            switch (state)
            {
                case GameState.MENU:
                    menuBackground.Draw(_spriteBatch);
                    cursor.Draw(_spriteBatch);
                    playBttn.Draw(_spriteBatch);
                    level1Bttn.Draw(_spriteBatch);
                    level2Bttn.Draw(_spriteBatch);
                    quitBttn.Draw(_spriteBatch);
                    break;
                case GameState.PLAYING:
                    playingBackground.Draw(_spriteBatch);
                    robot.Draw(_spriteBatch);
                    zombie.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    cursor.Draw(_spriteBatch);
                    k1.Draw(_spriteBatch);
                    break;
                case GameState.QUIT:
                    Exit();
                    break;
                case GameState.PAUSED:
                    menuBackground.Draw(_spriteBatch);
                    cursor.Draw(_spriteBatch);
                    backBtnn.Draw(_spriteBatch);
                    resumeBttn.Draw(_spriteBatch);
                    break;
                case GameState.GAME_OVER:
                    cursor.Draw(_spriteBatch);
                    break;
                default:
                    break;
            }





            _spriteBatch.End();
            base.Draw(gameTime);

        }


    }
}
