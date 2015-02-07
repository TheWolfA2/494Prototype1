using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {

	public float rotationOffset = 90;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		LookAtMouse();
	}

	void LookAtMouse() {
		// Find mouse and adjust it's z position
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Camera.main.transform.position.z;
		if (!MouseIsOnScreen(mousePos)) {
			return;
		}

		// Find the difference ot the arm's position and mouses
		Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
		targetPos = targetPos - transform.position;
		targetPos.Normalize();

		// Calculate the angle the arm need to be at and assign it
		float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,angle + rotationOffset);
	}

	bool MouseIsOnScreen(Vector3 mousePos) {
		Rect screenRect = new Rect(0,0, Screen.width, Screen.height);
		return screenRect.Contains(mousePos);
	}
}
