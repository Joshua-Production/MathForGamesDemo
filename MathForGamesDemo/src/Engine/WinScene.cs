using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;





namespace MathForGamesDemo
{
    internal class WinScene : Scene
    {
        public override void Start()
        {
            base.Start();
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Game.CurrentScene = Game.GetScene(3);
            Raylib.DrawText("YOU WIN", 120, 50, 70, Color.Magenta);
            Raylib.DrawText("Press Enter to go to main menu", 20, 200, 30, Color.Magenta);
            Raylib.DrawText("Press Esc key to close game", 20, 300, 30, Color.Magenta);
            if (Raylib.IsKeyPressed(KeyboardKey.Enter) || (Raylib.IsKeyPressed(KeyboardKey.KpEnter)))
            {
                Game.CurrentScene = Game.GetScene(0);
            }



        }

    }
}
