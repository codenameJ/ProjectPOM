using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using POM.Content.Controls;
//addd
using Microsoft.Xna.Framework.Media;

namespace POM.States
{
    public class MenuState : State
    {
        //add music
        private Song backgroundMusic;

        //bg test
        private Texture2D bgtest;

        private List<Component> _MenuComponents;

        Texture2D MainMoon;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            //add music
            backgroundMusic = _content.Load<Song>("ost/Earth Cry");
            MediaPlayer.Play(backgroundMusic);

            //bgtest
            bgtest = _content.Load<Texture2D>("BG/Layer 1");

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

            //bgtest
            spriteBatch.Draw(bgtest, new Rectangle(0, 0, 1440, 900), Color.White);

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
