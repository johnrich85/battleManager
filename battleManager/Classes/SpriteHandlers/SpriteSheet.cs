using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace battleManager.Classes.SpriteHandlers
{
    /// @author - John Richardson
    /// <summary>
    /// Spritesheet - Used to return individual frames from a sprite sheet.
    /// </summary>
    /// 
    class SpriteSheet
    {
        //The Spriteshhet
        Texture2D spriteSheet;

        //The individual frame
        Rectangle frame;

        //Dimensions of an individual sprite.
        int frameHeight;
        int frameWidth;

        //Size of spritesheet
        int rows;
        int cols;

        //current frame,
        int currentFrameX = 0;
        int currentFrameY = 0;

        /// <summary>
        /// Constructor - setting class variables.
        /// </summary>
        /// <param name="sheet"> A Spritesheet </param>
        /// <param name="height"> The height of an individual frame</param>
        /// <param name="width"> The width of an individual frame</param>
        /// <param name="numCols"> Number of columns in spritesheet</param>
        /// <param name="numRows"> Number of rows in spritesheet</param>
        public SpriteSheet(Texture2D sheet, int height, int width, int numCols, int numRows)
        {
            //Storing parameters to class properties.
            this.spriteSheet = sheet;
            this.frameHeight = height;
            this.frameWidth = width;
            this.rows = numRows;
            this.cols = numCols;
        }

        /// <summary>
        /// Returns the entire spritesheet.
        /// </summary>
        /// <returns>Texture2D</returns>
        public Texture2D getSpriteSheet()
        {
            return spriteSheet;
        }

        /// <summary>
        /// Returning specific sprite location. 
        /// </summary>
        /// <param name="frameCol">Get frame at this column</param>
        /// <param name="frameRow">Get frame at this row</param>
        /// <returns>Rectangle</returns>
        public Rectangle getFrame(int frameCol, int frameRow)
        {

            //Checking to see if valid col/row has been passed in.
            if (frameCol > cols || frameRow  > rows)
            {
                throw new System.ArgumentException("Col or row out of bounds in spritesheet.", "original");
            }

            //Getting x/y position for frame.
            int x = frameCol * frameWidth;
            int y = frameRow * frameHeight;

            //Creating rectangle
            frame = new Rectangle(x, y, frameWidth, frameHeight);
            return frame;
        }

        /// <summary>
        /// Returning next sprite in the sequence.
        /// </summary>
        /// <returns> Rectangle </returns>
        public Rectangle next()
        {

            //Last frame reached, back to start old boy.
            if (currentFrameX >= cols)
            {
                currentFrameX = 0;
            }

            //Getting x/y position for frame.
            int x = currentFrameX * frameWidth;
            int y = currentFrameY * frameHeight;

            //Creating rectangle
            frame = new Rectangle(x, y, frameWidth, frameHeight);

            this.currentFrameX++;

            return frame;
        }

        /// <summary>
        /// Set the current frame - used when using 'next()' to iterate through animations.
        /// </summary>
        /// <param name="x"> Setting Column</param>
        /// <param name="y"> Setting Row</param>
        public void setFrame(int x, int y)
        {

            //Checking to see if valid col/row has been passed in.
            if (x > cols || y > rows)
            {
                throw new System.ArgumentException("Col or row out of bounds in spritesheet.", "original");

            }

            currentFrameX = x;
            currentFrameY = y;
        }


    }
}
