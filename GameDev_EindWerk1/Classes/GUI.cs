using System;
using GameDev_EindWerk1.buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Classes
{
    class GUI
    {
        public GameState currentState;
        private Cursor cursor;
        public Button playButton;
        public Button quitButton;
        public Button backButton;
        public Button resumeButton;
        public Button level1Buttton;
        public Button level2Buttton;


        public GUI(Cursor mouse, Button play, Button quit, Button back, Button resume, Button level1, Button level2)
        {
            cursor = mouse;
            playButton = play;
            quitButton = quit;
            backButton = back;
            resumeButton = resume;
            level1Buttton = level1;
            level2Buttton = level2;
            currentState = GameState.MENU;
        }
        public GameState SetMenu()
        {


            if (currentState == GameState.MENU)
            {
                //var playTarget = new Rectangle((int)playButton.position.X, (int)playButton.position.Y, playButton.rect.Width, playButton.rect.Height);
                //var varMouse = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 5, 5);
                if (new Rectangle((int)playButton.position.X, (int)playButton.position.Y, playButton.rect.Width, playButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 201, 65)) && cursor.mouse.LeftClick())
                {
                    currentState = GameState.PLAYING;
                }
                else if (new Rectangle((int)quitButton.position.X, (int)quitButton.position.Y, quitButton.rect.Width, quitButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 214, 65)) && cursor.mouse.LeftClick())
                {
                    currentState = GameState.QUIT;
                }
            }
            else if (currentState==GameState.PAUSED)
            {
                if (new Rectangle((int)resumeButton.position.X, (int)resumeButton.position.Y, resumeButton.rect.Width, resumeButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 201, 65)) && cursor.mouse.LeftClick())
                {
                    currentState = GameState.PLAYING;
                }
                else if (new Rectangle((int)backButton.position.X, (int)backButton.position.Y, backButton.rect.Width, backButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 201, 65)) && cursor.mouse.LeftClick())
                {
                    currentState = GameState.MENU;
                }
            }
            else if (currentState == GameState.PLAYING)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    currentState = GameState.PAUSED;
                }
            }
            //TODO:add level GUI

            return currentState;
        }


    }
}
