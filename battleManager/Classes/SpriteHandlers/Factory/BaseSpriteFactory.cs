using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.SpriteHandlers.Factory
{
    class BaseSpriteFactory
    {

        protected Texture2D mapTexture;
        protected Sprite mapSprite;
        protected ContentManager theContent;

        public BaseSpriteFactory(ContentManager theContent, Texture2D mapTexture)
        {
            this.theContent = theContent;
            this.mapTexture = mapTexture;
        }
    }
}
