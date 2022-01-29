using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public Animation[] doorAnims;
	public PlateController[] plates;
	
	private bool allReqDoorsOpen;
	
	public void checkDoorOpen(int doorIndex, int plateAmount)
	{
		allReqDoorsOpen = true;
		for(int i = 0; i<plateAmount; i++)
		{
			if (!plates[i].triggered)
				allReqDoorsOpen = false;
		}
		
		if (allReqDoorsOpen)
			doorAnims[doorIndex].Play();
	}
	
}
