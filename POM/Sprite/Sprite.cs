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
        private MouseState _currentMouse;
        private bool _isMovering;
        private MouseState _previousMouse;
        private Texture2D _texture;
        public Vector2 Position { get; set; }
        public Vector2 TextureSize { get; set; }
        public Point monsterFrameSize { get; set; }
        public Point monsterSheetSize { get; set; }
        public Point monsterCurrentFrame { get; set; }
        public int timeSinceLastFrame { get; set; }
        public int millisecondPerFrame { get; set; }

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
                return new Rectangle((int)Position.X, (int)Position.Y, (int)TextureSize.X, (int)TextureSize.Y);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (_isMovering)
            {
                color = Color.Gray;
            }


 //           spriteBatch.Draw(_texture, SpriteRect, color);
            spriteBatch.Draw(_texture, Vector2.Zero, new Rectangle(
                 (monsterCurrentFrame.X * monsterFrameSize.X),
                 (monsterCurrentFrame.Y * monsterFrameSize.Y),
                 monsterFrameSize.X,
                 monsterFrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            _isMovering = false;

            if (mouseRectangle.Intersects(SpriteRect))
            {
                _isMovering = true;
            }


            Point MCF = monsterCurrentFrame;


            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                ++MCF.X;

                //monster
                if (MCF.X >= monsterSheetSize.X)
                {
                    MCF.X = 0;
                    ++MCF.Y;

                    if (monsterCurrentFrame.Y >= monsterSheetSize.Y)
                    {
                        MCF.Y = 0;

                    }
                }
            }

        }
    }
}
