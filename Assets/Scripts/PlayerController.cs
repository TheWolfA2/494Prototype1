using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject V_Portal;
	public GameObject H_Portal;
	public float currentTimeout = 0f;
	public float portalTimeout = 3f;

	public float walkSpeed = 10f;
	public float jumpSpeed = 8f;


	// Use this for initialization
	void Start () {
	}

	void FixedUpdate() {
		if (currentTimeout < portalTimeout) {
			currentTimeout += Time.deltaTime;
		}
	}

	// Update is called once per frame
	void Update () {
		Walk(Input.GetAxis("Horizontal"));
		Jump(Input.GetAxis("Vertical") > 0);
		if (Input.GetButton("Fire1")) {
			SummonPortal(true);
		}
		if (Input.GetButton("Fire2")) {
			SummonPortal(false);
		}
	}

	void Walk(float horizInput) {
		Vector2 newVel = transform.rigidbody.velocity;
		newVel.x = walkSpeed * horizInput;
		transform.rigidbody.velocity = newVel;
	}
	
	void Jump(bool jump) {
		if (!jump) {
			return;
		}
		Vector2 newVel = transform.rigidbody.velocity;
		newVel.y = jumpSpeed;
		transform.rigidbody.velocity = newVel;
	}

	void SummonPortal(bool isVertical) {
		if (currentTimeout >= portalTimeout) {
			// Reset timer
			currentTimeout = 0;

			// Spawn at the mouse's location
			Vector3 portalLocation = Input.mousePosition;
			portalLocation = Camera.main.ScreenToWorldPoint(portalLocation);
			portalLocation.z = transform.position.z; // line up with player

			if (isVertical) {
				SummonVPortal(portalLocation);
			} else {
				SummonHPortal(portalLocation);
			}
		}
	}
	void SummonVPortal(Vector3 loc) {
		Instantiate(V_Portal, loc, new Quaternion());
	}
	void SummonHPortal(Vector3 loc) {
		Instantiate(H_Portal, loc, new Quaternion());
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PortalEntrance") {
			Teleport(other.GetComponent<Portal>());
		}
	}

	void Teleport(Portal p) {
		p.EnterPortal(gameObject);
	}
}
