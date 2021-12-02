using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Input
{
    class MouseReader
    {
        public MouseState state = Mouse.GetState();
        public Vector2 ReadInput()
        {
            return new Vector2(state.X, state.Y);
        }
    }
}
