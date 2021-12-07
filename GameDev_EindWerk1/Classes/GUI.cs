using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;

namespace GameDev_EindWerk1.Classes
{
    class GUI
    {
        public GameState currentState;
        private Cursor cursor;

        public GUI(Cursor c)
        {
            cursor = c;
        }
        public GameState SetMenu()
        {
            if (currentState==GameState.PAUSED)
            {
                if ((cursor.position.X < 850 && cursor.position.X > 970)&& (cursor.position.Y < 480 && cursor.position.Y > 620) && cursor.mouse.RightClick())
                {
                    currentState = GameState.PLAYING;
                }
            }
            return GameState.PAUSED;
        }


    }
}
