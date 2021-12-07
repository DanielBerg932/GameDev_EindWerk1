using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    class Cursor : IGameObject
    {
        private Texture2D _texture;
        private Animiation animiation;
        public Vector2 position;
        private Vector2 speed;
        private Vector2 acceleration;
        private Vector2 moussePosition;

        public MouseReader mouse = new MouseReader();

        public Cursor(Texture2D _texture, IInputReader reader)
        {
            this._texture = _texture;
            animiation = new Animiation(reader);
            animiation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 84, 161)));

            position = reader.ReadInput();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, position, animiation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
        }
        public void Move()
        {
            position = mouse.ReadInput();
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animiation.Update(gameTime);
        }

    }
}
