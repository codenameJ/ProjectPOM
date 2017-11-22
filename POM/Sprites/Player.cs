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

        Vector2 princePosition = Vector2.Zero;
        MouseState prevMouseState;

        public Player(Texture2D texture) : base(texture)
        {

        }



        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            foreach (var sprite in sprites)
            {
                if (sprite is Player)
                    continue;
                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    Score++;
                    sprite.IsRemoved = true;
                }
            }
        }

        private void Move()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X != prevMouseState.X || mouseState.Y != prevMouseState.Y)
            {
                princePosition = new Vector2(mouseState.X, mouseState.Y);
                prevMouseState = mouseState;
            }
  
        }
    }
}
