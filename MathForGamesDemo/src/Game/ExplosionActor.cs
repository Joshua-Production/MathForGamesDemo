using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;




namespace MathForGamesDemo
{
    internal class ExplosionActor : Actor
    {

        private float _growthRate = 10.0f;  // Rate at which the Explosion grows
        private float _maxSize = 300.0f;  // Maximum size of the red explosion
        private float _currentSize = 10f; // Initial size of the explosion

        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            // Gradually increase the size of the explosion over time
            if (_currentSize < _maxSize)
            {
                _currentSize += Transform.LocalScale.x + (_growthRate * (float)deltaTime);
            }
            
            // Make sure the size doesn't exceed the maximum size
            if (_currentSize >= _maxSize)
            {
                Game.CurrentScene.RemoveActor(this);  // Remove the explosion after it reaches the maximum size
            }

            // Draw the  explosion
            Rectangle rec = new Rectangle(Transform.LocalPosition, new Vector2(_currentSize, _currentSize));
            Raylib.DrawRectanglePro(rec, new Vector2(_currentSize / 2, _currentSize / 2), 0, Raylib_cs.Color.Red);
        }

        public override void End()
        {
            base.End();
        }
    }
}

