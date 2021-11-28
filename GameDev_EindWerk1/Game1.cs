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
        private Texture2D _background;
        private Texture2D _runTexture;
        private Texture2D _jumpTexture;
        private Hero hero;
        private Background background;
        private int counter = 0;
        // private GameState state;
      




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
            _jumpTexture = Content.Load<Texture2D>("jumpSheet");//added jumping sprite sheet
            _background = Content.Load<Texture2D>("BG");//added background

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            background = new Background(_background);
            hero = new Hero(_runTexture, new KeyboardReader());
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
            // if (state==GameState.PLAYING)//for when we add the menu
            // {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            background.Draw(_spriteBatch);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
            //}

        }
    }
}
