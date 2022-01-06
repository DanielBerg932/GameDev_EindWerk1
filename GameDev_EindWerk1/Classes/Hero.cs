using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Collections.Generic;

using GameDev_EindWerk1.Enums;
using Microsoft.Xna.Framework.Audio;

namespace GameDev_EindWerk1.Classes
{
    public class Hero : IGameObject
    {

        Texture2D texture;
        private Texture2D deadTexture;
        private SpriteFont font;
        public Animiation animation;

        private Vector2 direction = new Vector2(0, 0);
        private int speed = 5;
        private int floor = 820;

        MovePosition currentPosition = MovePosition.STOP;

        private bool fall = true;
        public bool collison = true;

        private bool jump = false;
        private bool pressed = false;
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

        Items obs = Items.GetInstance();

        public Vector2 position = new Vector2(50, 610);
        public Rectangle rectPosition = new Rectangle(15, 8, 85, 126);
        private SoundEffectInstance insatnce;

        //public Vector2 Position { get => position; set => position = value; }

        public Hero(Texture2D _texture, Texture2D _dead, IInputReader reader, SpriteFont _font)
        {
            this.texture = _texture;
            deadTexture = _dead;
            font = _font;
            animation = new Animiation(reader, 3);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(363, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(726, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1089, 0, 363, 458)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1452, 0, 363, 458)));
            HP = 1000;
            //position = new Vector2(200, floor - animation.CurrentFrame.SourceRect.Height * 0.3f);
            //position = new Vector2(200, 400);


        }
        public void InputManager(SoundEffect _effect)
        {
            
            animation.userMove = animation.UserMove(); //start animation
            currentPosition = animation.EnumMoved();

            if (currentPosition == MovePosition.STOP)
            {
                //MoveTo(0, 8);
            }
            else if (currentPosition == MovePosition.JUMP_RIGHT)
            {
                _effect.Play();
                jump = true;
                
                Move((int)(speed / 1.2), 0);
            }
            else if (currentPosition == MovePosition.JUMP_LEFT)
            {
                _effect.Play();
                jump = true;
                Move(-(int)(speed / 1.2), 0);
            }
            else if (currentPosition == MovePosition.GO_RIGHT)
            {
                Move(speed, 0);
            }
            else if (currentPosition == MovePosition.GO_LEFT)
            {
                Move(-speed, 0);

            }
            else if (currentPosition == MovePosition.JUMP && !pressed)
            {
                _effect.Play();
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
           
               
                
                inercia -= 0.7;
                Move(0, -(int)inercia);
            }
            else
            {
                inercia = 20;
                pressed = false;
            }

            if (fall && !jump)
            {
                Move(0, 10);
            }

        }

        public void Move(int xMovement, int yMovement)
        {

            foreach (var item in obs.level)
            {
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
                    if (item.TileType == ItemType.WALL)
                    {
                        xMovement = 0;
                        yMovement = 0;
                        jump = false;
                        fall = true;
                    }
                    else if (item.TileType == ItemType.WATER)
                    {
                        xMovement = (int)(xMovement / 1.5);
                        yMovement = (int)(yMovement / 1.5);
                        HP -= 2;
                    }

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
            if (hP == 0)
            {
                spriteBatch.Draw(deadTexture, new Vector2(position.X + rectPosition.X, position.Y + rectPosition.Y), new Rectangle(0, 0, 482, 498), Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {


                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                {
                    spriteBatch.Draw(texture, new Vector2(position.X + rectPosition.X, position.Y + rectPosition.Y), animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    spriteBatch.Draw(texture, new Vector2(position.X + rectPosition.X, position.Y + rectPosition.Y), animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
                }
                spriteBatch.DrawString(font, this.ToString(), new Vector2(10, 10), Color.Yellow); //bring to class

                //foreach (var objRect in obs.level)
                //{
                //    spriteBatch.Draw(objRect.Texture, objRect.Rectangle, Color.White);
                //}

            }

        }

        public override string ToString()
        {
            return $" health:  {HP}";
        }

        public void Update(GameTime gameTime,SoundEffect _effect)
        {
            if (HP > 0)
            {

                InputManager(_effect);
                animation.Update(gameTime);
            }
        }
    }
}
