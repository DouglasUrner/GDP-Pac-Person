using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {
	void OnClick() {
		Application.LoadLevel("Scene_0");
	}
}
