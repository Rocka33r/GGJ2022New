using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public CanvasGroup fade;
	public Animation[] elevators;
	public Animation[] cars;
	
	private void Start()
	{
		StartCoroutine(startRoutine());
	}
		
	private IEnumerator elevatorRoutine()
	{
		yield return new WaitForSeconds(2);
		elevators[0].Play();
		yield return new WaitForSeconds(4);
		elevators[2].Play();
		yield return new WaitForSeconds(8);
		elevators[1].Play();
	}
	
	private IEnumerator startRoutine()
	{
		StartCoroutine(elevatorRoutine());
		StartCoroutine(carRoutine());
		yield return new WaitForSeconds(2);
		LeanTween.alphaCanvas(fade, 0, 3);
	}

	private IEnumerator carRoutine()
	{
		yield return new WaitForSeconds(2);
		cars[0].Play();
		yield return new WaitForSeconds(4);
		cars[1].Play();
		yield return new WaitForSeconds(3);
		cars[2].Play();
	}
}
