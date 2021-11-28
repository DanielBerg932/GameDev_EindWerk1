using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    public class Animiation
    {

        public AnimationFrame CurrentFrame;
        private List<AnimationFrame> frames;
        private int counter;
        private double FrameMovement = 0;


        public void AddFrame(AnimationFrame newFrame)
        {
            frames.Add(newFrame);
        }

        public void Update(GameTime gameTime)
        {

            CurrentFrame = frames[counter];
            FrameMovement += CurrentFrame.SourceRect.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if (FrameMovement >= CurrentFrame.SourceRect.Width / 10)
            {
                counter++;
                FrameMovement = 0;
            }
            if (counter >= frames.Count)
                counter = 0;
        }


        public Animiation()
        {
            frames = new List<AnimationFrame>();
        }
    }
}
