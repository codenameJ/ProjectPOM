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
using Microsoft.Xna.Framework.Input;
using POM.Sprites;

namespace POM.States
{
    public class GameState : State
    {
        public static Random Random;

        private bool GameOver = false;
        private SpriteFont _font;

        private List<Sprite> _sprites;

        Texture2D gamemoon;
        Texture2D prince;
        Texture2D gameovertext;
        Texture2D LitMontexture;

        public static int ScreenWidth;
        public static int ScreenHeight;
        private float _timer;


        //add music
        private Song backgroundMusic;

        //BG animetion part----------------------------------
        Texture2D BG;

        Point FrameSize = new Point(1440, 900);
        Point SheetSize = new Point(2, 4);

        Point CurrentFrame = new Point(0, 0);

        int timeSinceLastFrame = 0;
        int millisecondPerFrame = 100;
        //----------------------------------------------------


        //tree animation part---------------------------------
        Texture2D tree;

        Point treeFrameSize = new Point(155, 300);
        Point treeSheetSize = new Point(7, 4);
        
        Point treeCurrentFrame = new Point(0, 0);

        int treetimeSinceLastFrame = 0;
        int treemillisecondPerFrame = 2000;

        //------------------------------------------------------




        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {


            Random = new Random();


            //add music
            backgroundMusic = _content.Load<Song>("ost/Bat eat Banana");
            MediaPlayer.Play(backgroundMusic);

            //add BG
            BG = _content.Load<Texture2D>("BG/bgnew");

            //add tree
            tree = _content.Load<Texture2D>("BG/treemars155x300");

            //still content
            gamemoon = _content.Load<Texture2D>("MainMoon");

            //prince
            prince = _content.Load<Texture2D>("Players/o_princenew");

            //GameOver
            gameovertext = _content.Load<Texture2D>("t_gameover");


            _sprites = new List<Sprite>()
            {
                new Player(prince)
                {
                monsterSheetSize = new Point(2,0),
                monsterFramesize = new Point(202,190),
                }
            };


            //monsters part-----------------------------------------------------
            LitMontexture = _content.Load<Texture2D>("Monster/little monster");
            _font = _content.Load<SpriteFont>("fonts/font");


            var LitMon = new Sprite(LitMontexture)
            {
 //               Position = new Vector2(0,0),
 //               TextureSize = new Vector2(261,254),

  //              monsterCurrentFrame = new Point(0,0),
 //               timeSinceLastFrame = 0,
  //              millisecondPerFrame = 200
             
            };

            //jeng add------------
            var BigMontexture = _content.Load<Texture2D>("Monster/bigmonster");

            var BigMon = new Sprite(BigMontexture)
            {
                monsterSheetSize = new Point(3, 0),
                monsterFramesize = new Point(110, 135),
            };


            //end monsters part-------------------------------------------------------------


        }

        private void SpawnMonster()
        {
            if (_timer > 1)
            {
                _timer = 0;

                var xPos = Random.Next(0,1440);
                var yPos = Random.Next(0, 900);

                _sprites.Add(new Sprite(LitMontexture)
                {
                    monsterSheetSize = new Point(3, 0),
                    monsterFramesize = new Point(115, 78),
                    Position = new Vector2(xPos, yPos)
                }); 
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

            //BG animetion part--------------------------------------------------------
            spriteBatch.Draw(BG, Vector2.Zero, new Rectangle(
                (CurrentFrame.X * FrameSize.X),
                (CurrentFrame.Y * FrameSize.Y),
                FrameSize.X,
                FrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            //--------------------------------------------------------------------------

            if (!GameOver)
            {
                foreach (var sprite in _sprites)
                    sprite.Draw(spriteBatch);

                var fontY = 10;
                var i = 0;
                foreach (var sprite in _sprites)
                {
                    if (sprite is Player)

                        spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player)sprite).Score), new Vector2(10, fontY += 20), Color.Red);
                }


                //tree animation part------------------------------------------------------
                spriteBatch.Draw(tree, new Vector2(620, 350), new Rectangle(
                    (treeCurrentFrame.X * treeFrameSize.X),
                    (treeCurrentFrame.Y * treeFrameSize.Y),
                    treeFrameSize.X,
                    treeFrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                //--------------------------------------------------------------------------
                        



            }
            if(GameOver)
            {
                spriteBatch.Draw(gameovertext, new Rectangle(300,300,200,100), Color.White);
            }

            spriteBatch.End();
        }


        public override void PostUpdate(GameTime gameTime)
        {

        }


        public override void Update(GameTime gameTime)
        {

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);


            PostUpdate();



            SpawnMonster();

            //BG animation part Logic---------------------------------------------------------
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
            //end BG--------------------------------------------------------------------------



            //tree animation part Logic---------------------------------------------------------
            treetimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (treetimeSinceLastFrame > treemillisecondPerFrame)
            {
                treetimeSinceLastFrame -= treemillisecondPerFrame;
                ++treeCurrentFrame.X;

                if (treeCurrentFrame.X >= treeSheetSize.X)
                {
                    treeCurrentFrame.X = 0;
                    ++treeCurrentFrame.Y;

                    if (treeCurrentFrame.Y >= treeSheetSize.Y)
                    {
                        treeCurrentFrame.Y = 0;

                    }
                }
            }
            //end tree--------------------------------------------------------------------------



        }

        private void PostUpdate()
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
