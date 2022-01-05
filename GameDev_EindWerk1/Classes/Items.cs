using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    class Items
    {
        private static Items _obstacles = new Items();

        public List<ItemInfo> level1 = new List<ItemInfo>();
        public List<ItemInfo> level2 = new List<ItemInfo>();

        private Items() { }
        public static Items GetInstance()
        {
            return _obstacles;
        }
    }
}
