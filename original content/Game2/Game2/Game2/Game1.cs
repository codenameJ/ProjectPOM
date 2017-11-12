using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D spritesheet;
        Texture2D tree;

        //monster
        Point monsterFrameSize = new Point(261, 254);
        Point monsterSheetSize = new Point(3, 0);

        //tree
        Point treeFrameSize = new Point(401, 406);
        Point treeSheetSize = new Point(7, 4);

        Point monsterCurrentFrame = new Point(0, 0);

        int timeSinceLastFrame = 0;
        int millisecondPerFrame = 200;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>,
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            spritesheet = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream(@"Images/monster.png"));
            tree = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream(@"Images/tree.png"));
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

            // TODO: Add your update logic here

            //animation logic
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                ++monsterCurrentFrame.X;

                //monster
                if(monsterCurrentFrame.X >= monsterSheetSize.X)
                {
                    monsterCurrentFrame.X = 0;
                    ++monsterCurrentFrame.Y;

                    if(monsterCurrentFrame.Y >= monsterSheetSize.Y)
                    {
                        monsterCurrentFrame.Y = 0;
                        
                    }
                }

                //tree
                /*
                if (treeCurrentFrame.X >= treeSheetSize.X)
                {
                    treeCurrentFrame.X = 0;
                    ++treeCurrentFrame.Y;

                    if (treeCurrentFrame.Y >= treeSheetSize.Y)
                    {
                        treeCurrentFrame.Y = 0;

                    }
                }
                */

            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //monster
            spriteBatch.Draw(spritesheet, Vector2.Zero, new Rectangle(
                (monsterCurrentFrame.X * monsterFrameSize.X),
                (monsterCurrentFrame.Y * monsterFrameSize.Y),
                monsterFrameSize.X,
                monsterFrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            //tree
             spriteBatch.Draw(tree, new Vector2(200, 200), new Rectangle(
                (monsterCurrentFrame.X * treeFrameSize.X),
                (monsterCurrentFrame.Y * monsterCurrentFrame.Y),
                treeFrameSize.X,
                treeFrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);





            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
