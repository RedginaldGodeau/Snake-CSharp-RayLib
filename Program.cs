

using System.Numerics;
using Raylib_cs;
using SnakeGame.entity;
using SnakeGame.scene;

namespace SnakeGame
{
    class Program
    {
        static readonly int WindowWidth = 1024;
        static readonly int WindowHeight = 768;
        
        static void Main()
        {
            Raylib.InitWindow(WindowWidth, WindowHeight, "Snake Game");
            Raylib.SetTargetFPS(60);
            
            GameScene gameScene = new GameScene(WindowWidth, WindowHeight);
            

            while (!Raylib.WindowShouldClose())
            {
                // UPDATE
                float deltaTIme = Raylib.GetFrameTime();
                
                gameScene.Update(deltaTIme);
                
                // DRAW
                Raylib.BeginDrawing();
                gameScene.Draw();
                Raylib.EndDrawing();
            }
        }
    }
}

