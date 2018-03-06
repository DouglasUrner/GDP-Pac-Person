using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour {
//	public int dotsEaten = 0;
//
//	private void OnTriggerEnter2D(Collider2D other) {
//		if (other.CompareTag("Player")) {
//			Destroy(gameObject);
//			dotsEaten++;
//		}
//	}

	// Use this for initialization
	void Start () {
		gameObject.tag = "PacDot";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
