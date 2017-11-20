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

namespace POM.States
{
    public class GameState : State
    {

        private List<Component> _GameComponents;

        Texture2D gamemoon;
        Texture2D prince;
        Vector2 princePosition = Vector2.Zero;
        Vector2 hiiPosition = Vector2.Zero;
        MouseState prevMouseState;

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

            //add music
            backgroundMusic = _content.Load<Song>("ost/Bat eat Banana");
            MediaPlayer.Play(backgroundMusic);

            //add BG
            BG = _content.Load<Texture2D>("BG/bgnew");

            gamemoon = _content.Load<Texture2D>("MainMoon");
            prince = _content.Load<Texture2D>("Players/o_prince2crop");


            //monsters part-----------------------------------------------------
            var LitMontexture = _content.Load<Texture2D>("Monster/little monster");

            var LitMon = new Sprite(LitMontexture)
            {
                Position = new Vector2(0,0),
 //               TextureSize = new Vector2(261,254),
                monsterSheetSize = new Point(3, 0),
                monsterFramesize = new Point(115, 78),
  //              monsterCurrentFrame = new Point(0,0),
 //               timeSinceLastFrame = 0,
  //              millisecondPerFrame = 200
             
            };

            //jeng add------------
            var BigMontexture = _content.Load<Texture2D>("Monster/bigmonster");

            var BigMon = new Sprite(BigMontexture)
            {
                Position = new Vector2(0, 0),
                monsterSheetSize = new Point(3, 0),
                monsterFramesize = new Point(110, 135),
            };

            _GameComponents = new List<Component>()
            {
                LitMon, BigMon,
            };

            //end monsters part-------------------------------------------------------------


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

            spriteBatch.Draw(gamemoon, new Rectangle(600, 400, 225, 200), Color.White);
            spriteBatch.Draw(prince, new Rectangle((int)princePosition.X, (int)princePosition.Y, 160, 156), Color.White);


            foreach (var component in _GameComponents)
                component.Draw(gameTime, spriteBatch);
  

            spriteBatch.End();
        }


        public override void PostUpdate(GameTime gameTime)
        {
            
        }


        public override void Update(GameTime gameTime)
        {
            foreach (var component in _GameComponents)
                component.Update(gameTime);


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
            //end--------------------------------------------------------------------------


            MouseState mouseState = Mouse.GetState();
            if (mouseState.X != prevMouseState.X || mouseState.Y != prevMouseState.Y)
            {
                princePosition = new Vector2(mouseState.X, mouseState.Y);
                prevMouseState = mouseState;
            }
        }
    }
}
