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

        public Point monsterFramesize { get; set; }
        public Point monsterSheetSize { get; set; }

        Point monsterCurrentFrame = new Point(0,0);

        int timeSinceLastFrame = 0;
        int millisecondPerFrame = 200;

        public Vector2 Direction = new Vector2(720, 450);
        public float Speed = 0.01f;
        public Vector2 CurrentPosition = new Vector2(0, 0);
        float Timming = 1f;


        #region monstermove


        #endregion


        /*        public Rectangle SpriteRect
                {
                    get
                    {
                        return new Rectangle((int)Position.X, (int)Position.Y, (int)TextureSize.X, (int)TextureSize.Y);
                    }
                }
                */

        public Sprite(Texture2D texture)
        {
            _texture = texture;


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_texture,CurrentPosition, new Rectangle(
                            (monsterCurrentFrame.X * monsterFramesize.X),
                            (monsterCurrentFrame.Y * monsterFramesize.Y),
                            monsterFramesize.X,
                            monsterFramesize.Y), Color.White, 0, new Vector2 (112,100) , 1, SpriteEffects.None, 0);

        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentPosition.X <= Direction.X || CurrentPosition.Y <= Direction.Y)
            {
                CurrentPosition.X += (Direction.X - CurrentPosition.X)* (Speed * Timming);
                CurrentPosition.Y += (Direction.Y - CurrentPosition.Y)* (Speed * Timming);
            }
            //animation logic
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                ++monsterCurrentFrame.X;

                //monster
                if (monsterCurrentFrame.X >= monsterSheetSize.X)
                {
                    monsterCurrentFrame.X = 0;
                    ++monsterCurrentFrame.Y;

                    if (monsterCurrentFrame.Y >= monsterSheetSize.Y)
                    {
                        monsterCurrentFrame.Y = 0;
                    }
                }
            }
        }
    }
}
