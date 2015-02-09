using UnityEngine;
using System.Collections;

public class WallPlacer : MonoBehaviour {

	public GameObject Floor;
	public GameObject Ceiling;
	public bool isLeft = true;
	public float posOffset = 0.5f;

	// Use this for initialization
	void Start () {
		Floor = GameObject.Find("Main Floor");
		Ceiling = GameObject.Find("Ceiling");

		float roomHeight = Mathf.Abs(Floor.transform.position.y - Ceiling.transform.position.y);
		Vector3 newScale = transform.lossyScale;
		newScale.y = roomHeight;// / 2f;
		transform.localScale = newScale;

		Vector3 wallPos = Floor.transform.position;
		wallPos.y += transform.lossyScale.y / 2f; // half the height of the wall
		if (isLeft) {
			wallPos.x -= (Floor.transform.lossyScale.x / 2f - posOffset);
		} else {
			wallPos.x += (Floor.transform.lossyScale.x / 2f - posOffset);
		}
		transform.position = wallPos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
