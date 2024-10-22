﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text text;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchrounously(sceneIndex));
    }

    IEnumerator LoadAsynchrounously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
             slider.value = progress;
            text.text = Mathf.RoundToInt(progress * 100) + "%";

            yield return null;
        }
    }
}
