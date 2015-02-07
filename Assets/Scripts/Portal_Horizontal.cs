using UnityEngine;
using System.Collections;

public class Portal_Horizontal : Portal {
	
	override
	protected void SpawnExit() {
		Vector3 exitLocation = transform.position;
		exitLocation.x += positionOffset;
		ExitDoor = Instantiate(ExitDoor, exitLocation, new Quaternion()) as GameObject;
	}
}
