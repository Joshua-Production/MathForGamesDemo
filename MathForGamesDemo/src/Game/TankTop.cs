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

            // Fire a bullet when the space bar is pressed
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                ShootBullet();
            }

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
            // Calculating the spawn position for the bullet 
            Vector2 spawnPosition = Transform.GlobalPositon + Transform.Forward * 60;

            // Create a new bullet that spawns in front of the tank, moving in the direction the tank is facing
            Bullet newBullet = new Bullet(spawnPosition, Transform.Forward);

            // Add the bullet as a child of the tank (or to the world, if you're using a global scene system)
            Game.CurrentScene.AddActor(newBullet);

        }




    }
}


