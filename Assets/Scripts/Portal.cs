using UnityEngine;
using System.Collections;

public abstract class Portal : MonoBehaviour {

	public GameObject ExitDoor;
	public float positionOffset = 10f;
	public float currentTime = 0f;
	public float lifeTime = 5f; // in seconds
	public Color color;
	public bool doneSpawning = false;
	public bool doneMoving = true;

	// Use this for initialization
	protected virtual void Start () {
		if (!GameManager.CurrentPortals.Contains(this)) {
			GameManager.CurrentPortals.Add(this);
		}

		doneSpawning = false;
		SpawnExit();
		doneSpawning = true;

		Random.seed = System.DateTime.Now.Millisecond;
		color = new Color(Random.value, Random.value, Random.value, Random.Range(0.1f, 0.75f));
		ExitDoor.renderer.material.color = gameObject.renderer.material.color = color;
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {

	}

	protected abstract void SpawnExit();

	public virtual void ClosePortals() {
		GameManager.CurrentPortals.Remove(this);
		Destroy(ExitDoor);
		Destroy(gameObject);
	}

	public virtual void EnterPortal(GameObject obj) {
		while (!doneMoving) {}
		obj.transform.position = ExitDoor.transform.position;
		ClosePortals();
	}
}
