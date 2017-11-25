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
    class Tree : Sprite
    {
        public Tree(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            /*            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

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
                        }*/
         }
    }


}
