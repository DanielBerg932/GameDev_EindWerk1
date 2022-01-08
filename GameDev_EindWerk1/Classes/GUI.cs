
using System;
using System.Diagnostics;
using GameDev_EindWerk1.buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDev_EindWerk1.Classes
{
    class GUI
    {
        public GameState currentState;
        private Cursor cursor;
        private Hero hero;
        private Hero hero2;
        public Button playButton;
        public Button quitButton;
        public Button backButton;
        public Button resumeButton;
        public Button level1Buttton;
        public Button level2Buttton;
        public int counter = 0;


        public GUI(Cursor mouse,Hero _hero,Hero _hero2, Button play, Button quit, Button back, Button resume, Button level1, Button level2)
        {
            cursor = mouse;
            hero = _hero;
            hero2 = _hero2;
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


            if (currentState == GameState.MENU||currentState==GameState.GAME_OVER)
            {
                //var playTarget = new Rectangle((int)playButton.position.X, (int)playButton.position.Y, playButton.rect.Width, playButton.rect.Height);
                //var varMouse = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 5, 5);
                if (new Rectangle((int)playButton.position.X, (int)playButton.position.Y, playButton.rect.Width, playButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 201, 65)) && cursor.mouse.LeftClick() || new Rectangle((int)level1Buttton.position.X, (int)level1Buttton.position.Y, level1Buttton.rect.Width, level1Buttton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 528, 65)) && cursor.mouse.LeftClick())
                {
                    currentState = GameState.LEVEL1;
                }
                else if (new Rectangle((int)level2Buttton.position.X, (int)level2Buttton.position.Y, level2Buttton.rect.Width, level2Buttton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 537, 65)) && cursor.mouse.LeftClick())
                {

                    currentState = GameState.LEVEL2;
                }
                else if (new Rectangle((int)quitButton.position.X, (int)quitButton.position.Y, quitButton.rect.Width, quitButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 214, 65)) && cursor.mouse.LeftClick()||counter>0)
                {
                    currentState = GameState.QUIT;
                }
            }
            else if (currentState == GameState.PAUSED)
            {
                if (new Rectangle((int)resumeButton.position.X, (int)resumeButton.position.Y, resumeButton.rect.Width, resumeButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 201, 65)) && cursor.mouse.LeftClick())
                {
                    currentState = GameState.LEVEL1;
                }
                else if (new Rectangle((int)backButton.position.X, (int)backButton.position.Y, backButton.rect.Width, backButton.rect.Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 201, 65)) && cursor.mouse.LeftClick())
                {
                    currentState = GameState.MENU;
                }
            }
            else if (currentState == GameState.LEVEL1 || currentState == GameState.LEVEL2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    currentState = GameState.PAUSED;
                }

                if (hero.HP == 0 || hero2.HP == 0)
                {
                    currentState = GameState.GAME_OVER;
                    
                }


            }



            return currentState;
        }


    }
}
