﻿using Microsoft.Xna.Framework;
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
        private Rectangle _IndividualFrame;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
           // _graphics.ToggleFullScreen(); //open on full screen
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
           
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _IndividualFrame = new Rectangle(0, 0, 363, 458);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("runSheet");//add sprite from sheet

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            animation
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_texture, new Vector2(0, 0), _IndividualFrame, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);//used online code for scaling

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
