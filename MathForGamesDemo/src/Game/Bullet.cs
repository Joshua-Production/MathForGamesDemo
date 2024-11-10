using Raylib_cs;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class Bullet : Actor
    {
        public Vector2 Direction {get; set;}
        public float Speed { get; set; } = 100f; // speed for the bullet
       
        public Bullet(Vector2 position, Vector2 direction) 
        {
            Transform.LocalPosition = position;
            Direction = direction.Normalized;
            
        }

        public override void Update(double deltaTime)
        {
            Transform.Translate(Direction * Speed * (float)deltaTime);

            base.Update(deltaTime);
            Raylib.DrawCircleV(Transform.GlobalPositon, 5, Color.White);
        }

        
        
           
            
        



    }
}



