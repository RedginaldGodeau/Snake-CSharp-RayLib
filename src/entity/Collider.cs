using System.Numerics;
using Raylib_cs;

namespace SnakeGame.entity;

public class Collider(Vector2 position, Vector2 size)
{
    private Rectangle _collider = new Rectangle(position, size);
    
    public Rectangle GetCollider() => _collider;
    
    public Vector2 GetPosition() => _collider.Position;
    public Vector2 GetSize() => _collider.Size;
    
    public void SetSize(Vector2 size) => _collider.Size = size;
    public void SetPosition(Vector2 position) => _collider.Position = position;
    public void AddPosition(Vector2 position) => _collider.Position += position;
    
    public bool CheckCollide(Collider outCollider)
    {
        return Raylib.CheckCollisionRecs(this._collider, outCollider.GetCollider());
    }
    
}