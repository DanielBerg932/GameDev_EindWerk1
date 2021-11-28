using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameDev_EindWerk1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Texture2D _background;
        private Texture2D _jumpTexture;
        private Rectangle _individualFrame;
        private Rectangle _mainFrame;
        private int counter = 0;
        private GameState state;
        

        private int schuifOp_x = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

        }

        protected override void Initialize()
        {
            
            _individualFrame = new Rectangle(schuifOp_x, 0, 363, 458);
            _mainFrame = new Rectangle(0, 0, 2000, 1143);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("runSheet");//added running sprite from sheet
            _jumpTexture = Content.Load<Texture2D>("jumpSheet");//added jumping sprite sheet
            _background = Content.Load<Texture2D>("BG");//added background

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            // animation

        }

        protected override void Update(GameTime gameTime)
        {
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (state==GameState.PLAYING)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                _spriteBatch.Begin();
                _spriteBatch.Draw(_background, new Vector2(0, 0), _mainFrame, Color.White);
                _spriteBatch.Draw(_texture, new Vector2(0, 0), _individualFrame, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);//used online code for scaling
                _spriteBatch.Draw(_jumpTexture, new Vector2(100, 100), _individualFrame, Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
                _spriteBatch.End();

                schuifOp_x += 363;
                if (schuifOp_x > 1089)
                    schuifOp_x = 0;

                _individualFrame.X = schuifOp_x;

                base.Draw(gameTime);
            }
           
        }
    }
}
