using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathForGamesDemo.src.Engine.Components;
using MathLibrary;
using Raylib_cs;



namespace MathForGamesDemo
{
    internal class TestScene : Scene
    {
        
        
        public override void Start()
        {
            base.Start();
            
            
            // Adding the players actors
            Actor _tankBottom = Actor.Instantiate(new TankBottom(), null, new Vector2(265,860),-1.5f );
            _tankBottom.Collider = new CircleCollider(_tankBottom, 35);
            Actor _tankTop = Actor.Instantiate(new TankTop(), _tankBottom.Transform);

            Actor _EnemyTank1 = Actor.Instantiate(new EnemyTanks(4), null,new Vector2(509, 651), 0f);
            Actor _EnemyTank2 = Actor.Instantiate(new EnemyTanks(3), null,new Vector2(30, 507), 34.56f);
            Actor _EnemyTank3 = Actor.Instantiate(new EnemyTanks(2), null,new Vector2(509, 330), 0f);
            Actor _EnemyTank4 = Actor.Instantiate(new EnemyTanks(1.5f), null,new Vector2(30, 115), 34.56f);

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            
        }
    }
}
