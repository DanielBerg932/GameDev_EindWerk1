using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    class Cursor
    {
        private Texture2D _texture;
        private Animiation animiation;
        private Vector2 position;
        private IInputReader reader;
        private Vector2 speed;
        private Vector2 acceleration;

        /*public Cursor(Texture2D _texture)
        {
            this._texture = _texture;
            reader = new MouseReader();
            animiation = new Animiation(reader);
            animiation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 80)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 80)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 80)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 80)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(160, 0, 32, 80)));
            position = reader.ReadInput();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, position, animiation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
        }
        public void Move()
        {

            var direction = animiation.UserMove();

            // position += direction;
            // position += speed;




            speed += acceleration;
            speed = Limit(speed, 50);
            if (position.X <= 1780 && position.X > 0 && position.Y < 830 && position.Y > 0)//these nums are perfect
            {
                speed.X *= -1;
                acceleration.X *= -1;
                position += direction;
            }
            else
            {
                // stopMoving = true;
                //position = ReturnToBounds(position);

            }




            //if (position.Y < 830 && position.Y > 0)//these nums are perfect
            //{
            //    speed.Y *= -1;
            //    acceleration.Y *= -1;
            //    position += direction;
            //}

        }
        public void Update(GameTime gameTime)
        {
            Move();
            animiation.Update(gameTime);
        }
        public Vector2 Limit(Vector2 vec, float max)
        {
            if (vec.Length() > max)
            {
                var ratio = max / vec.Length();
                vec.X *= ratio;
                vec.Y *= ratio;
            }
            return vec;
        }

        */
    }
}
