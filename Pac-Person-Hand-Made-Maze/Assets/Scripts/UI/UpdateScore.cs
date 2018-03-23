using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {
	public static int points = 0;
	private Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + points;
	}
}
