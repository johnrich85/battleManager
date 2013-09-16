using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.SpriteHandlers.Factory
{
    class FeatureFactory : BaseSpriteFactory

    {
        public FeatureFactory(ContentManager theContent, Texture2D mapTexture)
            : base(theContent, mapTexture)
        {
        }

        public SpriteMulti makeWoodPanel()
        {
            //Getting Corner Positions.
            Vector2 topLeft = new Vector2(3, 3);
            Vector2 topRight = new Vector2(5, 3);
            Vector2 botRight = new Vector2(5, 5);
            Vector2 botLeft = new Vector2(3, 5);
            List<Vector2> corners = new List<Vector2>();

            corners.Add(topLeft);
            corners.Add(topRight);
            corners.Add(botRight);
            corners.Add(botLeft);

            //Sides
            Vector2 sideLeft = new Vector2(3, 4);
            Vector2 sideTop = new Vector2(4, 3);
            Vector2 sideRight = new Vector2(5, 4);
            Vector2 sideBot = new Vector2(4, 5);
            List<Vector2> sides = new List<Vector2>();
            sides.Add(sideLeft);
            sides.Add(sideTop);
            sides.Add(sideRight);
            sides.Add(sideBot);

            //Main tile
            Vector2 mainTile = new Vector2(4, 4);

            //Getting a multi-tiled image.
            SpriteMulti multiSpriteTest = new SpriteMulti(mapTexture, 32, 32, corners, sides, mainTile, 4, 4);
            multiSpriteTest.init();

            return multiSpriteTest;
        }
    }
}
