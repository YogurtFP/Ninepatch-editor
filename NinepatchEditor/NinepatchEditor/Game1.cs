using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using YogUILibrary;
using YogUILibrary.UIComponents;
using YogUILibrary.Managers;
using YogUILibrary.Structs;

namespace NinepatchEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Button loadExistingNinepatch;
        public Button createNewNinepatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            

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
            YogUI.YogUI_LoadContent(this);
            SpriteFont buttonFont = Content.Load<SpriteFont>("buttonFont");
            createNewNinepatch = new Button(new Vector2(200, 100), "Create new Ninepatch", buttonFont, createNew);
            loadExistingNinepatch = new Button(new Vector2(200, 150), "Load existing Ninepatch", buttonFont, loadExisting);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            YogUI.YogUI_Update(gameTime);

            createNewNinepatch.Update(gameTime);
            loadExistingNinepatch.Update(gameTime);

            base.Update(gameTime);
        }

        public void createNew()
        {
            var open = new System.Windows.Forms.OpenFileDialog();
            open.SupportMultiDottedExtensions = true;
            open.DefaultExt = ".png";
            open.Filter = "PNG files|*.png|All files|*";
            open.ShowDialog();
        }

        public void loadExisting()
        {
            var open = new System.Windows.Forms.OpenFileDialog();
            open.SupportMultiDottedExtensions = true;
            open.DefaultExt = ".9.png";
            open.Filter = "Ninepatch files|*.9.png|All files|*";
            open.ShowDialog();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            createNewNinepatch.Draw(spriteBatch);
            loadExistingNinepatch.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
