using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace POM.Content.Controls
{
    public class Button : Component
    {
        #region Fields

        private MouseState _currentMouse;
        private bool _isMovering;
        private MouseState _previousMouse;
        private Texture2D startmoon;

        #endregion

        #region Properties

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Vector2 Position { get; set; }
        public Rectangle StartMoonRect
        {
            get
            {
                return new Rectangle(290, 350, 200, 100);
            }
        }


        #endregion

        #region Methods

        public Button(Texture2D texture)
        {
            startmoon = texture;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (_isMovering)
                color = Color.Gray;
            spriteBatch.Draw(startmoon, new Rectangle(290, 350, 200 , 100) , color);

        }


        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 0, 0);
            _isMovering = false;

            if(mouseRectangle.Intersects(StartMoonRect))
            {
                _isMovering = true;
                if(_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton==ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
        
                }
            }
        }

#endregion
    }
}
