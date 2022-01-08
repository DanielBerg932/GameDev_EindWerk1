using GameDev_EindWerk1.Enemies;
using GameDev_EindWerk1.hero;
using GameDev_EindWerk1.weapons;

namespace GameDev_EindWerk1.damage
{
    public class Damage
    {

        public Hero hero { get; set; }
        public Enemy enemy { get; set; }

        public GameState currentState;
        public Kunai kunai { get; set; }
        public bool EnemyHit { get => enemyHit; }
        public bool EnemyHit2 { get => enemyHit2; }

        private bool enemyHit = false;
        private bool enemyHit2 = false;

        public void HeroDamage(Hero _hero, Enemy _enemy, GameState state)
        {


            bool Xhit = _hero.position.X >= _enemy.Position.X - 100 && _hero.position.X <= _enemy.Position.X + 100;
            bool Yhit = _hero.position.Y >= _enemy.Position.Y - 100 && _hero.position.Y <= _enemy.Position.Y + 100;

            if (Xhit && Yhit && _enemy.HP > 0)
            {
                if (_hero.HP > 0)
                {

                    if (_enemy is RobotEnemy && state == GameState.LEVEL2)
                    {

                        _hero.HP -= 1;
                    }
                    else if (_enemy is ZombieEnemy && state == GameState.LEVEL1)
                    {
                        _hero.HP -= 1;
                    }
                }
            }


        }

        private void EnemyDamage(Enemy _enemy, Kunai _kunai, GameState _state)
        {


            bool xHit = _kunai.position.X >= _enemy.Position.X - 100 && _kunai.position.X <= _enemy.Position.X + 100;
            bool yHit = _kunai.position.Y >= _enemy.Position.Y - 100 && _kunai.position.Y <= _enemy.Position.Y + 100;
            if (xHit && yHit)
            {
                if (_enemy is RobotEnemy)
                {

                    enemyHit = true;
                }
                else if (_enemy is ZombieEnemy)
                {

                    enemyHit = true;
                }
                _enemy.HP -= 500;

            }

        }

        public void Update(Hero _hero, Enemy _enemy, Kunai _kunai, GameState _state)
        {
            HeroDamage(_hero, _enemy, _state);
            EnemyDamage(_enemy, _kunai, _state);

        }

    }
}
