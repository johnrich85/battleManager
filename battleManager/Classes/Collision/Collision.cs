using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
        float centerPos;
        float radius;
    }

    class Collision
    {
        public bool BoundingCirle(float x1, float y1, float radius1, float x2, float y2, float radius2)
        {
            Vector2 v1 = new Vector2(x1, y1);
            Vector2 v2 = new Vector2(x2, y2);

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
}
