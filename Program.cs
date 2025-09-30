using Raylib_cs;
using rlImGui_cs;
using SnakeGame.scene;

namespace SnakeGame
{
    
    enum GameState
    {
        MainMenu,
        Playing,
        GameOver,
    }
    
    class Program
    {
        static readonly int WindowWidth = 1024;
        static readonly int WindowHeight = 768;
        
        static void Main()
        {
            Raylib.InitWindow(WindowWidth, WindowHeight, "Snake Game");
            Raylib.SetTargetFPS(60);
            rlImGui.Setup(false);
            
            GameState currentState = GameState.MainMenu;

            GameScene gameScene = new GameScene(WindowWidth, WindowHeight, () => { currentState = GameState.GameOver; });
            GameOverScene gameOverScene = new GameOverScene(WindowWidth, WindowHeight, () =>
                {
                    currentState = GameState.Playing;
                    gameScene.Restart();
                },
                () =>
                {
                    currentState = GameState.MainMenu;
                });
            MenuScene menuScene = new MenuScene(WindowWidth, WindowHeight, () =>
            {
                currentState = GameState.Playing;
                gameScene.Restart();
            });

            while (!Raylib.WindowShouldClose())
            {
                // UPDATE
                float deltaTIme = Raylib.GetFrameTime();
                
                switch (currentState)
                {
                    case GameState.Playing:
                        gameScene.Update(deltaTIme);
                        break;
                }
                
                
                // DRAW
                Raylib.BeginDrawing();
                switch (currentState)
                {
                    case GameState.MainMenu:
                        menuScene.Draw();
                        break;
                    case GameState.Playing:
                        gameScene.Draw();
                        break;
                    case GameState.GameOver:
                        gameOverScene.Draw(gameScene.GetScore());
                        break;
                }
                Raylib.EndDrawing();
            }
            
            rlImGui.Shutdown();
            Raylib.CloseWindow();
        }
    }
}