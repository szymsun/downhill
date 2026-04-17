using Godot;
using System;

public partial class CameraHandle : Node3D
{
    [Export]
    public Vector3 Offset;
    
    [Export]
    public Node3D Target;

    private Camera3D _cam;
    
    public override void _Process(double delta)
    {
        SetPosition(Target.Position + Offset);
    }

    public override void _Ready()
    {
        _cam = GetNode<Camera3D>("PlayerCam");
    }
}
