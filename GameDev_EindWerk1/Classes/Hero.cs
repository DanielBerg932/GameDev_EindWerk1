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
        Texture2D flippedTexture;
        Texture2D usedText;
        Animiation animiation;
        public Vector2 position;
        public Vector2 speed;
        public Vector2 acceleration;
       public bool stopMoving;



        public Hero(Texture2D _texture, Texture2D _flippedTexture, IInputReader reader)
        {
            this.texture = _texture;
            this.flippedTexture = _flippedTexture;
            animiation = new Animiation(reader);
            animiation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(363, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(726, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(1089, 0, 363, 458)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(1452, 0, 363, 458)));
            position = new Vector2(200, 200);
            speed = new Vector2(1, 1);
            acceleration = new Vector2(0.1f, 0.1f);
            stopMoving = false;
            
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
                stopMoving = true;
                //position = ReturnToBounds(position);

            }




            //if (position.Y < 830 && position.Y > 0)//these nums are perfect
            //{
            //    speed.Y *= -1;
            //    acceleration.Y *= -1;
            //    position += direction;
            //}

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
            
            KeyboardState state = Keyboard.GetState();//ask in class about refactoring
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                usedText = flippedTexture;
            else
                usedText = texture;
            spriteBatch.Draw(usedText, position, animiation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animiation.Update(gameTime);

        }

        public Vector2 ReturnToBounds(Vector2 current)
        {
            int toReturn = 20;
            if (current.X < 0)
            {
                return new Vector2(current.X + toReturn, current.Y);
            }
            if (current.Y < 0)
            {
                return new Vector2(current.X, current.Y + toReturn);
            }
            if (current.Y > 830)
            {
                return new Vector2(current.X, current.Y - toReturn);

            }
            if (current.X > 1780)
            {
                return new Vector2(current.X - toReturn, current.Y);
            }

            return Vector2.Zero;
        }
    }
}
