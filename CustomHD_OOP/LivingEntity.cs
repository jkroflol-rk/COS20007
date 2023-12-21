using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsekaiStory
{
    public abstract class LivingEntity : Entity
    {
        private int _health;
        public LivingEntity(double x, double y, double w, double h, int health) : base(x, y, w, h)
        {
            _health = health;
        }

        public virtual int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public virtual void TakeDamage(int damage)
        {
            if (_health > 0)
            {
                 _health -= damage;
            }
        }

        public virtual bool Death()
        {
            if (_health <= 0) return true;
            return false;
        }
    }
}