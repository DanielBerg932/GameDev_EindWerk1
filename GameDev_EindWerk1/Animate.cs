using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1
{
    public class Animate
    {
        Texture2D _animationTextture;
        Texture2D _texture;
        public Animate(Texture2D texture) 
        { 
            
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_texture, new Vector2(0, 0), _individualFrame, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);//used online code for scaling
        }


    }
}
