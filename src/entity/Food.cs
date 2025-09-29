using System.Numerics;
using Raylib_cs;

namespace SnakeGame.entity;

public class Food(Vector2 position, Vector2 size)
{
    
    private readonly Collider _collider = new Collider(position, size);
    
    public Collider GetCollider() => this._collider;

    public void SetPosition(Vector2 position)
    {
        this._collider.SetPosition(position);
    }
    
    public void Draw()
    {
        Raylib.DrawRectangleV(this._collider.GetPosition(), this._collider.GetSize(), Color.Red);
    }
    
}