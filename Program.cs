using SplashKitSDK;
using System;
using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

namespace IsekaiStory
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.LoadFont("mont", "../../../Montserrat-Regular.ttf");
            SplashKit.LoadFont("drag", "../../../DragonHunter-9Ynxj.otf");
            SplashKit.LoadBitmap("bg", "../../../bg.jpg");

            Window window = new Window("Camera Test", 1536, 864);
            //window.ToggleFullscreen();

            GameState gameState = new GameState();
            gameState = GameState.menu;

            Menu menu = new Menu();
            Game game = new Game();
            int highscore;

            using (StreamReader reader = new StreamReader("../../../save.txt"))
            {
               highscore = int.Parse(reader.ReadLine()); // Read an integer
            }
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                SplashKit.DrawBitmap("bg", 0, 0);

                // show x and y on screen
                SplashKit.DrawText(SplashKit.PointToString(SplashKit.MousePosition()), Color.Black, 0, 0, SplashKit.OptionToScreen());;

                if (gameState == GameState.menu)
                {
                    menu.Draw();
                    SplashKit.DrawText($"Highscore: {highscore}", Color.Black, "drag", 30, 668, 510);
                    SplashKit.DrawText("How to play:", Color.Black, "mont", 30, 630, 600);
                    SplashKit.DrawText("WASD for moving", Color.Black, "mont", 30, 630, 630);
                    SplashKit.DrawText("R for reloading", Color.Black, "mont", 30, 630, 660);
                    SplashKit.DrawText("(reload only when no ammo)", Color.Black, "mont", 30, 630, 690);
                    SplashKit.DrawText("Left Click to shoot", Color.Black, "mont", 30, 630, 720);
                    SplashKit.DrawText("Esc to quit", Color.Black, "mont", 30, 630, 750);

                    gameState = menu.Update();
                }
                else if (gameState == GameState.game)
                {
                    game.GameStart();
                    game.Update();
                    if (game.GameOver() == true)
                    {
                        if (game.Score > highscore)
                        {
                            highscore = game.Score;
                            using (StreamWriter writer = new StreamWriter("../../../save.txt"))
                            {
                                writer.WriteLine(highscore);
                            }
                        }
                        game.Reset();
                        gameState = GameState.menu;
                    }
                }

                if (SplashKit.KeyDown(KeyCode.EscapeKey)) window.Close();
                SplashKit.RefreshScreen(60);
            } while (!window.CloseRequested);
        }
    }
}


