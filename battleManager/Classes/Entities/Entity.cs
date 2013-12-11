using battleManager.Classes.Collision;
using battleManager.Classes.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.Entities
{
    class Entity
    {
        protected Vector2 position;

        public Entity(Vector2 position, battleManager.Classes.SpriteHandlers.IDrawable graphics)
        {
            this.position = position;
        }

        public Entity() {}

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }

    class CollidableEntity : Entity, ICollidable
    {
        protected List<CollidableCircle> collisionMasks;

        public CollidableEntity(Vector2 position, battleManager.Classes.SpriteHandlers.IDrawable graphics)
            : base(position, graphics)
        {
            collisionMasks = new List<CollidableCircle>();
        }

        public CollidableEntity() : base()
        {
            collisionMasks = new List<CollidableCircle>();
        }

        public IEnumerable<CollidableCircle> GetCollisionMasks()
        {
            return this.collisionMasks;
        }
    }
}
