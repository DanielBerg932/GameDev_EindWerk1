using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

using Newtonsoft.Json;

namespace GameDev_EindWerk1.Classes
{
    public class Hero : IGameObject
    {
        Texture2D texture;
        Texture2D flippedTexture;
        Texture2D usedText;
        Animiation animation;

        private Vector2 direction = new Vector2(0, 0);
        private int speed = 5;
        private int floor = 820;

        private bool fall = false;
        private double fallSpeed = 10;

        private bool jump = false;
        private bool pressed = false;
        private double inercia = 15;

        Items obs = Items.GetInstance();

        private Vector2 position = new Vector2(200, 400);
        private Rectangle rectPosition = new Rectangle(15, 8, 85, 126);

        public Hero(Texture2D _texture, Texture2D _flippedTexture, IInputReader reader)
        {
            this.texture = _texture;
            this.flippedTexture = _flippedTexture;
            animation = new Animiation(reader);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(363, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(726, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1089, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1452, 0, 363, 458)));
            //position = new Vector2(200, floor - animation.CurrentFrame.SourceRect.Height * 0.3f);
            //position = new Vector2(200, 400);


        }
        public void Move()
        {
            MovePosition currentPosition = animation.EnumMoved();
            if (currentPosition == MovePosition.STOP)
            {
                //MoveTo(0, 8);
            }
            else if (currentPosition == MovePosition.JUMP_RIGHT)
            {
                jump = true;
                MoveTo(speed, 0);
            }
            else if (currentPosition == MovePosition.JUMP_LEFT)
            {
                jump = true;
                MoveTo(-speed, 0);
            }
            else if (currentPosition == MovePosition.GO_RIGHT)
            {
                MoveTo(speed, 0);
            }
            else if (currentPosition == MovePosition.GO_LEFT)
            {
                MoveTo(-speed, 0);

            }
            else if (currentPosition == MovePosition.JUMP && !pressed)
            {
                jump = true;
                pressed = true;
            }
            else 
            {
                currentPosition = MovePosition.STOP;
            }

            //fall back on the floor after jump
            if (jump)
            {
                inercia -= 0.8;
                MoveTo(0, -(int)inercia);
            }
            else 
            {
                inercia = 22;
                pressed = false;
            }

            if (fall && !jump)
            {
                fallSpeed -= 0.8;
                MoveTo(0, 10);
            }
            
        }

        public void MoveTo(int xMovement, int yMovement)
        {

            foreach (var item in obs.obstacleList) {
                //if ((rectPosition.Right + position.X + xMovement >= item.Rect.Left) &&
                //    (rectPosition.Bottom + position.Y + yMovement >= item.Rect.Top) &&
                //    (rectPosition.Top + position.Y + yMovement <= item.Rect.Bottom) &&
                //    (rectPosition.Left + position.X + xMovement <= item.Rect.Right))
                //{

                //    xMovement = 0;
                //    yMovement = 0;
                //    jump = false;
                //}

                if ((rectPosition.Bottom + position.Y + yMovement >= item.Rectangle.Top) && (rectPosition.Right + position.X + xMovement >= item.Rectangle.Left) && (rectPosition.Left + position.X + xMovement <= item.Rectangle.Right) && (rectPosition.Top + position.Y + yMovement <= item.Rectangle.Bottom)) //TOP
                {
                    xMovement = 0;
                    yMovement = 0;
                    jump = false;
                    fall = true;
                }
            }

            if (rectPosition.Left + position.X + xMovement <= 0)
            {
                xMovement = 0;
                yMovement = 0;

            }
            else if (rectPosition.Right + position.X + xMovement >= 1580)
            {
                xMovement = 0;
                yMovement = 0;
            }
            else if (rectPosition.Bottom + position.Y + yMovement >= floor)
            {
                xMovement = 0;
                yMovement = 0;
                jump = false;
            }
            else
            {
                position.X += xMovement;
                position.Y += yMovement;

                /*rectPosition.X += xMovement;*/
                /*rectPosition.Y += yMovement;*/
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                usedText = flippedTexture;
            else
                usedText = texture;
            spriteBatch.Draw(usedText, new Vector2(position.X + rectPosition.X, position.Y + rectPosition.Y), animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }
    }
}
