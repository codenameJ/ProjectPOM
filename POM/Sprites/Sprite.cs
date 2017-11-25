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
        Vector2 CurrentPosition;


        public Point monsterFramesize { get; set; }
        public Point monsterSheetSize { get; set; }


        public bool IsRemoved;

        Point monsterCurrentFrame = new Point(0,0);
        Point PrinceCurrentFrame = new Point(0, 0);

        int timeSinceLastFrame = 0;
        int millisecondPerFrame = 200;

        
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
         
            spriteBatch.Draw(_texture, Position, new Rectangle(
                (monsterCurrentFrame.X * monsterFramesize.X),
                (monsterCurrentFrame.Y * monsterFramesize.Y),
                monsterFramesize.X,
                monsterFramesize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //monster move to Mars
            Distance.X = Direction.X - Position.X;
            Distance.Y = Direction.Y - Position.Y;
            CurrentPosition = new Vector2(Position.X, Position.Y);
            CurrentPosition.X += (float)Distance.X * (float)Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentPosition.Y += (float)Distance.Y * (float)Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position = CurrentPosition;

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
