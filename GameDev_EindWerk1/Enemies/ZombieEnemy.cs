﻿using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1.Classes;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameDev_EindWerk1.Enemies
{
    public class ZombieEnemy : Enemy
    {
        public ZombieEnemy(Texture2D _texture, Texture2D _deadTexture, IInputReader reader, SpriteFont _font) : base(_texture, _deadTexture, reader, _font)
        {
            animation = new Animiation(reader, 5);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 521, 576)));
            animation.AddFrame(new AnimationFrame(new Rectangle(521, 0, 521, 576)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1042, 0, 521, 576)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1563, 0, 521, 576)));
            animation.AddFrame(new AnimationFrame(new Rectangle(2084, 0, 521, 576)));
            animation.userMove = new Vector2(1, 1);

            position = new Vector2(1400,580);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(base.font, this.ToString(), new Vector2(1700, 10), Color.Yellow);
        }

    }
}
