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
        public Damage(Hero _hero, Enemy _robot, Enemy _zombie, Kunai _kunai)
        {
            hero = _hero;
            enemy = _robot;
            enemy2 = _zombie;
            kunai = _kunai;
        }
        public Hero hero { get; set; }
        public Enemy enemy { get; set; }
        public List<Kunai> kunais = new List<Kunai>();
        private Enemy enemy2;

        public Kunai kunai { get; set; }
        public bool EnemyHit { get => enemyHit; }
        public bool EnemyHit2 { get => enemyHit2; }

        private bool enemyHit = false;
        private bool enemyHit2 = false;

        public void HeroDamage(Hero hero, Enemy robot)
        {

            bool Xhit = hero.position.X >= robot.Position.X - 100 && hero.position.X <= robot.Position.X + 100;
            bool Yhit = hero.position.Y >= robot.Position.Y - 100 && hero.position.Y <= robot.Position.Y + 100;

            if (Xhit && Yhit && robot.HP > 0)
            {
                //Debug.WriteLine($"damage taken at\thero.x={this.Position.X}\trobot.x={robot.Position.X}");
                hero.HP -= 1;
            }
        }

        public void Update()
        {
            HeroDamage(hero, enemy);
            EnemyDamage(enemy, kunai);
            HeroDamage(hero, enemy2);
            EnemyDamage(enemy2, kunai);
            ZombieDamage(enemy2, hero);
        }


        private void EnemyDamage(Enemy enemy, Kunai kunai)
        {
            bool xHit = kunai.position.X >= enemy.Position.X - 100 && kunai.position.X <= enemy.Position.X + 100;
            bool yHit = kunai.position.Y >= enemy.Position.Y - 100 && kunai.position.Y <= enemy.Position.Y + 100;
            if (xHit && yHit)
            {
                enemy.HP = 0;
                if (enemy is RobotEnemy)
                {
                    enemyHit = true;
                }
                else if (enemy is ZombieEnemy)
                {
                    enemyHit2 = true;
                }
            }

        }

        private void ZombieDamage(Enemy enemy, Hero hero)
        {

            bool y = (int)hero.position.Y >= (int)enemy.position.Y && (int)hero.position.Y <= (int)enemy.position.Y - 100;
            bool x = (int)hero.position.X >= (int)enemy.position.X - 20 && (int)hero.position.X <= (int)enemy.position.X + 20;//range is good, havent checked r to l though
            if (x && y)
            {
                enemy.HP = 0;
            }
        }
    }
}
