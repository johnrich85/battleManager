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

        public Entity(Vector2 position, battleManager.Classes.SpriteHandlers.IDrawableBM graphics)
        {
            this.position = position;
        }

        public Entity() {}

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }

    class CollidableEntity : Entity
    {
        public CollidableEntity(Vector2 position, battleManager.Classes.SpriteHandlers.IDrawableBM graphics)
            : base(position, graphics)
        {
        }

        public CollidableEntity() : base() { }
    }
}
