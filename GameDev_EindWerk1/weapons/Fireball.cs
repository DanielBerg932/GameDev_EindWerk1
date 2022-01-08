using GameDev_EindWerk1.hero;
using GameDev_EindWerk1.animation;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.weapons
{
    class Fireball : Kunai
    {
        public Fireball(Texture2D _texture, IInputReader reader, Hero _hero) : base(_texture, reader, _hero)
        {
            animation = new Animation(reader, 1);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 100, 100)));
        }
       




        
    }
}
