using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
using System.Reflection.Metadata.Ecma335;

namespace MathForGamesDemo
{
    internal class StartScene : Scene
    {
        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Game.CurrentScene = Game.GetScene(0);
            if (Raylib.IsKeyPressed(KeyboardKey.Enter) || (Raylib.IsKeyPressed(KeyboardKey.KpEnter)))
            {
                Game.CurrentScene = Game.GetScene(1);
            }

            Raylib.DrawText(" Welcome to Cross Fire", 20, 50, 40, Color.Black);
            Raylib.DrawText(" Your goal is to get to the finish line ", 35, 90, 27, Color.Black);
            Raylib.DrawText(" The part of your tank with the dark blue line is the back ", 1, 150, 19, Color.Black);
            Raylib.DrawText(" CONTROLS ", 100, 210, 55, Color.Black);
            Raylib.DrawText(" W is forwards ", 120, 290, 40, Color.Black);
            Raylib.DrawText(" S is backwards", 120, 340, 40, Color.Black);
            Raylib.DrawText(" A is Rotate the bottom of your tank to the left", 20, 410, 20, Color.Black);
            Raylib.DrawText(" D is Rotate the bottom of your tank to the right", 20, 430, 20, Color.Black);
            Raylib.DrawText(" Left Arrow rotates your turret to the left", 30, 460, 20, Color.Black);
            Raylib.DrawText(" Right Arrow rotates your turret to the right", 27, 480, 20, Color.Black);
            Raylib.DrawText(" Spacebar is shoot", 70, 520, 40, Color.Black);

            Raylib.DrawText(" Press enter to start ", 1, 800, 48, Color.Black);






        }



    }
}
