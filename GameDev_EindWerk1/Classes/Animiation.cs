using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1.Input;

namespace GameDev_EindWerk1.Classes
{
    public class Animiation
    {

        public AnimationFrame CurrentFrame;
        public List<AnimationFrame> frames;
        public Vector2 userMove = Vector2.Zero;
        private int counter = 0;
        private double FrameMovement = 0;
        IInputReader inputReader;
        public int frameCounter;

        public Animiation(IInputReader reader ,int _frameCounter)
        {
            frames = new List<AnimationFrame>();
            inputReader = reader;
            frameCounter = _frameCounter;
        }

        public void AddFrame(AnimationFrame newFrame)
        {
            frames.Add(newFrame);
            CurrentFrame = frames[0];
        }

        public Vector2 UserMove()
        {
            Vector2 currentPosition = inputReader.ReadInput();
            return currentPosition;
        }
        
        public MovePosition EnumMoved()
        {
            return inputReader.ConvertInput();
        }

        public void Update(GameTime gameTime)
        {
            
            if (userMove != Vector2.Zero&& userMove != new Vector2(99999, 999999))//only when keyboard is pressed then it animates, can be overitten by non-interactable classes
            {
                CurrentFrame = frames[counter];
                FrameMovement += CurrentFrame.SourceRect.Width * gameTime.ElapsedGameTime.TotalSeconds;
                if (FrameMovement >= CurrentFrame.SourceRect.Width / 15)
                {
                    counter++;
                    FrameMovement = 0;
                }
                if (counter >= frames.Count)
                    counter = 0;
            }
            else
            {
                CurrentFrame = frames[frameCounter-1];
            }

           
        }


       
    }
}
