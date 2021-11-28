using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1
{
    public class AnimationFrame
    {
        public Rectangle SourceRect { get; set; }

        public AnimationFrame(Rectangle rect)
        {
            SourceRect = rect;
        }
    }
}
