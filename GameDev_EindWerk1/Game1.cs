using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameDev_EindWerk1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Texture2D _texture;
        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Rectangle _mainFrame;

        private Animate hero;
      
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.ToggleFullScreen(); //open on full screen
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _mainFrame = new Rectangle(0, 0, 2000, 1143);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("runSheet");//added sprite from sheet
            _background = Content.Load<Texture2D>("BG");//added background
            
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Animate(_texture);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, new Vector2(0, 0), _mainFrame, Color.White);
            hero.Draw(_spriteBatch);

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
