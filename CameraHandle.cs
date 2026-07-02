using Godot;
using System;

public partial class CameraHandle : Node3D
{
    [Export]
    public Node3D Target;

    [Export] public float Interpolation;

    private Camera3D _cam;
    
    public override void _Process(double delta)
    {
        SetRotation(Target.Rotation);
        SetPosition(Position.Lerp(Target.Position, Interpolation));
    }

    public override void _Ready()
    {
        _cam = GetNode<Camera3D>("PlayerCam");
    }
}
