using System.Numerics;
using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

namespace SnakeGame.scene;

public class GameOverScene(int width, int height, Action restartGame, Action goToMainMenu)
{

    public void Draw(int score)
    {
        Raylib.ClearBackground(Color.White);
        
        // UI
        rlImGui.Begin();
        
        var viewport = ImGui.GetMainViewport();
        ImGui.SetNextWindowPos(new Vector2(viewport.Size.X * 0.5f, viewport.Size.Y * 0.5f), 
                               ImGuiCond.Always, new Vector2(0.5f, 0.5f));
        ImGui.SetNextWindowSize(new Vector2(width, height), ImGuiCond.Always);

        ImGui.Begin("Game Over", ImGuiWindowFlags.NoResize | 
                                     ImGuiWindowFlags.NoMove | 
                                     ImGuiWindowFlags.NoCollapse);
        
        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(10, 10));
        ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(.8f, .8f, .8f, 1f));
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(1f, 1f, 1f, 1.0f));
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(1f, 1f, 1f, 1.0f));
        
        ImGui.SetCursorPosY(50);
        var titleSize = ImGui.CalcTextSize("Score : " + score);
        ImGui.SetCursorPosX((width - titleSize.X) / 2);
        ImGui.PushFont(ImGui.GetIO().Fonts.Fonts[0]);
        ImGui.TextColored(new Vector4(0.1f, 0.1f, 0.1f, 1.0f), "Score : " + score);
        ImGui.PopFont();

        ImGui.Spacing();
        ImGui.Spacing();
        ImGui.Spacing();
        
        ImGui.SetCursorPosY(150);
        
        if (ImGui.Button("Restart", new Vector2(width - 20, 60)))
        {
            restartGame();
        }

        ImGui.Spacing();

        if (ImGui.Button("Go to main Menu", new Vector2(width - 20, 60)))
        {
            goToMainMenu();
        }

        ImGui.Spacing();

        ImGui.PopStyleColor(3);
        ImGui.PopStyleVar();
            
        ImGui.End();
        rlImGui.End();
        
    }
    
}