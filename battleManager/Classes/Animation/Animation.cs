using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using battleManager.Classes.SpriteHandlers;

namespace battleManager.Classes.Animation
{
    /// @author - John Richardson.
    /// <summary>
    /// Used to cycle through a spritesheet with the aim of producing an animation.
    /// </summary>
    class Animation
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


        public void Initialize(SpriteSheet theSpriteSheet, float frameDuration, bool isLooping, Vector2 thePosition, int spriteCol, int spriteRow)
        {
            //Assigning param values to class variables
            this.spriteSheet = theSpriteSheet;
            this.elapsedTime = 0;
            this.displayDuration = frameDuration;
            this.looping = isLooping;
            this.position = thePosition;

            //Setting the starting point for spritesheet
            this.spriteSheet.setFrame(spriteCol, spriteRow);
            this.sourceDestination = this.spriteSheet.getFrame(spriteCol, spriteRow);    

        }

        public void Update(GameTime theGameTime, Vector2 thePosition)
        {
            //Stop if active false;
            if (active == false) return;

            this.elapsedTime += (float) theGameTime.ElapsedGameTime.Milliseconds;

            //Time to change frames.
            if (elapsedTime >= displayDuration)
            {
                this.sourceDestination = this.spriteSheet.next();

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

            //Generating rectangle based on above.
            destinationRect = new Rectangle(
                (int)position.X - (int)(spriteSheet.frameWidth) / 2,

                (int)position.Y - (int)(spriteSheet.frameHeight) / 2,

                (int)(spriteSheet.frameWidth),

                (int)(spriteSheet.frameHeight)
            ); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                spriteBatch.Draw(spriteSheet.getSpriteSheet(), destinationRect, sourceDestination, Color.White );
            }
        }
    }

    
}
