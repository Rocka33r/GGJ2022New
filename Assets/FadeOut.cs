using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public CanvasGroup canvas;

    private void Start()
    {
        LeanTween.alphaCanvas(canvas, 0, 1);
    }

    
}
