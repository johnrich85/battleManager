using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using battleManager.Classes.SpriteHandlers;

namespace battleManager.Classes.SpriteHandlers
{
    /// @author - John Richardson.
    /// <summary>
    /// Used to cycle through a spritesheet with the aim of producing an animation.
    /// </summary>
    class Animation : IsDrawable
    {
        /// <summary>
        /// Where the sprite will be drawn.
        /// </summary>
        Vector2 position;

        /// <summary>
        /// Which part of the sprite sheet to display.
        /// </summary>
        Rectangle sourceDestination;

        /// <summary>
        /// Location in game world
        /// </summary>
        Rectangle destinationRect;

        /// <summary>
        /// Time passed since last update.
        /// </summary>
        float elapsedTime;

        /// <summary>
        /// How long each frame will be displayed.
        /// </summary>
        float displayDuration;

        /// <summary>
        /// The spritesheet.
        /// </summary>
        SpriteSheet spriteSheet;

        /// <summary>
        /// Continuous loop, or one iteration?
        /// </summary>
        bool looping;

        /// <summary>
        /// Flag used to determine if animation is required.
        /// </summary>
        bool active = true;

        int currentCol;
        int currentRow;
        int startCol;
        int endCol;


        public void Initialize(SpriteSheet theSpriteSheet, float frameDuration, bool isLooping, Vector2 thePosition, int startCol, int endCol, int spriteRow)
        {
            //Assigning param values to class variables
            this.spriteSheet = theSpriteSheet;
            this.elapsedTime = 0;
            this.displayDuration = frameDuration;
            this.looping = isLooping;
            this.position = thePosition;
            this.currentCol = startCol;
            this.currentRow = spriteRow;
            this.endCol = endCol;
            this.startCol = startCol;

            //Setting the starting point for spritesheet
            this.spriteSheet.setFrame(startCol, spriteRow);
            this.sourceDestination = this.spriteSheet.getFrame(startCol, spriteRow);
        }

        public void Update(GameTime theGameTime, Vector2 thePosition)
        {
            //Stop if active false;
            if (active == false) return;

            this.elapsedTime += (float) theGameTime.ElapsedGameTime.Milliseconds;

            //Time to change frames.
            if (elapsedTime >= displayDuration)
            {
                currentCol++;
                if (currentCol > endCol) currentCol = startCol;

                this.sourceDestination = spriteSheet.getFrame(currentCol, currentRow);

                //Reset elapsed
                elapsedTime = 0;

                //Check if we need to loop the animation on last frame.
                if (spriteSheet.currentFrameX == spriteSheet.cols)
                {
                    if (looping == false)
                    {
                        active = false;
                    }
                }
            }

            //Getting current location of object.
            position = thePosition;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                spriteBatch.Draw(spriteSheet.getSpriteSheet(), position, sourceDestination, Color.White);
            }
        }
    }

    
}
