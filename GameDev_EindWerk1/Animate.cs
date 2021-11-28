using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1
{
    public class Animate
    {

        private Texture2D _animationTexture;
        private Rectangle _individualFrame;

        private int schuifOp_x = 0;

        /*SLOW ANIMATION DOWN
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        */


        public Animate(Texture2D texture) 
        {
            _animationTexture = texture;
            _individualFrame = new Rectangle(schuifOp_x, 0, 363, 458);
        }

        public void Update(GameTime gameTime)
        {
            schuifOp_x += 363;
            if (schuifOp_x > 1089)
                schuifOp_x = 0;
            _individualFrame.X = schuifOp_x;
            
            /*SLOW ANIMATION DOWN
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 1;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
            */

        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_animationTexture, new Vector2(0, 0), _individualFrame, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

    }
}
