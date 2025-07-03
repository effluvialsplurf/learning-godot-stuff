using Godot;
using System;
using System.Collections.Generic;

public partial class TestTimer : Timer
{
    // always declare a variable to reference the node at the beginning which the engine should be able to access
    [Export]
    public TestTimer testTimer { get; set; }

    // method which is called when the node enters the scene initionally
    public override void _Ready()
    {
        // check if the timer node has been assigned
        if (testTimer == null)
        {
            GD.PrintErr("Error: testTimer node is not assigned in the editor!");
            return;
        }

        // set the timers wait time
        testTimer.WaitTime = 1.0f;

        // make the timer repeat on timeout
        testTimer.OneShot = false;

        // connect the timeout method (killing the timer) to the OnTimerTimeout method
        // this should recall the timer on its death
        testTimer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));

        // start the timer
        testTimer.Start();

        GD.Print("Timer initialized and started. waiting for timeouts...");
    }

    // this method should be called instead of normal timeout when the timer 'dies'
    private void OnTimerTimeout()
    {
        // print some message
        GD.Print($"Script executed at: {DateTime.Now.ToLongTimeString()}");

        // get our random instance
        Random _random = new Random();

        // grab all the nodes
        List<Node> sceneNodes = SceneNodeCollector.GetAllChildrenNodes(GetTree().CurrentScene);
        // random index
        int randomIdx = _random.Next(0, sceneNodes.Count);
        // print that jawn
        GD.Print($"Node selected: {sceneNodes[randomIdx]}");
    }
}
