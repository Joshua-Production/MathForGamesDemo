﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;


namespace MathForGamesDemo
{
    internal class TankBottom : Actor
    {



        // set the speed
        public float Speed { get; set; } = 200;

        public float tankScale = 50;
        public float RotationSpeed { get; set; } = 2;


        public Color _color = Color.Blue;
        // override the update to handle movement and drawing for the actor
        public override void Update(double deltaTime)
        {
            // call the base class Update method to ensure any parent functionality is executed
            base.Update(deltaTime);

            // Calling the Movement function
            Movement(deltaTime);





            // Make a new Rectangle give it its Position and Scale multiply it by 10 to make it bigger
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * tankScale);

            // Draw rec create a new Vector2 for setting the origin give it its rotation and color

            Raylib.DrawRectanglePro(rec, new Vector2(tankScale / 2, tankScale / 2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), _color);
            Raylib.DrawLineEx(Transform.GlobalPositon, Transform.GlobalPositon + Transform.Forward * -34, 10, Color.DarkBlue);



            if (Transform.LocalPosition.x > Raylib.GetScreenWidth() || Transform.LocalPosition.y > Raylib.GetScreenHeight())
            {

                Game.CurrentScene = Game.GetScene(1);

            }


            if (Transform.LocalPosition.x <= 0 || Transform.LocalPosition.y <= 0)
            {
                Game.CurrentScene = Game.GetScene(1);


            }
            else if (Transform.LocalPosition.y <= 20)
            {
                Game.CurrentScene = Game.GetScene(3);
            }
        }

        // override the OnCollision method to handle collision with other actors
        public override void OnCollision(Actor other)
        {
            if (other is Bullet)
            {
                return;
            }
            if (other is EnemyTanks)
            {
                Game.CurrentScene = Game.GetScene(2);
            }

            else if (other is EnemyBullet)
            {
                Game.CurrentScene = Game.GetScene(2);
            }
        }
        public void Movement(double deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.W))
                Transform.Translate(Transform.Forward * Speed * (float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.S))
                Transform.Translate(Transform.Forward * Speed * -1 * (float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.A))
                Transform.Rotate(RotationSpeed * -1 * (float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.D))
                Transform.Rotate(RotationSpeed * (float)deltaTime);
        }
    }
}
