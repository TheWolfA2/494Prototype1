using UnityEngine;
using System.Collections;

public class FloorSizing : MonoBehaviour {

	public float widthOffset = 1f;

	// Use this for initialization
	void Awake () {
		Vector3 newScale = transform.lossyScale;
		newScale.x = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
		newScale.x -= widthOffset;
		transform.localScale = newScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
