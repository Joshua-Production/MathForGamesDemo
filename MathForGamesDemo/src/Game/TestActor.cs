using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;


namespace MathForGamesDemo
{
    internal class TestActor : Actor 
    {
        // set the speed
        public float Speed { get; set; } = 50;

        private Color _color = Color.Blue;
        // override the update to handle movement and drawing for the actor
        public override void Update(double deltaTime)
        {
            // call the base class Update method to ensure any parent functionality is executed
            base.Update(deltaTime);

            
            // Movement 
            Vector2 movementInput = new Vector2();
            movementInput.y -= Raylib.IsKeyDown(KeyboardKey.W);
            movementInput.y += Raylib.IsKeyDown(KeyboardKey.S);
            movementInput.x -= Raylib.IsKeyDown(KeyboardKey.A);
            movementInput.x += Raylib.IsKeyDown(KeyboardKey.D);

            // calculate the delta movement vector based on the normalized input and speed
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;

            // if there is any movement translate the actors position
            if (deltaMovement.Magnitude !=0)
            Transform.Translate(deltaMovement);

            Raylib.DrawCircleV(Transform.GlobalPositon, Transform.GlobalScale.x / 2 * 100, _color);
        }

        // override the OnCollision method to handle collision with other actors
        public override void OnCollision(Actor other)
        {
            _color = Color.Red;
        }
    }
}
