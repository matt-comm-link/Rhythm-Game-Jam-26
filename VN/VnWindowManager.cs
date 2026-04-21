using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class VnWindowManager : Control
{
    [Export]
    Godot.Collections.Array<PackedScene> scenes = new Godot.Collections.Array<PackedScene>();
    [Export]
    public int currentScene;

    Control CurrentScene;

    public void GotoScene(int scene)
    {
        if (scene < scenes.Count)
        {
            //this is so fucking confusing to read
            CurrentScene.QueueFree();
            currentScene = scene;
            CurrentScene = (Control)scenes[currentScene].Instantiate();
            AddChild(CurrentScene);

            //if VN scene
            if(CurrentScene.GetChildCount() == 3)
            {
                CurrentScene.GetChild(1).Call("start", 0);
            }
            else
            {
                //use some identifier to tell if rhythm or other menu scene.
            }
        }
    }

}
