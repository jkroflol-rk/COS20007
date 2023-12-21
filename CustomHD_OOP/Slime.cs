using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsekaiStory
{
    public class Slime : Enemy
    {
        private List<Bullet> bullets;
        private List<Bullet> removed;
        private Player _player;
        private long now = DateTime.UtcNow.Ticks;
        public Slime(double x, double y, double w, double h, int health, Player player) : base(x, y, w, h, health)
        {
            bullets = new List<Bullet>();
            removed = new List<Bullet>();
            _player = player;
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(Color.Green, X, Y, W, H);
            SplashKit.DrawText($"{Health}", Color.Red, X + 10, Y + 10);
            if (bullets != null)
            {
                foreach (Bullet bullet in bullets)
                {
                    bullet.Draw();
                }
            }
        }

        public List<Bullet> Bullets
        {
            get { return bullets; }
            set { bullets = value; }
        }

        public List<Bullet> Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        public void Attack(Player player)
        {
            bullets.Add(new Bullet(X, Y, 50, 10, player.X + 25, player.Y + 25, Color.Black, 15));
        }

        public override void Update()
        {
            long currentTick = DateTime.UtcNow.Ticks;
            if ((currentTick - now) > 7000000)
            {
                Attack(_player);
                now = currentTick;
            }
            if (bullets != null)
            {
                foreach (Bullet bullet in bullets)
                {
                    bullet.Update();
                }
            }
            if (bullets != null)
            {
                foreach (Bullet bullet in bullets)
                {
                    if (bullet.X > 1600 || bullet.Y > 900 || bullet.X < 0 || bullet.Y < 0 || bullet.CheckCollide(_player))
                    {
                        removed.Add(bullet);
                    }
                    if (bullet.CheckCollide(_player))
                    {
                        _player.TakeDamage(30);
                    }
                }
                foreach (Bullet bullet in removed)
                {
                    bullets.Remove(bullet);
                }
            }
        }

        public override bool CheckCollide(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}