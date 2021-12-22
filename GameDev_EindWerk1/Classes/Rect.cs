using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    class Rect
    {
        public double xPos;
        public double yPos;
        public double Width;
        public double Height;

        public Rect(double xPos, double yPos, double Width, double Height) {
            this.xPos = xPos;
            this.yPos = yPos;
            this.Width = Width;
            this.Height = Height;
        }


        /*
        whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
        whiteRectangle.SetData(new[] { Color.White });

        //_spriteBatch.Draw(whiteRectangle, new Rectangle(500, 800 - 100, 50, 100), Color.White);


        Texture2D redRectangle;
        Rectangle _redRectangle = new Rectangle(900, 800 - 100, 50, 100);
        redRectangle = new Texture2D(GraphicsDevice, 1, 1);
        redRectangle.SetData(new[] { Color.White});
        //_spriteBatch.Draw(redRectangle, _redRectangle, Color.Red);
        
         */
    }
}
