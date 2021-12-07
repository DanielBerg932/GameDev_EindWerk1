using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Input
{
    public class MouseReader : IInputReader
    {
        MouseState state;
        public MouseReader()
        {
            state = Mouse.GetState();
        }
        public Vector2 ReadInput()
        {
            state = Mouse.GetState();
            return new Vector2(state.X, state.Y);
        }

        public bool RightClick()
        {

            if (state.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            else return false;
        }



    }
}
