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
    public class GameState : State
    {

        private List<Component> _GameComponents;
        Texture2D gamemoon;
        //add music
        private Song backgroundMusic;

        //bg test
        private Texture2D bgtest;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            //add music
            backgroundMusic = _content.Load<Song>("ost/Bat eat Banana");
            MediaPlayer.Play(backgroundMusic);

            //bgtest
            bgtest = _content.Load<Texture2D>("BG/Layer 1");

            var LitMontexture = _content.Load<Texture2D>("Monster/LitMon");
             gamemoon = _content.Load<Texture2D>("MainMoon");

            var LitMon = new Sprite(LitMontexture)
            {
                monsterSheetSize = new Point(3, 0),
                monsterFrameSize = new Point(261, 254),
                monsterCurrentFrame = new Point(0,0),
                timeSinceLastFrame = 0,
                millisecondPerFrame = 200
             
            };

            _GameComponents = new List<Component>()
            {
                LitMon
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //bgtest
            spriteBatch.Draw(bgtest, new Rectangle(0, 0, 1440, 900), Color.White);

            spriteBatch.Draw(gamemoon, new Rectangle(420, 300, 550, 500), Color.White);

            foreach (var component in _GameComponents)
                component.Draw(gameTime, spriteBatch);


            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}
