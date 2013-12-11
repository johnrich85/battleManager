using battleManager.Classes.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace battleManager.Classes.Collision
{
    interface ICollidable
    {
        IEnumerable<CollidableCircle> GetCollisionMasks();
    }

    struct CollidableCircle
    {
        public Vector2 centerPos;
        public float radius;
    }

    class Collider
    {
        public bool BoundingCirle(CollidableCircle firstCircle, CollidableCircle secondCircle)
        {
            Vector2 distance = firstCircle.centerPos - secondCircle.centerPos;

            if (distance.Length() < firstCircle.radius + secondCircle.radius)
            {
                Debug.WriteLine(distance.Length());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BoundingCirle(Vector2 v1, float radius1, Vector2 v2, float radius2)
        {
            Vector2 distance = v1 - v2;

            if (distance.Length() < radius1 + radius2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool ByPixel(Texture2D Texture1, Vector2 pos1, Texture2D Texture2, Vector2 pos2)
        {

            // origin of sprites is in the centered, so we need to find the top left corner
            Rectangle Rectangle1 = new Rectangle((int)(pos1.X - Texture1.Width / 2), (int)(pos1.Y - Texture1.Height / 2), (int)Texture1.Width, (int)Texture1.Height);
            Rectangle Rectangle2 = new Rectangle((int)(pos2.X - Texture2.Width / 2), (int)(pos2.Y - Texture2.Height / 2), Texture2.Width, Texture2.Height);

            Color[] TextureData1 = new Color[Texture1.Width * Texture1.Height];
            Texture1.GetData(TextureData1);

            Color[] TextureData2 = new Color[Texture2.Width * Texture2.Height];
            Texture2.GetData(TextureData2);

            int top = Math.Max(Rectangle1.Top, Rectangle2.Top);
            int bottom = Math.Min(Rectangle1.Bottom, Rectangle2.Bottom);
            int left = Math.Max(Rectangle1.Left, Rectangle2.Left);
            int right = Math.Min(Rectangle1.Right, Rectangle2.Right);

            for (int y = top; y < bottom; y++)
                for (int x = left; x < right; x++)
                {
                    Color colorA = TextureData1[(x - Rectangle1.Left) + (y - Rectangle1.Top) * Rectangle1.Width];
                    Color colorB = TextureData2[(x - Rectangle2.Left) + (y - Rectangle2.Top) * Rectangle2.Width];
                    if (colorA.A != 0 && colorB.A != 0) return true;
                }
            return false;
        }


        //returns true if collision is detected
        public bool CollCheck(Texture2D Texture1, Vector2 pos1, float radius1, Texture2D Texture2, Vector2 pos2, float radius2)
        {
            //checks to see if bounding circles are intersecting
            bool circlecheck = BoundingCirle(pos1, radius1, pos2, radius2);

            if (!circlecheck)
            {
                return false;
            }

            bool pixelcheck = ByPixel(Texture1, pos1, Texture2, pos2);

            if (pixelcheck)
            {
                return true;
            }

            return false;
        }
    }

    interface IEntityCollisionHandler
    {
        void Collide(CollideHandler entity);
    }

    abstract class CollideHandler : IEntityCollisionHandler
    {
        public void Collide(CollideHandler entity)
        {
            if (entity.GetType() == typeof(CharacterCollider)) CharCollide((CharacterCollider)entity);
            if (entity.GetType() == typeof(ProjectileCollider)) ProjectileCollide((ProjectileCollider)entity);
            if (entity.GetType() == typeof(TerrainCollider)) TerrainCollide((TerrainCollider)entity);
            if (entity.GetType() == typeof(SceneryCollider)) SceneryCollide((SceneryCollider)entity);
        }

        virtual protected void CharCollide(CharacterCollider entity)
        {
            Debug.WriteLine("Characters collided!");
        }

        virtual protected void ProjectileCollide(ProjectileCollider proj)
        {
            Debug.WriteLine("Projectile collided!");
        }

        virtual protected void TerrainCollide(TerrainCollider terr)
        {
            Debug.WriteLine("Terrain collided!");
        }

        virtual protected void SceneryCollide(SceneryCollider terr)
        {
            Debug.WriteLine("Scenery collided!");
        }
    }

    class CharacterCollider : CollideHandler
    {
        Character host;

        public CharacterCollider(Character host)
        {
            this.host = host;
        }

        protected override void CharCollide(CharacterCollider entity)
        {
            Debug.WriteLine("Characters collided!");
        }

        protected override void ProjectileCollide(ProjectileCollider proj)
        {
            host.ReduceHealth(10);
        }

        protected override void TerrainCollide(TerrainCollider terr)
        {
            Debug.WriteLine("Character collided with terrain!");
        }

        protected override void SceneryCollide(SceneryCollider terr)
        {
            Debug.WriteLine("Character collided with terrain!");
        }
    }

    class ProjectileCollider : CollideHandler
    {
        protected override void CharCollide(CharacterCollider entity)
        {
            Debug.WriteLine("Projectile and Character collided!");
        }

        protected override void ProjectileCollide(ProjectileCollider proj)
        {
            Debug.WriteLine("Projectiles collided!");
        }

        protected override void TerrainCollide(TerrainCollider terr)
        {
            Debug.WriteLine("Projectile and Terrain collided!");
        }

        protected override void SceneryCollide(SceneryCollider terr)
        {
            Debug.WriteLine("Projectile and Scenery collided!");
        }
    }

    class TerrainCollider : CollideHandler
    {
        protected override void CharCollide(CharacterCollider entity)
        {
            throw new NotImplementedException();
        }

        protected override void ProjectileCollide(ProjectileCollider proj)
        {
            throw new NotImplementedException();
        }

        protected override void TerrainCollide(TerrainCollider terr)
        {
            throw new NotImplementedException();
        }

        protected override void SceneryCollide(SceneryCollider terr)
        {
            throw new NotImplementedException();
        }
    }

    class SceneryCollider : CollideHandler
    {
        protected override void CharCollide(CharacterCollider entity)
        {
            throw new NotImplementedException();
        }

        protected override void ProjectileCollide(ProjectileCollider proj)
        {
            throw new NotImplementedException();
        }

        protected override void TerrainCollide(TerrainCollider terr)
        {
            throw new NotImplementedException();
        }

        protected override void SceneryCollide(SceneryCollider terr)
        {
            throw new NotImplementedException();
        }
    }
}
