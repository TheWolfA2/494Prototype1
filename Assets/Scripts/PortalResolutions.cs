using UnityEngine;
using System.Collections;

public enum PushDirection {
	up,
	down,
	left,
	right,
}

public class PortalResolutions : MonoBehaviour {

	public PushDirection pushTo = PushDirection.up;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PortalEntrance" || other.tag == "PortalExit") {
//			print ("Portal entered!");
			ResolvePortalCollision(other);
		}
	}

	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}

	void ResolvePortalCollision(Collider other) {
		// Case order: Up,Left,Down,Right
		Vector3 newPortalPos = other.transform.position;

		switch (pushTo) {
		case PushDirection.up:
			newPortalPos.y = CalculateNewY(other.transform.localScale.y, true);
			break;
		
		case PushDirection.left:
			newPortalPos.x = CalculateNewX(other.transform.localScale.x, false);
			break;
		
		case PushDirection.down:
			newPortalPos.y = CalculateNewY(other.transform.localScale.y, false);
			break;
		
		case PushDirection.right:
			newPortalPos.x = CalculateNewX(other.transform.localScale.x, true);
			break;
		}

		other.transform.position = newPortalPos;
	}

	float CalculateNewX(float portalWidth, bool pushRight) {
		float x = transform.position.x,
			  offset = (transform.localScale.x / 2f + portalWidth / 2f);
		if (pushRight) {
			x += offset;
		} else {
			x -= offset;
		}
		return x;
	}
	float CalculateNewY(float portalHeight, bool pushUp) {
		float y = transform.position.y,
		      offset = (transform.localScale.y / 2f + portalHeight / 2f);
		if (pushUp) {
			y += offset;
		} else {
			y -= offset;
		}
		return y;
	}
}
