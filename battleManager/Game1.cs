﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using battleManager.Classes.GameState;
using System.Linq;
using battleManager.Classes.SpriteHandlers;
#endregion

namespace battleManager
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MenuState menuState;
        OverviewState overviewState;
        BattleState battleState;

        IGameState currentState;

        List<IGameState> gameStates;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";

            // instanstiate states
            gameStates = new List<IGameState>();
            menuState = new MenuState(this.Content, new EventHandler(MenuStateEvent));
            overviewState = new OverviewState(this.Content, new EventHandler(OverviewStateEvent));
            battleState = new BattleState(this.Content, new EventHandler(BattleStateEvent));
            gameStates.Add(menuState);
            gameStates.Add(overviewState);
            gameStates.Add(battleState);

            // current state set to menu
            currentState = battleState;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Initialise each game state
            foreach (var gs in gameStates)
            {
                gs.Initialize();
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            currentState.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            // Draw method of current game state
            currentState.Draw(spriteBatch, GraphicsDevice);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        #region GAMSTATE TRANSITION EVENTS

        public void MenuStateEvent(object obj, EventArgs e)
        {
            currentState = overviewState;
        }

        public void OverviewStateEvent(object obj, EventArgs e)
        {
            // switch active state based on which is selected
            OverviewState state = obj as OverviewState;
            if (state.goToBattle)
            {
                state.goToBattle = false;
                currentState = battleState;
            }
            else if (state.goToMenu)
            {
                state.goToMenu = false;
                currentState = menuState;
            }
        }

        public void BattleStateEvent(object obj, EventArgs e)
        {
            currentState = overviewState;
        }

        #endregion
    }
}
