using System.Numerics;
using Raylib_cs;

namespace SnakeGame.entity;

public class Food(Vector2 position, Vector2 size)
{
    
    private Collider Collider = new Collider(position, size);
    
    public Collider GetCollider() => Collider;

    public void SetPosition(Vector2 position)
    {
        this.Collider.SetPosition(position);
    }
    
    public void Draw()
    {
        Raylib.DrawRectangleV(Collider.GetPosition(), Collider.GetSize(), Color.Red);
    }
    
}