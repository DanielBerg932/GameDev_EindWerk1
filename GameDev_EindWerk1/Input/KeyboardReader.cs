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
        public Vector2 ReadInput()
        {

            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right) && (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Space)))
                direction = new Vector2(1, -1);
            else if (state.IsKeyDown(Keys.Left) && (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Space)))
                direction = new Vector2(-1, -1);


            else if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
                direction = new Vector2(0, 1);
            else if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up)||state.IsKeyDown(Keys.Space))
                direction = new Vector2(0, -1);
            else if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
                direction = new Vector2(-1, 0);
            else if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
                direction = new Vector2(1, 0);

            return direction * speed;

           
        }

        public MovePosition ConvertInput()
        {
            MovePosition currentState = MovePosition.STOP;

            KeyboardState state = Keyboard.GetState();

            if (this.ReadInput() / speed == new Vector2(1, -1))
            {
                currentState = MovePosition.JUMP_RIGHT;
            }
            else if (this.ReadInput() / speed == new Vector2(-1, -1))
            {
                currentState = MovePosition.JUMP_LEFT;
            }
            else if (this.ReadInput()/ speed == new Vector2(0,1))
            {
                currentState = MovePosition.GO_DOWN;
            }
            else if (this.ReadInput() / speed == new Vector2(0, -1))
            {
                currentState = MovePosition.JUMP;
            }
            else if (this.ReadInput() / speed == new Vector2(-1,0))
            {
                currentState = MovePosition.GO_LEFT;
            }
            else if (this.ReadInput() / speed == new Vector2(1,0))
            {
                currentState = MovePosition.GO_RIGHT;
            }

            
            return currentState;
        }

    }
}
