using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsekaiStory
{
    public class Menu
    {
        private Button play;
        public Menu()
        {
            play = new Button(668, 360, 200, 100, "PLAY");
        }

        public void Draw()
        {
            SplashKit.DrawText("Isekai Game", Color.Black, "drag", 60, 587, 200);

            play.Draw();

            play.Hover();
        }

        public GameState Update()
        {
            if (play.Click())
            {
                return GameState.game;
            }
            return GameState.menu;
        }
    }
}