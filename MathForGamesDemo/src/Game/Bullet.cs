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
        public float Speed { get; set; } = 1500;
        public void BulletMovement(double deltaTime)
        {
            Transform.Translate(Transform.Forward * Speed * (float)deltaTime);
        }

        









    }
}

