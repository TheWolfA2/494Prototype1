using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject V_Portal;
	public GameObject H_Portal;
	public float currentTimeout = 0f;
	public float portalTimeout = 3f;

	public float walkSpeed = 10f;
	public float jumpSpeed = 8f;
	public float portalBuffer = 0.5f;


	// Use this for initialization
	void Start () {
		// Allow the user to generate portals immediately
		currentTimeout = portalTimeout;
	}

	void FixedUpdate() {
		if (currentTimeout < portalTimeout) {
			currentTimeout += Time.deltaTime;
		}
	}

	// Update is called once per frame
	void Update () {
		Walk(Input.GetAxis("Horizontal"));
		//Jump(Input.GetAxis("Vertical") > 0);
		if (Input.GetButton("Fire1")) {
			SummonPortal(true);
		}
		if (Input.GetButton("Fire2")) {
			SummonPortal(false);
		}
		CheckForWall();
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

	void CheckForWall() {
		// Get the velocity
		Vector3 horizontalMove = transform.rigidbody.velocity;
		// Don't use the vertical velocity
		horizontalMove.y = 0;
		// Calculate the approximate distance that will be traversed
		float distance =  horizontalMove.magnitude * Time.deltaTime;
		// Normalize horizontalMove since it should be used to indicate direction
		horizontalMove.Normalize();
		RaycastHit hit;
		
		// Check if the body's current velocity will result in a collision
		if(transform.rigidbody.SweepTest(horizontalMove, out hit, distance))
		{
			// If so, stop the movement
			transform.rigidbody.velocity = new Vector3(0, transform.rigidbody.velocity.y, 0);
		}
	}


	void SummonPortal(bool isVertical) {
		if (currentTimeout >= portalTimeout) {
			// Reset timer
			currentTimeout = 0;

			// Spawn at the mouse's location
			Vector3 portalLocation = Input.mousePosition;
			portalLocation = Camera.main.ScreenToWorldPoint(portalLocation);
			portalLocation.z = transform.position.z; // line up with player

			if (GameManager.MaxPortalsAlive()) {
				GameManager.CloseEarliestPortal();
			}
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
		} else if (other.tag == "Door") {
//			print ("Entered a door!");
			EnterDoor(other.GetComponent<LevelDoor>());
		}
	}

	void Teleport(Portal p) {
		p.EnterPortal(gameObject);

		// Clear any movement player was experiencing before entering portal
		Vector3 newVel = transform.rigidbody.velocity;
		newVel.x = newVel.y = 0;
		transform.rigidbody.velocity = newVel;
	}

	void EnterDoor(LevelDoor d) {
		d.Open();
	}
}
