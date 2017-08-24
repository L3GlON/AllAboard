using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;

    AsyncOperation async;

    public void StartGame()
    {
        StartCoroutine("LoadingScreen");
    }


    IEnumerator LoadingScreen()
    {
        loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            loadingSlider.value = async.progress;
            if (async.progress == 0.9f)
            {
                loadingSlider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
