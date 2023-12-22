using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NotTerraria;

public class TileGrid
{
    public const int ViewTileSize = 16;
    public const int TileSize = 8;
    
    public readonly byte[][] Data;

    public readonly int Width;
    public readonly int Height;

    private Texture2D _atlasTexture;

    public TileGrid(int width, int height)
    {
        Width = width;
        Height = height;
        
        Data = new byte[width][];
        for (int x = 0; x < width; x++)
            Data[x] = new byte[height];
    }

    public void LoadContent(ContentManager content)
    {
        _atlasTexture = content.Load<Texture2D>("Atlas");
    }
    
    public void Draw(SpriteBatch batch)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                byte tile = Data[x][y];

                if (tile == 0) continue;

                Rectangle src = Tiles.Areas[tile - 1];
                src.X *= TileSize;
                src.Y *= TileSize;
                src.Width *= TileSize;
                src.Height *= TileSize;
                
                batch.Draw(
                    _atlasTexture, 
                    new Rectangle(x * ViewTileSize, y * ViewTileSize, ViewTileSize, ViewTileSize), 
                    src, 
                    Color.White
                    );
            }
        }
    }
}