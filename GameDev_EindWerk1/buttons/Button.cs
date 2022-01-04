using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.buttons
{
    class Button : IGameObject
    {
        public Rectangle rect;
        private Texture2D _texture;
        public int height;

        public Vector2 position;

        public Button(Texture2D _texture, int width, int height, int y, int x)
        {
            this._texture = _texture;
            rect = new Rectangle(0, 0, width, height);
            this.height = height;
            position = new Vector2(x, y);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, position, rect, Color.White);
        }
    }
}
