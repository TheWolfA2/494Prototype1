using UnityEngine;
using System.Collections;

public class LevelDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Open() {
		int nextLevel = Application.loadedLevel + 1;
		if (nextLevel == Application.levelCount) {
			nextLevel = 0;
		}

		Application.LoadLevel(nextLevel);
	}
}
