using System.Numerics;
using Raylib_cs;

namespace SnakeGame.entity;

public class Player(Vector2 snakePosition, Vector2 snakeSize, float speed, int tailLenght)
{
    
    private Collider _snakeHead = new Collider(snakePosition, snakeSize);
    private int _tailLenght = tailLenght;
    
    private List<Collider> _snakeTail = new List<Collider>();
    private Vector2 _direction = Vector2.Zero;

    public void AddSnakeTail(int value)
    {
        this._tailLenght += value;
    }

    public bool TouchFood(Collider foodCollider)
    {
        return this._snakeHead.CheckCollide(foodCollider);
    }

    public bool TouchTail()
    {
        if (this._direction == Vector2.Zero) return false;
        
        for (int i = 0; i < _snakeTail.Count - snakeSize.X; i++)
        {
            Console.WriteLine(i);
            return this._snakeHead.CheckCollide(_snakeTail[i]);
        }

        return false;
    }

    public void Update(float deltaTime)
    {
        if (Raylib.IsKeyDown(KeyboardKey.A) && this._direction != new Vector2(1, 0))
        {
            this._direction = new Vector2(-1, 0);
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.D) && this._direction != new Vector2(-1, 0))
        {
            this._direction = new Vector2(1, 0);
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.W) && this._direction != new Vector2(0, 1))
        {
            this._direction = new Vector2(0, -1);
        }
        
        if (Raylib.IsKeyDown(KeyboardKey.S) && this._direction != new Vector2(0, -1))
        {
            this._direction = new Vector2(0, 1);
        }
        
        this._snakeHead.AddPosition(this._direction * deltaTime * speed);
        this._snakeTail.Add(new Collider(this._snakeHead.GetPosition(), this._snakeHead.GetSize()));

        if (this._snakeTail.Count >= (snakeSize.X / 2) * _tailLenght)
        {
            this._snakeTail.RemoveAt(0);
        }
    }

    public void Draw()
    {
        foreach (var tail in _snakeTail)
        {
            Raylib.DrawRectangleV(tail.GetPosition(), tail.GetSize(), Color.Blue);
        }
        Raylib.DrawRectangleV(_snakeHead.GetPosition(), _snakeHead.GetSize(), Color.DarkBlue);
    }
}