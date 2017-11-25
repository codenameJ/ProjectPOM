using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POM.Content.Controls;

namespace POM.Sprites
{
    public class Sprite 
    {

        private Texture2D _texture;
        public Vector2 Position { get; set; }
        public Vector2 TextureSize { get; set; }
        public Vector2 Direction = new Vector2(700, 400);
        public Vector2 Distance;
        public Vector2 CurrentPosition;

        public Point monsterFramesize { get; set; }
        public Point monsterSheetSize { get; set; }


        public int treemillisecondPerFrame = 2000;

        public bool IsRemoved;
        public bool GameOverCheck = false;
        public bool GameOver = false;

        public Point monsterCurrentFrame = new Point(0,0);
        public Point PrinceCurrentFrame = new Point(0, 0);

        public int timeSinceLastFrame = 0;
        public int millisecondPerFrame = 200;

        
        public float Speed = 0.5f;
        


        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
              

        public Sprite(Texture2D texture)
        {
            _texture = texture;


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!GameOver)
            {
                spriteBatch.Draw(_texture, Position, new Rectangle(
                    (monsterCurrentFrame.X * monsterFramesize.X),
                    (monsterCurrentFrame.Y * monsterFramesize.Y),
                    monsterFramesize.X,
                    monsterFramesize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
        }
    }
}
