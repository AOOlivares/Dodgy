using System.Collections.Generic;
using Dodgy.Application.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dodgy.Application
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics;
        private SpriteBatch _spriteBatch;

        private List<IPlayer> _players;
        private readonly IPlayerFactory _playerFactory;

        public Game1()
        {
            var a = Window.ClientBounds;
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferHeight = 600;
            Graphics.PreferredBackBufferWidth = 600;
            Graphics.ApplyChanges();
            Content.RootDirectory = "../../Content";
            IsMouseVisible = true;
        }

        public Game1(IPlayerFactory playerFactory) : this()
        {
            _playerFactory = playerFactory;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _players = new List<IPlayer>()
            {
                _playerFactory.GetPlayerOne(),
                _playerFactory.GetPlayerTwo()
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (var player in _players)
            {
                player.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            foreach (var player in _players)
            {
                player.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
