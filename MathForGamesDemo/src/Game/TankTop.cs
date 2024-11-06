using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class TankTop : Actor
    {
        


        //public override void Update(double deltaTime)
        //{
        //    base.Update(deltaTime);

        //    Vector2 movementInput = new Vector2();
        //    // Forward
        //    movementInput.y -= Raylib.IsKeyDown(KeyboardKey.W);
        //    // Backwards
        //    movementInput.y += Raylib.IsKeyDown(KeyboardKey.S);

        //    // calculate the delta movement vector based on the normalized input and speed
        //    Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;

        //    // if there is any movement translate the actors position
        //    if (deltaMovement.Magnitude != 0)
        //        Transform.Translate(deltaMovement);

        //}
    }
}
