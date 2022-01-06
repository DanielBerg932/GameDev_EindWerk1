using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.weapons
{
    class Fireball : Kunai
    {
        public Fireball(Texture2D _texture, IInputReader reader, Hero _hero) : base(_texture, reader, _hero)
        {
            animation = new Animiation(reader, 1);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 100, 100)));
        }
    }
}
