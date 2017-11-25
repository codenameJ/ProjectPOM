using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using POM.Content.Controls;

//addd
using Microsoft.Xna.Framework.Media;


namespace POM.States
{
    class OverState : State
    {

        //add test
        private List<Component> _components;

        //add music
        private Song backgroundMusic;

        private Texture2D bg;
        private Texture2D over;



        public OverState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            game.IsMouseVisible = true
                ;
            //add music
            backgroundMusic = _content.Load<Song>("ost/Earth Cry");
            MediaPlayer.Play(backgroundMusic);


            bg = _content.Load<Texture2D>("BG/bgnew");
            over = _content.Load<Texture2D>("t_gameover");

            //try again butt
            var tryagaintexture = _content.Load<Texture2D>("tryagain");

            //try again butt
            var tryagainbutt = new Button(tryagaintexture)
            {
                Position = new Vector2(600,400),
                TextureSize = new Vector2(175, 53)
            };
            tryagainbutt.Click += Again_Click;


            //set component tryagain
            _components = new List<Component>()
            {
                tryagainbutt,
            };
        }


        //again click funtion
        private void Again_Click(object sender, System.EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _gtaphicsDevice, _content));
        }
        //------------------------------------------------------------------------------


        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);

        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            
            spriteBatch.Draw(bg, new Rectangle(0, 0, 1440, 900), Color.Azure);
            spriteBatch.Draw(over, new Rectangle(200, 400, 150, 60),Color.White);



            //for show every buttons
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);



            spriteBatch.End();
        }

    }
}
