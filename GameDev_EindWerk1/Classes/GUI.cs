using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;


namespace GameDev_EindWerk1.Classes
{
    class GUI
    {
        public GameState currentState;
        private IInputReader reader;

        public GameState SetMenu()
        {

            return GameState.PLAYING;
        }


    }
}
