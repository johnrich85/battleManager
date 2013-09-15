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
    class Animation : IDrawableBM
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

        bool stillFrame = false;


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

        /// <summary>
        /// Scales the time needed to switch to the next frame in the animation.
        /// </summary>
        /// <param name="scale">The float to scale the time by. 1.0f will reset the time.</param>
        public void ScaleSpeed(float scale)
        {
            this.displayDuration = this.displayDuration * scale;
        }

        /// <summary>
        /// Changes the row of the spritesheet that this animation uses.
        /// </summary>
        /// <param name="rowNum">New row to use.</param>
        public void ChangeRow(int rowNum)
        {
            this.currentRow = rowNum;
        }

        /// <summary>
        /// Stops the animation at the current frame.
        /// </summary>
        public void StillFrame()
        {
            stillFrame = true;
        }

        /// <summary>
        /// Restarts the animation if it has been stopped.
        /// </summary>
        public void EndStillFrame()
        {
            stillFrame = false;
        }

        public void Update(GameTime theGameTime, Vector2 thePosition, float scale)
        {
            // Stop if active false;
            if (active == false) return;

            this.elapsedTime += (float) (theGameTime.ElapsedGameTime.TotalMilliseconds / scale);

            // Time to change frames.
            if (elapsedTime >= displayDuration && stillFrame == false)
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
                spriteBatch.Draw(spriteSheet.getSpriteSheet(), new Vector2(position.X - sourceDestination.Width/2, position.Y - sourceDestination.Height), sourceDestination, Color.White);
            }
        }
    }

    
}
