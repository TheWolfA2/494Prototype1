using UnityEngine;
using System.Collections;

public class Portal_Horizontal : Portal {
	
	override
	protected void SpawnExit() {
		// TODO: Resolve spawning exiting inside of something
		Vector3 exitLocation = transform.position;
		exitLocation.x += positionOffset;
		ExitDoor = Instantiate(ExitDoor, exitLocation, new Quaternion()) as GameObject;
	}
}
