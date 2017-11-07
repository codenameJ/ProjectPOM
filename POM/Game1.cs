using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using POM.Content.Controls;
using System;
using System.Collections.Generic;

namespace POM
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D StartMoon; //StartBot;

        private Color _backgroundColour = Color.CornflowerBlue;
        private List<Component> _gameComponent;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
 
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var randomButton = new Button(Content.Load<Texture2D>("Controls/startgame"))
            {
                Position = new Vector2(500,520),
                TextureSize = new Vector2(350,180)
            };
            randomButton.Click += RandomButton_Click;

            var quitebot = new Button(Content.Load<Texture2D>("Controls/howtoplay"))
            {
                Position = new Vector2(480, 650),
                TextureSize = new Vector2(400,180)
            };
 

            quitebot.Click += Quite_Click;


            _gameComponent = new List<Component>()
            {
                randomButton,
                quitebot,
            };

            // TODO: use this.Content to load your game content here



            StartMoon = Content.Load<Texture2D>("MainMoon");
 //           StartBot = Content.Load<Texture2D>("startgame");
        }

        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            var random = new Random();
            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

        }

        private void Quite_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var component in _gameComponent)
                component.Update(gameTime); 
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColour);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            foreach (var component in _gameComponent)
            component.Draw(gameTime, spriteBatch);

            spriteBatch.Draw(StartMoon, new Rectangle(380,10,620,570), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
