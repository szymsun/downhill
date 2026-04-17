using Godot;
using System;
using downhill;

public partial class CarForces : RigidBody3D
{
    [Export] public int Acceleration;
    [Export] public int Braking;
    [Export] public int MaxSpeed = 150;
    
    
    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }

    public override void _PhysicsProcess(double delta)
    {
        ApplyForce(_appliedForce);
        LinearVelocity = LinearVelocity.LimitLength(MaxSpeed);
    }

    private Vector3 _appliedForce;

    private float _throttle;
    private float _steer;
    
    public override void _Process(double delta)
    {
        var forward = -GlobalTransform.Basis.Z;
        _steer = Input.GetAxis("SteerRight", "SteerLeft");
        _throttle = Input.GetAxis("Back","Throttle");

        _throttle = _throttle < 0 ? _throttle * Braking : _throttle * Acceleration; 
        _appliedForce = forward * _throttle;
        
        DebugInfo.SetParameter("velocity",LinearVelocity.ToString());
    }

    public override void _Ready()
    {
         
    }
}
