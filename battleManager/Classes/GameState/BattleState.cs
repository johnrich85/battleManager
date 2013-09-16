﻿using battleManager.Classes.Entities;
using battleManager.Classes.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Movement movement = new Movement();
        List<Texture2D> mapFeatures;
        MapFactory mapFactory;
        FeatureFactory featureFactory;

        Character testCharacter;
        bool debug = false;        Arena mapTest;        public BattleState(ContentManager theContent, EventHandler gameStateEvent)
            : base(theContent, gameStateEvent)
        {
        }

        public override void Initialize()
        {
            font = theContent.Load<SpriteFont>("SpriteFont1");

            texture = theContent.Load<Texture2D>("Graphics/Mechs/Mech2/Mech2Walk");
            test = new SpriteSheet(texture, 96, 96, 7, 3);

            testCharacter = new Mech(new Vector2(100, 100), test);          

            MapInit();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                gameStateEvent.Invoke(this, new EventArgs());
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                debug = true;
            }

            movement.Reset();
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                movement.mouse = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                movement.isNew = true;
            }


            // update entities here
            testCharacter.Update(gameTime, movement);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            //Temp changing bg color.
            graphicsDevice.Clear(new Color(0, 0, 0, 1));

            spriteBatch.DrawString(font, "BATTLE - press q to overview", new Vector2(20f, 20f), new Color(255, 255, 255));

            if (debug)
            {
                spriteBatch.DrawString(font, "X: " + Mouse.GetState().X.ToString() + " Y: " + Mouse.GetState().Y.ToString(), new Vector2(5, 5), new Color(255, 255, 255));
                spriteBatch.DrawString(font, testCharacter.moveAngle.ToString(), new Vector2(5, 50), new Color(255, 255, 255));
            }

            mapTest.Draw(spriteBatch, graphicsDevice);
            testCharacter.Draw(spriteBatch);
            base.Draw(spriteBatch, graphicsDevice);
        }


        //TODO: Move to 'mapInit / mapRender' class.
        private void MapInit()
        {
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
        }

    }
}
