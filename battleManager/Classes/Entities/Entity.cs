using battleManager.Classes.SpriteHandlers;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.Entities
{
    class Entity
    {
        Vector2 position;
        IsDrawable graphics;
    }

    class CollidableEntity : Entity
    {
        int test;
    }
}
