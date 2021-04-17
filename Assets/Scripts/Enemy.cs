using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
	public float speed;
	public int health
	public int ID;
	private Transform target;
	private int waypointIndex;

	public void Start()
	{
		target = Waypoints.waypoints[0];
	}


	public void Update()
	{
		Vector2 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector2.Distance(transform.position, target.position) < 0.1f)
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

