using GameDev_EindWerk1.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    public class Damage
    {
        public Damage(Hero _hero, RobotEnemy _robot, Kunai _kunai)
        {
            hero = _hero;
            enemy = _robot;
            kunai = _kunai;
        }
        public Hero hero { get; set; }
        public RobotEnemy enemy { get; set; }

        public Kunai kunai { get; set; }
        public bool EnemyHit { get => enemyHit;  }

        private bool enemyHit = false;

        public void HeroDamage(Hero hero, RobotEnemy robot)
        {
           
            bool hit = hero.Position.X >= robot.Position.X - 100 && hero.Position.X <= robot.Position.X + 100;

            if (hit)
            {
                //Debug.WriteLine($"damage taken at\thero.x={this.Position.X}\trobot.x={robot.Position.X}");
                hero.HP -= 1;
            }
        }

        public void Update()
        {
            HeroDamage(hero, enemy);
            EnemyDamage(enemy, kunai);
        }
       

        private void EnemyDamage(RobotEnemy enemy, Kunai kunai)
        {
            bool xHit = kunai.position.X >= enemy.Position.X - 100 && kunai.position.X <= enemy.Position.X + 100;
            bool yHit = kunai.position.Y >= enemy.Position.Y - 100 && kunai.position.X <= enemy.Position.X + 100;
            if (xHit&&yHit)
            {
                enemy.HP = 0;
                enemyHit = true;
            }
            
        }
    }
}
