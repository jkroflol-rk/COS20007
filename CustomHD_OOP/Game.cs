using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace IsekaiStory
{
    public class Game
    {
        private Player player;
        private List<Enemy> enemyList;
        private List<Enemy> enemyDel;
        private Random random;
        private PlayerHUD HUD;
        private int score;
        private int roundCounter;
        public Game()
        {
            player = new Player(450, 450, 50, 50, 150, 30);
            enemyList = new List<Enemy>();
            enemyDel = new List<Enemy>();
            random = new Random();
            HUD = new PlayerHUD(player);
            score = 0;
        }  

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public bool GameOver()
        {
            if (player.Death())
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            if (GameOver())
            {
                player.Health = 150;
                player.MaxHealth = 150;
                player.MaxAmmo = 30;
                player.Ammo = 30;
                roundCounter = 0;
                score = 0;
                foreach (Enemy enemy in enemyList)
                {
                    enemyDel.Add(enemy);
                }
                foreach (Enemy enemy in enemyDel)
                {
                    enemyList.Remove(enemy);
                }
            }
        }

        public void GameStart()
        {
            player.Draw();
            if (enemyList.Count == 0)
            {
                roundCounter++;

                if (roundCounter % 4 == 0) // Check if it's a multiple of 4
                {
                    enemyList.Add(new Slime(random.Next(10, 1400), random.Next(30, 700), 100, 100, 300, player));
                    enemyList.Add(new Slime(random.Next(10, 1400), random.Next(30, 700), 100, 100, 300, player));
                    enemyList.Add(new Slime(random.Next(10, 1400), random.Next(30, 700), 100, 100, 300, player));
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        enemyList.Add(new Skeleton(random.Next(10, 1400), random.Next(150, 700), 40, 40, 30, player));
                    }
                }
                if (roundCounter % 5 == 0)
                {
                    player.MaxHealth += 120;
                    player.Health = player.MaxHealth;
                    player.MaxAmmo += 12;
                    player.Ammo = player.MaxAmmo;
                }
            }
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw();
            }
            HUD.Draw();
        }

        public void Update()
        {
            if (!player.Death())
            {
                player.Update();
                if (enemyList.Count != 0)
                {
                    foreach (Enemy enemy in enemyList)
                    {
                        enemy.Update();
                    }
                }
                if (player.Bullets != null)
                {
                    foreach (Bullet bullet in player.Bullets)
                    {
                        if (enemyList.Count != 0)
                        {
                            foreach (Enemy enemy in enemyList)
                            {
                                if (bullet.CheckCollide(enemy))
                                {
                                    player.Removed.Add(bullet);
                                    enemy.TakeDamage(30);
                                }
                            }
                        }
                    }
                    foreach (Bullet bullet in player.Removed)
                    {
                        player.Bullets.Remove(bullet);
                    }
                }
                foreach (Enemy enemy in enemyList)
                {
                    if (enemy.Death())
                    {
                        enemyDel.Add(enemy);
                        if (enemy.GetType() == typeof(Slime))
                        {
                            score += 100;
                        }
                        if (enemy.GetType() == typeof(Skeleton))
                        {
                            score += 30;
                        }
                        Console.WriteLine(score.ToString());
                    }
                }
                foreach (Enemy enemy in enemyDel)
                {
                    enemyList.Remove(enemy);
                }
            }
        }
    }
}