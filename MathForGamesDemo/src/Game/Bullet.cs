using Raylib_cs;
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
        public float Speed { get; set; } = 350;
        public override void Start()
        {
            base.Start();
        }


        public override void Update(double deltaTime)
        {

            base.Update(deltaTime);

           
                Transform.Translate(Transform.Forward * Speed * (float)deltaTime);


            Raylib.DrawCircleV(Transform.LocalPosition, bulletSize, Color.Blue);
        }

        public override void End()
        {
            base.End();
        }












    }
}

