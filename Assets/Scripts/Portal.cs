using UnityEngine;
using System.Collections;

public abstract class Portal : MonoBehaviour {

	public GameObject ExitDoor;
	public float positionOffset = 10f;
	public float currentTime = 0f;
	public float lifeTime = 5f; // in seconds

	// Use this for initialization
	protected virtual void Start () {
		SpawnExit();
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {

	}

	protected abstract void SpawnExit();

	protected virtual void ClosePortals() {
		Destroy(ExitDoor);
		Destroy(gameObject);
	}

	public virtual void EnterPortal(GameObject obj) {
		obj.transform.position = ExitDoor.transform.position;
		ClosePortals();
	}
}
