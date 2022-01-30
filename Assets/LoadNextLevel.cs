using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int sceneIndex;
    public CanvasGroup alpha;

    public void loadScene()
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(loadFade());
    }

    private IEnumerator loadFade()
    {
        LeanTween.alphaCanvas(alpha, 1, 1);
        yield return new WaitForSeconds(1);
        loadScene();

    }
}
