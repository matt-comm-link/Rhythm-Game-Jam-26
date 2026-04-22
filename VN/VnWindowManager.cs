using Godot;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public partial class VnWindowManager : Control
{
    [Export]
    Godot.Collections.Array<PackedScene> scenes = new Godot.Collections.Array<PackedScene>();
    [Export]
    public int currentScene;

    Node CurrentScene;
   
    bool Fullscreen = false;

    public override void _Ready()
    {
        DisplayServer.WindowSetTitle("Half Measures");
        CurrentScene = (Node)GetChild(0);
    }


    public void GotoScene(int scene)
    {
        if (scene < scenes.Count)
        {
            //this is so fucking confusing to read
            CurrentScene.QueueFree();
            currentScene = scene;
            CurrentScene = (Node)scenes[currentScene].Instantiate();
            AddChild(CurrentScene);

            //if VN scene
            if(CurrentScene.GetChildCount() == 3)
            {
                GD.Print("dialog box is " + CurrentScene.GetChild(2).Name + "?");
                CurrentScene.GetChild(2).Call("start");
            }
            else
            {
                //use some identifier to tell if rhythm or other menu scene.
            }
        }
    }

    public override void _Input(InputEvent @event)
    {
        if(Input.IsKeyPressed(Key.Alt))
        {
            if(@event is InputEventKey key )
            {
                if(key.Pressed && key.Keycode == Key.Key1)
                    GotoScene(0);
                else if(key.Pressed && key.Keycode == Key.Key2)
                    GotoScene(1);
                else if(key.Pressed && key.Keycode == Key.Key3)
                    GotoScene(2);
                else if(key.Pressed && key.Keycode == Key.Key4)
                    GotoScene(3);
                else if(key.Pressed && key.Keycode == Key.Key5)
                    GotoScene(4);
                else if(key.Pressed && key.Keycode == Key.Key6)
                    GotoScene(5);
                else if(key.Pressed && key.Keycode == Key.Key7)
                    GotoScene(6);
                else if(key.Pressed && key.Keycode == Key.Key8)
                    GotoScene(7);
                else if(key.Pressed && key.Keycode == Key.Key9)
                    GotoScene(8);
                else if(key.Pressed && key.Keycode == Key.Key0)
                    GotoScene(9);
                else if(key.Pressed && key.Keycode == Key.Minus)
                    GotoScene(10);
                else if(key.Pressed && key.Keycode == Key.Equal)
                    GotoScene(11);
            }
            
        }
        if(@event is InputEventKey keyf)
            if(keyf.Pressed && keyf.Keycode == Key.F11)
                Fullscreen = !Fullscreen;
        if(Fullscreen)
           DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
        else
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
 
    }


}
