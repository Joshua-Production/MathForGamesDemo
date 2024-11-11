using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo.src.Engine.Components
{
    internal class SpriteComponent : Component
    {
        private string _path;

        public SpriteComponent(Actor owner, string path= " ") : base(owner)
        {
            _path = path;
        }
    }
}
