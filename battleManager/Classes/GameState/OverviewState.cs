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
    class OverviewState : GameState
    {
        SpriteFont font;
        public bool goToBattle { get; set; }
        public bool goToMenu { get; set; }

        public OverviewState(ContentManager theContent, EventHandler gameStateEvent)
            : base(theContent, gameStateEvent)
        {
        }

        public override void Initialize()
        {
            font = theContent.Load<SpriteFont>("SpriteFont1");
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // sets state transitions, and triggers the event if one of them is true
            if (Keyboard.GetState().IsKeyDown(Key.Space)) goToBattle = true;
            else if (Keyboard.GetState().IsKeyDown(Key.Escape)) goToMenu = true;

            if (goToBattle || goToMenu)
            {
                gameStateEvent.Invoke(this, new EventArgs());
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.DrawString(font, "OVERVIEW - esc for menu, space for battle", new Vector2(20f, 20f), new Color(255, 255, 255));
            base.Draw(spriteBatch, graphicsDevice);
        }
    }
}
