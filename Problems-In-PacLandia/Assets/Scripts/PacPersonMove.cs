using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacPersonMove : MonoBehaviour {
	public float speed = 0.4f;
	public int PacDotsEaten = 0;
	
	Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start () {
		dest = transform.position;
	}
	
	// Update is called once per tick
	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);

		if ((Vector2) transform.position != dest) {
			// Already moving...
			return;
		}

		if (Input.GetKey(KeyCode.UpArrow) && validMove(Vector2.up)) {
			dest = (Vector2) transform.position + Vector2.up;
		}
		if (Input.GetKey(KeyCode.RightArrow) && validMove(Vector2.right)) {
			dest = (Vector2) transform.position + Vector2.right;
		}
		if (Input.GetKey(KeyCode.DownArrow) && validMove(Vector2.down)) {
			dest = (Vector2) transform.position + Vector2.down;
		}
		if (Input.GetKey(KeyCode.LeftArrow) && validMove(Vector2.left)) {
			dest = (Vector2) transform.position + Vector2.left;
		}

		Vector2 dir = dest - (Vector2) transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("PacDot")) {
			Destroy(other.gameObject);
			PacDotsEaten++;
		}
	}

	private bool validMove(Vector2 dir) {
		// Test if move is possible by casting a line back from the
		// spot are checking to PacPerson - if it hits our collider,
		// nothing is in the way and we can move.
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}
}
