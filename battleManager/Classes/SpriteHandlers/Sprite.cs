using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace battleManager.Classes.SpriteHandlers
{
    /// <summary>
    /// Interface used to enforce draw method.
    /// </summary>
    interface IsDrawable{
        void Draw(SpriteBatch spriteBatch);
    }

    class Sprite : SpriteBase
    {

        protected Rectangle frame;

        /// <summary>
        /// Constructor - assigning class vars
        /// </summary>
        /// <param name="sprite"> Asset </param>
        /// <param name="height"> Asset height</param>
        /// <param name="width"> Asset Width</param>
        /// <param name="pos"> Position to which sprite will be drawn.</param>
        /// 
        public Sprite(Texture2D sprite, int height, int width)
            : base(sprite, height, width)
        {

        }

        /// <summary>
        /// Returning specific sprite location. 
        /// </summary>
        /// <param name="frameCol">Get frame at this column</param>
        /// <param name="frameRow">Get frame at this row</param>
        /// <returns>Rectangle</returns>
        public Texture2D getFrame(int frameCol, int frameRow)
        {

            //Getting x/y position for frame.
            int x = frameCol * frameWidth;
            int y = frameRow * frameHeight;

            //Creating rectangle
            frame = new Rectangle(x, y, frameWidth, frameHeight);

            return Crop(sprite, frame);
        }


    }

    

}
