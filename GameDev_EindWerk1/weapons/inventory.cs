using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.Input;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev_EindWerk1.weapons
{
    public class inventory
    {
        public static Texture2D texture;
        public static Hero hero;

        public inventory(Texture2D _texture, Hero _hero)
        {
            texture = _texture;
            hero = _hero;
        }
        public List<Kunai> kunais = new List<Kunai> { new Kunai(texture, new KeyboardReader(), hero), new Kunai(texture, new KeyboardReader(), hero), new Kunai(texture, new KeyboardReader(), hero) };
       
    }
}
