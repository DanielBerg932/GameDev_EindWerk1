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
        private Texture2D _jumpTexture;
        private Texture2D _mainMenuBG;
        private Hero hero;
        private Background playingBackground;
        private Background menuBackground;
        private int counter = 0;

        private GameState state;





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
            _jumpTexture = Content.Load<Texture2D>("jumpSheet");//added jumping sprite sheet
            _level1Background = Content.Load<Texture2D>("BG");//added background
            _flippedRunTexture = Content.Load<Texture2D>("runSheet_Flipped");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {

            state = GameState.PLAYING;
            playingBackground = new Background(_level1Background);
            menuBackground = new Background(_mainMenuBG);
            hero = new Hero(_runTexture, _flippedRunTexture, new KeyboardReader());
        }

        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine($"X={hero.position.X}\nY={hero.position.Y}");
            Debug.WriteLine($"{hero.speed.Length()}");

            Debug.WriteLine("");
            #region fullscreen logic
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.F12))
            {
                counter++;
                if (counter % 2 == 0)
                {
                    _graphics.PreferredBackBufferHeight = 600;
                    _graphics.PreferredBackBufferWidth = 800;
                }
                else
                {
                    _graphics.PreferredBackBufferHeight = 1080;
                    _graphics.PreferredBackBufferWidth = 1920;
                }
                _graphics.ApplyChanges();
            } //pressing F12 to go to fullscreen
            #endregion

            hero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            switch (state)
            {
                case GameState.MENU:
                    menuBackground.Draw(_spriteBatch);
                    break;
                case GameState.PLAYING:
                    playingBackground.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    break;
                case GameState.PAUSED:
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
