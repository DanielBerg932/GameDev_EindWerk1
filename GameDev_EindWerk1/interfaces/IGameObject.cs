using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_EindWerk1.interfaces
{
    interface IGameObject
    {
        void Move(){ }
        void Update(GameTime gameTime) { } //optional method for the static game objects
        void Draw(SpriteBatch _spriteBatch);
    }
}
