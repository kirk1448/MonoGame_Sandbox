using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace TestMonogameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D ballTexture;
        Texture2D fireTexture;
        Texture2D smokeTexture;
        World world;


        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 480;

            world = new World();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ballTexture = Content.Load<Texture2D>("ball");
            fireTexture = Content.Load<Texture2D>("fire");
            smokeTexture = Content.Load<Texture2D>("smoke");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            world.gameTime = gameTime.TotalGameTime.TotalMilliseconds;
            world.WorldUpdate();

            var kstate = Keyboard.GetState();
            var mstate = Mouse.GetState();

            if (kstate.IsKeyDown(Keys.X))
            {
                world.createTile(new Vector2(mstate.X/world.TILE_SIZE, mstate.Y/ world.TILE_SIZE));
            }
            if (kstate.IsKeyDown(Keys.C))
            {
                world.createMoreTile(new Vector2(mstate.X / world.TILE_SIZE, mstate.Y / world.TILE_SIZE));
            }
            if (kstate.IsKeyDown(Keys.Z))
            {
                world.createMoreTile(new Vector2(mstate.X / world.TILE_SIZE, mstate.Y / world.TILE_SIZE), 2);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            for (int x = 0; x < world.WORLD_SIZE * 2; x++)
            {
                for (int y = 0; y < world.WORLD_SIZE; y++)
                {
                    if (world.tiles[x,y] == 1)
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(ballTexture, new Vector2(x * world.TILE_SIZE, y * world.TILE_SIZE), Color.White);
                        _spriteBatch.End();
                    }
                    if (world.tiles[x, y] == 2)
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(fireTexture, new Vector2(x * world.TILE_SIZE, y * world.TILE_SIZE), Color.White);
                        _spriteBatch.End();
                    }
                    if (world.tiles[x, y] == 3)
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(smokeTexture, new Vector2(x * world.TILE_SIZE, y * world.TILE_SIZE), Color.White);
                        _spriteBatch.End();
                    }
                }
            }

            base.Draw(gameTime);
        }
    }
}