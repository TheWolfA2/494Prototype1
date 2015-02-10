using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Restart")) {
			RestartLevel();
		}
		if (PlayerIsOffScreen()) {
			print("Offscreen!");
		}
	}

	bool PlayerIsOffScreen() {
		Rect screenRect = new Rect(0,0, Screen.width, Screen.height);
//		Vector3 playerPos = player.transform.position;
//		playerPos = Camera.main.WorldToScreenPoint(playerPos);
		Bounds playerBounds = player.transform.collider.bounds;
		Vector3 left = playerBounds.center,
				right = playerBounds.center,
				top = playerBounds.center,
				bottom = playerBounds.center;
		left.x -= playerBounds.extents.x;
		right.x += playerBounds.extents.x;
		top.y += playerBounds.extents.y;
		bottom.y -= playerBounds.extents.y;

		left = Camera.main.WorldToScreenPoint(left);
		right = Camera.main.WorldToScreenPoint(right);
		top = Camera.main.WorldToScreenPoint(top);
		bottom = Camera.main.WorldToScreenPoint(bottom);

		return !(screenRect.Contains(left) || screenRect.Contains(right) ||
				 screenRect.Contains(top) || screenRect.Contains(bottom));
	}

	void RestartLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
