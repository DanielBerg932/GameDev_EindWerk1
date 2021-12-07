﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;

namespace GameDev_EindWerk1.Classes
{
    public class Animiation
    {

        public AnimationFrame CurrentFrame;
        private List<AnimationFrame> frames;
        private int counter = 0;
        private double FrameMovement = 0;
        IInputReader inputReader;


        public void AddFrame(AnimationFrame newFrame)
        {
            frames.Add(newFrame);
            CurrentFrame = frames[0];
        }

        public MovePosition UserMove()
        {
            MovePosition currentPosition = inputReader.ReadInput();
            return currentPosition;
        }

        public void Update(GameTime gameTime)
        {
            if (UserMove() != MovePosition.STOP && UserMove() != MovePosition.JUMP)
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

                CurrentFrame = frames[0];
            }

           
        }


        public Animiation(IInputReader reader)
        {
            frames = new List<AnimationFrame>();
            inputReader = reader;
        }
    }
}
