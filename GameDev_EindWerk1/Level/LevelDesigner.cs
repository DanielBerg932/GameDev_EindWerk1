using GameDev_EindWerk1.Classes;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


using GameDev_EindWerk1.Classes;
using Microsoft.Xna.Framework;

namespace GameDev_EindWerk1.Level
{
    class LevelDesigner
    {

        Items obs = Items.GetInstance();

        public LevelDesigner(int level, Texture2D _tile0, Texture2D _tile1, Texture2D _tile2, Texture2D _tile3, Texture2D _tile4, Texture2D _tile5, Texture2D _tile6, Texture2D _tile7, Texture2D _tile8, Texture2D _tile9, Texture2D _tile10, Texture2D _tile11, Texture2D _tile12, Texture2D _tile13, Texture2D _tile14, Texture2D _tile15, Texture2D _tile16, Texture2D _tile17, Texture2D _tile18) {

            if (level == 1) {
                /*TOP MID*/
                obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(550, 200, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(625, 200, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile15, new Rectangle(700, 200, 75, 75)));

                /*LEFT*/
                obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(50, 350, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(125, 350, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(200, 350, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile15, new Rectangle(275, 350, 75, 75)));

                /*MID LEFT*/
                obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(325, 525, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(400, 525, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(475, 525, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile15, new Rectangle(550, 525, 75, 75)));

                /*MID RIGHT*/
                obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(1500, 300, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(1575, 300, 75, 75)));

                /*RIGHT UNDER*/
                obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(1050, 475, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(1125, 475, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(1200, 475, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(1175, 475, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile15, new Rectangle(1275, 475, 75, 75)));
                //obs.obstacleList.Add(new ItemInfo(_tile15, new Rectangle(1350, 475, 75, 75)));

                /*FINAL DOOR*/
                //obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(1050, 150, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile13, new Rectangle(1125, 130, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile14, new Rectangle(1200, 130, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile15, new Rectangle(1275, 130, 75, 75)));

                /*GRASS*/
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(0, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(75, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(150, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(225, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(300, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(375, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(450, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(525, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(600, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(675, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile17, new Rectangle(750, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile17, new Rectangle(825, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile17, new Rectangle(900, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile17, new Rectangle(975, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1050, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1125, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1200, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1275, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1350, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1425, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1500, 750, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile2, new Rectangle(1575, 750, 75, 75)));

                /*GROUND*/
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(0, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(75, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(150, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(225, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(300, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(375, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(450, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(525, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(600, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(675, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile18, new Rectangle(750, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile18, new Rectangle(825, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile18, new Rectangle(900, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile18, new Rectangle(975, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1050, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1125, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1200, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1275, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1350, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1425, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1500, 825, 75, 75)));
                obs.obstacleList.Add(new ItemInfo(_tile5, new Rectangle(1575, 825, 75, 75)));
            }
            
        }

    }
}
