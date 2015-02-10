using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject player;

	// Portal Tracking
	static public List<Portal> CurrentPortals;
	static public int _maxPortals = 3;

	void Awake() {
		CurrentPortals = new List<Portal>();
	}

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
			RestartLevel();
		}
	}

	bool PlayerIsOffScreen() {
		Rect screenRect = new Rect(0,0, Screen.width, Screen.height);

		// Calculate the edges of the player
		Bounds playerBounds = player.transform.collider.bounds;
		Vector3 left = playerBounds.center,
				right = playerBounds.center,
				top = playerBounds.center,
				bottom = playerBounds.center;
		left.x -= playerBounds.extents.x;
		right.x += playerBounds.extents.x;
		top.y += playerBounds.extents.y;
		bottom.y -= playerBounds.extents.y;

		// Convert to screen points
		left = Camera.main.WorldToScreenPoint(left);
		right = Camera.main.WorldToScreenPoint(right);
		top = Camera.main.WorldToScreenPoint(top);
		bottom = Camera.main.WorldToScreenPoint(bottom);

		// Only offscreen once ALL sides are offscreen
		return !(screenRect.Contains(left) || screenRect.Contains(right) ||
				 screenRect.Contains(top) || screenRect.Contains(bottom));
	}

	void RestartLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}

	static public bool MaxPortalsAlive() {
		return CurrentPortals.Count >= _maxPortals;
	}
	static public void CloseEarliestPortal() {
		Portal p = CurrentPortals[0];
		p.ClosePortals();
	}
}
