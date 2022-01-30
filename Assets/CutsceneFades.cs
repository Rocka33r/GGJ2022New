using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFades : MonoBehaviour
{
    public CanvasGroup fade;
    public AudioSource rain;
    public AudioSource elevator;
    public AudioSource city;
    public AudioSource ding;
    public AudioSource rainInterior;

	public void fadeIn()
	{
		LeanTween.alphaCanvas(fade, 1, 1.5f);
	}
	
	public void fadeOut()
	{
		LeanTween.alphaCanvas(fade, 0, 1.5f);
	}

    public void playElevator()
    {
        elevator.Play();
    }

    public void stopElevator()
    {
        elevator.Stop();
    }

    public void playCity()
    {
        city.Play();
    }

    public void stopCity()
    {
        city.Stop();
    }

    public void playDing()
    {
        ding.Play();
    }

    public void playRainInterior()
    {
        rainInterior.Play();
    }

    public void playRain()
    {
        rain.Play();
    }

    public void stopRain()
    {
        rain.Stop();
    }
}
