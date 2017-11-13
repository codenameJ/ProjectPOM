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


        #region monstermove

        //       Point monsterFrameSize = new Point(261, 254);
        //       Point monsterSheetSize = new Point(3, 0);
        //       Point monsterCurrentFrame = new Point(0, 0);

        //      int timeSinceLastFrame = 0;
        //       int millisecondPerFrame = 200;

        #endregion
        int MovPX = 0;
        int MovPY = 0;


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


            MovPX++;
            MovPY++;


            spriteBatch.Draw(_texture, new Vector2(MovPX, MovPY), 
                new Rectangle((int)Position.X,(int)Position.Y, 
                (int)TextureSize.X, 
                (int)TextureSize.Y), Color.White
                );
        }

        public override void Update(GameTime gameTime)
        {


        }
    }
}
