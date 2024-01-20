using Sandbox;

public sealed class FlappyController : Component
{
	[Property] float jumpForce { get; set; }
	Rigidbody body;
	protected override void OnStart(){
		body = Components.Get<Rigidbody>();
	}
	protected override void OnUpdate()
	{
		if(Input.Pressed("Jump")){
			body.PhysicsBody.SmoothMove(Transform.Position + Vector3.Up * jumpForce, Time.Delta, 0.1f);
		}
	}
}