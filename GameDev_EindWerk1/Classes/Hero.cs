using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameDev_EindWerk1.Classes
{
    public class Hero : IGameObject
    {
        #region props
        Texture2D texture;
        private SpriteFont font;
        public Animiation animation;
        public Vector2 position;

        private Vector2 direction = new Vector2(0, 0);
        private int speed = 5;

        private int floor = 800;

        private bool pressed = false;
        private bool jump = false;

        private double inercia = 15;
        private int hP;

        public int HP
        {
            get => hP; set
            {
                if (value! > 0)
                {
                    hP = value;
                }
                else
                {
                    hP = 0;
                }
            }
        }

        #endregion
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, Convert.ToInt32(texture.Width * 0.28), Convert.ToInt32(texture.Height * 0.28));
            }
        }

        public Vector2 Position { get => position; set => position = value; }

        public Hero(Texture2D _texture, IInputReader reader, SpriteFont _font)
        {
            this.texture = _texture;
            font = _font;
            animation = new Animiation(reader, 3);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(363, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(726, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1089, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1452, 0, 363, 458)));
            position = new Vector2(200, (float)Math.Round(floor - animation.CurrentFrame.SourceRect.Height * 0.3f, MidpointRounding.ToPositiveInfinity));
            HP = 1000;
        }
        public void Move()
        {

            animation.userMove = animation.UserMove();//start animation
            var currentPosition = animation.EnumMoved();
            if (currentPosition == MovePosition.STOP)
            {
                direction = new Vector2(0, 0);
                position += direction;
            }
            else if (currentPosition == MovePosition.JUMP_RIGHT)
            {
                if (position.X - speed >= 0)
                {
                    if (pressed == false)
                    {
                        pressed = true;
                        jump = true;
                    }
                    direction = new Vector2(speed, 0);
                    position += direction;
                }
                else
                {
                    currentPosition = MovePosition.STOP;
                }
            }
            else if (currentPosition == MovePosition.JUMP_LEFT)
            {
                if (position.X - speed >= 0)
                {
                    if (pressed == false)
                    {
                        pressed = true;
                        jump = true;
                    }
                    direction = new Vector2(-speed, 0);
                    position += direction;
                }
                else
                {
                    currentPosition = MovePosition.STOP;
                }
            }
            else if (currentPosition == MovePosition.GO_RIGHT)
            {
                if (position.X + speed <= 1490)
                {
                    direction = new Vector2(speed, 0);
                    position += direction;
                }
                else
                {
                    currentPosition = MovePosition.STOP;
                }
            }
            else if (currentPosition == MovePosition.GO_LEFT)
            {
                if (position.X - speed >= 0)
                {
                    direction = new Vector2(-speed, 0);
                    position += direction;
                }
                else
                {
                    currentPosition = MovePosition.STOP;
                }
            }
            else if (currentPosition == MovePosition.JUMP && pressed == false)
            {
                pressed = true;
                jump = true;
            }



            //fall back on the floor after jump
            if (jump && (position.Y + animation.CurrentFrame.SourceRect.Height * 0.28) - inercia <= floor)
            {
                inercia -= 0.8;
                position.Y -= (float)inercia;
            }
            else
            {
                inercia = 15;

                jump = false;
                pressed = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (HP == 0)
            {

            }
            else
            {

                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                {
                    spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
                }
                spriteBatch.DrawString(font, this.ToString(), new Vector2(10, 10), Color.Yellow);//bring to class


            }
        }

        public override string ToString()
        {
            return $" health:  {HP}";
        }

        public void Update(GameTime gameTime)
        {
            Move();
            //Debug.WriteLine(animation.frames.Count);
            animation.Update(gameTime);
        }

        
    }
}
