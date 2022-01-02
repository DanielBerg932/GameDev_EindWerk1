using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameDev_EindWerk1.Classes
{
    public class RobotEnemy : IGameObject
    {
        private Texture2D texture;
        //private Texture2D deadTexture;
        public Animiation animation;
        private static int speed = 1;
        public Vector2 position;
        private int floor = 800;
        private int counter = 62;
        int counter2;
        private Vector2 target = new Vector2(speed, 0);
        private MovePosition direction;

        private int hP;
        private SpriteFont font;

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

        public RobotEnemy(Texture2D _texture, /*Texture2D _deadTexture,*/ IInputReader reader, SpriteFont _font)
        {

            texture = _texture;
            //deadTexture = _deadTexture;
            font = _font;
            animation = new Animiation(reader, 4);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 567, 556)));
            animation.AddFrame(new AnimationFrame(new Rectangle(567, 0, 567, 556)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1114, 0, 567, 556)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1671, 0, 567, 556)));
            position = new Vector2(1100, (float)Math.Round(floor - animation.CurrentFrame.SourceRect.Height * 0.3f, MidpointRounding.ToPositiveInfinity));
            animation.userMove = new Vector2(1, 1);
            HP = 1000;
            counter2 = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, this.ToString(), new Vector2(1700, 10), Color.Yellow);

            if (direction == MovePosition.GO_LEFT)
            {
                if (HP == 0)
                {
                    //spriteBatch.Draw(deadTexture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.FlipHorizontally, 0f);
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
                    //spriteBatch.Draw(deadTexture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
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
            Move();



            animation.Update(gameTime);
            
        }

        public override string ToString()
        {
            return $" health:  {HP}";
        }
    }
}
