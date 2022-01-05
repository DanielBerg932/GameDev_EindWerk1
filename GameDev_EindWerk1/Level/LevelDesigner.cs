using GameDev_EindWerk1.Classes;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

using GameDev_EindWerk1.Classes;
using GameDev_EindWerk1.Enums;


namespace GameDev_EindWerk1.Level
{
    public class LevelDesigner
    {

        Items obs = Items.GetInstance();

        private Texture2D _tile0;
        private Texture2D _tile1;
        private Texture2D _tile2;
        private Texture2D _tile3;
        private Texture2D _tile4;
        private Texture2D _tile5;
        private Texture2D _tile6;
        private Texture2D _tile7;
        private Texture2D _tile8;
        private Texture2D _tile9;
        private Texture2D _tile10;
        private Texture2D _tile11;
        private Texture2D _tile12;
        private Texture2D _tile13;
        private Texture2D _tile14;
        private Texture2D _tile15;
        private Texture2D _tile16;
        private Texture2D _tile17;
        private Texture2D _tile18;
        private Texture2D _arrow;

        public LevelDesigner(Texture2D tile0, Texture2D tile1, Texture2D tile2, Texture2D tile3, Texture2D tile4, Texture2D tile5, Texture2D tile6, Texture2D tile7, Texture2D tile8, Texture2D tile9, Texture2D tile10, Texture2D tile11, Texture2D tile12, Texture2D tile13, Texture2D tile14, Texture2D tile15, Texture2D tile16, Texture2D tile17, Texture2D tile18, Texture2D arrow)
        {
            _tile0 = tile0;
            _tile1 = tile1;
            _tile2 = tile2;
            _tile3 = tile3;
            _tile4 = tile4;
            _tile5 = tile5;
            _tile6 = tile6;
            _tile7 = tile7;
            _tile8 = tile8;
            _tile9 = tile9;
            _tile10 = tile10;
            _tile11 = tile11;
            _tile12 = tile12;
            _tile13 = tile13;
            _tile14 = tile14;
            _tile15 = tile15;
            _tile16 = tile16;
            _tile17 = tile17;
            _tile18 = tile18;
            _arrow = arrow;
        }

        public void loadLevel(int level)
        {
            obs.level.Clear();

            if (level == 1)
            {

                /*TOP MID*/
                obs.level.Add(new ItemInfo(_tile13, new Rectangle(550, 200, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(625, 200, 75, 75)));
                obs.level.Add(new ItemInfo(_tile15, new Rectangle(700, 200, 75, 75)));

                /*LEFT*/
                obs.level.Add(new ItemInfo(_tile13, new Rectangle(50, 350, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(125, 350, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(200, 350, 75, 75)));
                obs.level.Add(new ItemInfo(_tile15, new Rectangle(275, 350, 75, 75)));

                /*MID LEFT*/
                obs.level.Add(new ItemInfo(_tile13, new Rectangle(325, 525, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(400, 525, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(475, 525, 75, 75)));
                obs.level.Add(new ItemInfo(_tile15, new Rectangle(550, 525, 75, 75)));

                /*MID RIGHT*/
                obs.level.Add(new ItemInfo(_tile13, new Rectangle(1500, 300, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(1575, 300, 75, 75)));

                /*RIGHT UNDER*/
                obs.level.Add(new ItemInfo(_tile13, new Rectangle(1050, 475, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(1125, 475, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(1200, 475, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(1175, 475, 75, 75)));
                obs.level.Add(new ItemInfo(_tile15, new Rectangle(1275, 475, 75, 75)));
                //obs.obstacleList.Add(new ItemInfo(_tile15, new Rectangle(1350, 475, 75, 75)));

                /*FINAL DOOR*/
                //obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(1050, 150, 75, 75)));
                obs.level.Add(new ItemInfo(_tile13, new Rectangle(1125, 130, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(1200, 130, 75, 75)));
                obs.level.Add(new ItemInfo(_tile15, new Rectangle(1275, 130, 75, 75)));

                /*FINAL ARROW*/
                obs.level.Add(new ItemInfo(_arrow, new Rectangle(1200, 55, 75, 75), ItemType.FINAL));

                /*GRASS*/
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(0, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(75, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(150, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(225, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(300, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(375, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(450, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(525, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(600, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(675, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile17, new Rectangle(750, 750, 75, 75), ItemType.WATER));
                obs.level.Add(new ItemInfo(_tile17, new Rectangle(825, 750, 75, 75), ItemType.WATER));
                obs.level.Add(new ItemInfo(_tile17, new Rectangle(900, 750, 75, 75), ItemType.WATER));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(975, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1050, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1125, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1200, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1275, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1350, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1425, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1500, 750, 75, 75)));
                obs.level.Add(new ItemInfo(_tile2, new Rectangle(1575, 750, 75, 75)));

                /*GROUND*/
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(0, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(75, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(150, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(225, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(300, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(375, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(450, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(525, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(600, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(675, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile18, new Rectangle(750, 825, 75, 75), ItemType.WATER));
                obs.level.Add(new ItemInfo(_tile18, new Rectangle(825, 825, 75, 75), ItemType.WATER));
                obs.level.Add(new ItemInfo(_tile18, new Rectangle(900, 825, 75, 75), ItemType.WATER));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(975, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1050, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1125, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1200, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1275, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1350, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1425, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1500, 825, 75, 75)));
                obs.level.Add(new ItemInfo(_tile5, new Rectangle(1575, 825, 75, 75)));
            }

            if (level == 2)
            {
                obs.level.Add(new ItemInfo(_tile13, new Rectangle(550, 200, 75, 75)));
                obs.level.Add(new ItemInfo(_tile14, new Rectangle(625, 200, 75, 75)));
                obs.level.Add(new ItemInfo(_tile15, new Rectangle(700, 200, 75, 75)));
            }

        }
    }
}
