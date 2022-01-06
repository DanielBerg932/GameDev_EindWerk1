using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.Input;
using GameDev_EindWerk1.Enemies;
using GameDev_EindWerk1.buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

using GameDev_EindWerk1.Level;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using GameDev_EindWerk1.weapons;

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
        private Texture2D _heroDead;
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
        private Hero hero2;
        private RobotEnemy robot;
        private Button playBttn;
        private Button quitBttn;
        private Button level1Bttn;
        private Button level2Bttn;
        private Button backBtnn;
        private Button resumeBttn;
        private Background playingBackground;
        private Background menuBackground;
        private Background gameOverBackground;
        private int counter = 0;
        private GUI gui;
        private Kunai kunai;
        private Kunai k2;
        private GameState state;
        private Cursor cursor;
        public Rectangle clientbounds;
        public SpriteFont font;
        public Damage damage;
        private Damage damage2;
        public ZombieEnemy zombie;
        public LevelDesigner levelDesigner;
        private Fireball fireball;
        private Texture2D _tile0;
        private Song song;
        private Texture2D _fireball;
        private Texture2D _gameOver;
        private Texture2D _tile1;
        private Texture2D _tile2;
        private Texture2D _tile3;
        private Texture2D _tile4;
        private Texture2D _tile5;
        private Texture2D _tile6;
        private Texture2D _tile7;
        private Texture2D _tile8;
        private Texture2D _tile9;
        private Texture2D _tile10;
        private Texture2D _tile11;
        private Texture2D _tile12;
        private Texture2D _tile13;
        private Texture2D _tile14;
        private Texture2D _tile15;
        private Texture2D _tile16;
        private Texture2D _tile17;
        private Texture2D _tile18;
        private Texture2D _arrow;
        SoundEffect effect;
        private Song general;
        private Song levl1Song;
       
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
            _heroDead = Content.Load<Texture2D>("heroDead");//added running sprite from sheet
            _mainMenuBG = Content.Load<Texture2D>(@"buttons\plain_bg");
            _level1Background = Content.Load<Texture2D>("BG");//added background
            _cursor = Content.Load<Texture2D>("rotated_cursor");
            _level1Bttn = Content.Load<Texture2D>(@"buttons\level1");
            _level2Bttn = Content.Load<Texture2D>(@"buttons\level2");
            effect = Content.Load<SoundEffect>(@"music\jump");
            song= Content.Load<Song>(@"music\Boss Theme");
            _fireball = Content.Load<Texture2D>(@"weapons\fireball");
            _gameOver = Content.Load<Texture2D>("GameOver");

            _tile1 = Content.Load<Texture2D>("1");
            _tile2 = Content.Load<Texture2D>("2");
            _tile3 = Content.Load<Texture2D>("3");
            _tile4 = Content.Load<Texture2D>("4");
            _tile5 = Content.Load<Texture2D>("5");
            _tile6 = Content.Load<Texture2D>("6");
            _tile7 = Content.Load<Texture2D>("7");
            _tile8 = Content.Load<Texture2D>("8");
            _tile9 = Content.Load<Texture2D>("9");
            _tile10 = Content.Load<Texture2D>("10");
            _tile11 = Content.Load<Texture2D>("11");
            _tile12 = Content.Load<Texture2D>("12");
            _tile13 = Content.Load<Texture2D>("13");
            _tile14 = Content.Load<Texture2D>("14");
            _tile15 = Content.Load<Texture2D>("15");
            _tile16 = Content.Load<Texture2D>("16");
            _tile17 = Content.Load<Texture2D>("17");
            _tile18 = Content.Load<Texture2D>("18");
            _arrow = Content.Load<Texture2D>("arrow");


            /*obs.obstacleList.Add(new ItemInfo(_tile3, new Rectangle(300, 750, 100, 100)));*/


            font = Content.Load<SpriteFont>(@"buttons\osaka");
            _kunai = Content.Load<Texture2D>("kunaiSheet");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
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
            gameOverBackground = new Background(_gameOver);
            hero = new Hero(_runTexture, _heroDead, new KeyboardReader(), font);
            hero2 = new Hero(_runTexture, _heroDead, new KeyboardReader(), font);
            robot = new RobotEnemy(_enemy1Runsheet, _enemy1DeadSheet, new KeyboardReader(), font);
            cursor = new Cursor(_cursor, new MouseReader());
            gui = new GUI(cursor,hero,hero2, playBttn, quitBttn, backBtnn, resumeBttn, level1Bttn, level2Bttn);
            kunai = new Kunai(_kunai, new KeyboardReader(), hero2);
            levelDesigner = new LevelDesigner(_tile0, _tile1, _tile2, _tile3, _tile4, _tile5, _tile6, _tile7, _tile8, _tile9, _tile10, _tile11, _tile12, _tile13, _tile14, _tile15, _tile16, _tile17, _tile18, _arrow);
            fireball = new Fireball(_fireball,new KeyboardReader(),hero);

            zombie = new ZombieEnemy(_enemy2Runsheet, _enemy2DeadSheet, new KeyboardReader(), font);
            damage = new Damage();
         
            



        }

        protected override void Update(GameTime gameTime)
        {
            state = gui.SetMenu();
            
            MouseState mState = Mouse.GetState();
            cursor.Update(gameTime);
            #region fullscreen logic

            if (Keyboard.GetState().IsKeyDown(Keys.F12))
            {


                _graphics.PreferredBackBufferHeight = 890;
                _graphics.PreferredBackBufferWidth = 1600;

                _graphics.ApplyChanges();
            } //pressing F12 to go to fullscreen
            #endregion

            switch (state)
            {
                case GameState.LEVEL1:
                    levelDesigner.loadLevel(1);
                    hero2.Update(gameTime,effect);
                    zombie.Update(gameTime);
                    kunai.EnemyHit = damage.EnemyHit;
                    kunai.Update(gameTime);
                    damage.Update(hero2,zombie,kunai,state);
                    break;
                case GameState.LEVEL2:
                    levelDesigner.loadLevel(2);
                    hero.Update(gameTime,effect);
                    robot.Update(gameTime);
                    fireball.Update(gameTime);
                    damage.Update(hero, robot, fireball, state);
                    break;
                case GameState.GAME_OVER:
                    base.Update(gameTime);
                    break;
            }



            
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

                case GameState.LEVEL1:
                    playingBackground.Draw(_spriteBatch);
                    levelDesigner.Draw(_spriteBatch);
                    hero2.Draw(_spriteBatch);
                    zombie.Draw(_spriteBatch);
                    kunai.Draw(_spriteBatch);
                    break;
                case GameState.LEVEL2:
                    playingBackground.Draw(_spriteBatch);
                    levelDesigner.Draw(_spriteBatch);
                    robot.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    fireball.Draw(_spriteBatch);
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
                    gameOverBackground.Draw(_spriteBatch);
                    cursor.Draw(_spriteBatch);
                    quitBttn.Draw(_spriteBatch);
                    break;

                default:
                    break;
            }


            _spriteBatch.End();
            base.Draw(gameTime);

        }


    }
}
