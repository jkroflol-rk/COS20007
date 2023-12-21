using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsekaiStory
{
    public class Enemy : LivingEntity
    {
        public Enemy(double x, double y, double w, double h, int health) : base(x, y, w, h, health)
        {
        }

        public override bool CheckCollide(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}