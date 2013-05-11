using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace battleManager.Classes.SpriteHandlers
{
    abstract class SpriteBase
    {

        //The Spriteshhet
        protected Texture2D sprite;

        //Dimensions of an individual sprite.
        protected int frameHeight { get; set; }
        protected int frameWidth { get; set; }

        public SpriteBase(Texture2D sprite, int height, int width)
        {
            this.sprite = sprite;
            this.frameHeight = height;
            this.frameWidth = width;
        }

        /// <summary>
        /// Crop the spritesheet.
        /// </summary>
        /// <param name="image">The entire spritesheet</param>
        /// <param name="source">The section which will be retained.</param>
        /// <returns></returns>
        public Texture2D Crop(Texture2D image, Rectangle source)
        {
            var graphics = image.GraphicsDevice;
            var ret = new RenderTarget2D(graphics, source.Width, source.Height);
            var sb = new SpriteBatch(graphics);

            graphics.SetRenderTarget(ret); // draw to image
            graphics.Clear(new Color(0, 0, 0, 0));

            sb.Begin();
            sb.Draw(image, Vector2.Zero, source, Color.White);
            sb.End();

            graphics.SetRenderTarget(null); // set back to main window

            return (Texture2D)ret;
        }
    }
}
