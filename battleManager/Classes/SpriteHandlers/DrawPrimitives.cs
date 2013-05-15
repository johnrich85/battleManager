using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.SpriteHandlers
{
    static class DrawPrimitives
    {
        public static void DrawLine(SpriteBatch batch,
              float width, Color color, Vector2 point1, Vector2 point2, GraphicsDevice graphicsDevice)
        {
            Texture2D blankTexture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blankTexture.SetData(new[] { Color.White });

            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            batch.Draw(blankTexture, point1, null, color,
                       angle, Vector2.Zero, new Vector2(length, width),
                       SpriteEffects.None, 0);
        }

        public static void DrawDot(SpriteBatch batch, Vector2 point, Color color, GraphicsDevice graphicsDevice)
        {
            Texture2D blankTexture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blankTexture.SetData(new[] { Color.White });

            batch.Draw(blankTexture, point, color);
        }
    }
}
