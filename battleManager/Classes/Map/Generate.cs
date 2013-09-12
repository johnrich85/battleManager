using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace battleManager.Classes.Map
{
    class Generate
    {
        int arenaWidth;
        int arenaHeight;
        int textureWidth;
        int textureHeight;
        int cols;
        int rows;
        Texture2D texture;
        List<Texture2D> mapTextures;

        public Generate(Texture2D theTexture, List<Texture2D> textures, int width, int height)
        {
            //Dimensions of entire arena.
            arenaWidth = width;
            arenaHeight = height;

            //Individual tile dimensions.
            textureWidth = theTexture.Width;
            textureHeight = theTexture.Height;

            //Texture2d
            texture = theTexture;
            mapTextures = textures;

            //Amount of cols/rows required.
            cols = arenaWidth / textureWidth;
            rows = arenaHeight / textureHeight;

        }

        public Texture2D generateMap()
        {

            //Generating a new Texture2D.
            var graphics = texture.GraphicsDevice;
            var ret = new RenderTarget2D(graphics, arenaWidth, arenaHeight);
            var sb = new SpriteBatch(graphics);
            graphics.SetRenderTarget(ret); // draw to image
            graphics.Clear(new Color(0, 0, 0, 0));

            //Source rectangle, texturesize * cols required.
            Rectangle source = new Rectangle(0, 0, textureWidth * cols, textureHeight * rows);
            Rectangle source2 = new Rectangle(0, 0, textureWidth , textureHeight);



            //Drawing sprite in tile mode.
            sb.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap,
                    DepthStencilState.Default, RasterizerState.CullNone);
            
            sb.Draw(texture, Vector2.Zero, source, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);


            Vector2 pos = new Vector2(96,96);


            foreach (var v in mapTextures)
            {

                source2.Width = (v.Width);
                source2.Height = (v.Height);

                sb.Draw(v, pos, source2, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

                //Need to make position change properly, this will do for now though, just placing the second item in bottom corner.
                pos.X = 380;
                pos.Y = 380;

            }
            
            sb.End();

            // set back to main window
            graphics.SetRenderTarget(null); 

            return ret;

            //TO DO: Save new image.
            //save to disk
            //Stream stream = File.OpenWrite("test.png");
            //ret.SaveAsJpeg(stream, arenaWidth, arenaHeight);
            //stream.Dispose();
            //texture.Dispose();

        }

        
    }
}
