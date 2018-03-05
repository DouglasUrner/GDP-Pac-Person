using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour {
	public TextAsset waypointList;
	public float speed = 0.2f;
	public Transform[] waypoints;
	public int cur = 0; // The current waypoint.

	// Use this for initialization
	void Start () {
		// TODO: set waypoints from maze definition file.
		//setWaypoints();
	}

	void setWaypoints() {
		// Read the maze description.
		// TODO: handle missing or malformed description file.
		string waypointLocs = waypointList.text;

		// TODO: flip the maze
		// TODO: do file processing in a common method that calls this one

		// Count waypoints
		int waypointCount = 0;
		foreach (var s in waypointLocs) {
			if (s == 'b') {
				waypointCount++;
			}
		}

		waypoints = new Transform[waypointCount];

		// Loop over the lines of the description placing prefabs:
		// - MazeWall for each 'x'
		// - PacDot for each '-'
		// - Empty space for each ' '
		int row = 0;
		int col = 0;
		int cur = 0;
		foreach (var s in waypointLocs) {
			switch (s) {
				case 'x':
				case '-':
				case ' ':
					// Ignore maze definition characters.
				case 'p':
					// Ignore other ghost's waypoints.
					col++;
					break;

				case 'b':
					// On the maze ghost waypoints are PacDots.
					GameObject wp = new GameObject();
					Vector2 pos = wp.transform.position;
					wp.name = "wp" + cur + " (" + col + ", " + row + ")";
					pos.x = col++;
					pos.y = row;
					wp.transform.position = pos;
					waypoints[cur++] = wp.transform;
					break;

				case '\n':
					row++;
					col = 0;
					break;
			}
		}
	}
	
	// FixedUpdate is called once per tick
	private void FixedUpdate() {
		if (!closeEnough(transform, waypoints[cur])) {
			Vector2 p = Vector2.MoveTowards(transform.position,
																			waypoints[cur].position,
																			speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		} else {
			cur = ++cur % waypoints.Length;
		}

		Vector2 dir = waypoints[cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	private bool closeEnough(Transform a, Transform b) {
		return ((Mathf.Abs(a.position.x - b.position.x) < 0.1) &&
		        (Mathf.Abs(a.position.y - b.position.y) < 0.1));
	}

	private void OnTriggerEnter2D(Collider2D c) {
		if (c.CompareTag("PacPerson")) {
			Destroy(c.gameObject);
		}
	}
}
