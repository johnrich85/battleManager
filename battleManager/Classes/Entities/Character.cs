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
    abstract class Character : CollidableEntity, IMoveManageable
    {
        int health;

        protected Animation graphics;

        public Vector2 velocity;
        public Vector2 target;

        // applies steering behaviors to entity
        public SteeringManager steering;

        protected float pixelsMovedPerSec = 50;
        float pixelsMovedThisUpdate;

        protected float maxForcePerSec = 10;
        float maxForceThisUpdate;

        public int mass = 4;
        public double moveAngle;
        

        public Character(Vector2 position, SpriteSheet sheet)
        {
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
            steering.Seek(target, 100);

            // Use the manager to update the position vector.
            steering.Update();

            SetAnimation();

            return true;
        }

        /// <summary>
        /// Sets the animation to the correct row in the spritesheet, based on the angle of the current velocity.
        /// Stops the animation if sufficiently slow.
        /// </summary>
        protected void SetAnimation()
        {
            graphics.ScaleSpeed(1);

            if (velocity.Length() > pixelsMovedThisUpdate / 12)
            {
                graphics.EndStillFrame();

                if (this.moveAngle > -135 && this.moveAngle <= -45)
                {
                    graphics.ChangeRow(0);
                }
                if (this.moveAngle > -45 && this.moveAngle <= 45)
                {
                    graphics.ChangeRow(3);
                }
                else if (this.moveAngle > 45 && this.moveAngle <= 135)
                {
                    graphics.ChangeRow(2);
                }
                else if (this.moveAngle > 135 || this.moveAngle <= -135)
                {
                    graphics.ChangeRow(1);
                }
            }
            else
            {
                graphics.StillFrame();
            }
        }

        public void Update(GameTime gameTime, Movement movement)
        {
            Move(movement, gameTime);
            graphics.Update(gameTime, position, pixelsMovedThisUpdate / velocity.Length());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphics.Draw(spriteBatch);
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

        public void SetAngle(double angle)
        {
            this.moveAngle = angle;
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
