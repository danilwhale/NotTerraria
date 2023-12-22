using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NotTerraria;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private TileGrid _grid;
    private Camera _camera;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _grid = new TileGrid(32, 32);

        for (int x = 0; x < _grid.Width; x++)
        {
            for (int y = 0; y < _grid.Height / 2; y++)
            {
                if (y == 1) _grid.Data[x][y] = 2;
                else if (y == 0) _grid.Data[x][y] = 3;
                else _grid.Data[x][y] = 1;
            }
        }

        _camera = new Camera(new Vector2(0.0f, 0.0f), 1.0f, 0.0f);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _grid.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.W)) _camera.Position.Y += 500 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (keyboard.IsKeyDown(Keys.S)) _camera.Position.Y -= 500 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (keyboard.IsKeyDown(Keys.A)) _camera.Position.X += 500 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (keyboard.IsKeyDown(Keys.D)) _camera.Position.X -= 500 * (float)gameTime.ElapsedGameTime.TotalSeconds;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(samplerState: SamplerState.PointWrap, transformMatrix: _camera.CreateTransform());
        
        _grid.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}