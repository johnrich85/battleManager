using battleManager.Classes.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using battleManager.Classes.Map;

namespace battleManager.Classes.GameState
{
    class BattleState : GameState
    {
        SpriteFont font;
        Texture2D texture;
        Texture2D mapTexture;
        Sprite mapSprite;
        SpriteSheet test;
        Animation testAnim;
        List<Texture2D> mapTextures;

        Arena mapTest;

        public BattleState(ContentManager theContent, EventHandler gameStateEvent)
            : base(theContent, gameStateEvent)
        {
        }

        public override void Initialize()
        {
            font = theContent.Load<SpriteFont>("SpriteFont1");
            texture = theContent.Load<Texture2D>("Graphics/Characters/Agent/AgentWalk");
            test = new SpriteSheet(texture, 64, 64, 8, 3);
            testAnim = new Animation();
            testAnim.Initialize(test, 150, true, new Vector2(50, 50), 1, 8, 2);

            //Map Spritesheet texture
            mapTexture = theContent.Load<Texture2D>("Graphics/Pipes-RustyWalls");

            //Map Spritesheet sprite.
            mapSprite = new Sprite(mapTexture, 32, 32);

            //Getting individual tiles.
            Texture2D mapTexture1 = mapSprite.getFrame(8, 2);
            Texture2D mapTexture2 = mapSprite.getFrame(3, 3);
            //Texture2D mapTexture3 = mapSprite.getFrame(1, 7);
            //Texture2D mapTexture4 = mapSprite.getFrame(2, 5);

            //Getting Corner Positions.
            Vector2 topLeft = new Vector2(6, 3);
            Vector2 topRight = new Vector2(6, 3);
            Vector2 botRight = new Vector2(6, 3);
            Vector2 botLeft = new Vector2(6, 3);
            List<Vector2> corners = new List<Vector2>();
            corners.Add(topLeft);
            corners.Add(topRight);
            corners.Add(botRight);
            corners.Add(botLeft);

            //Sides
            Vector2 sideLeft = new Vector2(6, 3);
            Vector2 sideTop = new Vector2(6, 3);
            Vector2 sideRight = new Vector2(6, 3);
            Vector2 sideBot = new Vector2(6, 3);
            List<Vector2> sides = new List<Vector2>();
            sides.Add(sideLeft);
            sides.Add(sideTop);
            sides.Add(sideRight);
            sides.Add(sideBot);

            //Main tile
            Vector2 mainTile = new Vector2(7, 2);

            //Getting a multi-tiled image.
            SpriteMulti mapBG = new SpriteMulti(mapTexture, 32, 32, corners, sides, mainTile, 19, 19);
            Texture2D theMapBg = mapBG.getTexture();

            //Getting Corner Positions.
            topLeft = new Vector2(3, 3);
            topRight = new Vector2(5, 3);
            botRight = new Vector2(5, 5);
            botLeft = new Vector2(3, 5);
            corners = new List<Vector2>();

            corners.Add(topLeft);
            corners.Add(topRight);
            corners.Add(botRight);
            corners.Add(botLeft);

            //Sides
            sideLeft = new Vector2(3, 4);
            sideTop = new Vector2(4, 3);
            sideRight = new Vector2(5, 4);
            sideBot = new Vector2(4, 5);
            sides = new List<Vector2>();
            sides.Add(sideLeft);
            sides.Add(sideTop);
            sides.Add(sideRight);
            sides.Add(sideBot);

            //Main tile
            mainTile = new Vector2(4, 4);

            //Getting a multi-tiled image.
            SpriteMulti multiSpriteTest = new SpriteMulti(mapTexture, 32, 32, corners, sides, mainTile, 4, 4);
            Texture2D multiReturnTest = multiSpriteTest.getTexture();

            //Storing tiles in list.
            mapTextures = new List<Texture2D>();
            mapTextures.Add(mapTexture2);
            //mapTextures.Add(mapTexture3);
            //mapTextures.Add(mapTexture4);
            mapTextures.Add(multiReturnTest);


            //Passing tiles to map generator.
            Generate mapGen = new Generate(theMapBg, mapTextures, 608, 608);

            //Generating map.
            Texture2D generatedMap = mapGen.generateMap();

            //Passing finalized map into arena for positioning.
            mapTest = new Arena(generatedMap, 608, 608);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Key.Q))
            {
                gameStateEvent.Invoke(this, new EventArgs());
            }

            testAnim.Update(gameTime, new Vector2(50, 50));

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            //Temp changing bg color.
            graphicsDevice.Clear(new Color(0, 0, 0, 1));

            spriteBatch.DrawString(font, "BATTLE - press q to overview", new Vector2(20f, 20f), new Color(255, 255, 255));
            testAnim.Draw(spriteBatch);

            mapTest.Draw(spriteBatch, graphicsDevice);
            base.Draw(spriteBatch, graphicsDevice);
        }
    }
}
