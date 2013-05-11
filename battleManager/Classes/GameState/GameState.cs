using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes.GameState
{
    /// <summary>
    /// Interface for all game states to implement.
    /// Ensures the functionality of update draw and init methods.
    /// </summary>
    interface IGameState
    {
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice);
    }

    /// <summary>
    /// Base GameState class.
    /// All game states should derive from this.
    /// </summary>
    abstract class GameState : IGameState
    {
        /// <summary>
        /// Reference to game content.
        /// </summary>
        protected ContentManager theContent;

        /// <summary>
        /// Holds true, once the state has been initialised.
        /// </summary>
        protected bool isInitialised = false;

        /// <summary>
        /// Event handler that allows state changes.
        /// </summary>
        protected EventHandler gameStateEvent;

        public GameState(ContentManager theContent, EventHandler gameStateEvent)
        {
            this.gameStateEvent = gameStateEvent;
            this.theContent = theContent;
        }
        
        /// <summary>
        /// Initialises the components of the state.
        /// Should be called in the game initialise method.
        /// </summary>
        public virtual void Initialize()
        {
            isInitialised = true;
        }

        /// <summary>
        /// Update method for this state.
        /// Should be called in the game's update method, when this state is active.
        /// </summary>
        /// <param name="gameTime">Milliseconds since last update.</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draw method for this state.
        /// Should be called in the game's draw method.
        /// </summary>
        /// <param name="spriteBatch">Provides the state with a reference to the game's sprite batch object.</param>
        /// <param name="graphicsDevice">Provides the state with a reference to the game's GraphicsDevice.</param>
        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {

        }
        
    }
}
