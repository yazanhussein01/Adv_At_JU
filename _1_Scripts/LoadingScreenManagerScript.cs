using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManagerScript : MonoBehaviour
{
    //to store all the screens in one place
    [SerializeField] GameObject[] LoadingScreens;
    [SerializeField] GameObject LoadingCircle;
    
    public void LoadScreen(int sceneIndex)
    {
        StartCoroutine(LoadScreenAsync(0, sceneIndex));
    }

    IEnumerator LoadScreenAsync(int screenIndex, int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScreens[screenIndex].SetActive(true);

        while (!operation.isDone)
        {
            LoadingCircle.transform.Rotate(new Vector3(0, 0, -5));
            yield return null;
        }
    }
}
