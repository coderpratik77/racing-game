using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {
    public GameObject loadingScreen;
    public Slider Slider;
    public Text progressText;

    public void LoadLevel (int sceneIndex));
    StartCoroutine(LoadAsynchronously (sceneIndex));
    if (Time.timeScale == 0f) {
        Time.timeScale =1.0f;
        
    } else{
        Time.timeScale = 1f;

    }



}
IEnumerator LoadAsynchronously(int sceneIndex)
{
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    loadingScreen.SetActive (true);
    while(!operation.isDone) {
        flaot progress = Mathf.Clamp01(operation.progress / .9f);
        Slider.value = progress;
        progress.Text.text = progress * 100f + "%";
        yield return null;
    }
}

public void QuitApplicationFun()
{
    Application.Quit();
}
