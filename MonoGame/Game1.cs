using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGame
    {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
        {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        List<DisplayMode> displayModeList = new List<DisplayMode>();


        public Game1()
            {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            foreach (DisplayMode displayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
                {
                //displayModeList.Contains(x => (x.Height == displayMode.Height && x.Width == displayMode.Width))
                if (displayModeList.Find(x => x.Height == displayMode.Height) == null)
                    {
                    if (displayModeList.Find(y => y.Width == displayMode.Width) == null)
                        {

                        if ( displayMode.RefreshRate>=60)
                        //displayMode.Height >= 1080 && displayMode.Width >= 1920 && displayMode.RefreshRate>=60)
                            {
                            displayModeList.Add(displayMode);
                            }
                        }
                    }
                }

            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;

            graphics.ApplyChanges();
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
        /// </summary>
        protected override void LoadContent()
            {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("myfont");

            // TODO: use this.Content to load your game content here
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

            base.Update(gameTime);
            }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
            {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            int y = 5;
            foreach (DisplayMode displayMode in displayModeList)
                {
                spriteBatch.DrawString(font,
                    displayMode.Width.ToString() + "x" +
                    displayMode.Height.ToString() + "-" +
                    displayMode.Format.ToString() + " @ " +
                    displayMode.RefreshRate.ToString() + "Hz",
                    new Vector2(0, y), Color.Azure);
                y += 10;
                }

            spriteBatch.End();

            base.Draw(gameTime);
            }
        }
    }
