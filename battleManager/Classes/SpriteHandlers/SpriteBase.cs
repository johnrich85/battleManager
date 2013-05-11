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
    }
}
