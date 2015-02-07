using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject V_Portal;
	public GameObject H_Portal;

	public float walkSpeed = 10f;
	public float jumpSpeed = 8f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Walk(Input.GetAxis("Horizontal"));
		Jump(Input.GetAxis("Vertical") > 0);
		if (Input.GetButton("Fire1")) {
			SummonVPortal();
		}
		if (Input.GetButton("Fire2")) {
			SummonHPortal();
		}
	}

	void Walk(float horizInput) {
		Vector2 newVel = transform.rigidbody.velocity;
		newVel.x = walkSpeed * horizInput;
		transform.rigidbody.velocity = newVel;
	}
	
	void Jump(bool isJumping) {
		if (!isJumping) {
			return;
		}
		Vector2 newVel = transform.rigidbody.velocity;
		newVel.y = jumpSpeed;
		transform.rigidbody.velocity = newVel;
	}

	void SummonVPortal() {
		Instantiate(V_Portal);
	}

	void SummonHPortal() {
		Instantiate(H_Portal);
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
