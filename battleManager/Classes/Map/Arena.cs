using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using battleManager.Classes.SpriteHandlers;

namespace battleManager.Classes.Map
{
    class Arena
    {
        int arenaWidth;
        int arenaHeight;
        Vector2 position;
        Texture2D texture;

        public Arena( Texture2D theTexture, int width, int height )
        {
            arenaWidth = width;
            arenaHeight = height;
            texture = theTexture;

        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            //Centering the map;
            position.X = (graphicsDevice.Viewport.Width - arenaWidth) /2;
            position.Y = (graphicsDevice.Viewport.Height - arenaHeight) / 2;

            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
