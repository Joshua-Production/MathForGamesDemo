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

            Raylib.DrawText(" Welcome to Cross Fire", 55, 50, 35, Color.Black );
            Raylib.DrawText(" Your goal is to get to the finish line ",  35, 100, 27, Color.Black );
          





        }



    }
}
