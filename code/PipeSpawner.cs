using System;
using System.Collections.Generic;
using Sandbox;

public sealed class PipeSpawner : Component
{
	[Property] float DelayInSeconds { get; set; } = 1;
	[Property] float initialDelay { get; set; } = 2;
	[Property] float pipeSpeed { get; set; } = .5f;
	[Property] float heightVariance { get; set; } = 20f;

	[Property] GameObject pipePrefab { get; set; }

	private TimeSince lastSpawn;
	GameObject pipe;
	bool spawnPipes;
	List<GameObject> pipes = new();

	protected override async void OnEnabled(){
		await Task.DelaySeconds(initialDelay);
		spawnPipes = true;
	}
	protected override void OnUpdate()
	{
		if( lastSpawn >= DelayInSeconds && spawnPipes == true && pipes.Count <= 5){
			lastSpawn = 0f;
			pipe = pipePrefab.Clone();
			pipe.Transform.Position = Transform.Position.WithZ(Game.Random.Float(-heightVariance, heightVariance));
			pipes.Add(pipe);
		}
		if(pipes != null){
			foreach(GameObject p in pipes){
				p.Transform.Position += -Vector3.Left * pipeSpeed;
			}
		}
	}
}