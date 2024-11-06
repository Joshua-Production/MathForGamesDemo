using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;



namespace MathForGamesDemo
{
    internal class CircleCollider : Collider
    {
        public float CollisionRadius { get; set; }

        public CircleCollider(Actor owner, float radius) : base(owner)
        {
            CollisionRadius = radius;
        }
        public override bool CheckCollisionCircle(CircleCollider collider)
        {
            float sumRadii = collider.CollisionRadius + CollisionRadius;
            float distance = Vector2.Distance(collider.Owner.Transform.GlobalPositon, Owner.Transform.GlobalPositon);
            

            return sumRadii >= distance;


        }
        public override void Draw()
        {
            base.Draw();
            Raylib.DrawCircleLinesV(Owner.Transform.GlobalPositon, CollisionRadius, Color.Green);
        }



    }
}
