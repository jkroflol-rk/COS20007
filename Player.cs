using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SplashKitSDK;

namespace IsekaiStory
{
    public class Player : LivingEntity
    {
        private List<Bullet> bullets;
        private List<Bullet> removed;
        private int _ammo;
        private int _maxammo;
        private long now = DateTime.UtcNow.Ticks;
        private long reloadStartTime;
        private bool reloading = false;
        private int maxhealth;
        public Player(double x, double y, double w, double h, int health, int ammo) : base(x, y, w, h, health)
        {
            bullets = new List<Bullet>();
            removed = new List<Bullet>();
            _ammo = ammo;
            _maxammo = ammo;
            maxhealth = health;
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(Color.Blue, X, Y, W, H);
            if (Death())
            {
                SplashKit.DrawText("gameover", Color.Blue, X+200, Y+200);
            }
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

        public bool Reloading
        {
            get { return reloading; }
            set { reloading = value; }
        }

        public int Ammo
        {
            get { return _ammo; }
            set { _ammo = value; }
        }

        public int MaxAmmo
        {
            get { return _maxammo; }
            set { _maxammo = value; }
        }

        public int MaxHealth
        {
            get { return maxhealth; }
            set { maxhealth = value; }
        }

        public override void Move()
        {
            if (SplashKit.KeyDown(KeyCode.AKey) && X >= 0) X -= 3;
            if (SplashKit.KeyDown(KeyCode.DKey) && X <= 1486) X += 3;
            if (SplashKit.KeyDown(KeyCode.SKey) && Y <= 814) Y += 3;
            if (SplashKit.KeyDown(KeyCode.WKey) && Y >= 100) Y -= 3;
        }

        public override void Attack()
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && _ammo > 0)
            {
                bullets.Add(new Bullet(X, Y, 50, 10, SplashKit.MousePosition().X, SplashKit.MousePosition().Y, Color.Red, 40));
                _ammo -= 1;
            }
        }

        public void Reload()
        {
            if (SplashKit.KeyDown(KeyCode.RKey) && _ammo == 0 && !reloading)
            {
                reloading = true;
                reloadStartTime = DateTime.UtcNow.Ticks;
            }

            // Check if the gun is currently reloading
            if (reloading)
            {
                long currentTick = DateTime.UtcNow.Ticks;
                // Delay for 2 seconds (20000000 ticks) before finishing the reload
                if ((currentTick - reloadStartTime) > 20000000)
                {
                    _ammo = _maxammo;
                    reloading = false;
                }
            }
        }

        public override void Update()
        {
            Move();
            Attack();
            Reload();
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
                    if (bullet.X > 1600 || bullet.Y > 900 || bullet.X < 0 || bullet.Y < 0)
                    {
                        removed.Add(bullet);
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