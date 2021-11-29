using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Classes
{
    public class Hero : IGameObject
    {
        Texture2D texture;
        Animiation animiation;
        public Vector2 position;
        public Vector2 speed;
        public Vector2 acceleration;
        // IInputReader inputReader;

        public Hero(Texture2D _texture, IInputReader reader)
        {
            this.texture = _texture;
            animiation = new Animiation(reader);
            animiation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(363, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(726, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(1089, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(1452, 0, 363, 458)));
            position = new Vector2(200, 200);
            speed = new Vector2(1, 1);
            acceleration = new Vector2(0.1f, 0.1f);
        }
        public void Move()
        {

            // position += speed;
            speed += acceleration;
            speed = Limit(speed, 5);
            if (position.X > 1780 || position.X < 0)//these nums are perfect
            {
                speed.X *= -1;
                acceleration.X *= -1;
            }
            if (position.Y > 830 || position.Y < 0)//these nums are perfect
            {
                speed.Y *= -1;
                acceleration.Y *= -1;
            }
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animiation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            var direction = animiation.UserMove();
            position += direction;
            Move();
            animiation.Update(gameTime);
        }
    }

}
