using System.Numerics;
using SnakeGame.entity;
using Raylib_cs;

namespace SnakeGame.scene;

public class GameScene(int width, int height, Action gameOver)
{
    private static readonly Random Rand = new Random();
    
    private int _score = 0;
    private readonly Collider _groundCollider = new Collider(Vector2.Zero, new Vector2(width, height));
    
    private Player _player = new Player(new Vector2(0, 0), new Vector2(50, 50), 200, 0);
    private Food _food = new Food(new Vector2(Rand.Next(0, width), Rand.Next(0, height)),
        new Vector2(30, 30));

    public int GetScore() => this._score;

    public void Restart()
    {
        this._score = 0;
        this._player = new Player(new Vector2(0, 0), new Vector2(50, 50), 200, 0);
        this._food = new Food(new Vector2(Rand.Next(0, width), Rand.Next(0, height)),
            new Vector2(30, 30));
    }

    public void Update(float deltaTime)
    {
        _player.Update(deltaTime);

        if (_player.TouchFood(_food.GetCollider()))
        {
            _score++;
            _player.AddSnakeTail(1);
            _food.SetPosition(new Vector2(Rand.Next(0, width), Rand.Next(0, height)));
        }

        if (_player.TouchTail() || !_groundCollider.CheckCollide(_player.GetCollider()))
        {
            gameOver();
        }
    }

    public void Draw()
    {
        Raylib.ClearBackground(Color.White);

        _player.Draw(); 
        _food.Draw();
        
        // UI
        Raylib.DrawText("Score : " + _score, 0, 0, 16, Color.Black);
    }
    
}