using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public GameObject loadingScene;
    public Slider slider;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(Load(sceneIndex));
    }

    IEnumerator Load(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScene.SetActive(true);

        while(operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
