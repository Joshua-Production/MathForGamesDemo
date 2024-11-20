using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;



namespace MathForGamesDemo
{

    internal class EnemyBullet : Actor
    {
        public float bulletSize = 10f;
        public float Speed { get; set; } = 100;
        public override void Start()
        {
            base.Start();
        }


        public override void Update(double deltaTime)
        {

            base.Update(deltaTime);


            Transform.Translate(Transform.Forward *-1 * Speed * (float)deltaTime);


            Raylib.DrawCircleV(Transform.LocalPosition, bulletSize, Color.Black);
            // Removing the projectiles once they get out of view
            if (Transform.LocalPosition.x > Raylib.GetScreenWidth() ||
                 Transform.LocalPosition.y > Raylib.GetScreenHeight()
    ) 
{
                Game.CurrentScene.RemoveActor(this);
            }

            if (Transform.LocalPosition.x <= 0 ||
                 Transform.LocalPosition.y <= 0
    ) 
{
                Game.CurrentScene.RemoveActor(this);
            }
        }

        public override void End()
        {
            base.End();
        }


    }
}


