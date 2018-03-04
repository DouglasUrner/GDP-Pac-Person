﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {
	public float speed = 0.4f;
	
	Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start () {
		dest = transform.position;
	}
	
	// FixedUpdate() is called at fixed intervals
	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);

		if ((Vector2) transform.position == dest) {
			if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up)) {
				dest = (Vector2) transform.position + Vector2.up;
			} 
			if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right)) {
				dest = (Vector2) transform.position + Vector2.right;
				Debug.Log("right");
			} 
			if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down)) {
				dest = (Vector2) transform.position - Vector2.up;
			} 
			if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left)) {
				dest = (Vector2) transform.position - Vector2.right;
			}
		}
	}

	bool valid(Vector2 dir) {
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		bool valid = (hit.collider == GetComponent<Collider2D>());
		print(valid);
		return valid;
	}
}
