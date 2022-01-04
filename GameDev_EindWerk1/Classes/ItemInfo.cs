using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    public class ItemInfo
    {
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }


        public ItemInfo(Texture2D text, Rectangle rect) {
            this.Texture = text;
            this.Rectangle = rect;
        }
    }
}
