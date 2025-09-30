using System.Numerics;
using Raylib_cs;

namespace SnakeGame.entity;

public class Sprite(string filePath)
{
    private Texture2D _texture;

    public void Load()
    {
        _texture = Raylib.LoadTexture(filePath);
        Raylib.SetTextureFilter(_texture, TextureFilter.Point);
        Raylib.SetTextureWrap(_texture, TextureWrap.Clamp);
        
        if (_texture.Id == 0)
        {
            Console.WriteLine($"Erreur : La texture '{filePath}' n'a pas pu être chargée.");
        }
    }

    public void Draw(Rectangle renderBox, float angle, Vector2 origin, bool debug = false)
    {
        Rectangle sourceTexture = new Rectangle(new Vector2(0, 0), new Vector2(_texture.Width, _texture.Height));
        Raylib.DrawTexturePro(_texture, sourceTexture, renderBox, origin, angle, Color.White);

        if (debug)
        {
            Raylib.DrawRectangleLinesEx(renderBox, 2, Color.Blue);
        }
    }
}