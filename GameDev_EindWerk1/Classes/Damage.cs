using GameDev_EindWerk1.interfaces;
using GameDev_EindWerk1.Enemies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    public class Damage
    {
        public Damage(Hero _hero, Enemy _robot,  Kunai _kunai)
        {
            hero = _hero;
            enemy = _robot;
            
            kunai = _kunai;
        }
        public Hero hero { get; set; }
        public Enemy enemy { get; set; }
        public List<Kunai> kunais = new List<Kunai>();
       
        public GameState currentState;
        public Kunai kunai { get; set; }
        public bool EnemyHit { get => enemyHit; }


        private bool enemyHit = false;


        public void HeroDamage(Hero hero, Enemy _enemy, GameState state)
        {


            bool Xhit = hero.position.X >= _enemy.Position.X - 100 && hero.position.X <= _enemy.Position.X + 100;
            bool Yhit = hero.position.Y >= _enemy.Position.Y - 100 && hero.position.Y <= _enemy.Position.Y + 100;

            if (Xhit && Yhit && _enemy.HP > 0)
            {
                if (enemy is RobotEnemy && state == GameState.LEVEL2)
                {

                    hero.HP -= 1;
                }
                else if (enemy is ZombieEnemy && state == GameState.LEVEL1)
                {
                    hero.HP -= 1;
                }
            }


        }

        public void Update(GameState state)
        {
            HeroDamage(hero, enemy, state);
            EnemyDamage(enemy, kunai, state);
            ZombieDamage(enemy, hero, state);
        }


        private void EnemyDamage(Enemy enemy, Kunai kunai, GameState _state)
        {
            bool xHit = kunai.position.X >= enemy.Position.X - 100 && kunai.position.X <= enemy.Position.X + 100;
            bool yHit = kunai.position.Y >= enemy.Position.Y - 100 && kunai.position.Y <= enemy.Position.Y + 100;
            if (xHit && yHit)
            {
                enemy.HP = 0;
                enemyHit = true;
            }

        }

        private void ZombieDamage(Enemy enemy, Hero hero, GameState _state)
        {
            if (_state == GameState.LEVEL1)
            {

                bool y = (int)hero.position.Y >= (int)enemy.position.Y && (int)hero.position.Y <= (int)enemy.position.Y - 100;
                bool x = (int)hero.position.X >= (int)enemy.position.X - 20 && (int)hero.position.X <= (int)enemy.position.X + 20;//range is good, havent checked r to l though
                if (x && y)
                {
                    enemy.HP = 0;
                    enemyHit = true;
                }
            }
        }
    }
}
