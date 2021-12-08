using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        private Vector2 direction = new Vector2(0, 0);
        private int speed = 5;
        private bool jumped = false;

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
            position = new Vector2(200, 550);

        }
        public void Move()
        {

            var currentPosition = animiation.EnumMoved();

            if (currentPosition == MovePosition.STOP)
            {
                direction = new Vector2(0, 0);
                position += direction;
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
            else if (currentPosition == MovePosition.JUMP && jumped == false)
            {
                Jump();
            }

            Gravity();


        }

        public void Jump()
        {
            position.Y -= 100;
            jumped = true;
        }

        public void Gravity()
        {
            if (jumped == true && position.Y < 550)
            {
                position.Y += 15;
            }
            else
            {
                jumped = false;
                speed = 5;
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

            KeyboardState state = Keyboard.GetState();//ask in class about refactoring
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                usedText = flippedTexture;
            else
                usedText = texture;
            spriteBatch.Draw(usedText, position, animiation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animiation.Update(gameTime);

        }
    }
}
