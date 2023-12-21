using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsekaiStory
{
    public class PlayerHUD
    {
        private Player _player;
        public PlayerHUD(Player player)
        {
            _player = player;
        }

        public void Draw()
        {
            SplashKit.DrawText("Health:", Color.Red, "mont", 14, 1130, 18);
            SplashKit.FillRectangle(Color.Red, 1200, 18, (((float)_player.Health/_player.MaxHealth))*200, 30);
            SplashKit.DrawRectangle(Color.Black, 1198, 16, 202, 32);
            SplashKit.DrawText($"{_player.Health}/{_player.MaxHealth}", Color.Red, "mont", 14, 1420, 18);


            SplashKit.DrawText("Ammo:", Color.Blue, "mont", 14, 1130, 70);
            SplashKit.FillRectangle(Color.Blue, 1200, 70, (((float)_player.Ammo / _player.MaxAmmo)) * 200, 30);
            SplashKit.DrawRectangle(Color.Black, 1198, 70, 202, 32);
            SplashKit.DrawText($"{_player.Ammo}/{_player.MaxAmmo}", Color.Blue, "mont", 14, 1420, 70);
            if (_player.Reloading == true )
            {
                SplashKit.DrawText("Reloading...", Color.White, "mont", 14, _player.X, _player.Y+20);
            }
        }

        public void Update()
        {
           
        }
    }
}