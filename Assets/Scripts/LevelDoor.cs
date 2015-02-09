using UnityEngine;
using System.Collections;

public class LevelDoor : MonoBehaviour {

	public string nextLevel = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Open() {
		if (nextLevel == "") {
			print("No level to go to!");
		} else {
			Application.LoadLevel(nextLevel);
		}
	}
}
