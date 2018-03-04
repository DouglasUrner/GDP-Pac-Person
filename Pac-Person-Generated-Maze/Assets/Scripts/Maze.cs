using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
	public TextAsset mazeDescription;
	public GameObject mazeWallPrefab;
	public GameObject pacDotPrefab;

	// Generate the Maze
	void Start() {
		generateMaze();
	}

	void generateMaze() {
		// Read the maze description.
		// TODO: handle missing or malformed description file.
		string mazeDesc = mazeDescription.text;

		// TODO: Flip the maze

		// Loop over the lines of the description placing prefabs:
		// - MazeWall for each 'x'
		// - PacDot for each '-'
		// - Empty space for each ' '
		int row = 0;
		int col = 0;
		foreach (var s in mazeDesc) {
			switch (s) {
				case 'x':
					placeElement(mazeWallPrefab, col++, row);
					break;

				case '-':
					placeElement(pacDotPrefab, col++, row);
					break;

				case ' ':
					col++;
					break;

				case '\n':
					row++;
					col = 0;
					break;
			}
		}
	}

	// Set the position and parent of the maze element.
	void placeElement(GameObject prefab, int x, int y) {
		// Instantiate the prefab and make it a child of the maze.
		GameObject go = Instantiate(prefab, transform);

		// Set the location - tronsform.position must be set atomically.
		Vector3 pos = go.transform.position;
		pos.x = x;
		pos.y = y;
		go.transform.position = pos;

		// Name element by its position.
		go.name = prefab.name + " (" + x + ", " + y + ")";
	}
}