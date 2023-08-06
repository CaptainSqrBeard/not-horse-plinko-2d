using Godot;
using System;

public partial class ParticleController : GpuParticles2D
{
	public void SetState(bool state)
	{
		Emitting = state;
	}
	public void Shoot()
	{
		Emitting = true;
		Emitting = false;
	}
}
