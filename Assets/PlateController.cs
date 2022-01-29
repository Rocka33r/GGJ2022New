using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
	public StageController stage;
	public int doorIndex;
	public int plateAmount;
	
	public bool triggered;
        private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Box")
				triggered = true;
			stage.checkDoorOpen(doorIndex, plateAmount);
		}
		
		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == "Box")
				triggered = false;
		}

}
