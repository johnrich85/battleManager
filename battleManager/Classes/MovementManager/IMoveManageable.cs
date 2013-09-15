using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.MovementManager
{
    /// <summary>
    /// Defines the methods that objects must include in order to "plug" a movement manager to the entity.
    /// </summary>
    interface IMoveManageable
    {
        Vector2 getVelocity();
        void SetVelocity(Vector2 v);
        float getMaxVelocity();
        float getMaxForce();
        Vector2 getPosition();
        void SetPosition(Vector2 v);
        void SetAngle(double angle);
        float getMass();
    }
}
