using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathForGamesDemo.src.Engine.Components;
using MathLibrary;
using Raylib_cs;



namespace MathForGamesDemo
{
    internal class TestScene : Scene
    {
        Actor _tankBottom;
        Actor _theBoi;
        public override void Start()
        {
            base.Start();

            
            // Add our cool actor
            Actor _tankBottom = Actor.Instantiate(new TankBottom(), null, new Vector2(200,200),0 );
            Actor _tankTop = Actor.Instantiate(new TankTop(), _tankBottom.Transform);
            


        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            
        }
    }
}
