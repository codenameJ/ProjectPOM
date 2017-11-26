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
    public class Player : Sprite
    {
        public int Score;

        public Color[] textureData;
        MouseState prevMouseState;

        public Player(Texture2D texture) : base(texture)
        {

        }



        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();


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
                if (sprite is Player)
                    continue;
                if (sprite is Mars)
                    continue;
                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    if (sprite is Monster)
                    {
                        Score++;
                        sprite.IsRemoved = true;
                    }
                    if(sprite is Item)
                    {
                        sprite.IsRemoved = true;
                    }
                }
                FinalScore = Score;
            }

        }

        private void Move()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X != prevMouseState.X || mouseState.Y != prevMouseState.Y)
            {
                Position = new Vector2(mouseState.X, mouseState.Y);
                prevMouseState = mouseState;
            }
  
        }
    }
}
