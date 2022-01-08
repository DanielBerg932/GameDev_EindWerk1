using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.collision
{
    class MapBoundaries
    {
        

        private int top = 0;
        public int Top
        {
            get { return top; }
            set {
                if (top < bottom)
                {
                    top = value;
                }
                else
                {
                    return;
                }
            }
        }

        private int bottom = 820;
        public int Bottom
        {
            get { return bottom; }
            set {
                if (top < bottom)
                {
                    bottom = value;
                }
                else
                {
                    return;
                }
            }
        }

        private int right = 1585;
        public int Right
        {
            get { return right; }
            set {
                if (right > left)
                {
                    right = value;
                }
                else
                {
                    return;
                }
            }
        }

        private int left;
        public int Left
        {
            get { return left; }
            set {
                if (left < right)
                {
                    left = value;
                }
                else
                {
                    return;
                }
            }
        }



    }
}
