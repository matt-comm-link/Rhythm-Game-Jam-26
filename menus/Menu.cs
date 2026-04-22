using Godot;
using System;

public partial class Menu : Control
{
    VnWindowManager manager;

    public override void _Ready()
    {
        manager = GetParent<VnWindowManager>();

    }

    public void GotoGame()
    {
        manager.GotoScene(1);
    }

    public void GotoCredits()
    {
        manager.GotoScene(11);
    } 

    public void GotoStart()
    {
        manager.GotoScene(0);
    } 
    
}
