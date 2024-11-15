using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;


namespace MathForGamesDemo
{
    internal class TankTop : Actor
    {

        private Color _color = Color.Blue;

        public float RotationSpeed { get; set; } = 10;


        public override void Update(double deltaTime)
        {
            // Calling the Movement function
            Movement(deltaTime);

            // Calling the Shoot function
            Shoot(deltaTime);
            



            base.Update(deltaTime);

            // Draw the Turret
            Raylib.DrawLineEx(Transform.GlobalPositon,
             Transform.GlobalPositon + Transform.Forward * 60, 20.0f,
                _color);


        }



        public void Movement(double deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.Left))
                Transform.Rotate(RotationSpeed * -1 * (float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.Right))
                Transform.Rotate(RotationSpeed * (float)deltaTime);




        }

        public void Shoot(double deltaTime)
        {
            

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                Vector2 offset = new Vector2(Transform.GlobalPositon.x * 1.4f, Transform.GlobalPositon.y);
                Actor.Instantiate(new Bullet(), null, 
                    Transform.GlobalPositon, Transform.GlobalRotationAngle * -1, 
                    "bullet");
                
            }
        }

    }
}


