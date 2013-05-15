using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.MovementManager
{
    class SteeringManager
    {
        public Vector2 steering;
        public IMoveManageable host;
        private Vector2 desiredVelocity;
        float distance;

        public SteeringManager(IMoveManageable host)
        {
            this.host = host;
            this.steering = new Vector2();
            desiredVelocity = new Vector2();
        }

        // Applies forces to position of host. Must be invoked after all behaviors.
        public void Update()
        {
            Vector2 velocity = host.getVelocity();
            Vector2 position = host.getPosition();

            steering = truncate(steering, host.getMaxForce());
            steering = steering / host.getMass();

            host.SetVelocity(host.getVelocity() + steering);

            host.SetPosition(host.getPosition() + velocity);
        }

        public Vector2 truncate(Vector2 vector, float max)
        {
            float i;

            i = max / vector.Length();
            i = (i < 1.0) ? i : 1.0f;

            vector = vector * i;

            return vector;
        }

        // public behavior API
        public void Seek(Vector2 target, int slowRadius)
        {
            steering = steering + doSeek(target, slowRadius);
        }

        private Vector2 doSeek(Vector2 target, int slowRadius)
        {
            // difference between target and position
            var desiredVelocity = target - host.getPosition();
            
            // length of vector
            distance = desiredVelocity.Length();

            // normalise vector to a length of 1
            desiredVelocity.Normalize();

            if (distance <= slowRadius)
            {
                desiredVelocity = desiredVelocity * (host.getMaxVelocity() * (distance / slowRadius));
            }
            else
            {
                // multiply the velocity to scale it from a length of 1 to the desired length for this update.
                desiredVelocity = desiredVelocity * host.getMaxVelocity();
            }

            // set steering force to the difference between desired velocity and current velocity
            return  desiredVelocity - host.getVelocity();
        }
    }
}
