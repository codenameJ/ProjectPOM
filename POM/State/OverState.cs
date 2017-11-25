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
using POM.Sprites;

//addd
using Microsoft.Xna.Framework.Media;


namespace POM.States
{
    class OverState : State
    {

        private SpriteFont _font;

        //add test
        private List<Component> _components;

        //add music
        private Song backgroundMusic;

        private Texture2D bg;
        private Texture2D over;
        private Texture2D highscore;
        private Texture2D score;


        public OverState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            game.IsMouseVisible = true;

            //add music
            backgroundMusic = _content.Load<Song>("ost/Earth Cry");
            MediaPlayer.Play(backgroundMusic);

            _font = _content.Load<SpriteFont>("fonts/OverFont");
            bg = _content.Load<Texture2D>("BG/bgnewover");
            over = _content.Load<Texture2D>("t_gameover");
            highscore = _content.Load<Texture2D>("BG/highscore");
            score = _content.Load<Texture2D>("BG/score");

            //try again butt
            var tryagaintexture = _content.Load<Texture2D>("tryagain");

            var tryagainbutt = new Button(tryagaintexture)
            {
                Position = new Vector2(578,550),
                TextureSize = new Vector2(250, 76)
            };
            tryagainbutt.Click += Again_Click;



            //main memu again butt
            var mainmenutexture = _content.Load<Texture2D>("mainmenu");

            var mainmenubutt = new Button(mainmenutexture)
            {
                Position = new Vector2(555, 650),
                TextureSize = new Vector2(300, 73)
            };
            mainmenubutt.Click += MainMenu_Click;



            //set component tryagain
            _components = new List<Component>()
            {
                tryagainbutt,mainmenubutt
            };
        }


        //click funtion
        //try again
        private void Again_Click(object sender, System.EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _gtaphicsDevice, _content));
        }

        //back to menu
        private void MainMenu_Click(object sender, System.EventArgs e)
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
            spriteBatch.Draw(over, new Rectangle(507, 350, 400, 121),Color.White);
            spriteBatch.Draw(highscore, new Rectangle(520, 100, 190, 190), Color.White);
            spriteBatch.Draw(score, new Rectangle(720, 100, 190, 190), Color.White);
            spriteBatch.DrawString(_font, string.Format("{0}", GameState.playerScore), new Vector2(780, 190), Color.White);
            spriteBatch.DrawString(_font, string.Format("{0}", GameState.HighScore), new Vector2(570,190), Color.White);

            //for show every buttons
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);



            spriteBatch.End();
        }

    }
}
