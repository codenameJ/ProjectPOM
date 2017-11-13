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
    class HowtoState : State
    {

        //add test
        private List<Component> _components;

        /* for animation in future
        Texture2D howtomon;
        Texture2D howtoprince;
        */


        //add music
        private Song backgroundMusic;

        //bg test
        private Texture2D howto;



        public HowtoState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            //add music
            backgroundMusic = _content.Load<Song>("ost/My Heart Will Go On");
            MediaPlayer.Play(backgroundMusic);

            //bgtest
            howto = _content.Load<Texture2D>("BG/howto");

            //backbutt
            var backtexture = _content.Load<Texture2D>("backbutt");

            //backbutt
            var backbutt = new Button(backtexture)
            {
                Position = new Vector2(50, 70),
                TextureSize = new Vector2(100, 100)
            };
            backbutt.Click += Back_Click;


            //set component backbutt
            _components = new List<Component>()
            {
                backbutt,
            };
        }


        //back click funtion
        private void Back_Click(object sender, System.EventArgs e)
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
            //bgtest
            spriteBatch.Draw(howto, new Rectangle(0, 0, 1440, 900), Color.Azure);


            //for show every buttons
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

    }
}
