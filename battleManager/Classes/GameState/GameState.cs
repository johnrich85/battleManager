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
    interface IGameState
    {
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice);
    }

    abstract class GameState : IGameState
    {
        protected ContentManager theContent;

        protected EventHandler gameStateEvent;

        public GameState(ContentManager theContent, EventHandler gameStateEvent)
        {
            this.gameStateEvent = gameStateEvent;
            this.theContent = theContent;
        }
        
        public virtual void Initialize()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Key.Space))
            {
                gameStateEvent.Invoke(this, new EventArgs());
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
        }
        
    }
}
