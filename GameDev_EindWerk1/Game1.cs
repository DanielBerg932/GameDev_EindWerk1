using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

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
        private MouseReader mReader;
        private Cursor cursor;





        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _runTexture = Content.Load<Texture2D>("runSheet");//added running sprite from sheet
            _mainMenuBG = Content.Load<Texture2D>("menuBG");//added running sprite from sheet
            //_jumpTexture = Content.Load<Texture2D>("jumpSheet");//added jumping sprite sheet
            _level1Background = Content.Load<Texture2D>("BG");//added background
            _flippedRunTexture = Content.Load<Texture2D>("runSheet_Flipped");
            _cursor = Content.Load<Texture2D>("cursor_sheet");
            _pauseMenu = Content.Load<Texture2D>("paused_background");
            gui = new GUI();
            mReader = new MouseReader();
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {

            state = gui.SetMenu();
            playingBackground = new Background(_level1Background);
            menuBackground = new Background(_mainMenuBG);
            pauseBackground = new Background(_pauseMenu);
            hero = new Hero(_runTexture, _flippedRunTexture, new KeyboardReader());
            /*cursor = new Cursor(_cursor);*/
        }

        protected override void Update(GameTime gameTime)
        {
            //Debug.WriteLine($"X={hero.position.X}\nY={hero.position.Y}");
            //Debug.WriteLine($"{hero.speed.Length()}");
            //Debug.WriteLine("");


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


            //if (!hero.stopMoving)
            //{
            //Debug.WriteLine($"X:{mReader.ReadInput().X}\nY:{mReader.ReadInput().Y}");
            hero.Update(gameTime);
            base.Update(gameTime);
            //Debug.WriteLine("updating");
            //}

        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            Vector2 coor = new Vector2(10, 20);
            _spriteBatch.Draw(Rectangle(50, 50, 0, 0), coor, Color.White);

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
                    break;
                case GameState.GAME_OVER:
                    break;
                default:
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
