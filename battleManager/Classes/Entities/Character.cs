using battleManager.Classes.MovementManager;
using battleManager.Classes.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.Entities
{
    class Character : CollidableEntity, IMoveManageable
    {
        int health;

        Animation graphics;

        public Vector2 velocity;
        public Vector2 target;

        // applies steering behaviors to entity
        public SteeringManager steering;

        Movement movement;

        float pixelsMovedPerSec = 110;
        float pixelsMovedThisUpdate;

        float maxForcePerSec = 10;
        float maxForceThisUpdate;

        public int mass = 4;
        

        public Character(Vector2 position, SpriteSheet sheet)
        {
            int health = 100;

            graphics = new Animation();
            graphics.Initialize(sheet, 150, true, this.position, 1, 8, 1);

            velocity = new Vector2(0, 0);
            target = new Vector2();

            steering = new SteeringManager(this);

            this.position = position;
        }

        protected bool Move(Movement movement, GameTime gameTime)
        {
            // If movement has not been processed yet.
            if (movement.isNew)
            {
                target = movement.mouse;
            }

            // Divide the number of pixels moved per second by 1000 to get the distance in millisecs, then
            // multiply this value by the number of millisecs since last update.
            pixelsMovedThisUpdate = (float)((pixelsMovedPerSec / 1000) * gameTime.ElapsedGameTime.TotalMilliseconds);
            // Similar technique for max force allowed this update.
            maxForceThisUpdate = (float)((maxForcePerSec / 1000) * gameTime.ElapsedGameTime.TotalMilliseconds);

            // Using the steering manager to apply behaviors.
            steering.Seek(target, 20);

            // Use the manager to update the position vector.
            steering.Update();

            return true;
            
        }

        public void Update(GameTime gameTime, Movement movement)
        {
            Move(movement, gameTime);
            graphics.Update(gameTime, position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphics.Draw(spriteBatch);
            DrawPrimitives.DrawLine(spriteBatch, 1f, Color.White, position, position + velocity * 10, new GraphicsDevice());
        }

        #region IMoveManageable methods
        public Vector2 getVelocity()
        {
            return this.velocity;
        }

        public void SetVelocity(Vector2 v)
        {
            this.velocity = v;
        }

        public float getMaxVelocity()
        {
            return this.pixelsMovedThisUpdate;
        }

        public float getMaxForce()
        {
            return this.maxForceThisUpdate;
        }

        public Vector2 getPosition()
        {
            return this.position;
        }

        public void SetPosition(Vector2 v)
        {
            this.position = v;
        }

        public float getMass()
        {
            return this.mass;
        }

        #endregion

    }

    class Movement
    {
        public Vector2 mouse = new Vector2();
        public bool isNew = false;

        public void Reset()
        {
            isNew = false;
        }
    }

}
