using System.Numerics;
using Raylib_cs;

namespace SnakeGame.entity;

public class Food(Vector2 position, Vector2 size)
{
    
    private readonly Collider _collider = new Collider(position, size);
    
    public Collider GetCollider() => this._collider;
    
    private readonly Sprite _foodSprite = new Sprite("assets/images/apple.png");

    
    public void Load()
    {
        _foodSprite.Load();
    }

    public void SetPosition(Vector2 position)
    {
        _collider.SetPosition(position);
    }
    
    public void Draw()
    {
        _foodSprite.Draw(_collider.GetCollider(), 0, Vector2.Zero, false);
    }
    
}