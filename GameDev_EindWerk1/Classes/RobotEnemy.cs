using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Classes
{
    class RobotEnemy : IGameObject
    {
        private Texture2D texture;
        private Animiation animiation;
        private Vector2 position;

        public RobotEnemy(Texture2D _texture, IInputReader reader)
        {

            this.texture = _texture;

            animiation = new Animiation(reader);
            animiation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 567, 556)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(567, 0, 567, 556)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(1114, 0, 567, 556)));
            animiation.AddFrame(new AnimationFrame(new Rectangle(1671, 0, 567, 556)));
            position = new Vector2(800, 550);


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animiation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animiation.Update(gameTime);
        }
    }
}
