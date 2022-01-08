using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Level
{
    class Items
    {
        private static Items _obstacles = new Items();

        public List<ItemInfo> level = new List<ItemInfo>();

        private Items() { }
        public static Items GetInstance()
        {
            return _obstacles;
        }
    }
}
