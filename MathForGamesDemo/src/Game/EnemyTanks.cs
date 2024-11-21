using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class EnemyTanks : Actor
    {
        
        private float _baseFireRate;
        // Making a private variable for fire rate
        private float _fireRate = 1;
        
        // Making a scale for size
        public float tankScale = 50;

        // This lets you set the firerate for individual tanks
        public EnemyTanks(float fireRate)
        {
            _fireRate = fireRate;

            // Set a baseFireRate
            _baseFireRate = fireRate;
        }

        public override void Start()
        {
            base.Start();
            
        }
        public override void Update(double deltaTime)
        {
            // call the base class Update method to ensure any parent functionality is executed
            base.Update(deltaTime);

             _fireRate -= 1 * (float)deltaTime;

           

            // Make a new Rectangle give it its Position and Scale multiply it by 10 to make it bigger
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * tankScale);
            // Draw rec create a new Vector2 for setting the origin give it its rotation and color

            Raylib.DrawRectanglePro(rec, new Vector2(tankScale / 2, tankScale / 2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), Raylib_cs.Color.Red);
            Raylib.DrawLineEx(Transform.GlobalPositon, Transform.GlobalPositon + Transform.Forward * -65, 25, Color.Red);
            
            if (Math.Truncate(_fireRate) == 0)
            {

              Actor _enemyBullet = Actor.Instantiate(new EnemyBullet(), null,
                    Transform.GlobalPositon, Transform.LocalRotationAngle,
                    "bullet");
                _enemyBullet.Collider = new CircleCollider(_enemyBullet, 10);
                _fireRate = _baseFireRate;
            }



        }

        // override the OnCollision method to handle collision with other actors
        public override void OnCollision(Actor other)
        {
            if (other is EnemyBullet)
            {
                return;
            }
            if (other is TankBottom)
            {
                Game.CurrentScene = Game.GetScene(2);
            }

            else if (other is Bullet)
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
