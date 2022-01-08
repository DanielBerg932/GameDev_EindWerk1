using System;
using System.Collections.Generic;
using System.Text;
using GameDev_EindWerk1.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameDev_EindWerk1.Classes
{
    public class Kunai : IGameObject
    {
        Texture2D texture;
        public Animiation animation;
        public Vector2 position;
        private Hero hero;
        private int rCounter;
        private int lCounter;
        private int ECounter;
        
        bool enemyHit;

        SoundManager sounds = SoundManager.GetInstance();

        public bool EnemyHit { get => enemyHit; set => enemyHit = value; }
        

        public Kunai(Texture2D _texture, IInputReader reader, Hero _hero)
        {
            animation = new Animiation(reader, 5);
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 163, 160)));
            animation.AddFrame(new AnimationFrame(new Rectangle(163, 0, 163, 160)));
            animation.AddFrame(new AnimationFrame(new Rectangle(326, 0, 163, 160)));
            animation.AddFrame(new AnimationFrame(new Rectangle(489, 0, 163, 160)));
            animation.AddFrame(new AnimationFrame(new Rectangle(652, 0, 163, 160)));
            texture = _texture;
            rCounter = 0;
            lCounter = 0;
            ECounter = 0;
            animation.userMove = new Vector2(0, 1);
            hero = _hero;
        }
        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }

     

        public void Draw(SpriteBatch _spriteBatch)
        {
           
            if (ECounter > 0 && ECounter < 200 && lCounter >= 0 && lCounter < 200 && rCounter >= 0 && rCounter < 200 && !EnemyHit)
            {
                _spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRect, Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
            }
        }
        public void Move()
        {
            bool right = Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.E) || Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyDown(Keys.E);
            bool left = Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.E) || Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyDown(Keys.E);

            if (right || (rCounter > 0 && rCounter < 200))
            {
                if (rCounter <= 1)
                {
                    position = hero.position;
                }
                position.X += 10;
                rCounter++;
                ECounter++;
                
                //MediaPlayer.Play(sounds.dictionary["ThrowKnife"]);
            }
            else if (left || (lCounter > 0 && lCounter < 200))
            {
                if (lCounter <= 1)
                {
                    position = hero.position;
                }
                position.X -= 10;
                lCounter++;
                ECounter++;
            }




        }


    }
}
