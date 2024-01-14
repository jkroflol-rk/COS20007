using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsekaiStory
{
    public class Bullet : Entity
    {
        private double speedX, speedY, distX, distY;
        private int SPEED;
        private Color _color;
        public Bullet(double x, double y, double w, double z, double destX, double destY, Color color, int speed) : base(x, y, w, z)
        {
            distX = destX - X;
            distY = destY - Y;
            _color = color;
            SPEED = speed;
        }

        public override void Draw()
        {
            SplashKit.FillCircle(_color, X, Y, W/4);
        }

        public override void Update()
        {
            double angle = Math.Atan2(distY, distX);

            // Calculate the speed components using the angle in radians
            speedX = SPEED * Math.Cos(angle);
            speedY = SPEED * Math.Sin(angle);

            X += speedX;
            Y += speedY;
        }

        public override bool CheckCollide(Entity entity)
        {
            Point2D point = new Point2D();
            point.X = X; point.Y = Y;
            return SplashKit.PointInRectangle(point, SplashKit.RectangleFrom(entity.X, entity.Y, entity.W, entity.H));
        }
    }
}