using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;



namespace MathForGamesDemo
{
    internal class TestScene : Scene
    {
        Actor _tankBottom;
        public override void Start()
        {
            base.Start();

            // Add our cool actor
            Actor actor = new TankBottom();
            actor.Transform.LocalPosition = new Vector2(200, 200);
            AddActor(actor);
            actor.Collider = new CircleCollider(actor, 60);

             _tankBottom = Actor.Instantiate(new Actor("Bottom"), null, new Vector2(100, 100), 0);
            _tankBottom.Collider = new CircleCollider(_tankBottom, 50);

            
            
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            
        }
    }
}
