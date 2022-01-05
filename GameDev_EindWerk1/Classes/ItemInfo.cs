using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using GameDev_EindWerk1.Enums;

namespace GameDev_EindWerk1.Classes
{
    public class ItemInfo
    {
        private Texture2D tile13;

        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }
        public ItemType TileType { get; set; }

        public ItemInfo(Texture2D text, Rectangle rect, ItemType tiletype = ItemType.WALL) {
            this.Texture = text;
            this.Rectangle = rect;
            this.TileType = tiletype;
        }

    }
}
