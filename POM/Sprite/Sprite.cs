using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Content.Controls
{
    public class Sprite : Component
    {

        private Texture2D _texture;
        public Vector2 Position { get; set; }
        public Vector2 TextureSize { get; set; }
        public Point monsterFrameSize { get; set; }
        public Point monsterSheetSize { get; set; }
        public Point monsterCurrentFrame { get; set; }
        public int timeSinceLastFrame { get; set; }
        public int millisecondPerFrame { get; set; }
        private Point MCF;

        #region monstermove

        //       Point monsterFrameSize = new Point(261, 254);
        //       Point monsterSheetSize = new Point(3, 0);
        //       Point monsterCurrentFrame = new Point(0, 0);

        //      int timeSinceLastFrame = 0;
        //       int millisecondPerFrame = 200;

        #endregion



        public Rectangle SpriteRect
        {
            get
            {
                MCF = monsterCurrentFrame;

                return new Rectangle((int)MCF.X*monsterFrameSize.X, (int)MCF.Y*monsterFrameSize.Y, (int)monsterFrameSize.X, (int)monsterFrameSize.Y);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            MCF = monsterCurrentFrame;
            int MovX = MCF.X * monsterFrameSize.X;
            ++MovX;
            int MovY = MCF.Y * monsterFrameSize.Y;
            ++MovY;

 //           spriteBatch.Draw(_texture, SpriteRect, color);
            spriteBatch.Draw(_texture, new Vector2(MovX,MovY), SpriteRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {


            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                ++MCF.X;

                if (MCF.X >= monsterSheetSize.X)
                {
                    MCF.X = 0;
                    ++MCF.Y;

                    if (MCF.Y >= monsterSheetSize.Y)
                    {
                        MCF.Y = 0;
                    }
                }
            }


        }
    }
}
