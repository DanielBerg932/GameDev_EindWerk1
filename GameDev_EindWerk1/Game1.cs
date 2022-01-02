﻿using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.Input;
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
        private Texture2D _enemy1DeadSheet;
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
        private Kunai kunai;
        private GameState state;
        private Cursor cursor;
        public Rectangle clientbounds;
        public SpriteFont font;
        public Damage damage;
  
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
            _enemy1Runsheet = Content.Load<Texture2D>(@"enemySprites\robot\runsheet");
            //_enemy1DeadSheet = Content.Load<Texture2D>(@"enemySprites\robot\deadSheet");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playButton = Content.Load<Texture2D>(@"buttons\play_button");
            _resumeButton = Content.Load<Texture2D>(@"buttons\resume");
            _quitButton = Content.Load<Texture2D>(@"buttons\quit");
            _bacbBttn = Content.Load<Texture2D>(@"buttons\backBttn");
            _runTexture = Content.Load<Texture2D>("runSheet");//added running sprite from sheet
            _mainMenuBG = Content.Load<Texture2D>(@"buttons\plain_bg");
            //_jumpTexture = Content.Load<Texture2D>("jumpSheet");//added jumping sprite sheet
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
            hero = new Hero(_runTexture, new KeyboardReader(), font);
            robot = new RobotEnemy(_enemy1Runsheet/*,_enemy1DeadSheet*/, new KeyboardReader(), font);
            cursor = new Cursor(_cursor, new MouseReader());
            gui = new GUI(cursor, playBttn, quitBttn, backBtnn, resumeBttn, level1Bttn, level2Bttn);
            kunai = new Kunai(_kunai, new KeyboardReader(), hero, font);
            damage = new Damage(hero, robot, kunai);

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
                    //hero.checkfordamage(robot);
                    damage.Update();
                    hero.Update(gameTime);
                    kunai.EnemyHit = damage.EnemyHit;//sorry, dit ziet er niet goed uit. ik kon geen oplossing vinden zonder een major refactoring.
                    robot.Update(gameTime);
                    kunai.Update(gameTime);
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



            //debug.writeline($"hero {hero.position}\troboy {robot.position}");

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
                    hero.Draw(_spriteBatch);
                    cursor.Draw(_spriteBatch);
                    kunai.Draw(_spriteBatch);
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
