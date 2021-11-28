using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Input
{
    class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
                direction = new Vector2(0, 1);
            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up))
                direction = new Vector2(0, -1);
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                direction = new Vector2(-1, 0);
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
                direction = new Vector2(1, 0);
            return direction*4;//*4 to make it move faster
        }
    }
}
