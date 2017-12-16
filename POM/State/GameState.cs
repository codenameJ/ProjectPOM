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

       
        private SpriteFont _font;
        private List<Sprite> _sprites;

        Texture2D Marstext;
        Texture2D prince;
        Texture2D gameovertext;
        Texture2D LitMontexture;
        Texture2D BigMontexture;
        Texture2D score;
        Texture2D Fever;

        public static int ScreenWidth;
        public static int ScreenHeight;
        private float _timer;
        private float _timer2;
        private float _timeritem;
        private float alltime;

        public static int playerScore = 0;
        public static int HighScore = 417;
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




        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            game.IsMouseVisible = false;
            
           
            Random = new Random();
  
            //add music
            backgroundMusic = _content.Load<Song>("ost/KoisuruFortuneCookie");
            MediaPlayer.Play(backgroundMusic);

            //add BG
            BG = _content.Load<Texture2D>("BG/bgnew");

            //prince
            prince = _content.Load<Texture2D>("Players/o_princenew");

            //score
            score = _content.Load<Texture2D>("BG/score");

            //add
            Fever = _content.Load<Texture2D>("Item/fever55x55");
            //add tree
//            tree = _content.Load<Texture2D>("BG/treemars155x300");

            //add
            Marstext = _content.Load<Texture2D>("BG/treemars155x300");


            //GameOver
           gameovertext = _content.Load<Texture2D>("t_gameover");


            _sprites = new List<Sprite>()
            {
                new Mars(Marstext)
                {
                monsterSheetSize = new Point(7, 4),
                monsterFramesize = new Point(155,300),
                Position = new Vector2(620,350),
                },
                new Player(prince)
                {
                monsterSheetSize = new Point(2,0),
                monsterFramesize = new Point(202,190),
                },

            };




            //monsters part-----------------------------------------------------
            LitMontexture = _content.Load<Texture2D>("Monster/little monster");

            _font = _content.Load<SpriteFont>("fonts/font");



            //jeng add------------
             BigMontexture = _content.Load<Texture2D>("Monster/bigmonster");


            //end monsters part-------------------------------------------------------------


        }

        private void SpanwItem()
        {
            if (_timeritem > 15)
            {
                _timeritem = 0;

                _sprites.Add(new Item(Fever)
                {
                    Speed = ((float)alltime * 0.05f),
                    monsterSheetSize = new Point(0, 0),
                    monsterFramesize = new Point(55, 55),
                    Position = new Vector2(Random.Next(600,800), Random.Next(300, 500))

                });
            }
        }

        private void SpawnMonster()
        {
// ช่วยแก้ด้วยทำให้มอนสุ่มออกมาคนละเวลา
         
        if (_timer > 1)
            {
                _timer = 0;

                _sprites.Add(new Monster(LitMontexture)
                {
                    Speed = ((float)alltime * 0.05f),
                    monsterSheetSize = new Point(3, 0),
                    monsterFramesize = new Point(115, 78),
                    Position = new Vector2(Random.Next(0, 2000), Random.Next(-100, 0))
                });
                _sprites.Add(new Monster(LitMontexture)
                {
                    Speed = ((float)alltime * 0.05f),
                    monsterSheetSize = new Point(3, 0),
                    monsterFramesize = new Point(115, 78),
                    Position = new Vector2(Random.Next(0, 2000), Random.Next(900, 1000))
                });

            }
            if (_timer2 > 3)
            {

                _timer2 = 0;

                _sprites.Add(new Monster(LitMontexture)
                {
                    Speed = ((float)alltime * 0.05f),
                    monsterSheetSize = new Point(3, 0),
                    monsterFramesize = new Point(115, 78),
                    Position = new Vector2(Random.Next(0, 2000), Random.Next(900, 1000))
                });

                _sprites.Add(new Monster(BigMontexture)
                {
                    Speed = ((float)alltime * 0.04f),
                    monsterSheetSize = new Point(3, 0),
                    monsterFramesize = new Point(110, 135),
                    Position = new Vector2(Random.Next(0, 2000), Random.Next(-100, 0))
                });

                _sprites.Add(new Monster(BigMontexture)
                {
                    Speed = ((float)alltime * 0.04f),
                    monsterSheetSize = new Point(3, 0),
                    monsterFramesize = new Point(110, 135),
                    Position = new Vector2(Random.Next(0, 2000), Random.Next(900, 1000))
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

            if(HighScore > playerScore)
            {
                HighScore = HighScore;
            }
            if(playerScore > HighScore)
            {
                HighScore = playerScore;
            }

            //draw prince monster mars
            foreach (var sprite in _sprites)
                        sprite.Draw(spriteBatch);

            //score box
            spriteBatch.Draw(score, new Rectangle(30, 30, 120, 100), Color.White);


            // draw score font
            foreach (var sprite in _sprites)
                    {
                        if (sprite is Player)
                        {
                         spriteBatch.DrawString(_font, string.Format("{0}", ((Player)sprite).Score), new Vector2(62,73), Color.White);
                         playerScore = ((Player)sprite).Score;
                        }
                   }

                foreach (var spr in _sprites)
                    if (spr.GameOver)
                {
                    _game.ChangeState(new OverState(_game, _gtaphicsDevice, _content));
                }





                    //spriteBatch.Draw(gameovertext, new Rectangle(300, 300, 200, 100), Color.White);
               
                spriteBatch.End();
        }


        public override void PostUpdate(GameTime gameTime)
        {

        }


        public override void Update(GameTime gameTime)
        {
                _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            alltime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timeritem += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);


            PostUpdate();

            SpawnMonster();

            SpanwItem();

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
