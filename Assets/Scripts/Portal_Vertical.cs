using UnityEngine;
using System.Collections;

public class Portal_Vertical : Portal {

	override
	protected void SpawnExit() {
		// TODO: Resolve spawning exiting inside of something
		Vector3 exitLocation = transform.position;
		exitLocation.y += positionOffset;
		ExitDoor = Instantiate(ExitDoor, exitLocation, new Quaternion()) as GameObject;
	}
}
