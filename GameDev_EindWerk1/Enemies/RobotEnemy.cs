using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1;
using GameDev_EindWerk1.Classes;
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

            //texture = _texture;
            //deadTexture = _deadTexture;
            //font = _font;
            //animation = new Animiation(reader, 4);
            //animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 567, 556)));
            //animation.AddFrame(new AnimationFrame(new Rectangle(567, 0, 567, 556)));
            //animation.AddFrame(new AnimationFrame(new Rectangle(1114, 0, 567, 556)));
            //animation.AddFrame(new AnimationFrame(new Rectangle(1671, 0, 567, 556)));
            //position = new Vector2(1100, (float)Math.Round(floor - animation.CurrentFrame.SourceRect.Height * 0.3f, MidpointRounding.ToPositiveInfinity));
            //animation.userMove = new Vector2(1, 1);
            //HP = 1000;
            //counter2 = 0;
        }
    }
}
