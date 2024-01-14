using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsekaiStory
{
    public class Button
    {
        private double _x, _y;
        private double _w, _h;
        private string _text;
        private Rectangle _rect;
        public Button(double x, double y, double w, double h, string text)
        {
            _x = x;
            _y = y; 
            _w = w;
            _h = h;
            _rect = new Rectangle();
            _rect.X = x;
            _rect.Y = y;
            _rect.Width = w;    
            _rect.Height = h;
            _text = text;

        }

        public void Draw()
        {
            SplashKit.FillRectangle(Color.OrangeRed, _rect);
            SplashKit.DrawText(_text, Color.Black, "mont", 20, _x+10, _y+10);
        }

        public void Hover()
        {
            if (SplashKit.PointInRectangle(SplashKit.MousePosition(), _rect))
            {
                SplashKit.DrawRectangle(Color.Black, _x - 2, _y - 2, _w + 4, _h + 4);
            }
        }

        public bool Click()
        {
            if (SplashKit.PointInRectangle(SplashKit.MousePosition(), _rect) && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                return true;
            }
            return false;
        }
    }
}