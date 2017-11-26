using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace POM.Sprites
{
    class Item : Sprite
    {
        public Item(Texture2D texture) : base(texture)
        {
        }


        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            Distance.X = Direction.X - Position.X;
            Distance.Y = Direction.Y - Position.Y;
            CurrentPosition = new Vector2(Position.X, Position.Y);
            CurrentPosition.X += (float)Distance.X * (float)Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentPosition.Y += (float)Distance.Y * (float)Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position = CurrentPosition;

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                ++monsterCurrentFrame.X;

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

            foreach (var sprite in sprites)
            {
                if (sprite is Monster)
                    continue;
                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    if (sprite is Player)
                    {
                    }
                }
            }
        }
    }
}
