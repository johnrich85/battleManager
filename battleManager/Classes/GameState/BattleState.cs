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
using battleManager.Classes.SpriteHandlers.Factory;

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
        List<Texture2D> mapFeatures;
        MapFactory mapFactory;
        FeatureFactory featureFactory;

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

            /*
             * 
             * ============================================ Start Map ============================================
             * 
            */

            //Load map texture.
            mapTexture = theContent.Load<Texture2D>("Graphics/Pipes-RustyWalls");
            //Generate sprite using the texture.
            mapSprite = new Sprite(mapTexture, 32, 32);

            //Instantiate factories.
            mapFactory = new MapFactory(theContent, mapTexture);
            featureFactory = new FeatureFactory(theContent, mapTexture);

            //Generate required sprites

            //Map background.
            SpriteMulti mapBG = mapFactory.makeConcrete();
            Texture2D theMapBg = mapBG.getTexture();

            //Multi tile map Feature
            SpriteMulti feature1Sprite = featureFactory.makeWoodPanel();
            Texture2D feature1 = feature1Sprite.getTexture();

            //Single tile map feature.
            Texture2D feature2 = mapSprite.getFrame(1, 7);

            //Storing tiles in list.
            mapFeatures = new List<Texture2D>();
            mapFeatures.Add(feature1);
            mapFeatures.Add(feature2);


            //Passing tiles to map generator.
            Generate mapGen = new Generate(theMapBg, mapFeatures, 800, 480);

            //Generating map.
            Texture2D generatedMap = mapGen.generateMap();

            //Passing finalized map into arena for positioning.
            mapTest = new Arena(generatedMap, 800, 480);

            /*
             * 
             * ============================================ End Map ============================================
             * 
            */

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
