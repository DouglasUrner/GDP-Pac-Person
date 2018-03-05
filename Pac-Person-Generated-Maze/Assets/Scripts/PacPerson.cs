using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacPerson : MonoBehaviour {
	public float speed = 0.3f;

	private Vector2 dest = Vector2.zero;

	void Start () {
		// Start off going nowhere.
		dest = transform.position;
	}
	
	void FixedUpdate () {
		Vector2 moveTo = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(moveTo);

		if ((Vector2) transform.position == dest) {
			// We're not moving...
			if (Input.GetKey(KeyCode.UpArrow)&& canMove(Vector2.up)) {
				dest = (Vector2) transform.position + Vector2.up;
			}
			if (Input.GetKey(KeyCode.RightArrow) && canMove(Vector2.right)) {
				dest = (Vector2) transform.position + Vector2.right;
			}
			if (Input.GetKey(KeyCode.DownArrow)&& canMove(Vector2.down)) {
				dest = (Vector2) transform.position + Vector2.down;
			}
			if (Input.GetKey(KeyCode.LeftArrow)&& canMove(Vector2.left)) {
				dest = (Vector2) transform.position + Vector2.left;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		//print("trigger: " + c.name);
		if (c.CompareTag("PacDot")) {
			// TODO: track score events.
			Destroy(c.gameObject);
		}
	}

	/**
	 * bool canMove(dir) - check if we can move in the direction indicated by dir.
	 *
	 * Method: Linecast from a point one move in the direction we are trying to
	 * go back towards our character. If the hit is on our collider then we there
	 * is nothing blocking our way. Otherwise an obstacle (wall) is on our way.
	 */
	bool canMove(Vector2 dir) {
		Collider2D myCollider = GetComponent<Collider2D>();
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		bool canMove = (hit.collider == myCollider);
		//print("hit collider: " + hit.collider + " myCollider: " + myCollider + " canMove: " + canMove);
		return canMove;
	}
}
