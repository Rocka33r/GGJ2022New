using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFades : MonoBehaviour
{
    public CanvasGroup fade;
	
	public void fadeIn()
	{
		LeanTween.alphaCanvas(fade, 1, 1.5f);
	}
	
	public void fadeOut()
	{
		LeanTween.alphaCanvas(fade, 0, 1.5f);
	}
}
