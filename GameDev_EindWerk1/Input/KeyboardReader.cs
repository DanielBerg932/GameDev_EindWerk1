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
        public int speed = 5;
        public MovePosition ReadInput()
        {
            MovePosition currentState = MovePosition.STOP;
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Space))
                currentState = MovePosition.JUMP;
            else if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                currentState = MovePosition.GO_LEFT;
            else if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
                currentState = MovePosition.GO_RIGHT;

            return currentState;
        }


    }
}
