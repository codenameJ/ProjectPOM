using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using POM.Content.Controls;

namespace POM.States
{
    public class MenuState : State
    {
        private List<Component> _MenuComponents;
        Texture2D MainMoon;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var startgametexture = _content.Load<Texture2D>("Controls/startgame");
            var howtoplaytexture = _content.Load<Texture2D>("Controls/howtoplay");
            var exittexture = _content.Load<Texture2D>("Controls/exitbutt");
            MainMoon = _content.Load <Texture2D>("MainMoon");

            var startgamebutt = new Button(startgametexture)
            {
                Position = new Vector2(540, 520),
                TextureSize = new Vector2(280, 100)
            };
            startgamebutt.Click += Startgame_Click;

            var howtoplaybutt = new Button(howtoplaytexture)
            {
                Position = new Vector2(530, 680),
                TextureSize = new Vector2(300, 60)
            };

            var exitbutt = new Button(exittexture)
            {
                Position = new Vector2(600, 805),
                TextureSize = new Vector2(150, 60)
            };
            exitbutt.Click += Quite_Click;

            _MenuComponents = new List<Component>()
            {
                startgamebutt,
                howtoplaybutt,
                exitbutt
            };

        }

        private void Startgame_Click(object sender, System.EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _gtaphicsDevice, _content));
        }

        private void Quite_Click(object sender, System.EventArgs e)
        {
            _game.Exit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(MainMoon, new Rectangle(420, 10, 550, 500), Color.White);

            foreach (var component in _MenuComponents)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _MenuComponents)
                component.Update(gameTime);
                
        }
    }
}
