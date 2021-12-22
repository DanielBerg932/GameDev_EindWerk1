using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_EindWerk1.Classes
{
    class Background : IGameObject
    {
        private Rectangle frame;
        private Texture2D _texture;
        private float scale = 0;
        public Background(Texture2D _texture, float scale = 0f)
        {
            this._texture = _texture;
            frame = new Rectangle(0, 0, 2000, 1143);
            this.scale = scale;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(_texture, new Vector2(0, 0), frame, Color.White);

        }


    }
}
