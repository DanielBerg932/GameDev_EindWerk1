using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Classes
{
    public class Hero : IGameObject
    {

        Items obs = Items.GetInstance();
        CollisionManager collisionManager = new CollisionManager();
        MapBoundaries mapBoundaries = new MapBoundaries();

        Texture2D texture;
        private SpriteFont font;
        public Animiation animation;

        public Vector2 position = new Vector2(70, 610);
        public Rectangle rectPosition = new Rectangle(12, 5, 80, 125);
        private int speed = 5;

        MovePosition currentPosition = MovePosition.STOP;

        public bool IsJumping { get { return isJumping; } set { isJumping = value; }}
        private bool isJumping = false;

        public bool IsFalling { get { return isFalling; } set { isFalling = value; }}
        private bool isFalling = true;

        public double Inercia { get { return inercia; } set { inercia = value; } }
        private double inercia = 15;

        public int HP { get => hP; set { if (value! > 0) { hP = value; } else { hP = 0; } } }
        private int hP;

        //public Vector2 Position { get => position; set => position = value; }

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
            HP = 1000;
            //position = new Vector2(200, floor - animation.CurrentFrame.SourceRect.Height * 0.3f);
            //position = new Vector2(200, 400);
        }

        public void Move()
        {

            animation.userMove = animation.UserMove(); //start animation
            currentPosition = animation.EnumMoved();

            if (currentPosition == MovePosition.STOP)
            {
                //MoveTo(0, 8);
            }
            else if (currentPosition == MovePosition.JUMP_RIGHT)
            {
                isJumping = true;
                collisionManager.CollisionDetector(this, (int)(speed / 1.2), 0);
            }
            else if (currentPosition == MovePosition.JUMP_LEFT)
            {
                isJumping = true;
                collisionManager.CollisionDetector(this, -(int)(speed / 1.2), 0);
            }
            else if (currentPosition == MovePosition.GO_RIGHT)
            {
                collisionManager.CollisionDetector(this, speed, 0);
            }
            else if (currentPosition == MovePosition.GO_LEFT)
            {
                collisionManager.CollisionDetector(this, -speed, 0);

            }
            else if (currentPosition == MovePosition.JUMP)
            {
                isJumping = true;
            }
            else 
            {
                currentPosition = MovePosition.STOP;
            }

            //fall back on the floor after jump
            if (isJumping)
            {
                inercia -= 0.7;
                collisionManager.CollisionDetector(this, 0, -(int)inercia);
            }
            else 
            {
                inercia = 20;
            }

            if (isFalling && !isJumping)
            {
                collisionManager.CollisionDetector(this, 0, 15);

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (HP == 0)
            {
                //TODO
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

            }
           
        }

        public override string ToString()
        {
            return $" health:  {HP}";
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }
    }
}
