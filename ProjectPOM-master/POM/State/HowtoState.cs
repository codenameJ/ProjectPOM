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

        //animetion part----------------------------------
        Texture2D howtoprince;
        Texture2D howtomons;

        Point FrameSize = new Point(571, 377);
        Point SheetSize = new Point(7, 5);

        Point CurrentFrame = new Point(0, 0);

        int timeSinceLastFrame = 0;
        int millisecondPerFrame = 70;
        //------------------------------------------------

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
            howto = _content.Load<Texture2D>("BG/howtonew");

            //animetion part------------------------------------------------
            howtoprince = _content.Load<Texture2D>("how to anime/howtoprince");
            howtomons = _content.Load<Texture2D>("how to anime/howtomons");
            //-----------------------------------------------------------------


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

            //animetion part Logic---------------------------------------------------------
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                ++CurrentFrame.X;

                if (CurrentFrame.X >= SheetSize.X)
                {
                    CurrentFrame.X = 0;
                    ++CurrentFrame.Y;

                    if (CurrentFrame.Y >= SheetSize.Y)
                    {
                        CurrentFrame.Y = 0;

                    }
                }
            }
            //end--------------------------------------------------------------------------

        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            //bgtest
            spriteBatch.Draw(howto, new Rectangle(0, 0, 1440, 900), Color.Azure);


            //for show every buttons
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);


            //animetion part--------------------------------------------------------
            //how to with prince
            spriteBatch.Draw(howtoprince, new Vector2(600, 280), new Rectangle(
                (CurrentFrame.X * FrameSize.X),
                (CurrentFrame.Y * FrameSize.Y),
                FrameSize.X,
                FrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            //how to with monster
            spriteBatch.Draw(howtomons, new Vector2(20, 280), new Rectangle(
                (CurrentFrame.X * FrameSize.X),
                (CurrentFrame.Y * FrameSize.Y),
                FrameSize.X,
                FrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            //-----------------------------------------------------------------------

            spriteBatch.End();
        }

    }
}
