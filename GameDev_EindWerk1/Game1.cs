using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.Input;
using GameDev_EindWerk1.interfaces;
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

        private SpriteBatch _spriteBatch;
        private Texture2D _level1Background;
        private Texture2D _runTexture;
        private Texture2D _flippedRunTexture;
        //private Texture2D _jumpTexture;
        private Texture2D _pauseMenu;
        private Texture2D _mainMenuBG;
        private Texture2D _cursor;
        private Hero hero;
        private Background playingBackground;
        private Background menuBackground;
        private Background pauseBackground;
        private int counter = 0;
        private GUI gui;
        private GameState state;
        private MouseReader _mReader;
        private Cursor cursor;

        public Rectangles rectList = new Rectangles();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            Rectangle clientbounds = Window.ClientBounds;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _runTexture = Content.Load<Texture2D>("runSheet");//added running sprite from sheet
            _mainMenuBG = Content.Load<Texture2D>("main-menu");//added running sprite from sheet
            //_jumpTexture = Content.Load<Texture2D>("jumpSheet");//added jumping sprite sheet
            _level1Background = Content.Load<Texture2D>("BG");//added background
            _flippedRunTexture = Content.Load<Texture2D>("runSheet_Flipped");
            _cursor = Content.Load<Texture2D>("rotated_cursor");
            _pauseMenu = Content.Load<Texture2D>("paused_background");
            gui = new GUI(cursor);
            
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            _mReader = new MouseReader();
            playingBackground = new Background(_level1Background);
            menuBackground = new Background(_mainMenuBG);
            pauseBackground = new Background(_pauseMenu);
            hero = new Hero(_runTexture, _flippedRunTexture, new KeyboardReader());
            cursor = new Cursor(_cursor,_mReader);

        }

        protected override void Update(GameTime gameTime)
        {
           


            #region fullscreen logic
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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


           
            state = gui.SetMenu();
            MouseState mState = Mouse.GetState();
           
            hero.Update(gameTime);
            cursor.Update(gameTime);
            base.Update(gameTime);
            

        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            Vector2 coor = new Vector2(10, 20);
            //_spriteBatch.Draw(, coor, Color.White);

            GraphicsDevice.Clear(Color.Black);
            switch (state)
            {
                case GameState.MENU:
                    menuBackground.Draw(_spriteBatch);
                    /*cursor.Draw(_spriteBatch);*/
                    break;
                case GameState.PLAYING:
                    playingBackground.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    break;
                case GameState.PAUSED:
                    pauseBackground.Draw(_spriteBatch);
                    cursor.Draw(_spriteBatch);
                    break;
                case GameState.GAME_OVER:
                    cursor.Draw(_spriteBatch);
                    break;
                default:
                    break;
            }

            Texture2D whiteRectangle;
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
            
            _spriteBatch.Draw(whiteRectangle, new Rectangle(500, 800 - 100, 50, 100), Color.White);

            /*Texture2D redRectangle;
            redRectangle = new Texture2D(GraphicsDevice, 1, 1);
            redRectangle.SetData(new[] { Color.White });
            _spriteBatch.Draw(redRectangle, , Color.Red);*/






            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
