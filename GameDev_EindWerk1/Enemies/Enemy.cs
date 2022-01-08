using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace GameDev_EindWerk1.Enemies
{
    public abstract class Enemy
    {
        private Texture2D texture;
        private Texture2D deadTexture;
        public Animiation animation;
        private static int speed = 1;
        public Vector2 position;
        public int floor = 800;
        public int counter = 62;
        public int counter2;
        public int counterInit;

        private Vector2 target = new Vector2(speed, 0);
        private MovePosition direction;

        private int hP;
        public SpriteFont font;

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
        public Vector2 Position { get => position; set => position = value; }
        
        public int HP1 { get => hP; set => hP = value; }

        public Enemy(Texture2D _texture, Texture2D _deadTexture, IInputReader reader, SpriteFont _font)
        {

            texture = _texture;
            deadTexture = _deadTexture;
            font = _font;
            animation = new Animiation(reader, 4);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 567, 556)));
            animation.AddFrame(new AnimationFrame(new Rectangle(567, 0, 567, 556)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1114, 0, 567, 556)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1671, 0, 567, 556)));
            animation.userMove = new Vector2(1, 1);
            position = new Vector2(1100, 320);
            HP = 10500;
            counter2 = 0;
            counterInit = 0;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (this is RobotEnemy)
            {
                spriteBatch.DrawString(font, this.ToString(), new Vector2(1100, 10), Color.Yellow);

            }

            if (direction == MovePosition.GO_LEFT)
            {
                if (HP == 0)
                {
                    if (this is ZombieEnemy)
                    {
                        spriteBatch.Draw(deadTexture, position, new Rectangle(0, 0, 684, 627), Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.FlipHorizontally, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(deadTexture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.FlipHorizontally, 0f);
                    }
                }
                else
                {
                    spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.FlipHorizontally, 0f);
                }
            }
            else if (direction == MovePosition.GO_RIGHT)
            {
                if (HP == 0)
                {
                    if (this is ZombieEnemy)
                    {
                        spriteBatch.Draw(deadTexture, position, new Rectangle(0, 0, 684, 627), Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
                    }
                    else
                    {

                        spriteBatch.Draw(deadTexture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
                    }
                }
                else
                {
                    spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
                }
            }

        }

        public void Move()
        {



            if (counter >= 200)
                counter = 0;


            if (counter >= 100 && position.X + speed < 1490/*||position.X-speed==900*/)
            {
                direction = MovePosition.GO_RIGHT;
                position += target;//right

            }
            else if (counter < 100 && position.X - speed > 900)
            {
                direction = MovePosition.GO_LEFT;
                position -= target;//left

            }

            counter++;
        }



        public void Update(GameTime gameTime)
        {
            if (HP == 0 && counter2 == 0)
            {
                counter2++;
            }
            if (HP > 0)
            {
                Move();
                animation.Update(gameTime);
            }
            if (counter2 > 0 && counter2 < 2)
            {
                Move();
                animation.Update(gameTime);
                counter2++;
            }
        }

        public override string ToString()
        {
            return $" health:  {HP}";
        }
    }

}

