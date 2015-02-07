using UnityEngine;
using System.Collections;

public class Portal_Vertical : Portal {

	override
	protected void SpawnExit() {
		Vector3 exitLocation = transform.position;
		exitLocation.y += positionOffset;
		ExitDoor = Instantiate(ExitDoor, exitLocation, new Quaternion()) as GameObject;
	}
}
