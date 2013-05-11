using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace battleManager.Classes.SpriteHandlers
{
    /// <summary>
    /// Interface used to enforce draw method.
    /// </summary>
    interface IDrawableBM{
        void Draw(SpriteBatch spriteBatch);
    }

    class Sprite : SpriteBase, IDrawableBM
    {
        /// <summary>
        /// Position to which sprite is drawn.
        /// </summary>
        Vector2 position;

        /// <summary>
        /// Constructor - assigning class vars
        /// </summary>
        /// <param name="sprite"> Asset </param>
        /// <param name="height"> Asset height</param>
        /// <param name="width"> Asset Width</param>
        /// <param name="pos"> Position to which sprite will be drawn.</param>
        /// 
        public Sprite(Texture2D sprite, int height, int width, Vector2 pos)
            : base(sprite, height, width)
        {
            position = pos;
        }

        /// <summary>
        /// Draw the sprite.
        /// </summary>
        /// <param name="spriteBatch"> Sprite will be drawn onto this.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }

    

}
