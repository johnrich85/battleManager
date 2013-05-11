using battleManager.Classes.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.Entities
{
    class Character : CollidableEntity
    {
        int health;
        Animation graphics;
        Movement movement;

        public Character(Vector2 position, SpriteSheet sheet)
        {
            graphics = new Animation();
            graphics.Initialize(sheet, 150, true, this.position, 1, 8, 1);

            this.position = position;
        }

        protected bool Move(Movement movement, GameTime gameTime)
        {
            if (movement.Up)
            {
                this.position.Y -= 1;
            }
            else if (movement.Down)
            {
                this.position.Y += 1;
            }

            if (movement.Left)
            {
                this.position.X -= 1;
            }
            else if (movement.Right)
            {
                this.position.X += 1;
            }

            return false;
        }

        public void Update(GameTime gameTime, Movement movement)
        {
            Move(movement, gameTime);
            graphics.Update(gameTime, position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphics.Draw(spriteBatch);
        }
    }

    class Movement
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public void Reset()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
        }
    }

}
