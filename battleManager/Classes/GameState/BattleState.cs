using battleManager.Classes.Entities;
using battleManager.Classes.SpriteHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Movement movement = new Movement();

        Character testCharacter;

        public BattleState(ContentManager theContent, EventHandler gameStateEvent)
            : base(theContent, gameStateEvent)
        {
        }

        public override void Initialize()
        {
            font = theContent.Load<SpriteFont>("SpriteFont1");

            texture = theContent.Load<Texture2D>("Graphics/Characters/Agent/AgentWalk");
            test = new SpriteSheet(texture, 64, 64, 8, 3);

            testCharacter = new Character(new Vector2(100, 100), test);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                gameStateEvent.Invoke(this, new EventArgs());
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
            spriteBatch.DrawString(font, "BATTLE - press q to overview", new Vector2(20f, 20f), new Color(255, 255, 255));
            spriteBatch.DrawString(font, "X: " + Mouse.GetState().X.ToString() + " Y: " + Mouse.GetState().Y.ToString(), new Vector2(5, 5), new Color(255, 255, 255));
            testCharacter.Draw(spriteBatch);
            base.Draw(spriteBatch, graphicsDevice);
        }
    }
}
