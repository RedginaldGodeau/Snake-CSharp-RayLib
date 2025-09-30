using System.Numerics;
using ImGuiNET;
using Raylib_cs;
using rlImGui_cs;

namespace SnakeGame.scene;

public class MenuScene(int width, int height, Action startGame)
{
    public void Draw()
    {
        Raylib.ClearBackground(Color.White);
        
        rlImGui.Begin();
        
        var viewport = ImGui.GetMainViewport();
        ImGui.SetNextWindowPos(new Vector2(viewport.Size.X * 0.5f, viewport.Size.Y * 0.5f), 
                               ImGuiCond.Always, new Vector2(0.5f, 0.5f));
        ImGui.SetNextWindowSize(new Vector2(width, height), ImGuiCond.Always);

        ImGui.Begin("Menu Principal", ImGuiWindowFlags.NoResize | 
                                     ImGuiWindowFlags.NoMove | 
                                     ImGuiWindowFlags.NoCollapse);
        
        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(10, 10));
        ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(.8f, .8f, .8f, 1f));
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(1f, 1f, 1f, 1.0f));
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(1f, 1f, 1f, 1.0f));
        
        ImGui.SetCursorPosY(50);
        var titleSize = ImGui.CalcTextSize("SNAKE GAME");
        ImGui.SetCursorPosX((width - titleSize.X) / 2);
        ImGui.PushFont(ImGui.GetIO().Fonts.Fonts[0]);
        ImGui.TextColored(new Vector4(0.1f, 0.1f, 0.1f, 1.0f), "SNAKE GAME");
        ImGui.PopFont();

        ImGui.Spacing();
        ImGui.Spacing();
        ImGui.Spacing();
        
        ImGui.SetCursorPosY(150);
        
        if (ImGui.Button("Nouvelle Partie", new Vector2(width - 20, 60)))
        {
            startGame();
        }

        ImGui.Spacing();

        if (ImGui.Button("Quitter", new Vector2(width - 20, 60)))
        {
            Raylib.CloseWindow();
        }

        ImGui.Spacing();

        ImGui.PopStyleColor(3);
        ImGui.PopStyleVar();

        ImGui.End();
            
        rlImGui.End();
        
    }
    
}