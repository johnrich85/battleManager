using battleManager.Classes.SpriteHandlers;
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
    class BattleState : GameState
    {
        SpriteFont font;
        Texture2D texture;
        SpriteSheet test;
        Animation testAnim;

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
            spriteBatch.DrawString(font, "BATTLE - press q to overview", new Vector2(20f, 20f), new Color(255, 255, 255));
            testAnim.Draw(spriteBatch);
            base.Draw(spriteBatch, graphicsDevice);
        }
    }
}
