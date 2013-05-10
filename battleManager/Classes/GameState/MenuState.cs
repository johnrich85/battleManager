using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGameWindowsApplication1.Classes.GameState
{
    class MenuState : GameState
    {
        SpriteFont font;

        public MenuState(ContentManager theContent, EventHandler gameStateEvent)
            : base(theContent, gameStateEvent)
        {
        }

        public override void Initialize()
        {
            font = theContent.Load<SpriteFont>("SpriteFont1");
            base.Initialize();
        }
        
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.DrawString(font, "MENU", new Vector2(20f, 20f), new Color(255,255,255));
 	        base.Draw(spriteBatch, graphicsDevice);
        }
    }
}
