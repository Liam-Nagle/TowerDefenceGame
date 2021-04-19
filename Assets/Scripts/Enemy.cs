using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
	public float speed;
	public int health;
	public int ID;
	public int damage;
	private Transform target;
	private int waypointIndex;
	private Animator animate;

	public void Start()
	{
		target = Waypoints.waypoints[0];

		// Gets Animator Component Off Enemy and Sets the Speed to Enemy Speed.
		animate = GetComponent<Animator>();
		animate.speed = speed;

	}


	public void Update()
	{
		Vector2 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector2.Distance(transform.position, target.position) < 0.01f)
		{
			GetNextWaypoint();
		}
	}

	public int GetID()
	{
		return ID;
	}

	void GetNextWaypoint()
	{
		if (waypointIndex >= Waypoints.waypoints.Length - 1)
		{
			Destroy(gameObject);
			Spawner.EnemiesAlive--;
			return;
		}
		waypointIndex++;
		target = Waypoints.waypoints[waypointIndex];
	}

	void Die()
    {

    }
}

