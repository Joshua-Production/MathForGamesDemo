using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class DeathScene : Scene
    {
        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Game.CurrentScene = Game.GetScene(2);
            // If enter is pressed go back to starting scene 
            if (Raylib.IsKeyPressed(KeyboardKey.Enter) || (Raylib.IsKeyPressed(KeyboardKey.KpEnter)))
            {
                Game.CurrentScene = Game.GetScene(0);
            }

            Raylib.DrawText("Skill Issue", 90, 50, 70, Color.Black);
            Raylib.DrawText("Press Enter to go to title screen", 10, 190, 30, Color.Black);






        }




    }

}
