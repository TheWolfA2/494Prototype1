using UnityEngine;
using System.Collections;

public class PortalResolutions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PortalEntrance" || other.tag == "PortalExit") {
			print ("Portal entered!");
		}
	}

	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
	
}
