using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour {
	// TODO: make strategy an enum.
	public int strategy = 0;
	public Transform[] waypoints;
	public int cur = 0;
	public float speed = 0.3f;

	Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start () {
		dest = transform.position;
	}
	
	// Update is called once per tick
	void FixedUpdate() {
		if ((Vector2) transform.position != dest) {
			Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}

		switch (strategy) {
			case 0:
				// Waypoints
				if ((Vector2) transform.position == dest) {
					cur = (cur + 1) % waypoints.Length;
					dest = waypoints[cur].position;
				}

			break;
		}

		// Animation
		Vector2 dir = waypoints[cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.CompareTag("Player"))
			Destroy(co.gameObject);
	}
}
