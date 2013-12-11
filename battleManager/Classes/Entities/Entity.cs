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
    class Entity : IComparable<Entity>
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

        /// <summary>
        /// Sort entities by their Y axis value.
        /// </summary>
        public int CompareTo(Entity otherEntity)
        {
            if (this.position.Y < otherEntity.position.Y) return -1;
            else if (this.position.Y > otherEntity.position.Y) return 1;
            else return 0;
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
            foreach (CollidableCircle circle in this.collisionMasks)
            {
                yield return new CollidableCircle() { centerPos = this.position + circle.centerPos, radius = circle.radius };
            }
        }
    }
}
