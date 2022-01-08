using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameDev_EindWerk1.Enemies
{
    public class RobotEnemy : Enemy, IGameObject
    {


        public RobotEnemy(Texture2D _texture, Texture2D _deadTexture, IInputReader reader, SpriteFont _font) : base(_texture, _deadTexture, reader, _font)
        {

          
        }
    }
}
