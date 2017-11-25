using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using POM.Content.Controls;
using POM.States;

namespace POM.Sprites
{
    public class Mars : Sprite
    {
        public Mars(Texture2D texture) : base(texture)
        {
        }


        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > treemillisecondPerFrame)
            {
                timeSinceLastFrame -= treemillisecondPerFrame;
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
                        sprite.GameOver = true;
                    }



            }
        }
    }
}
