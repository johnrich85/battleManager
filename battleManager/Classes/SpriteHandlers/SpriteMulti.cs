using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace battleManager.Classes.SpriteHandlers
{

    class SpriteMulti : Sprite
    {

        List<Vector2> cornerLocations;
        List<Vector2> sidesLocations;
        Vector2 centerTileLoc;
        Texture2D returnImage;
        Texture2D tempImage;
        int textureCols;
        int textureRows;
        int count;
        GraphicsDevice graphics;
        RenderTarget2D ret;
        SpriteBatch sb;
        Vector2 dest;

        /// <summary>
        /// This class is used to generate a meaningful image from a bunch of selected tiles.
        /// </summary>
        /// <param name="sprite">The spritesheet</param>
        /// <param name="height">Tile height</param>
        /// <param name="width">Tile rows</param>
        /// <param name="corners">Tiles used for corners, add to list in clock-wise order, starding at top left. Top left, top right, bottom right, bottom left.</param>
        /// <param name="sides"> Tiles used for sides, add in clock-wise order. Left, top, right, bottom. Add Only one tile to have it rotated & repeated.</param>
        /// <param name="center"> Tiles used for the center, this tile will be repeated.</param>
        /// <param name="returnTextureCols">Number of desired cols in the generated Texture2d</param>
        /// <param name="returnTextureRows">Number of desired rows in the generated Texture2d</param>
        public SpriteMulti(Texture2D sprite, int height, int width, List<Vector2> corners, List<Vector2> sides, Vector2 center, int returnTextureCols, int returnTextureRows )
            : base(sprite, height, width)
        {
            cornerLocations = corners;
            sidesLocations = sides;
            centerTileLoc = center;
            textureCols = returnTextureCols;
            textureRows = returnTextureRows;

            //Used as source triangle to select the desired tile - x,y will be changed as required
            //rather than creating a new rectangle each time.
            Rectangle frame1 = new Rectangle(0, 0, frameWidth, frameHeight);

            //Prep
            prepareNewTexture();

            //addBackground
            drawBg();

            //Draw Corners
            drawCorners();

            //Draw Sides
            drawSides();

            graphics.Clear(new Color(0, 0, 0, 0));
            sb.End();

        }


        //TODO:

        //1. Need a target onto which the tiles will be drawn.
        public void prepareNewTexture() {
            graphics = sprite.GraphicsDevice;

            //Creating new render target with desired dimensions.
            ret = new RenderTarget2D(graphics, textureCols * frameWidth, textureRows * frameHeight);
            sb = new SpriteBatch(graphics);
            sb.Begin();
            
        }

        public void drawBg() {

            //Cropping sprite sheet at required location.
            tempImage = getFrame((int)centerTileLoc.X, (int)centerTileLoc.Y);

            //getFrame uses different render target, need to set it back to 'ret'
            graphics.SetRenderTarget(ret);

            for (int a = 1; a < textureCols -1; a++)
            {
                dest.X = a * frameWidth;

                for (int z = 1; z < textureCols -1; z++)
                {
                    dest.Y = z * frameHeight;
                    sb.Draw(tempImage, dest, Color.White);
                }

            }
        }

        //2. Draw corners function, top left for example 0, (returnTextureCols * width) - width.
        public void drawCorners()
        {
            count = 0;

            foreach (var spriteLoc in cornerLocations)
            {
                //Cropping sprite sheet at required location.
                tempImage = getFrame((int)spriteLoc.X, (int)spriteLoc.Y);

                //getFrame uses different render target, need to set it back to 'ret'
                graphics.SetRenderTarget(ret);
                

                switch(count) {
                    //Top Left
                    case 0:
                        dest.X = 0;
                        dest.Y = 0;
                    break;

                    //Top Right
                    case 1:
                    dest.X = (textureCols * frameWidth) - frameWidth;
                    dest.Y = 0;
                    break;

                    //Bottom Right
                    case 2:
                    dest.X = (textureCols * frameWidth) - frameWidth;
                    dest.Y = (textureRows * frameHeight) - frameHeight;
                    break;

                    //Bottom Left
                    case 3:
                    dest.X = 0;
                    dest.Y = (textureRows * frameHeight) - frameHeight;
                    break;

                }

                sb.Draw(tempImage, dest, Color.White);

                count++;
            }
            

        }

        //3. Draw sides similar to above, if only one side passed in need to consider rotating it.
        public void drawSides()
        {
            count = 0;

            foreach (var spriteLoc in sidesLocations)
            {
                //Cropping sprite sheet at required location.
                tempImage = getFrame((int)spriteLoc.X, (int)spriteLoc.Y);

                //getFrame uses different render target, need to set it back to 'ret'
                graphics.SetRenderTarget(ret);

                switch (count)
                {
                    //Left
                    case 0:
                        dest.X = 0;

                        for (int a = 1; a < textureRows -1; a++)
                        {
                            dest.Y = a * frameHeight;
                            sb.Draw(tempImage, dest, Color.White);
                        }
                        break;

                    //Top
                    case 1:
                        dest.Y = 0;

                        for (int a = 1; a < textureCols -1; a++)
                        {
                            dest.X = a * frameWidth;
                            sb.Draw(tempImage, dest, Color.White);
                        }
                        break;

                    //Right
                    case 2:
                        dest.X = textureCols * frameWidth - frameWidth;

                        for (int a = 1; a < textureRows -1; a++)
                        {
                            dest.Y = a * frameHeight;
                            sb.Draw(tempImage, dest, Color.White);
                        }
                        break;

                    //Bottom
                    case 3:
                        dest.Y = textureRows * frameHeight - frameHeight;

                        for (int a = 1; a < textureCols -1; a++)
                        {
                            dest.X = a * frameWidth;
                            sb.Draw(tempImage, dest, Color.White);
                        }
                        break;

                }

                

                count++;
            }

        }

        //4. Draw center.
        //5. Return the resulting image.

        public Texture2D getTexture()
        {
            return (Texture2D)ret;
        }


    }

    

}
