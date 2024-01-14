using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace IsekaiStory
{
    public abstract class Entity
    {
        private double _x, _y, _w, _h;
        public Entity(double x, double y, double w, double h)
        {
            _x = x;
            _y = y;
            _w = w;
            _h = h;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double W
        {
            get { return _w; }
            set { _w = value; }
        }

        public double H
        {
            get { return _h; }
            set { _h = value; }
        }

        public double X2
        {
            get { return _x + _w; }
        }

        public double Y2
        {
            get { return _y + _h; }
        }

        public virtual void Draw()
        {

        }

        public abstract bool CheckCollide(Entity entity);

        public virtual void Move()
        {

        }

        public virtual void Attack()
        {

        }

        public virtual void Update()
        {

        }
    }
}