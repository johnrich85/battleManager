using battleManager.Classes.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.Entities
{
    class Mech : Character
    {
        public Mech(Vector2 position, SpriteSheet sheet)
            : base(position, sheet)
        {
            int health = 100;
            graphics = new Animation();
            graphics.Initialize(sheet, 100, true, this.position, 0, 7, 1);
            this.pixelsMovedPerSec = 90;
            this.maxForcePerSec = 10;
            this.mass = 3;
            this.collisionMasks.Add(new Collision.CollidableCircle() { centerPos = this.position, radius = 50.0f });
        }

    }
}