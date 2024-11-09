using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using System.Buffers;


namespace MathForGamesDemo
{
    internal class TankTop : Actor
    {

        private Color _color = Color.Blue;

        public float RotationSpeed { get; set; } = 5;
        public float FireRate { get; set; } = 0.5f;


        public override void Update(double deltaTime)
        {
            // Calling the Movement function
            Movement(deltaTime);





            base.Update(deltaTime);
            Raylib.DrawLineEx(Transform.GlobalPositon,
                Transform.GlobalPositon + Transform.Forward * 60, 10.0f,
                _color);


        }
        

        public void Movement(double deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.Left))
                Transform.Rotate(RotationSpeed * -1 * (float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.Right))
                Transform.Rotate(RotationSpeed * (float)deltaTime);
        }

        public void ShootBullet()
        {

            Vector2 spawnPosition = Transform.GlobalPositon + Transform.Forward * 60;
            Vector2 shootDirection = Transform.Forward;

            Bullet newbullet = new Bullet(spawnPosition, shootDirection);
            

        }




    }
}

