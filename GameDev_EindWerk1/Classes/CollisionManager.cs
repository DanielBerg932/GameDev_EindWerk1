using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using GameDev_EindWerk1.Enums;

namespace GameDev_EindWerk1.Classes
{
    public class CollisionManager
    {

        Items obs = Items.GetInstance();
        MapBoundaries mapBoundaries = new MapBoundaries();

        public void CollisionDetector(Hero hero, int xMovement, int yMovement)
        {

            foreach (var item in obs.level)
            {

                if ((hero.rectPosition.Bottom + hero.rectPosition.Y + hero.position.Y + yMovement >= item.Rectangle.Top) && (hero.rectPosition.Right + hero.rectPosition.X + hero.position.X + xMovement >= item.Rectangle.Left) && (hero.rectPosition.Left + hero.rectPosition.X + hero.position.X + xMovement <= item.Rectangle.Right) && (hero.rectPosition.Top + hero.rectPosition.Y + hero.position.Y + yMovement <= item.Rectangle.Bottom)) //TOP
                {
                    if (item.TileType == ItemType.WALL)
                    {
                        xMovement = 0;
                        yMovement = 0;
                        hero.IsJumping = false;
                        hero.IsFalling = true;
                    }
                    else if (item.TileType == ItemType.WATER)
                    {
                        xMovement = (int)(xMovement / 1.5);
                        yMovement = (int)(yMovement / 1.5);
                        hero.HP -= 1;
                    }
                    //else if (hero.rectPosition.Bottom + hero.rectPosition.Y + hero.position.Y + 15 > item.Rectangle.Top && (hero.rectPosition.Right / 2) + hero.position.X > item.Rectangle.Left || (hero.rectPosition.Right / 2) + hero.position.X < item.Rectangle.Right)
                    //{
                    //    hero.IsJumping = false;
                    //    Debug.WriteLine("Can jump!!");
                    //}

                }
            }

            if (hero.rectPosition.Left + hero.rectPosition.X + hero.position.X + xMovement <= mapBoundaries.Left)
            {
                xMovement = 0;
                yMovement = 0;

            }
            else if (hero.rectPosition.Right + hero.rectPosition.X + hero.position.X + xMovement >= mapBoundaries.Right)
            {
                xMovement = 0;
                yMovement = 0;
            }
            else if (hero.rectPosition.Bottom + hero.rectPosition.Y + hero.position.Y + yMovement >= mapBoundaries.Bottom)
            {
                xMovement = 0;
                yMovement = 0;
                hero.IsJumping = false;
            }
            else
            {

                hero.position.X += xMovement;
                hero.position.Y += yMovement;

            }

        }
    }
}
