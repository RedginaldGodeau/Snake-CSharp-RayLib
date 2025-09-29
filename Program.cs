

using System.Numerics;
using Raylib_cs;
using SnakeGame.entity;

namespace SnakeGame
{
    class Program
    {
        static readonly int WindowWidth = 1024;
        static readonly int WindowHeight = 768;
        
        
        static void Main()
        {
            Random rand = new Random();
            
            Raylib.InitWindow(WindowWidth, WindowHeight, "Snake Game");
            Raylib.SetTargetFPS(60);

            int score = 0;
            
            Collider groundCollider = new Collider(Vector2.Zero, new Vector2(WindowWidth, WindowHeight));
            
            Player player = new Player(new Vector2(0, 0), new Vector2(50, 50), 100, 0);
            Food food = new Food(new Vector2(rand.Next(0, WindowWidth), rand.Next(0, WindowHeight)),
                new Vector2(30, 30));

            while (!Raylib.WindowShouldClose())
            {
                // UPDATE
                float deltaTIme = Raylib.GetFrameTime();
                
                player.Update(deltaTIme);

                if (player.TouchFood(food.GetCollider()))
                {
                    score++;
                    player.AddSnakeTail(1);
                    food.SetPosition(new Vector2(rand.Next(0, WindowWidth), rand.Next(0, WindowHeight)));
                }

                if (player.TouchTail() || !groundCollider.CheckCollide(player.GetCollider()))
                {
                    Raylib.CloseWindow();
                }
                
                // DRAW
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                player.Draw();
                food.Draw();
                
                
                // UI
                Raylib.DrawText("Score : " + score, 0, 0, 50, Color.Beige);
                
                Raylib.EndDrawing();
            }
        }
    }
}

