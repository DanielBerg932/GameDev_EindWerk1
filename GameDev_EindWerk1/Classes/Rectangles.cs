using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    public class Rectangles
    {
        List<Rectangle> rectangles;

        public void addRect(int xPos, int yPos, int width, int height)
        {
            rectangles.Add(new Rectangle(xPos, yPos, width, height));
        }

        public List<Rectangle> getRect()
        {
            return rectangles;
        }
    }
}
