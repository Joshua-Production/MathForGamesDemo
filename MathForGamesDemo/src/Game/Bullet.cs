﻿using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class Bullet : Actor
    {
        public float bulletSize = 10f;
        public float Speed { get; set; } = 500;
        public override void Start()
        {
            base.Start();
        }


        public override void Update(double deltaTime)
        {

            base.Update(deltaTime);

           
                Transform.Translate(Transform.Forward * Speed * (float)deltaTime);


            Raylib.DrawCircleV(Transform.LocalPosition, bulletSize, Color.Blue);
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

